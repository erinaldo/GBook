USE [master]
GO
/****** Object:  Database [GBook]    Script Date: 16-Jun-22 17:52:25 ******/
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
/****** Object:  Table [dbo].[Alerta]    Script Date: 16-Jun-22 17:52:25 ******/
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
/****** Object:  Table [dbo].[Autor]    Script Date: 16-Jun-22 17:52:26 ******/
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
/****** Object:  Table [dbo].[ComprobanteCompra]    Script Date: 16-Jun-22 17:52:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComprobanteCompra](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaRecepcion] [datetime2](7) NOT NULL,
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
/****** Object:  Table [dbo].[ComprobanteVenta]    Script Date: 16-Jun-22 17:52:26 ******/
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
/****** Object:  Table [dbo].[DetalleComprobante]    Script Date: 16-Jun-22 17:52:26 ******/
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
/****** Object:  Table [dbo].[Editorial]    Script Date: 16-Jun-22 17:52:26 ******/
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
/****** Object:  Table [dbo].[Envio]    Script Date: 16-Jun-22 17:52:26 ******/
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
/****** Object:  Table [dbo].[Genero]    Script Date: 16-Jun-22 17:52:26 ******/
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
/****** Object:  Table [dbo].[Producto]    Script Date: 16-Jun-22 17:52:26 ******/
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
/****** Object:  Table [dbo].[Stock]    Script Date: 16-Jun-22 17:52:26 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 16-Jun-22 17:52:26 ******/
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

INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (1, 0, 0, 6)
INSERT [dbo].[Alerta] ([Id], [Activo], [CantidadStockAviso], [ProductoId]) VALUES (2, 0, 0, 7)
SET IDENTITY_INSERT [dbo].[Alerta] OFF
GO
SET IDENTITY_INSERT [dbo].[Autor] ON 

INSERT [dbo].[Autor] ([Id], [Nombre], [Apellido], [Seudonimo], [Activo]) VALUES (1, N'Joanne', N'Rowling', N'J.K. Rowling', 1)
SET IDENTITY_INSERT [dbo].[Autor] OFF
GO
SET IDENTITY_INSERT [dbo].[Editorial] ON 

INSERT [dbo].[Editorial] ([Id], [Nombre], [Activo]) VALUES (1, N'Salamandra', 1)
SET IDENTITY_INSERT [dbo].[Editorial] OFF
GO
SET IDENTITY_INSERT [dbo].[Genero] ON 

INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (1, N'Fantasía', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (2, N'Ficción', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (3, N'Policial', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (4, N'Romance', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (5, N'Aventura', 1)
SET IDENTITY_INSERT [dbo].[Genero] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (6, N'9789878000107', N'Harry Potter Y La Piedra Filosofal', 1750.5, 288, 1, 1, 1, 1, 1)
INSERT [dbo].[Producto] ([Id], [ISBN], [Nombre], [Precio], [CantidadPaginas], [EnVenta], [Activo], [AutorId], [GeneroId], [EditorialId]) VALUES (7, N'9789878000114', N'Harry Potter Y La Camara Secreta', 2000, 320, 1, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (1, 0, 6)
INSERT [dbo].[Stock] ([Id], [Cantidad], [ProductoId]) VALUES (2, 0, 7)
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([UsuarioId], [Email], [Password], [Nombre], [Apellido], [Bloqueo]) VALUES (1, N'zytYsyL7FNNuleTccgskCjdX97Xz9JJxAcOZ0og07bk=', N'Wpc+Gn1uW+hvznWX3+/fHumxStJc9kcf6xgOu8StqLU=', N'DwYpXQd5ThCKyOtdkQfiAQ==', N'9vYEdDvaswxngkpKwSqPjw==', 2)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
/****** Object:  Index [IX_Alerta_ProductoId]    Script Date: 16-Jun-22 17:52:26 ******/
CREATE NONCLUSTERED INDEX [IX_Alerta_ProductoId] ON [dbo].[Alerta]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ComprobanteCompra_EnvioId]    Script Date: 16-Jun-22 17:52:26 ******/
CREATE NONCLUSTERED INDEX [IX_ComprobanteCompra_EnvioId] ON [dbo].[ComprobanteCompra]
(
	[EnvioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetalleComprobante_ComprobanteCompraId]    Script Date: 16-Jun-22 17:52:26 ******/
CREATE NONCLUSTERED INDEX [IX_DetalleComprobante_ComprobanteCompraId] ON [dbo].[DetalleComprobante]
(
	[ComprobanteCompraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetalleComprobante_ComprobanteVentaId]    Script Date: 16-Jun-22 17:52:26 ******/
CREATE NONCLUSTERED INDEX [IX_DetalleComprobante_ComprobanteVentaId] ON [dbo].[DetalleComprobante]
(
	[ComprobanteVentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetalleComprobante_ProductoId]    Script Date: 16-Jun-22 17:52:26 ******/
CREATE NONCLUSTERED INDEX [IX_DetalleComprobante_ProductoId] ON [dbo].[DetalleComprobante]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Producto_AutorId]    Script Date: 16-Jun-22 17:52:26 ******/
CREATE NONCLUSTERED INDEX [IX_Producto_AutorId] ON [dbo].[Producto]
(
	[AutorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Producto_EditorialId]    Script Date: 16-Jun-22 17:52:26 ******/
CREATE NONCLUSTERED INDEX [IX_Producto_EditorialId] ON [dbo].[Producto]
(
	[EditorialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Producto_GeneroId]    Script Date: 16-Jun-22 17:52:26 ******/
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
USE [master]
GO
ALTER DATABASE [GBook] SET  READ_WRITE 
GO
