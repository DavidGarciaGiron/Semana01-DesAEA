use neptuno;

Create Procedure Usp_ListaProductos_Neptuno
as
Select IdProducto,NombreProducto,IdProveedor,
PrecioUnidad,Suspendido
from Productos

Create Procedure Usp_ListaClientes_Neptuno_2
@idCliente varchar(100)
as
Select idCliente,NombreContacto,Direccion,
Pais,Telefono
from Clientes where idcliente like '%'+@idCliente+'%'

Usp_ListaClientes_Neptuno_2 'B'