USE [ids_basket]
GO

/****** Object:  Table [dbo].[BlogKathgoriesTable]    Script Date: 5/7/2017 8:42:59 μμ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BlogProgramma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OmadaA] [nvarchar](50) NOT NULL,
	[OmadaB] [nvarchar](50) NOT NULL,
	[gamedate] date NOT NULL,
	[Omilosid] int,
	[GipedoId] int,
	[CreationDate] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[EditDate] [datetime] NULL,
	[EditBy] [varchar](100) NULL,
 CONSTRAINT [PK_BlogProgramma] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


