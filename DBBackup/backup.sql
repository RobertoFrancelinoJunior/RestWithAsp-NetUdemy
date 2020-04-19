USE [master]
GO
CREATE DATABASE treinamentoRest;
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [treinamentoRest]    Script Date: 19/04/2020 18:58:44 ******/
CREATE LOGIN [treinamentoRest] WITH PASSWORD=N'n6oXgueQSAVPkoZQ0Nc6+M11fWtYJ9w47bRk26VgDZE=', DEFAULT_DATABASE=[treinamentoRest], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
ALTER LOGIN [treinamentoRest] DISABLE
GO
USE [treinamentoRest]
GO
/****** Object:  User [treinamentoRest]    Script Date: 19/04/2020 18:58:44 ******/
CREATE USER [treinamentoRest] FOR LOGIN [treinamentoRest] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [treinamentoRest]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [treinamentoRest]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 19/04/2020 18:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Author] [varchar](50) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[LaunchDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 19/04/2020 18:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Gender] [varchar](20) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 19/04/2020 18:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NULL,
	[AccessKey] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON 
GO
INSERT [dbo].[Book] ([Id], [Title], [Author], [Price], [LaunchDate]) VALUES (2, N'Roberto', N'Junior', CAST(20 AS Decimal(18, 0)), CAST(N'2020-04-01T11:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Address], [Gender]) VALUES (1, N'Roberto', N'Junior', N'Rua Settimo Giannini 600', N'Male')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Address], [Gender]) VALUES (3, N'Wiviane', N'Rocha de Souza', N'Rua Settimo Giannini 600', N'Female')
GO
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [Login], [AccessKey]) VALUES (1, N'junior', N'junior')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
