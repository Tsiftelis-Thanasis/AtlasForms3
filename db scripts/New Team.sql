USE [ATLASBLOG2]
GO

/****** Object:  Table [dbo].[BlogNewTeam]    Script Date: 27/8/2017 8:43:10 μμ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BlogNewTeam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[teamname] [varchar](200) NOT NULL,
	[teamemail] [varchar](100) NULL,
	[teamphone] [varchar](50) NOT NULL,
	[teamroster] [image] NULL,
	[CreationDate] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[EditDate] [datetime] NULL,
	[EditBy] [varchar](100) NULL,
 CONSTRAINT [PK_NewTeam] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


