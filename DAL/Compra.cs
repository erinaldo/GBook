using DAL.Conexion;
using DAL.Tools;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Compra : Acceso, ICompra
    {
        #region Inyección de dependencias
        private readonly Fill _fill;
        public Compra()
        {
            _fill = new Fill();
        }
        #endregion

        #region Querys
        private const string ALTA_COMPRA = "INSERT INTO ComprobanteCompra (Detalle, Fecha, Total, EnvioId) OUTPUT inserted.Id" +
                                            " VALUES (@parDetalle, @parFecha, @parTotal, @parEnvioId)";
        private const string ALTA_ENVIO = "INSERT INTO Envio (Domicilio, Numero, EntreCalles, TelefonoContacto) OUTPUT inserted.Id" +
                                          " VALUES (@parDomicilio, @parNumero, @parEntreCalles, @parTelefonoContacto)";
        private const string ALTA_DETALLE_COMPRA = "INSERT INTO DetalleComprobante (ProductoId, Cantidad, PrecioUnitario, Total, ComprobanteCompraId) OUTPUT inserted.Id" +
                                                    " VALUES (@parProductoId, @parCantidad, @parPrecioUnitario, @parTotal, @parComprobanteCompraId)";
        private const string GET_ENVIO = "SELECT * FROM Envio WHERE Id = {0}";
        private const string GET_COMPROBANTE_COMPRA = "SELECT * FROM ComprobanteCompra";
        private const string GET_DETALLE_COMPROBANTE_COMPRA = "SELECT * FROM DetalleComprobante WHERE ComprobanteCompraId = {0}";
        private const string RECIBIR_PEDIDO_STOCK = "UPDATE ComprobanteCompra SET FechaRecepcion = GETDATE() OUTPUT inserted.Id WHERE Id = @parId";
        private const string AUMENTAR_STOCK = "UPDATE Stock SET Cantidad = Cantidad + @parCantidad OUTPUT inserted.Id WHERE ProductoId = @parProductoId";
        #endregion

        #region Métodos CRUD
        public int AltaEnvio(Models.Envio envio)
        {
            try
            {
                ExecuteCommandText = ALTA_ENVIO;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parDomicilio", envio.Domicilio);
                ExecuteParameters.Parameters.AddWithValue("@parNumero", envio.Numero);
                ExecuteParameters.Parameters.AddWithValue("@parEntreCalles", envio.EntreCalles);
                ExecuteParameters.Parameters.AddWithValue("@parTelefonoContacto", envio.TelefonoContacto);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int AltaCompra(Models.ComprobanteCompra compra, int envioId)
        {
            try
            {
                ExecuteCommandText = ALTA_COMPRA;

                ExecuteParameters.Parameters.Clear();
                    
                ExecuteParameters.Parameters.AddWithValue("@parDetalle", compra.Detalle);
                ExecuteParameters.Parameters.AddWithValue("@parFecha", compra.Fecha);
                ExecuteParameters.Parameters.AddWithValue("@parTotal", compra.Total);
                ExecuteParameters.Parameters.AddWithValue("@parEnvioId", envioId);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int AltaDetalleComprobante(Models.DetalleComprobante detalle, int compraId)
        {
            try
            {
                ExecuteCommandText = ALTA_DETALLE_COMPRA;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parProductoId", detalle.Producto.Id);
                ExecuteParameters.Parameters.AddWithValue("@parCantidad", detalle.Cantidad);
                ExecuteParameters.Parameters.AddWithValue("@parPrecioUnitario", detalle.PrecioUnitario);
                ExecuteParameters.Parameters.AddWithValue("@parTotal", detalle.Total);
                ExecuteParameters.Parameters.AddWithValue("@parComprobanteCompraId", compraId);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int GenerarPedidoStock(Envio envio, ComprobanteCompra compra)
        {
            throw new NotImplementedException();
        }

        public int RecibirPedidoStock(ComprobanteCompra comprobante)
        {
            try
            {
                ExecuteCommandText = RECIBIR_PEDIDO_STOCK;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parId", comprobante.Id);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int AumentarStock(DetalleComprobante detalle)
        {
            try
            {
                ExecuteCommandText = AUMENTAR_STOCK;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parProductoId", detalle.Producto.Id);
                ExecuteParameters.Parameters.AddWithValue("@parCantidad", detalle.Cantidad);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion

        #region Métodos View
        public Models.Envio GetEnvio(int envioId)
        {
            try
            {
                SelectCommandText = String.Format(GET_ENVIO, envioId);

                DataSet ds = ExecuteNonReader();
                Models.Envio envio = ds.Tables[0].Rows.Count <= 0 ? null : _fill.FillObjectEnvio(ds.Tables[0].Rows[0]);

                return envio;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public List<Models.ComprobanteCompra> GetComprobanteCompra()
        {
            try
            {
                SelectCommandText = String.Format(GET_COMPROBANTE_COMPRA);
                DataSet ds = ExecuteNonReader();

                List<Models.ComprobanteCompra> comprobantes = new List<Models.ComprobanteCompra>();

                if (ds.Tables[0].Rows.Count > 0)
                    comprobantes = _fill.FillListComprobanteCompra(ds);

                return comprobantes;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        
        
        public List<Models.DetalleComprobante> GetDetalleComprobanteCompra(int compraId)
        {
            try
            {
                SelectCommandText = String.Format(GET_DETALLE_COMPROBANTE_COMPRA, compraId);
                DataSet ds = ExecuteNonReader();

                List<Models.DetalleComprobante> detalleComprobante = new List<Models.DetalleComprobante>();

                if (ds.Tables[0].Rows.Count > 0)
                    detalleComprobante = _fill.FillListDetalleComprobante(ds);

                return detalleComprobante;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion
    }
}
