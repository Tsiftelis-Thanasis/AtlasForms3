CREATE TABLE [dbo].[BlogKathgoriesTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KathgoriaName] [nvarchar](50) NOT NULL,
	[ActiveKathgoria] [bit] NOT NULL,
	[CreationDate] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[EditDate] [datetime] NULL,
	[EditBy] [varchar](100) NULL,	
 CONSTRAINT [PK_BlogKathgoriesTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


CREATE TABLE [dbo].[BlogPostsTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KathgoriaId] int NULL,
	[YpoKathgoriaId] int NULL,
	Activepost [bit] NOT NULL,
	PostTitle varchar(300),
	PostBody varchar(2000),
	PostPhoto image,
	Youtubelink varchar(200),
	Statslink varchar(200),
	[CreationDate] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[EditDate] [datetime] NULL,
	[EditBy] [varchar](100) NULL,	
 CONSTRAINT [PK_BlogPostsTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO




-------


USE [atlasBlog]
GO

INSERT INTO [dbo].[BlogPostsTable]
           ([KathgoriaId]
           ,[YpoKathgoriaId]
           ,[Activepost]
           ,[PostTitle]
           ,[PostBody]
           ,[PostPhoto]
           ,[Youtubelink]
           ,[Statslink]
           ,[CreationDate]
           ,[CreatedBy]
           ,[EditDate]
           ,[EditBy])
     VALUES
           (2
           ,null
           ,1
           ,'TEST'
           ,'TEST'
           ,null
           ,null
           ,null
            ,getdate()
           ,'thanasis.tsiftelis'
           ,getdate()
           ,'thanasis.tsiftelis')
GO



INSERT INTO [dbo].[BlogKathgoriesTable]
           ([KathgoriaName]
           ,[ActiveKathgoria]
           ,[CreationDate]
           ,[CreatedBy]
           ,[EditDate]
           ,[EditBy])
     VALUES
           ('MVP παίχτης'
           ,1
           ,getdate()
           ,'thanasis.tsiftelis'
           ,getdate()
           ,'thanasis.tsiftelis')
GO


---------------------------------------

alter table blogpoststable
alter column postsummary varchar(2000)

INSERT INTO [dbo].[BlogPostKathgoriaTable]
([KathgoriaId],[YpokathgoriaId],[PostId],[CreationDate],[CreatedBy],[EditDate],[EditBy])
VALUES(null,2,13,getdate(),'thanasis.tsiftelis',getdate(),'thanasis.tsiftelis')



INSERT INTO [dbo].[BlogYpokathgoriesTable]([KathgoriaId],[YpokathgoriaName],[ActiveKathgoria],[CreationDate],[CreatedBy],[EditDate],[EditBy])
VALUES(6,'Βαθμολογία',7,getdate(),'thanasis.tsiftelis',getdate(),'thanasis.tsiftelis')

alter TABLE [dbo].[BlogPostsTable]
alter column  [PostBody] [varchar](max)
	
	
alter table [atlasBlog].[dbo].[BlogPostsTable]
add PostSummary varchar(200)
--------------------------------
alter table [atlasBlog].[dbo].[BlogPostsTable]
drop COLUMN  KathgoriaId, YpoKathgoriaId
--------------------------------
CREATE TABLE [dbo].[BlogYpokathgoriesTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	KathgoriaId int not null,
	[YpokathgoriaName] [nvarchar](50) NOT NULL,
	[ActiveKathgoria] [bit] NOT NULL,
	[CreationDate] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[EditDate] [datetime] NULL,
	[EditBy] [varchar](100) NULL,
 CONSTRAINT [PK_BlogYpokathgoriesTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


----------------------------------------
-- Join to post me kathgoria h ypokathgoria
CREATE TABLE [dbo].[BlogPostKathgoriaTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KathgoriaId] Int,
	YpokathgoriaId Int,
	PostId Int Not Null,
	[CreationDate] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[EditDate] [datetime] NULL,
	[EditBy] [varchar](100) NULL,
 CONSTRAINT [PK_BlogPostKathgoriaTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


INSERT INTO [dbo].[BlogPostsTable]
([Activepost],[PostTitle],PostSummary, [PostBody],[PostPhoto],[Youtubelink],[Statslink],[CreationDate],[CreatedBy],[EditDate],[EditBy])
VALUES(1,'ΤΡΕΝΟ BC vs 98΄ers','7Η Α.Π.ΑΤΛΑΣ ΤΡΕΝΟ BC vs 98΄ers','<p class="MsoNormal" style="margin-left: 0cm; text-align: justify;"><span lang="EN-GB">O</span> πρώτος τίτλος της σεζόν στις διοργανώσεις Άτλας, θα αποδοθεί την Κυριακή 25 Ιουνίου! Η «καρδιά» του <span lang="EN-GB">Final</span>4 του κυπέλλου «χτυπά δυνατά» στο γήπεδο της Καισαριανής, όπου διεξάγονται την ερχόμενη Κυριακή, οι τελικοί της διοργάνωσης.</p>
<p class="MsoNormal" style="margin-left: 0και οι μοναδικο, που θα γίνει την Παρασκευή στο ΟΑΚΑ, θα αναμετρηθούν <span lang="EN-GB">Arkouda</span> και <span lang="EN-GB">Tigers</span>. Δύο ομάδες γνωστές μεταξύ τους, που αγωνίστηκαν στον Γ’ Ομιλο του πρωταθλήματος Άτλας και έχουν ήδη διασταυρώσει τα ξίφη τους δύο φορές. Η <span lang="EN-GB">Arkouda</span> κατέκτησε την τέταρτη θέση στον όμιλο της και οι <span lang="EN-GB">Tigers</span> την πέμπτη με δύο νίκες λιγότερες. Στα φετινά μεταξύ τους ματς μετρούν από μία νίκη. Εξαιρετικά αμφίρροπο ζευγάρι, με δυο αντιπάλους που διψούν για διάκριση. Οι <span lang="EN-GB">Tigers</span> άφησαν εκτός συνέχειας στη διοργάνωση του κυπέλλου, <span lang="EN-GB">Chicken</span> <span lang="EN-GB">Nuggets</span>, <span lang="EN-GB">Brooklyn</span> <span lang="EN-GB">Bets</span> και <span lang="EN-GB">Ghost</span> <span lang="EN-GB">Riders</span>, ενώ η <span lang="EN-GB">Arkouda</span> έκλεισε θέση στο <span lang="EN-GB">Final</span> 4 κερδίζοντας, <span lang="EN-GB">Halvaianas</span>, 
<span lang="EN-GB">Risko</span> <span lang="EN-GB">Cavaliers</span> και Καρέα.&nbsp;</p>                </div>',null,'3M8ELHnby_A',null,getdate(),'thanasis.tsiftelis',getdate(),'thanasis.tsiftelis')


INSERT INTO [dbo].[BlogKathgoriesTable]
([KathgoriaName],[ActiveKathgoria],[CreationDate],[CreatedBy],[EditDate],[EditBy])
VALUES('Διοργ. Αρχή',1,getdate(),'thanasis.tsiftelis',getdate(),'thanasis.tsiftelis')


INSERT INTO [dbo].[BlogYpokathgoriesTable]([KathgoriaId],[YpokathgoriaName],[ActiveKathgoria],[CreationDate],[CreatedBy],[EditDate],[EditBy])
VALUES(3,'Φυσικοθεραπείες',7,getdate(),'thanasis.tsiftelis',getdate(),'thanasis.tsiftelis')