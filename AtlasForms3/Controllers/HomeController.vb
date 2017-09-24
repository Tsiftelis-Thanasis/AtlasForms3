Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Imports System.IO
Imports System.Net
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D


<Compress>
Public Class HomeController
    Inherits System.Web.Mvc.Controller


    Private pdb As New AtlasStatisticsEntities

    Private pdb_blog As New AtlasBlogEntities



    Function Index(Optional ak As Integer = 0) As ActionResult

        '3   Γενικά Νέα
        '11  Νέα
        '12  Ομάδες
        '13  Τιμωρίες
        '14  Πρόγραμμα
        '15  Βαθμολογίες
        '17  ΔΗΛΩΣΕΙΣ

        ViewBag.LastNewsList = GetLastNewsByCategory(10, ak, {6, 7, 16}, Nothing, 1, 1).Data.data
        ViewBag.LastGamesList = Getlastgames(ak).Data
        ViewBag.LastNews1 = GetLastNews(10, ak, 1, Nothing, {3, 11, 13, 17}, 1, Nothing).Data.data
        ViewBag.LastNews2 = GetLastNews(10, ak, Nothing, Nothing, {3, 11, 13, 17}, Nothing, Nothing).Data.data

        ViewBag.WeeklyStat1 = GetWeeklyReportStat1(Nothing, ak).Data
        ViewBag.WeeklyStat2 = GetWeeklyReportStat2(Nothing, ak).Data
        ViewBag.WeeklyStat3 = GetWeeklyReportStat3(Nothing, ak).Data
        ViewBag.WeeklyStat4 = GetWeeklyReportStat4(Nothing, ak).Data
        ViewBag.WeeklyStat5 = GetWeeklyReportStat5(Nothing, ak).Data

        ViewBag.PhotosList = GetFwtografies().Data

        ViewBag.AtlasKathgoria = ak
        Return View()

    End Function

    <Authorize(Roles:="Admins")>
    Function Panel() As ActionResult
        ViewData("Message") = "Control panel page."

        Return View()
    End Function


    Function Contact() As ActionResult

        Return View()

    End Function


    ' POST: Newteam/Create
    <HttpPost()>
    Public Async Function Contact(ByVal name As String, ByVal email As String, ByVal subj As String, ByVal body As String, ByVal copy As Boolean) As Threading.Tasks.Task(Of ActionResult)

        If name = "" Or email = "" Or subj = "" Or body = "" Then

            ModelState.AddModelError("", "Πρέπει να συμπληρώσετε το oνοματεπώνυμο, το email, το θέμα και το κείμενο")
            Return View()

        End If

        Dim ha As New Utils


        subj = "Επικοινωνία μέσω site με θέμα: " & subj
        body = "<h3>Τα σχόλια της επικοινωνίας</h3><hr>" & body & "<hr>"

        Await ha.sendContactformEmailAsync(name, email, subj, body, copy)

        'ModelState.AddModelError("", "Έγινε η αποστολή!")
        'Return View()

        Return RedirectToAction("Index", "Home")

    End Function




    <AllowAnonymous>
    Function SetGlobalDiorganwshid(ByVal id As Integer?) As Boolean


        If id IsNot Nothing Then
            If id > 0 Then
                Session("GlobalDiorganwshid") = id
            End If
        End If

        Return True

    End Function

    <Compress>
    Public Function GetWeeklyReportStat1(ByVal omid As Integer?, ByVal kid As Integer?) As JsonResult

        If omid Is Nothing Then omid = 0
        If kid Is Nothing Then kid = 0

        Dim s = (From proc In pdb.GetWeeklyReportStat1All(omid, kid)
                 Select proc).Take(5).AsEnumerable().[Select](
                    Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                            .tid = o.teamId, .tname = o.teamname,
                                                            .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                            .Row = o.Row,
                                                            .val = o.totalpoints}).ToList()
        Return Json(s, JsonRequestBehavior.AllowGet)

    End Function

    <Compress>
    Public Function GetWeeklyReportStat2(ByVal omid As Integer?, ByVal kid As Integer?) As JsonResult

        If omid Is Nothing Then omid = 0
        If kid Is Nothing Then kid = 0

        Dim s = (From proc In pdb.GetWeeklyReportStat2All(omid, kid)
                 Select proc).Take(5).AsEnumerable().[Select](
                   Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                           .tid = o.teamId, .tname = o.teamname,
                                                           .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                           .Row = o.Row,
                                                           .val = o.totalassists}).ToList()
        Return Json(s, JsonRequestBehavior.AllowGet)


    End Function

    <Compress>
    Public Function GetWeeklyReportStat3(ByVal omid As Integer?, ByVal kid As Integer?) As JsonResult

        If omid Is Nothing Then omid = 0
        If kid Is Nothing Then kid = 0

        Dim s = (From proc In pdb.GetWeeklyReportStat3All(omid, kid)
                 Select proc).Take(5).AsEnumerable().[Select](
                   Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                           .tid = o.teamId, .tname = o.teamname,
                                                           .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                           .Row = o.Row,
                                                           .val = o.totalrebounds}).ToList()
        Return Json(s, JsonRequestBehavior.AllowGet)

    End Function

    <Compress>
    Public Function GetWeeklyReportStat4(ByVal omid As Integer?, ByVal kid As Integer?) As JsonResult

        If omid Is Nothing Then omid = 0
        If kid Is Nothing Then kid = 0

        Dim s = (From proc In pdb.GetWeeklyReportStat4All(omid, kid)
                 Select proc).Take(5).AsEnumerable().[Select](
                   Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                           .tid = o.teamId, .tname = o.teamname,
                                                           .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                           .Row = o.Row,
                                                           .val = o.totalsteals}).ToList()
        Return Json(s, JsonRequestBehavior.AllowGet)

    End Function

    <Compress>
    Public Function GetWeeklyReportStat5(ByVal omid As Integer?, ByVal kid As Integer?) As JsonResult

        If omid Is Nothing Then omid = 0
        If kid Is Nothing Then kid = 0

        Dim s = (From proc In pdb.GetWeeklyReportStat5All(omid, kid)
                 Select proc).Take(5).AsEnumerable().[Select](
                   Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                           .tid = o.teamId, .tname = o.teamname,
                                                           .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                           .Row = o.Row,
                                                           .val = o.totalblocks}).ToList()
        Return Json(s, JsonRequestBehavior.AllowGet)

    End Function

    <Compress>
    Public Function GetRankingsStats(ByVal kathgoriaid As Integer) As JsonResult

        Dim omilosid = (From o In pdb.OmilosTable
                        Join k In pdb.KathgoriesTable On o.Id Equals k.Omilosid
                        Where k.Id = kathgoriaid
                        Select o.Id).FirstOrDefault

        Dim diorganwshid = (From d In pdb.DiorganwshTable
                            Join o In pdb.OmilosTable On d.Id Equals o.Diorganwshid
                            Where o.Id = omilosid
                            Select d.Id).FirstOrDefault

        Dim seasonid = (From s1 In pdb.SeasonTable
                        Join d In pdb.DiorganwshTable On s1.Id Equals d.Seasonid
                        Where d.Id = diorganwshid
                        Select s1.Id).FirstOrDefault

        Dim s = (From proc In pdb.getallteamsrankings(seasonid, diorganwshid, omilosid, kathgoriaid)
                 Select proc).ToList

        Dim stats = s.AsEnumerable.Select(Function(o) New With {.sid = o.thisid, .scount = o.ncount, .sname = o.thisname, .season = o.SeasonName, .diorganwsh = o.DiorganwshName,
                                                                    .omilos = o.OmilosName, .kathgoria = o.KathgoriaName,
                                                                    .nikes = o.nikes, .isopalies = o.isopalies, .httes = o.httes, .totalplayed = o.totalplayed, .totalpoints = o.totalpoints,
                                                                    .diaforapontwn = o.diaforapontwn, .bathmoi = o.bathmoi, .mhdenismoi = o.mhdenismoi
                                                                    }).ToArray


        Return Json(stats, JsonRequestBehavior.AllowGet)


    End Function

    '<Compress>
    'Public Function Getdiorganwseis() As JsonResult

    '    Dim kat = (From d In pdb.DiorganwshTable
    '               Join s In pdb.SeasonTable On s.Id Equals d.Seasonid
    '               Where s.ActiveSeason = True
    '               Order By d.DiorganwshName
    '               Select d.DiorganwshName, d.Id).ToList

    '    Return Json(kat, JsonRequestBehavior.AllowGet)


    'End Function

    <Compress>
    Public Function GetOmiloiByDiorganwsh(ByVal dId As Integer) As JsonResult

        Dim om = (From o In pdb.OmilosTable
                  Join d In pdb.DiorganwshTable On d.Id Equals o.Diorganwshid
                  Where d.Id = dId
                  Order By o.OmilosName
                  Select o.OmilosName, o.Id).ToList

        Return Json(om, JsonRequestBehavior.AllowGet)


    End Function


    <Compress>
    Public Function GetKathgoriesbyOmilos(ByVal OId As Integer) As JsonResult

        Dim om = (From k In pdb.KathgoriesTable
                  Join o In pdb.OmilosTable On o.Id Equals k.Omilosid
                  Where o.Id = OId
                  Order By k.KathgoriaName
                  Select k.KathgoriaName, k.Id).AsEnumerable.
                  Select(Function(o) New With {
                        .Id = o.Id, .KathgoriaName =
                            If(o.KathgoriaName.Contains("("), o.KathgoriaName.Split("(").ToArray(0), o.KathgoriaName)
                        }).ToList


        Return Json(om, JsonRequestBehavior.AllowGet)


    End Function

    <Compress>
    Public Function Getlastgames(ByVal kathgoria As Integer?) As JsonResult

        'Link
        'Date as Σαβ 01/06/2017 
        'gipedo ??
        'omada a, pontoi a,
        'omada b, pontoi b         

        If kathgoria Is Nothing Then kathgoria = 0

        Dim lastgames = (From g In pdb.GamesTable
                         Join ta In pdb.TeamsStatisticsTable On ta.Gameid Equals g.Id
                         Join teama In pdb.TeamsTable On ta.Teamid Equals teama.Id
                         Join tb In pdb.TeamsStatisticsTable On tb.Gameid Equals g.Id
                         Join teamb In pdb.TeamsTable On tb.Teamid Equals teamb.Id
                         Where ta.gipedouxos = 1 And tb.gipedouxos = 0 And
                             If(kathgoria = 0, 1 = 1, g.Kathgoriaid = kathgoria)
                         Order By g.Id Descending
                         Select g.Id, Gamedate = g.Gamedate,
                             g.Gamestadium, team1 = teama.TeamName, team1score = ta.ptstotal,
                            team2 = teamb.TeamName, team2score = tb.ptstotal).Take(10).
                            AsEnumerable.Select(Function(o) New With {
                            .Id = o.Id, .Gamedate = o.Gamedate.GetValueOrDefault().ToString("ddd") & " " & o.Gamedate.GetValueOrDefault().ToString("dd/MM/yyyy"),
                             .Gamestadium = o.Gamestadium, .team1 = o.team1, .team1score = o.team1score,
                            .team2 = o.team2, .team2score = o.team2score
                            }).ToList


        Return Json(lastgames, JsonRequestBehavior.AllowGet)


    End Function

    <Compress>
    Public Function GetProgrammaidbyKathgoria(ByVal atlaskathgoriaid As Integer?) As JsonResult

        If atlaskathgoriaid Is Nothing Then atlaskathgoriaid = 0

        Dim thisid = (From t In pdb_blog.BlogPostandKathgoriaTable
                      Where t.AtlasKathgoriaId = atlaskathgoriaid And t.KathgoriaId = 14
                      Select t.PostId).FirstOrDefault

        Return Json(thisid, JsonRequestBehavior.AllowGet)

    End Function

    <Compress>
    Public Function GetKathgories(ByVal id As Integer) As JsonResult

        Dim q = (From d In pdb.KathgoriesTable
                 Join s In pdb.OmilosTable On d.Omilosid Equals s.Id
                 Where s.Id = id
                 Select d.KathgoriaName, did = d.Id
            ).AsEnumerable().[Select](
            Function(o) New With {.text = o.KathgoriaName, .value = o.did})

        Return Json(q.ToArray(), JsonRequestBehavior.AllowGet)

    End Function


    <Compress>
    Function GetTeamsbyKathgoria(ByVal kid As Integer) As JsonResult


        Dim q = (From t In pdb.TeamsTable
                 Join tk In pdb.TeamsandKathgoriesTable On t.Id Equals tk.TeamId
                 Join k In pdb.KathgoriesTable On k.Id Equals tk.KathgoriaId
                 Join o In pdb.OmilosTable On o.Id Equals k.Omilosid
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
    Function GetFwtografies() As JsonResult

        Dim fwtos As New List(Of String)

        Try

            Dim tempFolder As String = System.Web.HttpContext.Current.Server.MapPath("~/Content/tempimages/")

            For Each f As String In Directory.GetFiles(tempFolder)
                Dim fi As FileInfo = New FileInfo(f)
                fwtos.Add("/Content/tempimages/" & fi.Name)
            Next


            Dim j As New JsonResult
            j.MaxJsonLength = Integer.MaxValue
            j = Json(fwtos, JsonRequestBehavior.AllowGet)

            Return j

        Catch ex As Exception

            Return Nothing

        End Try

    End Function

    '<Authorize(Roles:="Admins")>
    'Public Sub Resizeimages()

    '    Dim a As New Utils
    '    a.resizepostimages()

    'End Sub


    'Public Async Function sendtheemail() As Threading.Tasks.Task



    '    Dim ha As New Utils



    '    Await ha.sendEmailsync("tsiftelis.thanasis@gmail.com", "test", "Please confirm your account by clicking <a href=""http://atlasbasket2.gr.144-76-99-45.my-website-preview.com/Posts/?ak=49&k=11"">here</a>", False)


    'End Function


    <Compress>
    Public Function GetLastNewsByCategory(ByVal nCount As Integer, ByVal atlaskathgoria As Integer?, ByVal k() As Integer?, ByVal k2() As Integer?,
                                          ByVal withphoto As Integer?, ByVal withvideo As Integer?) As JsonResult

        If atlaskathgoria Is Nothing Then atlaskathgoria = 0
        If k Is Nothing Then k = {3} 'Teleutaia nea!
        If k2 Is Nothing Then k2 = {11} 'Teleutaia nea omilou!

        If withphoto Is Nothing Then withphoto = 0
        If withvideo Is Nothing Then withvideo = 0


        If atlaskathgoria = 0 Then

            Dim q = (From p In pdb_blog.BlogPostsTable
                     Join p1 In pdb_blog.BlogPostandKathgoriaTable On p1.PostId Equals p.Id
                     Join p2 In pdb_blog.BlogKathgoriesTable On p2.Id Equals p1.KathgoriaId
                     Where p.Activepost = True And (k.Contains(p1.KathgoriaId) And p1.IsKathgoria = True) And
                          If(withphoto = 1, Not p.PostPhotoStr Is Nothing, 1 = 1) And
                            If(withvideo = 1, Not p.Youtubelink Is Nothing, 1 = 1)
                     Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                         PostPhoto = p.PostPhotoStr, PostPhoto2 = p.PostPhoto160_160Str, Youtubelink = p.Youtubelink, editBy = p.EditBy,
                        KatName = p2.KathgoriaName).Take(nCount).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                        .PostPhoto = If(o.PostPhoto Is Nothing, "", o.PostPhoto),
                        .PostPhoto2 = If(o.PostPhoto2 Is Nothing, "", o.PostPhoto2),
                        .Youtubelink = o.Youtubelink,
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

            Dim kl = (From o In pdb.KathgoriesTable
                      Where o.Id = atlaskathgoria
                      Select o.Id).ToList

            Dim q = (From p In pdb_blog.BlogPostsTable
                     Join p1 In pdb_blog.BlogPostandKathgoriaTable On p1.PostId Equals p.Id
                     Join p2 In pdb_blog.BlogKathgoriesTable On p2.Id Equals p1.KathgoriaId
                     Join klist In kl On klist Equals p1.AtlasKathgoriaId
                     Where p.Activepost = True And (k.Contains(p1.KathgoriaId) And p1.IsAtlasKathgoria = True) And
                          If(withphoto = 1, Not p.PostPhotoStr Is Nothing, 1 = 1) And
                         If(withvideo = 1, Not p.Youtubelink Is Nothing, 1 = 1)
                     Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                         PostPhoto = p.PostPhotoStr, PostPhoto2 = p.PostPhoto160_160Str, Youtubelink = p.Youtubelink, editBy = p.EditBy,
                        KatName = p2.KathgoriaName).Take(nCount).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                        .PostPhoto = If(o.PostPhoto Is Nothing, "", o.PostPhoto),
                        .PostPhoto2 = If(o.PostPhoto2 Is Nothing, "", o.PostPhoto2),
                        .Youtubelink = o.Youtubelink,
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
    Function GetLastNews(ByVal nCount As Integer, ByVal atlaskathgoria As Integer?,
                         ByVal withphoto As Integer?, ByVal withvideo As Integer?, ByVal k() As Integer?,
                         ByVal isSlider As Integer?, ByVal orderByName As Integer?) As JsonResult

        If atlaskathgoria Is Nothing Then atlaskathgoria = 0
        If withphoto Is Nothing Then withphoto = 0
        If withvideo Is Nothing Then withvideo = 0
        If isSlider Is Nothing Then isSlider = 0
        If orderByName Is Nothing Then orderByName = 0

        Dim kl = (From o In pdb.KathgoriesTable
                  Where o.Id = atlaskathgoria
                  Select o.Id).ToList

        '1   Διοργανώτρια Αρχή -> oxi
        '3   Γενικά Νέα
        '6   MVP
        '7   Καλύτερες φάσεις
        '11  Νέα
        '12  Ομάδες -> oxi
        '13  Τιμωρίες 
        '14  Πρόγραμμα -> oxi
        '15  Βαθμολογίες -> oxi
        '16  Τοπ 10
        '17  ΔΗΛΩΣΕΙΣ

        If k Is Nothing Or k.Count = 0 Or k.FirstOrDefault = 0 Then
            k = {3, 6, 7, 11, 13, 16, 17} 'Teleutaia nea!
        End If


        Try


            If kl.Count > 0 Then

                Dim q = (From p In pdb_blog.BlogPostsTable
                         Join pk In pdb_blog.BlogPostandKathgoriaTable On pk.PostId Equals p.Id
                         Join klist In kl On klist Equals pk.AtlasKathgoriaId
                         Where p.Activepost = True And
                             If(withphoto = 1, Not p.PostPhotoStr Is Nothing, 1 = 1) And
                             If(withvideo = 1, Not p.Youtubelink Is Nothing, 1 = 1) And
                            k.Contains(pk.KathgoriaId)
                         Select p
                         Order By p.Id Descending
                             ).Take(nCount).AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody,
                        .PostPhoto = If(o.PostPhotoStr Is Nothing, "", o.PostPhotoStr),
                        .PostPhoto2 = If(o.PostPhoto160_160Str Is Nothing, "", o.PostPhoto160_160Str)
                        }).ToList()

                If orderByName > 0 Then
                    q = q.OrderBy(Function(a) a.PostTitle).ToList
                Else
                    q = q.OrderByDescending(Function(a) a.Id).ToList
                End If

                Dim dtm As New DataTableModel
                If q IsNot Nothing Then
                    dtm.data = q.Cast(Of Object).ToList
                End If
                dtm.draw = 0
                dtm.recordsTotal = dtm.data.Count
                dtm.recordsFiltered = dtm.recordsTotal

                Return Json(dtm, JsonRequestBehavior.AllowGet)

            Else

                Dim q = (From p In pdb_blog.BlogPostsTable
                         Join pk In pdb_blog.BlogPostandKathgoriaTable On pk.PostId Equals p.Id
                         Where p.Activepost = True And
                             If(withphoto = 1, Not p.PostPhotoStr Is Nothing, 1 = 1) And
                             If(withvideo = 1, Not p.Youtubelink Is Nothing, 1 = 1) And
                             If(isSlider = 1, 1 = 1, pk.AtlasKathgoriaId Is Nothing) And
                             k.Contains(If(pk.KathgoriaId, 0))
                         Select p
                         Order By p.Id Descending
                             ).Take(nCount).AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody,
                        .PostPhoto = If(o.PostPhotoStr Is Nothing, "", o.PostPhotoStr),
                        .PostPhoto2 = If(o.PostPhoto160_160Str Is Nothing, "", o.PostPhoto160_160Str)
                    }).ToList()

                If orderByName > 0 Then
                    q = q.OrderBy(Function(a) a.PostTitle).ToList
                Else
                    q = q.OrderByDescending(Function(a) a.Id).ToList
                End If

                Dim dtm As New DataTableModel
                If q IsNot Nothing Then
                    dtm.data = q.Cast(Of Object).ToList
                End If
                dtm.draw = 0
                dtm.recordsTotal = dtm.data.Count
                dtm.recordsFiltered = dtm.recordsTotal

                Return Json(dtm, JsonRequestBehavior.AllowGet)

            End If

        Catch ex As Exception

        End Try

    End Function




End Class
