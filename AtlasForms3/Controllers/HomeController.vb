Imports System.IO
Imports System.Net
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D


<Compress>
Public Class HomeController
    Inherits System.Web.Mvc.Controller
    Function Index(Optional a As Integer = 0) As ActionResult



        ViewBag.AtlasOmilos = a
        Return View()

    End Function

    Private pdb As New AtlasStatisticsEntities

    Private pdb_blog As New AtlasBlogEntities

    <Authorize(Roles:="Admins")>
    Function Panel() As ActionResult
        ViewData("Message") = "Control panel page."

        Return View()
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
                 Select proc).ToList

        Dim stats
        stats = s.AsEnumerable.Select(Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                            .tid = o.teamId, .tname = o.teamname,
                                                            .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                            .Row = o.Row,
                                                            .val = o.totalpoints}).OrderByDescending(Function(a) a.val).ToArray.Take(10)
        Return Json(stats, JsonRequestBehavior.AllowGet)

    End Function

    <Compress>
    Public Function GetWeeklyReportStat2(ByVal omid As Integer?, ByVal kid As Integer?) As JsonResult

        If omid Is Nothing Then omid = 0
        If kid Is Nothing Then kid = 0

        Dim s = (From proc In pdb.GetWeeklyReportStat2All(omid, kid)
                 Select proc).ToList

        Dim stats
        stats = s.AsEnumerable.Select(Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                            .tid = o.teamId, .tname = o.teamname,
                                                            .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                            .Row = o.Row,
                                                            .val = o.totalassists}).OrderByDescending(Function(a) a.val).ToArray.Take(10)
        Return Json(stats, JsonRequestBehavior.AllowGet)

    End Function

    <Compress>
    Public Function GetWeeklyReportStat3(ByVal omid As Integer?, ByVal kid As Integer?) As JsonResult

        If omid Is Nothing Then omid = 0
        If kid Is Nothing Then kid = 0

        Dim s = (From proc In pdb.GetWeeklyReportStat3All(omid, kid)
                 Select proc).ToList

        Dim stats
        stats = s.AsEnumerable.Select(Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                            .tid = o.teamId, .tname = o.teamname,
                                                            .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                            .Row = o.Row,
                                                            .val = o.totalrebounds}).OrderByDescending(Function(a) a.val).ToArray.Take(10)
        Return Json(stats, JsonRequestBehavior.AllowGet)

    End Function

    <Compress>
    Public Function GetWeeklyReportStat4(ByVal omid As Integer?, ByVal kid As Integer?) As JsonResult

        If omid Is Nothing Then omid = 0
        If kid Is Nothing Then kid = 0

        Dim s = (From proc In pdb.GetWeeklyReportStat4All(omid, kid)
                 Select proc).ToList

        Dim stats
        stats = s.AsEnumerable.Select(Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                            .tid = o.teamId, .tname = o.teamname,
                                                            .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                            .Row = o.Row,
                                                            .val = o.totalsteals}).OrderByDescending(Function(a) a.val).ToArray.Take(10)
        Return Json(stats, JsonRequestBehavior.AllowGet)

    End Function

    <Compress>
    Public Function GetWeeklyReportStat5(ByVal omid As Integer?, ByVal kid As Integer?) As JsonResult

        If omid Is Nothing Then omid = 0
        If kid Is Nothing Then kid = 0

        Dim s = (From proc In pdb.GetWeeklyReportStat5All(omid, kid)
                 Select proc).ToList

        Dim stats
        stats = s.AsEnumerable.Select(Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                            .tid = o.teamId, .tname = o.teamname,
                                                            .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                            .Row = o.Row,
                                                            .val = o.totalblocks}).OrderByDescending(Function(a) a.val).ToArray.Take(10)
        Return Json(stats, JsonRequestBehavior.AllowGet)

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

    <Compress>
    Public Function Getdiorganwseis() As JsonResult

        Dim kat = (From d In pdb.DiorganwshTable
                   Join s In pdb.SeasonTable On s.Id Equals d.Seasonid
                   Where s.ActiveSeason = True
                   Order By d.DiorganwshName
                   Select d.DiorganwshName, d.Id).ToList

        Return Json(kat, JsonRequestBehavior.AllowGet)


    End Function

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
    Public Function Getlastgames(ByVal omilosid As Integer?) As JsonResult

        'Link
        'Date as Σαβ 01/06/2017 
        'gipedo ??
        'omada a, pontoi a,
        'omada b, pontoi b         

        If omilosid Is Nothing Then omilosid = 0

        Dim lastgames = (From g In pdb.GamesTable
                         Join ta In pdb.TeamsStatisticsTable On ta.Gameid Equals g.Id
                         Join teama In pdb.TeamsTable On ta.Teamid Equals teama.Id
                         Join tb In pdb.TeamsStatisticsTable On tb.Gameid Equals g.Id
                         Join teamb In pdb.TeamsTable On tb.Teamid Equals teamb.Id
                         Where ta.gipedouxos = 1 And tb.gipedouxos = 0 And
                             If(omilosid = 0, 1 = 1, g.Omilosid = omilosid)
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

        Dim fwtos = (From p In pdb_blog.BlogPostsTable
                     Where Not p.PostPhoto Is Nothing
                     Order By p.Id Descending
                     Select PostPhoto = p.PostPhoto, Id = p.Id
                       ).Take(20).ToList

        '.AsEnumerable().[Select](Function(o) New With {.Id = o.Id, .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/jpeg;base64,{0}", Convert.ToBase64String(o.PostPhoto)))}).ToList


        Dim tempFolder As String = System.Web.HttpContext.Current.Server.MapPath("~/Content/tempimages/")

        Try


            Dim exists As Boolean = System.IO.Directory.Exists(tempFolder)
            If Not exists Then
                Directory.CreateDirectory(tempFolder)
            End If

            For Each _file As String In Directory.GetFiles(tempFolder)
                System.IO.File.Delete(_file)
            Next

            Dim savedfwtos As New List(Of String)

            For Each f In fwtos
                Dim imageStr As String = tempFolder & f.Id & ".png"
                If Not f.PostPhoto Is Nothing Then
                    Using memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream(f.PostPhoto, False)
                        memoryStream.Seek(0, SeekOrigin.Begin)
                        Using image1 As System.Drawing.Image = System.Drawing.Image.FromStream(memoryStream)
                            If (System.IO.File.Exists(imageStr)) Then System.IO.File.Delete(imageStr)
                            savedfwtos.Add("/Content/tempimages/" & f.Id & ".png")
                            image1.Save(imageStr)
                        End Using
                    End Using
                End If
            Next

            Dim j As New JsonResult
            j.MaxJsonLength = Integer.MaxValue
            j = Json(savedfwtos, JsonRequestBehavior.AllowGet)

            Return j

        Catch ex As Exception

            Return Nothing

        End Try

    End Function

    <Compress>
    Function GetFwtografies2() As JsonResult

        Dim fwtos = (From p In pdb_blog.BlogPostsTable
                     Where Not p.PostPhoto Is Nothing
                     Order By p.Id Descending
                     Select PostPhoto = "", Id = p.Id
                       ).Take(20).AsEnumerable().[Select](Function(o) New With {.Id = o.Id, .PostPhoto = ""}).ToList
        Dim j As New JsonResult
        j.MaxJsonLength = Integer.MaxValue
        j = Json(fwtos, JsonRequestBehavior.AllowGet)

        Return j

    End Function


    Public Sub Resizeimages()

        Dim a As New Utils
        a.resizepostimages()

    End Sub


    Public Async Function sendtheemail() As Threading.Tasks.Task



        Dim ha As New Utils
        Await ha.sendEmailsync("tsiftelis.thanasis@gmail.com", "test", "test")


    End Function


End Class
