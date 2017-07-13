Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function


    Private pdb As New atlasStatisticsEntities

    <Authorize(Roles:="Admins")>
    Function Panel() As ActionResult
        ViewData("Message") = "Control panel page."

        Return View()
    End Function


    <HttpPost>
    Public Function GetWeeklyReportStat1(ByVal thisid As Integer?) As JsonResult

        Dim s = (From proc In pdb.GetWeeklyReportStat1All(thisid)
                 Select proc).ToList

        Dim stats
        stats = s.AsEnumerable.Select(Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                            .tid = o.teamId, .tname = o.teamname,
                                                            .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                            .Row = o.Row,
                                                            .val = o.totalpoints}).OrderByDescending(Function(a) a.val).ToArray.Take(10)
        Return Json(stats, JsonRequestBehavior.AllowGet)

    End Function

    <HttpPost>
    Public Function GetWeeklyReportStat2(ByVal thisid As Integer?) As JsonResult

        Dim s = (From proc In pdb.GetWeeklyReportStat2All(thisid)
                 Select proc).ToList

        Dim stats
        stats = s.AsEnumerable.Select(Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                            .tid = o.teamId, .tname = o.teamname,
                                                            .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                            .Row = o.Row,
                                                            .val = o.totalassists}).OrderByDescending(Function(a) a.val).ToArray.Take(10)
        Return Json(stats, JsonRequestBehavior.AllowGet)

    End Function

    <HttpPost>
    Public Function GetWeeklyReportStat3(ByVal thisid As Integer?) As JsonResult

        Dim s = (From proc In pdb.GetWeeklyReportStat3All(thisid)
                 Select proc).ToList

        Dim stats
        stats = s.AsEnumerable.Select(Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                            .tid = o.teamId, .tname = o.teamname,
                                                            .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                            .Row = o.Row,
                                                            .val = o.totalrebounds}).OrderByDescending(Function(a) a.val).ToArray.Take(10)
        Return Json(stats, JsonRequestBehavior.AllowGet)

    End Function

    <HttpPost>
    Public Function GetWeeklyReportStat4(ByVal thisid As Integer?) As JsonResult

        Dim s = (From proc In pdb.GetWeeklyReportStat4All(thisid)
                 Select proc).ToList

        Dim stats
        stats = s.AsEnumerable.Select(Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                            .tid = o.teamId, .tname = o.teamname,
                                                            .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                            .Row = o.Row,
                                                            .val = o.totalsteals}).OrderByDescending(Function(a) a.val).ToArray.Take(10)
        Return Json(stats, JsonRequestBehavior.AllowGet)

    End Function

    <HttpPost>
    Public Function GetWeeklyReportStat5(ByVal thisid As Integer?) As JsonResult

        Dim s = (From proc In pdb.GetWeeklyReportStat5All(thisid)
                 Select proc).ToList

        Dim stats
        stats = s.AsEnumerable.Select(Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                            .tid = o.teamId, .tname = o.teamname,
                                                            .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                            .Row = o.Row,
                                                            .val = o.totalblocks}).OrderByDescending(Function(a) a.val).ToArray.Take(10)
        Return Json(stats, JsonRequestBehavior.AllowGet)

    End Function


    <HttpPost>
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


    <HttpPost>
    Public Function Getdiorganwseis() As JsonResult

        Dim kat = (From d In pdb.DiorganwshTable
                   Join s In pdb.SeasonTable On s.Id Equals d.Seasonid
                   Where s.ActiveSeason = True
                   Order By d.DiorganwshName
                   Select d.DiorganwshName, d.Id).ToList

        Return Json(kat, JsonRequestBehavior.AllowGet)


    End Function

    <HttpPost>
    Public Function GetOmiloiByDiorganwsh(ByVal dId As Integer) As JsonResult

        Dim om = (From o In pdb.OmilosTable
                  Join d In pdb.DiorganwshTable On d.Id Equals o.Diorganwshid
                  Where d.Id = dId
                  Order By o.OmilosName
                  Select o.OmilosName, o.Id).ToList

        Return Json(om, JsonRequestBehavior.AllowGet)


    End Function

    <HttpPost>
    Public Function Getlastgames() As JsonResult


        'Link
        'Date as Σαβ 01/06/2017 
        'gipedo ??
        'omada a, pontoi a,
        'omada b, pontoi b         


        Dim lastgames = (From g In pdb.GamesTable
                         Join ta In pdb.TeamsStatisticsTable On ta.Gameid Equals g.Id
                         Join teama In pdb.TeamsTable On ta.Teamid Equals teama.Id
                         Join tb In pdb.TeamsStatisticsTable On tb.Gameid Equals g.Id
                         Join teamb In pdb.TeamsTable On tb.Teamid Equals teamb.Id
                         Where ta.gipedouxos = 1 And tb.gipedouxos = 0
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


End Class
