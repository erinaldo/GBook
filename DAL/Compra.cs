using DAL.Conexion;
using DAL.Tools;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
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
        #endregion
    }
}
