# API-GestionClientesProductosUsuarios

## Descripción

Esta API proporciona un conjunto de operaciones para gestionar clientes, productos y usuarios en una aplicación. Permite realizar acciones como agregar, editar, eliminar y consultar la información de los clientes y productos, así como gestionar el acceso de los usuarios a través de autenticación y edición de su estado.

## Endpoints

### **Clientes**

- **GET /api/clientes**: Obtiene la lista de todos los clientes.
- **GET /api/clientes/{Cedula}**: Obtiene la información de un cliente específico basado en su cédula.
- **DELETE /api/clientes/{Cedula}**: Elimina un cliente específico basado en su cédula.
- **GET /api/clientes/cedula/{cedula}**: Busca un cliente utilizando su número de cédula.
- **POST /api/clientes/agregar**: Agrega un nuevo cliente.
- **PUT /api/clientes/Modificar**: Modifica la información de un cliente existente.

### **Productos**

- **GET /api/productos**: Obtiene la lista de todos los productos.
- **GET /api/productos/{CodigoInterno}**: Obtiene la información de un producto específico basado en su código interno.
- **DELETE /api/productos/{CodigoInterno}**: Elimina un producto específico basado en su código interno.
- **GET /api/productos/descripcion/{Descripcion}**: Busca productos basados en su descripción.
- **POST /api/productos/agregar**: Agrega un nuevo producto.
- **PUT /api/productos/Modificar**: Modifica la información de un producto existente.

### **Usuarios**

- **GET /api/Usuarios**: Obtiene la lista de todos los usuarios.
- **GET /api/Usuarios/Buscar/{Login}**: Busca un usuario basado en su login.
- **GET /api/Usuarios/AutenticarUsuario/{Login},{Password}**: Autentica un usuario mediante su login y contraseña.
- **POST /api/Usuarios/Agregar**: Agrega un nuevo usuario.
- **PUT /api/Usuarios/Editar/{Login}**: Modifica la información de un usuario basado en su login.
- **GET /api/Usuarios/Inactivar/{Login}**: Inactiva un usuario basado en su login.
