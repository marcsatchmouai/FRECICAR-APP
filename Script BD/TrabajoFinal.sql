USE [master]
GO
/****** Object:  Database [TrabajoFinal]    Script Date: 05/02/2019 15:57:38 ******/
CREATE DATABASE [TrabajoFinal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TrabajoFinal', FILENAME = N'b:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\TrabajoFinal.ldf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TrabajoFinal_log', FILENAME = N'b:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\TrabajoFinal_log.ldf' , SIZE = 1344KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TrabajoFinal] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TrabajoFinal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TrabajoFinal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TrabajoFinal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TrabajoFinal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TrabajoFinal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TrabajoFinal] SET ARITHABORT OFF 
GO
ALTER DATABASE [TrabajoFinal] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TrabajoFinal] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TrabajoFinal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TrabajoFinal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TrabajoFinal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TrabajoFinal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TrabajoFinal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TrabajoFinal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TrabajoFinal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TrabajoFinal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TrabajoFinal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TrabajoFinal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TrabajoFinal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TrabajoFinal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TrabajoFinal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TrabajoFinal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TrabajoFinal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TrabajoFinal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TrabajoFinal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TrabajoFinal] SET  MULTI_USER 
GO
ALTER DATABASE [TrabajoFinal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TrabajoFinal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TrabajoFinal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TrabajoFinal] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [TrabajoFinal]
GO
/****** Object:  StoredProcedure [dbo].[SP_AddCategoria]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_AddCategoria](
@Descripcion nvarchar(30),
@Nombre nvarchar(45)
)
as begin
Insert into Categorias (Nombre,Descripcion)
Values(@Nombre,@Descripcion)
end


GO
/****** Object:  StoredProcedure [dbo].[SP_AddCategoriaProducto]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SP_AddCategoriaProducto]
(
@Nombre nvarchar(60),
@Descripcion nvarchar(120)
)
as begin
insert into CategoriasProductos (Nombre,Descripcion)
values (@Nombre,@Descripcion)
end


GO
/****** Object:  StoredProcedure [dbo].[SP_AddCliente]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_AddCliente]
(
@Cuit bigint,
@RazonSocial nvarchar(100),
@Direccion nvarchar(100),
@Email nvarchar(120),
@SituacionFiscal int,
@Telefono bigint,
@Provincia nvarchar(50),
@Localidad nvarchar(50)
)
as begin
declare @id_Provincia int = (Select Id_Provincia from Provincias where Provincias.NombreProvincia = @Provincia)
declare @id_Localidad int = (select Id_Localidad from Localidades where Localidades.NombreLocalidad = @Localidad and Localidades.Id_Provincia = @id_Provincia)
insert into Clientes (Cuit,Email,RazonSocial,Direccion,id_SituacionFiscal,Telefono,id_Localidad,Activo)
values(@Cuit,@Email,@RazonSocial,@Direccion,@SituacionFiscal,@Telefono,@id_Localidad,1)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_AddDetallePedido]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_AddDetallePedido](
@OrdenCompra int,
@Cantidad int,
@MateriaPrima int,
@SubTotal decimal,
@Faltante int
)
as begin
Declare @id_MateriaPrima int = (Select id_MPrima from MateriasPrimas where MateriasPrimas.CodigoMateriaPrima = @MateriaPrima)
insert into DetallesPedidos(Pedido,Cantidad,MateriaPrima,SubTotal,Faltante)
values (@OrdenCompra,@Cantidad,@id_MateriaPrima,@SubTotal,@Faltante)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_AddDetalleRemito]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_AddDetalleRemito](
@Cantidad int,
@Remito int,
@SubTotal Decimal,
@MateriaPrima int
)
as begin
Declare @id_MPrima int = (Select id_MPrima from MateriasPrimas where MateriasPrimas.CodigoMateriaPrima = @MateriaPrima)
insert into DetallesRemitos (Cantidad,Remito,SubTotal,MateriaPrima)
values (@Cantidad,@Remito,@SubTotal,@id_MPrima)
end

GO
/****** Object:  StoredProcedure [dbo].[SP_AddDetalleVenta]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_AddDetalleVenta]
(
  @id_Venta int,
  @CodigoProducto int,
  @Cantidad int,
  @SubTotal decimal
)
as begin
Declare @id_Producto int = (select id_Producto from Productos where Productos.id_Producto = @CodigoProducto)
Insert into DetallesVentas (id_Venta,id_Producto,SubTotal,Cantidad) Values
(@id_Venta,@id_Producto,@SubTotal,@Cantidad)
end


GO
/****** Object:  StoredProcedure [dbo].[SP_AddFEnvios]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_AddFEnvios](
@Nombre nvarchar(15),
@Descripcion nvarchar(30))
as begin
insert into FormasdeEnvios(Estado,Descripcion)
Values(@Nombre,@Descripcion)
end


GO
/****** Object:  StoredProcedure [dbo].[SP_AddFPago]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SP_AddFPago](
@Nombre nvarchar(30),
@Descripcion nvarchar(140))
as begin
insert into FormasdePagos(Nombre,Descripcion)
Values(@Nombre,@Descripcion)
end


GO
/****** Object:  StoredProcedure [dbo].[SP_AddMateriaPrima]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_AddMateriaPrima](
@CodigoMateriaPrima int,
@Descripcion nvarchar(110),
@Categoria nvarchar(45),
@Cantidad int,
@CostoUnitario Decimal,
@CantMin int,
@Proveedor bigint
)
as begin
Declare @id_Proveedor int = (Select id_Proveedor from Proveedores where Proveedores.Cuit = @Proveedor)
Declare @id_Categoria int = (Select id_Categoria from Categorias where Categorias.Nombre = @Categoria)
Insert into MateriasPrimas (CodigoMateriaPrima,Descripcion,Categoria,Cantidad,CostoUnitario,CantMin,Proveedor)
Values (@CodigoMateriaPrima,@Descripcion,@id_Categoria,@Cantidad,@CostoUnitario,@CantMin,@id_Proveedor)
end

GO
/****** Object:  StoredProcedure [dbo].[SP_AddNota]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_AddNota]
(
@Fecha Datetime,
@Importe Decimal,
@Detalle nvarchar(120),
@CodigoCliente int
)
as begin
Declare @id_Cliente int = (select id_Cliente from Clientes where id_Cliente = @CodigoCliente)
Insert into NotasCreditos(Fecha,Importe,Detalle,id_Cliente)
values(@Fecha,@Importe,@Detalle,@id_Cliente)
select SCOPE_IDENTITY()
end
GO
/****** Object:  StoredProcedure [dbo].[SP_AddPagos]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_AddPagos]
(
@Fecha Datetime,
@Importe Decimal,
@Detalle nvarchar(120),
@CodigoCliente int,
@CodigoVenta int
)
as begin
Declare @id_Cliente int = (select id_Cliente from Clientes where id_Cliente = @CodigoCliente)
Declare @id_Venta int = (Select id_Venta from Ventas where Ventas.id_Venta = @CodigoVenta)
Insert into Pagos (Fecha,Importe,Detalle,id_Cliente,id_Venta)
values(@Fecha,@Importe,@Detalle,@id_Cliente,@id_Venta)
select SCOPE_IDENTITY()
end
GO
/****** Object:  StoredProcedure [dbo].[SP_AddPedido]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_AddPedido](
@FormadeEnvio nvarchar(15),
@FormadePago nvarchar(30),
@Proveedor bigint,
@Total Decimal,
@Fecha datetime,
@Estado nvarchar(30),
@Operacion nvarchar(120),
@Usuario nvarchar(60),
@FechaOperacion datetime,
@Equipo nvarchar(20)
)
as begin
Declare @id_FormaEnvio int = (Select id_FormadeEnvio from FormasdeEnvios where FormasdeEnvios.Estado = @FormadeEnvio)
Declare @id_FormaPago int = (Select id_FormadePago from FormasdePagos where FormasdePagos.Nombre = @FormadePago)
Declare @id_Proveedor int = (Select id_Proveedor from Proveedores where Proveedores.Cuit = @Proveedor)
Insert into Pedidos(FormadeEnvio,FormadePago,Proveedor,Total,Fecha,Estado,Operacion,Usuario,FechaOperacion,EQUIPO)
Values(@id_FormaEnvio,@id_FormaPago,@id_Proveedor,@Total,@Fecha,@Estado,@Operacion,@Usuario,@FechaOperacion,@Equipo)
select SCOPE_IDENTITY()
end
GO
/****** Object:  StoredProcedure [dbo].[SP_AddProducto]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_AddProducto]
(
@Cantidad int,
@CantMin int,
@Descripcion nvarchar(120),
@CostoUnitario Decimal(18,2),
@Categoria nvarchar(60)
)
as begin
declare @id_Categoria int = (select id_Categoria from CategoriasProductos where CategoriasProductos.Nombre = @Categoria)
insert into Productos (Descripcion,CostoUnitario,id_Categoria,Cantidad,CantMin)
Values (@Descripcion,@CostoUnitario,@id_Categoria,@Cantidad,@CantMin)
end


GO
/****** Object:  StoredProcedure [dbo].[SP_AddProveedor]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_AddProveedor](
@Nombre nvarchar(50),
@Cuit Bigint,
@Telefono nvarchar(32),
@Direccion_N nvarchar(10),
@Direccion_C nvarchar(45),
@Email nvarchar(120))
as begin
Insert into Proveedores (Cuit,Nombre,Telefono,Direccion_N,Direccion_C,Email)
Values (@Cuit,@Nombre,@Telefono,@Direccion_N,@Direccion_C,@Email)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_AddRemito]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_AddRemito](
@Proveedor bigint,
@Fecha datetime,
@Total decimal,
@NumeroOrdenC int
)
as begin
Declare @id_Proveedor int = (select id_Proveedor from Proveedores where Proveedores.Cuit = @Proveedor)
insert into Remitos(Proveedor,Fecha,Total,NumeroOrdenC)
values(@id_Proveedor,@Fecha,@Total,@NumeroOrdenC)
select SCOPE_IDENTITY()
end
GO
/****** Object:  StoredProcedure [dbo].[SP_AddVenta]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_AddVenta]
(
@Detalle nvarchar(120),
@FormadePago nvarchar(30),
@Cuit BigInt,
@Fecha datetime,
@Total decimal,
@Estado nvarchar(12),
@FormadeEnvio nvarchar(15)
)
as begin
Declare @id_Cliente int = (select id_Cliente from Clientes where Clientes.Cuit = @Cuit)
Declare @id_Envio int = (select id_FormadeEnvio from FormasdeEnvios where FormasdeEnvios.Estado = @FormadeEnvio)
Declare @id_FPago int = (select id_FormadePago from FormasdePagos where FormasdePagos.Nombre = @FormadePago)
insert into Ventas (id_Cliente,Fecha,Total,Estado,id_FormaEnvio,id_FormadePago,Detalle) 
Values (@id_Cliente,@Fecha,@Total,@Estado,@id_Envio,@id_FPago,@Detalle)
select SCOPE_IDENTITY()
end
GO
/****** Object:  StoredProcedure [dbo].[SP_FindDetalleRemito]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_FindDetalleRemito](@NumeroRemito int)
as begin
Select DetallesRemitos.Cantidad,MateriasPrimas.CodigoMateriaPrima,DetallesRemitos.Remito,DetallesRemitos.SubTotal from DetallesRemitos
inner join MateriasPrimas on MateriasPrimas.id_MPrima = DetallesRemitos.MateriaPrima
where DetallesRemitos.Remito = @NumeroRemito
end


------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------Procedimientos Almacenados Formas de Envio------------------------------------
------------------------------------------------------------------------------------------------------------------------------
GO
/****** Object:  StoredProcedure [dbo].[SP_FindDetalles]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_FindDetalles](@id_OrdenCompra int)
as begin
Select DetallesPedidos.Cantidad,DetallesPedidos.SubTotal,MateriasPrimas.CodigoMateriaPrima as 'MateriaPrima',DetallesPedidos.Faltante from DetallesPedidos
inner join MateriasPrimas on MateriasPrimas.id_MPrima = DetallesPedidos.MateriaPrima
where DetallesPedidos.Pedido = @id_OrdenCompra
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ListCategorias]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SP_ListCategorias]
as begin
Select Categorias.Nombre, Categorias.Descripcion from Categorias
end

------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------Procedimientos Almacenados MateriasPrimas-------------------------------------
------------------------------------------------------------------------------------------------------------------------------


GO
/****** Object:  StoredProcedure [dbo].[SP_ListCategoriasProductos]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[SP_ListCategoriasProductos]
as begin
select CategoriasProductos.Nombre , CategoriasProductos.Descripcion from CategoriasProductos
end

--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------Procedimientos Almacenados Producto----------------------------------------
--------------------------------------------------------------------------------------------------------------------------

GO
/****** Object:  StoredProcedure [dbo].[SP_ListClientes]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_ListClientes]
as begin
Select Clientes.id_Cliente ,Clientes.Email, Clientes.Cuit , Clientes.Direccion , Localidades.NombreLocalidad , Clientes.id_SituacionFiscal as 'SituacionFiscal' , Clientes.RazonSocial , Clientes.Telefono , Provincias.NombreProvincia
From Clientes
inner join SituacionesFiscales on SituacionesFiscales.id_SituacionFiscal = Clientes.id_SituacionFiscal
inner join Localidades on Localidades.Id_Localidad = Clientes.id_Localidad
inner join Provincias on Provincias.Id_Provincia = Localidades.Id_Provincia
end

--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------


GO
/****** Object:  StoredProcedure [dbo].[SP_ListClientesActivos]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_ListClientesActivos]
as begin
Select Clientes.id_Cliente ,Clientes.Email, Clientes.Cuit , Clientes.Direccion , Localidades.NombreLocalidad , Clientes.id_SituacionFiscal as 'SituacionFiscal' , Clientes.RazonSocial , Clientes.Telefono , Provincias.NombreProvincia
From Clientes
inner join SituacionesFiscales on SituacionesFiscales.id_SituacionFiscal = Clientes.id_SituacionFiscal
inner join Localidades on Localidades.Id_Localidad = Clientes.id_Localidad
inner join Provincias on Provincias.Id_Provincia = Localidades.Id_Provincia
where Clientes.Activo = 1
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ListDetallesVentas]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_ListDetallesVentas] (@id_Venta int)
as begin
Select DetallesVentas.Cantidad , DetallesVentas.SubTotal , Productos.id_Producto from DetallesVentas
inner join Productos on Productos.id_Producto = DetallesVentas.id_Producto
where id_Venta = @id_Venta
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ListFEnvio]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_ListFEnvio]
as begin
Select FormasdeEnvios.Descripcion, FormasdeEnvios.Estado as 'Nombre' from FormasdeEnvios
end

GO
/****** Object:  StoredProcedure [dbo].[SP_ListFPago]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_ListFPago]
as begin
Select FormasdePagos.Descripcion , FormasdePagos.Nombre from FormasdePagos
end

------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------Procedimientos Almacenados Pedidos--------------------------------------------
------------------------------------------------------------------------------------------------------------------------------


GO
/****** Object:  StoredProcedure [dbo].[SP_ListLocalidades]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_ListLocalidades]
as begin
Select Localidades.NombreLocalidad from Localidades
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ListLocalidadesProvincias]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ListLocalidadesProvincias] @Id_Provincia int
as begin
select Localidades.NombreLocalidad from Localidades where Localidades.Id_Provincia = @Id_Provincia
end

GO
/****** Object:  StoredProcedure [dbo].[SP_ListMateriaPrima]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_ListMateriaPrima]
as begin
select MateriasPrimas.Cantidad,MateriasPrimas.CantMin,MateriasPrimas.CodigoMateriaPrima,MateriasPrimas.CostoUnitario,
MateriasPrimas.Descripcion, Categorias.Nombre , Proveedores.Cuit as 'Proveedor' from MateriasPrimas
inner join Proveedores on Proveedores.id_Proveedor = MateriasPrimas.Proveedor
inner join Categorias on Categorias.id_Categoria = MateriasPrimas.Categoria
end

GO
/****** Object:  StoredProcedure [dbo].[SP_ListPedido]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_ListPedido]
as Begin
Select pedidos.id_Pedido, Pedidos.Fecha,FormasdeEnvios.Estado as 'FormaEnvio',FormasdePagos.Nombre as'FormaPago',Proveedores.Cuit as 'Proveedor'
,Pedidos.Total, Pedidos.Estado,Pedidos.Operacion,Pedidos.Usuario,Pedidos.FechaOperacion from Pedidos
inner join FormasdeEnvios on FormasdeEnvios.id_FormadeEnvio = Pedidos.FormadeEnvio
inner join FormasdePagos on FormasdePagos.id_FormadePago = Pedidos.FormadePago
inner join Proveedores on Proveedores.id_Proveedor = Pedidos.Proveedor
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ListProductos]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[SP_ListProductos]
as begin
select Productos.id_Producto , Productos.Descripcion , Productos.CostoUnitario , CategoriasProductos.Nombre, Productos.Cantidad , Productos.CantMin from Productos
inner join CategoriasProductos on CategoriasProductos.id_Categoria = Productos.id_Categoria
end

--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------Procedimientos Venta---------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------


GO
/****** Object:  StoredProcedure [dbo].[SP_ListProveedores]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_ListProveedores]
as begin
Select  Email,Cuit,Nombre,Telefono,Direccion_C,Direccion_N from Proveedores
end

GO
/****** Object:  StoredProcedure [dbo].[SP_ListProvincias]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[SP_ListProvincias]
as begin
Select Provincias.Id_Provincia ,Provincias.NombreProvincia from Provincias
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ListRemitos]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_ListRemitos]
as begin
Select Remitos.id_Remito,Remitos.Fecha,Proveedores.Cuit,Remitos.Total,Remitos.NumeroOrdenC from Remitos
inner join Proveedores on Proveedores.id_Proveedor = Remitos.Proveedor
end

GO
/****** Object:  StoredProcedure [dbo].[SP_ListSituacionesFiscales]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_ListSituacionesFiscales]
as begin
select SituacionesFiscales.id_SituacionFiscal , SituacionesFiscales.Descripcion from SituacionesFiscales
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ListVentas]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_ListVentas]
as begin
Select Ventas.id_Venta, Clientes.Cuit as 'Cliente', FormasdeEnvios.Estado as 'FormaEnvio', FormasdePagos.Nombre as 'FormaPago' , Ventas.Estado , Ventas.Total , Ventas.Fecha, Ventas.Detalle from Ventas
inner join Clientes on Clientes.id_Cliente = Ventas.id_Cliente
inner join FormasdeEnvios on FormasdeEnvios.id_FormadeEnvio = Ventas.id_FormaEnvio
inner join FormasdePagos on FormasdePagos.id_FormadePago = Ventas.id_FormadePago
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ModCategoria]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_ModCategoria](
@Descripcion nvarchar(30),
@Nombre nvarchar(45)
)
as begin
Update Categorias set Descripcion = @Descripcion
where Nombre = @Nombre
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ModCategoriaProducto]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SP_ModCategoriaProducto]
(
@Nombre nvarchar(60),
@Descripcion nvarchar(120)
)
as begin
update CategoriasProductos set Descripcion = @Descripcion where Nombre = @Nombre
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ModCliente]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_ModCliente]
(
@Codigo int,
@Cuit bigint,
@RazonSocial nvarchar(100),
@Direccion nvarchar(100),
@Email nvarchar(120),
@SituacionFiscal int,
@Telefono bigint,
@Provincia nvarchar(50),
@Localidad nvarchar(50)
)
as begin
declare @id_Provincia int = (Select Id_Provincia from Provincias where Provincias.NombreProvincia = @Provincia)
declare @id_Localidad int = (select Id_Localidad from Localidades where Localidades.NombreLocalidad = @Localidad and Localidades.Id_Provincia = @id_Provincia)
update Clientes set Cuit = @Cuit , RazonSocial = @RazonSocial , Direccion = @Direccion , id_SituacionFiscal = @SituacionFiscal , Telefono = @Telefono, id_Localidad = @id_Localidad
where id_Cliente = @Codigo
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ModFEnvio]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_ModFEnvio](
@Nombre nvarchar(15),
@Descripcion nvarchar(30))
as begin
update FormasdeEnvios set Descripcion = @Descripcion , Estado = @Nombre
where Estado = @Nombre
end

GO
/****** Object:  StoredProcedure [dbo].[SP_ModFPago]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SP_ModFPago](
@Nombre nvarchar(30),
@Descripcion nvarchar(140))
as begin
update FormasdePagos set Nombre=@Nombre,Descripcion=@Descripcion where Nombre = @Nombre
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ModMateriaPrima]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_ModMateriaPrima](
@CodigoMPrima int,
@Descripcion nvarchar(110),
@Categoria nvarchar(45),
@Cantidad int,
@CostoUnitario Decimal,
@CantMin int,
@Proveedor bigint
)
as begin
Declare @id_Proveedor int = (Select id_Proveedor from Proveedores where Proveedores.Cuit = @Proveedor)
Declare @id_Categoria int = (Select id_Categoria from Categorias where Categorias.Nombre = @Categoria)
Update MateriasPrimas set Descripcion = @Descripcion, Categoria = @id_Categoria, Cantidad = @Cantidad, 
CostoUnitario=@CostoUnitario,CodigoMateriaPrima = @CodigoMPrima, CantMin = @CantMin, Proveedor = @id_Proveedor where CodigoMateriaPrima = @CodigoMPrima
end

GO
/****** Object:  StoredProcedure [dbo].[SP_ModPedido]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_ModPedido](
@OrdenCompra int,
@FormadeEnvio nvarchar(15),
@FormadePago nvarchar(30),
@Proveedor bigint,
@Total Decimal,
@Fecha datetime,
@Estado nvarchar(30),
@Operacion nvarchar(120),
@Usuario nvarchar(60),
@FechaOperacion datetime,
@Equipo nvarchar(20)
)
as begin
Declare @id_FormaEnvio int = (Select id_FormadeEnvio from FormasdeEnvios where FormasdeEnvios.Estado = @FormadeEnvio)
Declare @id_FormaPago int = (Select id_FormadePago from FormasdePagos where FormasdePagos.Nombre = @FormadePago)
Declare @id_Proveedor int = (Select id_Proveedor from Proveedores where Proveedores.Cuit = @Proveedor)
update Pedidos set FormadeEnvio = @id_FormaEnvio , FormadePago = @id_FormaPago , Proveedor = @id_Proveedor,Estado = @Estado,
Total=@Total,Fecha = @Fecha, Operacion = @Operacion , Usuario = @Usuario, FechaOperacion = @FechaOperacion, EQUIPO = @Equipo where id_Pedido = @OrdenCompra
Delete DetallesPedidos where DetallesPedidos.Pedido = @OrdenCompra
end

GO
/****** Object:  StoredProcedure [dbo].[SP_ModProducto]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_ModProducto]
(
@Codigo int,
@Cantidad int,
@CantMin int,
@Descripcion nvarchar(120),
@CostoUnitario Decimal(18,2),
@Categoria nvarchar(60)
)
as begin
declare @id_Categoria int = (select id_Categoria from CategoriasProductos where CategoriasProductos.Nombre = @Categoria)
update Productos set Descripcion =@Descripcion , CostoUnitario = @CostoUnitario , id_Categoria = @id_Categoria, Cantidad = @Cantidad , CantMin = @CantMin where id_Producto = @Codigo
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ModProveedor]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_ModProveedor](
@Cuit bigint,
@Nombre nvarchar(50),
@Telefono nvarchar(32),
@Direccion_N nvarchar(10),
@Direccion_C nvarchar(45),
@Email nvarchar(120)
)
as begin
Update Proveedores set Nombre=@Nombre, Telefono=@Telefono , Direccion_N=@Direccion_N, Direccion_C=@Direccion_C , Email = @Email
Where Cuit = @Cuit
end

GO
/****** Object:  StoredProcedure [dbo].[SP_ModRemito]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SP_ModRemito](
@NumeroRemito int,
@Proveedor int,
@Fecha datetime,
@Total decimal)
as begin
update Remitos set Proveedor=@Proveedor,Fecha=@Fecha,Total = @Total
where id_Remito = @NumeroRemito
delete DetallesRemitos where DetallesRemitos.Remito = @NumeroRemito
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ModVenta]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_ModVenta]
(
@Detalle nvarchar(120),
@CodigoVenta int,
@FormadePago nvarchar(30),
@Cuit BigInt,
@Fecha datetime,
@Total decimal,
@Estado nvarchar(12),
@FormadeEnvio nvarchar(15)
)
as begin
Declare @id_Cliente int = (select id_Cliente from Clientes where Clientes.Cuit = @Cuit)
Declare @id_Envio int = (select id_FormadeEnvio from FormasdeEnvios where FormasdeEnvios.Estado = @FormadeEnvio)
Declare @id_FPago int = (select id_FormadePago from FormasdePagos where FormasdePagos.Nombre = @FormadePago)
update Ventas set Detalle = @Detalle ,id_Cliente = @id_Cliente , Fecha = @Fecha , Total = @Total , Estado = @Estado , id_FormaEnvio = @id_Envio, id_FormadePago=@id_FPago where id_Venta = @CodigoVenta
Delete DetallesVentas where DetallesVentas.id_Venta = @CodigoVenta
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RecuperarCuentasCorrientes]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[SP_RecuperarCuentasCorrientes]
as begin
Select id_CuentaCorriente,id_Cliente,Saldo from CuentasCorrientes
end


GO
/****** Object:  StoredProcedure [dbo].[SP_RecuperarMovimientos]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_RecuperarMovimientos] (@NumeroCuentaCorriente int)
as begin
Select Detalle,Importe,Fecha,TipodeMovimiento from Movimientos where id_CuentaCorriente = @NumeroCuentaCorriente
end

GO
/****** Object:  StoredProcedure [dbo].[SP_RecuperarNotas]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_RecuperarNotas]
as begin
Select Fecha,Importe,Detalle,id_Cliente,id_NotaCredito from NotasCreditos
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RecuperarPagos]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[SP_RecuperarPagos]
as begin
Select Fecha,Importe,Detalle,id_Cliente,id_Pago,id_Venta from Pagos
end
GO
/****** Object:  StoredProcedure [dbo].[sp_RecuperarProvincias]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_RecuperarProvincias]
as begin
select Provincias.Id_Provincia, Provincias.NombreProvincia from Provincias
end

GO
/****** Object:  StoredProcedure [dbo].[SP_RemoveCategoria]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SP_RemoveCategoria](@Nombre nvarchar(45))
as begin
Delete Categorias where Nombre = @Nombre
end


GO
/****** Object:  StoredProcedure [dbo].[SP_RemoveCategoriaProducto]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SP_RemoveCategoriaProducto] (@Nombre nvarchar(60))
as begin
delete CategoriasProductos where Nombre = @Nombre
end


GO
/****** Object:  StoredProcedure [dbo].[SP_RemoveCliente]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_RemoveCliente](@Codigo int)
as begin
Update Clientes set Activo = 0 where id_Cliente = @Codigo
end


GO
/****** Object:  StoredProcedure [dbo].[SP_RemoveDetalleVenta]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[SP_RemoveDetalleVenta] (@id_Venta int)
as begin
delete DetallesVentas where DetallesVentas.id_Venta = @id_Venta
end


GO
/****** Object:  StoredProcedure [dbo].[SP_RemoveFEnvio]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SP_RemoveFEnvio](@Nombre nvarchar(15))
as begin
delete FormasdeEnvios where Estado = @Nombre
end


GO
/****** Object:  StoredProcedure [dbo].[SP_RemoveFPago]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_RemoveFPago](@Nombre Nvarchar(30))
as begin
delete FormasdePagos where Nombre = @Nombre
end


GO
/****** Object:  StoredProcedure [dbo].[SP_RemoveMateriaPrima]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_RemoveMateriaPrima](@CodigoMateriaPrima int)
as begin
Delete MateriasPrimas where CodigoMateriaPrima = @CodigoMateriaPrima
end


GO
/****** Object:  StoredProcedure [dbo].[SP_RemovePedido]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SP_RemovePedido](@NumeroPedido int)
as begin
delete DetallesPedidos where DetallesPedidos.Pedido = @NumeroPedido
delete Pedidos where id_pedido = @NumeroPedido
end


GO
/****** Object:  StoredProcedure [dbo].[SP_RemoveProducto]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_RemoveProducto] (@codigo int)
as begin
delete Productos where id_Producto = @Codigo
end


GO
/****** Object:  StoredProcedure [dbo].[SP_RemoveProveedor]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_RemoveProveedor](@Cuit bigint)
as begin
Delete Proveedores where Cuit = @Cuit
end


GO
/****** Object:  StoredProcedure [dbo].[SP_RemoveRemito]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SP_RemoveRemito](@NumeroRemito int)
as begin
delete Remitos where id_Remito = @NumeroRemito
end


GO
/****** Object:  StoredProcedure [dbo].[SP_RemoveVenta]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_RemoveVenta](@CodigoVenta int)
as begin
delete Ventas where Ventas.id_Venta = @CodigoVenta
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ReporteMateriasPrimas]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_ReporteMateriasPrimas](@FechaDesde Datetime,@FechaHasta Datetime)
as begin
select MateriasPrimas.Descripcion as 'MPrima',Proveedores.Nombre as 'Proveedor',sum(detallespedidos.cantidad) as 'Cantidad' 
from MateriasPrimas 
inner join DetallesPedidos on MateriasPrimas.id_MPrima = DetallesPedidos.MateriaPrima 
inner join Proveedores on MateriasPrimas.Proveedor = Proveedores.id_Proveedor
inner Join Pedidos on Pedidos.id_Pedido = DetallesPedidos.Pedido
where  Pedidos.Estado = 'Finalizado' and Pedidos.Fecha between @FechaDesde and @FechaHasta
group by MateriasPrimas.Descripcion,Proveedores.Nombre
order by sum(detallespedidos.cantidad) desc
end

GO
/****** Object:  StoredProcedure [dbo].[SP_ReporteVentas]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_ReporteVentas](@FechaDesde Datetime,@FechaHasta Datetime)
as begin
Select Clientes.RazonSocial as 'Cliente', Productos.Descripcion as 'Producto', SUM(DetallesVentas.Cantidad) as 'Cantidad'  from DetallesVentas
inner join Productos on Productos.id_Producto = DetallesVentas.id_Producto
inner join Ventas on Ventas.id_Venta = DetallesVentas.id_Venta
inner join Clientes on Clientes.id_Cliente = Ventas.id_Cliente
where  Ventas.Estado = 'Finalizado' and Ventas.Fecha between @FechaDesde and @FechaHasta
Group by Clientes.RazonSocial,Productos.Descripcion
Order by SUM(DetallesVentas.Cantidad)
end
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 05/02/2019 15:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[id_Categoria] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](30) NOT NULL,
	[Nombre] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_Categorias_id_Categoria] PRIMARY KEY CLUSTERED 
(
	[id_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CategoriasProductos]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriasProductos](
	[id_Categoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](60) NOT NULL,
	[Descripcion] [nvarchar](120) NOT NULL,
 CONSTRAINT [PK_CategoriasProductos_id_Categoria] PRIMARY KEY CLUSTERED 
(
	[id_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Cuit] [bigint] NOT NULL,
	[RazonSocial] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[id_SituacionFiscal] [int] NOT NULL,
	[Telefono] [bigint] NOT NULL,
	[id_Localidad] [int] NOT NULL,
	[Email] [nvarchar](120) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Clientes_id_Cliente] PRIMARY KEY CLUSTERED 
(
	[id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CuentasCorrientes]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentasCorrientes](
	[id_CuentaCorriente] [int] IDENTITY(1,1) NOT NULL,
	[id_Cliente] [int] NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_CuentasCorrientes_id_CuentaCorriente] PRIMARY KEY CLUSTERED 
(
	[id_CuentaCorriente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetallesPedidos]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesPedidos](
	[id_DetallePedido] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[MateriaPrima] [int] NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[Pedido] [int] NOT NULL,
	[Faltante] [int] NOT NULL,
 CONSTRAINT [PK_DetallesPedidos_id_DetallePedido] PRIMARY KEY CLUSTERED 
(
	[id_DetallePedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetallesRemitos]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesRemitos](
	[id_DetalleRemito] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Remito] [int] NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[MateriaPrima] [int] NOT NULL,
 CONSTRAINT [PK_DetallesRemitos_id_DetalleRemito] PRIMARY KEY CLUSTERED 
(
	[id_DetalleRemito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetallesVentas]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesVentas](
	[id_DetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[id_Venta] [int] NOT NULL,
	[id_Producto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_DetallesVentas_id_DetalleVenta] PRIMARY KEY CLUSTERED 
(
	[id_DetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FormasdeEnvios]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormasdeEnvios](
	[id_FormadeEnvio] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [nvarchar](15) NOT NULL,
	[Descripcion] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_FormasdeEnvios_id_FormadeEnvio] PRIMARY KEY CLUSTERED 
(
	[id_FormadeEnvio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FormasdePagos]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormasdePagos](
	[id_FormadePago] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](30) NOT NULL,
	[Descripcion] [nvarchar](140) NOT NULL,
 CONSTRAINT [PK_FormasdePagos_id_FormadePago] PRIMARY KEY CLUSTERED 
(
	[id_FormadePago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidades](
	[Id_Localidad] [int] IDENTITY(1,1) NOT NULL,
	[NombreLocalidad] [nvarchar](50) NOT NULL,
	[Id_Provincia] [int] NOT NULL,
 CONSTRAINT [PK_IDLocalidad] PRIMARY KEY CLUSTERED 
(
	[Id_Localidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MateriasPrimas]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MateriasPrimas](
	[id_MPrima] [int] IDENTITY(1,1) NOT NULL,
	[CodigoMateriaPrima] [int] NOT NULL,
	[Descripcion] [nvarchar](110) NOT NULL,
	[Categoria] [int] NOT NULL,
	[Proveedor] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[CostoUnitario] [decimal](18, 2) NOT NULL,
	[CantMin] [int] NOT NULL,
 CONSTRAINT [PK_MateriasPrimas_id_MPrima] PRIMARY KEY CLUSTERED 
(
	[id_MPrima] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[id_Movimiento] [int] IDENTITY(1,1) NOT NULL,
	[Detalle] [nvarchar](120) NOT NULL,
	[Importe] [decimal](18, 2) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[id_CuentaCorriente] [int] NOT NULL,
	[TipodeMovimiento] [nvarchar](12) NULL,
 CONSTRAINT [PK_Movimientos_id_Movimiento] PRIMARY KEY CLUSTERED 
(
	[id_Movimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NotasCreditos]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotasCreditos](
	[id_NotaCredito] [int] IDENTITY(1,1) NOT NULL,
	[id_Cliente] [int] NOT NULL,
	[Detalle] [nvarchar](120) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Importe] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_NotasCreditos_id_NotaCredito] PRIMARY KEY CLUSTERED 
(
	[id_NotaCredito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pagos]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagos](
	[id_Pago] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Importe] [decimal](18, 2) NOT NULL,
	[id_Cliente] [int] NOT NULL,
	[Detalle] [nvarchar](120) NOT NULL,
	[id_Venta] [int] NULL,
 CONSTRAINT [PK_Pagos_id_Pago] PRIMARY KEY CLUSTERED 
(
	[id_Pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[id_Pedido] [int] IDENTITY(1,1) NOT NULL,
	[FormadeEnvio] [int] NOT NULL,
	[FormadePago] [int] NOT NULL,
	[Proveedor] [int] NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Estado] [nvarchar](30) NULL,
	[Usuario] [nvarchar](60) NULL,
	[Operacion] [nvarchar](120) NULL,
	[FechaOperacion] [datetime] NULL,
	[EQUIPO] [nvarchar](20) NULL,
 CONSTRAINT [PK_Pedidos_id_Pedidos] PRIMARY KEY CLUSTERED 
(
	[id_Pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Productos]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](120) NOT NULL,
	[CostoUnitario] [decimal](18, 2) NOT NULL,
	[id_Categoria] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[CantMin] [int] NOT NULL,
 CONSTRAINT [PK_Productos_id_Producto] PRIMARY KEY CLUSTERED 
(
	[id_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[id_Proveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](32) NOT NULL,
	[Cuit] [bigint] NOT NULL,
	[Email] [nvarchar](120) NOT NULL,
	[Direccion_N] [nvarchar](10) NOT NULL,
	[Direccion_C] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_Proveedores_id_Proveedor] PRIMARY KEY CLUSTERED 
(
	[id_Proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincias](
	[Id_Provincia] [int] NOT NULL,
	[NombreProvincia] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_IDProvincia] PRIMARY KEY CLUSTERED 
(
	[Id_Provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Remitos]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Remitos](
	[id_Remito] [int] IDENTITY(1,1) NOT NULL,
	[Proveedor] [int] NULL,
	[Fecha] [datetime] NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[NumeroOrdenC] [int] NULL,
 CONSTRAINT [PK_Remitos_id_Remito] PRIMARY KEY CLUSTERED 
(
	[id_Remito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SituacionesFiscales]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SituacionesFiscales](
	[id_SituacionFiscal] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](120) NOT NULL,
 CONSTRAINT [PK_SituacionesFiscales_id_SituacionFiscal] PRIMARY KEY CLUSTERED 
(
	[id_SituacionFiscal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 05/02/2019 15:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[id_Venta] [int] IDENTITY(1,1) NOT NULL,
	[id_Cliente] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Estado] [nvarchar](12) NOT NULL,
	[id_FormaEnvio] [int] NOT NULL,
	[id_FormadePago] [int] NOT NULL,
	[Detalle] [nvarchar](120) NOT NULL,
 CONSTRAINT [PK_Ventas_id_Venta] PRIMARY KEY CLUSTERED 
(
	[id_Venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([id_Categoria], [Descripcion], [Nombre]) VALUES (9, N'Poliestireno Cristal', N'GPPS')
INSERT [dbo].[Categorias] ([id_Categoria], [Descripcion], [Nombre]) VALUES (10, N'Poliestireno de Alto Impacto', N'HIPS')
INSERT [dbo].[Categorias] ([id_Categoria], [Descripcion], [Nombre]) VALUES (13, N'Sin Categoria', N'SC')
INSERT [dbo].[Categorias] ([id_Categoria], [Descripcion], [Nombre]) VALUES (14, N'Master Cyan', N'MC')
INSERT [dbo].[Categorias] ([id_Categoria], [Descripcion], [Nombre]) VALUES (15, N'Master Magenta', N'MM')
INSERT [dbo].[Categorias] ([id_Categoria], [Descripcion], [Nombre]) VALUES (16, N'Master Yellow', N'MY')
INSERT [dbo].[Categorias] ([id_Categoria], [Descripcion], [Nombre]) VALUES (17, N'Master Black', N'MB')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
SET IDENTITY_INSERT [dbo].[CategoriasProductos] ON 

INSERT [dbo].[CategoriasProductos] ([id_Categoria], [Nombre], [Descripcion]) VALUES (5, N'SC', N'Sin Categoria')
INSERT [dbo].[CategoriasProductos] ([id_Categoria], [Nombre], [Descripcion]) VALUES (6, N'V50', N'Vasos de 50 mm')
INSERT [dbo].[CategoriasProductos] ([id_Categoria], [Nombre], [Descripcion]) VALUES (7, N'V35', N'Vasos de 30 mm')
SET IDENTITY_INSERT [dbo].[CategoriasProductos] OFF
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([id_Cliente], [Cuit], [RazonSocial], [Direccion], [id_SituacionFiscal], [Telefono], [id_Localidad], [Email], [Activo]) VALUES (7, 25123454322, N'Grido', N'Ovidio Lagos 512', 4, 3411235465, 3994, N'GridoHelados@Hotmail.com', 1)
INSERT [dbo].[Clientes] ([id_Cliente], [Cuit], [RazonSocial], [Direccion], [id_SituacionFiscal], [Telefono], [id_Localidad], [Email], [Activo]) VALUES (8, 24567899875, N'Sancor', N'Colectora 57 1256', 3, 2342556452, 2582, N'Sancor@hotmail.com', 1)
INSERT [dbo].[Clientes] ([id_Cliente], [Cuit], [RazonSocial], [Direccion], [id_SituacionFiscal], [Telefono], [id_Localidad], [Email], [Activo]) VALUES (9, 25123536742, N'La Serenisima', N'Camino Rawson 3456', 4, 3633367236, 3414, N'LaSerenisima@hotmail.com', 1)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
SET IDENTITY_INSERT [dbo].[CuentasCorrientes] ON 

INSERT [dbo].[CuentasCorrientes] ([id_CuentaCorriente], [id_Cliente], [Saldo]) VALUES (5, 7, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[CuentasCorrientes] ([id_CuentaCorriente], [id_Cliente], [Saldo]) VALUES (6, 8, CAST(-264.00 AS Decimal(18, 2)))
INSERT [dbo].[CuentasCorrientes] ([id_CuentaCorriente], [id_Cliente], [Saldo]) VALUES (7, 9, CAST(-1770.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[CuentasCorrientes] OFF
SET IDENTITY_INSERT [dbo].[DetallesPedidos] ON 

INSERT [dbo].[DetallesPedidos] ([id_DetallePedido], [Cantidad], [MateriaPrima], [SubTotal], [Pedido], [Faltante]) VALUES (28, 14, 12, CAST(1680.00 AS Decimal(18, 2)), 21, 0)
INSERT [dbo].[DetallesPedidos] ([id_DetallePedido], [Cantidad], [MateriaPrima], [SubTotal], [Pedido], [Faltante]) VALUES (29, 300, 9, CAST(60096.00 AS Decimal(18, 2)), 22, 0)
INSERT [dbo].[DetallesPedidos] ([id_DetallePedido], [Cantidad], [MateriaPrima], [SubTotal], [Pedido], [Faltante]) VALUES (30, 400, 6, CAST(76640.00 AS Decimal(18, 2)), 22, 0)
INSERT [dbo].[DetallesPedidos] ([id_DetallePedido], [Cantidad], [MateriaPrima], [SubTotal], [Pedido], [Faltante]) VALUES (31, 150, 10, CAST(27233.00 AS Decimal(18, 2)), 22, 0)
INSERT [dbo].[DetallesPedidos] ([id_DetallePedido], [Cantidad], [MateriaPrima], [SubTotal], [Pedido], [Faltante]) VALUES (32, 150, 7, CAST(14955.00 AS Decimal(18, 2)), 23, 0)
SET IDENTITY_INSERT [dbo].[DetallesPedidos] OFF
SET IDENTITY_INSERT [dbo].[DetallesRemitos] ON 

INSERT [dbo].[DetallesRemitos] ([id_DetalleRemito], [Cantidad], [Remito], [SubTotal], [MateriaPrima]) VALUES (10, 14, 1032, CAST(1680.00 AS Decimal(18, 2)), 12)
INSERT [dbo].[DetallesRemitos] ([id_DetalleRemito], [Cantidad], [Remito], [SubTotal], [MateriaPrima]) VALUES (11, 300, 1033, CAST(60096.00 AS Decimal(18, 2)), 9)
INSERT [dbo].[DetallesRemitos] ([id_DetalleRemito], [Cantidad], [Remito], [SubTotal], [MateriaPrima]) VALUES (12, 400, 1033, CAST(76640.00 AS Decimal(18, 2)), 6)
INSERT [dbo].[DetallesRemitos] ([id_DetalleRemito], [Cantidad], [Remito], [SubTotal], [MateriaPrima]) VALUES (13, 150, 1033, CAST(27233.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[DetallesRemitos] ([id_DetalleRemito], [Cantidad], [Remito], [SubTotal], [MateriaPrima]) VALUES (14, 150, 1034, CAST(14955.00 AS Decimal(18, 2)), 7)
SET IDENTITY_INSERT [dbo].[DetallesRemitos] OFF
SET IDENTITY_INSERT [dbo].[DetallesVentas] ON 

INSERT [dbo].[DetallesVentas] ([id_DetalleVenta], [id_Venta], [id_Producto], [Cantidad], [SubTotal]) VALUES (14, 56, 3, 18, CAST(234.00 AS Decimal(18, 2)))
INSERT [dbo].[DetallesVentas] ([id_DetalleVenta], [id_Venta], [id_Producto], [Cantidad], [SubTotal]) VALUES (17, 59, 4, 300, CAST(1770.00 AS Decimal(18, 2)))
INSERT [dbo].[DetallesVentas] ([id_DetalleVenta], [id_Venta], [id_Producto], [Cantidad], [SubTotal]) VALUES (18, 58, 4, 250, CAST(1475.00 AS Decimal(18, 2)))
INSERT [dbo].[DetallesVentas] ([id_DetalleVenta], [id_Venta], [id_Producto], [Cantidad], [SubTotal]) VALUES (19, 60, 4, 5, CAST(30.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[DetallesVentas] OFF
SET IDENTITY_INSERT [dbo].[FormasdeEnvios] ON 

INSERT [dbo].[FormasdeEnvios] ([id_FormadeEnvio], [Estado], [Descripcion]) VALUES (3, N'CP', N'Camion Propio')
INSERT [dbo].[FormasdeEnvios] ([id_FormadeEnvio], [Estado], [Descripcion]) VALUES (4, N'CNP', N'Camion No Propio')
INSERT [dbo].[FormasdeEnvios] ([id_FormadeEnvio], [Estado], [Descripcion]) VALUES (5, N'M', N'Maritimo')
SET IDENTITY_INSERT [dbo].[FormasdeEnvios] OFF
SET IDENTITY_INSERT [dbo].[FormasdePagos] ON 

INSERT [dbo].[FormasdePagos] ([id_FormadePago], [Nombre], [Descripcion]) VALUES (3, N'Tarjeta', N'Metodo con Tarjeta de Credito/Debito')
INSERT [dbo].[FormasdePagos] ([id_FormadePago], [Nombre], [Descripcion]) VALUES (4, N'Efectivo', N'Pago en Efectivo')
INSERT [dbo].[FormasdePagos] ([id_FormadePago], [Nombre], [Descripcion]) VALUES (5, N'Transferencia', N'Transferencia Bancaria')
INSERT [dbo].[FormasdePagos] ([id_FormadePago], [Nombre], [Descripcion]) VALUES (6, N'Cheque', N'Cheques')
SET IDENTITY_INSERT [dbo].[FormasdePagos] OFF
SET IDENTITY_INSERT [dbo].[Localidades] ON 

INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2139, N'Achiras', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2140, N'Adelia Maria', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2141, N'Agua De Oro', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2142, N'Alcira Gigena', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2143, N'Aldea Santa María', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2144, N'Alejandro Roca', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2145, N'Alejo Ledesma', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2146, N'Alicia', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2147, N'Almafuerte', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2148, N'Alpa Corral', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2149, N'Alta Gracia', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2150, N'Alto Alegre', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2151, N'Alto De Los Quebrachos', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2152, N'Altos De Chipion', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2153, N'Amboy', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2154, N'Ambul', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2155, N'Ana Zumarán', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2156, N'Anisacate', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2157, N'Arias', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2158, N'Arroyito', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2159, N'Arroyo Algodon', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2160, N'Arroyo Cabral', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2161, N'Arroyo De Los Patos', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2162, N'Assunta', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2163, N'Atahona', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2164, N'Ausonia', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2165, N'Avellaneda', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2166, N'Ballesteros', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2167, N'Ballesteros Sud', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2168, N'Balnearia', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2169, N'Bañado De Soto', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2170, N'Bell Ville', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2171, N'Bengolea', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2172, N'Benjamin Gould', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2173, N'Berrotaran', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2174, N'Bialet Masse', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2175, N'Bouwer', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2176, N'Brinkmann', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2177, N'Buchardo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2178, N'Bulnes', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2179, N'Cabalango', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2180, N'Calchin', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2181, N'Calchin Oeste', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2182, N'Calmayo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2183, N'Camilo Aldao', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2184, N'Caminiaga', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2185, N'Cañada De Luque', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2186, N'Cañada De Machado', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2187, N'Cañada De Rio Pinto', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2188, N'Canals', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2189, N'Candelaria Sud', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2190, N'Capilla De Los Remedios', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2191, N'Capilla De Siton', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2192, N'Capilla Del Carmen', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2193, N'Capilla Del Monte', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2194, N'Capitán General Bernardo O’higgins', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2195, N'Carnerillo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2196, N'Carrilobo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2197, N'Casa Grande', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2198, N'Cavanagh', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2199, N'Cerro Colorado', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2200, N'Chajan', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2201, N'Chalacea', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2202, N'Chañar Viejo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2203, N'Chancani', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2204, N'Charbonier', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2205, N'Charras', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2206, N'Chazon', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2207, N'Chilibroste', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2208, N'Chucul', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2209, N'Chuña', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2210, N'Chuña Huasi', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2211, N'Churqui Cañada', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2212, N'Ciénaga Del Coro', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2213, N'Cintra', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2214, N'Colazo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2215, N'Colonia Almada', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2216, N'Colonia Anita', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2217, N'Colonia Barge', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2218, N'Colonia Bismark', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2219, N'Colonia Bremen', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2220, N'Colonia Caroya', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2221, N'Colonia Italiana', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2222, N'Colonia Iturraspe', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2223, N'Colonia Las Cuatro Esquinas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2224, N'Colonia Las Pichanas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2225, N'Colonia Marina', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2226, N'Colonia Prosperidad', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2227, N'Colonia San Bartolomé', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2228, N'Colonia San Pedro', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2229, N'Colonia Tirolesa', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2230, N'Colonia Vicente Agüero', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2231, N'Colonia Videla', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2232, N'Colonia Vignaud', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2233, N'Colonia Waltelina', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2234, N'Comechingones', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2235, N'Conlara', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2236, N'Copacabana', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2237, N'Cordoba', 5)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2238, N'Coronel Baigorria', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2239, N'Coronel Moldes', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2240, N'Corral De Bustos - Ifflinger', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2241, N'Corralito', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2242, N'Cosquin', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2243, N'Costasacate', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2244, N'Cruz Alta', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2245, N'Cruz De Caña', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2246, N'Cruz Del Eje', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2247, N'Cuesta Blanca', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2248, N'Dalmacio Velez Sarsfield', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2249, N'Dean Funes', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2250, N'Del Campillo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2251, N'Despeñaderos', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2252, N'Devoto', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2253, N'Diego De Rojas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2254, N'Dique Chico', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2255, N'El Arañado', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2256, N'El Brete', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2257, N'El Chacho', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2258, N'El Crispín', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2259, N'El Fortin', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2260, N'El Manzano', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2261, N'El Rastreador', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2262, N'El Rodeo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2263, N'El Tio', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2264, N'Elena', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2265, N'Embalse', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2266, N'Esquina', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2267, N'Estación General Paz', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2268, N'Estacion Juarez Celman', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2269, N'Estancia Guadalupe', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2270, N'Estancia Vieja', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2271, N'Etruria', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2272, N'Eufrasio Loza', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2273, N'Falda Del Carmen', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2274, N'Freyre', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2275, N'General Baldissera', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2276, N'General Cabrera', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2277, N'General Deheza', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2278, N'General Fotheringham', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2279, N'General Levalle', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2280, N'General Roca', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2281, N'Guanaco Muerto', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2282, N'Guasapampa', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2283, N'Guatimozin', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2284, N'Gutemberg', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2285, N'Hernando', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2286, N'Huanchilla', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2287, N'Huerta Grande', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2288, N'Huinca Renanco', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2289, N'Idiazabal', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2290, N'Impira', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2291, N'Inriville', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2292, N'Isla Verde', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2293, N'Italo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2294, N'James Craik', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2295, N'Jesus Maria', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2296, N'Jovita', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2297, N'Justiniano Posse', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2298, N'Kilometro 658', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2299, N'La Batea', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2300, N'La Calera', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2301, N'La Carlota', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2302, N'La Carolina (El Potosí)', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2303, N'La Cautiva', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2304, N'La Cesira', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2305, N'La Cruz', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2306, N'La Cumbre', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2307, N'La Cumbrecita', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2308, N'La Falda', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2309, N'La Francia', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2310, N'La Granja', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2311, N'La Higuera', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2312, N'La Laguna', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2313, N'La Paisanita', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2314, N'La Palestina', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2315, N'La Pampa', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2316, N'La Paquita', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2317, N'La Para', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2318, N'La Paz', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2319, N'La Playa', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2320, N'La Playosa', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2321, N'La Población', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2322, N'La Posta', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2323, N'La Puerta', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2324, N'La Quinta', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2325, N'La Rancherita', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2326, N'La Rinconada', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2327, N'La Serranita', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2328, N'La Tordilla', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2329, N'Laborde', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2330, N'Laboulaye', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2331, N'Laguna Larga', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2332, N'Las Acequias', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2333, N'Las Albahacas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2334, N'Las Arrias', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2335, N'Las Bajadas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2336, N'Las Caleras', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2337, N'Las Calles', 5)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2338, N'Las Cañadas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2339, N'Las Gramillas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2340, N'Las Higueras', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2341, N'Las Isletillas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2342, N'Las Junturas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2343, N'Las Palmas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2344, N'Las Peñas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2345, N'Las Peñas Sud', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2346, N'Las Perdices', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2347, N'Las Playas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2348, N'Las Rabonas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2349, N'Las Saladas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2350, N'Las Tapias', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2351, N'Las Varas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2352, N'Las Varillas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2353, N'Las Vertientes', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2354, N'Leguizamón', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2355, N'Leones', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2356, N'Los Cedros', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2357, N'Los Cerrillos', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2358, N'Los Chañaritos (Cruz Del Eje)', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2359, N'Los Chañaritos (Rio Segundo)', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2360, N'Los Cisnes', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2361, N'Los Cocos', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2362, N'Los Condores', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2363, N'Los Hornillos', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2364, N'Los Hoyos', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2365, N'Los Mistoles', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2366, N'Los Molinos', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2367, N'Los Pozos', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2368, N'Los Reartes', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2369, N'Los Surgentes', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2370, N'Los Talares', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2371, N'Los Zorros', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2372, N'Lozada', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2373, N'Luca', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2374, N'Lucio Victorio Mansilla', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2375, N'Luque', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2376, N'Lutti', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2377, N'Luyaba', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2378, N'Malagueño', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2379, N'Malena', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2380, N'Malvinas Argentinas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2381, N'Manfredi', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2382, N'Maquinista Gallini', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2383, N'Marcos Juarez', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2384, N'Marull', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2385, N'Matorrales', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2386, N'Mattaldi', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2387, N'Mayu Sumaj', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2388, N'Media Naranja', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2389, N'Melo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2390, N'Mendiolaza', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2391, N'Mi Granja', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2392, N'Mina Clavero', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2393, N'Miramar', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2394, N'Monte Buey', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2395, N'Monte Cristo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2396, N'Monte De Los Gauchos', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2397, N'Monte Leña', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2398, N'Monte Maiz', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2399, N'Monte Ralo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2400, N'Morrison', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2401, N'Morteros', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2402, N'Nicolás Bruzzone', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2403, N'Noetinger', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2404, N'Nono', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2405, N'Obispo Trejo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2406, N'Olaeta', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2407, N'Oliva', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2408, N'Olivares De San Nicolás', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2409, N'Onagoyti', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2410, N'Oncativo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2411, N'Ordoñez', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2412, N'Pacheco De Melo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2413, N'Pampayasta Norte', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2414, N'Pampayasta Sud', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2415, N'Panaholma', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2416, N'Pascanas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2417, N'Pasco', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2418, N'Paso Del Durazno', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2419, N'Paso Viejo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2420, N'Pilar', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2421, N'Pincén', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2422, N'Piquillin', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2423, N'Plaza De Mercedes', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2424, N'Plaza Luxardo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2425, N'Porteña', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2426, N'Potrero De Garay', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2427, N'Pozo Del Molle', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2428, N'Pozo Nuevo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2429, N'Pueblo Italiano', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2430, N'Puesto De Castro', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2431, N'Punta Del Agua', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2432, N'Quebracho Herrado', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2433, N'Quilino', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2434, N'Rafael García', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2435, N'Ranqueles', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2436, N'Rayo Cortado', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2437, N'Reduccion', 5)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2438, N'Rincón', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2439, N'Río Bamba', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2440, N'Rio Ceballos', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2441, N'Rio Cuarto', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2442, N'Rio De Los Sauces', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2443, N'Rio Primero', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2444, N'Rio Segundo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2445, N'Rio Tercero', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2446, N'Rosales', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2447, N'Rosario Del Saladillo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2448, N'Sacanta', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2449, N'Sagrada Familia', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2450, N'Saira', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2451, N'Saladillo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2452, N'Saldan', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2453, N'Salsacate', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2454, N'Salsipuedes', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2455, N'Sampacho', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2456, N'San Agustin', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2457, N'San Antonio De Arredondo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2458, N'San Antonio De Litin', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2459, N'San Basilio', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2460, N'San Carlos Minas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2461, N'San Clemente', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2462, N'San Esteban', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2463, N'San Francisco', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2464, N'San Francisco Del Chañar', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2465, N'San Gerónimo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2466, N'San Ignacio', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2467, N'San Javier Y Yacanto', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2468, N'San Joaquín', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2469, N'San Jose', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2470, N'San Jose De La Dormida', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2471, N'San Jose De Las Salinas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2472, N'San Lorenzo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2473, N'San Marcos Sierras', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2474, N'San Marcos Sud', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2475, N'San Pedro', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2476, N'San Pedro Norte', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2477, N'San Roque', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2478, N'San Vicente', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2479, N'Santa Catalina', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2480, N'Santa Elena', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2481, N'Santa Eufemia', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2482, N'Santa Maria', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2483, N'Santa Rosa De Calamuchita', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2484, N'Santa Rosa De Rio Primero', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2485, N'Santiago Temple', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2486, N'Sarmiento', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2487, N'Saturnino María Laspiur', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2488, N'Sauce Arriba', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2489, N'Sebastian Elcano', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2490, N'Seeber', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2491, N'Segunda Usina', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2492, N'Serrano', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2493, N'Serrezuela', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2494, N'Silvio Pellico', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2495, N'Simbolar', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2496, N'Sinsacate', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2497, N'Suco', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2498, N'Tala Cañada', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2499, N'Tala Huasi', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2500, N'Talaini', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2501, N'Tancacha', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2502, N'Tanti', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2503, N'Ticino', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2504, N'Tinoco', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2505, N'Tio Pujio', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2506, N'Toledo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2507, N'Toro Pujío', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2508, N'Tosno', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2509, N'Tosquita', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2510, N'Transito', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2511, N'Tuclame', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2512, N'Ucacha', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2513, N'Unquillo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2514, N'Valle De Anisacate', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2515, N'Valle Hermoso', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2516, N'Viamonte', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2517, N'Vicuña Mackenna', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2518, N'Villa Allende', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2519, N'Villa Amancay', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2520, N'Villa Ascasubi', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2521, N'Villa Cañada Del Sauce', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2522, N'Villa Candelaria Norte', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2523, N'Villa Carlos Paz', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2524, N'Villa Cerro Azul', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2525, N'Villa Ciudad De America', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2526, N'Villa Ciudad Parque Los Reartes', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2527, N'Villa Concepcion Del Tio', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2528, N'Villa Cura Brochero', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2529, N'Villa De Las Rosas', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2530, N'Villa De María', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2531, N'Villa De Pocho', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2532, N'Villa De Soto', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2533, N'Villa Del Dique', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2534, N'Villa Del Prado', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2535, N'Villa Del Rosario', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2536, N'Villa Del Totoral', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2537, N'Villa Dolores', 5)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2538, N'Villa El Chacay', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2539, N'Villa Elisa', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2540, N'Villa Flor Serrana', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2541, N'Villa Fontana', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2542, N'Villa General Belgrano', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2543, N'Villa Giardino', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2544, N'Villa Gutiérrez', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2545, N'Villa Huidobro', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2546, N'Villa Icho Cruz', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2547, N'Villa La Bolsa', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2548, N'Villa Los Aromos', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2549, N'Villa Los Patos', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2550, N'Villa Maria', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2551, N'Villa Nueva', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2552, N'Villa Parque Santa Ana', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2553, N'Villa Parque Siquiman', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2554, N'Villa Quillinzo', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2555, N'Villa Rossi', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2556, N'Villa Rumipal', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2557, N'Villa San Esteban', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2558, N'Villa San Isidro', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2559, N'Villa Santa Cruz Del Lago', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2560, N'Villa Sarmiento (General Roca)', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2561, N'Villa Sarmiento (San Alberto)', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2562, N'Villa Tulumba', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2563, N'Villa Valeria', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2564, N'Villa Yacanto', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2565, N'Washington', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2566, N'Wenceslao Escalante', 5)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2567, N'Adolfo Alsina', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2568, N'Alberti', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2569, N'Almirante Brown', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2570, N'Arrecifes', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2571, N'Avellaneda', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2572, N'Ayacucho', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2573, N'Azul', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2574, N'Bahia Blanca', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2575, N'Balcarce', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2576, N'Baradero', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2577, N'Benito Juarez', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2578, N'Berazategui', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2579, N'Berisso', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2580, N'Bolivar', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2581, N'Bragado', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2582, N'Campana', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2583, N'Cañuelas', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2584, N'Capitan Sarmiento', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2585, N'Carlos Casares', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2586, N'Carlos Tejedor', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2587, N'Carmen De Areco', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2588, N'Castelli', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2589, N'Chacabuco', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2590, N'Chascomus', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2591, N'Chivilcoy', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2592, N'Colon', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2593, N'Coronel Brandsen', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2594, N'Coronel Dorrego', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2595, N'Coronel Pringles', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2596, N'Coronel Rosales', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2597, N'Coronel Suarez', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2598, N'Daireaux', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2599, N'Dolores', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2600, N'Ensenada', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2601, N'Escobar', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2602, N'Esteban Echeverria', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2603, N'Exaltacion De La Cruz', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2604, N'Ezeiza', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2605, N'Florencio Varela', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2606, N'Florentino Ameghino', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2607, N'General Alvarado', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2608, N'General Alvear', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2609, N'General Arenales', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2610, N'General Belgrano', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2611, N'General Guido', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2612, N'General Lamadrid', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2613, N'General Las Heras', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2614, N'General Lavalle', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2615, N'General Madariaga', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2616, N'General Paz', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2617, N'General Pinto', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2618, N'General Pueyrredon', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2619, N'General Rodriguez', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2620, N'General San Martin', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2621, N'General Viamonte', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2622, N'General Villegas', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2623, N'Gonzalez Chaves', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2624, N'Guamini', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2625, N'Hipolito Yrigoyen', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2626, N'Hurlingham', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2627, N'Ituzaingo', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2628, N'Jose Clemente Paz', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2629, N'Junin', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2630, N'La Matanza', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2631, N'La Plata', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2632, N'Lanus', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2633, N'Laprida', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2634, N'Las Flores', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2635, N'Leandro Nicéforo Alem', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2636, N'Lincoln', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2637, N'Loberia', 1)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2638, N'Lobos', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2639, N'Lomas De Zamora', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2640, N'Lujan', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2641, N'Magdalena', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2642, N'Maipu', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2643, N'Malvinas Argentinas', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2644, N'Mar Chiquita', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2645, N'Marcos Paz', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2646, N'Mercedes', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2647, N'Merlo', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2648, N'Monte', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2649, N'Moreno', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2650, N'Moron', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2651, N'Municipio De La Costa', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2652, N'Municipio De Monte Hermoso', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2653, N'Municipio De Pinamar', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2654, N'Municipio De Villa Gesell', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2655, N'Navarro', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2656, N'Necochea', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2657, N'Nueve De Julio', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2658, N'Olavarria', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2659, N'Patagones', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2660, N'Pehuajo', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2661, N'Pellegrini', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2662, N'Pergamino', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2663, N'Pila', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2664, N'Pilar', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2665, N'Presidente Peron', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2666, N'Puan', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2667, N'Punta Indio', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2668, N'Quilmes', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2669, N'Ramallo', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2670, N'Rauch', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2671, N'Rivadavia', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2672, N'Rojas', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2673, N'Roque Perez', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2674, N'Saavedra', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2675, N'Saladillo', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2676, N'Salliquelo', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2677, N'Salto', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2678, N'San Andres De Giles', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2679, N'San Antonio De Areco', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2680, N'San Cayetano', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2681, N'San Fernando', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2682, N'San Isidro', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2683, N'San Miguel', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2684, N'San Nicolas', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2685, N'San Pedro', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2686, N'San Vicente', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2687, N'Suipacha', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2688, N'Tandil', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2689, N'Tapalque', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2690, N'Tigre', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2691, N'Tordillo', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2692, N'Tornquist', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2693, N'Trenque Lauquen', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2694, N'Tres Arroyos', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2695, N'Tres De Febrero', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2696, N'Tres Lomas', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2697, N'Veinticinco De Mayo', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2698, N'Vicente Lopez', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2699, N'Villarino', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2700, N'Zarate', 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2701, N'Balde', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2702, N'Carpintería ', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2703, N'Concarán', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2704, N'Cortaderas', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2705, N'El Trapiche ', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2706, N'La Carolina ', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2707, N'La Punta ', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2708, N'La Toma ', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2709, N'Los Molles', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2710, N'Lujan', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2711, N'Merlo', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2712, N'Nogolí', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2713, N'Papagayos', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2714, N'Potrero de los Funes', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2715, N'Quines', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2716, N'San Francisco del Monte', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2717, N'San Luis Capital', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2718, N'Santa Rosa del Conlara', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2719, N'Villa Elena', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2720, N'Villa la Quebrada', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2721, N'Villa Larca', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2722, N'Villa Mercedes', 18)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2723, N'Arauco', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2724, N'Castro Barros', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2725, N'Chamical', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2726, N'Chilecito', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2727, N'Coronel Felipe Varela', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2728, N'Famatina', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2729, N'General Angel Vicente Peñaloza', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2730, N'General Belgrano', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2731, N'General Juan Facundo Quiroga', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2732, N'General Lamadrid', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2733, N'General Ocampo', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2734, N'General San Martín', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2735, N'Independencia', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2736, N'La Rioja', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2737, N'Rosario Vera Peñaloza', 11)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2738, N'San Blas De Los Sauces', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2739, N'Sanagasta', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2740, N'Vinchina', 11)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2741, N'Aconquija', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2742, N'Ancasti', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2743, N'Andalgalá', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2744, N'Antofagasta', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2745, N'Belén', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2746, N'Capayan', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2747, N'Corral Quemado', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2748, N'El Alto', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2749, N'El Rodeo', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2750, N'Fiambalá', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2751, N'Fray Mamerto Esquiu', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2752, N'Hualfin', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2753, N'Huillapima (Capayan)', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2754, N'Icaño (La Paz)', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2755, N'La Puerta', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2756, N'Las Juntas', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2757, N'Londres', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2758, N'Los Altos', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2759, N'Los Varela', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2760, N'Mutquín', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2761, N'Paclin', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2762, N'Pomán', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2763, N'Pozo De La Piedra', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2764, N'Puerta De Corral Quemado', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2765, N'Puerta De San José', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2766, N'Recreo', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2767, N'San Fernando', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2768, N'San Fernando Del Valle De Catamarca', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2769, N'San José', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2770, N'Santa María', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2771, N'Santa Rosa', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2772, N'Saujil', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2773, N'Tapso', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2774, N'Tinogasta', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2775, N'Valle Viejo', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2776, N'Villa Vil', 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2777, N'Abdon Castro Tolay (Barrancas)', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2778, N'Abra Pampa', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2779, N'Abralaite', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2780, N'Aguas Calientes', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2781, N'Arrayanal', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2782, N'Barrios', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2783, N'Barro Negro', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2784, N'Caimancito', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2785, N'Calilegua', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2786, N'Cangrejillos', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2787, N'Caspalá', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2788, N'Catua', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2789, N'Cieneguillas', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2790, N'Coranzuli', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2791, N'Cusi Cusi', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2792, N'El Aguilar', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2793, N'El Carmen', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2794, N'El Condor', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2795, N'El Fuerte', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2796, N'El Piquete', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2797, N'El Talar', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2798, N'Fraile Pintado', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2799, N'Hipolito Yrigoyen', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2800, N'Huacalera', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2801, N'Humahuaca', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2802, N'La Esperanza', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2803, N'La Mendieta', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2804, N'La Quiaca', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2805, N'Libertador General San Martin', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2806, N'Maimará', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2807, N'Mina Pirquitas', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2808, N'Monterrico', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2809, N'Palma Sola', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2810, N'Palpalá', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2811, N'Pampa Blanca', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2812, N'Pampichuela', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2813, N'Perico', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2814, N'Puesto Del Marquéz', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2815, N'Puesto Viejo', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2816, N'Pumahuasi', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2817, N'Purmamarca', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2818, N'Rinconada', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2819, N'Rodeíto', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2820, N'Rosario De Río Grande', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2821, N'San Antonio', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2822, N'San Francisco', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2823, N'San Pedro De Jujuy', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2824, N'San Salvador De Jujuy', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2825, N'Santa Ana', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2826, N'Santa Catalina', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2827, N'Santa Clara', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2828, N'Susques', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2829, N'Tilcara', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2830, N'Tres Cruces', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2831, N'Tumbaya', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2832, N'Valle Grande', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2833, N'Vinalito', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2834, N'Volcan', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2835, N'Yala', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2836, N'Yaví', 9)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2837, N'Yuto', 9)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2838, N'Avia Terai', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2839, N'Barranqueras', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2840, N'Basail', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2841, N'Campo Largo', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2842, N'Capitan Solari', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2843, N'Charadai', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2844, N'Charata', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2845, N'Chorotis', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2846, N'Ciervo Petiso', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2847, N'Colonia Benitez', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2848, N'Colonia Elisa', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2849, N'Colonia Popular', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2850, N'Colonias Unidas', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2851, N'Concepción Del Bermejo', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2852, N'Coronel Du Graty', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2853, N'Corzuela', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2854, N'Cote Lai', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2855, N'El Sauzalito', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2856, N'Enrique Urien', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2857, N'Fontana', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2858, N'Fuerte Esperanza', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2859, N'Gancedo', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2860, N'General Capdevila', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2861, N'General Pinedo', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2862, N'General San Martin', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2863, N'General Vedia', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2864, N'Hermoso Campo', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2865, N'Isla Del Cerrito', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2866, N'Juan Jose Castelli', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2867, N'La Clotilde', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2868, N'La Eduviges', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2869, N'La Escondida', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2870, N'La Leonesa', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2871, N'La Tigra', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2872, N'La Verde', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2873, N'Laguna Blanca', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2874, N'Laguna Limpia', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2875, N'Lapachito', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2876, N'Las Breñas', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2877, N'Las Garcitas', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2878, N'Las Palmas', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2879, N'Los Frentones', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2880, N'Machagai', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2881, N'Makalle', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2882, N'Margarita Belen', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2883, N'Miraflores', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2884, N'Mision Nueva Pompeya', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2885, N'Napenay', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2886, N'Pampa Almiron', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2887, N'Pampa Del Indio', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2888, N'Pampa Del Infierno', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2889, N'Presidencia Roca', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2890, N'Presidente De La Plaza', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2891, N'Puerto Bermejo', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2892, N'Puerto Eva Peron', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2893, N'Puerto Tirol', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2894, N'Puerto Vilelas', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2895, N'Quitilipi', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2896, N'Resistencia', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2897, N'Roque Saenz Peña', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2898, N'Samuhu', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2899, N'San Bernardo', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2900, N'Santa Sylvina', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2901, N'Taco Pozo', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2902, N'Tres Isletas', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2903, N'Villa Angela', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2904, N'Villa Berthet', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2905, N'Villa Rio Bermejito', 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2906, N'28 De Julio', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2907, N'Aldea Apeleg', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2908, N'Aldea Beleiro', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2909, N'Aldea Epulef', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2910, N'Alto Rio Senguer', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2911, N'Buen Pasto', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2912, N'Camarones', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2913, N'Carrenleufú', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2914, N'Cerro Centinela', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2915, N'Cholila', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2916, N'Colán Conhué', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2917, N'Comodoro Rivadavia', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2918, N'Corcovado', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2919, N'Cushamen Centro', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2920, N'Dique Florentino Ameghino', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2921, N'Doctor Ricardo Rojas', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2922, N'Dolavon', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2923, N'El Hoyo', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2924, N'El Maiten', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2925, N'Epuyen', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2926, N'Esquel', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2927, N'Facundo', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2928, N'Gaiman', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2929, N'Gan Gan', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2930, N'Gastre', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2931, N'Gobernador Costa', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2932, N'Gualjaina', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2933, N'Jose De San Martin', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2934, N'Lago Blanco', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2935, N'Lago Puelo', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2936, N'Lagunita Salada', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2937, N'Las Plumas', 4)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2938, N'Los Altares', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2939, N'Paso De Indios', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2940, N'Paso Del Sapo', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2941, N'Puerto Madryn', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2942, N'Puerto Pirámide', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2943, N'Rada Tilly', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2944, N'Rawson', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2945, N'Rio Mayo', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2946, N'Rio Pico', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2947, N'Sarmiento', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2948, N'Tecka', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2949, N'Telsen', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2950, N'Trelew', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2951, N'Trevelin', 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2952, N'Alvear', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2953, N'Bella Vista', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2954, N'Beron De Astrada', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2955, N'Bonpland', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2956, N'Caa Cati', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2957, N'Chavarria', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2958, N'Colonia Carlos Pellegrini', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2959, N'Colonia Libertad', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2960, N'Colonia Liebig', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2961, N'Colonia Santa Rosa', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2962, N'Concepcion', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2963, N'Corrientes', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2964, N'Cruz De Los Milagros', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2965, N'Curuzu Cuatia', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2966, N'Empedrado', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2967, N'Esquina', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2968, N'Estacion Torrent', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2969, N'Felipe Yofre', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2970, N'Garruchos', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2971, N'Gobernador Martinez', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2972, N'Gobernador Virasoro', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2973, N'Goya', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2974, N'Guaviravi', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2975, N'Herlitzka', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2976, N'Ita Ibate', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2977, N'Itati', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2978, N'Ituzaingo', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2979, N'Jose Rafael Gomez', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2980, N'Juan Pujol', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2981, N'La Cruz', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2982, N'Lavalle', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2983, N'Lomas De Vallejos', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2984, N'Loreto', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2985, N'Mariano I. Loza', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2986, N'Mburucuya', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2987, N'Mercedes', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2988, N'Mocoreta', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2989, N'Monte Caseros', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2990, N'Nueve De Julio', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2991, N'Palmar Grande', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2992, N'Parada Pucheta', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2993, N'Paso De La Patria', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2994, N'Paso De Los Libres', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2995, N'Pedro Fernandez', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2996, N'Perugorria', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2997, N'Pueblo Libertador', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2998, N'Ramada Paso', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (2999, N'Riachuelo', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3000, N'Saladas', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3001, N'San Antonio', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3002, N'San Carlos', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3003, N'San Cosme', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3004, N'San Lorenzo', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3005, N'San Luis Del Palmar', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3006, N'San Miguel', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3007, N'San Roque', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3008, N'Santa Ana', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3009, N'Santa Lucia', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3010, N'Santo Tome', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3011, N'Sauce', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3012, N'Tabay', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3013, N'Tapebicua', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3014, N'Tatacua', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3015, N'Villa Olivari', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3016, N'Yapeyu', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3017, N'Yatayti Calle', 6)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3018, N'Alarcón', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3019, N'Alcaraz Norte', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3020, N'Alcaraz Sur', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3021, N'Aldea Asunción', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3022, N'Aldea Brasilera', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3023, N'Aldea Eigenfeld', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3024, N'Aldea Grapschental', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3025, N'Aldea María Luisa', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3026, N'Aldea Protestante', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3027, N'Aldea Salto', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3028, N'Aldea San Antonio (Gualeguaychú)', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3029, N'Aldea San Antonio (Paraná)', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3030, N'Aldea San Juan', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3031, N'Aldea San Miguel', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3032, N'Aldea San Rafael', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3033, N'Aldea Santa María', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3034, N'Aldea Santa Rosa', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3035, N'Aldea Spatzenkutter', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3036, N'Aldea Valle Maria', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3037, N'Alejandro Roca', 7)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3038, N'Altamirano Sur', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3039, N'Antelo', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3040, N'Antonio Tomás', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3041, N'Aranguren', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3042, N'Arroyo Barú', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3043, N'Arroyo Burgos', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3044, N'Arroyo Clé', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3045, N'Arroyo Corralito', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3046, N'Arroyo Del Medio', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3047, N'Arroyo Maturrango', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3048, N'Arroyo Palo Seco', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3049, N'Banderas', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3050, N'Basavilbaso', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3051, N'Berrera', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3052, N'Betbeder', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3053, N'Bovril', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3054, N'Caseros', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3055, N'Ceibas', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3056, N'Cerrito', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3057, N'Chajari', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3058, N'Chilcas', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3059, N'Clodomiro Ledesma', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3060, N'Colon', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3061, N'Colonia Alemana', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3062, N'Colonia Avellaneda', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3063, N'Colonia Avigdor', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3064, N'Colonia Ayui', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3065, N'Colonia Baylina', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3066, N'Colonia Carrasco', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3067, N'Colonia Celina', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3068, N'Colonia Cerrito', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3069, N'Colonia Crespo', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3070, N'Colonia Elía', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3071, N'Colonia Ensayo', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3072, N'Colonia General Roca', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3073, N'Colonia La Argentina', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3074, N'Colonia Merou', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3075, N'Colonia Oficial N° 13', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3076, N'Colonia Oficial N° 3 Y 14', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3077, N'Colonia Oficial N°5', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3078, N'Colonia Reffino', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3079, N'Colonia Tunas', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3080, N'Colonia Viraró', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3081, N'Concepcion Del Uruguay', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3082, N'Concordia', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3083, N'Conscripto Bernardi', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3084, N'Costa Grande', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3085, N'Costa San Antonio', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3086, N'Costa Uruguay Norte', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3087, N'Costa Uruguay Sur', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3088, N'Crespo', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3089, N'Crucesitas Octava', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3090, N'Crucesitas Séptima', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3091, N'Crucesitas Tercera', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3092, N'Cuchilla Redonda', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3093, N'Curtiembre', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3094, N'Diamante', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3095, N'Distrito Chañar', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3096, N'Distrito Chiqueros', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3097, N'Distrito Cuarto', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3098, N'Distrito Diego López', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3099, N'Distrito Pajonal', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3100, N'Distrito Sauce', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3101, N'Distrito Sexto Costa De Nogoyá', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3102, N'Distrito Tala', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3103, N'Distrito Talitas', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3104, N'Don Cristóbal Primero', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3105, N'Don Cristóbal Segundo', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3106, N'Durazno', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3107, N'El Cimarrón', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3108, N'El Gramiyal', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3109, N'El Palenque', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3110, N'El Pingo', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3111, N'El Quebracho', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3112, N'El Redomón', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3113, N'El Solar', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3114, N'Enrique Carbo', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3115, N'Espinillo Norte', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3116, N'Estación Camps', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3117, N'Estación Escriña', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3118, N'Estación Lazo', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3119, N'Estación Raíces', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3120, N'Estación Yerúa', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3121, N'Estancia Grande', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3122, N'Estancia Líbaros', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3123, N'Estancia Racedo (El Carmen)', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3124, N'Estancia Sola', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3125, N'Estancia Yuquerí', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3126, N'Estaquitas', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3127, N'Faustino María Parera', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3128, N'Febre', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3129, N'Federacion', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3130, N'Federal', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3131, N'General Almada', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3132, N'General Alvear', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3133, N'General Campos', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3134, N'General Galarza', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3135, N'General Ramirez', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3136, N'Gilbert', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3137, N'Gobernador Echagüe', 7)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3138, N'Gobernador Mansilla', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3139, N'González Calderón', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3140, N'Gualeguay', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3141, N'Gualeguaychu', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3142, N'Gualeguaycito', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3143, N'Guardamonte', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3144, N'Hambis', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3145, N'Hasenkamp', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3146, N'Hernandarias', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3147, N'Hernandez', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3148, N'Herrera', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3149, N'Hinojal', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3150, N'Hocker', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3151, N'Ingeniero Sajaroff', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3152, N'Irazusta', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3153, N'Islas Del Ibicuy', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3154, N'Isletas', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3155, N'Jubileo', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3156, N'Justo José De Urquiza', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3157, N'La Clarita', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3158, N'La Criolla', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3159, N'La Esmeralda', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3160, N'La Florida', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3161, N'La Fraternidad Y Santa Juana', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3162, N'La Hierra', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3163, N'La Ollita', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3164, N'La Paz', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3165, N'La Picada', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3166, N'La Providencia', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3167, N'La Verbena', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3168, N'Laguna Benítez', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3169, N'Larroque', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3170, N'Las Cuevas', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3171, N'Las Garzas (Pueblo Bellocq)', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3172, N'Las Guachas', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3173, N'Las Mercedes', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3174, N'Las Moscas', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3175, N'Las Mulitas', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3176, N'Las Toscas', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3177, N'Laurencena', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3178, N'Libertador San Martin', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3179, N'Loma Limpia', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3180, N'Los Ceibos', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3181, N'Los Charruas', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3182, N'Los Conquistadores', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3183, N'Lucas Gonzalez', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3184, N'Lucas Norte', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3185, N'Lucas Sur Primera', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3186, N'Lucas Sur Segundo', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3187, N'Macia', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3188, N'Maria Grande', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3189, N'María Grande Segunda', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3190, N'Médanos', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3191, N'Mojones Norte', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3192, N'Mojones Sur', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3193, N'Molino Doll', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3194, N'Monte Redondo', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3195, N'Montoya', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3196, N'Mulas Grandes', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3197, N'Ñancay', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3198, N'Nogoya', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3199, N'Nueva Escocia', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3200, N'Nueva Vizcaya', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3201, N'Ombú', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3202, N'Oro Verde', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3203, N'Paraje Las Tunas', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3204, N'Parana', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3205, N'Pasaje Guayaquil', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3206, N'Paso De La Arena', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3207, N'Paso De La Laguna', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3208, N'Paso De Las Piedras', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3209, N'Paso Duarte', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3210, N'Pastor Britos', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3211, N'Pedernal', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3212, N'Perdices', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3213, N'Picada Berón', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3214, N'Piedras Blancas', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3215, N'Primer Distrito Cuchilla', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3216, N'Primero De Mayo', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3217, N'Pronunciamiento', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3218, N'Pueblo Brugo', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3219, N'Pueblo Cazes', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3220, N'Pueblo General Belgrano', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3221, N'Pueblo Liebig', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3222, N'Puerto Algarrobo', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3223, N'Puerto Ibicuy', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3224, N'Puerto Yerua', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3225, N'Punta Del Monte', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3226, N'Quebracho', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3227, N'Quinto Distrito', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3228, N'Raíces Oeste', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3229, N'Rincón De Nogoyá', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3230, N'Rincón Del Cinto', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3231, N'Rincón Del Doll', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3232, N'Rincón Del Gato', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3233, N'Rocamora', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3234, N'Rosario Del Tala', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3235, N'S.J. De La Frontera', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3236, N'San Benito', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3237, N'San Cipriano', 7)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3238, N'San Ernesto', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3239, N'San Gustavo', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3240, N'San Jaime', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3241, N'San Jose', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3242, N'San José De Feliciano', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3243, N'San Justo (Concordia)', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3244, N'San Justo (Uruguay)', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3245, N'San Marcial', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3246, N'San Pedro', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3247, N'San Ramírez', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3248, N'San Ramón', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3249, N'San Roque', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3250, N'San Salvador', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3251, N'San Víctor', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3252, N'Santa Ana (Federación)', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3253, N'Santa Ana (Uruguay)', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3254, N'Santa Anita', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3255, N'Santa Elena', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3256, N'Santa Lucía', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3257, N'Santa Luisa', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3258, N'Sauce De Luna', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3259, N'Sauce Montrull', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3260, N'Sauce Pintos', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3261, N'Sauce Sur', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3262, N'Segui', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3263, N'Sir Leonard', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3264, N'Sosa', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3265, N'Tabossi', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3266, N'Tezanos Pintos', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3267, N'Ubajay', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3268, N'Urdinarrain', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3269, N'Veinte De Setiembre', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3270, N'Viale', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3271, N'Victoria', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3272, N'Villa Clara', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3273, N'Villa Del Rosario', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3274, N'Villa Dominguez', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3275, N'Villa Elisa', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3276, N'Villa Fontana', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3277, N'Villa Gobernador Etchevehere', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3278, N'Villa Mantero', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3279, N'Villa Paranacito', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3280, N'Villa Urquiza', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3281, N'Villaguay', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3282, N'Walter Moss', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3283, N'Yacaré', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3284, N'Yeso Oeste', 7)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3285, N'Buena Vista', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3286, N'Clorinda', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3287, N'Colonia Pastoril', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3288, N'Comandante Fontana', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3289, N'El Colorado', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3290, N'El Espinillo', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3291, N'Estanislao Del Campo', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3292, N'Formosa', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3293, N'Fortín Cabo 1º Lugones', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3294, N'General Enrique Mosconi', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3295, N'General Güemes', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3296, N'General Lucio Victorio Mansilla', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3297, N'General Manuel Belgrano', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3298, N'Gran Guardia', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3299, N'Herradura', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3300, N'Ibarreta', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3301, N'Ingeniero Juarez', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3302, N'Laguna Blanca', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3303, N'Laguna Naick Neck', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3304, N'Laguna Yema', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3305, N'Las Lomitas', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3306, N'Los Chiriguanos', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3307, N'Mayor Vicente Villafañe', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3308, N'Mision San Francisco De Laishi', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3309, N'Mision Tacaagle', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3310, N'Mojon De Fierro', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3311, N'Palo Santo', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3312, N'Pirane', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3313, N'Posta San Martin', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3314, N'Pozo De Maza', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3315, N'Pozo Del Tigre', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3316, N'Riacho He He', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3317, N'San Hilario', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3318, N'Siete Palmas', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3319, N'Subteniente Perin', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3320, N'Tres Lagunas', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3321, N'Villa Dos Trece', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3322, N'Villa Escolar', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3323, N'Villa General Guemes', 8)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3324, N'25 De Mayo', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3325, N'Abramo', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3326, N'Adolfo Van Praet', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3327, N'Agustoni', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3328, N'Algarrobo Del Aguila', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3329, N'Alpachiri', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3330, N'Alta Italia', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3331, N'Anguil', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3332, N'Arata', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3333, N'Ataliva Roca', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3334, N'Bernardo Larroude', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3335, N'Bernasconi', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3336, N'Caleufu', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3337, N'Carro Quemado', 10)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3338, N'Catrilo', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3339, N'Ceballos', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3340, N'Chacharramendi', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3341, N'Colonia Baron', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3342, N'Colonia Santa Maria', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3343, N'Colonia Santa Teresa', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3344, N'Conhelo', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3345, N'Coronel Hilario Lagos', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3346, N'Cuchillo Co', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3347, N'Doblas', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3348, N'Dorila', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3349, N'Eduardo Castex', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3350, N'Embajador Martini', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3351, N'Falucho', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3352, N'General Acha', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3353, N'General Manuel Campos', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3354, N'General Pico', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3355, N'General San Martin', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3356, N'Gobernador Duval', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3357, N'Guatrache', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3358, N'Ingeniero Luiggi', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3359, N'Intendente Alvear', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3360, N'Jacinto Arauz', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3361, N'La Adela', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3362, N'La Humada', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3363, N'La Maruja', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3364, N'La Reforma', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3365, N'Limay Mahuida', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3366, N'Lonquimay', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3367, N'Loventue', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3368, N'Luan Toro', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3369, N'Macachin', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3370, N'Maisonnave', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3371, N'Mauricio Mayer', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3372, N'Metileo', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3373, N'Miguel Cane', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3374, N'Miguel Riglos', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3375, N'Monte Nievas', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3376, N'Parera', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3377, N'Peru', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3378, N'Pichi Huinca', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3379, N'Puelches', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3380, N'Puelen', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3381, N'Quehue', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3382, N'Quemu Quemu', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3383, N'Quetrequen', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3384, N'Rancul', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3385, N'Realico', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3386, N'Relmo', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3387, N'Rolon', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3388, N'Rucanelo', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3389, N'Santa Isabel', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3390, N'Santa Rosa', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3391, N'Sarah', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3392, N'Speluzzi', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3393, N'Telen', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3394, N'Toay', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3395, N'Tomas Manuel Anchorena', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3396, N'Trenel', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3397, N'Unanue', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3398, N'Uriburu', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3399, N'Vertiz', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3400, N'Victorica', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3401, N'Villa Mirasol', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3402, N'Winifreda', 10)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3403, N'General Alvear', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3404, N'Godoy Cruz', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3405, N'Guaymallen', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3406, N'Junin', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3407, N'La Paz', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3408, N'Las Heras', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3409, N'Lavalle', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3410, N'Lujan De Cuyo', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3411, N'Maipu', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3412, N'Malargue', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3413, N'Mendoza', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3414, N'Rivadavia', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3415, N'San Carlos', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3416, N'San Martin', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3417, N'San Rafael', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3418, N'Santa Rosa', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3419, N'Tunuyan', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3420, N'Tupungato', 12)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3421, N'25 De Mayo', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3422, N'Alba Posse', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3423, N'Almafuerte', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3424, N'Apostoles', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3425, N'Aristobulo Del Valle', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3426, N'Arroyo Del Medio', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3427, N'Azara', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3428, N'Bernardo De Irigoyen', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3429, N'Bompland', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3430, N'Caa Yari', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3431, N'Campo Grande', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3432, N'Campo Ramon', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3433, N'Campo Viera', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3434, N'Candelaria', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3435, N'Capiovi', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3436, N'Caraguatay', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3437, N'Cerro Azul', 13)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3438, N'Cerro Cora', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3439, N'Colonia Alberdi', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3440, N'Colonia Aurora', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3441, N'Colonia Delicia', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3442, N'Colonia Polana', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3443, N'Colonia Victoria', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3444, N'Colonia Wanda', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3445, N'Comandante Andrés Guacurari', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3446, N'Concepción De La Sierra', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3447, N'Corpus', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3448, N'Dos Arroyos', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3449, N'Dos De Mayo', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3450, N'El Alcazar', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3451, N'El Soberbio', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3452, N'Eldorado', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3453, N'Fachinal', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3454, N'Florentino Ameghino', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3455, N'Garuhape', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3456, N'Garupa', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3457, N'General Alvear', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3458, N'General Manuel Belgrano', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3459, N'General Urquiza', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3460, N'Gobernador Lopez', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3461, N'Gobernador Roca', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3462, N'Guarani', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3463, N'Hipolito Irigoyen', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3464, N'Itacaruare', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3465, N'Jardin America', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3466, N'Leandro Nicéforo Alem', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3467, N'Loreto', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3468, N'Los Helechos', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3469, N'Martires', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3470, N'Mojon Grande', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3471, N'Montecarlo', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3472, N'Nueve De Julio', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3473, N'Obera', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3474, N'Olegario Víctor Andrade', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3475, N'Panambi', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3476, N'Posadas', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3477, N'Profundidad', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3478, N'Puerto Esperanza', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3479, N'Puerto Iguazu', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3480, N'Puerto Leoni', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3481, N'Puerto Libertad', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3482, N'Puerto Piray', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3483, N'Puerto Rico', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3484, N'Ruiz De Montoya', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3485, N'San Antonio', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3486, N'San Ignacio', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3487, N'San Javier', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3488, N'San Jose', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3489, N'San Martin', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3490, N'San Pedro', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3491, N'San Vicente', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3492, N'Santa Ana', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3493, N'Santa Maria', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3494, N'Santiago De Liniers', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3495, N'Santo Pipo', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3496, N'Tres Capones', 13)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3497, N'Aguada San Roque', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3498, N'Alumine', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3499, N'Andacollo', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3500, N'Añelo', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3501, N'Bajada Del Agrio', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3502, N'Barrancas', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3503, N'Buta Ranquil', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3504, N'Caviahue', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3505, N'Centenario', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3506, N'Chorriaca', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3507, N'Chos Malal', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3508, N'Covunco Abajo', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3509, N'Coyuco - Cochico', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3510, N'Cutral Co', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3511, N'El Cholar', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3512, N'El Huecu', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3513, N'El Sauce', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3514, N'Guañacos', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3515, N'Huinganco', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3516, N'Junin De Los Andes', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3517, N'Las Coloradas', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3518, N'Las Lajas', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3519, N'Las Ovejas', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3520, N'Loncopue', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3521, N'Los Catutos', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3522, N'Los Chihuidos', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3523, N'Los Miches', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3524, N'Mariano Moreno', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3525, N'Neuquen', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3526, N'Octavio Pico', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3527, N'Paso Aguerre', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3528, N'Picun Leufu', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3529, N'Piedra Del Aguila', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3530, N'Pilo Lil', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3531, N'Plaza Huincul', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3532, N'Plotier', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3533, N'Puente Picun Leufu', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3534, N'Quili Malal', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3535, N'Ramón M. Castro', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3536, N'Rincon De Los Sauces', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3537, N'San Martin De Los Andes', 14)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3538, N'San Patricio Del Chañar', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3539, N'Santo Tomas', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3540, N'Sauzal Bonito (Cutralco)', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3541, N'Senillosa', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3542, N'Taquimilan', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3543, N'Tricao Malal', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3544, N'Varvarco', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3545, N'Villa Curi Leuvu', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3546, N'Villa Del Nahueve', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3547, N'Villa El Chocon', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3548, N'Villa La Angostura', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3549, N'Villa Manzano Amargo', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3550, N'Villa Pehuenia', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3551, N'Villa Traful', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3552, N'Vista Alegre', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3553, N'Zapala', 14)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3554, N'Aguada Cecilio', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3555, N'Aguada De Guerra', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3556, N'Aguada Guzmán', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3557, N'Allen', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3558, N'Arroyo De La Ventana', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3559, N'Arroyo Los Berros', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3560, N'Campo Grande', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3561, N'Catriel', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3562, N'Cerro Policia', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3563, N'Cervantes', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3564, N'Chelforo', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3565, N'Chichinales', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3566, N'Chimpay', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3567, N'Chipauquil', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3568, N'Choele Choel', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3569, N'Cinco Saltos', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3570, N'Cipolletti', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3571, N'Clemente Onelli', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3572, N'Colán Conhue', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3573, N'Comallo', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3574, N'Comicó', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3575, N'Cona Niyeu', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3576, N'Contralmirante Cordero', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3577, N'Coronel Belisle', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3578, N'Cubanea', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3579, N'Darwin', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3580, N'Dina Huapi', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3581, N'El Bolson', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3582, N'El Caín', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3583, N'El Cuy', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3584, N'El Manso', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3585, N'General Conesa', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3586, N'General Enrique Godoy', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3587, N'General Fernandez Oro', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3588, N'General Roca', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3589, N'Guardia Mitre', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3590, N'Ingeniero Huergo', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3591, N'Ingeniero Jacobacci', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3592, N'Laguna Blanca', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3593, N'Lamarque', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3594, N'Los Menucos', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3595, N'Luis Beltran', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3596, N'Mainque', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3597, N'Mamuel Choique', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3598, N'Maquinchao', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3599, N'Mencué', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3600, N'Ministro Ramos Mexia', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3601, N'Nahuel Niyeu', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3602, N'Naupa Huen', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3603, N'Ñorquinco', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3604, N'Ojos De Agua', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3605, N'Paso Flores', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3606, N'Peñas Blancas', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3607, N'Pichi Mahuida', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3608, N'Pilcaniyeu', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3609, N'Pilquiniyeu', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3610, N'Pilquiniyeu Del Limay', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3611, N'Pomona', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3612, N'Prahuaniyeu', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3613, N'Rincón Treneta', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3614, N'Río Chico', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3615, N'Rio Colorado', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3616, N'San Antonio Oeste', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3617, N'San Carlos De Bariloche', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3618, N'San Javier', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3619, N'Sierra Colorada', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3620, N'Sierra Grande', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3621, N'Sierra Pailemán', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3622, N'Valcheta', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3623, N'Valle Azul', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3624, N'Viedma', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3625, N'Villa Llanquín', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3626, N'Villa Mascardi', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3627, N'Villa Regina', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3628, N'Yaminué', 15)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3629, N'Aguaray', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3630, N'Angastaco', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3631, N'Animana', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3632, N'Apolinario Saravia', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3633, N'Cachi', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3634, N'Cafayate', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3635, N'Campo Quijano', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3636, N'Campo Santo', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3637, N'Cerrillos', 16)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3638, N'Chicoana', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3639, N'Colonia Santa Rosa', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3640, N'Coronel Moldes', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3641, N'Delegacion Dragones', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3642, N'El Bordo', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3643, N'El Carril', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3644, N'El Galpon', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3645, N'El Jardin', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3646, N'El Potrero', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3647, N'El Quebrachal', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3648, N'El Tala', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3649, N'Embarcacion', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3650, N'General Ballivian', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3651, N'General Guemes', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3652, N'General Mosconi', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3653, N'General Pizarro', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3654, N'Guachipas', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3655, N'Hipolito Yrigoyen', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3656, N'Iruya', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3657, N'Isla De Cañas', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3658, N'Joaquin Víctor Gonzalez', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3659, N'La Caldera', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3660, N'La Candelaria', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3661, N'La Merced', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3662, N'La Poma', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3663, N'La Viña', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3664, N'Las Lajitas', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3665, N'Los Toldos', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3666, N'Molinos', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3667, N'Nazareno', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3668, N'Payogasta', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3669, N'Pichanal', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3670, N'Profesor Salvador Mazza', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3671, N'Rio De Las Piedras', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3672, N'Rivadavia Banda Norte', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3673, N'Rivadavia Banda Sur', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3674, N'Rosario De La Frontera', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3675, N'Rosario De Lerma', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3676, N'Salta', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3677, N'San Antonio De Los Cobres', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3678, N'San Carlos', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3679, N'San José De Metán', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3680, N'San Ramón De La Nueva Orán', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3681, N'Santa Victoria Este', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3682, N'Santa Victoria Oeste', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3683, N'Seclantas', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3684, N'Tartagal', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3685, N'Tolar Gande', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3686, N'Urundel', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3687, N'Vaqueros', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3688, N'Villa San Lorenzo', 16)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3689, N'25 De Mayo', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3690, N'9 De Julio', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3691, N'Albardon', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3692, N'Angaco', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3693, N'Calingasta', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3694, N'Caucete', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3695, N'Chimbas', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3696, N'Iglesia', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3697, N'Jachal', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3698, N'Pocito', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3699, N'Rawson', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3700, N'Rivadavia', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3701, N'San Juan', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3702, N'San Martin', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3703, N'Santa Lucia', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3704, N'Sarmiento', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3705, N'Ullum', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3706, N'Valle Fertil', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3707, N'Zonda', 17)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3708, N'28 De Noviembre', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3709, N'Caleta Olivia', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3710, N'Cañadon Seco', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3711, N'Comandante Luis Piedrabuena', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3712, N'El Calafate', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3713, N'El Chalten', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3714, N'Gobernador Gregores', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3715, N'Hipolito Irigoyen', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3716, N'Jaramillo', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3717, N'Koluel Kaike', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3718, N'Las Heras', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3719, N'Los Antiguos', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3720, N'Perito Moreno', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3721, N'Pico Truncado', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3722, N'Puerto Deseado', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3723, N'Puerto San Julian', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3724, N'Puerto Santa Cruz', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3725, N'Rio Gallegos', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3726, N'Rio Turbio', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3727, N'Tres Lagos', 19)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3728, N'Acebal', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3729, N'Aguara Grande', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3730, N'Albarellos', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3731, N'Alcorta', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3732, N'Aldao', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3733, N'Aldao ( C )', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3734, N'Alejandra', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3735, N'Alvarez', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3736, N'Alvear', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3737, N'Ambrosetti', 20)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3738, N'Amenabar', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3739, N'Angelica', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3740, N'Angeloni', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3741, N'Arequito', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3742, N'Arminda', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3743, N'Armstrong', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3744, N'Arocena', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3745, N'Aron Castellanos', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3746, N'Arroyo Aguiar', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3747, N'Arroyo Ceibal', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3748, N'Arroyo Leyes', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3749, N'Arroyo Seco', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3750, N'Arrufo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3751, N'Arteaga', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3752, N'Ataliva', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3753, N'Aurelia', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3754, N'Avellaneda', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3755, N'Barrancas', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3756, N'Bauer Y Sigel', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3757, N'Bella Italia', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3758, N'Berabevu', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3759, N'Berna', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3760, N'Bernardo De Irigoyen', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3761, N'Bigand', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3762, N'Bombal', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3763, N'Bouquet', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3764, N'Bustinza', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3765, N'Cabal', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3766, N'Cacique Ariacaiquin', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3767, N'Cafferata', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3768, N'Calchaqui', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3769, N'Campo Andino', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3770, N'Campo Piaggio', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3771, N'Cañada De Gomez', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3772, N'Cañada Del Ucle', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3773, N'Cañada Ombu', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3774, N'Cañada Rica', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3775, N'Cañada Rosquin', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3776, N'Candioti', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3777, N'Capitan Bermudez', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3778, N'Capivara', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3779, N'Carcaraña', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3780, N'Carlos Pellegrini', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3781, N'Carmen', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3782, N'Carmen Del Sauce', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3783, N'Carreras', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3784, N'Carrizales', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3785, N'Casalegno', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3786, N'Casas', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3787, N'Casilda', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3788, N'Castelar', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3789, N'Castellanos', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3790, N'Cavour', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3791, N'Cayasta', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3792, N'Cayastacito', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3793, N'Centeno', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3794, N'Cepeda', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3795, N'Ceres', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3796, N'Chabas', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3797, N'Chañar Ladeado', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3798, N'Chapuy', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3799, N'Chovet', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3800, N'Christophersen', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3801, N'Classon', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3802, N'Clucellas', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3803, N'Colonia Ana', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3804, N'Colonia Belgrano', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3805, N'Colonia Bicha', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3806, N'Colonia Bigand', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3807, N'Colonia Bossi', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3808, N'Colonia Cello', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3809, N'Colonia Dolores', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3810, N'Colonia Duran', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3811, N'Colonia Iturraspe', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3812, N'Colonia Margarita', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3813, N'Colonia Mascias', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3814, N'Colonia Raquel', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3815, N'Colonia Rosa', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3816, N'Colonia San Jose', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3817, N'Constanza', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3818, N'Coronda', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3819, N'Coronel Arnold', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3820, N'Coronel Bogado', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3821, N'Coronel Dominguez', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3822, N'Coronel Fraga', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3823, N'Correa', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3824, N'Crespo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3825, N'Crispi', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3826, N'Cululu', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3827, N'Curupaity', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3828, N'Desvio Arijon', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3829, N'Diego De Alvear', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3830, N'Dos Rosas Y La Legua', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3831, N'Egusquiza', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3832, N'El Araza', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3833, N'El Rabon', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3834, N'El Sombrerito', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3835, N'El Trebol', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3836, N'Elisa', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3837, N'Elortondo', 20)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3838, N'Emilia', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3839, N'Empalme San Carlos', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3840, N'Empalme Villa Constitucion', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3841, N'Esmeralda', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3842, N'Esperanza', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3843, N'Estacion Clucellas', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3844, N'Estacion Diaz', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3845, N'Esteban Rams', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3846, N'Esther', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3847, N'Eusebia Y Carolina', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3848, N'Eustolia', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3849, N'Felicia', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3850, N'Fidela', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3851, N'Fighiera', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3852, N'Firmat', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3853, N'Florencia', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3854, N'Fortin Olmos', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3855, N'Franck', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3856, N'Fray Luis Beltran', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3857, N'Frontera', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3858, N'Fuentes', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3859, N'Funes', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3860, N'G- Perez De Denis - El Noche', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3861, N'Gaboto', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3862, N'Galisteo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3863, N'Galvez', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3864, N'Garabato', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3865, N'Garibaldi', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3866, N'Gato Colorado', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3867, N'General Gelly', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3868, N'General Lagos', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3869, N'Gessler', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3870, N'Godeken', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3871, N'Godoy', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3872, N'Golondrina', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3873, N'Granadero Baigorria', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3874, N'Grutly', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3875, N'Guadalupe Norte', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3876, N'Helvecia', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3877, N'Hersilia', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3878, N'Hipatia', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3879, N'Huanqueros', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3880, N'Hugentobler', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3881, N'Hughes', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3882, N'Humberto Primo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3883, N'Humboldt', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3884, N'Ibarlucea', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3885, N'Ingeniero Chanourdie', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3886, N'Intiyaco', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3887, N'Irigoyen', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3888, N'Ituzaingo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3889, N'Jacinto L. Arauz', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3890, N'Josefina', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3891, N'Juan Bernabé Molina', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3892, N'Juan De Garay', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3893, N'Juncal', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3894, N'La Brava', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3895, N'La Cabral', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3896, N'La Camila', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3897, N'La Chispa', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3898, N'La Clara', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3899, N'La Criolla', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3900, N'La Gallareta', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3901, N'La Lucila', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3902, N'La Pelada', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3903, N'La Penca Y Caraguata', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3904, N'La Rubia', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3905, N'La Sarita', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3906, N'La Vanguardia', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3907, N'Labordeboy', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3908, N'Laguna Paiva', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3909, N'Landeta', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3910, N'Lanteri', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3911, N'Larrechea', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3912, N'Las Avispas', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3913, N'Las Bandurrias', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3914, N'Las Garzas', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3915, N'Las Palmeras', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3916, N'Las Parejas', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3917, N'Las Petacas', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3918, N'Las Rosas', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3919, N'Las Toscas', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3920, N'Las Tunas', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3921, N'Lazzarino', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3922, N'Lehmann', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3923, N'Llambi Campbell', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3924, N'Logroño', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3925, N'Loma Alta', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3926, N'Lopez', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3927, N'Los Amores', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3928, N'Los Cardos', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3929, N'Los Laureles', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3930, N'Los Molinos', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3931, N'Los Quirquinchos', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3932, N'Lucio V. Lopez', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3933, N'Luis Palacios', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3934, N'Maciel', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3935, N'Maggiolo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3936, N'Malabrigo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3937, N'Marcelino Escalada', 20)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3938, N'Margarita', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3939, N'Maria Juana', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3940, N'Maria Luisa', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3941, N'Maria Susana', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3942, N'Maria Teresa', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3943, N'Matilde', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3944, N'Maua', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3945, N'Maximo Paz', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3946, N'Melincue', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3947, N'Miguel Torres', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3948, N'Moises Ville', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3949, N'Monigotes', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3950, N'Monje', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3951, N'Monte Oscuridad', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3952, N'Monte Vera', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3953, N'Montefiore', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3954, N'Montes De Oca', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3955, N'Murphy', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3956, N'Ñanducita', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3957, N'Nare', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3958, N'Nelson', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3959, N'Nicanor Molinas', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3960, N'Nuevo Torino', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3961, N'Oliveros', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3962, N'Palacios', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3963, N'Pavon', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3964, N'Pavon Arriba', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3965, N'Pedro Gomez Cello', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3966, N'Perez', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3967, N'Peyrano', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3968, N'Piamonte', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3969, N'Pilar', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3970, N'Piñero', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3971, N'Portugalete', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3972, N'Pozo Borrado', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3973, N'Presidente Roca', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3974, N'Progreso', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3975, N'Providencia', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3976, N'Pto.General San Martin', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3977, N'Pueblo Andino', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3978, N'Pueblo Esther', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3979, N'Pueblo Marini', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3980, N'Pueblo Muñoz', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3981, N'Pueblo San Bernardo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3982, N'Pueblo Uranga', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3983, N'Pujato', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3984, N'Pujato Norte', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3985, N'Rafaela', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3986, N'Ramayon', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3987, N'Ramona', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3988, N'Reconquista', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3989, N'Recreo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3990, N'Ricardone', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3991, N'Rivadavia', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3992, N'Roldan', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3993, N'Romang', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3994, N'Rosario', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3995, N'Rueda', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3996, N'Rufino', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3997, N'Sa Pereira', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3998, N'Saguier', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (3999, N'Saladero Mariano Cabal', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4000, N'Salto Grande', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4001, N'San Agustin', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4002, N'San Antonio', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4003, N'San Antonio De Obligado', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4004, N'San Bernardo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4005, N'San Carlos Centro', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4006, N'San Carlos Norte', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4007, N'San Carlos Sud', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4008, N'San Cristobal', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4009, N'San Eduardo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4010, N'San Eugenio', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4011, N'San Fabian', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4012, N'San Francisco De Santa Fe', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4013, N'San Genaro', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4014, N'San Genaro Norte', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4015, N'San Gregorio', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4016, N'San Guillermo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4017, N'San Javier', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4018, N'San Jeronimo Del Sauce', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4019, N'San Jeronimo Norte', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4020, N'San Jeronimo Sud', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4021, N'San Jorge', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4022, N'San Jose De La Esquina', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4023, N'San Jose Del Rincon', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4024, N'San Justo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4025, N'San Lorenzo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4026, N'San Mariano', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4027, N'San Martín De Las Escobas', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4028, N'San Martin Norte', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4029, N'San Vicente', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4030, N'Sancti Spiritu', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4031, N'Sanford', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4032, N'Santa Clara De Buena Vista', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4033, N'Santa Clara De Saguier', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4034, N'Santa Fe', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4035, N'Santa Isabel', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4036, N'Santa Margarita', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4037, N'Santa Maria Centro', 20)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4038, N'Santa Maria Norte', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4039, N'Santa Rosa', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4040, N'Santa Teresa', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4041, N'Santo Domingo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4042, N'Santo Tome', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4043, N'Santurce', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4044, N'Sargento Cabral', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4045, N'Sarmiento', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4046, N'Sastre', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4047, N'Sauce Viejo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4048, N'Serodino', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4049, N'Silva', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4050, N'Soldini', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4051, N'Soledad', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4052, N'Soutomayor', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4053, N'Suardi', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4054, N'Sunchales', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4055, N'Susana', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4056, N'Tacuarendi', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4057, N'Tacural', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4058, N'Tacurales', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4059, N'Tartagal', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4060, N'Teodelina', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4061, N'Theobald', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4062, N'Timbues - Jesus Maria', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4063, N'Toba', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4064, N'Tortugas', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4065, N'Tostado', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4066, N'Totoras', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4067, N'Traill', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4068, N'Venado Tuerto', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4069, N'Vera', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4070, N'Vera Y Pintado', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4071, N'Videla', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4072, N'Vila', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4073, N'Villa Amelia', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4074, N'Villa Ana', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4075, N'Villa Cañas', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4076, N'Villa Constitucion', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4077, N'Villa Eloisa', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4078, N'Villa Goberanador Galvez', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4079, N'Villa Guillermina', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4080, N'Villa Minetti', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4081, N'Villa Mugueta', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4082, N'Villa Ocampo', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4083, N'Villa San Jose', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4084, N'Villa Saralegui', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4085, N'Villa Trinidad', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4086, N'Villada', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4087, N'Virginia', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4088, N'Wheelwright', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4089, N'Zaballa', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4090, N'Zenon Pereyra', 20)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4091, N'Añatuya', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4092, N'Arraga', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4093, N'Bandera', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4094, N'Bandera Bajada', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4095, N'Beltran', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4096, N'Bobadal', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4097, N'Brea Pozo', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4098, N'Campo Gallo', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4099, N'Chilca Juliana', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4100, N'Choya', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4101, N'Clodomira', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4102, N'Colonia Alpina', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4103, N'Colonia Dora', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4104, N'El Charco', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4105, N'El Mojon', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4106, N'El Simbolar', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4107, N'Fernandez', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4108, N'Fortin Inca', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4109, N'Frias', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4110, N'Garza', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4111, N'Gramilla', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4112, N'Guardia Escolta', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4113, N'Herrera', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4114, N'Icaño', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4115, N'Ingeniero Forres', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4116, N'Juan F. Ibarra', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4117, N'La Banda', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4118, N'La Cañada', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4119, N'Laprida', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4120, N'Lavalle', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4121, N'Loreto', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4122, N'Los Juries', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4123, N'Los Nuñez', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4124, N'Los Pirpintos', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4125, N'Los Quirogas', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4126, N'Los Telares', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4127, N'Lugones', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4128, N'Malbrán', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4129, N'Matara', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4130, N'Medellin', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4131, N'Monte Quemado', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4132, N'Nueva Esperanza', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4133, N'Nueva Francia', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4134, N'Palo Negro', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4135, N'Pampa De Los Guanacos', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4136, N'Pinto', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4137, N'Pozo Hondo', 21)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4138, N'Quimili', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4139, N'Real Sayana', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4140, N'Sachayoi', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4141, N'San Pedro De Guazaya', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4142, N'Santiago Del Estero', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4143, N'Selva', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4144, N'Simbolar', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4145, N'Sol De Julio', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4146, N'Sumampa', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4147, N'Suncho Corral', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4148, N'Taboada', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4149, N'Tapso', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4150, N'Termas De Rio Hondo', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4151, N'Tintina', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4152, N'Tomas Young', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4153, N'Vilelas', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4154, N'Villa Atamisqui', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4155, N'Villa La Punta', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4156, N'Villa Ojo De Agua', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4157, N'Villa Rio Hondo', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4158, N'Villa Salavina', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4159, N'Villa Union', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4160, N'Vilmer', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4161, N'Weisburd', 21)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4162, N'Río Grande', 22)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4163, N'Tolhuin', 22)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4164, N'Ushuaia', 22)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4165, N'7 De Abril', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4166, N'Acheral', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4167, N'Agua Dulce Y La Soledad', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4168, N'Aguilares', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4169, N'Alderetes', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4170, N'Alpachiri Y El Molino', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4171, N'Alto Verde Y Los Guchea', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4172, N'Amaicha Del Valle', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4173, N'Amberes', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4174, N'Ancajuli', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4175, N'Arcadia', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4176, N'Atahona', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4177, N'Banda Del Río Salí', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4178, N'Bella Vista', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4179, N'Buena Vista', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4180, N'Burruyacú', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4181, N'Capitán Cáceres', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4182, N'Cevil Redondo', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4183, N'Choromoro', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4184, N'Ciudacita', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4185, N'Colalao Del Valle', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4186, N'Colombres', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4187, N'Comuna De Yerba Buena', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4188, N'Concepción', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4189, N'Delfín Gallo', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4190, N'El Bracho Y El Cevilar', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4191, N'El Cadillal', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4192, N'El Cercado', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4193, N'El Chañar', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4194, N'El Manantial', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4195, N'El Mojón', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4196, N'El Mollar', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4197, N'El Naranjito', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4198, N'El Naranjo Y El Sunchal', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4199, N'El Polear', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4200, N'El Puestito', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4201, N'El Sacrificio', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4202, N'El Timbo', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4203, N'Escaba', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4204, N'Esquina Y Mancopa', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4205, N'Estación Aráoz Y Tacanas', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4206, N'Famaillá', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4207, N'Gastona Y Belicha', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4208, N'Gobernador Garmendia', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4209, N'Gobernador Piedrabuena', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4210, N'Graneros', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4211, N'Huasa Pampa', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4212, N'Juan Bautista Alberdi', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4213, N'La Cocha', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4214, N'La Esperanza', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4215, N'La Florida Y Luisiana', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4216, N'La Ramada Y La Cruz', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4217, N'La Trinidad', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4218, N'Lamadrid', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4219, N'Las Cejas', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4220, N'Las Talas', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4221, N'Las Talitas', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4222, N'León Rouges Y Santa Rosa', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4223, N'Los Bulacio Y Los Villagra', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4224, N'Los Gómez', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4225, N'Los Nogales', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4226, N'Los Pereyra', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4227, N'Los Pérez', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4228, N'Los Puestos', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4229, N'Los Ralos', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4230, N'Los Sarmientos Y La Tipa', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4231, N'Los Sosa', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4232, N'Lules', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4233, N'Manuel García Fernández', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4234, N'Manuela Pedraza', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4235, N'Medina', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4236, N'Monte Bello', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4237, N'Monteagudo', 23)
GO
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4238, N'Monteros', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4239, N'Pampa Mayo', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4240, N'Quilmes Y Los Sueldos', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4241, N'Raco', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4242, N'Ranchillos Y San Miguel', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4243, N'Río Chico Y Nueva Trinidad', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4244, N'Río Colorado', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4245, N'Río Seco', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4246, N'Rumi Punco', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4247, N'San Andrés', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4248, N'San Felipe Y Santa Bárbara', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4249, N'San Ignacio', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4250, N'San Javier', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4251, N'San José De La Cocha', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4252, N'San Miguel De Tucumán', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4253, N'San Pablo Y Villa Nougués', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4254, N'San Pedro De Colalao', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4255, N'San Pedro Y San Antonio', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4256, N'Santa Ana', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4257, N'Santa Cruz Y La Tuna', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4258, N'Santa Lucía', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4259, N'Santa Rosa De Leales Y Laguna Blanca', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4260, N'Sargento Moya', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4261, N'Simoca', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4262, N'Soldado Maldonado', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4263, N'Taco Ralo', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4264, N'Tafí Del Valle', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4265, N'Tafí Viejo', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4266, N'Tapia', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4267, N'Teniente Berdina', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4268, N'Trancas', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4269, N'Villa Belgrano', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4270, N'Villa Benjamín Aráoz Y El Tajamar', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4271, N'Villa Chicligasta', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4272, N'Villa De Leales', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4273, N'Villa Padre Monti', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4274, N'Villa Quinteros', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4275, N'Yanima', 23)
INSERT [dbo].[Localidades] ([Id_Localidad], [NombreLocalidad], [Id_Provincia]) VALUES (4276, N'Yerba Buena', 23)
SET IDENTITY_INSERT [dbo].[Localidades] OFF
SET IDENTITY_INSERT [dbo].[MateriasPrimas] ON 

INSERT [dbo].[MateriasPrimas] ([id_MPrima], [CodigoMateriaPrima], [Descripcion], [Categoria], [Proveedor], [Cantidad], [CostoUnitario], [CantMin]) VALUES (5, 1, N'Poliestireno Crist', 9, 2, 0, CAST(241.20 AS Decimal(18, 2)), 100)
INSERT [dbo].[MateriasPrimas] ([id_MPrima], [CodigoMateriaPrima], [Descripcion], [Categoria], [Proveedor], [Cantidad], [CostoUnitario], [CantMin]) VALUES (6, 2, N'Poliestireno AI', 10, 2, 400, CAST(191.60 AS Decimal(18, 2)), 200)
INSERT [dbo].[MateriasPrimas] ([id_MPrima], [CodigoMateriaPrima], [Descripcion], [Categoria], [Proveedor], [Cantidad], [CostoUnitario], [CantMin]) VALUES (7, 3, N'Planchas de Carton', 13, 3, 150, CAST(99.70 AS Decimal(18, 2)), 150)
INSERT [dbo].[MateriasPrimas] ([id_MPrima], [CodigoMateriaPrima], [Descripcion], [Categoria], [Proveedor], [Cantidad], [CostoUnitario], [CantMin]) VALUES (8, 4, N'Master C', 14, 2, 0, CAST(201.20 AS Decimal(18, 2)), 100)
INSERT [dbo].[MateriasPrimas] ([id_MPrima], [CodigoMateriaPrima], [Descripcion], [Categoria], [Proveedor], [Cantidad], [CostoUnitario], [CantMin]) VALUES (9, 5, N'Master M', 15, 2, 300, CAST(200.32 AS Decimal(18, 2)), 100)
INSERT [dbo].[MateriasPrimas] ([id_MPrima], [CodigoMateriaPrima], [Descripcion], [Categoria], [Proveedor], [Cantidad], [CostoUnitario], [CantMin]) VALUES (10, 6, N'Master Y', 16, 2, 150, CAST(181.55 AS Decimal(18, 2)), 100)
INSERT [dbo].[MateriasPrimas] ([id_MPrima], [CodigoMateriaPrima], [Descripcion], [Categoria], [Proveedor], [Cantidad], [CostoUnitario], [CantMin]) VALUES (11, 7, N'Master B', 17, 2, 0, CAST(230.10 AS Decimal(18, 2)), 100)
INSERT [dbo].[MateriasPrimas] ([id_MPrima], [CodigoMateriaPrima], [Descripcion], [Categoria], [Proveedor], [Cantidad], [CostoUnitario], [CantMin]) VALUES (12, 8, N'Planca de Carton Abrillantado', 13, 3, 14, CAST(120.00 AS Decimal(18, 2)), 50)
INSERT [dbo].[MateriasPrimas] ([id_MPrima], [CodigoMateriaPrima], [Descripcion], [Categoria], [Proveedor], [Cantidad], [CostoUnitario], [CantMin]) VALUES (13, 9, N'Tambor de Resina', 13, 2, 0, CAST(1191.90 AS Decimal(18, 2)), 4)
SET IDENTITY_INSERT [dbo].[MateriasPrimas] OFF
SET IDENTITY_INSERT [dbo].[Movimientos] ON 

INSERT [dbo].[Movimientos] ([id_Movimiento], [Detalle], [Importe], [Fecha], [id_CuentaCorriente], [TipodeMovimiento]) VALUES (14, N'Venta Realizada el: 12/01/2017 0:00:00 al Cliente: Sancor por un Importe de:  234,00.', CAST(234.00 AS Decimal(18, 2)), CAST(N'2017-01-12 18:37:39.000' AS DateTime), 6, N'Debito')
INSERT [dbo].[Movimientos] ([id_Movimiento], [Detalle], [Importe], [Fecha], [id_CuentaCorriente], [TipodeMovimiento]) VALUES (16, N'Venta Realizada el: 12/01/2017 0:00:00 al Cliente: Grido por un Importe de:  1475,00.', CAST(1475.00 AS Decimal(18, 2)), CAST(N'2017-01-12 18:48:08.000' AS DateTime), 5, N'Debito')
INSERT [dbo].[Movimientos] ([id_Movimiento], [Detalle], [Importe], [Fecha], [id_CuentaCorriente], [TipodeMovimiento]) VALUES (17, N'Venta Realizada el: 12/01/2017 0:00:00 al Cliente: La Serenisima por un Importe de:  1770,00.', CAST(1770.00 AS Decimal(18, 2)), CAST(N'2017-01-12 18:52:27.000' AS DateTime), 7, N'Debito')
INSERT [dbo].[Movimientos] ([id_Movimiento], [Detalle], [Importe], [Fecha], [id_CuentaCorriente], [TipodeMovimiento]) VALUES (18, N'Pago de 1475 pesos.', CAST(1475.00 AS Decimal(18, 2)), CAST(N'2017-01-19 16:57:05.073' AS DateTime), 5, N'Credito')
INSERT [dbo].[Movimientos] ([id_Movimiento], [Detalle], [Importe], [Fecha], [id_CuentaCorriente], [TipodeMovimiento]) VALUES (19, N'Venta Realizada el: 07/03/2017 0:00:00 al Cliente: Sancor por un Importe de:  29,50.', CAST(30.00 AS Decimal(18, 2)), CAST(N'2017-03-07 19:57:03.000' AS DateTime), 6, N'Debito')
SET IDENTITY_INSERT [dbo].[Movimientos] OFF
SET IDENTITY_INSERT [dbo].[NotasCreditos] ON 

INSERT [dbo].[NotasCreditos] ([id_NotaCredito], [id_Cliente], [Detalle], [Fecha], [Importe]) VALUES (1, 9, N'Nota de credito creada por la anulacion de la Venta Nº 50.', CAST(N'2016-12-19 14:46:44.563' AS DateTime), CAST(260.00 AS Decimal(18, 2)))
INSERT [dbo].[NotasCreditos] ([id_NotaCredito], [id_Cliente], [Detalle], [Fecha], [Importe]) VALUES (2, 9, N'Nota de credito creada por la anulacion de la Venta Nº 51.', CAST(N'2016-12-19 14:57:05.440' AS DateTime), CAST(130.00 AS Decimal(18, 2)))
INSERT [dbo].[NotasCreditos] ([id_NotaCredito], [id_Cliente], [Detalle], [Fecha], [Importe]) VALUES (3, 7, N'Nota de credito creada por la anulacion de la Venta Nº 52.', CAST(N'2016-12-19 15:17:36.927' AS DateTime), CAST(39.00 AS Decimal(18, 2)))
INSERT [dbo].[NotasCreditos] ([id_NotaCredito], [id_Cliente], [Detalle], [Fecha], [Importe]) VALUES (4, 9, N'Nota de credito creada por la anulacion de la Venta Nº 53.', CAST(N'2016-12-19 15:24:06.607' AS DateTime), CAST(260.00 AS Decimal(18, 2)))
INSERT [dbo].[NotasCreditos] ([id_NotaCredito], [id_Cliente], [Detalle], [Fecha], [Importe]) VALUES (5, 9, N'Nota de credito creada por la anulacion de la Venta Nº 55.', CAST(N'2016-12-19 15:36:35.700' AS DateTime), CAST(130.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[NotasCreditos] OFF
SET IDENTITY_INSERT [dbo].[Pagos] ON 

INSERT [dbo].[Pagos] ([id_Pago], [Fecha], [Importe], [id_Cliente], [Detalle], [id_Venta]) VALUES (2, CAST(N'2017-01-19 16:57:05.073' AS DateTime), CAST(1475.00 AS Decimal(18, 2)), 7, N'Pago de 1475 pesos.', 58)
SET IDENTITY_INSERT [dbo].[Pagos] OFF
SET IDENTITY_INSERT [dbo].[Pedidos] ON 

INSERT [dbo].[Pedidos] ([id_Pedido], [FormadeEnvio], [FormadePago], [Proveedor], [Total], [Fecha], [Estado], [Usuario], [Operacion], [FechaOperacion], [EQUIPO]) VALUES (21, 3, 3, 3, CAST(1680.00 AS Decimal(18, 2)), CAST(N'2016-12-20 20:13:25.277' AS DateTime), N'Finalizado', N'Admin', N'Modificar', CAST(N'2017-01-05 19:39:19.290' AS DateTime), N'DESKTOP-1MDN7GM')
INSERT [dbo].[Pedidos] ([id_Pedido], [FormadeEnvio], [FormadePago], [Proveedor], [Total], [Fecha], [Estado], [Usuario], [Operacion], [FechaOperacion], [EQUIPO]) VALUES (22, 3, 3, 2, CAST(163969.00 AS Decimal(18, 2)), CAST(N'2017-01-05 19:34:51.600' AS DateTime), N'Finalizado', N'Admin', N'Modificar', CAST(N'2017-01-05 19:39:53.610' AS DateTime), N'DESKTOP-1MDN7GM')
INSERT [dbo].[Pedidos] ([id_Pedido], [FormadeEnvio], [FormadePago], [Proveedor], [Total], [Fecha], [Estado], [Usuario], [Operacion], [FechaOperacion], [EQUIPO]) VALUES (23, 3, 3, 3, CAST(14955.00 AS Decimal(18, 2)), CAST(N'2017-01-05 19:36:34.823' AS DateTime), N'Finalizado', N'Admin', N'Modificar', CAST(N'2017-01-05 19:40:08.917' AS DateTime), N'DESKTOP-1MDN7GM')
SET IDENTITY_INSERT [dbo].[Pedidos] OFF
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([id_Producto], [Descripcion], [CostoUnitario], [id_Categoria], [Cantidad], [CantMin]) VALUES (3, N'Balde de Carton', CAST(13.00 AS Decimal(18, 2)), 5, 0, 10)
INSERT [dbo].[Productos] ([id_Producto], [Descripcion], [CostoUnitario], [id_Categoria], [Cantidad], [CantMin]) VALUES (4, N'Vasos Plasticos', CAST(8.00 AS Decimal(18, 2)), 5, 195, 100)
SET IDENTITY_INSERT [dbo].[Productos] OFF
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([id_Proveedor], [Nombre], [Telefono], [Cuit], [Email], [Direccion_N], [Direccion_C]) VALUES (2, N'Petrobras S.A', N'0114460000', 23654748943, N'PampaEnergia@PetroPampa.com', N'286', N'Rivadavia')
INSERT [dbo].[Proveedores] ([id_Proveedor], [Nombre], [Telefono], [Cuit], [Email], [Direccion_N], [Direccion_C]) VALUES (3, N'Papel Misionero', N'3763096888', 32455663456, N'PapelMisionero@hotmail.com', N'45', N'Jilguero')
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (1, N'Buenos Aires')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (2, N'Catamarca')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (3, N'Chaco')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (4, N'Chubut')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (5, N'Cordoba')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (6, N'Corrientes')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (7, N'Entre Rios')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (8, N'Formosa')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (9, N'Jujuy')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (10, N'La Pampa')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (11, N'La Rioja')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (12, N'Mendoza')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (13, N'Misiones')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (14, N'Neuquen')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (15, N'Rio Negro')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (16, N'Salta')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (17, N'San Juan')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (18, N'San Luis')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (19, N'Santa Cruz')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (20, N'Santa Fe')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (21, N'Santiago del Estero')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (22, N'Tierra del Fuego')
INSERT [dbo].[Provincias] ([Id_Provincia], [NombreProvincia]) VALUES (23, N'Tucuman')
SET IDENTITY_INSERT [dbo].[Remitos] ON 

INSERT [dbo].[Remitos] ([id_Remito], [Proveedor], [Fecha], [Total], [NumeroOrdenC]) VALUES (1032, 3, CAST(N'2017-01-05 19:38:47.680' AS DateTime), CAST(1680.00 AS Decimal(18, 2)), 21)
INSERT [dbo].[Remitos] ([id_Remito], [Proveedor], [Fecha], [Total], [NumeroOrdenC]) VALUES (1033, 2, CAST(N'2017-01-05 19:39:24.530' AS DateTime), CAST(163969.00 AS Decimal(18, 2)), 22)
INSERT [dbo].[Remitos] ([id_Remito], [Proveedor], [Fecha], [Total], [NumeroOrdenC]) VALUES (1034, 3, CAST(N'2017-01-05 19:39:57.227' AS DateTime), CAST(14955.00 AS Decimal(18, 2)), 23)
SET IDENTITY_INSERT [dbo].[Remitos] OFF
SET IDENTITY_INSERT [dbo].[SituacionesFiscales] ON 

INSERT [dbo].[SituacionesFiscales] ([id_SituacionFiscal], [Descripcion]) VALUES (3, N'Monotributista')
INSERT [dbo].[SituacionesFiscales] ([id_SituacionFiscal], [Descripcion]) VALUES (4, N'Responsable Inscripto')
SET IDENTITY_INSERT [dbo].[SituacionesFiscales] OFF
SET IDENTITY_INSERT [dbo].[Ventas] ON 

INSERT [dbo].[Ventas] ([id_Venta], [id_Cliente], [Fecha], [Total], [Estado], [id_FormaEnvio], [id_FormadePago], [Detalle]) VALUES (56, 8, CAST(N'2017-01-12 18:37:39.000' AS DateTime), CAST(234.00 AS Decimal(18, 2)), N'Relizado', 3, 3, N'Venta Realizada el: 12/01/2017 0:00:00 al Cliente: Sancor por un Importe de:  234,00.')
INSERT [dbo].[Ventas] ([id_Venta], [id_Cliente], [Fecha], [Total], [Estado], [id_FormaEnvio], [id_FormadePago], [Detalle]) VALUES (58, 7, CAST(N'2017-01-12 18:48:08.000' AS DateTime), CAST(1475.00 AS Decimal(18, 2)), N'Finalizado', 3, 3, N'Venta Realizada el: 12/01/2017 0:00:00 al Cliente: Grido por un Importe de:  1475,00.')
INSERT [dbo].[Ventas] ([id_Venta], [id_Cliente], [Fecha], [Total], [Estado], [id_FormaEnvio], [id_FormadePago], [Detalle]) VALUES (59, 9, CAST(N'2017-01-12 18:52:27.000' AS DateTime), CAST(1770.00 AS Decimal(18, 2)), N'Relizado', 3, 3, N'Venta Realizada el: 12/01/2017 0:00:00 al Cliente: La Serenisima por un Importe de:  1770,00.')
INSERT [dbo].[Ventas] ([id_Venta], [id_Cliente], [Fecha], [Total], [Estado], [id_FormaEnvio], [id_FormadePago], [Detalle]) VALUES (60, 8, CAST(N'2017-03-07 19:57:03.000' AS DateTime), CAST(30.00 AS Decimal(18, 2)), N'Relizado', 4, 3, N'Venta Realizada el: 07/03/2017 0:00:00 al Cliente: Sancor por un Importe de:  29,50.')
SET IDENTITY_INSERT [dbo].[Ventas] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ_Categorias_Nombre]    Script Date: 05/02/2019 15:57:39 ******/
ALTER TABLE [dbo].[Categorias] ADD  CONSTRAINT [UQ_Categorias_Nombre] UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ_FormasdeEnvios_Estado]    Script Date: 05/02/2019 15:57:39 ******/
ALTER TABLE [dbo].[FormasdeEnvios] ADD  CONSTRAINT [UQ_FormasdeEnvios_Estado] UNIQUE NONCLUSTERED 
(
	[Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ_FormasdePagos_Nombre]    Script Date: 05/02/2019 15:57:39 ******/
ALTER TABLE [dbo].[FormasdePagos] ADD  CONSTRAINT [UQ_FormasdePagos_Nombre] UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ_MateriasPrimas_CodigoMateriaPrima]    Script Date: 05/02/2019 15:57:39 ******/
ALTER TABLE [dbo].[MateriasPrimas] ADD  CONSTRAINT [UQ_MateriasPrimas_CodigoMateriaPrima] UNIQUE NONCLUSTERED 
(
	[CodigoMateriaPrima] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Proveedores_Cuit]    Script Date: 05/02/2019 15:57:39 ******/
