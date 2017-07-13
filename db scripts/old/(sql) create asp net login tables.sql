SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/7/2017 11:00:08 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/7/2017 11:00:08 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/7/2017 11:00:08 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 3/7/2017 11:00:08 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[IsLocked] [int] NULL,
	[IsEnabled] [int] NULL,
	[Fullname] [varchar](100) NULL,
	[Address] [varchar](250) NULL,
	[Perioxi] [varchar](250) NULL,
	[Poli] [varchar](250) NULL,
	[Tk] [varchar](10) NULL,
	[Afm] [varchar](20) NULL,
	[Phone] [varchar](100) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'88973700-ecff-46c7-a198-7dd23e7704e0', N'Users', NULL, N'IdentityRole')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'9cc7f2fe-a740-4b2a-947b-5a9b949e9dae', N'Admins', NULL, N'IdentityRole')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'26570c59-6ce1-4393-85e2-5b9103e141d2', N'88973700-ecff-46c7-a198-7dd23e7704e0')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'26570c59-6ce1-4393-85e2-5b9103e141d2', N'9cc7f2fe-a740-4b2a-947b-5a9b949e9dae')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2e2947b2-a8c5-4b4f-84e8-31bfb3ca2d30', N'88973700-ecff-46c7-a198-7dd23e7704e0')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2e2947b2-a8c5-4b4f-84e8-31bfb3ca2d30', N'9cc7f2fe-a740-4b2a-947b-5a9b949e9dae')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9b97f10e-d74c-4805-98c7-4bafcc961e82', N'88973700-ecff-46c7-a198-7dd23e7704e0')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9b97f10e-d74c-4805-98c7-4bafcc961e82', N'9cc7f2fe-a740-4b2a-947b-5a9b949e9dae')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a3d51e93-376a-424d-a0e5-5ec3664c1f82', N'88973700-ecff-46c7-a198-7dd23e7704e0')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a3d51e93-376a-424d-a0e5-5ec3664c1f82', N'9cc7f2fe-a740-4b2a-947b-5a9b949e9dae')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c75cb0b9-556e-47e7-9531-5525077fe7ea', N'88973700-ecff-46c7-a198-7dd23e7704e0')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c75cb0b9-556e-47e7-9531-5525077fe7ea', N'9cc7f2fe-a740-4b2a-947b-5a9b949e9dae')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f66503bd-2b19-4288-a289-d04b46a878b8', N'88973700-ecff-46c7-a198-7dd23e7704e0')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f66503bd-2b19-4288-a289-d04b46a878b8', N'9cc7f2fe-a740-4b2a-947b-5a9b949e9dae')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsLocked], [IsEnabled], [Fullname], [Address], [Perioxi], [Poli], [Tk], [Afm], [Phone]) VALUES (N'26570c59-6ce1-4393-85e2-5b9103e141d2', N'giliasins@gmail.com', 1, N'AOeGrVdsaRTSV0x7NpkRe3TodXz6zvPwcaqYzGYVfvFStXAhaEDCd9gj7Y+1SSRgLA==', N'b7323e8e-6250-48f0-83ec-cb8250a97737', NULL, 0, 0, NULL, 1, 0, N'cgilias', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsLocked], [IsEnabled], [Fullname], [Address], [Perioxi], [Poli], [Tk], [Afm], [Phone]) VALUES (N'2e2947b2-a8c5-4b4f-84e8-31bfb3ca2d30', N'GOALMACHEINE-9@HOTMAIL.COM', 1, N'ABEAc5vPUyhNNKz8VFPBdLZ334rqBqeuHRqZ3a2ZBrwGfQ1ahozd2zm/eQ9J/6KUow==', N'66f4d21b-e22b-49a3-b23e-ec2767f7db07', NULL, 0, 0, NULL, 1, 0, N'user3', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsLocked], [IsEnabled], [Fullname], [Address], [Perioxi], [Poli], [Tk], [Afm], [Phone]) VALUES (N'9b97f10e-d74c-4805-98c7-4bafcc961e82', N'TAKAROS_6393@HOTMAIL.COM', 1, N'AE+Sw729NqDcNJBPXgpOfCdxHlTTVuPdfD3uCTBwOPGOZFpbLB7wJwoNAOTVDIMoUw==', N'cc42627f-a78b-4cf4-a514-4323e6efeab0', NULL, 0, 0, NULL, 1, 0, N'user2', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsLocked], [IsEnabled], [Fullname], [Address], [Perioxi], [Poli], [Tk], [Afm], [Phone]) VALUES (N'a3d51e93-376a-424d-a0e5-5ec3664c1f82', N'THANASOULISD@GMAIL.COM', 1, N'AGpAKimRf+CqOtKTxtcprlkRb6YALY66jX4QKMM0jy0RE3qhgly5sD6jkjJ7f/3guQ==', N'e019681a-0446-41e8-9125-000a736afa6c', NULL, 0, 0, NULL, 1, 0, N'user1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsLocked], [IsEnabled], [Fullname], [Address], [Perioxi], [Poli], [Tk], [Afm], [Phone]) VALUES (N'c75cb0b9-556e-47e7-9531-5525077fe7ea', N'thanasis.tsiftelis@yourideas.gr', 1, N'AKGGLLxW3zUikRdfasTdYqR/vbiBIhFc+6kNBWKMA8jUorJj2KrQBhFDaKnvXJMTIQ==', N'89b1c81b-c835-4b1f-9f82-be23eafde922', N'+306936895805', 1, 0, NULL, 1, 0, N'thanasis.tsiftelis', 0, 0, N'Thanasis Tsiftelis', N'Mesogeion 12', N'Ampelokipoi', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsLocked], [IsEnabled], [Fullname], [Address], [Perioxi], [Poli], [Tk], [Afm], [Phone]) VALUES (N'f66503bd-2b19-4288-a289-d04b46a878b8', N'fotis.petrou@yourideas.gr', 1, N'ALRg7BcxaelT5WxD2WWlL+E/LWsHtehrE4F1n3MrPohMAmdiQHIpKBlkpWn4UQdCbw==', N'3acf350d-c661-43e0-9888-a10ab48f8bfa', NULL, 0, 0, NULL, 1, 0, N'fp', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
