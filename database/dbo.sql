/*
 Navicat Premium Dump SQL

 Source Server         : SQL_Server
 Source Server Type    : SQL Server
 Source Server Version : 16001135 (16.00.1135)
 Source Host           : PC-SHEBA\SQLEXPRESS:1433
 Source Catalog        : bd_vacaciones
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001135 (16.00.1135)
 File Encoding         : 65001

 Date: 26/01/2025 23:00:22
*/


-- ----------------------------
-- Table structure for departamentos
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[departamentos]') AND type IN ('U'))
	DROP TABLE [dbo].[departamentos]
GO

CREATE TABLE [dbo].[departamentos] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [nombre] varchar(128) COLLATE SQL_Latin1_General_CP1_CI_AI  NOT NULL,
  [esta_activo] bit DEFAULT 1 NULL,
  [fecha_creacion] datetime DEFAULT sysdatetime() NULL
)
GO

ALTER TABLE [dbo].[departamentos] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of departamentos
-- ----------------------------
SET IDENTITY_INSERT [dbo].[departamentos] ON
GO

INSERT INTO [dbo].[departamentos] ([id], [nombre], [esta_activo], [fecha_creacion]) VALUES (N'1', N'Recursos Humanos', N'1', N'2025-01-01 23:46:00.037')
GO

INSERT INTO [dbo].[departamentos] ([id], [nombre], [esta_activo], [fecha_creacion]) VALUES (N'2', N'Finanzas 2', N'0', N'2025-01-01 23:46:17.583')
GO

INSERT INTO [dbo].[departamentos] ([id], [nombre], [esta_activo], [fecha_creacion]) VALUES (N'3', N'Ventas', N'1', N'2025-01-01 23:46:26.880')
GO

INSERT INTO [dbo].[departamentos] ([id], [nombre], [esta_activo], [fecha_creacion]) VALUES (N'4', N'Operaciones', N'1', N'2025-01-01 23:46:32.990')
GO

INSERT INTO [dbo].[departamentos] ([id], [nombre], [esta_activo], [fecha_creacion]) VALUES (N'5', N'Administración', N'1', N'2025-01-02 01:02:51.060')
GO

INSERT INTO [dbo].[departamentos] ([id], [nombre], [esta_activo], [fecha_creacion]) VALUES (N'6', N'Limpieza', N'1', N'2025-01-02 01:27:16.783')
GO

INSERT INTO [dbo].[departamentos] ([id], [nombre], [esta_activo], [fecha_creacion]) VALUES (N'7', N'Ingenieria', N'1', N'2025-01-06 23:54:13.273')
GO

INSERT INTO [dbo].[departamentos] ([id], [nombre], [esta_activo], [fecha_creacion]) VALUES (N'8', N'Ejemplo2', N'0', N'2025-01-12 13:41:47.900')
GO

INSERT INTO [dbo].[departamentos] ([id], [nombre], [esta_activo], [fecha_creacion]) VALUES (N'9', N'Finanzas', N'1', N'2025-01-26 22:45:06.587')
GO

SET IDENTITY_INSERT [dbo].[departamentos] OFF
GO


-- ----------------------------
-- Table structure for empleados
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[empleados]') AND type IN ('U'))
	DROP TABLE [dbo].[empleados]
GO

CREATE TABLE [dbo].[empleados] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [nombre_completo] varchar(64) COLLATE SQL_Latin1_General_CP1_CI_AI  NOT NULL,
  [apellido_paterno] varchar(64) COLLATE SQL_Latin1_General_CP1_CI_AI  NOT NULL,
  [apellido_materno] varchar(64) COLLATE SQL_Latin1_General_CP1_CI_AI  NULL,
  [fecha_ingreso] date DEFAULT getdate() NULL,
  [fecha_nacimiento] date DEFAULT getdate() NULL,
  [correo_electronico] varchar(128) COLLATE SQL_Latin1_General_CP1_CI_AI  NOT NULL,
  [id_departamento] int  NOT NULL,
  [id_tipo_empleado] int  NOT NULL,
  [esta_activo] bit DEFAULT 1 NULL,
  [fecha_creacion] datetime DEFAULT sysdatetime() NULL
)
GO

ALTER TABLE [dbo].[empleados] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of empleados
-- ----------------------------
SET IDENTITY_INSERT [dbo].[empleados] ON
GO

INSERT INTO [dbo].[empleados] ([id], [nombre_completo], [apellido_paterno], [apellido_materno], [fecha_ingreso], [fecha_nacimiento], [correo_electronico], [id_departamento], [id_tipo_empleado], [esta_activo], [fecha_creacion]) VALUES (N'2', N'Sebastian David', N'Torres', N'Chavez', N'2020-01-19', N'1991-08-02', N'sebasdtc@outlook.com', N'1', N'1', N'1', N'2025-01-08 20:05:41.033')
GO

INSERT INTO [dbo].[empleados] ([id], [nombre_completo], [apellido_paterno], [apellido_materno], [fecha_ingreso], [fecha_nacimiento], [correo_electronico], [id_departamento], [id_tipo_empleado], [esta_activo], [fecha_creacion]) VALUES (N'3', N'Miguel Angel', N'Zavaleta', N'Chavez', N'2022-10-01', N'1999-07-23', N'mzavaleta@programming.com', N'4', N'2', N'1', N'2025-01-08 21:26:39.173')
GO

