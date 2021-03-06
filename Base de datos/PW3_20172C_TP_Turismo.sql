
USE [master]
GO
/****** Object:  Database [PW3_20172C_TP_Turismo]    Script Date: 2/8/2017 7:39:25 PM ******/
CREATE DATABASE [PW3_20172C_TP_Turismo]

GO
ALTER DATABASE [PW3_20172C_TP_Turismo] SET COMPATIBILITY_LEVEL = 120
GO

USE [PW3_20172C_TP_Turismo]
GO
/****** Object:  Table [dbo].[Paquete]    Script Date: 2/3/2017 7:39:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paquete](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Foto] [nvarchar](max) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[Destacado] [bit] NOT NULL CONSTRAINT [DF_Paquete_Destacado]  DEFAULT ((0)),
	[LugaresDisponibles] [int] NULL,
	[PrecioPorPersona] [int] NOT NULL,
 CONSTRAINT [PK_Paquete] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 2/3/2017 7:39:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CantPersonas] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL CONSTRAINT [DF_Reserva_FechaCreacion]  DEFAULT (getdate()),
	[IdPaquete] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 2/3/2017 7:39:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Contrasenia] [nvarchar](50) NOT NULL,
	[Admin] [bit] NOT NULL CONSTRAINT [DF_Usuario_Admin]  DEFAULT ((0)),
	[Nombre] [nvarchar](200) NOT NULL,
	[Apellido] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Paquete] FOREIGN KEY([IdPaquete])
REFERENCES [dbo].[Paquete] ([Id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Paquete]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Usuario]
GO
USE [master]
GO
ALTER DATABASE [PW3_20172C_TP_Turismo] SET  READ_WRITE 
GO
