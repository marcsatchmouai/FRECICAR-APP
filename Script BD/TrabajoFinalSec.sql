USE [master]
GO
/****** Object:  Database [TrabajoFinalSec]    Script Date: 05/02/2019 15:58:56 ******/
CREATE DATABASE [TrabajoFinalSec]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TrabajoFinalSec', FILENAME = N'b:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\TrabajoFinalSec.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TrabajoFinalSec_log', FILENAME = N'b:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\TrabajoFinalSec_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TrabajoFinalSec] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TrabajoFinalSec].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TrabajoFinalSec] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET ARITHABORT OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TrabajoFinalSec] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TrabajoFinalSec] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TrabajoFinalSec] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TrabajoFinalSec] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TrabajoFinalSec] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TrabajoFinalSec] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TrabajoFinalSec] SET  MULTI_USER 
GO
ALTER DATABASE [TrabajoFinalSec] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TrabajoFinalSec] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TrabajoFinalSec] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TrabajoFinalSec] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [TrabajoFinalSec]
GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarGrupo]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_AgregarGrupo] @NombreGrupo varchar(20), @Descripcion varchar(200)
as Insert into Grupos values (@NombreGrupo,@Descripcion)

GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarGruposUsuario]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_AgregarGruposUsuario] @NombreUsuario varchar(15), @NombreGrupo varchar(20)
as Insert into Grupos_Usuarios values (@NombreUsuario,@NombreGrupo)

GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarPerfil]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_AgregarPerfil] @NombreGrupo varchar(20), @Nombreformulario varchar(50), @NombrePermiso varchar(15)
as Insert into Perfiles values (@NombreGrupo,@Nombreformulario,@NombrePermiso)

GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarUsuario]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_AgregarUsuario] 
(
@NombreUsuario varchar(15),
@NombreApellido varchar(60),
@Clave varbinary(max),
@Email varchar(150),
@Habilitado bit,
@Activo bit
)
as begin 

Insert into Usuarios (Id_Usuario,Nombre_Apellido,Clave,Email,Habilitado,Activo) 
values (@NombreUsuario,@NombreApellido, @Clave, @Email, @Habilitado,@Activo)

