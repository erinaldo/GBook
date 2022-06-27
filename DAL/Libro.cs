using DAL.Conexion;
using DAL.Tools;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Libro : Acceso, ILibro
    {
        #region Inyección de dependencias
        private readonly Fill _fill;
        public Libro()
        {
            _fill = new Fill();
        }
        #endregion

        #region Querys
        private const string GET_LIBRO = "SELECT TOP 1 * FROM Producto WHERE Id = {0}";
        private const string GET_LIBROS = "SELECT * FROM Producto";
        #endregion

        #region Métodos View
        public Models.Libro GetLibro(int productoId)
        {
            try
            {
                SelectCommandText = String.Format(GET_LIBRO, productoId);

                DataSet ds = ExecuteNonReader();
                Models.Libro producto = ds.Tables[0].Rows.Count <= 0 ? null : _fill.FillObjectLibro(ds.Tables[0].Rows[0]);

                return producto;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public List<Models.Libro> GetLibros()
        {
            try
            {
                SelectCommandText = String.Format(GET_LIBROS);
                DataSet ds = ExecuteNonReader();

                List<Models.Libro> productos = new List<Models.Libro>();

                if (ds.Tables[0].Rows.Count > 0)
                    productos = _fill.FillListLibro(ds);

                return productos;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public List<Models.Libro> GenerarAlertaPedidoStock()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
