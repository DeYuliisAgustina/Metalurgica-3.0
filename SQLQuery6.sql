-- Estados de usuario
SET IDENTITY_INSERT EstadoUsuarios ON;
IF NOT EXISTS (SELECT * FROM EstadoUsuarios WHERE EstadoUsuarioId = 1)
    INSERT INTO EstadoUsuarios (EstadoUsuarioId, Nombre) VALUES (1, 'Activo');
IF NOT EXISTS (SELECT * FROM EstadoUsuarios WHERE EstadoUsuarioId = 2)
    INSERT INTO EstadoUsuarios (EstadoUsuarioId, Nombre) VALUES (2, 'Inactivo');
SET IDENTITY_INSERT EstadoUsuarios OFF;

-- Estados de grupo
SET IDENTITY_INSERT EstadoGrupos ON;
IF NOT EXISTS (SELECT * FROM EstadoGrupos WHERE EstadoGrupoId = 1)
    INSERT INTO EstadoGrupos (EstadoGrupoId, Nombre) VALUES (1, 'Activo');
IF NOT EXISTS (SELECT * FROM EstadoGrupos WHERE EstadoGrupoId = 2)
    INSERT INTO EstadoGrupos (EstadoGrupoId, Nombre) VALUES (2, 'Inactivo');
SET IDENTITY_INSERT EstadoGrupos OFF;

-- Componentes (Acciones)
SET IDENTITY_INSERT Componentes ON;

-- Acciones de Compras - Nota de Compra
IF NOT EXISTS (SELECT * FROM Componentes WHERE ComponenteId = 1)
    INSERT INTO Componentes (ComponenteId, Nombre, TipoComponente) 
    VALUES (1, 'Agregar Nota de Compra', 'Accion');

IF NOT EXISTS (SELECT * FROM Componentes WHERE ComponenteId = 2)
    INSERT INTO Componentes (ComponenteId, Nombre, TipoComponente) 
    VALUES (2, 'Modificar Nota de Compra', 'Accion');

IF NOT EXISTS (SELECT * FROM Componentes WHERE ComponenteId = 3)
    INSERT INTO Componentes (ComponenteId, Nombre, TipoComponente) 
    VALUES (3, 'Eliminar Nota de Compra', 'Accion');

-- Acciones de Compras - Proveedor
IF NOT EXISTS (SELECT * FROM Componentes WHERE ComponenteId = 4)
    INSERT INTO Componentes (ComponenteId, Nombre, TipoComponente) 
    VALUES (4, 'Agregar Proveedor', 'Accion');

IF NOT EXISTS (SELECT * FROM Componentes WHERE ComponenteId = 5)
    INSERT INTO Componentes (ComponenteId, Nombre, TipoComponente) 
    VALUES (5, 'Modificar Proveedor', 'Accion');

IF NOT EXISTS (SELECT * FROM Componentes WHERE ComponenteId = 6)
    INSERT INTO Componentes (ComponenteId, Nombre, TipoComponente) 
    VALUES (6, 'Eliminar Proveedor', 'Accion');

-- Acciones de Venta - Nota de Venta
IF NOT EXISTS (SELECT * FROM Componentes WHERE ComponenteId = 7)
    INSERT INTO Componentes (ComponenteId, Nombre, TipoComponente) 
    VALUES (7, 'Agregar Nota de Venta', 'Accion');

IF NOT EXISTS (SELECT * FROM Componentes WHERE ComponenteId = 8)
    INSERT INTO Componentes (ComponenteId, Nombre, TipoComponente) 
    VALUES (8, 'Modificar Nota de Venta', 'Accion');

IF NOT EXISTS (SELECT * FROM Componentes WHERE ComponenteId = 9)
    INSERT INTO Componentes (ComponenteId, Nombre, TipoComponente) 
    VALUES (9, 'Eliminar Nota de Venta', 'Accion');

-- Acciones de Venta - Cliente
IF NOT EXISTS (SELECT * FROM Componentes WHERE ComponenteId = 10)
    INSERT INTO Componentes (ComponenteId, Nombre, TipoComponente) 
    VALUES (10, 'Agregar Cliente', 'Accion');

IF NOT EXISTS (SELECT * FROM Componentes WHERE ComponenteId = 11)
    INSERT INTO Componentes (ComponenteId, Nombre, TipoComponente) 
    VALUES (11, 'Modificar Cliente', 'Accion');

IF NOT EXISTS (SELECT * FROM Componentes WHERE ComponenteId = 12)
    INSERT INTO Componentes (ComponenteId, Nombre, TipoComponente) 
    VALUES (12, 'Eliminar Cliente', 'Accion');

-- Acciones de Productos
IF NOT EXISTS (SELECT * FROM Componentes WHERE ComponenteId = 13)
    INSERT INTO Componentes (ComponenteId, Nombre, TipoComponente) 
    VALUES (13, 'Agregar Producto', 'Accion');

