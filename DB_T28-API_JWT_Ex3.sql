USE [master]
GO
/****** Object:  Database [T28-API_JWT_Ex3]    Script Date: 08/02/2021 17:48:16 ******/
CREATE DATABASE [T28-API_JWT_Ex3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'T28-API_JWT_Ex3', FILENAME = N'/var/opt/mssql/data/T28-API_JWT_Ex3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'T28-API_JWT_Ex3_log', FILENAME = N'/var/opt/mssql/data/T28-API_JWT_Ex3_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [T28-API_JWT_Ex3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET ARITHABORT OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET  ENABLE_BROKER 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET RECOVERY FULL 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET  MULTI_USER 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET QUERY_STORE = OFF
GO
USE [T28-API_JWT_Ex3]
GO
/****** Object:  Table [dbo].[Cajeros]    Script Date: 08/02/2021 17:48:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cajeros](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[NomApels] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maquinas_Registradoras]    Script Date: 08/02/2021 17:48:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maquinas_Registradoras](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Piso] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 08/02/2021 17:48:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Precio] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 08/02/2021 17:48:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[UserName] [varchar](30) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 08/02/2021 17:48:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[Cajero] [int] NOT NULL,
	[Maquina] [int] NOT NULL,
	[Producto] [int] NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[Cajero] ASC,
	[Maquina] ASC,
	[Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cajeros] ON 

INSERT [dbo].[Cajeros] ([Codigo], [NomApels]) VALUES (1, N'Cajero 1')
INSERT [dbo].[Cajeros] ([Codigo], [NomApels]) VALUES (2, N'Cajero 2')
INSERT [dbo].[Cajeros] ([Codigo], [NomApels]) VALUES (3, N'Cajero 3')
INSERT [dbo].[Cajeros] ([Codigo], [NomApels]) VALUES (4, N'Cajero 4')
INSERT [dbo].[Cajeros] ([Codigo], [NomApels]) VALUES (5, N'Cajero 5')
INSERT [dbo].[Cajeros] ([Codigo], [NomApels]) VALUES (6, N'Cajero 6')
INSERT [dbo].[Cajeros] ([Codigo], [NomApels]) VALUES (7, N'Cajero 7')
INSERT [dbo].[Cajeros] ([Codigo], [NomApels]) VALUES (8, N'Cajero 8')
INSERT [dbo].[Cajeros] ([Codigo], [NomApels]) VALUES (9, N'Cajero 9')
INSERT [dbo].[Cajeros] ([Codigo], [NomApels]) VALUES (10, N'Cajero 10')
SET IDENTITY_INSERT [dbo].[Cajeros] OFF
GO
SET IDENTITY_INSERT [dbo].[Maquinas_Registradoras] ON 

INSERT [dbo].[Maquinas_Registradoras] ([Codigo], [Piso]) VALUES (1, 41)
INSERT [dbo].[Maquinas_Registradoras] ([Codigo], [Piso]) VALUES (2, 28)
INSERT [dbo].[Maquinas_Registradoras] ([Codigo], [Piso]) VALUES (3, 47)
INSERT [dbo].[Maquinas_Registradoras] ([Codigo], [Piso]) VALUES (4, 65)
INSERT [dbo].[Maquinas_Registradoras] ([Codigo], [Piso]) VALUES (5, 32)
INSERT [dbo].[Maquinas_Registradoras] ([Codigo], [Piso]) VALUES (6, 54)
INSERT [dbo].[Maquinas_Registradoras] ([Codigo], [Piso]) VALUES (7, 2)
INSERT [dbo].[Maquinas_Registradoras] ([Codigo], [Piso]) VALUES (8, 43)
INSERT [dbo].[Maquinas_Registradoras] ([Codigo], [Piso]) VALUES (9, 60)
INSERT [dbo].[Maquinas_Registradoras] ([Codigo], [Piso]) VALUES (10, 1)
SET IDENTITY_INSERT [dbo].[Maquinas_Registradoras] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([Codigo], [Nombre], [Precio]) VALUES (1, N'Producto 1', 31)
INSERT [dbo].[Productos] ([Codigo], [Nombre], [Precio]) VALUES (2, N'Producto 2', 32)
INSERT [dbo].[Productos] ([Codigo], [Nombre], [Precio]) VALUES (3, N'Producto 3', 33)
INSERT [dbo].[Productos] ([Codigo], [Nombre], [Precio]) VALUES (4, N'Producto 4', 34)
INSERT [dbo].[Productos] ([Codigo], [Nombre], [Precio]) VALUES (5, N'Producto 5', 35)
INSERT [dbo].[Productos] ([Codigo], [Nombre], [Precio]) VALUES (6, N'Producto 6', 36)
INSERT [dbo].[Productos] ([Codigo], [Nombre], [Precio]) VALUES (7, N'Producto 7', 37)
INSERT [dbo].[Productos] ([Codigo], [Nombre], [Precio]) VALUES (8, N'Producto 8', 38)
INSERT [dbo].[Productos] ([Codigo], [Nombre], [Precio]) VALUES (9, N'Producto 9', 39)
INSERT [dbo].[Productos] ([Codigo], [Nombre], [Precio]) VALUES (10, N'Producto 10', 40)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[UserInfo] ON 

INSERT [dbo].[UserInfo] ([UserId], [FirstName], [LastName], [UserName], [Email], [Password], [CreatedDate]) VALUES (1, N'Piezas', N'Admin', N'PiezasAdmin', N'admin@piezas.com', N'$admin@2021', CAST(N'2021-02-08T17:29:52.240' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
GO
INSERT [dbo].[Venta] ([Cajero], [Maquina], [Producto]) VALUES (1, 7, 9)
INSERT [dbo].[Venta] ([Cajero], [Maquina], [Producto]) VALUES (2, 4, 3)
INSERT [dbo].[Venta] ([Cajero], [Maquina], [Producto]) VALUES (2, 8, 10)
INSERT [dbo].[Venta] ([Cajero], [Maquina], [Producto]) VALUES (3, 6, 3)
INSERT [dbo].[Venta] ([Cajero], [Maquina], [Producto]) VALUES (4, 5, 2)
INSERT [dbo].[Venta] ([Cajero], [Maquina], [Producto]) VALUES (5, 3, 1)
INSERT [dbo].[Venta] ([Cajero], [Maquina], [Producto]) VALUES (6, 4, 2)
INSERT [dbo].[Venta] ([Cajero], [Maquina], [Producto]) VALUES (7, 2, 6)
INSERT [dbo].[Venta] ([Cajero], [Maquina], [Producto]) VALUES (8, 1, 7)
INSERT [dbo].[Venta] ([Cajero], [Maquina], [Producto]) VALUES (9, 10, 8)
INSERT [dbo].[Venta] ([Cajero], [Maquina], [Producto]) VALUES (10, 9, 2)
GO
ALTER TABLE [dbo].[UserInfo] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([Cajero])
REFERENCES [dbo].[Cajeros] ([Codigo])
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([Maquina])
REFERENCES [dbo].[Maquinas_Registradoras] ([Codigo])
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([Producto])
REFERENCES [dbo].[Productos] ([Codigo])
GO
USE [master]
GO
ALTER DATABASE [T28-API_JWT_Ex3] SET  READ_WRITE 
GO