end
GO
/****** Object:  StoredProcedure [dbo].[sp_ConsultarFormularios]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ConsultarFormularios]
as select Formularios.Id_Formulario, Formularios.Descripcion from Formularios
---Stored Table Permisos

GO
/****** Object:  StoredProcedure [dbo].[sp_ConsultarFormulariosGrupo]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ConsultarFormulariosGrupo] @NombreGrupo varchar(20)
as select distinct(Formularios.Id_Formulario),Formularios.Descripcion from Perfiles inner join Formularios on Perfiles.Id_Formulario = Formularios.Id_Formulario where Id_Grupo = @NombreGrupo

GO
/****** Object:  StoredProcedure [dbo].[sp_ConsultarGrupos]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ConsultarGrupos]
as Select Id_Grupo,Descripcion from dbo.Grupos 

GO
/****** Object:  StoredProcedure [dbo].[sp_ConsultarGruposPerfiles]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ConsultarGruposPerfiles]
as select Grupos.Id_Grupo,Grupos.Descripcion from dbo.Perfiles inner join dbo.Grupos on dbo.Perfiles.Id_Grupo = dbo.Grupos.Id_Grupo 

GO
/****** Object:  StoredProcedure [dbo].[sp_ConsultarGruposUsuario]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ConsultarGruposUsuario] @Usuario varchar(15)
as Select dbo.Grupos.Id_Grupo,dbo.Grupos.Descripcion from dbo.Grupos_Usuarios inner join dbo.Grupos on dbo.Grupos_Usuarios.Id_Grupo = dbo.Grupos.Id_Grupo where dbo.Grupos_Usuarios.Id_Usuario = @Usuario

GO
/****** Object:  StoredProcedure [dbo].[sp_ConsultarPermisos]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ConsultarPermisos]
as select Permisos.Id_Permiso,Permisos.Descripcion from Permisos

---Stored Table Perfiles

GO
/****** Object:  StoredProcedure [dbo].[sp_ConsultarPermisosFormulario]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_ConsultarPermisosFormulario] @NombreGrupo varchar(20), @NombreFormulario varchar(50)
as Select Permisos.Id_Permiso,Permisos.Descripcion from Perfiles inner join Permisos on Perfiles.Id_Permiso = Permisos.Id_Permiso where Id_Grupo = @NombreGrupo and Id_Formulario = @NombreFormulario


GO
/****** Object:  StoredProcedure [dbo].[sp_ConsultarUsuarios]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ConsultarUsuarios] 
as Select Id_Usuario,Nombre_Apellido,Clave,Email,Habilitado,Activo from dbo.Usuarios

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarGrupo]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EliminarGrupo] @NombreGrupo varchar(20)
as delete from Grupos where Id_Grupo = @NombreGrupo 

---Stored Table Formularios

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarGruposUsuario]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EliminarGruposUsuario] @NombreUsuario varchar(15), @NombreGrupo varchar(20)
as delete from Grupos_Usuarios where Id_Usuario = @NombreUsuario and Id_Grupo = @NombreGrupo

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarPerfil]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EliminarPerfil] @NombreGrupo varchar(20)
as delete from Perfiles where Id_Grupo = @NombreGrupo

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarRegistroPerfil]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_EliminarRegistroPerfil] @NombreGrupo varchar(20),@NombreFormulario varchar(50), @NombrePermiso varchar(15)
as delete from Perfiles where Id_Grupo = @NombreGrupo and Id_Formulario = @NombreFormulario and Id_Permiso = @NombrePermiso

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarUsuario]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EliminarUsuario] @NombreUsuario varchar(15)
as begin
delete from Grupos_Usuarios where Id_Usuario = @NombreUsuario
delete from Usuarios where usuarios.Id_Usuario = @NombreUsuario
end

GO
/****** Object:  StoredProcedure [dbo].[SP_ListSituacionesFiscales]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SP_ListSituacionesFiscales]
as begin
select SituacionesFiscales.Codigo , SituacionesFiscales.Descripcion from SituacionesFiscales
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarGrupo]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ModificarGrupo] @NombreGrupo varchar(20), @Descripcion varchar(200)
as Update Grupos set Descripcion = @Descripcion where Id_Grupo = @NombreGrupo

GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarUsuario]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_ModificarUsuario] @NombreUsuario varchar(15),@Clave varbinary(max),@NombreApellido varchar(60),@Email varchar(150), @Habilitado bit, @Activo bit
as update Usuarios set Nombre_Apellido = @NombreApellido, Email = @Email,Clave = @Clave ,Habilitado = @Habilitado, Activo = @Activo where Id_Usuario = @NombreUsuario

GO
/****** Object:  StoredProcedure [dbo].[SP_ModificarUsuariosSinContraseña]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_ModificarUsuariosSinContraseña]
(
@NombreUsuario varchar(15),
@NombreApellido varchar(60),
@Email varchar(150),
@Habilitado bit,
@Activo bit
)
as begin
update Usuarios set Nombre_Apellido = @NombreApellido , Email = @Email , Habilitado = @Habilitado , Activo = @Activo
where Id_Usuario = @NombreUsuario
end


Select * from Usuarios
GO
/****** Object:  Table [dbo].[Formularios]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Formularios](
	[Id_Formulario] [varchar](50) NOT NULL,
	[Descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Formulario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grupos]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grupos](
	[Id_Grupo] [varchar](20) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Grupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grupos_Usuarios]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grupos_Usuarios](
	[Id_Usuario] [varchar](15) NOT NULL,
	[Id_Grupo] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC,
	[Id_Grupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Perfiles]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perfiles](
	[Id_Grupo] [varchar](20) NOT NULL,
	[Id_Formulario] [varchar](50) NOT NULL,
	[Id_Permiso] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Grupo] ASC,
	[Id_Permiso] ASC,
	[Id_Formulario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Permisos](
	[Id_Permiso] [varchar](15) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 05/02/2019 15:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id_Usuario] [varchar](15) NOT NULL,
	[Nombre_Apellido] [varchar](60) NOT NULL,
	[Email] [varchar](150) NULL,
	[Habilitado] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
	[Clave] [varbinary](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'Categorias', N'Gestion de Categorias')
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'CategoriasP', N'Gestionar Categorias Productos')
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'Clientes', N'Gestion de Clientes')
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'Envios', N'Gestion de Envios de Ventas')
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'FormaEnvios', N'Gestion de Forma de Envios')
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'FormaPagos', N'Gestion de Forma de Pagos')
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'MateriasPrimas', N'Gestion de Materias Primas')
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'OrdenesCompras', N'Gestion de Ordenes de Copras')
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'Pagos', N'Gestionar Pagos')
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'Productos', N'Gestionar Productos')
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'Proveedores', N'Gestion de Proveedores')
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'RealizarOrden', N'Realizar Orden de Compra')
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'RealizarRemito', N'Realizar Remito de Proveedor')
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'RealizarVenta', N'Realizar Venta')
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'RegistrarPago', N'Registrar Pago')
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'RemitosProveedor', N'Gestion de Remitos de Proveedor')
INSERT [dbo].[Formularios] ([Id_Formulario], [Descripcion]) VALUES (N'Ventas', N'Gestionar Ventas')
INSERT [dbo].[Grupos] ([Id_Grupo], [Descripcion]) VALUES (N'Administradores', N'Grupo de administracion de la seguridad')
INSERT [dbo].[Grupos] ([Id_Grupo], [Descripcion]) VALUES (N'Compras', N'Encargados de Compras a Proveedor')
INSERT [dbo].[Grupos] ([Id_Grupo], [Descripcion]) VALUES (N'Ventas', N'Encargado de Ventas a Clientes')
INSERT [dbo].[Grupos_Usuarios] ([Id_Usuario], [Id_Grupo]) VALUES (N'Admin', N'Administradores')
INSERT [dbo].[Grupos_Usuarios] ([Id_Usuario], [Id_Grupo]) VALUES (N'joni', N'Ventas')
INSERT [dbo].[Grupos_Usuarios] ([Id_Usuario], [Id_Grupo]) VALUES (N'matia', N'Compras')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Categorias', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'CategoriasP', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Clientes', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Envios', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'FormaEnvios', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'FormaPagos', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'MateriasPrimas', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'OrdenesCompras', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Pagos', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Productos', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Proveedores', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'RealizarOrden', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'RealizarRemito', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'RealizarVenta', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'RegistrarPago', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'RemitosProveedor', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Ventas', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Categorias', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'CategoriasP', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Clientes', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Envios', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'FormaEnvios', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'FormaPagos', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'MateriasPrimas', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'OrdenesCompras', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Productos', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Proveedores', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'RealizarOrden', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'RealizarRemito', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'RealizarVenta', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'RegistrarPago', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'RemitosProveedor', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'OrdenesCompras', N'Anular')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Pagos', N'Anular')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Ventas', N'Anular')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Categorias', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'CategoriasP', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Clientes', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Envios', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'FormaEnvios', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'FormaPagos', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'MateriasPrimas', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'OrdenesCompras', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Productos', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Proveedores', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'RealizarOrden', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'RealizarRemito', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'RemitosProveedor', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Categorias', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'CategoriasP', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Clientes', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Envios', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'FormaEnvios', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'FormaPagos', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'MateriasPrimas', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'OrdenesCompras', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Productos', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'Proveedores', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'RealizarOrden', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'RealizarRemito', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Administradores', N'RemitosProveedor', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'Categorias', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'MateriasPrimas', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'OrdenesCompras', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'Proveedores', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'RealizarOrden', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'RealizarRemito', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'RemitosProveedor', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'Categorias', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'MateriasPrimas', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'Proveedores', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'RealizarOrden', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'RealizarRemito', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'OrdenesCompras', N'Anular')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'RemitosProveedor', N'Anular')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'Categorias', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'MateriasPrimas', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'Proveedores', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'Categorias', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'MateriasPrimas', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Compras', N'Proveedores', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'CategoriasP', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'Clientes', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'Pagos', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'Productos', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'RealizarVenta', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'RegistrarPago', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'Ventas', N'Acceso')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'CategoriasP', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'Clientes', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'Productos', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'RealizarVenta', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'RegistrarPago', N'Agregar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'Pagos', N'Anular')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'Ventas', N'Anular')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'CategoriasP', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'Clientes', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'Productos', N'Eliminar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'CategoriasP', N'Modificar')
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'Clientes', N'Modificar')
GO
INSERT [dbo].[Perfiles] ([Id_Grupo], [Id_Formulario], [Id_Permiso]) VALUES (N'Ventas', N'Productos', N'Modificar')
INSERT [dbo].[Permisos] ([Id_Permiso], [Descripcion]) VALUES (N'Acceso', N'Brinda acceso a los formularios de gestión')
INSERT [dbo].[Permisos] ([Id_Permiso], [Descripcion]) VALUES (N'Agregar', N'Permite agregar registros nuevos')
INSERT [dbo].[Permisos] ([Id_Permiso], [Descripcion]) VALUES (N'Anular', N'Permite Anular un Registro existente')
INSERT [dbo].[Permisos] ([Id_Permiso], [Descripcion]) VALUES (N'Eliminar', N'Permite eliminar registros existentes')
INSERT [dbo].[Permisos] ([Id_Permiso], [Descripcion]) VALUES (N'Modificar', N'Permite modificar registros existentes')
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre_Apellido], [Email], [Habilitado], [Activo], [Clave]) VALUES (N'Admin', N'Administrador', N'matiaspena93@hotmail.com', 1, 0, 0x41403F3F3F3F583F3F3F3F713F3F3F401A781873403F6F633F3F573F3F3F3F3F3F653F3F3F4C352C3F353F3F3F3D054B763F3F3F49586E260A3F1C04633F1C3F)
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre_Apellido], [Email], [Habilitado], [Activo], [Clave]) VALUES (N'joni', N'Joni Barto', N'jonibarto@gmail.com', 1, 0, 0x41403F3F3F3F583F3F3F3F713F3F3F401A781873403F6F633F3F573F3F3F3F3F3F653F3F3F4C352C3F353F3F3F3D054B763F3F3F49586E260A3F1C04633F1C3F)
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre_Apellido], [Email], [Habilitado], [Activo], [Clave]) VALUES (N'matia', N'Fds', N'matias_lakd_989@hotmail.com', 1, 0, 0x41403F3F3F3F583F3F3F3F713F3F3F401A781873403F6F633F3F573F3F3F3F3F3F653F3F3F4C352C3F353F3F3F3D054B763F3F3F49586E260A3F1C04633F1C3F)
ALTER TABLE [dbo].[Grupos_Usuarios]  WITH CHECK ADD FOREIGN KEY([Id_Grupo])
REFERENCES [dbo].[Grupos] ([Id_Grupo])
GO
ALTER TABLE [dbo].[Grupos_Usuarios]  WITH CHECK ADD FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuarios] ([Id_Usuario])
GO
ALTER TABLE [dbo].[Perfiles]  WITH CHECK ADD FOREIGN KEY([Id_Formulario])
REFERENCES [dbo].[Formularios] ([Id_Formulario])
GO
ALTER TABLE [dbo].[Perfiles]  WITH CHECK ADD FOREIGN KEY([Id_Grupo])
REFERENCES [dbo].[Grupos] ([Id_Grupo])
GO
ALTER TABLE [dbo].[Perfiles]  WITH CHECK ADD FOREIGN KEY([Id_Permiso])
REFERENCES [dbo].[Permisos] ([Id_Permiso])
GO
USE [master]
GO
ALTER DATABASE [TrabajoFinalSec] SET  READ_WRITE 
GO
