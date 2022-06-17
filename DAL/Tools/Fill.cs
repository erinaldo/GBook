using DAL;
using Interfaces;
using Models;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tools
{
    public class Fill
    {
        #region Usuario
        public Models.Usuario FillObjectUsuario(DataRow dr)
        {
            Models.Usuario usuario = new Models.Usuario();

            try
            {
                if (dr.Table.Columns.Contains("UsuarioId") && !Convert.IsDBNull(dr["UsuarioId"]))
                    usuario.Id = Convert.ToInt32(dr["UsuarioId"]);

                if (dr.Table.Columns.Contains("Email") && !Convert.IsDBNull(dr["Email"]))
                    usuario.Email = Convert.ToString(dr["Email"]);

                if (dr.Table.Columns.Contains("Password") && !Convert.IsDBNull(dr["Password"]))
                    usuario.Password = Convert.ToString(dr["Password"]);

                if (dr.Table.Columns.Contains("Nombre") && !Convert.IsDBNull(dr["Nombre"]))
                    usuario.Nombre = Convert.ToString(dr["Nombre"]);

                if (dr.Table.Columns.Contains("Apellido") && !Convert.IsDBNull(dr["Apellido"]))
                    usuario.Apellido = Convert.ToString(dr["Apellido"]);

                if (dr.Table.Columns.Contains("Bloqueo") && !Convert.IsDBNull(dr["Bloqueo"]))
                    usuario.Bloqueo = Convert.ToInt32(dr["Bloqueo"]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el método FillObject, " + ex.Message);
            }
            return usuario;
        }

        public UsuarioDTO FillObjectUsuarioDTO(DataRow dr)
        {
            UsuarioDTO usuario = new UsuarioDTO();

            try
            {
                if (dr.Table.Columns.Contains("UsuarioId") && !Convert.IsDBNull(dr["UsuarioId"]))
                    usuario.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);

                if (dr.Table.Columns.Contains("Email") && !Convert.IsDBNull(dr["Email"]))
                    usuario.Email = Convert.ToString(dr["Email"]);

                if (dr.Table.Columns.Contains("Nombre") && !Convert.IsDBNull(dr["Nombre"]))
                    usuario.Nombre = Convert.ToString(dr["Nombre"]);

                if (dr.Table.Columns.Contains("Apellido") && !Convert.IsDBNull(dr["Apellido"]))
                    usuario.Apellido = Convert.ToString(dr["Apellido"]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el método FillObject, " + ex.Message);
            }
            return usuario;
        }

        public List<UsuarioDTO> FillListUsuarioDTO(DataSet ds)
        {
            return (from DataRow dr in ds.Tables[0].Rows select (new Fill()).FillObjectUsuarioDTO(dr)).ToList();
        }

        #endregion

        #region Autor
        public Models.Autor FillObjectAutor(DataRow dr)
        {
            Models.Autor autor = new Models.Autor();

            try
            {
                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    autor.Id = Convert.ToInt32(dr["Id"]);

                if (dr.Table.Columns.Contains("Nombre") && !Convert.IsDBNull(dr["Nombre"]))
                    autor.Nombre = Convert.ToString(dr["Nombre"]);

                if (dr.Table.Columns.Contains("Apellido") && !Convert.IsDBNull(dr["Apellido"]))
                    autor.Apellido = Convert.ToString(dr["Apellido"]);

                if (dr.Table.Columns.Contains("Seudonimo") && !Convert.IsDBNull(dr["Seudonimo"]))
                    autor.Seudonimo = Convert.ToString(dr["Seudonimo"]);

                if (dr.Table.Columns.Contains("Activo") && !Convert.IsDBNull(dr["Activo"]))
                    autor.Activo = Convert.ToBoolean(dr["Activo"]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el método FillObject, " + ex.Message);
            }
            return autor;
        }

        public List<Models.Autor> FillListAutor(DataSet ds)
        {
            return (from DataRow dr in ds.Tables[0].Rows select (new Fill()).FillObjectAutor(dr)).ToList();
        }

        #endregion

        #region Editorial
        public Models.Editorial FillObjectEditorial(DataRow dr)
        {
            Models.Editorial editorial = new Models.Editorial();

            try
            {
                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    editorial.Id = Convert.ToInt32(dr["Id"]);

                if (dr.Table.Columns.Contains("Nombre") && !Convert.IsDBNull(dr["Nombre"]))
                    editorial.Nombre = Convert.ToString(dr["Nombre"]);

                if (dr.Table.Columns.Contains("Activo") && !Convert.IsDBNull(dr["Activo"]))
                    editorial.Activo = Convert.ToBoolean(dr["Activo"]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el método FillObject, " + ex.Message);
            }
            return editorial;
        }

        public List<Models.Editorial> FillListEditorial(DataSet ds)
        {
            return (from DataRow dr in ds.Tables[0].Rows select (new Fill()).FillObjectEditorial(dr)).ToList();
        }
        #endregion

        #region Género
        public Models.Genero FillObjectGenero(DataRow dr)
        {
            Models.Genero genero = new Models.Genero();

            try
            {
                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    genero.Id = Convert.ToInt32(dr["Id"]);

                if (dr.Table.Columns.Contains("Nombre") && !Convert.IsDBNull(dr["Nombre"]))
                    genero.Nombre = Convert.ToString(dr["Nombre"]);

                if (dr.Table.Columns.Contains("Activo") && !Convert.IsDBNull(dr["Activo"]))
                    genero.Activo = Convert.ToBoolean(dr["Activo"]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el método FillObject, " + ex.Message);
            }
            return genero;
        }

        public List<Models.Genero> FillListGenero(DataSet ds)
        {
            return (from DataRow dr in ds.Tables[0].Rows select (new Fill()).FillObjectGenero(dr)).ToList();
        }
        #endregion

        #region Producto
        public Models.Producto FillObjectProducto(DataRow dr)
        {
            Autor _autorDAL = new Autor();
            Genero _generoDAL = new Genero();
            Editorial _editorialDAL = new Editorial();
            Producto _productoDAL = new Producto();

            Models.Producto producto = new Models.Producto();

            try
            {
                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    producto.Id = Convert.ToInt32(dr["Id"]);

                if (dr.Table.Columns.Contains("ISBN") && !Convert.IsDBNull(dr["ISBN"]))
                    producto.ISBN = Convert.ToString(dr["ISBN"]);

                if (dr.Table.Columns.Contains("Nombre") && !Convert.IsDBNull(dr["ISBN"]))
                    producto.Nombre = Convert.ToString(dr["Nombre"]);

                if (dr.Table.Columns.Contains("Precio") && !Convert.IsDBNull(dr["Precio"]))
                    producto.Precio = Convert.ToDouble(dr["Precio"]);

                if (dr.Table.Columns.Contains("CantidadPaginas") && !Convert.IsDBNull(dr["CantidadPaginas"]))
                    producto.CantidadPaginas = Convert.ToInt32(dr["CantidadPaginas"]);

                if (dr.Table.Columns.Contains("EnVenta") && !Convert.IsDBNull(dr["EnVenta"]))
                    producto.EnVenta = Convert.ToBoolean(dr["EnVenta"]);

                if (dr.Table.Columns.Contains("Activo") && !Convert.IsDBNull(dr["Activo"]))
                    producto.Activo = Convert.ToBoolean(dr["Activo"]);

                if (dr.Table.Columns.Contains("AutorId") && !Convert.IsDBNull(dr["AutorId"]))
                    producto.Autor = _autorDAL.GetAutor(Convert.ToInt32(dr["AutorId"]));

                if (dr.Table.Columns.Contains("GeneroId") && !Convert.IsDBNull(dr["GeneroId"]))
                    producto.Genero = _generoDAL.GetGenero(Convert.ToInt32(dr["GeneroId"]));

                if (dr.Table.Columns.Contains("EditorialId") && !Convert.IsDBNull(dr["EditorialId"]))
                    producto.Editorial = _editorialDAL.GetEditorial(Convert.ToInt32(dr["EditorialId"]));

                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    producto.Stock = _productoDAL.GetStock(producto.Id);

                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    producto.Alerta = _productoDAL.GetAlerta(producto.Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el método FillObject, " + ex.Message);
            }
            return producto;
        }

        public List<Models.Producto> FillListProducto(DataSet ds)
        {
            return (from DataRow dr in ds.Tables[0].Rows select (new Fill()).FillObjectProducto(dr)).ToList();
        }
        #endregion

        #region Stock
        public Models.Stock FillObjectStock(DataRow dr)
        {
            Models.Stock stock = new Models.Stock();

            try
            {
                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    stock.Id = Convert.ToInt32(dr["Id"]);

                if (dr.Table.Columns.Contains("Cantidad") && !Convert.IsDBNull(dr["Cantidad"]))
                    stock.Cantidad = Convert.ToInt32(dr["Cantidad"]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el método FillObject, " + ex.Message);
            }

            return stock;
        }
        #endregion

        #region Alerta
        public Models.Alerta FillObjectAlerta(DataRow dr)
        {
            Models.Alerta alerta = new Models.Alerta();

            try
            {
                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    alerta.Id = Convert.ToInt32(dr["Id"]);

                if (dr.Table.Columns.Contains("CantidadStockAviso") && !Convert.IsDBNull(dr["CantidadStockAviso"]))
                    alerta.CantidadStockAviso = Convert.ToInt32(dr["CantidadStockAviso"]);

                if (dr.Table.Columns.Contains("Activo") && !Convert.IsDBNull(dr["Activo"]))
                    alerta.Activo = Convert.ToBoolean(dr["Activo"]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el método FillObject, " + ex.Message);
            }

            return alerta;
        }
        #endregion

        #region Compra
        public Models.ComprobanteCompra FillObjectComprobanteCompra(DataRow dr)
        {
            Compra _compraDAL = new Compra();

            Models.ComprobanteCompra comprobante = new Models.ComprobanteCompra();

            try
            {
                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    comprobante.Id = Convert.ToInt32(dr["Id"]);

                if (dr.Table.Columns.Contains("FechaRecepcion") && !Convert.IsDBNull(dr["FechaRecepcion"]))
                    comprobante.FechaRecepcion = Convert.ToDateTime(dr["FechaRecepcion"]);

                if (dr.Table.Columns.Contains("EnvioId") && !Convert.IsDBNull(dr["EnvioId"]))
                    comprobante.Envio = _compraDAL.GetEnvio(Convert.ToInt32(dr["EnvioId"]));

                if (dr.Table.Columns.Contains("Detalle") && !Convert.IsDBNull(dr["Detalle"]))
                    comprobante.Detalle = Convert.ToString(dr["Detalle"]);

                if (dr.Table.Columns.Contains("Fecha") && !Convert.IsDBNull(dr["Fecha"]))
                    comprobante.Fecha = Convert.ToDateTime(dr["Fecha"]);

                if (dr.Table.Columns.Contains("Total") && !Convert.IsDBNull(dr["Total"]))
                    comprobante.Total = Convert.ToDouble(dr["Total"]);

                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    comprobante.Items = _compraDAL.GetDetalleComprobanteCompra(Convert.ToInt32(dr["Id"]));
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el método FillObject, " + ex.Message);
            }

            return comprobante;
        }

        public List<Models.ComprobanteCompra> FillListComprobanteCompra(DataSet ds)
        {
            return (from DataRow dr in ds.Tables[0].Rows select (new Fill()).FillObjectComprobanteCompra(dr)).ToList();
        }
        #endregion

        #region Envio
        public Models.Envio FillObjectEnvio(DataRow dr)
        {
            Models.Envio envio = new Models.Envio();

            try
            {
                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    envio.Id = Convert.ToInt32(dr["Id"]);

                if (dr.Table.Columns.Contains("Domicilio") && !Convert.IsDBNull(dr["Domicilio"]))
                    envio.Domicilio = Convert.ToString(dr["Domicilio"]);

                if (dr.Table.Columns.Contains("Numero") && !Convert.IsDBNull(dr["Numero"]))
                    envio.Numero = Convert.ToString(dr["Numero"]);


                if (dr.Table.Columns.Contains("EntreCalles") && !Convert.IsDBNull(dr["EntreCalles"]))
                    envio.EntreCalles = Convert.ToString(dr["EntreCalles"]);

                if (dr.Table.Columns.Contains("TelefonoContacto") && !Convert.IsDBNull(dr["TelefonoContacto"]))
                    envio.TelefonoContacto = Convert.ToString(dr["TelefonoContacto"]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el método FillObject, " + ex.Message);
            }

            return envio;
            #endregion
        }
        #region Detalle Comprobante
        public Models.DetalleComprobante FillObjectDetalleComprobante(DataRow dr)
        {
            Producto _productoDAL = new Producto();

            Models.DetalleComprobante detalle = new Models.DetalleComprobante();

            try
            {
                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    detalle.Id = Convert.ToInt32(dr["Id"]);

                if (dr.Table.Columns.Contains("Cantidad") && !Convert.IsDBNull(dr["Cantidad"]))
                    detalle.Cantidad = Convert.ToInt32(dr["Cantidad"]);

                if (dr.Table.Columns.Contains("PrecioUnitario") && !Convert.IsDBNull(dr["PrecioUnitario"]))
                    detalle.PrecioUnitario = Convert.ToDouble(dr["PrecioUnitario"]);

                if (dr.Table.Columns.Contains("ProductoId") && !Convert.IsDBNull(dr["ProductoId"]))
                    detalle.Producto = _productoDAL.GetProducto(Convert.ToInt32(dr["ProductoId"]));

                if (dr.Table.Columns.Contains("Total") && !Convert.IsDBNull(dr["Total"]))
                    detalle.Total = Convert.ToDouble(dr["Total"]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el método FillObject, " + ex.Message);
            }

            return detalle;
        }

        public List<Models.DetalleComprobante> FillListDetalleComprobante(DataSet ds)
        {
            return (from DataRow dr in ds.Tables[0].Rows select (new Fill()).FillObjectDetalleComprobante(dr)).ToList();
        }
        #endregion
    }
}