IF NOT EXISTS (SELECT * FROM Componentes WHERE ComponenteId = 14)
    INSERT INTO Componentes (ComponenteId, Nombre, TipoComponente) 
    VALUES (14, 'Modificar Producto', 'Accion');

IF NOT EXISTS (SELECT * FROM Componentes WHERE ComponenteId = 15)
    INSERT INTO Componentes (ComponenteId, Nombre, TipoComponente) 
    VALUES (15, 'Eliminar Producto', 'Accion');

SET IDENTITY_INSERT Componentes OFF;


----ADMINISTRADOR--


-- Primero crear el Grupo de Administradores
SET IDENTITY_INSERT Componentes ON;
IF NOT EXISTS (SELECT * FROM Componentes WHERE ComponenteId = 16)
    INSERT INTO Componentes (ComponenteId, Nombre, TipoComponente, EstadoGrupoId) 
    VALUES (16, 'Administradores', 'Grupo', 1);
SET IDENTITY_INSERT Componentes OFF;

-- Insertar el Administrador en Personas
SET IDENTITY_INSERT Personas ON;
IF NOT EXISTS (SELECT * FROM Personas WHERE PersonaId = 1)
    INSERT INTO Personas 
    (PersonaId, NombreyApellido, DNI, Email, Telefono, Domicilio, FechaNacimiento, Discriminator) 
    VALUES 
    (1, 'Administrador del Sistema', 11111111, 'admin@metallon.com', '0000000', 'Dirección Admin', '2000-01-01', 'Administrador');
SET IDENTITY_INSERT Personas OFF;

-- Crear el Usuario para el Administrador
SET IDENTITY_INSERT Usuarios ON;
IF NOT EXISTS (SELECT * FROM Usuarios WHERE UsuarioId = 1)
    INSERT INTO Usuarios 
    (UsuarioId, NombreUsuario, Clave, Email, EstadoUsuarioId, PersonaId) 
    VALUES 
    (1, 'Admin', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'admin@metallon.com', 1, 1);
SET IDENTITY_INSERT Usuarios OFF;

-- Asignar el Grupo Administradores al Usuario Admin
INSERT INTO ComponenteUsuario (PerfilComponenteId, UsuariosUsuarioId)
SELECT 16, 1
WHERE NOT EXISTS (
    SELECT 1 FROM ComponenteUsuario 
    WHERE PerfilComponenteId = 16 AND UsuariosUsuarioId = 1
);

-- Asignar todas las Acciones al Grupo Administradores
INSERT INTO ComponenteUsuario (PerfilComponenteId, UsuariosUsuarioId)
SELECT ComponenteId, 1
FROM Componentes
WHERE TipoComponente = 'Accion'
AND NOT EXISTS (
    SELECT 1 FROM ComponenteUsuario 
    WHERE PerfilComponenteId = Componentes.ComponenteId 
    AND UsuariosUsuarioId = 1
);


---CONSULTA DE ADMINISTRADOR---
-- Verificar que el Administrador se creó en Personas
SELECT * 
FROM Personas 
WHERE Discriminator = 'Administrador';

-- Verificar el Usuario Admin y su estado
SELECT u.*, e.Nombre as EstadoUsuario
FROM Usuarios u
JOIN EstadoUsuarios e ON u.EstadoUsuarioId = e.EstadoUsuarioId
WHERE u.NombreUsuario = 'Admin';

-- Verificar el Grupo Administradores
SELECT c.*, eg.Nombre as EstadoGrupo
FROM Componentes c
JOIN EstadoGrupos eg ON c.EstadoGrupoId = eg.EstadoGrupoId
WHERE c.TipoComponente = 'Grupo' 
AND c.Nombre = 'Administradores';

-- Verificar que acciones tiene asignadas el Admin
SELECT c.Nombre as AccionAsignada
FROM Componentes c
JOIN ComponenteUsuario cu ON c.ComponenteId = cu.PerfilComponenteId
JOIN Usuarios u ON cu.UsuariosUsuarioId = u.UsuarioId
WHERE u.NombreUsuario = 'Admin'
AND c.TipoComponente = 'Accion';

-- Verificar que el Admin pertenece al grupo Administradores
SELECT c.Nombre as Grupo
FROM Componentes c
JOIN ComponenteUsuario cu ON c.ComponenteId = cu.PerfilComponenteId
JOIN Usuarios u ON cu.UsuariosUsuarioId = u.UsuarioId
WHERE u.NombreUsuario = 'Admin'
AND c.TipoComponente = 'Grupo';

-- Contar cuántas acciones tiene asignadas el Admin
SELECT COUNT(*) as TotalAcciones
FROM ComponenteUsuario cu
JOIN Usuarios u ON cu.UsuariosUsuarioId = u.UsuarioId
JOIN Componentes c ON cu.PerfilComponenteId = c.ComponenteId
WHERE u.NombreUsuario = 'Admin'
AND c.TipoComponente = 'Accion';