INSERT INTO [dbo].[empleados] ([id], [nombre_completo], [apellido_paterno], [apellido_materno], [fecha_ingreso], [fecha_nacimiento], [correo_electronico], [id_departamento], [id_tipo_empleado], [esta_activo], [fecha_creacion]) VALUES (N'4', N'Jose espinoza', N'Elber', NULL, N'2020-12-10', N'1999-10-12', N'jt_2022@gamil.com', N'3', N'1', N'0', N'2025-01-12 12:24:16.640')
GO

INSERT INTO [dbo].[empleados] ([id], [nombre_completo], [apellido_paterno], [apellido_materno], [fecha_ingreso], [fecha_nacimiento], [correo_electronico], [id_departamento], [id_tipo_empleado], [esta_activo], [fecha_creacion]) VALUES (N'5', N'Flavia', N'Torres', N'Robles', N'2020-10-19', N'2020-10-19', N'ftorres@gmail.com', N'9', N'2', N'1', N'2025-01-26 22:48:31.847')
GO

SET IDENTITY_INSERT [dbo].[empleados] OFF
GO


-- ----------------------------
-- Table structure for fechas_vacaciones
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[fechas_vacaciones]') AND type IN ('U'))
	DROP TABLE [dbo].[fechas_vacaciones]
GO

CREATE TABLE [dbo].[fechas_vacaciones] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [id_solicitud_vacacion] int  NOT NULL,
  [fecha_solicitada] date  NOT NULL,
  [tipo_turno] varchar(16) COLLATE SQL_Latin1_General_CP1_CI_AI DEFAULT 'Completo' NOT NULL
)
GO

ALTER TABLE [dbo].[fechas_vacaciones] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of fechas_vacaciones
-- ----------------------------
SET IDENTITY_INSERT [dbo].[fechas_vacaciones] ON
GO

SET IDENTITY_INSERT [dbo].[fechas_vacaciones] OFF
GO


-- ----------------------------
-- Table structure for roles
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[roles]') AND type IN ('U'))
	DROP TABLE [dbo].[roles]
GO

CREATE TABLE [dbo].[roles] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [nombre] varchar(64) COLLATE SQL_Latin1_General_CP1_CI_AI  NOT NULL,
  [esta_activo] bit DEFAULT 1 NULL,
  [fecha_creacion] datetime DEFAULT sysdatetime() NULL
)
GO

ALTER TABLE [dbo].[roles] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of roles
-- ----------------------------
SET IDENTITY_INSERT [dbo].[roles] ON
GO

SET IDENTITY_INSERT [dbo].[roles] OFF
GO


-- ----------------------------
-- Table structure for solicitudes_vacaciones
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[solicitudes_vacaciones]') AND type IN ('U'))
	DROP TABLE [dbo].[solicitudes_vacaciones]
GO

CREATE TABLE [dbo].[solicitudes_vacaciones] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [id_empleado] int  NOT NULL,
  [fecha_solicitud] date  NULL,
  [dias_solicitados] int  NOT NULL,
  [estado_solicitud] varchar(12) COLLATE SQL_Latin1_General_CP1_CI_AI DEFAULT 'Pendiente' NOT NULL
)
GO

ALTER TABLE [dbo].[solicitudes_vacaciones] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of solicitudes_vacaciones
-- ----------------------------
SET IDENTITY_INSERT [dbo].[solicitudes_vacaciones] ON
GO

SET IDENTITY_INSERT [dbo].[solicitudes_vacaciones] OFF
GO


-- ----------------------------
-- Table structure for tipos_empleados
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tipos_empleados]') AND type IN ('U'))
	DROP TABLE [dbo].[tipos_empleados]
GO

CREATE TABLE [dbo].[tipos_empleados] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [nombre] varchar(64) COLLATE SQL_Latin1_General_CP1_CI_AI  NOT NULL,
  [dias_por_anio] int  NOT NULL,
  [esta_activo] bit DEFAULT 1 NULL,
  [fecha_creacion] datetime DEFAULT sysdatetime() NULL
)
GO

ALTER TABLE [dbo].[tipos_empleados] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tipos_empleados
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tipos_empleados] ON
GO

INSERT INTO [dbo].[tipos_empleados] ([id], [nombre], [dias_por_anio], [esta_activo], [fecha_creacion]) VALUES (N'1', N'Empleados internacionales', N'21', N'1', N'2025-01-03 23:01:14.317')
GO

INSERT INTO [dbo].[tipos_empleados] ([id], [nombre], [dias_por_anio], [esta_activo], [fecha_creacion]) VALUES (N'2', N'Empleados locales profesionales', N'16', N'1', N'2025-01-03 23:01:25.023')
GO

INSERT INTO [dbo].[tipos_empleados] ([id], [nombre], [dias_por_anio], [esta_activo], [fecha_creacion]) VALUES (N'3', N'Empleados locales no profesionales', N'14', N'1', N'2025-01-03 23:01:42.333')
GO

