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
    public class Venta : Acceso, IVenta
    {
        #region Inyección de dependencias
        private readonly Fill _fill;
        public Venta()
        {
            _fill = new Fill();
        }
        #endregion

        #region Querys
        private const string ALTA_VENTA = "UPDATE Stock SET Cantidad = Cantidad - @parCantidad OUTPUT inserted.Id WHERE ProductoId = @parProductoId";
        private const string GENERAR_COMPROBANTE_VENTA = "INSERT INTO ComprobanteVenta (Detalle, Fecha, Total) OUTPUT inserted.Id" +
                                    " VALUES (@parDetalle, @parFecha, @parTotal)";
        private const string ALTA_DETALLE_COMPROBANTE = "INSERT INTO DetalleComprobante (ProductoId, Cantidad, PrecioUnitario, Total, ComprobanteVentaId) OUTPUT inserted.Id" +
                                                    " VALUES (@parProductoId, @parCantidad, @parPrecioUnitario, @parTotal, @parComprobanteVentaId)";
        private const string GET_COMPROBANTE_VENTA = "SELECT * FROM ComprobanteVenta";
        private const string GET_DETALLE_COMPROBANTE_VENTA = "SELECT * FROM DetalleComprobante WHERE ComprobanteVentaId = {0}";
        #endregion

        #region Métodos CRUD
        public int AltaVenta(DetalleComprobante detalle)
        {
            try
            {
                ExecuteCommandText = ALTA_VENTA;

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

        public int GenerarComprobanteVenta(Models.ComprobanteVenta venta)
        {
            try
            {
                ExecuteCommandText = GENERAR_COMPROBANTE_VENTA;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parDetalle", venta.Detalle);
                ExecuteParameters.Parameters.AddWithValue("@parFecha", venta.Fecha);
                ExecuteParameters.Parameters.AddWithValue("@parTotal", venta.Total);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int AltaDetalleComprobante(Models.DetalleComprobante detalle, int ventaId)
        {
            try
            {
                ExecuteCommandText = ALTA_DETALLE_COMPROBANTE;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parProductoId", detalle.Producto.Id);
                ExecuteParameters.Parameters.AddWithValue("@parCantidad", detalle.Cantidad);
                ExecuteParameters.Parameters.AddWithValue("@parPrecioUnitario", detalle.PrecioUnitario);
                ExecuteParameters.Parameters.AddWithValue("@parTotal", detalle.Total);
                ExecuteParameters.Parameters.AddWithValue("@parComprobanteVentaId", ventaId);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int RealizarVenta(ComprobanteVenta comprobante)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Métodos View
        public List<Models.ComprobanteVenta> GetComprobanteVenta()
        {
            try
            {
                SelectCommandText = String.Format(GET_COMPROBANTE_VENTA);
                DataSet ds = ExecuteNonReader();

                List<Models.ComprobanteVenta> comprobantes = new List<Models.ComprobanteVenta>();

                if (ds.Tables[0].Rows.Count > 0)
                    comprobantes = _fill.FillListComprobanteVenta(ds);

                return comprobantes;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public List<Models.DetalleComprobante> GetDetalleComprobanteVenta(int ventaId)
        {
            try
            {
                SelectCommandText = String.Format(GET_DETALLE_COMPROBANTE_VENTA, ventaId);
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
