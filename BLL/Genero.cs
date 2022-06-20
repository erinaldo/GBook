using Interfaces;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Genero : IGenero
    {
        #region Inyección de dependencias
        private readonly DAL.Genero _generoDAL;
        private readonly DAL.Observer.Idioma _idiomaDAL;

        public Genero()
        {
            _generoDAL = new DAL.Genero();
            _idiomaDAL = new DAL.Observer.Idioma();
        }
        #endregion

        #region Métodos CRUD
        public int AltaGenero(Models.Genero genero)
        {
            try
            {
                ValidarGenero(genero);
                return _generoDAL.AltaGenero(genero);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int BajaGenero(int id)
        {
            try
            {
                return _generoDAL.BajaGenero(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ModificarGenero(Models.Genero genero)
        {
            try
            {
                ValidarGenero(genero);
                return _generoDAL.ModificarGenero(genero);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Métodos View
        public Models.Genero GetGenero(int id)
        {
            try
            {
                Models.Genero genero = _generoDAL.GetGenero(id);
                return genero;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener el género."); }
        }

        public List<Models.Genero> GetGeneros()
        {
            try
            {
                List<Models.Genero> generos = _generoDAL.GetGeneros();
                return generos;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener los géneros."); }
        }
        #endregion

        #region Tools
        private void ValidarGenero(Models.Genero genero)
        {
            if (string.IsNullOrEmpty(genero.Nombre)) throw new Exception(TraducirMensaje("msg_GeneroNombre"));
        }

        private string TraducirMensaje(string msgTag)
        {
            return Traductor.TraducirMensaje(_idiomaDAL, msgTag);
        }
        #endregion
    }
}
