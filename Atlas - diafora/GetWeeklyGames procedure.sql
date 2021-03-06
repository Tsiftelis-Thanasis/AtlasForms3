USE [atlas]
GO
/****** Object:  StoredProcedure [dbo].[GetWeeklyReportStat1All]    Script Date: 4/9/2017 12:28:12 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetWeeklyGames]
	@omid int,
	@kid int
AS
BEGIN

declare @currentdate as date = cast('01/06/2017' as date)

declare @startdate as date, @enddate as date

select @startdate = 
(case when DATEPART(WEEKDAY, @currentdate) = 1 then DATEADD(DAY,-2,@currentdate) 
when DATEPART(WEEKDAY, @currentdate) = 2 then DATEADD(DAY,-3,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 3 then DATEADD(DAY,-4,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 4 then DATEADD(DAY,-5,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 5 then DATEADD(DAY,-6,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 6 then DATEADD(DAY,0,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 7 then DATEADD(DAY,-1,@currentdate)
end )

select @enddate = 
(case when DATEPART(WEEKDAY, @currentdate) = 1 then DATEADD(DAY,4,@currentdate) 
when DATEPART(WEEKDAY, @currentdate) = 2 then DATEADD(DAY,3,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 3 then DATEADD(DAY,2,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 4 then DATEADD(DAY,1,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 5 then DATEADD(DAY,0,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 6 then DATEADD(DAY,6,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 7 then DATEADD(DAY,5,@currentdate)
end )

	select g.id gameid,
	t1.id t1id, t1.TeamName t1name,  t1.TeamLogo t1logo, ts1.ptstotal t1points,
	t2.id t2id, t2.TeamName t2name,  t2.TeamLogo t2logo, ts2.ptstotal t2points
	from 
	GamesTable g 
	inner join TeamsStatisticsTable ts1  on g.id = ts1.Gameid
	inner join TeamsStatisticsTable ts2  on g.id = ts2.Gameid 
	inner join TeamsTable t1 on t1.id = ts1.Teamid
	inner join TeamsTable t2 on t2.id = ts2.Teamid
	inner join dbo.SeasonTable s on s.id = g.Seasonid
	inner join dbo.DiorganwshTable d on d.Id = g.Diorganwshid
	inner join dbo.OmilosTable o on o.Id = g.Omilosid
	inner join dbo.KathgoriesTable k on k.id = g.Kathgoriaid
	where t1.id <> t2.id and ts1.gipedouxos =1 and ts2.gipedouxos =0 
			and (o.id = @omid or @omid=0)
			and (k.id = @kid or @kid=0)
			and cast(g.gamedate as date) between @startdate and @enddate
	order by g.id 

end