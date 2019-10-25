USE [crud]
GO
/****** Object:  Table [dbo].[edades]    Script Date: 24/10/2019 22:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[edades](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nro] [nvarchar](50) NULL,
 CONSTRAINT [PK_edades] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personas]    Script Date: 24/10/2019 22:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[edad_id] [int] NULL,
	[nombre] [nvarchar](50) NULL,
	[fecha] [smalldatetime] NULL,
 CONSTRAINT [PK_personas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[edades] ON 

INSERT [dbo].[edades] ([id], [nro]) VALUES (1, N'15')
INSERT [dbo].[edades] ([id], [nro]) VALUES (2, N'16')
INSERT [dbo].[edades] ([id], [nro]) VALUES (3, N'17')
INSERT [dbo].[edades] ([id], [nro]) VALUES (4, N'18')
INSERT [dbo].[edades] ([id], [nro]) VALUES (6, N'20')
INSERT [dbo].[edades] ([id], [nro]) VALUES (8, N'22')
INSERT [dbo].[edades] ([id], [nro]) VALUES (9, N'23')
INSERT [dbo].[edades] ([id], [nro]) VALUES (10, N'24')
INSERT [dbo].[edades] ([id], [nro]) VALUES (11, N'28')
SET IDENTITY_INSERT [dbo].[edades] OFF
ALTER TABLE [dbo].[personas]  WITH CHECK ADD  CONSTRAINT [FK_personas_edades] FOREIGN KEY([edad_id])
REFERENCES [dbo].[edades] ([id])
GO
ALTER TABLE [dbo].[personas] CHECK CONSTRAINT [FK_personas_edades]
GO
