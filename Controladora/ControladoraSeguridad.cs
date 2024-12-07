using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using Entidades;
using Entidades.Seguridad;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace Controladora
{
    public class ControladoraSeguridad
    {
        Context context;

        private ControladoraSeguridad()
        {
            context = new Context();
        }

        private static ControladoraSeguridad instancia;

        public static ControladoraSeguridad Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraSeguridad();
                return instancia;
            }
        }

        // MÉTODOS DE USUARIO
        public ReadOnlyCollection<Usuario> RecuperarUsuarios()
        {
            Context.Instancia.Usuarios.ToList().AsReadOnly();
            return Context.Instancia.Usuarios.ToList().AsReadOnly();
        }

        //RECUPERAR ESTADOS DE USUARIO
        public ReadOnlyCollection<EstadoUsuario> RecuperarEstadosUsuario()
        {
            Context.Instancia.EstadoUsuarios.ToList().AsReadOnly();
            return Context.Instancia.EstadoUsuarios.ToList().AsReadOnly();
        }

        //RECUPERAR ESTADOS DE GRUPO
        public ReadOnlyCollection<EstadoGrupo> RecuperarEstadosGrupo()
        {
            Context.Instancia.EstadoGrupos.ToList().AsReadOnly();
            return Context.Instancia.EstadoGrupos.ToList().AsReadOnly();
        }

        // MÉTODOS DE GRUPO
        public ReadOnlyCollection<Grupo> RecuperarGrupos()
        {
            Context.Instancia.Grupos.ToList().AsReadOnly();
            return Context.Instancia.Grupos.ToList().AsReadOnly();
        }

        public ReadOnlyCollection<Accion> RecuperarAcciones()
        {
            Context.Instancia.Acciones.ToList().AsReadOnly();
            return Context.Instancia.Acciones.ToList().AsReadOnly();
        }


        public ReadOnlyCollection<Administrador> RecuperarAdministradores()
        {
            Context.Instancia.Administradores.ToList().AsReadOnly();
            return Context.Instancia.Administradores.ToList().AsReadOnly();
        }


        public string IniciarSesion(Usuario usuario)
        {
            try
            {
                var listaUsuarios = RecuperarUsuarios();
                var usuarioEncontrado = listaUsuarios.FirstOrDefault(u =>
                    u.NombreUsuario.ToLower() == usuario.NombreUsuario.ToLower() &&
                    u.Clave == HashPassword(usuario.Clave));

                if (usuarioEncontrado == null)
                    return "Usuario o contraseña incorrectos";

                var grupos = usuarioEncontrado.Perfil.OfType<Grupo>();
                var tieneGrupoActivo = grupos.Any(g => g.Nombre.ToLower() == "activo");

                if (!tieneGrupoActivo)
                    return "El usuario no pertenece a un grupo activo";

                return "Inicio de sesión exitoso";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string AgregarUsuario(Usuario usuario)
        {
            try
            {
                var listaUsuarios = RecuperarUsuarios();
                var usuarioExistente = listaUsuarios.FirstOrDefault(u =>
                    u.NombreUsuario.ToLower() == usuario.NombreUsuario.ToLower());

                if (usuarioExistente != null)
                    return "El usuario ya existe";

                // Generar clave aleatoria
                string clave = GenerarClaveAleatoria();
                usuario.Clave = HashPassword(clave);

                Context.Instancia.Usuarios.Add(usuario);
                int insertados = Context.Instancia.SaveChanges();

                if (insertados > 0)
                {
                    EnviarClaveEmail(usuario.Email, usuario.NombreUsuario, clave);
                    return "Usuario agregado exitosamente";
                }
                return "No se pudo agregar el usuario";
            }
            catch (Exception ex)
            {
                // Log del error para debugging
                Console.WriteLine($"Error agregando usuario: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                return $"Error al agregar el usuario: {ex.Message}";
            }
        }

        public string ModificarUsuario(Usuario usuario)
        {
            try
            {
                var listaUsuarios = RecuperarUsuarios();
                var usuarioExistente = listaUsuarios.FirstOrDefault(u =>
                    u.UsuarioId == usuario.UsuarioId);

                if (usuarioExistente == null)
                    return "Usuario no encontrado";

                usuarioExistente.Email = usuario.Email;
                usuarioExistente.Persona = usuario.Persona;
                usuarioExistente.Perfil = usuario.Perfil;

                int modificados = Context.Instancia.SaveChanges();
                return modificados > 0 ? "Usuario modificado exitosamente" : "No se pudo modificar el usuario";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string EliminarUsuario(Usuario usuario)
        {
            try
            {
                var listaUsuarios = RecuperarUsuarios();
                var usuarioExistente = listaUsuarios.FirstOrDefault(u =>
                    u.UsuarioId == usuario.UsuarioId);

                if (usuarioExistente == null)
                    return "Usuario no encontrado";

                Context.Instancia.Usuarios.Remove(usuarioExistente);
                int eliminados = Context.Instancia.SaveChanges();
                return eliminados > 0 ? "Usuario eliminado exitosamente" : "No se pudo eliminar el usuario";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string CambiarClave(Usuario usuario, string claveNueva, string confirmacionClave)
        {
            try
            {
                if (claveNueva != confirmacionClave)
                    return "Las claves no coinciden";

                if (!ValidarFormatoClave(claveNueva))
                    return "La clave no cumple con los requisitos de seguridad";

                var listaUsuarios = RecuperarUsuarios();
                var usuarioExistente = listaUsuarios.FirstOrDefault(u =>
                    u.UsuarioId == usuario.UsuarioId);

                if (usuarioExistente == null)
                    return "Usuario no encontrado";

                usuarioExistente.Clave = HashPassword(claveNueva);
                int modificados = Context.Instancia.SaveChanges();
                return modificados > 0 ? "Clave modificada exitosamente" : "No se pudo modificar la clave";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string RecuperarClave(Usuario usuario)
        {
            try
            {
                var listaUsuarios = RecuperarUsuarios();
                var usuarioExistente = listaUsuarios.FirstOrDefault(u =>
                    u.NombreUsuario.ToLower() == usuario.NombreUsuario.ToLower() &&
                    u.Email.ToLower() == usuario.Email.ToLower());

                if (usuarioExistente == null)
                    return "Usuario no encontrado";

                string nuevaClave = GenerarClaveAleatoria();
                usuarioExistente.Clave = HashPassword(nuevaClave);

                int modificados = Context.Instancia.SaveChanges();
                if (modificados > 0)
                {
                    EnviarClaveEmail(usuarioExistente.Email, usuarioExistente.NombreUsuario, nuevaClave);
                    return "La nueva clave ha sido enviada a su email";
                }
                return "No se pudo recuperar la clave";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ResetearClave(Usuario usuario)
        {
            try
            {
                var usuarioEncontrado = Context.Instancia.Usuarios
                    .Include(u => u.EstadoUsuario)
                    .FirstOrDefault(u => u.UsuarioId == usuario.UsuarioId);

                if (usuarioEncontrado == null)
                    return "Usuario no encontrado";

                if (usuarioEncontrado.EstadoUsuario.Nombre != "Activo")
                    return "Usuario inactivo";

                if (string.IsNullOrEmpty(usuarioEncontrado.Email))
                    return "El usuario no tiene email registrado";

                // Generate and set new random password
                string nuevaClave = GenerarClaveAleatoria();
                usuarioEncontrado.Clave = HashPassword(nuevaClave);

                int insertados = Context.Instancia.SaveChanges();
                if (insertados > 0)
                {
                    EnviarClaveEmail(usuarioEncontrado.Email, usuarioEncontrado.NombreUsuario, nuevaClave);
                    return "La nueva clave ha sido enviada al email del usuario";
                }

                return "No se ha podido resetear la clave";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string AgregarGrupo(Grupo grupo)
        {
            try
            {
                var listaGrupos = RecuperarGrupos();
                var grupoExistente = listaGrupos.FirstOrDefault(g =>
                    g.Codigo.ToLower() == grupo.Codigo.ToLower() ||
                    g.Nombre.ToLower() == grupo.Nombre.ToLower());

                if (grupoExistente != null)
                    return "Ya existe un grupo con ese código o nombre";

                Context.Instancia.Grupos.Add(grupo);
                int insertados = Context.Instancia.SaveChanges();
                return insertados > 0 ? "Grupo agregado exitosamente" : "No se pudo agregar el grupo";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ModificarGrupo(Grupo grupo)
        {
            try
            {
                var listaGrupos = RecuperarGrupos();
                var grupoExistente = listaGrupos.FirstOrDefault(g =>
                    g.GrupoId == grupo.GrupoId);

                if (grupoExistente == null)
                    return "Grupo no encontrado";

                grupoExistente.Nombre = grupo.Nombre;
                grupoExistente.Codigo = grupo.Codigo;
                grupoExistente.Descripcion = grupo.Descripcion;
                grupoExistente.Hijos = grupo.Hijos;

                int modificados = Context.Instancia.SaveChanges();
                return modificados > 0 ? "Grupo modificado exitosamente" : "No se pudo modificar el grupo";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string EliminarGrupo(Grupo grupo)
        {
            try
            {
                var listaGrupos = RecuperarGrupos();
                var grupoExistente = listaGrupos.FirstOrDefault(g =>
                    g.GrupoId == grupo.GrupoId);

                if (grupoExistente == null)
                    return "Grupo no encontrado";

                if (grupoExistente.Usuarios.Any())
                    return "No se puede eliminar el grupo porque tiene usuarios asociados";

                Context.Instancia.Grupos.Remove(grupoExistente);
                int eliminados = Context.Instancia.SaveChanges();
                return eliminados > 0 ? "Grupo eliminado exitosamente" : "No se pudo eliminar el grupo";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        // MÉTODOS PRIVADOS DE UTILIDAD
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private bool ValidarFormatoClave(string clave)
        {
            if (clave.Length < 8) return false;
            if (!clave.Any(char.IsUpper)) return false;
            if (!clave.Any(char.IsLower)) return false;
            if (!clave.Any(char.IsDigit)) return false;
            if (!clave.Any(ch => !char.IsLetterOrDigit(ch))) return false;
            return true;
        }

        private string GenerarClaveAleatoria()
        {
            const string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string minusculas = "abcdefghijklmnopqrstuvwxyz";
            const string numeros = "0123456789";
            const string especiales = "*#$@!";

            var random = new Random();
            var password = new StringBuilder();

            // Asegurar requisitos mínimos
            password.Append(mayusculas[random.Next(mayusculas.Length)]);
            password.Append(minusculas[random.Next(minusculas.Length)]);
            password.Append(numeros[random.Next(numeros.Length)]);
            password.Append(especiales[random.Next(especiales.Length)]);

            // Completar hasta 12 caracteres
            const string todosCaracteres = mayusculas + minusculas + numeros + especiales;
            while (password.Length < 12)
            {
                password.Append(todosCaracteres[random.Next(todosCaracteres.Length)]);
            }

            // Mezclar caracteres
            return new string(password.ToString().ToCharArray().OrderBy(x => random.Next()).ToArray());
        }

        private void EnviarClaveEmail(string email, string nombreUsuario, string clave)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential("your-email@gmail.com", "your-app-password");

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("your-email@gmail.com", "Metallon S.R.L");
                    mail.To.Add(email);
                    mail.Subject = "Nueva clave de acceso - Metallon S.R.L";
                    mail.Body = $"Estimado/a {nombreUsuario}:\n\n" +
                              $"Su nueva clave de acceso es: {clave}\n\n" +
                              "Por motivos de seguridad, le recomendamos cambiar esta clave la próxima vez que inicie sesión.\n\n" +
                              "Saludos cordiales,\n" +
                              "Metallon S.R.L";

                    smtpClient.Send(mail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enviando email: {ex.Message}");
            }
        }
    }
}