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
    public class Venta : IVenta
    {
        #region Inyección de dependencias
        private readonly DAL.Venta _ventaDAL;
        private readonly DAL.Observer.Idioma _idiomaDAL;

        public Venta()
        {
            _ventaDAL = new DAL.Venta();
            _idiomaDAL = new DAL.Observer.Idioma();
        }
        #endregion

        #region Métodos CRUD
        public int RealizarVenta(ComprobanteVenta comprobante)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    int ventaId = GenerarComprobanteVenta(comprobante);
                    foreach (var item in comprobante.Items)
                    {
                        AltaDetalleComprobante(item, ventaId);
                        AltaVenta(item);
                    }
                    scope.Complete();

                    return ventaId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AltaVenta(DetalleComprobante detalle)
        {
            try
            {
                return _ventaDAL.AltaVenta(detalle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int GenerarComprobanteVenta(Models.ComprobanteVenta venta)
        {
            try
            {
                ValidarVenta(venta);
                return _ventaDAL.GenerarComprobanteVenta(venta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AltaDetalleComprobante(Models.DetalleComprobante detalle, int ventaId)
        {
            try
            {
                return _ventaDAL.AltaDetalleComprobante(detalle, ventaId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Métodos View
        public List<Models.ComprobanteVenta> GetComprobanteVenta()
        {
            try
            {
                List<Models.ComprobanteVenta> comprobantesVenta = _ventaDAL.GetComprobanteVenta();
                return comprobantesVenta;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener los comprobantes de venta."); }
        }

        public List<Models.DetalleComprobante> GetDetalleComprobanteVenta(int ventaId)
        {
            try
            {
                List<Models.DetalleComprobante> detalleComprobante = _ventaDAL.GetDetalleComprobanteVenta(ventaId);
                return detalleComprobante;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener los detalles de comprobantes de compra."); }
        }        
        #endregion

        #region Tools
        private void ValidarVenta(Models.ComprobanteVenta venta)
        {
            if (string.IsNullOrWhiteSpace(venta.Detalle)) throw new Exception(TraducirMensaje("msg_VentaDetalle"));
            if (venta.Total <= 0) throw new Exception(TraducirMensaje("msg_VentaTotal"));
            if (venta.Items.Count() == 0) throw new Exception(TraducirMensaje("msg_VentaCarrito"));
        }

        private string TraducirMensaje(string msgTag)
        {
            return Traductor.TraducirMensaje(_idiomaDAL, msgTag);
        }
        #endregion
    }
}
