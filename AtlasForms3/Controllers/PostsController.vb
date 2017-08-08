Imports System.IO
Imports System.Web.Mvc

Namespace Controllers

    <Compress>
    Public Class PostsController
        Inherits Controller

        Private pdb As New AtlasBlogEntities
        Private pdb2 As New AtlasStatisticsEntities

        ' GET: Posts
        Function Index(Optional a As Integer = 0, Optional ak As Integer = 0,
                      Optional ByVal k As Integer = 0) As ActionResult

            ViewBag.AtlasKathgoria = ak
            ViewBag.AtlasOmilos = a
            ViewBag.Kathgoria = k
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


                Dim q = (From t In pdb.BlogPostsTable
                         Where t.Id = id
                         Select t).First

                Dim t1 As New Posts
                t1.Id = q.Id
                t1.Activepost = q.Activepost
                t1.PostTitle = q.PostTitle
                t1.PostBody = q.PostBody
                t1.PostPhoto = q.PostPhoto
                t1.PostSummary = q.PostSummary
                t1.Youtubelink = "https://www.youtube.com/embed/" & q.Youtubelink & "?rel=0"
                t1.Statslink = q.Statslink
                t1.createdby = q.CreatedBy
                t1.creationdate = q.CreationDate
                t1.editby = q.EditBy
                t1.editdate = q.EditDate

                Return View(t1)

            Else

                Return Nothing

            End If

        End Function

        ' GET: Posts/Create
        <Authorize(Roles:="Admins")>
        Function Create() As ActionResult
            Return View()
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

            If ModelState.IsValid Then

                Try

                    Dim newpost As New BlogPostsTable

                    newpost.PostTitle = p1.PostTitle
                    newpost.PostBody = p1.PostBody
                    If Not logodata Is Nothing Then
                        newpost.PostPhoto = logodata
                    End If
                    newpost.PostSummary = p1.PostSummary
                    newpost.Youtubelink = p1.Youtubelink
                    newpost.Statslink = p1.Statslink
                    newpost.Activepost = 1
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

                    Return RedirectToAction("Index", "Posts")

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
            t1.PostPhoto = q.PostPhoto
            t1.Youtubelink = q.Youtubelink
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

            If ModelState.IsValid Then

                Try

                    Dim editpost = pdb.BlogPostsTable.Find(p1.Id)

                    editpost.PostTitle = p1.PostTitle
                    editpost.PostBody = p1.PostBody
                    editpost.PostSummary = p1.PostSummary
                    If Not logodata Is Nothing Then
                        editpost.PostPhoto = logodata
                    End If
                    editpost.Youtubelink = p1.Youtubelink
                    editpost.Statslink = p1.Statslink
                    editpost.Activepost = If(p1.Activepost, 1, 0)
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

                    Return RedirectToAction("Index", "Posts")

                Catch ex As Exception
                    ModelState.AddModelError("error_msg", ex.Message)
                    Return View(p1)
                End Try


            Else
                ModelState.AddModelError("error_msg", "error with model")
                Return View(p1)

            End If

        End Function

        '' GET: Posts/Delete/5
        '<Authorize(Roles:="Admins")>
        'Function Delete(ByVal id As Integer) As ActionResult
        '    Return View()
        'End Function

        '' POST: Posts/Delete/5
        '<HttpPost()>
        '<Authorize(Roles:="Admins")>
        'Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        '    Try
        '        ' TODO: Add delete logic here

        '        Return RedirectToAction("Index")
        '    Catch
        '        Return View()
        '    End Try
        'End Function


        <Compress>
        Function GetNews() As JsonResult

            Dim q = (From p In pdb.BlogPostsTable
                     Select p).AsEnumerable().[Select](
                    Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editby = o.EditBy,
                    .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto)))}).ToList

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
        Function GetLastNews(ByVal nCount As Integer, ByVal atlasomilosid As Integer?) As JsonResult

            If atlasomilosid Is Nothing Then atlasomilosid = 0

            Dim kl = (From o In pdb2.OmilosTable
                      Join k In pdb2.KathgoriesTable On k.Omilosid Equals o.Id
                      Where o.Id = atlasomilosid
                      Select k.Id).ToList

            If kl.Count > 0 Then

                Dim q = (From p In pdb.BlogPostsTable
                         Join pk In pdb.BlogPostandKathgoriaTable On pk.PostId Equals p.Id
                         Join klist In kl On klist Equals pk.AtlasKathgoriaId
                         Select p
                         Order By p.Id Descending
                         ).Take(nCount).AsEnumerable().[Select](
                    Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody,
                    .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto)))}).ToList()

                Dim dtm As New DataTableModel
                If q IsNot Nothing Then
                    dtm.data = q.Cast(Of Object).ToList
                End If
                dtm.draw = 0
                dtm.recordsTotal = dtm.data.Count
                dtm.recordsFiltered = dtm.recordsTotal

                Return Json(dtm, JsonRequestBehavior.AllowGet)



            Else
                Dim q = (From p In pdb.BlogPostsTable
                         Select p
                         Order By p.Id Descending
                         ).Take(nCount).AsEnumerable().[Select](
                    Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody,
                    .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto)))}).ToList()

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
        Function GetLastNewsByCategory(ByVal nCount As Integer, ByVal atlasomilosid As Integer?) As JsonResult

            If atlasomilosid Is Nothing Then atlasomilosid = 0

            Dim k As Integer = 3 'Teleutaia nea!
            Dim k2 As Integer = 11 'Teleutaia nea omilou!

            If atlasomilosid = 0 Then

                Dim q = (From p In pdb.BlogPostsTable
                         Join p1 In pdb.BlogPostandKathgoriaTable On p1.PostId Equals p.Id
                         Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p1.KathgoriaId
                         Where (p1.KathgoriaId = k And p1.IsKathgoria = True)
                         Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                             PostPhoto = p.PostPhoto, Youtubelink = p.Youtubelink, editBy = p.EditBy,
                            KatName = p2.KathgoriaName).Take(nCount).
                            AsEnumerable().[Select](
                            Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                            .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto))), .Youtubelink = o.Youtubelink,
                            .KatName = o.KatName}).ToList
                Dim dtm As New DataTableModel
                If q IsNot Nothing Then
                    dtm.data = q.Cast(Of Object).ToList
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
                         Where (p1.KathgoriaId = k2 And p1.IsAtlasKathgoria = True)
                         Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                             PostPhoto = p.PostPhoto, Youtubelink = p.Youtubelink, editBy = p.EditBy,
                            KatName = p2.KathgoriaName).Take(nCount).
                            AsEnumerable().[Select](
                            Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                            .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto))), .Youtubelink = o.Youtubelink,
                            .KatName = o.KatName}).ToList
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
        Function GetLastNewswithVideo() As JsonResult

            Dim ar2 = (From p In pdb.BlogPostsTable
                       Where Not p.Youtubelink Is Nothing
                       Order By p.Id Descending
                       Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostPhoto = p.PostPhoto, Youtubelink = p.Youtubelink
                           ).Take(5).AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .PostTitle = If(o.PostTitle Is Nothing, "", o.PostTitle.Substring(0, Math.Min(50, o.PostTitle.Length)) & "..."),
                        .PostSummary = If(o.PostSummary Is Nothing, "", o.PostSummary.Substring(0, Math.Min(150, o.PostSummary.Length)) & "..."),
                        .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto))),
                        .Youtubelink = o.Youtubelink
                        }).ToArray

            Dim dtm As New DataTableModel
            If ar2 IsNot Nothing Then
                dtm.data = ar2.Cast(Of Object).ToList
            End If
            dtm.draw = 0
            dtm.recordsTotal = dtm.data.Count
            dtm.recordsFiltered = dtm.recordsTotal

            Return Json(dtm, JsonRequestBehavior.AllowGet)

        End Function

        <Compress>
        Function GetLastNewsByCategory2(ByVal nCount As Integer, ByVal KathgoriaId As Integer,
                                        Optional ByVal IsKathgoria As Integer = 0,
                                        Optional ByVal IsYpokathgoria As Integer = 0,
                                        Optional ByVal IsAtlasOmilos As Integer = 0,
                                        Optional ByVal IsAtlasKathgoria As Integer = 0) As JsonResult

            If IsKathgoria > 0 Then

                Dim q = (From p In pdb.BlogPostsTable
                         Join p1 In pdb.BlogPostandKathgoriaTable On p1.PostId Equals p.Id
                         Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p1.AtlasKathgoriaId
                         Where p1.AtlasKathgoriaId = KathgoriaId And p1.IsKathgoria = True
                         Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                             PostPhoto = p.PostPhoto, Youtubelink = p.Youtubelink, editBy = p.EditBy,
                            KatName = p2.KathgoriaName).Take(nCount).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                        .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto))), .Youtubelink = o.Youtubelink,
                        .KatName = o.KatName}).ToList
                Dim dtm As New DataTableModel
                If q IsNot Nothing Then
                    dtm.data = q.Cast(Of Object).ToList
                End If
                dtm.draw = 0
                dtm.recordsTotal = dtm.data.Count
                dtm.recordsFiltered = dtm.recordsTotal

                Return Json(dtm, JsonRequestBehavior.AllowGet)

            ElseIf IsAtlasOmilos > 0 Then

                Dim ar1 = (From o In pdb2.OmilosTable
                           Join k In pdb2.KathgoriesTable On k.Omilosid Equals o.Id
                           Select Omilos = o.Id, o.OmilosName, Kathgoria = k.Id, k.KathgoriaName).
                           AsEnumerable().Select(Function(a) New With {
                           .Omilos = a.Omilos, .Omilosname = a.OmilosName, .Kathgoria = a.Kathgoria, .KathgoriaName = a.KathgoriaName
                           }).ToArray

                Dim ar2 = (From p In pdb.BlogPostsTable
                           Join p1 In pdb.BlogPostandKathgoriaTable On p1.PostId Equals p.Id
                           Where p1.AtlasKathgoriaId = KathgoriaId And p1.IsAtlasOmilos = True
                           Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                             PostPhoto = p.PostPhoto, Youtubelink = p.Youtubelink, editBy = p.EditBy, kathgoria = p1.AtlasKathgoriaId).Take(nCount).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .Kathgoria = o.kathgoria, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                        .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto))), .Youtubelink = o.Youtubelink
                        }).ToArray

                Dim q = (From a2 In ar2
                         Join a1 In ar1 On a2.Kathgoria Equals a1.Kathgoria
                         Select a1.Omilos, a1.Omilosname, a1.Kathgoria, a1.KathgoriaName, a2.Id, a2.PostTitle, a2.PostSummary, a2.PostBody,
                         a2.PostPhoto, a2.Youtubelink, a2.editBy).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .Kathgoria = o.Kathgoria, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                        .PostPhoto = o.PostPhoto, .Youtubelink = o.Youtubelink, .KatName = o.Omilosname & "-" & o.KathgoriaName
                        }).ToList

                Dim dtm As New DataTableModel
                If q IsNot Nothing Then
                    dtm.data = q.Cast(Of Object).ToList
                End If
                dtm.draw = 0
                dtm.recordsTotal = dtm.data.Count
                dtm.recordsFiltered = dtm.recordsTotal

                Return Json(dtm, JsonRequestBehavior.AllowGet)

            Else

                Dim ar1 = (From o In pdb2.OmilosTable
                           Join k In pdb2.KathgoriesTable On k.Omilosid Equals o.Id
                           Select Omilos = o.Id, o.OmilosName, Kathgoria = k.Id, k.KathgoriaName).
                           AsEnumerable().Select(Function(a) New With {
                           .Omilos = a.Omilos, .Omilosname = a.OmilosName, .Kathgoria = a.Kathgoria, .KathgoriaName = a.KathgoriaName
                           }).ToArray

                Dim ar2 = (From p In pdb.BlogPostsTable
                           Join p1 In pdb.BlogPostandKathgoriaTable On p1.PostId Equals p.Id
                           Where p1.AtlasKathgoriaId = KathgoriaId And p1.IsAtlasKathgoria = True
                           Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                             PostPhoto = p.PostPhoto, Youtubelink = p.Youtubelink, editBy = p.EditBy, kathgoria = p1.AtlasKathgoriaId).Take(nCount).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .Kathgoria = o.kathgoria, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                        .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto))), .Youtubelink = o.Youtubelink
                        }).ToArray

                Dim q = (From a2 In ar2
                         Join a1 In ar1 On a2.Kathgoria Equals a1.Kathgoria
                         Select a1.Omilos, a1.Omilosname, a1.Kathgoria, a1.KathgoriaName, a2.Id, a2.PostTitle, a2.PostSummary, a2.PostBody,
                         a2.PostPhoto, a2.Youtubelink, a2.editBy).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .Kathgoria = o.Kathgoria, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                        .PostPhoto = o.PostPhoto, .Youtubelink = o.Youtubelink, .KatName = o.Omilosname & "-" & o.KathgoriaName
                        }).ToList

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
                           If(KathgoriaId > 0, p1.KathgoriaId = KathgoriaId, 1 = 1) And
                           If(AtlasOmilosid > 0, p1.AtlasKathgoriaId = AtlasOmilosid, 1 = 1)
                       Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                        PostPhoto = p.PostPhoto, Youtubelink = p.Youtubelink, editBy = p.EditBy, kathgoria = p1.AtlasKathgoriaId).Take(nCount).
                AsEnumerable().[Select](
                Function(o) New With {.Id = o.Id, .Kathgoria = o.kathgoria, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto))), .Youtubelink = o.Youtubelink
                }).ToArray

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


            'Dim q = (From p In pdb.BlogPostsTable
            '         Join p1 In pdb.BlogPostandKathgoriaTable On p1.PostId Equals p.Id
            '         Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p1.KathgoriaId
            '         Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary,
            '         editBy = p.EditBy, editDate = p.EditDate, KatName = p2.KathgoriaName).AsEnumerable().[Select](
            '        Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary,
            '        .editBy = o.editBy, .editDate = CDate(o.editDate).ToString("dd/MM/yyyy"), .KatName = o.KatName}).ToList


            Dim ar1 = (From o In pdb2.OmilosTable
                       Join k In pdb2.KathgoriesTable On k.Omilosid Equals o.Id
                       Select Omilos = o.Id, o.OmilosName, Kathgoria = k.Id, k.KathgoriaName).
                    AsEnumerable().Select(Function(a) New With {
                    .Omilos = a.Omilos, .Omilosname = a.OmilosName, .Kathgoria = a.Kathgoria, .KathgoriaName = a.KathgoriaName
                    }).ToArray

            Dim ar2 = (From p In pdb.BlogPostsTable
                       Join p1 In pdb.BlogPostandKathgoriaTable On p1.PostId Equals p.Id
                       Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p1.KathgoriaId
                       Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                         editBy = p.EditBy, editDate = p.EditDate, KathgoriaName = p2.KathgoriaName, atlaskathgoria = p1.AtlasKathgoriaId).
                AsEnumerable().[Select](
                Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody,
                        .editBy = o.editBy, .editDate = CDate(o.editDate).ToString("dd/MM/yyyy"), .KathgoriaName = o.KathgoriaName, .atlaskathgoria = o.atlaskathgoria}).ToArray

            Dim q = (From a2 In ar2
                     Where a2.atlaskathgoria Is Nothing
                     Select a2.Id, a2.PostTitle, a2.PostSummary, a2.PostBody, a2.editBy, a2.editDate, a2.KathgoriaName).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy, .editDate = o.editDate,
                        .KathgoriaName = o.KathgoriaName, .AtlasKathgoria = "", .AtlasOmilos = ""
                        }).
                        Union(From a2 In ar2
                              Where Not a2.atlaskathgoria Is Nothing
                              Join a1 In ar1 On a1.Kathgoria Equals a2.atlaskathgoria
                              Select a2.Id, a2.PostTitle, a2.PostSummary, a2.PostBody, a2.editBy, a2.editDate, a2.KathgoriaName, AtlasKathgoria = a1.KathgoriaName, AtlasOmilos = a1.Omilosname).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy, .editDate = o.editDate,
                        .KathgoriaName = o.KathgoriaName, .AtlasKathgoria = o.AtlasKathgoria, .AtlasOmilos = o.AtlasOmilos
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



    End Class

End Namespace