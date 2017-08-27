USE [ATLASBLOG2]
GO

/****** Object:  Table [dbo].[BlogNewPlayer]    Script Date: 27/8/2017 8:42:53 μμ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BlogNewPlayer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[playername] [varchar](200) NOT NULL,
	[playeremail] [varchar](100) NULL,
	[playerphone] [varchar](50) NOT NULL,
	[playerbirthdate] [varchar](50) NULL,
	[playerheight] [varchar](10) NULL,
	[playerposition] [varchar](10) NULL,
	[CreationDate] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[EditDate] [datetime] NULL,
	[EditBy] [varchar](100) NULL,
 CONSTRAINT [PK_NewPlayer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


