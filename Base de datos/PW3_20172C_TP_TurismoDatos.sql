USE [PW3_20172C_TP_Turismo]
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT INTO [dbo].[Usuario] ([Email], [Contrasenia], [Admin], [Nombre], [Apellido]) VALUES (N'admin@turismo.com', N'1234', 1, N'Despegar', N'Puntocom')
INSERT INTO [dbo].[Usuario] ([Email], [Contrasenia], [Admin], [Nombre], [Apellido]) VALUES (N'usuario1@gmail.com', N'1234', 0, N'Viaja', N'Solari')
INSERT INTO [dbo].[Usuario] ([Email], [Contrasenia], [Admin], [Nombre], [Apellido]) VALUES (N'usuario2@gmail.com', N'1234', 0, N'Viaja', N'EnFamilia')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
SET IDENTITY_INSERT [dbo].[Paquete] ON 

INSERT INTO [dbo].[Paquete] ([Nombre], [Descripcion], [Foto], [FechaInicio], [FechaFin], [Destacado], [LugaresDisponibles], [PrecioPorPersona]) VALUES (N'Cancun', N'7 dias 6 noches en Hotel 4 estreallas ALL INCLUSIVE', N'/imagenes/cancun.jpg', CAST(N'2018-07-01 00:00:00.000' AS DateTime), CAST(N'2017-10-10 00:00:00.000' AS DateTime), 1, 10, 10000)
INSERT INTO [dbo].[Paquete] ([Nombre], [Descripcion], [Foto], [FechaInicio], [FechaFin], [Destacado], [LugaresDisponibles], [PrecioPorPersona]) VALUES (N'Bariloche', N'6 dias 5 noches en Hotel 3 estrellas con media pensión', N'/imagenes/bariloche.jpg', CAST(N'2018-03-10 00:00:00.000' AS DateTime), CAST(N'2018-03-16 00:00:00.000' AS DateTime), 1, 30, 4000)
INSERT INTO [dbo].[Paquete] ([Nombre], [Descripcion], [Foto], [FechaInicio], [FechaFin], [Destacado], [LugaresDisponibles], [PrecioPorPersona]) VALUES (N'Mundial Rusia 2018', N'Te vas a perder el mundial?!', N'/imagenes/mundial.jpg', CAST(N'2018-06-01 00:00:00.000' AS DateTime), CAST(N'2018-06-25 00:00:00.000' AS DateTime), 1, 100, 20000)
INSERT INTO [dbo].[Paquete] ([Nombre], [Descripcion], [Foto], [FechaInicio], [FechaFin], [Destacado], [LugaresDisponibles], [PrecioPorPersona]) VALUES (N'JJOO Tokio 2020', N'Paquete 1 - Basket, Handball, Voley', N'/imagenes/jjoo.jpg', CAST(N'2018-08-01 00:00:00.000' AS DateTime), CAST(N'2020-08-10 00:00:00.000' AS DateTime), 1, 20, 18000)
INSERT INTO [dbo].[Paquete] ([Nombre], [Descripcion], [Foto], [FechaInicio], [FechaFin], [Destacado], [LugaresDisponibles], [PrecioPorPersona]) VALUES (N'Mar del Plata - Semana Santa ', N'3 dias 4 noches', N'/imagenes/123.jpg', CAST(N'2018-04-01 00:00:00.000' AS DateTime), CAST(N'2018-04-05 00:00:00.000' AS DateTime), 0, 8, 2500)
SET IDENTITY_INSERT [dbo].[Paquete] OFF
SET IDENTITY_INSERT [dbo].[Reserva] ON 

INSERT INTO [dbo].[Reserva] ([CantPersonas], [FechaCreacion], [IdPaquete], [IdUsuario]) VALUES (1, CAST(N'2017-03-02 00:00:00.000' AS DateTime), 1, 2)
INSERT INTO [dbo].[Reserva] ([CantPersonas], [FechaCreacion], [IdPaquete], [IdUsuario]) VALUES (4, CAST(N'2017-03-02 00:00:00.000' AS DateTime), 1, 3)
INSERT INTO [dbo].[Reserva] ([CantPersonas], [FechaCreacion], [IdPaquete], [IdUsuario]) VALUES (10, CAST(N'2017-04-03 00:00:00.000' AS DateTime), 5, 3)
INSERT INTO [dbo].[Reserva] ([CantPersonas], [FechaCreacion], [IdPaquete], [IdUsuario]) VALUES (10, CAST(N'2017-03-02 00:00:00.000' AS DateTime), 4, 3)
INSERT INTO [dbo].[Reserva] ([CantPersonas], [FechaCreacion], [IdPaquete], [IdUsuario]) VALUES (1, CAST(N'2017-03-02 00:00:00.000' AS DateTime), 4, 2)
SET IDENTITY_INSERT [dbo].[Reserva] OFF
