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
    public class Compra : ICompra
    {
        #region Inyección de dependencias
        private readonly DAL.Compra _compraDAL;
        private readonly DAL.Observer.Idioma _idiomaDAL;

        public Compra()
        {
            _compraDAL = new DAL.Compra();
            _idiomaDAL = new DAL.Observer.Idioma();
        }
        #endregion

        #region Métodos CRUD
        public int AltaCompra(ComprobanteCompra compra, int envioId)
        {
            try
            {
                ValidarCompra(compra);
                return _compraDAL.AltaCompra(compra, envioId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AltaDetalleComprobante(DetalleComprobante detalle, int compraId)
        {
            try
            {
                return _compraDAL.AltaDetalleComprobante(detalle, compraId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AltaEnvio(Envio envio)
        {
            try
            {
                ValidarEnvio(envio);
                return _compraDAL.AltaEnvio(envio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int GenerarPedidoStock(Models.Envio envio, Models.ComprobanteCompra compra)
        {
            try
            {
                int compraId = 0;

                using (TransactionScope scope = new TransactionScope())
                {
                    int envioId = AltaEnvio(envio);
                    compraId = AltaCompra(compra, envioId);
                    foreach (var item in compra.Items)
                    {
                        _compraDAL.AltaDetalleComprobante(item, compraId);
                    }

                    scope.Complete();
                }

                return compraId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AumentarStock(Models.DetalleComprobante detalle)
        {
            try
            {
                return _compraDAL.AumentarStock(detalle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int RecibirPedidoStock(ComprobanteCompra comprobante)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    int pedido = _compraDAL.RecibirPedidoStock(comprobante);
                    foreach (DetalleComprobante item in comprobante.Items)
                    {
                        _compraDAL.AumentarStock(item);
                    }
                    scope.Complete();

                    return pedido;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Métodos View
        public Models.Envio GetEnvio(int envioId)
        {
            try
            {
                Models.Envio envio = _compraDAL.GetEnvio(envioId);
                return envio;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener el envío."); }
        }

        public List<Models.DetalleComprobante> GetDetalleComprobanteCompra(int compraId)
        {
            try
            {
                List<Models.DetalleComprobante> detalleComprobante = _compraDAL.GetDetalleComprobanteCompra(compraId);
                return detalleComprobante;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener los detalles de comprobantes de compra."); }
        }

        public List<Models.ComprobanteCompra> GetComprobanteCompra()
        {
            try
            {
                List<Models.ComprobanteCompra> comprobantesCompra = _compraDAL.GetComprobanteCompra();
                return comprobantesCompra;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener los comprobantes de compra"); }
        }
        #endregion

        #region Tools
        private void ValidarCompra(Models.ComprobanteCompra compra)
        {
            if (string.IsNullOrWhiteSpace(compra.Detalle)) throw new Exception(TraducirMensaje("msg_CompraDetalle"));
            if (compra.Total <= 0) throw new Exception(TraducirMensaje("msg_CompraTotal"));
            if (compra.Envio == null) throw new Exception(TraducirMensaje("msg_CompraEnvio"));
            if (compra.Items.Count() == 0) throw new Exception(TraducirMensaje("msg_CompraCarrito"));
        }

        private void ValidarEnvio(Models.Envio envio)
        {
            if (string.IsNullOrWhiteSpace(envio.Domicilio)) throw new Exception(TraducirMensaje("msg_EnvioDomicilio"));
            if (string.IsNullOrWhiteSpace(envio.Numero)) throw new Exception(TraducirMensaje("msg_EnvioNumero"));
            if (string.IsNullOrWhiteSpace(envio.EntreCalles)) throw new Exception(TraducirMensaje("msg_EnvioEntreCalles"));
            if (string.IsNullOrWhiteSpace(envio.TelefonoContacto)) throw new Exception(TraducirMensaje("msg_EnvioTelefonoContacto"));
        }

        private string TraducirMensaje(string msgTag)
        {
            return Traductor.TraducirMensaje(_idiomaDAL, msgTag);
        }
        #endregion
    }
}
