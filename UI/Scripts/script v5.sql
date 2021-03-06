USE [master]
GO
/****** Object:  Database [GBook]    Script Date: 26-Jun-22 21:31:23 ******/
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
/****** Object:  Table [dbo].[Alerta]    Script Date: 26-Jun-22 21:31:23 ******/
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
/****** Object:  Table [dbo].[Autor]    Script Date: 26-Jun-22 21:31:23 ******/
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
/****** Object:  Table [dbo].[ComprobanteCompra]    Script Date: 26-Jun-22 21:31:23 ******/
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
/****** Object:  Table [dbo].[ComprobanteVenta]    Script Date: 26-Jun-22 21:31:23 ******/
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
/****** Object:  Table [dbo].[DetalleComprobante]    Script Date: 26-Jun-22 21:31:23 ******/
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
/****** Object:  Table [dbo].[Editorial]    Script Date: 26-Jun-22 21:31:23 ******/
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
/****** Object:  Table [dbo].[Envio]    Script Date: 26-Jun-22 21:31:23 ******/
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
/****** Object:  Table [dbo].[Etiqueta]    Script Date: 26-Jun-22 21:31:23 ******/
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
/****** Object:  Table [dbo].[FamiliaPatente]    Script Date: 26-Jun-22 21:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamiliaPatente](
	[PadreId] [int] NOT NULL,
	[HijoId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 26-Jun-22 21:31:23 ******/
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
/****** Object:  Table [dbo].[Idioma]    Script Date: 26-Jun-22 21:31:23 ******/
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
/****** Object:  Table [dbo].[Permiso]    Script Date: 26-Jun-22 21:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Permiso] [nvarchar](200) NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 26-Jun-22 21:31:23 ******/
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
/****** Object:  Table [dbo].[Stock]    Script Date: 26-Jun-22 21:31:23 ******/
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
/****** Object:  Table [dbo].[Traduccion]    Script Date: 26-Jun-22 21:31:23 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 26-Jun-22 21:31:23 ******/
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
/****** Object:  Table [dbo].[UsuarioPermiso]    Script Date: 26-Jun-22 21:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPermiso](
	[UsuarioId] [int] NOT NULL,
	[PatenteId] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alerta] ON 

INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (1, 1, 10, 1)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (2, 0, 0, 2)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (3, 1, 15, 3)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (4, 0, 0, 4)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (5, 1, 10, 5)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (6, 0, 0, 6)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (7, 0, 0, 7)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (8, 1, 10, 8)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (9, 0, 0, 9)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (10, 0, 0, 10)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (11, 0, 0, 11)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (12, 1, 10, 12)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (13, 1, 10, 13)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (14, 1, 5, 14)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (15, 0, 0, 15)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (16, 0, 0, 16)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (17, 1, 10, 17)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (18, 0, 0, 18)
SET IDENTITY_INSERT [dbo].[Alerta] OFF
GO
SET IDENTITY_INSERT [dbo].[Autor] ON 

INSERT [dbo].[Autor] ([Id], [Nombre], [Apellido], [Seudonimo], [Activo]) VALUES (1, N'Joanne', N'Rowling', N'J.K. Rowling', 1)
INSERT [dbo].[Autor] ([Id], [Nombre], [Apellido], [Seudonimo], [Activo]) VALUES (2, N'Sarah Janet', N'Maas', N'Sarah J. Maas', 1)
INSERT [dbo].[Autor] ([Id], [Nombre], [Apellido], [Seudonimo], [Activo]) VALUES (3, N'Stephen Edwin', N'King', N'Stephen King', 1)
INSERT [dbo].[Autor] ([Id], [Nombre], [Apellido], [Seudonimo], [Activo]) VALUES (4, N'Patrick James', N'Rothfuss', N'Patrick Rothfuss', 1)
SET IDENTITY_INSERT [dbo].[Autor] OFF
GO
SET IDENTITY_INSERT [dbo].[ComprobanteCompra] ON 

INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (1, CAST(N'2022-06-21T18:14:43.3900000' AS DateTime2), 1, N'Compra saga harry potter', CAST(N'2022-06-21T18:11:38.8266667' AS DateTime2), 110000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (2, CAST(N'2022-06-21T18:14:51.1633333' AS DateTime2), 2, N'Compra saga corte de rosas y espinas', CAST(N'2022-06-21T18:12:23.9400000' AS DateTime2), 115000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (3, CAST(N'2022-06-21T18:19:41.9866667' AS DateTime2), 3, N'Compra de saga crónica de asesino de reyes', CAST(N'2022-06-21T18:16:37.0033333' AS DateTime2), 30000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (4, CAST(N'2022-06-21T18:19:46.0366667' AS DateTime2), 4, N'Compra de it', CAST(N'2022-06-21T18:17:39.1200000' AS DateTime2), 15000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (5, CAST(N'2022-06-21T18:19:52.9666667' AS DateTime2), 5, N'Compra instituto', CAST(N'2022-06-21T18:18:59.8200000' AS DateTime2), 15000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (6, CAST(N'2022-06-21T18:19:49.2900000' AS DateTime2), 6, N'Una corte de rosas y espinas', CAST(N'2022-06-21T18:19:36.0333333' AS DateTime2), 10000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (7, CAST(N'2022-06-21T18:24:53.2200000' AS DateTime2), 7, N'Compra de HP 1', CAST(N'2022-06-21T18:24:46.5800000' AS DateTime2), 15000)
INSERT [dbo].[ComprobanteCompra] ([Id], [FechaRecepcion], [EnvioId], [Detalle], [Fecha], [Total]) VALUES (8, CAST(N'2022-06-22T09:44:18.6100000' AS DateTime2), 8, N'Compra throne of glass', CAST(N'2022-06-22T09:44:09.9400000' AS DateTime2), 85000)
SET IDENTITY_INSERT [dbo].[ComprobanteCompra] OFF
GO
SET IDENTITY_INSERT [dbo].[ComprobanteVenta] ON 

INSERT [dbo].[ComprobanteVenta] ([Id], [Detalle], [Fecha], [Total]) VALUES (1, N'Venta HP 1 y 2', CAST(N'2022-06-21T18:21:02.9200000' AS DateTime2), 7000)
INSERT [dbo].[ComprobanteVenta] ([Id], [Detalle], [Fecha], [Total]) VALUES (2, N'Venta hp 5', CAST(N'2022-06-21T18:21:28.1900000' AS DateTime2), 6299.99)
INSERT [dbo].[ComprobanteVenta] ([Id], [Detalle], [Fecha], [Total]) VALUES (3, N'Venta de saga una corte de rosas y espinas', CAST(N'2022-06-21T18:21:42.0466667' AS DateTime2), 13072.24)
INSERT [dbo].[ComprobanteVenta] ([Id], [Detalle], [Fecha], [Total]) VALUES (4, N'Venta saga nombre del viento', CAST(N'2022-06-21T18:21:54.1500000' AS DateTime2), 12499.98)
SET IDENTITY_INSERT [dbo].[ComprobanteVenta] OFF
GO
SET IDENTITY_INSERT [dbo].[DetalleComprobante] ON 

INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (1, 5, 2000, 1, 10000, 1, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (2, 5, 2000, 2, 10000, 1, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (3, 10, 2000, 3, 20000, 1, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (4, 5, 3000, 4, 15000, 1, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (5, 5, 5000, 5, 25000, 1, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (6, 5, 3000, 6, 15000, 1, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (7, 5, 3000, 7, 15000, 1, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (8, 10, 2000, 8, 20000, 2, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (9, 20, 3000, 9, 60000, 2, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (10, 5, 3000, 10, 15000, 2, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (11, 5, 4000, 12, 20000, 2, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (12, 5, 3000, 17, 15000, 3, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (13, 5, 3000, 18, 15000, 3, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (14, 5, 3000, 15, 15000, 4, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (15, 5, 3000, 16, 15000, 5, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (16, 5, 2000, 8, 10000, 6, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (17, 1, 3500, 1, 3500, NULL, 1)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (18, 1, 3500, 2, 3500, NULL, 1)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (19, 1, 6299.99, 5, 6299.99, NULL, 2)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (20, 1, 3570.5, 8, 3570.5, NULL, 3)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (21, 1, 4250.99, 9, 4250.99, NULL, 3)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (22, 1, 5250.75, 10, 5250.75, NULL, 3)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (23, 1, 6249.99, 17, 6249.99, NULL, 4)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (24, 1, 6249.99, 18, 6249.99, NULL, 4)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (25, 10, 1500, 1, 15000, 7, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (26, 15, 3000, 13, 45000, 8, NULL)
INSERT [dbo].[DetalleComprobante] ([Id], [Cantidad], [PrecioUnitario], [ProductoId], [Total], [ComprobanteCompraId], [ComprobanteVentaId]) VALUES (27, 10, 4000, 14, 40000, 8, NULL)
SET IDENTITY_INSERT [dbo].[DetalleComprobante] OFF
GO
SET IDENTITY_INSERT [dbo].[Editorial] ON 

INSERT [dbo].[Editorial] ([Id], [Nombre], [Activo]) VALUES (1, N'Salamandra', 1)
INSERT [dbo].[Editorial] ([Id], [Nombre], [Activo]) VALUES (2, N'Planeta', 1)
INSERT [dbo].[Editorial] ([Id], [Nombre], [Activo]) VALUES (3, N'Bloomsbury YA', 1)
INSERT [dbo].[Editorial] ([Id], [Nombre], [Activo]) VALUES (4, N'Debolsillo', 1)
INSERT [dbo].[Editorial] ([Id], [Nombre], [Activo]) VALUES (5, N'Plaza & Janes Editores', 1)
SET IDENTITY_INSERT [dbo].[Editorial] OFF
GO
SET IDENTITY_INSERT [dbo].[Envio] ON 

INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (1, N'Prueba', N'120', N'Prueba y prueba', N'1135345342')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (2, N'Prueba', N'656', N'Prueba y prueba', N'115653573')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (3, N'Prueba', N'88', N'Prueba y prueba', N'1185836704')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (4, N'Prueba', N'88', N'Prueba y prueba', N'1156325632')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (5, N'Prueba', N'88', N'prueba y prueba', N'1132454234')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (6, N'prueba', N'34', N'probando y probando', N'11345824523')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (7, N'Test', N'88', N'Test and test', N'1148524382')
INSERT [dbo].[Envio] ([Id], [Domicilio], [Numero], [EntreCalles], [TelefonoContacto]) VALUES (8, N'Prueba', N'88', N'Prueba y prueba', N'1152346543')
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
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (126, N'msg_CompletarCampos')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1094, N'menu_Seguridad')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1095, N'menu_Permisos')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1096, N'menu_GestionFamiliaPatente')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1097, N'menu_GestionPermisosUsuarios')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1098, N'menu_CambiarPassword')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1099, N'lbl_NuevaFamilia')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1100, N'lbl_NombreFamilia')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1101, N'lbl_NuevaPatente')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1102, N'lbl_Patente')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1103, N'lbl_NombrePatente')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1104, N'lbl_PatentesExistentes')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1106, N'lbl_FamiliasExistentes')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1108, N'lbl_PermisoUsuario')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1109, N'btn_GuardarFamilia')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1110, N'btn_GuardarPatente')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1111, N'btn_ConfigurarFamilia')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1112, N'btn_AgregarPatente')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1113, N'btn_AgregarFamilia')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1114, N'btn_GuardarFamilia')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1115, N'btn_EliminarPatente')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1116, N'btn_ConfigurarUsuario')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1117, N'btn_GuardarFamiliaPatente')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1118, N'msg_FamiliaCreadaExito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1119, N'msg_PatenteCreadaExito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1120, N'msg_ErrorCargarArbol')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1121, N'msg_PatenteYaCargada')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1122, N'msg_ErrorCargarPatente')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1123, N'msg_FamiliaGuardadaExito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1124, N'msg_Recursividad')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1125, N'msg_UsuarioFamiliaAsociada')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1126, N'msg_SeleccionarUsuario')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1127, N'msg_PatenteYaAsociada')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1128, N'msg_PermisosGuardadosExito')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1129, N'msg_PermisosGuardadosError')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1130, N'lbl_PasswordActual')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1131, N'lbl_PasswordNueva')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1132, N'lbl_PasswordNuevaConfirmar')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1133, N'btn_CambiarPassword')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1134, N'msg_PasswordNoCoindice')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1135, N'msg_ValidacionPassword')
INSERT [dbo].[Etiqueta] ([Id], [NombreEtiqueta]) VALUES (1136, N'msg_PasswordCambioExito')
SET IDENTITY_INSERT [dbo].[Etiqueta] OFF
GO
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (17, 1)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (17, 2)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (17, 3)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (19, 1)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (19, 2)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (19, 5)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (19, 6)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (19, 7)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (19, 8)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (19, 9)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (19, 10)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (19, 11)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (19, 12)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (18, 14)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (18, 15)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (18, 16)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (18, 5)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (17, 5)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (17, 6)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (17, 7)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (17, 8)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (17, 9)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (17, 10)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (17, 11)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (17, 12)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (17, 13)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (17, 14)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (17, 15)
INSERT [dbo].[FamiliaPatente] ([PadreId], [HijoId]) VALUES (17, 16)
GO
SET IDENTITY_INSERT [dbo].[Genero] ON 

INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (1, N'Aventura', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (2, N'Ciencia ficción', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (3, N'Fantasía', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (4, N'Policial', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (5, N'Poesía', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (6, N'Romance', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (7, N'Terror y misterio', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (8, N'Mitología', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (9, N'Cuento', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (10, N'Aventura fantástica', 1)
SET IDENTITY_INSERT [dbo].[Genero] OFF
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([Id], [Nombre], [Default]) VALUES (1, N'Español', 1)
INSERT [dbo].[Idioma] ([Id], [Nombre], [Default]) VALUES (2, N'English', 0)
SET IDENTITY_INSERT [dbo].[Idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (1, N'Cargar producto', N'CargarProducto')
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (2, N'Modificar producto', N'ModificarProducto')
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (3, N'Baja producto', N'BajaProducto')
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (5, N'Detalle de producto', N'DetalleProducto')
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (6, N'Generar pedido de stock', N'GenerarPedidoStockManual')
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (7, N'Generar pedido de stock de productos fijados', N'GenerarPedidoStockFijado')
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (8, N'Marcar producto como fijado', N'MarcarProductoFijado')
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (9, N'Generar alerta de pedido de stock', N'GenerarAlertaPedidoStock')
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (10, N'Visualizar pedidos de stock', N'VisualizarPedidosStock')
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (11, N'Detalle de pedido de stock', N'DetallePedidoStock')
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (12, N'Recibir pedido de stock', N'RecibirPedidoStock')
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (13, N'Publicar producto a la venta', N'PublicarProductoVenta')
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (14, N'Listar productos', N'ListarProductos')
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (15, N'Realizar venta', N'VentaProducto')
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (16, N'Visualizar ventas', N'VisualizarVentas')
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (17, N'Administrador', NULL)
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (18, N'Vendedor', NULL)
INSERT [dbo].[Permiso] ([Id], [Nombre], [Permiso]) VALUES (19, N'Comprador', NULL)
SET IDENTITY_INSERT [dbo].[Permiso] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (1, N'9789878000404', N'Harry Potter Y La Piedra Filosofal', 3500, 288, 1, 1, 1, 10, 1)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (2, N'9789878000442', N'Harry Potter Y La Camara Secreta', 3500, 320, 1, 1, 1, 10, 1)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (3, N'9789878000176', N'Harry Potter Y El Prisionero De Azkaban', 3500, 384, 1, 1, 1, 10, 1)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (4, N'9789878000213', N'Harry Potter Y El Caliz De Fuego', 5400, 672, 1, 1, 1, 10, 1)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (5, N'9789878000459', N'Harry Potter Y La Orden Del Fenix', 6299.99, 928, 1, 1, 1, 10, 1)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (6, N'9789878000411', N'Harry Potter Y El Misterio Del Principe', 4299.99, 576, 1, 1, 1, 10, 1)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (7, N'9789878000190', N'Harry Potter Y Las Reliquias De La Muerte', 5349.5, 704, 1, 1, 1, 10, 1)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (8, N'9789504948629', N'Una corte de rosas y espinas', 3570.5, 456, 1, 1, 2, 3, 2)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (9, N'9789504974581', N'Una corte de niebla y furia', 4250.99, 704, 1, 1, 2, 3, 2)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (10, N'9789504959977', N'Una corte de alas y ruina', 5250.75, 800, 1, 1, 2, 3, 2)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (11, N'9789504963448', N'Una corte de hielo y estrellas', 2000, 240, 0, 1, 2, 3, 2)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (12, N'9789504974185', N'Una corte de llamas plateadas', 6550.8, 816, 1, 1, 2, 3, 2)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (13, N'9781599906959', N'Throne of Glass', 4000, 432, 1, 1, 2, 3, 3)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (14, N'9781619630628', N'Crown of Midnight', 5000, 432, 1, 1, 2, 3, 3)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (15, N'9789877252576', N'It', 6525.75, 1168, 1, 1, 3, 7, 4)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (16, N'9789506445096', N'El instituto', 5400, 624, 1, 1, 3, 7, 5)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (17, N'9789506441746', N'El nombre del viento', 6249.99, 872, 1, 1, 4, 1, 5)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (18, N'9788401339639', N'El temor de un hombre sabio', 6249.99, 1200, 1, 1, 4, 1, 5)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (1, 14, 1)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (2, 4, 2)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (3, 10, 3)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (4, 5, 4)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (5, 4, 5)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (6, 5, 6)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (7, 5, 7)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (8, 14, 8)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (9, 19, 9)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (10, 4, 10)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (11, 0, 11)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (12, 5, 12)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (13, 15, 13)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (14, 10, 14)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (15, 5, 15)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (16, 5, 16)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (17, 4, 17)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (18, 4, 18)
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
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (125, 1, 126, N'Faltan completar campos')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1074, 2, 1, N'Welcome')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1075, 2, 2, N'Warning: There are pinned product/s that requiere your attention')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1076, 2, 3, N'Name')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1077, 2, 4, N'Lastname')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1078, 2, 5, N'Pseudonym')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1079, 2, 6, N'Insert')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1080, 2, 7, N'Name')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1081, 2, 8, N'Insert')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1082, 2, 9, N'Name')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1083, 2, 10, N'Insert')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1084, 2, 11, N'ISBN')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1085, 2, 12, N'Name')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1086, 2, 13, N'Price')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1087, 2, 14, N'Number of pages')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1088, 2, 15, N'Author')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1089, 2, 16, N'Genre')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1090, 2, 17, N'Publisher')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1091, 2, 18, N'Insert')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1092, 2, 19, N'Remaining stock warning')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1093, 2, 20, N'Active')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1094, 2, 21, N'Pin')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1095, 2, 22, N'Published price')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1096, 2, 23, N'Unit purchase price')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1097, 2, 24, N'Quantity')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1098, 2, 25, N'Add to cart')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1099, 2, 26, N'Domicile')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1100, 2, 27, N'Number')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1101, 2, 28, N'Intersection')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1102, 2, 29, N'Contact number')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1103, 2, 30, N'Purchase detail')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1104, 2, 31, N'Generate stock order')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1105, 2, 32, N'Products')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1106, 2, 33, N'Cart')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1107, 2, 34, N'Products')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1108, 2, 35, N'Modify')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1109, 2, 36, N'Modify')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1110, 2, 37, N'Modify')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1111, 2, 39, N'Publish product')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1112, 2, 40, N'Sale detail')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1113, 2, 41, N'Complete sale')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1114, 2, 42, N'Order received')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1115, 2, 43, N'Receive order')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1116, 2, 44, N'Stock orders placed')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1117, 2, 45, N'Sales made')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1118, 2, 46, N'Logout')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1119, 2, 47, N'The name of the author is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1120, 2, 48, N'The lastname of the author is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1121, 2, 49, N'The pseudonym of the author is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1122, 2, 50, N'The purchase detail is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1123, 2, 51, N'The purchase total can''t be 0')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1124, 2, 52, N'The shipping data is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1125, 2, 53, N'The cart is empty')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1126, 2, 54, N'The domicile is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1127, 2, 55, N'The domicile number is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1128, 2, 56, N'The intersection is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1129, 2, 57, N'The contact number is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1130, 2, 58, N'The name of the publisher is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1131, 2, 59, N'The name of the genre is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1132, 2, 60, N'The ISBN of the product is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1133, 2, 61, N'The name of the product is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1134, 2, 62, N'The price of the product is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1135, 2, 63, N'The number of pages of the product is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1136, 2, 64, N'The author of the product is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1137, 2, 65, N'The genre of the product is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1138, 2, 66, N'The publisher of the product is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1139, 2, 67, N'The sale detail is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1140, 2, 68, N'The total of the sale can''t be 0')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1141, 2, 69, N'The cart is empty')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1142, 2, 70, N'Author inserted successfully')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1143, 2, 71, N'Publisher inserted successfully')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1144, 2, 72, N'Genre inserted successfully')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1145, 2, 73, N'Product inserted successfully')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1146, 2, 74, N'Product pinned successfully')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1147, 2, 75, N'The cart is empty')
GO
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1148, 2, 76, N'The purchase price is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1149, 2, 77, N'The quantity is required')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1150, 2, 78, N'That product is already in the cart')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1151, 2, 79, N'The cart is empty')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1152, 2, 80, N'Stock order placed successfully')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1153, 2, 81, N'Unselected author')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1154, 2, 82, N'Author modified successfully')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1155, 2, 83, N'Unselected publisher')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1156, 2, 84, N'Publisher modified successfully')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1157, 2, 85, N'Unselected genre')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1158, 2, 86, N'Genre modified successfully')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1159, 2, 87, N'Unselected product')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1160, 2, 88, N'Product modified successfully')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1161, 2, 89, N'Product published successfully')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1162, 2, 90, N'The stock is insufficient')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1163, 2, 91, N'Sale made successfully')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1164, 2, 92, N'Unselected stock order')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1165, 2, 93, N'Stock order received successfully. Stock increased.')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1166, 2, 94, N'Manage business')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1167, 2, 95, N'Author management')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1168, 2, 96, N'Insert author')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1169, 2, 97, N'Modify author')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1170, 2, 98, N'Manage publisher')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1171, 2, 99, N'Insert publisher')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1172, 2, 100, N'Modify publisher')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1173, 2, 101, N'Genre management')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1174, 2, 102, N'Insert genre')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1175, 2, 103, N'Modify genre')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1176, 2, 104, N'Products')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1177, 2, 105, N'Product management')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1178, 2, 106, N'Insert product')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1179, 2, 107, N'Modify product')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1180, 2, 108, N'Publish product')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1181, 2, 109, N'Pin product')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1182, 2, 110, N'List products')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1183, 2, 111, N'Orders')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1184, 2, 112, N'Generate stock order')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1185, 2, 113, N'Generate stock order pinned products')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1186, 2, 114, N'Receive stock order')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1187, 2, 115, N'View stock orders')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1188, 2, 116, N'Sales')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1189, 2, 117, N'Make sale')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1190, 2, 118, N'View sales')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1191, 2, 119, N'Language')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1192, 2, 120, N'Language management')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1193, 2, 121, N'Insert language')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1194, 2, 122, N'Upload tags')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1195, 2, 123, N'Modify tags')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1196, 2, 124, N'Received')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1197, 2, 125, N'For sale')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1198, 2, 126, N'There are fields empty')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1199, 1, 1094, N'Seguridad')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1200, 1, 1095, N'Permisos')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1201, 1, 1096, N'Gestión de familias y patentes')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1202, 1, 1097, N'Gestión de permisos de usuario')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1203, 1, 1098, N'Cambiar contraseña')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1204, 1, 1099, N'Nueva familia')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1205, 1, 1100, N'Nombre')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1206, 1, 1101, N'Nueva patente')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1207, 1, 1102, N'Patente')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1208, 1, 1103, N'Nombre')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1209, 1, 1104, N'Patentes existentes')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1210, 1, 1106, N'Familias existentes')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1211, 1, 1108, N'Permiso')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1212, 1, 1109, N'Guardar familia')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1213, 1, 1110, N'Guardar patente')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1214, 1, 1111, N'Configurar')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1215, 1, 1112, N'Agregar')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1216, 1, 1113, N'Agregar')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1217, 1, 1115, N'Eliminar')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1218, 1, 1116, N'Configurar')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1219, 1, 1117, N'Guardar')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1220, 1, 1118, N'Familia creada con éxito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1221, 1, 1119, N'Patente creada con éxito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1222, 1, 1120, N'Error al querer cargar el árbol de permisos')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1223, 1, 1121, N'Esa patente ya se encuentra cargada')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1224, 1, 1122, N'Error al querer cargar la patente')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1225, 1, 1123, N'Familia guardada con éxito')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1226, 1, 1124, N'Error de recursividad. No se pudo añadir.')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1227, 1, 1125, N'Ese usuario ya tiene esa familia asociada')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1228, 1, 1126, N'Debe seleccionar un usuario')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1229, 1, 1127, N'Ese usuario ya tiene esa patente asociada')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1230, 1, 1128, N'Permisos guardados correctamente')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1231, 1, 1129, N'No se pudieron guardar los permisos')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1232, 1, 1130, N'Contraseña actual')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1233, 1, 1131, N'Contraseña nueva')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1234, 1, 1132, N'Confirmar contraseña nueva')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1235, 1, 1133, N'Cambiar')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1236, 1, 1134, N'La contraseña no coincide')
INSERT [dbo].[Traduccion] ([Id], [IdiomaId], [EtiquetaId], [Traduccion]) VALUES (1237, 1, 1136, N'Contraseña cambiada con éxito')
SET IDENTITY_INSERT [dbo].[Traduccion] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([UsuarioId], [Email], [Password], [Nombre], [Apellido], [Bloqueo]) VALUES (1, N'zytYsyL7FNNuleTccgskCjdX97Xz9JJxAcOZ0og07bk=', N'Wpc+Gn1uW+hvznWX3+/fHumxStJc9kcf6xgOu8StqLU=', N'DwYpXQd5ThCKyOtdkQfiAQ==', N'9vYEdDvaswxngkpKwSqPjw==', 0)
INSERT [dbo].[Usuario] ([UsuarioId], [Email], [Password], [Nombre], [Apellido], [Bloqueo]) VALUES (2, N'ms7RvBSd7oUmWdFJv20ue3AAY/zXX9soN6FRs3lcZI0=', N'Wpc+Gn1uW+hvznWX3+/fHumxStJc9kcf6xgOu8StqLU=', N'XGABM4Mvw4N7say/j/nBjA==', N'XGABM4Mvw4N7say/j/nBjA==', 0)
INSERT [dbo].[Usuario] ([UsuarioId], [Email], [Password], [Nombre], [Apellido], [Bloqueo]) VALUES (3, N'M4ADRNJO470zsQJoQSLdOCpBD0NqKpR6/BjfsX1fnac=', N'Wpc+Gn1uW+hvznWX3+/fHumxStJc9kcf6xgOu8StqLU=', N'lwzLBlssKzhTuH9YKpsXhg==', N'lwzLBlssKzhTuH9YKpsXhg==', 0)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
INSERT [dbo].[UsuarioPermiso] ([UsuarioId], [PatenteId]) VALUES (1, 17)
INSERT [dbo].[UsuarioPermiso] ([UsuarioId], [PatenteId]) VALUES (2, 18)
INSERT [dbo].[UsuarioPermiso] ([UsuarioId], [PatenteId]) VALUES (3, 19)
GO
/****** Object:  Index [IX_Alerta_ProductoId]    Script Date: 26-Jun-22 21:31:23 ******/
CREATE NONCLUSTERED INDEX [IX_Alerta_ProductoId] ON [dbo].[Alerta]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ComprobanteCompra_EnvioId]    Script Date: 26-Jun-22 21:31:23 ******/
CREATE NONCLUSTERED INDEX [IX_ComprobanteCompra_EnvioId] ON [dbo].[ComprobanteCompra]
(
	[EnvioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetalleComprobante_ComprobanteCompraId]    Script Date: 26-Jun-22 21:31:23 ******/
CREATE NONCLUSTERED INDEX [IX_DetalleComprobante_ComprobanteCompraId] ON [dbo].[DetalleComprobante]
(
	[ComprobanteCompraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetalleComprobante_ComprobanteVentaId]    Script Date: 26-Jun-22 21:31:23 ******/
CREATE NONCLUSTERED INDEX [IX_DetalleComprobante_ComprobanteVentaId] ON [dbo].[DetalleComprobante]
(
	[ComprobanteVentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetalleComprobante_ProductoId]    Script Date: 26-Jun-22 21:31:23 ******/
CREATE NONCLUSTERED INDEX [IX_DetalleComprobante_ProductoId] ON [dbo].[DetalleComprobante]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Producto_AutorId]    Script Date: 26-Jun-22 21:31:23 ******/
CREATE NONCLUSTERED INDEX [IX_Producto_AutorId] ON [dbo].[Producto]
(
	[AutorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Producto_EditorialId]    Script Date: 26-Jun-22 21:31:23 ******/
CREATE NONCLUSTERED INDEX [IX_Producto_EditorialId] ON [dbo].[Producto]
(
	[EditorialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Producto_GeneroId]    Script Date: 26-Jun-22 21:31:23 ******/
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
ALTER TABLE [dbo].[FamiliaPatente]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaPatente_Permiso] FOREIGN KEY([PadreId])
REFERENCES [dbo].[Permiso] ([Id])
GO
ALTER TABLE [dbo].[FamiliaPatente] CHECK CONSTRAINT [FK_FamiliaPatente_Permiso]
GO
ALTER TABLE [dbo].[FamiliaPatente]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaPatente_Permiso1] FOREIGN KEY([HijoId])
REFERENCES [dbo].[Permiso] ([Id])
GO
ALTER TABLE [dbo].[FamiliaPatente] CHECK CONSTRAINT [FK_FamiliaPatente_Permiso1]
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
ALTER TABLE [dbo].[UsuarioPermiso]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPermiso_Patente] FOREIGN KEY([PatenteId])
REFERENCES [dbo].[Permiso] ([Id])
GO
ALTER TABLE [dbo].[UsuarioPermiso] CHECK CONSTRAINT [FK_UsuarioPermiso_Patente]
GO
ALTER TABLE [dbo].[UsuarioPermiso]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPermiso_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[UsuarioPermiso] CHECK CONSTRAINT [FK_UsuarioPermiso_Usuario]
GO
USE [master]
GO
ALTER DATABASE [GBook] SET  READ_WRITE 
GO
