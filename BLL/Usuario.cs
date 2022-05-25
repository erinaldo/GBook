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

namespace BLL
{
    public class Usuario : IUsuario
    {
        #region Inyección de dependencias
        private readonly DAL.Usuario _usuarioDAL;
        private readonly Encriptacion _encriptacion;

        public Usuario()
        {
            _usuarioDAL = new DAL.Usuario();
            _encriptacion = new Encriptacion();
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
                            UsuarioId = usuario.UsuarioId,
                            Email = _encriptacion.DesencriptarAES(usuario.Email),
                            Nombre = _encriptacion.DesencriptarAES(usuario.Nombre),
                            Apellido = _encriptacion.DesencriptarAES(usuario.Apellido),
                        };

                        Sesion.CreateInstance(usuarioSingleton);
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

                usuario.Email = _encriptacion.EncriptarAES(usuario.Email);
                usuario.Nombre = _encriptacion.EncriptarAES(usuario.Nombre);
                usuario.Apellido = _encriptacion.EncriptarAES(usuario.Apellido);
                usuario.Password = _encriptacion.Hash(usuario.Password);
                usuario.Bloqueo = 0;

                return _usuarioDAL.RegistrarUsuario(usuario);
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
            if (string.IsNullOrWhiteSpace(usuario.Password) || usuario.Password.Length < 8) throw new Exception("La contraseña no puede estar vacía ni tener menos de 8 caracteres.");
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
        #endregion
    }
}
