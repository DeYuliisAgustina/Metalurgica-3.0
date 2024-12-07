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
    (1, 'Admin', 'Admin123', 'admin@metallon.com', 1, 1);
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
AND c.TipoComponente = 'Accion'

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