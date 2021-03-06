USE [master]
GO
/****** Object:  Database [GBook]    Script Date: 20-Jun-22 20:11:33 ******/
CREATE DATABASE [GBook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GBook', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GBook.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GBook_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GBook_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GBook] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GBook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GBook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GBook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GBook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GBook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GBook] SET ARITHABORT OFF 
GO
ALTER DATABASE [GBook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GBook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GBook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GBook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GBook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GBook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GBook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GBook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GBook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GBook] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GBook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GBook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GBook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GBook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GBook] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [GBook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GBook] SET RECOVERY FULL 
GO
ALTER DATABASE [GBook] SET  MULTI_USER 
GO
ALTER DATABASE [GBook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GBook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GBook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GBook] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GBook] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GBook] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GBook', N'ON'
GO
ALTER DATABASE [GBook] SET QUERY_STORE = OFF
GO
USE [GBook]
GO
/****** Object:  Table [dbo].[Alerta]    Script Date: 20-Jun-22 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alerta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Activo] [bit] NOT NULL,
	[CantidadStockAviso] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
 CONSTRAINT [PK_Alerta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 20-Jun-22 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Apellido] [nvarchar](200) NOT NULL,
	[Seudonimo] [nvarchar](200) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Autor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComprobanteCompra]    Script Date: 20-Jun-22 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComprobanteCompra](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaRecepcion] [datetime2](7) NULL,
	[EnvioId] [int] NOT NULL,
	[Detalle] [nvarchar](500) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Total] [float] NOT NULL,
 CONSTRAINT [PK_ComprobanteCompra] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComprobanteVenta]    Script Date: 20-Jun-22 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComprobanteVenta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Detalle] [nvarchar](500) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Total] [float] NOT NULL,
 CONSTRAINT [PK_ComprobanteVenta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleComprobante]    Script Date: 20-Jun-22 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleComprobante](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [real] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Total] [float] NOT NULL,
	[ComprobanteCompraId] [int] NULL,
	[ComprobanteVentaId] [int] NULL,
 CONSTRAINT [PK_DetalleComprobante] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Editorial]    Script Date: 20-Jun-22 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Editorial](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Editorial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Envio]    Script Date: 20-Jun-22 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Envio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Domicilio] [nvarchar](200) NOT NULL,
	[Numero] [nvarchar](200) NOT NULL,
	[EntreCalles] [nvarchar](200) NOT NULL,
	[TelefonoContacto] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Envio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Etiqueta]    Script Date: 20-Jun-22 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Etiqueta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreEtiqueta] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Etiqueta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 20-Jun-22 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genero](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Genero] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 20-Jun-22 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Default] [bit] NOT NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 20-Jun-22 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ISBN] [nvarchar](200) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Precio] [float] NOT NULL,
	[CantidadPaginas] [int] NOT NULL,
	[EnVenta] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
	[AutorId] [int] NOT NULL,
	[GeneroId] [int] NOT NULL,
	[EditorialId] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 20-Jun-22 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Traduccion]    Script Date: 20-Jun-22 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Traduccion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdiomaId] [int] NOT NULL,
	[EtiquetaId] [int] NOT NULL,
	[Traduccion] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Traduccion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 20-Jun-22 20:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[Bloqueo] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alerta] ON 

INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (1, 1, 10, 6)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (2, 1, 15, 7)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (3, 1, 15, 8)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (4, 0, 0, 9)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (5, 0, 0, 10)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (6, 0, 0, 11)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (7, 1, 8, 12)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (8, 1, 5, 13)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (9, 1, 5, 14)
SET IDENTITY_INSERT [dbo].[Alerta] OFF
GO
SET IDENTITY_INSERT [dbo].[Autor] ON 

INSERT [dbo].[Autor] ([Id], [Nombre], [Apellido], [Seudonimo], [Activo]) VALUES (1, N'Joanne', N'Rowling', N'J.K. Rowling', 1)
INSERT [dbo].[Autor] ([Id], [Nombre], [Apellido], [Seudonimo], [Activo]) VALUES (2, N'Sarah Janet', N'Maas', N'Sarah J. Maas', 1)
SET IDENTITY_INSERT [dbo].[Autor] OFF
GO
SET IDENTITY_INSERT [dbo].[ComprobanteCompra] ON 

INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (1, CAST(N'2022-06-17T19:18:02.2800000' AS DateTime2), 5, N'un detalle', CAST(N'2022-06-17T17:56:56.4766667' AS DateTime2), 35000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (8, CAST(N'2022-06-17T19:40:29.7533333' AS DateTime2), 12, N'hp 2', CAST(N'2022-06-17T19:37:59.3366667' AS DateTime2), 40000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (9, CAST(N'2022-06-17T19:40:41.7100000' AS DateTime2), 14, N'saga una corte de rosas', CAST(N'2022-06-17T19:40:00.0900000' AS DateTime2), 98000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (10, CAST(N'2022-06-17T19:42:15.0800000' AS DateTime2), 15, N'una corte de rosas mas stock', CAST(N'2022-06-17T19:42:08.2166667' AS DateTime2), 27000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (11, CAST(N'2022-06-17T19:49:46.9933333' AS DateTime2), 16, N'una corte de llamas plateadas', CAST(N'2022-06-17T19:49:36.7266667' AS DateTime2), 27500)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (12, CAST(N'2022-06-17T22:20:45.4100000' AS DateTime2), 17, N'corte', CAST(N'2022-06-17T22:20:33.2433333' AS DateTime2), 45000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (13, CAST(N'2022-06-17T22:31:06.9333333' AS DateTime2), 18, N'hp', CAST(N'2022-06-17T22:29:56.0400000' AS DateTime2), 96000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (14, CAST(N'2022-06-17T22:32:15.0833333' AS DateTime2), 19, N'sdfgdfsg', CAST(N'2022-06-17T22:32:00.9566667' AS DateTime2), 10000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (15, CAST(N'2022-06-18T14:44:57.9533333' AS DateTime2), 20, N'asgsadf', CAST(N'2022-06-18T14:44:52.8033333' AS DateTime2), 30000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (16, CAST(N'2022-06-18T15:38:48.9600000' AS DateTime2), 21, N'sdfhfdsh', CAST(N'2022-06-18T15:38:43.0833333' AS DateTime2), 5000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (17, CAST(N'2022-06-18T15:56:03.8433333' AS DateTime2), 22, N'sfdhgfdsh', CAST(N'2022-06-18T15:55:20.0433333' AS DateTime2), 15000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (18, CAST(N'2022-06-18T15:56:40.2200000' AS DateTime2), 23, N'fhfdsh', CAST(N'2022-06-18T15:56:31.6233333' AS DateTime2), 10000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (19, CAST(N'2022-06-18T16:21:35.7566667' AS DateTime2), 24, N'detalle', CAST(N'2022-06-18T16:21:29.8233333' AS DateTime2), 5000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (20, CAST(N'2022-06-19T23:24:04.5266667' AS DateTime2), 25, N'asdf', CAST(N'2022-06-19T23:23:58.9833333' AS DateTime2), 15000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (21, CAST(N'2022-06-20T20:05:07.5700000' AS DateTime2), 26, N'aa', CAST(N'2022-06-20T20:04:10.7533333' AS DateTime2), 25000)
SET IDENTITY_INSERT [dbo].[ComprobanteCompra] OFF
GO
SET IDENTITY_INSERT [dbo].[ComprobanteVenta] ON 

INSERT [dbo].[ComprobanteVenta] ([Id], [Detalle], [Fecha], [Total]) VALUES (1, N'venta', CAST(N'2022-06-18T14:38:46.2800000' AS DateTime2), 55000)
INSERT [dbo].[ComprobanteVenta] ([Id], [Detalle], [Fecha], [Total]) VALUES (2, N'venta todo el stock hp 1 y 2', CAST(N'2022-06-18T14:40:32.3800000' AS DateTime2), 195000)
INSERT [dbo].[ComprobanteVenta] ([Id], [Detalle], [Fecha], [Total]) VALUES (3, N'saga corte de roseas', CAST(N'2022-06-18T14:42:47.2600000' AS DateTime2), 65000)
INSERT [dbo].[ComprobanteVenta] ([Id], [Detalle], [Fecha], [Total]) VALUES (4, N'venta', CAST(N'2022-06-18T15:36:34.1000000' AS DateTime2), 17500)
INSERT [dbo].[ComprobanteVenta] ([Id], [Detalle], [Fecha], [Total]) VALUES (5, N'venta', CAST(N'2022-06-18T15:39:08.1700000' AS DateTime2), 17500)
INSERT [dbo].[ComprobanteVenta] ([Id], [Detalle], [Fecha], [Total]) VALUES (6, N'venta hp 1 y 2 para generar alerta', CAST(N'2022-06-18T16:18:11.1800000' AS DateTime2), 52500)
INSERT [dbo].[ComprobanteVenta] ([Id], [Detalle], [Fecha], [Total]) VALUES (7, N'aaa', CAST(N'2022-06-18T17:22:07.9133333' AS DateTime2), 27000)
INSERT [dbo].[ComprobanteVenta] ([Id], [Detalle], [Fecha], [Total]) VALUES (8, N'Venta trono de cristal', CAST(N'2022-06-20T20:09:08.2933333' AS DateTime2), 16000)
INSERT [dbo].[ComprobanteVenta] ([Id], [Detalle], [Fecha], [Total]) VALUES (9, N'venta trono de cristal', CAST(N'2022-06-20T20:09:54.2100000' AS DateTime2), 17500)
SET IDENTITY_INSERT [dbo].[ComprobanteVenta] OFF
GO
SET IDENTITY_INSERT [dbo].[DetalleComprobante] ON 

INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (1, 10, 2000, 7, 20000, 1, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (2, 10, 1500, 6, 15000, 1, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (8, 20, 2000, 7, 40000, 8, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (9, 10, 1800, 8, 18000, 9, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (10, 15, 2000, 9, 30000, 9, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (11, 20, 2500, 10, 50000, 9, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (12, 15, 1800, 8, 27000, 10, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (13, 10, 1000, 11, 10000, 11, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (14, 5, 3500, 12, 17500, 11, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (15, 10, 3500, 12, 35000, 12, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (16, 5, 2000, 9, 10000, 12, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (17, 60, 1000, 6, 60000, 13, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (18, 30, 1200, 7, 36000, 13, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (19, 5, 1000, 12, 5000, 14, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (20, 10, 500, 11, 5000, 14, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (21, 10, 2500, 10, 25000, NULL, 1)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (22, 20, 1500, 6, 30000, NULL, 1)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (23, 50, 1500, 6, 75000, NULL, 2)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (24, 60, 2000, 7, 120000, NULL, 2)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (25, 10, 2500, 10, 25000, NULL, 3)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (26, 5, 1000, 11, 5000, NULL, 3)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (27, 10, 3500, 12, 35000, NULL, 3)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (28, 10, 1000, 6, 10000, 15, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (29, 15, 1000, 7, 15000, 15, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (30, 5, 1000, 10, 5000, 15, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (31, 5, 3500, 12, 17500, NULL, 4)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (32, 5, 1000, 12, 5000, 16, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (33, 5, 3500, 12, 17500, NULL, 5)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (34, 5, 1000, 12, 5000, 17, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (35, 10, 1000, 7, 10000, 17, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (36, 10, 1000, 6, 10000, 18, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (37, 15, 1500, 6, 22500, NULL, 6)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (38, 15, 2000, 7, 30000, NULL, 6)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (39, 10, 500, 6, 5000, 19, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (40, 15, 1800, 8, 27000, NULL, 7)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (41, 10, 1500, 12, 15000, 20, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (42, 10, 1000, 13, 10000, 21, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (43, 10, 1500, 14, 15000, 21, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (44, 3, 2000, 13, 6000, NULL, 8)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (45, 4, 2500, 14, 10000, NULL, 8)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (46, 5, 2000, 13, 10000, NULL, 9)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (47, 3, 2500, 14, 7500, NULL, 9)
SET IDENTITY_INSERT [dbo].[DetalleComprobante] OFF
GO
SET IDENTITY_INSERT [dbo].[Editorial] ON 

INSERT [dbo].[Editorial] ([Id], [Nombre], [Activo]) VALUES (1, N'Salamandra', 1)
INSERT [dbo].[Editorial] ([Id], [Nombre], [Activo]) VALUES (2, N'Planeta', 1)
INSERT [dbo].[Editorial] ([Id], [Nombre], [Activo]) VALUES (3, N'Alfaguara juvenil', 1)
SET IDENTITY_INSERT [dbo].[Editorial] OFF
GO
SET IDENTITY_INSERT [dbo].[Envio] ON 

INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (5, N'prueba', N'88', N'aa y aa', N'1234')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (6, N'', N'', N'', N'')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (7, N'', N'', N'', N'')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (8, N'', N'', N'', N'')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (9, N'', N'', N'', N'')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (10, N'', N'', N'', N'')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (11, N'', N'', N'', N'')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (12, N'Domicilio', N'20', N'Prueba', N'123412512')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (14, N'Dom', N'123', N'prueba', N'2346432')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (15, N'hhho', N'hsdfh', N'sdhf', N'hsfdh')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (16, N'asfghsafg', N'sdfhsfdh', N'sdfhsfdh', N'34534543')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (17, N'asdgasdg', N'asdgsad', N'sfahasf', N'1243123')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (18, N'sadgdsag', N'sadgsdag', N'sadgsdag', N'1242141')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (19, N'gsfd', N'dsfg', N'sdfgsdfg', N'sdfgsfdg')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (20, N'dafasdg', N'asdgsadg', N'sadgads', N'123213')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (21, N'dshdsfhg', N'sdfhfdsh', N'sdfhfsdh', N'sdfhsfdh')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (22, N'sdfgfgsd', N'sfdgfs', N'sdfgfds', N'324342')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (23, N'dsgadsa', N'asdg', N'324521435', N'252315')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (24, N'aaa', N'aaa', N'aaa', N'23213')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (25, N'asfdfsad', N'sdafasd', N'sadf', N'12341234')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (26, N'Aaaaaa', N'aaa', N'aaa', N'aa')
SET IDENTITY_INSERT [dbo].[Envio] OFF
GO
SET IDENTITY_INSERT [dbo].[Etiqueta] ON 

INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1, N'lbl_Bienvenido')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (2, N'lbl_AlertaPedidoStock')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (3, N'lbl_NombreAutor')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (4, N'lbl_ApellidoAutor')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (5, N'lbl_SeudonimoAutor')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (6, N'btn_AltaAutor')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (7, N'lbl_NombreEditorial')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (8, N'btn_AltaEditorial')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (9, N'lbl_NombreGenero')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (10, N'btn_AltaGenero')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (11, N'lbl_ProductoISBN')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (12, N'lbl_ProductoNombre')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (13, N'lbl_ProductoPrecio')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (14, N'lbl_ProductoCantidadPaginas')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (15, N'lbl_ProductoAutor')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (16, N'lbl_ProductoGenero')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (17, N'lbl_ProductoEditorial')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (18, N'btn_AltaProducto')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (19, N'lbl_ProductoCantidadStockAviso')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (20, N'lbl_ProductoActivo')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (21, N'btn_FijarProducto')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (22, N'lbl_ProductoPrecioPublicado')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (23, N'lbl_PrecioUnitarioCompra')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (24, N'lbl_ProductoCantidad')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (25, N'btn_AgregarCarrito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (26, N'lbl_Domicilio')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (27, N'lbl_DomicilioNumero')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (28, N'lbl_EntreCalles')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (29, N'lbl_TelefonoContacto')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (30, N'lbl_DetalleCompra')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (31, N'btn_GenerarPedidoStock')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (32, N'lbl_Productos')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (33, N'lbl_Carrito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (34, N'lbl_ProductosCargados')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (35, N'btn_ModificarAutor')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (36, N'btn_ModificarEditorial')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (37, N'btn_ModificarGenero')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (38, N'btn_ModificarAutor')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (39, N'btn_PublicarProducto')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (40, N'lbl_DetalleVenta')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (41, N'btn_RealizarVenta')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (42, N'lbl_PedidoRecibido')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (43, N'btn_RecibirPedido')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (44, N'lbl_PedidosStockRealizados')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (45, N'lbl_VentasRealizadas')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (46, N'lbl_Logout')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (47, N'msg_AutorNombre')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (48, N'msg_AutorApellido')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (49, N'msg_AutorSeudonimo')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (50, N'msg_CompraDetalle')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (51, N'msg_CompraTotal')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (52, N'msg_CompraEnvio')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (53, N'msg_CompraCarrito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (54, N'msg_EnvioDomicilio')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (55, N'msg_EnvioNumero')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (56, N'msg_EnvioEntreCalles')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (57, N'msg_EnvioTelefonoContacto')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (58, N'msg_EditorialNombre')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (59, N'msg_GeneroNombre')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (60, N'msg_ProductoISBN')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (61, N'msg_ProductoNombre')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (62, N'msg_ProductoPrecio')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (63, N'msg_ProductoCantidadPaginas')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (64, N'msg_ProductoAutor')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (65, N'msg_ProductoGenero')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (66, N'msg_ProductoEditorial')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (67, N'msg_VentaDetalle')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (68, N'msg_VentaTotal')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (69, N'msg_VentaCarrito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (70, N'msg_AutorAltaExito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (71, N'msg_EditorialAltaExito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (72, N'msg_GeneroAltaExito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (73, N'msg_ProductoAltaExito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (74, N'msg_ProductoFijarExito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (75, N'msg_CarritoNoProductos')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (76, N'msg_CarritoNoPrecioCompra')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (77, N'msg_CarritoNoCantidad')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (78, N'msg_CarritoProductoExistente')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (79, N'msg_CarritoVacio')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (80, N'msg_PedidoRealizadoCorrectamente')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (81, N'msg_AutorNoSeleccionado')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (82, N'msg_AutorModificadoExito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (83, N'msg_EditorialNoSeleccionada')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (84, N'msg_EditorialModificadaExito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (85, N'msg_GeneroNoSeleccionado')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (86, N'msg_GeneroModificadoExito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (87, N'msg_ProductoNoSeleccionado')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (88, N'msg_ProductoModificacionExito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (89, N'msg_ProductoPublicadoExito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (90, N'msg_StockInsuficiente')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (91, N'msg_VentaExito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (92, N'msg_NoPedidoSeleccionado')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (93, N'msg_PedidoRecibido')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (94, N'menu_AdministrarNegocio')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (95, N'menu_GestionAutores')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (96, N'menu_AltaAutor')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (97, N'menu_ModificarAutor')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (98, N'menu_GestionEditoriales')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (99, N'menu_AltaEditorial')
GO
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (100, N'menu_ModificarEditorial')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (101, N'menu_GestionGeneros')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (102, N'menu_AltaGenero')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (103, N'menu_ModificarGenero')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (104, N'menu_Producto')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (105, N'menu_GestionProductos')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (106, N'menu_AltaProducto')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (107, N'menu_ModificarProducto')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (108, N'menu_PublicarProducto')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (109, N'menu_FijarProducto')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (110, N'menu_ListarProductos')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (111, N'menu_Compra')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (112, N'menu_GenerarPedidoStock')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (113, N'menu_GenerarPedidoStockFijados')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (114, N'menu_RecibirPedidoStock')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (115, N'menu_VisualizarPedidosStock')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (116, N'menu_Venta')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (117, N'menu_RealizarVenta')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (118, N'menu_VisualizarVentas')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (119, N'menu_Idioma')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (120, N'menu_GestionIdioma')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (121, N'menu_AltaIdioma')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (122, N'menu_CargarEtiquetas')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (123, N'menu_ModificarEtiquetas')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (124, N'chk_Recibido')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (125, N'lbl_EnVenta')
SET IDENTITY_INSERT [dbo].[Etiqueta] OFF
GO
SET IDENTITY_INSERT [dbo].[Genero] ON 

INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (1, N'Fantasía', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (2, N'Ficción', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (3, N'Policial', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (4, N'Romance', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (5, N'Aventura', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (1001, N'Poesía', 1)
SET IDENTITY_INSERT [dbo].[Genero] OFF
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([Id], [Nombre], [Default]) VALUES (1, N'Español', 1)
INSERT [dbo].[Idioma] ([Id], [Nombre], [Default]) VALUES (2, N'English', 0)
SET IDENTITY_INSERT [dbo].[Idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (6, N'9789878000107', N'Harry Potter Y La Piedra Filosofal', 1500, 288, 1, 1, 1, 1, 1)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (7, N'9789878000114', N'Harry Potter Y La Camara Secreta', 2000, 320, 1, 1, 1, 1, 1)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (8, N'9789504948629', N'Una corte de rosas y espinas', 1800, 456, 1, 1, 2, 1, 2)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (9, N'9789504953388', N'Una corte de niebla y furia', 2000, 704, 1, 1, 2, 1, 2)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (10, N'9789504959977', N'Una corte de alas y ruina', 2500, 800, 0, 1, 2, 1, 2)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (11, N'9789504974604', N'Una corte de hielo y estrellas', 1000, 240, 0, 1, 2, 1, 2)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (12, N'9789504974185', N'Una corte de llamas plateadas', 3500, 816, 1, 1, 2, 1, 2)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (13, N'9788418359286', N'Trono de Cristal', 2000, 528, 1, 1, 2, 1, 3)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (14, N'9789877383300', N'Corona de Medianoche', 2500, 400, 1, 1, 2, 1, 3)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (1, 15, 6)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (2, 10, 7)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (3, 10, 8)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (4, 20, 9)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (5, 5, 10)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (6, 15, 11)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (7, 20, 12)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (8, 2, 13)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (9, 3, 14)
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO
SET IDENTITY_INSERT [dbo].[Traduccion] ON 

INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1, 1, 1, N'Bienvenido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (2, 1, 2, N'Alerta: hay producto/s que requieren su atención')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (3, 1, 46, N'Cerrar sesión')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (4, 1, 3, N'Nombre')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (5, 1, 4, N'Apellido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (6, 1, 5, N'Seudónimo')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (7, 1, 6, N'Alta')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (8, 1, 7, N'Nombre')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (9, 1, 8, N'Alta')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (10, 1, 9, N'Nombre')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (11, 1, 10, N'Alta')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (12, 1, 11, N'ISBN')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (13, 1, 12, N'Nombre')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (14, 1, 13, N'Precio')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (15, 1, 14, N'Cantidad de páginas')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (16, 1, 15, N'Autor')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (17, 1, 16, N'Género')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (18, 1, 17, N'Editorial')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (19, 1, 18, N'Alta')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (20, 1, 19, N'Cantidad de stock aviso')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (21, 1, 20, N'Activo')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (22, 1, 21, N'Fijado')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (23, 1, 22, N'Precio publicado')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (24, 1, 23, N'Precio unitario')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (25, 1, 24, N'Cantidad')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (26, 1, 25, N'Agregar a carrito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (27, 1, 26, N'Domicilio')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (28, 1, 27, N'Número')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (29, 1, 28, N'Entre calles')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (30, 1, 29, N'Teléfono de contacto')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (31, 1, 30, N'Detalle de compra')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (32, 1, 31, N'Generar pedido de stock')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (33, 1, 32, N'Productos')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (34, 1, 33, N'Carrito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (35, 1, 34, N'Productos cargados')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (36, 1, 35, N'Modificar')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (37, 1, 36, N'Modificar')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (38, 1, 37, N'Modificar')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (39, 1, 39, N'Publicar')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (40, 1, 40, N'Detalle de venta')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (41, 1, 41, N'Realizar venta')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (42, 1, 42, N'Recibido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (43, 1, 43, N'Recibir pedido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (44, 1, 44, N'Pedidos de stock realizados')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (45, 1, 45, N'Ventas realizadas')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (46, 1, 47, N'El nombre del autor es requerido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (47, 1, 48, N'El apellido del autor es requerido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (48, 1, 49, N'El seudónimo del autor es requerido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (49, 1, 50, N'El detalle de la compra es requerido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (50, 1, 51, N'El total de la compra no puede ser 0')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (51, 1, 52, N'Los datos del envío no pueden estar vacios')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (52, 1, 53, N'El carrito no puede estar vacío')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (53, 1, 54, N'El domicilio es requerido para el envío')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (54, 1, 55, N'El número del domicilio es requerido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (55, 1, 56, N'Las entre calles del envío es requerido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (56, 1, 57, N'El teléfono de contacto del envío es requerido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (57, 1, 58, N'El nombre de la editorial es requerida')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (58, 1, 59, N'El nombre del género es requerido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (59, 1, 60, N'El ISBN del producto es requerido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (60, 1, 61, N'El nombre del producto es requerido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (61, 1, 62, N'El precio del producto es requerido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (62, 1, 63, N'La cantidad de páginas del producto es requerido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (63, 1, 64, N'El autor del producto es requerido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (64, 1, 65, N'El género del producto es requerido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (65, 1, 66, N'La editorial del producto es requerida')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (66, 1, 67, N'El detalle de la venta es requerido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (67, 1, 68, N'El total de la venta no puede ser 0')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (68, 1, 69, N'El carrito no puede estar vacío')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (69, 1, 70, N'Autor cargado con éxito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (70, 1, 71, N'Editorial cargada con éxito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (71, 1, 72, N'Género cargado con éxito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (72, 1, 73, N'Producto cargado con éxito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (73, 1, 74, N'Producto fijado con éxito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (74, 1, 75, N'El carrito está vacío')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (75, 1, 76, N'No se completó el precio de compra')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (76, 1, 77, N'No se completó la cantidad')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (77, 1, 78, N'Ese producto ya está en el carrito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (78, 1, 79, N'El carrito está vacío')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (79, 1, 80, N'Pedido de stock realizado correctamente')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (80, 1, 81, N'No se seleccionó el autor')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (81, 1, 82, N'Autor modificado con éxito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (82, 1, 83, N'Editorial no seleccionada')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (83, 1, 84, N'Editorial modificada con éxito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (84, 1, 85, N'Género no seleccionado')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (85, 1, 86, N'Género modificado con éxito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (86, 1, 87, N'Producto no seleccionado')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (87, 1, 88, N'Producto modificado con éxito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (88, 1, 89, N'Producto publicado con éxito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (89, 1, 90, N'El stock es insuficiente')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (90, 1, 91, N'Venta realizada con éxito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (91, 1, 92, N'No se seleccionó ningún pedido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (92, 1, 93, N'Pedido recibido correctamente, se actualizará el stock')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (93, 1, 94, N'Administrar negocio')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (94, 1, 95, N'Gestión autores')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (95, 1, 96, N'Alta autor')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (96, 1, 97, N'Modificar autor')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (97, 1, 98, N'Gestión editoriales')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (98, 1, 99, N'Alta editorial')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (99, 1, 100, N'Modificar editorial')
GO
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (100, 1, 101, N'Gestión géneros')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (101, 1, 102, N'Alta género')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (102, 1, 103, N'Modificar género')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (103, 1, 104, N'Productos')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (104, 1, 105, N'Gestión productos')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (105, 1, 106, N'Alta producto')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (106, 1, 107, N'Modificar producto')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (107, 1, 108, N'Publicar producto')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (108, 1, 109, N'Fijar producto')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (109, 1, 110, N'Listar productos')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (110, 1, 111, N'Compras')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (111, 1, 112, N'Generar pedido de stock')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (112, 1, 113, N'Generar pedido de stock de productos fijados')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (113, 1, 114, N'Recibir pedido de stock')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (114, 1, 115, N'Visualizar pedidos de stock')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (115, 1, 116, N'Ventas')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (116, 1, 117, N'Realizar venta')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (117, 1, 118, N'Visualizar ventas')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (118, 1, 119, N'Idioma')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (119, 1, 120, N'Gestionar idiomas')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (120, 1, 121, N'Alta idioma')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (121, 1, 122, N'Cargar etiquetas')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (122, 1, 123, N'Modificar etiquetas')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (123, 1, 124, N'Recibido')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (124, 1, 125, N'En venta')
SET IDENTITY_INSERT [dbo].[Traduccion] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([UsuarioId], [Email], [Password], [Nombre], [Apellido], [Bloqueo]) VALUES (1, N'zytYsyL7FNNuleTccgskCjdX97Xz9JJxAcOZ0og07bk=', N'Wpc+Gn1uW+hvznWX3+/fHumxStJc9kcf6xgOu8StqLU=', N'DwYpXQd5ThCKyOtdkQfiAQ==', N'9vYEdDvaswxngkpKwSqPjw==', 0)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
/****** Object:  Index [IX_Alerta_ProductoId]    Script Date: 20-Jun-22 20:11:33 ******/
CREATE NONCLUSTERED INDEX [IX_Alerta_ProductoId] ON [dbo].[Alerta]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ComprobanteCompra_EnvioId]    Script Date: 20-Jun-22 20:11:33 ******/
CREATE NONCLUSTERED INDEX [IX_ComprobanteCompra_EnvioId] ON [dbo].[ComprobanteCompra]
(
	[EnvioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetalleComprobante_ComprobanteCompraId]    Script Date: 20-Jun-22 20:11:33 ******/
CREATE NONCLUSTERED INDEX [IX_DetalleComprobante_ComprobanteCompraId] ON [dbo].[DetalleComprobante]
(
	[ComprobanteCompraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetalleComprobante_ComprobanteVentaId]    Script Date: 20-Jun-22 20:11:33 ******/
CREATE NONCLUSTERED INDEX [IX_DetalleComprobante_ComprobanteVentaId] ON [dbo].[DetalleComprobante]
(
	[ComprobanteVentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetalleComprobante_ProductoId]    Script Date: 20-Jun-22 20:11:33 ******/
CREATE NONCLUSTERED INDEX [IX_DetalleComprobante_ProductoId] ON [dbo].[DetalleComprobante]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Producto_AutorId]    Script Date: 20-Jun-22 20:11:33 ******/
CREATE NONCLUSTERED INDEX [IX_Producto_AutorId] ON [dbo].[Producto]
(
	[AutorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Producto_EditorialId]    Script Date: 20-Jun-22 20:11:33 ******/
CREATE NONCLUSTERED INDEX [IX_Producto_EditorialId] ON [dbo].[Producto]
(
	[EditorialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Producto_GeneroId]    Script Date: 20-Jun-22 20:11:33 ******/
CREATE NONCLUSTERED INDEX [IX_Producto_GeneroId] ON [dbo].[Producto]
(
	[GeneroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alerta]  WITH CHECK ADD  CONSTRAINT [FK_Alerta_Producto_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Alerta] CHECK CONSTRAINT [FK_Alerta_Producto_ProductoId]
GO
ALTER TABLE [dbo].[ComprobanteCompra]  WITH CHECK ADD  CONSTRAINT [FK_ComprobanteCompra_Envio_EnvioId] FOREIGN KEY([EnvioId])
REFERENCES [dbo].[Envio] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ComprobanteCompra] CHECK CONSTRAINT [FK_ComprobanteCompra_Envio_EnvioId]
GO
ALTER TABLE [dbo].[DetalleComprobante]  WITH CHECK ADD  CONSTRAINT [FK_DetalleComprobante_ComprobanteCompra_ComprobanteCompraId] FOREIGN KEY([ComprobanteCompraId])
REFERENCES [dbo].[ComprobanteCompra] ([Id])
GO
ALTER TABLE [dbo].[DetalleComprobante] CHECK CONSTRAINT [FK_DetalleComprobante_ComprobanteCompra_ComprobanteCompraId]
GO
ALTER TABLE [dbo].[DetalleComprobante]  WITH CHECK ADD  CONSTRAINT [FK_DetalleComprobante_ComprobanteVenta_ComprobanteVentaId] FOREIGN KEY([ComprobanteVentaId])
REFERENCES [dbo].[ComprobanteVenta] ([Id])
GO
ALTER TABLE [dbo].[DetalleComprobante] CHECK CONSTRAINT [FK_DetalleComprobante_ComprobanteVenta_ComprobanteVentaId]
GO
ALTER TABLE [dbo].[DetalleComprobante]  WITH CHECK ADD  CONSTRAINT [FK_DetalleComprobante_Producto_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleComprobante] CHECK CONSTRAINT [FK_DetalleComprobante_Producto_ProductoId]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Autor_AutorId] FOREIGN KEY([AutorId])
REFERENCES [dbo].[Autor] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Autor_AutorId]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Editorial_EditorialId] FOREIGN KEY([EditorialId])
REFERENCES [dbo].[Editorial] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Editorial_EditorialId]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Genero_GeneroId] FOREIGN KEY([GeneroId])
REFERENCES [dbo].[Genero] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Genero_GeneroId]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Producto]
GO
ALTER TABLE [dbo].[Traduccion]  WITH CHECK ADD  CONSTRAINT [FK_Traduccion_Etiqueta] FOREIGN KEY([EtiquetaId])
REFERENCES [dbo].[Etiqueta] ([Id])
GO
ALTER TABLE [dbo].[Traduccion] CHECK CONSTRAINT [FK_Traduccion_Etiqueta]
GO
ALTER TABLE [dbo].[Traduccion]  WITH CHECK ADD  CONSTRAINT [FK_Traduccion_Idioma] FOREIGN KEY([IdiomaId])
REFERENCES [dbo].[Idioma] ([Id])
GO
ALTER TABLE [dbo].[Traduccion] CHECK CONSTRAINT [FK_Traduccion_Idioma]
GO
USE [master]
GO
ALTER DATABASE [GBook] SET  READ_WRITE 
GO
