using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Libro : ILibro
    {
        #region Inyección de dependencias
        private readonly DAL.Libro _libroDAL;
        private readonly DAL.Observer.Idioma _idiomaDAL;

        public Libro()
        {
            _libroDAL = new DAL.Libro();
            _idiomaDAL = new DAL.Observer.Idioma();
        }
        #endregion

        public Models.Libro GetLibro(int productoId)
        {
            try
            {
                Models.Libro producto = _libroDAL.GetLibro(productoId);
                return producto;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener el producto."); }
        }

        public List<Models.Libro> GetLibros()
        {
            try
            {
                List<Models.Libro> productos = _libroDAL.GetLibros();
                return productos;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener los productos."); }
        }

        public List<Models.Libro> GenerarAlertaPedidoStock()
        {
            try
            {
                List<Models.Libro> productos = GetLibros().Where(x => x.Stock.Cantidad <= x.Alerta.CantidadStockAviso && x.Alerta.Activo == true).ToList();
                return productos;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer generer las alertas de pedido de stock."); }
        }
    }
}
