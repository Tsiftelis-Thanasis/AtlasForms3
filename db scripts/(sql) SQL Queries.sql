USE [ATLASBLOG2]
GO

DROP TABLE [dbo].[BlogYpokathgoriesTable]

DROP TABLE [dbo].[BlogPostKathgoriaTable]


EXEC sp_rename 'BlogPostKathgoriaTable2', 'BlogPostandKathgoriaTable';  