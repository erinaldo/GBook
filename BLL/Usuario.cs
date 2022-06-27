using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTOs;
using System.Text.RegularExpressions;
using Servicios;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace BLL
{
    public class Usuario : IUsuario
    {
        #region Inyección de dependencias
        private readonly DAL.Usuario _usuarioDAL;
        private readonly Encriptacion _encriptacion;
        private readonly DAL.Observer.Idioma _idiomaDAL;

        public Usuario()
        {
            _usuarioDAL = new DAL.Usuario();
            _encriptacion = new Encriptacion();
            _idiomaDAL = new DAL.Observer.Idioma();
        }
        #endregion

        #region Métodos View
        public List<UsuarioDTO> GetUsers()
        {
            try
            {
                List<UsuarioDTO> usuarios = _usuarioDAL.GetUsers();
                return usuarios;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener los usuarios."); }
        }

        public List<UsuarioDTO> GetUsersDesencriptado()
        {
            try
            {
                List<UsuarioDTO> usuarios = _usuarioDAL.GetUsers();
                List<UsuarioDTO> usuariosDesencriptado = new List<UsuarioDTO>();

                foreach (UsuarioDTO user in usuarios)
                {
                    user.Email = _encriptacion.DesencriptarAES(user.Email);
                    usuariosDesencriptado.Add(user);
                }

                return usuariosDesencriptado;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener los usuarios."); }
        }

        public void Login(string email, string password)
        {
            try
            {
                if (Sesion.GetInstance() != null) throw new Exception("Ya hay una instancia de un usuario creada.");
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password)) throw new Exception("Se deben completar los campos");

                string emailEncriptado = _encriptacion.EncriptarAES(email);
                Models.Usuario usuario = _usuarioDAL.Login(emailEncriptado);

                if (usuario != null)
                {
                    if (usuario.Bloqueo >= 3) throw new Exception("El usuario está bloqueado.");

                    string passwordEncriptada = _encriptacion.Hash(password);
                    if (passwordEncriptada == usuario.Password)
                    {
                        UsuarioDTO usuarioSingleton = new UsuarioDTO()
                        {
                            UsuarioId = usuario.Id,
                            Email = _encriptacion.DesencriptarAES(usuario.Email),
                            Nombre = _encriptacion.DesencriptarAES(usuario.Nombre),
                            Apellido = _encriptacion.DesencriptarAES(usuario.Apellido),
                        };

                        Sesion.CreateInstance(usuarioSingleton, _idiomaDAL.ObtenerIdiomaDefault());
                    }
                    else
                    {
                        _usuarioDAL.BloquearUsuario(emailEncriptado);
                        throw new Exception("La contraseña ingresada es incorrecta.");
                    }
                }
                else throw new Exception("No existe un usuario con ese email.");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Logout()
        {
            try
            {
                Sesion.RemoveInstance();
            }
            catch
            {
                throw new Exception("Hubo un error al querer desloguear. Contacte al administrador.");
            }
        }
        #endregion

        #region Métodos CRUD
        public int RegistrarUsuario(Models.Usuario usuario)
        {
            try
            {
                ValidarUsuario(usuario);
                string passwordRandom = _encriptacion.GenerarPasswordRandom();
                string email = usuario.Email.Replace("@", "-");
                string emailTxt = email.Replace(".com", "");

                usuario.Email = _encriptacion.EncriptarAES(usuario.Email);
                usuario.Nombre = _encriptacion.EncriptarAES(usuario.Nombre);
                usuario.Apellido = _encriptacion.EncriptarAES(usuario.Apellido);
                usuario.Password = _encriptacion.Hash(passwordRandom);
                usuario.Bloqueo = 0;
                GuardarPassword(emailTxt, passwordRandom);

                return _usuarioDAL.RegistrarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CambiarPassword(UsuarioDTO usuario, string passwordActual, string nuevaPassword)
        {
            try
            {
                ValidarCambioPassword(usuario, _encriptacion.Hash(passwordActual), nuevaPassword);
                if (string.IsNullOrWhiteSpace(nuevaPassword) || nuevaPassword.Length < 8) throw new Exception("msg_ValidacionPassword");

                string nuevaPasswordEncriptada = _encriptacion.Hash(nuevaPassword);

                return _usuarioDAL.CambiarPassword(usuario, nuevaPasswordEncriptada);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Tools
        private void ValidarUsuario(Models.Usuario usuario)
        {
            if ((ValidarEmail(usuario.Email) == false) || string.IsNullOrWhiteSpace(usuario.Email)) throw new Exception("El email no puede estar vacío ni tener el formato incorrecto.");
            if (string.IsNullOrWhiteSpace(usuario.Nombre) || usuario.Nombre.Length < 3) throw new Exception("El nombre no puede estar vacía ni tener menos de 3 caracteres.");
            if (string.IsNullOrWhiteSpace(usuario.Apellido) || usuario.Apellido.Length < 3) throw new Exception("El apellido no puede estar vacía ni tener menos de 3 caracteres.");
        }

        private bool ValidarEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0) return true;
                else return false;
            }
            else return false;
        }

        private void ValidarCambioPassword(Models.DTOs.UsuarioDTO user, string passwordActual, string nuevaPassword)
        {
            Models.Usuario _usuario = _usuarioDAL.GetUsuario(user.UsuarioId);
            if (passwordActual != _usuario.Password) throw new Exception(TraducirMensaje("msg_PasswordNoCoindice"));
            if (string.IsNullOrWhiteSpace(nuevaPassword) || nuevaPassword.Length < 8) throw new Exception(TraducirMensaje("msg_NuevaPasswordFormato"));
        }

        private string TraducirMensaje(string msgTag)
        {
            return Traductor.TraducirMensaje(_idiomaDAL, msgTag);
        }

        private void GuardarPassword(string usuario, string password)
        {
            try
            {
                string directorio = $"C:\\GBook\\{usuario}\\";
                string _password = $"Contraseña: {password}";

                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                StreamWriter fichero;
                fichero = File.CreateText($"{directorio}{usuario}.txt");  
                fichero.WriteLine(_password);
                fichero.Close();
            }
            catch
            {
                throw new Exception("Hubo un error al querer guardar la contraseña del usuario en el disco.");
            }
        }
        #endregion
    }
}
