﻿using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Autor : IAutor
    {
        #region Inyección de dependencias
        private readonly DAL.Autor _autorDAL;

        public Autor()
        {
            _autorDAL = new DAL.Autor();
        }
        #endregion

        #region Métodos CRUD
        public int RegistrarAutor(Models.Autor autor)
        {
            try
            {
                ValidarAutor(autor);
                return _autorDAL.AltaAutor(autor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ModificarAutor(Models.Autor autor)
        {
            try
            {
                ValidarAutor(autor);
                return _autorDAL.ModificarAutor(autor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int BajaAutor(int autorId)
        {
            try
            {
                return _autorDAL.BajaAutor(autorId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Métodos View
        public List<Models.Autor> GetAutores()
        {
            try
            {
                List<Models.Autor> autores = _autorDAL.GetAutores();
                return autores;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener los autores."); }
        }

        public Models.Autor GetAutor(int autorId)
        {
            try
            {
                Models.Autor autor = _autorDAL.GetAutor(autorId);
                return autor;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener el autor."); }
        }
        #endregion

        #region Tools
        private void ValidarAutor(Models.Autor autor)
        {
            if (string.IsNullOrEmpty(autor.Nombre)) throw new Exception("El nombre es requerido.");
            if (string.IsNullOrEmpty(autor.Apellido)) throw new Exception("El apellido es requerido.");
            if (string.IsNullOrEmpty(autor.Seudonimo)) throw new Exception("El seudónimo es requerido.");
        }
        #endregion

    }
}