ALTER TABLE [dbo].[Proveedores] ADD  CONSTRAINT [UQ_Proveedores_Cuit] UNIQUE NONCLUSTERED 
(
	[Cuit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ_NombreProvincia]    Script Date: 05/02/2019 15:57:39 ******/
ALTER TABLE [dbo].[Provincias] ADD  CONSTRAINT [UQ_NombreProvincia] UNIQUE NONCLUSTERED 
(
	[NombreProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes]  WITH NOCHECK ADD  CONSTRAINT [FK_Clientes_id_Localidad] FOREIGN KEY([id_Localidad])
REFERENCES [dbo].[Localidades] ([Id_Localidad])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_id_Localidad]
GO
ALTER TABLE [dbo].[Clientes]  WITH NOCHECK ADD  CONSTRAINT [FK_Clientes_id_SituacionFiscal] FOREIGN KEY([id_SituacionFiscal])
REFERENCES [dbo].[SituacionesFiscales] ([id_SituacionFiscal])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_id_SituacionFiscal]
GO
ALTER TABLE [dbo].[CuentasCorrientes]  WITH NOCHECK ADD  CONSTRAINT [FK_CuentasCorrientes_id_Cliente] FOREIGN KEY([id_Cliente])
REFERENCES [dbo].[Clientes] ([id_Cliente])
GO
ALTER TABLE [dbo].[CuentasCorrientes] CHECK CONSTRAINT [FK_CuentasCorrientes_id_Cliente]
GO
ALTER TABLE [dbo].[DetallesPedidos]  WITH NOCHECK ADD  CONSTRAINT [FK_DetallesPedidos_MateriaPrima] FOREIGN KEY([MateriaPrima])
REFERENCES [dbo].[MateriasPrimas] ([id_MPrima])
GO
ALTER TABLE [dbo].[DetallesPedidos] CHECK CONSTRAINT [FK_DetallesPedidos_MateriaPrima]
GO
ALTER TABLE [dbo].[DetallesPedidos]  WITH NOCHECK ADD  CONSTRAINT [FK_DetallesPedidos_Pedido] FOREIGN KEY([Pedido])
REFERENCES [dbo].[Pedidos] ([id_Pedido])
GO
ALTER TABLE [dbo].[DetallesPedidos] CHECK CONSTRAINT [FK_DetallesPedidos_Pedido]
GO
ALTER TABLE [dbo].[DetallesRemitos]  WITH NOCHECK ADD  CONSTRAINT [FK_DetallesRemitos_MateriaPrima] FOREIGN KEY([MateriaPrima])
REFERENCES [dbo].[MateriasPrimas] ([id_MPrima])
GO
ALTER TABLE [dbo].[DetallesRemitos] CHECK CONSTRAINT [FK_DetallesRemitos_MateriaPrima]
GO
ALTER TABLE [dbo].[DetallesRemitos]  WITH NOCHECK ADD  CONSTRAINT [FK_DetallesRemitos_Remito] FOREIGN KEY([Remito])
REFERENCES [dbo].[Remitos] ([id_Remito])
GO
ALTER TABLE [dbo].[DetallesRemitos] CHECK CONSTRAINT [FK_DetallesRemitos_Remito]
GO
ALTER TABLE [dbo].[DetallesVentas]  WITH NOCHECK ADD  CONSTRAINT [FK_DetallesVentas_id_Producto] FOREIGN KEY([id_Producto])
REFERENCES [dbo].[Productos] ([id_Producto])
GO
ALTER TABLE [dbo].[DetallesVentas] CHECK CONSTRAINT [FK_DetallesVentas_id_Producto]
GO
ALTER TABLE [dbo].[DetallesVentas]  WITH NOCHECK ADD  CONSTRAINT [FK_DetallesVentas_id_Venta] FOREIGN KEY([id_Venta])
REFERENCES [dbo].[Ventas] ([id_Venta])
GO
ALTER TABLE [dbo].[DetallesVentas] CHECK CONSTRAINT [FK_DetallesVentas_id_Venta]
GO
ALTER TABLE [dbo].[Localidades]  WITH NOCHECK ADD  CONSTRAINT [FK_Provincias_IDProvincia] FOREIGN KEY([Id_Provincia])
REFERENCES [dbo].[Provincias] ([Id_Provincia])
GO
ALTER TABLE [dbo].[Localidades] CHECK CONSTRAINT [FK_Provincias_IDProvincia]
GO
ALTER TABLE [dbo].[MateriasPrimas]  WITH NOCHECK ADD  CONSTRAINT [FK_MateriasPrimas_Categoria] FOREIGN KEY([Categoria])
REFERENCES [dbo].[Categorias] ([id_Categoria])
GO
ALTER TABLE [dbo].[MateriasPrimas] CHECK CONSTRAINT [FK_MateriasPrimas_Categoria]
GO
ALTER TABLE [dbo].[MateriasPrimas]  WITH NOCHECK ADD  CONSTRAINT [FK_MateriasPrimas_Proveedor] FOREIGN KEY([Proveedor])
REFERENCES [dbo].[Proveedores] ([id_Proveedor])
GO
ALTER TABLE [dbo].[MateriasPrimas] CHECK CONSTRAINT [FK_MateriasPrimas_Proveedor]
GO
ALTER TABLE [dbo].[Movimientos]  WITH NOCHECK ADD  CONSTRAINT [FK_Movimientos_id_CuentaCorriente] FOREIGN KEY([id_CuentaCorriente])
REFERENCES [dbo].[CuentasCorrientes] ([id_CuentaCorriente])
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_id_CuentaCorriente]
GO
ALTER TABLE [dbo].[NotasCreditos]  WITH NOCHECK ADD  CONSTRAINT [FK_NotasCreditos_id_Cliente] FOREIGN KEY([id_Cliente])
REFERENCES [dbo].[Clientes] ([id_Cliente])
GO
ALTER TABLE [dbo].[NotasCreditos] CHECK CONSTRAINT [FK_NotasCreditos_id_Cliente]
GO
ALTER TABLE [dbo].[Pagos]  WITH NOCHECK ADD  CONSTRAINT [FK_Pagos_id_Cliente] FOREIGN KEY([id_Cliente])
REFERENCES [dbo].[Clientes] ([id_Cliente])
GO
ALTER TABLE [dbo].[Pagos] CHECK CONSTRAINT [FK_Pagos_id_Cliente]
GO
ALTER TABLE [dbo].[Pagos]  WITH NOCHECK ADD  CONSTRAINT [FK_Pagos_id_Venta] FOREIGN KEY([id_Venta])
REFERENCES [dbo].[Ventas] ([id_Venta])
GO
ALTER TABLE [dbo].[Pagos] CHECK CONSTRAINT [FK_Pagos_id_Venta]
GO
ALTER TABLE [dbo].[Pedidos]  WITH NOCHECK ADD  CONSTRAINT [FK_Pedidos_FormadeEnvio] FOREIGN KEY([FormadeEnvio])
REFERENCES [dbo].[FormasdeEnvios] ([id_FormadeEnvio])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_FormadeEnvio]
GO
ALTER TABLE [dbo].[Pedidos]  WITH NOCHECK ADD  CONSTRAINT [FK_Pedidos_FormasdePago] FOREIGN KEY([FormadePago])
REFERENCES [dbo].[FormasdePagos] ([id_FormadePago])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_FormasdePago]
GO
ALTER TABLE [dbo].[Pedidos]  WITH NOCHECK ADD  CONSTRAINT [FK_Pedidos_Proveedor] FOREIGN KEY([Proveedor])
REFERENCES [dbo].[Proveedores] ([id_Proveedor])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Proveedor]
GO
ALTER TABLE [dbo].[Productos]  WITH NOCHECK ADD  CONSTRAINT [FK_Productos_id_Categoria] FOREIGN KEY([id_Categoria])
REFERENCES [dbo].[CategoriasProductos] ([id_Categoria])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_id_Categoria]
GO
ALTER TABLE [dbo].[Remitos]  WITH NOCHECK ADD  CONSTRAINT [FK__Remitos__NumeroO] FOREIGN KEY([NumeroOrdenC])
REFERENCES [dbo].[Pedidos] ([id_Pedido])
GO
ALTER TABLE [dbo].[Remitos] CHECK CONSTRAINT [FK__Remitos__NumeroO]
GO
ALTER TABLE [dbo].[Remitos]  WITH NOCHECK ADD  CONSTRAINT [FK_Remitos_Proveedor] FOREIGN KEY([Proveedor])
REFERENCES [dbo].[Proveedores] ([id_Proveedor])
GO
ALTER TABLE [dbo].[Remitos] CHECK CONSTRAINT [FK_Remitos_Proveedor]
GO
ALTER TABLE [dbo].[Ventas]  WITH NOCHECK ADD  CONSTRAINT [FK_Ventas_id_Cliente] FOREIGN KEY([id_Cliente])
REFERENCES [dbo].[Clientes] ([id_Cliente])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_id_Cliente]
GO
ALTER TABLE [dbo].[Ventas]  WITH NOCHECK ADD  CONSTRAINT [FK_Ventas_id_FormadePago] FOREIGN KEY([id_FormadePago])
REFERENCES [dbo].[FormasdePagos] ([id_FormadePago])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_id_FormadePago]
GO
ALTER TABLE [dbo].[Ventas]  WITH NOCHECK ADD  CONSTRAINT [FK_Ventas_id_FormaEnvio] FOREIGN KEY([id_FormaEnvio])
REFERENCES [dbo].[FormasdeEnvios] ([id_FormadeEnvio])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_id_FormaEnvio]
GO
USE [master]
GO
ALTER DATABASE [TrabajoFinal] SET  READ_WRITE 
GO
