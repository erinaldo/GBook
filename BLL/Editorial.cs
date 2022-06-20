using Interfaces;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Editorial : IEditorial
    {
        #region Inyección de dependencias
        private readonly DAL.Editorial _editorialDAL;
        private readonly DAL.Observer.Idioma _idiomaDAL;

        public Editorial()
        {
            _editorialDAL = new DAL.Editorial();
            _idiomaDAL = new DAL.Observer.Idioma();
        }
        #endregion

        #region Métodos CRUD
        public int AltaEditorial(Models.Editorial editorial)
        {
            try
            {
                ValidarEditorial(editorial);
                return _editorialDAL.AltaEditorial(editorial);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int BajaEditorial(Models.Editorial editorial)
        {
            try
            {
                return _editorialDAL.BajaEditorial(editorial);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ModificarEditorial(Models.Editorial editorial)
        {
            try
            {
                ValidarEditorial(editorial);
                return _editorialDAL.ModificarEditorial(editorial);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Métodos View
        public Models.Editorial GetEditorial(int editorialId)
        {
            try
            {
                Models.Editorial editorial = _editorialDAL.GetEditorial(editorialId);
                return editorial;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener la editorial."); }
        }


        public List<Models.Editorial> GetEditoriales()
        {
            try
            {
                List<Models.Editorial> editoriales = _editorialDAL.GetEditoriales();
                return editoriales;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener las editoriales."); }
        }
        #endregion

        #region Tools
        private void ValidarEditorial(Models.Editorial editorial)
        {
            if (string.IsNullOrEmpty(editorial.Nombre)) throw new Exception(TraducirMensaje("msg_EditorialNombre"));
        }

        private string TraducirMensaje(string msgTag)
        {
            return Traductor.TraducirMensaje(_idiomaDAL, msgTag);
        }
        #endregion
    }
}
