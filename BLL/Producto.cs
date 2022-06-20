using Interfaces;
using Models;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class Producto : IProducto
    {
        #region Inyección de dependencias
        private readonly DAL.Producto _productoDAL;
        private readonly DAL.Observer.Idioma _idiomaDAL;

        public Producto()
        {
            _productoDAL = new DAL.Producto();
            _idiomaDAL = new DAL.Observer.Idioma();
        }
        #endregion

        #region Métodos CRUD
        public int AltaAlerta(int productoId)
        {
            try
            {
                return _productoDAL.AltaAlerta(productoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AltaProducto(Models.Producto producto)
        {
            try
            {
                ValidarProducto(producto);

                using (TransactionScope scope = new TransactionScope())
                {
                    int productoId = _productoDAL.AltaProducto(producto);
                    _productoDAL.AltaStock(productoId);
                    _productoDAL.AltaAlerta(productoId);
                    scope.Complete();
                }

                return producto.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AltaStock(int productoId)
        {
            try
            {
                return _productoDAL.AltaStock(productoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ModificarProducto(Models.Producto producto)
        {
            try
            {
                ValidarProducto(producto);
                return _productoDAL.ModificarProducto(producto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int PublicarProducto(Models.Producto producto)
        {
            try
            {
                return _productoDAL.PublicarProducto(producto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int FijarProducto(Models.Producto producto)
        {
            try
            {
                return _productoDAL.FijarProducto(producto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Métodos View
        public Models.Producto GetProducto(int productoId)
        {
            try
            {
                Models.Producto producto = _productoDAL.GetProducto(productoId);
                return producto;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener el producto."); }
        }

        public List<Models.Producto> GetProductos()
        {
            try
            {
                List<Models.Producto> productos = _productoDAL.GetProductos();
                return productos;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener los productos."); }
        }

        public List<Models.Producto> GenerarAlertaPedidoStock()
        {
            try
            {
                List<Models.Producto> productos = _productoDAL.GetProductos().Where(x => x.Stock.Cantidad <= x.Alerta.CantidadStockAviso && x.Alerta.Activo == true).ToList();
                return productos;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer generer las alertas de pedido de stock."); }
        }

        public Stock GetStock(int productoId)
        {
            try
            {
                Models.Stock stock = _productoDAL.GetStock(productoId);
                return stock;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener el stock."); }
        }

        public Models.Alerta GetAlerta (int productoId)
        {
            try
            {
                Models.Alerta alerta = _productoDAL.GetAlerta(productoId);
                return alerta;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener la alerta."); }
        }
        #endregion

        #region Tools
        private void ValidarProducto(Models.Producto producto)
        {
            if (string.IsNullOrEmpty(producto.ISBN)) throw new Exception(TraducirMensaje("msg_ProductoISBN"));
            if (string.IsNullOrEmpty(producto.Nombre)) throw new Exception(TraducirMensaje("msg_ProductoNombre"));
            if (producto.Precio <= 0) throw new Exception(TraducirMensaje("msg_ProductoPrecio"));
            if (producto.CantidadPaginas <= 0) throw new Exception(TraducirMensaje("msg_ProductoCantidadPaginas"));
            if (producto.Autor == null) throw new Exception(TraducirMensaje("msg_ProductoAutor"));
            if (producto.Genero == null) throw new Exception(TraducirMensaje("msg_ProductoGenero"));
            if (producto.Editorial == null) throw new Exception(TraducirMensaje("msg_ProductoEditorial"));
        }

        private string TraducirMensaje(string msgTag)
        {
            return Traductor.TraducirMensaje(_idiomaDAL, msgTag);
        }
        #endregion
    }
}
