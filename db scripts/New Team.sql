SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[NewTeam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	teamname [varchar](200) NOT NULL,
	teamemail [varchar](100) ,
	teamphone [varchar](50) not null,
	teamroster [image] NULL,
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

SET ANSI_PADDING OFF
GO


