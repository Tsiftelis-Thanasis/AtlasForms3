Imports System.IO
Imports System.Web.Mvc
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Net

Namespace Controllers

    <Compress>
    Public Class PostsController
        Inherits Controller

        Private pdb As New AtlasBlogEntities
        Private pdb2 As New AtlasStatisticsEntities

        ' GET: Posts
        Function Index(Optional a As Integer = 0, Optional ak As Integer = 0,
                      Optional ByVal k As Integer = 0,
                       Optional ByVal sl As Integer = 0) As ActionResult

            ViewBag.AtlasKathgoria = ak
            ViewBag.AtlasOmilos = a
            ViewBag.Kathgoria = k
            ViewBag.simplelist = sl

            ViewBag.GetTeamsbyKathgoriaList = GetTeamsbyKathgoria(ak).Data.data
            ViewBag.GetWeeklyGamesList = GetWeeklyGames(Nothing, ak).Data

            Return View()

        End Function


        ' GET: Posts
        <Authorize(Roles:="Admins")>
        Function All() As ActionResult

            Return View()

        End Function


        ' GET: Posts/Details/5
        Function Details(ByVal id As Integer, Optional ByVal k As Integer = 0, Optional ByVal yk As Integer = 0) As ActionResult

            If id > 0 Then

                Try

                    Dim q = (From t In pdb.BlogPostsTable
                             Where t.Id = id
                             Select t).First

                    Dim pq As Integer? = 0
                    pq = (From pk In pdb.BlogPostandKathgoriaTable
                          Where pk.PostId = q.Id
                          Select pk.KathgoriaId).FirstOrDefault

                    Dim ak As Integer? = 0
                    ak = (From pk2 In pdb.BlogPostandKathgoriaTable
                          Where pk2.PostId = q.Id
                          Select pk2.AtlasKathgoriaId).FirstOrDefault

                    Dim agonistiki As Integer? = 0
                    If Not q.agonistiki Is Nothing And pq = 14 Then
                        agonistiki = q.agonistiki
                    Else
                        agonistiki = 0
                    End If

                    '7 & 16
                    '3 & 11 & 13
                    Dim intArrray As String = ","
                    If pq = 7 Or pq = 16 Then
                        intArrray &= "7,16"
                    ElseIf pq = 3 Or pq = 11 Or pq = 16 Then
                        intArrray &= "3,11,16"
                    Else
                        intArrray &= pq
                    End If
                    intArrray &= ","

                    Dim s = (From proc In pdb.GetPreviousandNextpostid(id, intArrray, If(ak Is Nothing, 0, ak), agonistiki)
                             Select proc.PreviousPostId, proc.NextPostId).FirstOrDefault


                    Dim t1 As New Posts
                    t1.Id = id

                    If pq = 14 And User.Identity.IsAuthenticated = False Then

                        ModelState.AddModelError("", "Το περιεχόμενο δεν είναι διαθέσιμο. Πρέπει να συνδεθείτε για να το δείτε!")
                        Return View(t1)

                    End If

                    t1.Activepost = q.Activepost
                    t1.PostTitle = q.PostTitle
                    t1.PostBody = q.PostBody
                    t1.PostPhotoStr = q.PostPhotoStr
                    t1.PostSummary = q.PostSummary
                    t1.Youtubelink = "https://www.youtube.com/embed/" & q.Youtubelink & "?rel=0"
                    t1.Agonistiki = If(q.agonistiki Is Nothing, 0, q.agonistiki)
                    t1.Statslink = q.Statslink
                    t1.createdby = q.CreatedBy
                    t1.creationdate = q.CreationDate
                    t1.editby = q.EditBy
                    t1.editdate = q.EditDate



                    ViewBag.postimage = q.PostPhotoStr
                    ViewBag.PreviousPostId = s.PreviousPostId
                    ViewBag.NextPostId = s.NextPostId


                    Return View(t1)

                Catch ex As Exception

                    ModelState.AddModelError("", ex.Message)

                    Return View()

                End Try


            Else

                Return View()

            End If

        End Function

        ' GET: Posts/Create
        <Authorize(Roles:="Admins")>
        Function Create() As ActionResult

            Dim p As New Posts
            p.Activepost = 1
            Return View(p)

        End Function

        ' POST: Posts/Create
        <HttpPost()>
        <Authorize(Roles:="Admins")>
        Function Create(ByVal p1 As Posts, ByVal kathgoria As String(), ByVal omilos As String(), ByVal atlaskathgoria As String(),
                        ByVal uploadEditorImage As HttpPostedFileBase) As ActionResult

            Dim logodata As Byte() = Nothing

            If uploadEditorImage IsNot Nothing Then
                If uploadEditorImage.ContentLength > 0 Then

                    Dim target As New MemoryStream()
                    uploadEditorImage.InputStream.CopyTo(target)
                    logodata = target.ToArray()

                End If
            End If

            If logodata Is Nothing And p1.Youtubelink <> "" Then
                'mono gia  
                '16  Τοp 10
                '17  ΔΗΛΩΣΕΙΣ
                Dim kat1 = If(kathgoria Is Nothing, Nothing, kathgoria(0))
                If kat1 = 16 Or kat1 = 17 Then
                    Dim webClient As New WebClient()
                    logodata = webClient.DownloadData("http://img.youtube.com/vi/" & p1.Youtubelink & "/hqdefault.jpg")
                End If

            End If

                Dim thisfolder As String = "/Content/postimages/" & Now.Month & Now.Year & "/"
            Dim postimagesfolder As String = System.Web.HttpContext.Current.Server.MapPath(thisfolder)

            Dim exists As Boolean = System.IO.Directory.Exists(postimagesfolder)
            If Not exists Then
                Directory.CreateDirectory(postimagesfolder)
            End If

            Dim newname As Guid
            newname = Guid.NewGuid()

            Dim imageStr As String = thisfolder & newname.ToString & ".png" 'db save
            Dim imageStr1 As String = thisfolder & newname.ToString & "_medium.png" 'db save
            Dim imageStr2 As String = thisfolder & newname.ToString & "_small.png" 'db save

            Dim tempimage As String = postimagesfolder & newname.ToString & "original.png" 'local save and delete
            Dim imageStrtoSave As String = postimagesfolder & newname.ToString & ".png" 'local save
            Dim imageStr1toSave As String = postimagesfolder & newname.ToString & "_medium.png" 'local save
            Dim imageStr2toSave As String = postimagesfolder & newname.ToString & "_small.png" 'local save

            If ModelState.IsValid Then

                Try

                    Dim newpost As New BlogPostsTable

                    newpost.PostTitle = p1.PostTitle
                    newpost.PostBody = p1.PostBody
                    If Not logodata Is Nothing Then

                        Using memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream(logodata, False)
                            Using image1 As System.Drawing.Image = System.Drawing.Image.FromStream(memoryStream)
                                If (System.IO.File.Exists(imageStrtoSave)) Then System.IO.File.Delete(imageStrtoSave)
                                image1.Save(tempimage)
                            End Using
                        End Using

                        Dim u As New Utils
                        Using original As Image = Image.FromFile(tempimage)

                            u.resizeimages_upd(tempimage, imageStrtoSave, 0, 0)

                            If System.IO.File.ReadAllBytes(imageStrtoSave).Length > System.IO.File.ReadAllBytes(tempimage).Length Then
                                original.Save(imageStrtoSave)
                            End If

                            u.resizeimages_upd(imageStrtoSave, imageStr1toSave, 160, 160)
                            u.resizeimages_upd(imageStrtoSave, imageStr2toSave, 30, 30)

                        End Using
                        u = Nothing

                        newpost.PostPhotoStr = imageStr
                        newpost.PostPhoto160_160Str = imageStr1
                        newpost.PostPhoto30_30Str = imageStr2

                        If tempimage <> "" Then
                            If System.IO.File.Exists(tempimage) Then System.IO.File.Delete(tempimage)
                        End If


                    End If
                    newpost.PostSummary = p1.PostSummary
                    newpost.Youtubelink = p1.Youtubelink
                    newpost.Statslink = p1.Statslink
                    newpost.agonistiki = p1.Agonistiki
                    newpost.Activepost = If(p1.Activepost, 1, 0)
                    newpost.CreatedBy = User.Identity.Name
                    newpost.CreationDate = Now()
                    newpost.EditBy = User.Identity.Name
                    newpost.EditDate = Now()
                    pdb.BlogPostsTable.Add(newpost)
                    pdb.SaveChanges()

                        Dim kat = If(kathgoria Is Nothing, Nothing, kathgoria(0))
                        Dim om = If(omilos Is Nothing, Nothing, omilos(0))
                        Dim atlaskat = If(atlaskathgoria Is Nothing, Nothing, atlaskathgoria(0))

                        If Not (kat Is Nothing And om Is Nothing And atlaskat Is Nothing) Then
                        If kat <> "" Or om <> "" Or atlaskat <> "" Then

                            Dim newlink As New BlogPostandKathgoriaTable
                            newlink.PostId = newpost.Id
                            If kat <> "" Then
                                newlink.KathgoriaId = CInt(kat)
                                newlink.IsKathgoria = True
                            End If
                            If om <> "" And atlaskat = "" Then
                                newlink.AtlasKathgoriaId = CInt(om)
                                newlink.IsAtlasOmilos = True
                            End If
                            If atlaskat <> "" Then
                                newlink.AtlasKathgoriaId = CInt(atlaskat)
                                newlink.IsAtlasKathgoria = True
                            End If
                            newlink.CreationDate = Now()
                            newlink.EditBy = User.Identity.Name
                            newlink.EditDate = Now()
                            pdb.BlogPostandKathgoriaTable.Add(newlink)
                            pdb.SaveChanges()

                        End If

                    End If

                    Return RedirectToAction("All", "Posts")

                Catch ex As Exception
                    ModelState.AddModelError("error_msg", ex.Message)
                    Return View(p1)
                End Try


            Else
                ModelState.AddModelError("error_msg", "error with model")
                Return View(p1)

            End If

        End Function

        ' GET: Posts/Edit/5
        <Authorize(Roles:="Admins")>
        Function Edit(ByVal id As Integer) As ActionResult

            Dim q = (From t In pdb.BlogPostsTable
                     Where t.Id = id
                     Select t).First

            Dim t1 As New Posts
            t1.Id = q.Id
            t1.Activepost = q.Activepost
            t1.PostTitle = q.PostTitle
            t1.PostSummary = q.PostSummary
            t1.PostBody = q.PostBody
            t1.PostPhotoStr = q.PostPhotoStr
            t1.Youtubelink = q.Youtubelink
            t1.Agonistiki = If(q.agonistiki Is Nothing, 0, q.agonistiki)
            t1.Statslink = q.Statslink
            t1.createdby = q.CreatedBy
            t1.creationdate = q.CreationDate
            t1.editby = q.EditBy
            t1.editdate = q.EditDate

            Return View(t1)


        End Function

        ' POST: /Posts/Edit
        '<Authorize(Roles:="Admins")>

        <HttpPost()>
        <Authorize(Roles:="Admins")>
        Function Edit(ByVal p1 As Posts, ByVal kathgoria As String(), ByVal omilos As String(), ByVal atlaskathgoria As String(),
            ByVal uploadEditorImage As HttpPostedFileBase) As ActionResult

            Dim logodata As Byte() = Nothing

            If uploadEditorImage IsNot Nothing Then
                If uploadEditorImage.ContentLength > 0 Then

                    Dim target As New MemoryStream()
                    uploadEditorImage.InputStream.CopyTo(target)
                    logodata = target.ToArray()

                End If
            End If



            Dim thisfolder As String = "/Content/postimages/" & Now.Month & Now.Year & "/"
            Dim postimagesfolder As String = System.Web.HttpContext.Current.Server.MapPath(thisfolder)

            Dim exists As Boolean = System.IO.Directory.Exists(postimagesfolder)
            If Not exists Then
                Directory.CreateDirectory(postimagesfolder)
            End If

            Dim newname As Guid
            newname = Guid.NewGuid()

            Dim imageStr As String = thisfolder & newname.ToString & ".png" 'db save
            Dim imageStr1 As String = thisfolder & newname.ToString & "_medium.png" 'db save
            Dim imageStr2 As String = thisfolder & newname.ToString & "_small.png" 'db save

            Dim tempimage As String = postimagesfolder & newname.ToString & "original.png" 'local save and delete
            Dim imageStrtoSave As String = postimagesfolder & newname.ToString & ".png" 'local save
            Dim imageStr1toSave As String = postimagesfolder & newname.ToString & "_medium.png" 'local save
            Dim imageStr2toSave As String = postimagesfolder & newname.ToString & "_small.png" 'local save


            If ModelState.IsValid Then

                Try

                    Dim editpost = pdb.BlogPostsTable.Find(p1.Id)

                    editpost.PostTitle = p1.PostTitle
                    editpost.PostBody = p1.PostBody
                    editpost.PostSummary = p1.PostSummary
                    If Not logodata Is Nothing Then

                        Dim oldimage1 As String = ""
                        Dim oldimage2 As String = ""
                        Dim oldimage3 As String = ""

                        If Not editpost.PostPhotoStr Is Nothing Then
                            If editpost.PostPhotoStr.ToString <> "" Then
                                oldimage1 = editpost.PostPhotoStr.ToString
                            End If
                        End If
                        If Not editpost.PostPhoto160_160Str Is Nothing Then
                            If editpost.PostPhoto160_160Str.ToString <> "" Then
                                oldimage2 = editpost.PostPhoto160_160Str.ToString
                            End If
                        End If

                        If Not editpost.PostPhoto30_30Str Is Nothing Then
                            If editpost.PostPhoto30_30Str.ToString <> "" Then
                                oldimage3 = editpost.PostPhoto30_30Str.ToString
                            End If
                        End If

                        Using memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream(logodata, False)
                            Using image1 As System.Drawing.Image = System.Drawing.Image.FromStream(memoryStream)
                                If (System.IO.File.Exists(imageStrtoSave)) Then System.IO.File.Delete(imageStrtoSave)
                                image1.Save(tempimage)
                            End Using
                        End Using

                        Dim u As New Utils
                        Using original As Image = Image.FromFile(tempimage)

                            u.resizeimages_upd(tempimage, imageStrtoSave, 0, 0)

                            If System.IO.File.ReadAllBytes(imageStrtoSave).Length > System.IO.File.ReadAllBytes(tempimage).Length Then
                                original.Save(imageStrtoSave)
                            End If

                            u.resizeimages_upd(tempimage, imageStr1toSave, 160, 160)
                            u.resizeimages_upd(tempimage, imageStr2toSave, 30, 30)

                        End Using
                        u = Nothing

                        editpost.PostPhotoStr = imageStr
                        editpost.PostPhoto160_160Str = imageStr1
                        editpost.PostPhoto30_30Str = imageStr2

                        If tempimage <> "" Then
                            If System.IO.File.Exists(tempimage) Then System.IO.File.Delete(tempimage)
                        End If


                        If oldimage1 <> "" Then
                            If System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(oldimage1)) Then System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(oldimage1))
                        End If
                        If oldimage2 <> "" Then
                            If System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(oldimage2)) Then System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(oldimage2))
                        End If
                        If oldimage3 <> "" Then
                            If System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(oldimage3)) Then System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(oldimage3))
                        End If

                    End If

                    editpost.Youtubelink = p1.Youtubelink
                    editpost.Statslink = p1.Statslink
                    editpost.Activepost = If(p1.Activepost, 1, 0)
                    editpost.agonistiki = p1.Agonistiki
                    editpost.EditBy = User.Identity.Name
                    editpost.EditDate = Now()
                    pdb.SaveChanges()


                    Dim deletejoins = From tp In pdb.BlogPostandKathgoriaTable
                                      Where tp.PostId = p1.Id
                                      Select tp

                    For Each k In deletejoins.ToList()
                        pdb.BlogPostandKathgoriaTable.Remove(k)
                        pdb.SaveChanges()
                    Next


                    Dim kat = If(kathgoria Is Nothing, Nothing, kathgoria(0))
                    Dim om = If(omilos Is Nothing, Nothing, omilos(0))
                    Dim atlaskat = If(atlaskathgoria Is Nothing, Nothing, atlaskathgoria(0))

                    If Not (kat Is Nothing And om Is Nothing And atlaskat Is Nothing) Then
                        If kat <> "" Or om <> "" Or atlaskat <> "" Then

                            Dim newlink As New BlogPostandKathgoriaTable
                            newlink.PostId = editpost.Id
                            If kat <> "" Then
                                newlink.KathgoriaId = CInt(kat)
                                newlink.IsKathgoria = True
                            End If
                            If om <> "" And atlaskat = "" Then
                                newlink.AtlasKathgoriaId = CInt(om)
                                newlink.IsAtlasOmilos = True
                            End If
                            If atlaskat <> "" Then
                                newlink.AtlasKathgoriaId = CInt(atlaskat)
                                newlink.IsAtlasKathgoria = True
                            End If
                            newlink.CreationDate = Now()
                            newlink.EditBy = User.Identity.Name
                            newlink.EditDate = Now()
                            pdb.BlogPostandKathgoriaTable.Add(newlink)
                            pdb.SaveChanges()

                        End If

                    End If

                    Return RedirectToAction("All", "Posts")

                Catch ex As Exception
                    ModelState.AddModelError("error_msg", ex.Message)
                    Return View(p1)
                End Try


            Else
                ModelState.AddModelError("error_msg", "error with model")
                Return View(p1)

            End If

        End Function

        ' get: posts/delete/5
        <Authorize(Roles:="Admins")>
        Function Delete(ByVal id As Integer) As ActionResult

            If id > 0 Then


                Dim p = (From t In pdb.BlogPostsTable
                         Where t.Id = id
                         Select t).First

                Dim np As New Posts
                np.Id = p.Id
                np.PostTitle = p.PostTitle
                np.createdby = p.CreatedBy
                np.creationdate = p.CreationDate
                np.editby = p.EditBy
                np.editdate = p.EditDate
                Return View(np)

            Else

                Return Nothing

            End If

        End Function

        ' post: posts/delete/5
        <HttpPost()>
        <Authorize(Roles:="Admins")>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try

                Dim deletepost = From ps In pdb.BlogPostsTable
                                 Where ps.Id = id
                                 Select ps


                For Each p In deletepost.ToList

                    Dim deletejoins = From ps2 In pdb.BlogPostandKathgoriaTable
                                      Where ps2.PostId = p.Id
                                      Select ps2

                    For Each p2 In deletejoins.ToList
                        pdb.BlogPostandKathgoriaTable.Remove(p2)
                        pdb.SaveChanges()
                    Next


                    If Not p.PostPhotoStr Is Nothing Then
                        If p.PostPhotoStr.ToString <> "" Then
                            If System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(p.PostPhotoStr.ToString)) Then System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(p.PostPhotoStr.ToString))
                        End If
                    End If
                    If Not p.PostPhoto160_160Str Is Nothing Then
                        If p.PostPhoto160_160Str.ToString <> "" Then
                            If System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(p.PostPhoto160_160Str.ToString)) Then System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(p.PostPhoto160_160Str.ToString))
                        End If
                    End If

                    If Not p.PostPhoto30_30Str Is Nothing Then
                        If p.PostPhoto30_30Str.ToString <> "" Then
                            If System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(p.PostPhoto30_30Str.ToString)) Then System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(p.PostPhoto30_30Str.ToString))
                        End If
                    End If






                    pdb.BlogPostsTable.Remove(p)
                    pdb.SaveChanges()

                Next

                Return RedirectToAction("All", "Posts")

            Catch ex As Exception
                Return View(collection)
            End Try
        End Function

        <Compress>
        Function GetNews() As JsonResult

            Dim q = (From p In pdb.BlogPostsTable
                     Where p.Activepost = True
                     Select p).AsEnumerable().[Select](
                    Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editby = o.EditBy,
                    .PostPhoto = If(o.PostPhotoStr Is Nothing, "", o.PostPhotoStr)}).ToList
            Dim dtm As New DataTableModel
            If q IsNot Nothing Then
                dtm.data = q.Cast(Of Object).ToList
            End If
            dtm.draw = 0
            dtm.recordsTotal = dtm.data.Count
            dtm.recordsFiltered = dtm.recordsTotal
            Return Json(dtm, JsonRequestBehavior.AllowGet)
        End Function


        <Compress>
        Public Function GetSimplePosts(ByVal nCount As Integer, ByVal AtlasKathgoria As Integer?, ByVal k As Integer?, ByVal k2 As Integer?) As JsonResult

            If AtlasKathgoria Is Nothing Then AtlasKathgoria = 0
            If k Is Nothing Then k = 3 'Teleutaia nea!
            If k2 Is Nothing Then k2 = 11 'Teleutaia nea omilou!
            'Dim k As Integer = 3 'Teleutaia nea!
            'Dim k2 As Integer = 11 'Teleutaia nea omilou!

            If AtlasKathgoria = 0 Then

                Dim q = (From p In pdb.BlogPostsTable
                         Join p1 In pdb.BlogPostandKathgoriaTable On p1.PostId Equals p.Id
                         Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p1.KathgoriaId
                         Where p.Activepost = True And (p1.KathgoriaId = k And p1.IsKathgoria = True)
                         Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, KatName = p2.KathgoriaName).Take(nCount).
                            AsEnumerable().[Select](
                            Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .KatName = o.KatName}).ToList

                Dim dtm As New DataTableModel
                If q IsNot Nothing Then
                    dtm.data = q.Cast(Of Object).ToList
                End If
                dtm.draw = 0
                dtm.recordsTotal = dtm.data.Count
                dtm.recordsFiltered = dtm.recordsTotal

                Return Json(dtm, JsonRequestBehavior.AllowGet)

            Else

                Dim kl = (From o In pdb2.KathgoriesTable
                          Where o.Id = AtlasKathgoria
                          Select o.Id).ToList

                Dim q = (From p In pdb.BlogPostsTable
                         Join p1 In pdb.BlogPostandKathgoriaTable On p1.PostId Equals p.Id
                         Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p1.KathgoriaId
                         Join klist In kl On klist Equals p1.AtlasKathgoriaId
                         Where p.Activepost = True And (p1.KathgoriaId = k2 And p1.IsAtlasKathgoria = True)
                         Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, KatName = p2.KathgoriaName).Take(nCount).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .KatName = o.KatName}).ToList

                Dim dtm As New DataTableModel
                If q IsNot Nothing Then
                    dtm.data = q.Cast(Of Object).ToList
                End If
                dtm.draw = 0
                dtm.recordsTotal = dtm.data.Count
                dtm.recordsFiltered = dtm.recordsTotal

                Return Json(dtm, JsonRequestBehavior.AllowGet)


            End If

        End Function


        <Compress>
        Function GetKalyteresFaseisVideo(ByVal atlasomilosid As Integer?) As JsonResult

            If atlasomilosid Is Nothing Then atlasomilosid = 0

            Dim k As Integer = 7 'Καλυτερες φάσεις!

            If atlasomilosid = 0 Then

                Dim ar2 = (From p In pdb.BlogPostsTable
                           Join p1 In pdb.BlogPostandKathgoriaTable On p1.PostId Equals p.Id
                           Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p1.KathgoriaId
                           Where p.Activepost = True And Not p.Youtubelink Is Nothing And p2.Id = k And p1.IsAtlasKathgoria = False
                           Order By p.Id Descending
                           Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostPhoto = p.PostPhoto30_30Str, Youtubelink = p.Youtubelink
                           ).Take(5).AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .PostTitle = If(o.PostTitle Is Nothing, "", o.PostTitle.Substring(0, Math.Min(50, o.PostTitle.Length)) & "..."),
                        .PostSummary = If(o.PostSummary Is Nothing, "", o.PostSummary.Substring(0, Math.Min(150, o.PostSummary.Length)) & "..."),
                        .PostPhoto = If(o.PostPhoto Is Nothing, "", o.PostPhoto),
                        .Youtubelink = o.Youtubelink
                        }).ToArray

                '.PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto))),

                Dim dtm As New DataTableModel
                If ar2 IsNot Nothing Then
                    dtm.data = ar2.Cast(Of Object).ToList
                End If
                dtm.draw = 0
                dtm.recordsTotal = dtm.data.Count
                dtm.recordsFiltered = dtm.recordsTotal

                Return Json(dtm, JsonRequestBehavior.AllowGet)

            Else

                Dim kl = (From o In pdb2.OmilosTable
                          Join k1 In pdb2.KathgoriesTable On k1.Omilosid Equals o.Id
                          Where o.Id = atlasomilosid
                          Select k1.Id).ToList

                Dim q = (From p In pdb.BlogPostsTable
                         Join p1 In pdb.BlogPostandKathgoriaTable On p1.PostId Equals p.Id
                         Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p1.KathgoriaId
                         Join klist In kl On klist Equals p1.AtlasKathgoriaId
                         Where p.Activepost = True And Not p.Youtubelink Is Nothing And p2.Id = k And p1.IsAtlasKathgoria = True
                         Order By p.Id Descending
                         Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostPhoto = p.PostPhoto30_30Str, Youtubelink = p.Youtubelink
                           ).Take(5).AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .PostTitle = If(o.PostTitle Is Nothing, "", o.PostTitle.Substring(0, Math.Min(50, o.PostTitle.Length)) & "..."),
                        .PostSummary = If(o.PostSummary Is Nothing, "", o.PostSummary.Substring(0, Math.Min(150, o.PostSummary.Length)) & "..."),
                        .PostPhoto = If(o.PostPhoto Is Nothing, "", o.PostPhoto),
                        .Youtubelink = o.Youtubelink
                        }).ToArray

                '.PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto))),
                Dim dtm As New DataTableModel
                If q IsNot Nothing Then
                    dtm.data = q.Cast(Of Object).ToList
                End If
                dtm.draw = 0
                dtm.recordsTotal = dtm.data.Count
                dtm.recordsFiltered = dtm.recordsTotal

                Return Json(dtm, JsonRequestBehavior.AllowGet)


            End If


        End Function

        <Compress>
        Function GetLastNewsByBothCategories(ByVal nCount As Integer, ByVal AtlasOmilosid As Integer,
                                             ByVal KathgoriaId As Integer,
                                        Optional ByVal IsKathgoria As Integer = 0,
                                        Optional ByVal IsYpokathgoria As Integer = 0,
                                        Optional ByVal IsAtlasOmilos As Integer = 0,
                                        Optional ByVal IsAtlasKathgoria As Integer = 0) As JsonResult


            Dim ar1 = (From o In pdb2.OmilosTable
                       Join k In pdb2.KathgoriesTable On k.Omilosid Equals o.Id
                       Select Omilos = o.Id, o.OmilosName, Kathgoria = k.Id, k.KathgoriaName).
                    AsEnumerable().Select(Function(a) New With {
                    .Omilos = a.Omilos, .Omilosname = a.OmilosName, .Kathgoria = a.Kathgoria, .KathgoriaName = a.KathgoriaName
                    }).ToArray

            Dim ar2 = (From p In pdb.BlogPostsTable
                       Join p1 In pdb.BlogPostandKathgoriaTable On p1.PostId Equals p.Id
                       Where
                           p.Activepost = True And
                           If(KathgoriaId > 0, p1.KathgoriaId = KathgoriaId, 1 = 1) And
                           If(AtlasOmilosid > 0, p1.AtlasKathgoriaId = AtlasOmilosid, 1 = 1) And
                           If(IsKathgoria = 0 And IsAtlasKathgoria = 0, 1 = 2, 1 = 1)
                       Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                        PostPhoto = p.PostPhotoStr, Youtubelink = p.Youtubelink, editBy = p.EditBy, kathgoria = p1.AtlasKathgoriaId).Take(nCount).
                AsEnumerable().[Select](
                Function(o) New With {.Id = o.Id, .Kathgoria = o.kathgoria, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                .PostPhoto = If(o.PostPhoto Is Nothing, "", o.PostPhoto), .Youtubelink = o.Youtubelink
                }).ToArray

            '.PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto))), .Youtubelink = o.Youtubelink

            Dim q = (From a2 In ar2
                     Join a1 In ar1 On a2.Kathgoria Equals a1.Kathgoria
                     Select a1.Omilos, a1.Omilosname, a1.Kathgoria, a1.KathgoriaName, a2.Id, a2.PostTitle, a2.PostSummary, a2.PostBody,
                         a2.PostPhoto, a2.Youtubelink, a2.editBy).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .Kathgoria = o.Kathgoria, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                        .PostPhoto = o.PostPhoto, .Youtubelink = o.Youtubelink, .KatName = o.Omilosname, .Ypokatname = o.KathgoriaName
                        }).ToList

            Dim dtm As New DataTableModel
            If q IsNot Nothing Then
                dtm.data = q.Cast(Of Object).ToList
            End If
            dtm.draw = 0
            dtm.recordsTotal = dtm.data.Count
            dtm.recordsFiltered = dtm.recordsTotal

            Return Json(dtm, JsonRequestBehavior.AllowGet)

        End Function

        <Compress>
        Function GetAllthePosts() As JsonResult

            Dim ar1 = (From o In pdb2.OmilosTable
                       Join k In pdb2.KathgoriesTable On k.Omilosid Equals o.Id
                       Select Omilos = o.Id, o.OmilosName, Kathgoria = k.Id, k.KathgoriaName).
                    AsEnumerable().Select(Function(a) New With {
                    .Omilos = a.Omilos, .Omilosname = a.OmilosName, .Kathgoria = a.Kathgoria, .KathgoriaName = a.KathgoriaName
                    }).ToArray

            Dim ar2 = (From p In pdb.BlogPostsTable
                       Join p1 In pdb.BlogPostandKathgoriaTable On p1.PostId Equals p.Id
                       Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p1.KathgoriaId
                       Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary,
                         editBy = p.EditBy, editDate = p.EditDate, CreatedBy = p.CreatedBy, CreationDate = p.CreationDate,
                          KathgoriaName = p2.KathgoriaName, atlaskathgoria = p1.AtlasKathgoriaId, Active = If(p.Activepost = True, "Ναι", "Οχι")).
                AsEnumerable().[Select](
                Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary,
                        .editBy = o.editBy, .editDate = CDate(o.editDate).ToString("dd/MM/yyyy"),
                        .createdBy = o.CreatedBy, .creationDate = CDate(o.CreationDate).ToString("dd/MM/yyyy"),
                        .KathgoriaName = o.KathgoriaName, .atlaskathgoria = o.atlaskathgoria, .ActivePost = o.Active}).ToArray.OrderByDescending(Function(a) a.Id)

            Dim q1 = (From a2 In ar2
                      Where (a2.atlaskathgoria Is Nothing)
                      Select a2.Id, a2.PostTitle, a2.PostSummary,
                        a2.editBy, a2.editDate, a2.createdBy, a2.creationDate, a2.KathgoriaName, AtlasKathgoria = "", AtlasOmilos = "", a2.ActivePost).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary,
                         .editBy = o.editBy, .editDate = o.editDate,
                          .createdBy = o.createdBy, .creationDate = o.creationDate,
                        .KathgoriaName = o.KathgoriaName, .AtlasKathgoria = o.AtlasKathgoria, .AtlasOmilos = o.AtlasOmilos, .ActivePost = o.ActivePost}).ToArray

            Dim q2 = (From a2 In ar2
                      Join a1 In ar1 On a1.Kathgoria Equals a2.atlaskathgoria
                      Where Not (a2.atlaskathgoria Is Nothing)
                      Select a2.Id, a2.PostTitle, a2.PostSummary,
                        a2.editBy, a2.editDate, a2.createdBy, a2.creationDate, a2.KathgoriaName, AtlasKathgoria = a1.KathgoriaName, AtlasOmilos = a1.Omilosname, ActivePost = a2.ActivePost).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary,
                         .editBy = o.editBy, .editDate = o.editDate, .createdBy = o.createdBy, .creationDate = o.creationDate,
                        .KathgoriaName = o.KathgoriaName, .AtlasKathgoria = o.AtlasKathgoria, .AtlasOmilos = o.AtlasOmilos, .ActivePost = o.ActivePost}).ToArray

            Dim q = q1.Concat(q2)

            q = q.OrderByDescending(Function(a) Convert.ToInt32(a.Id)).ToArray

            Dim dtm As New DataTableModel
            If q IsNot Nothing Then
                dtm.data = q.Cast(Of Object).ToList
            End If
            dtm.draw = 0
            dtm.recordsTotal = dtm.data.Count
            dtm.recordsFiltered = dtm.recordsTotal

            Return Json(dtm, JsonRequestBehavior.AllowGet)


        End Function


        <Compress>
        Function GetTeamsbyKathgoria(ByVal kid As Integer) As JsonResult


            Dim q = (From t In pdb2.TeamsTable
                     Join tk In pdb2.TeamsandKathgoriesTable On t.Id Equals tk.TeamId
                     Join k In pdb2.KathgoriesTable On k.Id Equals tk.KathgoriaId
                     Join o In pdb2.OmilosTable On o.Id Equals k.Omilosid
                     Where k.Id = kid
                     Select Id = t.Id, Teamname = t.TeamName, Teamlogo = t.TeamLogo, k.KathgoriaName, o.OmilosName).
                         AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .TeamName = o.Teamname, .TeamLogo = If(o.Teamlogo Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.Teamlogo))),
                        .KathgoriaName = o.KathgoriaName, .OmilosName = o.OmilosName}).ToList

            Dim dtm As New DataTableModel
            If q IsNot Nothing Then
                dtm.data = q.Cast(Of Object).ToList
            End If
            dtm.draw = 0
            dtm.recordsTotal = dtm.data.Count
            dtm.recordsFiltered = dtm.recordsTotal

            Return Json(dtm, JsonRequestBehavior.AllowGet)


        End Function



        <Compress>
        Public Function GetWeeklyGames(ByVal omid As Integer?, ByVal kid As Integer?) As JsonResult

            If omid Is Nothing Then omid = 0
            If kid Is Nothing Then kid = 0

            Dim s = (From proc In pdb2.GetWeeklyGames(omid, kid)
                     Select proc).Take(7).AsEnumerable().[Select](
                        Function(o) New With {.gameid = o.gameid,
                            .t1id = o.t1id, .t1logo = If(o.t1logo Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.t1logo))), .t1name = o.t1name, .t1points = o.t1points,
                            .t2id = o.t2id, .t2logo = If(o.t2logo Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.t2logo))), .t2name = o.t2name, .t2points = o.t2points
                            }).ToList()
            Return Json(s, JsonRequestBehavior.AllowGet)

        End Function

    End Class

End Namespace