SET IDENTITY_INSERT [dbo].[tipos_empleados] OFF
GO


-- ----------------------------
-- Table structure for usuarios
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[usuarios]') AND type IN ('U'))
	DROP TABLE [dbo].[usuarios]
GO

CREATE TABLE [dbo].[usuarios] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [clave] varchar(128) COLLATE SQL_Latin1_General_CP1_CI_AI  NOT NULL,
  [id_rol] int  NOT NULL,
  [esta_activo] bit DEFAULT 1 NULL,
  [fecha_creacion] datetime DEFAULT sysdatetime() NULL
)
GO

ALTER TABLE [dbo].[usuarios] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of usuarios
-- ----------------------------
SET IDENTITY_INSERT [dbo].[usuarios] ON
GO

SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO


-- ----------------------------
-- Auto increment value for departamentos
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[departamentos]', RESEED, 9)
GO


-- ----------------------------
-- Primary Key structure for table departamentos
-- ----------------------------
ALTER TABLE [dbo].[departamentos] ADD CONSTRAINT [PK__departam__3213E83F54D52E5D] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for empleados
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[empleados]', RESEED, 5)
GO


-- ----------------------------
-- Primary Key structure for table empleados
-- ----------------------------
ALTER TABLE [dbo].[empleados] ADD CONSTRAINT [PK__empleado__3213E83F77F04533] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for fechas_vacaciones
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[fechas_vacaciones]', RESEED, 1)
GO


-- ----------------------------
-- Checks structure for table fechas_vacaciones
-- ----------------------------
ALTER TABLE [dbo].[fechas_vacaciones] ADD CONSTRAINT [CK__fechas_va__tipo___5FB337D6] CHECK ([tipo_turno]='Completo' OR [tipo_turno]='Tarde' OR [tipo_turno]='Mañana')
GO


-- ----------------------------
-- Primary Key structure for table fechas_vacaciones
-- ----------------------------
ALTER TABLE [dbo].[fechas_vacaciones] ADD CONSTRAINT [PK__fechas_v__3213E83FAF2C8F42] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for roles
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[roles]', RESEED, 1)
GO


-- ----------------------------
-- Uniques structure for table roles
-- ----------------------------
ALTER TABLE [dbo].[roles] ADD CONSTRAINT [UQ__roles__72AFBCC69BB5C7BA] UNIQUE NONCLUSTERED ([nombre] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table roles
-- ----------------------------
ALTER TABLE [dbo].[roles] ADD CONSTRAINT [PK__roles__3213E83F33F2B71A] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for solicitudes_vacaciones
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[solicitudes_vacaciones]', RESEED, 1)
GO


-- ----------------------------
-- Checks structure for table solicitudes_vacaciones
-- ----------------------------
ALTER TABLE [dbo].[solicitudes_vacaciones] ADD CONSTRAINT [CK__solicitud__estad__5AEE82B9] CHECK ([estado_solicitud]='Pendiente' OR [estado_solicitud]='Rechazado' OR [estado_solicitud]='Aprobado')
GO


-- ----------------------------
-- Primary Key structure for table solicitudes_vacaciones
-- ----------------------------
ALTER TABLE [dbo].[solicitudes_vacaciones] ADD CONSTRAINT [PK__solicitu__3213E83F67B111C0] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tipos_empleados
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tipos_empleados]', RESEED, 4)
GO


-- ----------------------------
-- Primary Key structure for table tipos_empleados
-- ----------------------------
ALTER TABLE [dbo].[tipos_empleados] ADD CONSTRAINT [PK__tipos_em__3213E83FDABCD24D] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for usuarios
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[usuarios]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table usuarios
-- ----------------------------
ALTER TABLE [dbo].[usuarios] ADD CONSTRAINT [PK__usuarios__3213E83F36757CD1] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table empleados
-- ----------------------------
ALTER TABLE [dbo].[empleados] ADD CONSTRAINT [FK__empleados__id_de__5535A963] FOREIGN KEY ([id_departamento]) REFERENCES [dbo].[departamentos] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[empleados] ADD CONSTRAINT [FK__empleados__id_ti__5629CD9C] FOREIGN KEY ([id_tipo_empleado]) REFERENCES [dbo].[tipos_empleados] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table fechas_vacaciones
-- ----------------------------
ALTER TABLE [dbo].[fechas_vacaciones] ADD CONSTRAINT [FK__fechas_va__id_so__5EBF139D] FOREIGN KEY ([id_solicitud_vacacion]) REFERENCES [dbo].[solicitudes_vacaciones] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table solicitudes_vacaciones
-- ----------------------------
ALTER TABLE [dbo].[solicitudes_vacaciones] ADD CONSTRAINT [FK__solicitud__id_em__59FA5E80] FOREIGN KEY ([id_empleado]) REFERENCES [dbo].[empleados] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table usuarios
-- ----------------------------
ALTER TABLE [dbo].[usuarios] ADD CONSTRAINT [FK__usuarios__id_rol__693CA210] FOREIGN KEY ([id_rol]) REFERENCES [dbo].[roles] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

