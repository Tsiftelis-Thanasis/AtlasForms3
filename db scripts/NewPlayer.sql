SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[NewPlayer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	playername [varchar](200) NOT NULL,
	playeremail [varchar](100) ,
	playerphone [varchar](50) not null,
	playerbirthdate varchar(50) ,
	playerheight varchar(10) ,
	playerposition varchar(10) ,
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

SET ANSI_PADDING OFF
GO

 
  
