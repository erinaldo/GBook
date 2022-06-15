﻿using DAL.Conexion;
using DAL.Tools;
using Interfaces;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Producto : Acceso, IProducto
    {
        #region Inyección de dependencias
        private readonly Fill _fill;
        public Producto()
        {
            _fill = new Fill();
        }
        #endregion

        #region Querys
        private const string ALTA_PRODUCTO = "INSERT INTO Producto (ISBN, Nombre, Precio, CantidadPaginas, EnVenta, Activo, AutorId, GeneroId, EditorialId)" +
                                           " OUTPUT inserted.Id VALUES (@parISBN, @parNombre, @parPrecio, @parCantidadPaginas, @parEnVenta, @parActivo, " +
                                           " @parAutorId, @parGeneroId, @parEditorialId)";
        private const string ALTA_STOCK = "INSERT INTO Stock (Cantidad, ProductoId) OUTPUT inserted.Id VALUES (@parCantidad, @parProductoId)";
        private const string ALTA_ALERTA = "INSERT INTO Alerta (Activo, CantidadStockAviso, ProductoId) OUTPUT inserted.Id " +
                                            " VALUES (@parActivo, @parCantidadStockAviso, @parProductoId)";
        private const string GET_STOCK = "SELECT Id, Cantidad FROM Stock WHERE ProductoId = {0}";
        private const string GET_PRODUCTO = "SELECT TOP 1 * FROM Producto WHERE ProductoId = {0}";
        private const string GET_PRODUCTOS = "SELECT * FROM Producto";
        #endregion

        #region Métodos CRUD
        public int AltaProducto(Models.Producto producto)
        {
            try
            {
                ExecuteCommandText = ALTA_PRODUCTO;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parISBN", producto.ISBN);
                ExecuteParameters.Parameters.AddWithValue("@parNombre", producto.Nombre);
                ExecuteParameters.Parameters.AddWithValue("@parPrecio", producto.Precio);
                ExecuteParameters.Parameters.AddWithValue("@parCantidadPaginas", producto.CantidadPaginas);
                ExecuteParameters.Parameters.AddWithValue("@parEnVenta", false);
                ExecuteParameters.Parameters.AddWithValue("@parActivo", true);
                ExecuteParameters.Parameters.AddWithValue("@parAutorId", producto.Autor.Id);
                ExecuteParameters.Parameters.AddWithValue("@parGeneroId", producto.Genero.Id);
                ExecuteParameters.Parameters.AddWithValue("@parEditorialId", producto.Editorial.Id);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int AltaStock(int productoId)
        {
            try
            {
                ExecuteCommandText = ALTA_STOCK;

                ExecuteParameters.Parameters.Clear();


                ExecuteParameters.Parameters.AddWithValue("@parCantidad", 0);
                ExecuteParameters.Parameters.AddWithValue("@parProductoId", productoId);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int AltaAlerta(int productoId)
        {
            try
            {
                ExecuteCommandText = ALTA_ALERTA;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parActivo", false);
                ExecuteParameters.Parameters.AddWithValue("@parCantidadStockAviso", 0);
                ExecuteParameters.Parameters.AddWithValue("@parProductoId", productoId);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion

        #region Métodos View
        public Models.Stock GetStock(int productoId)
        {
            try
            {
                SelectCommandText = String.Format(GET_STOCK, productoId);

                DataSet ds = ExecuteNonReader();
                Models.Stock stock = ds.Tables[0].Rows.Count <= 0 ? null : _fill.FillObjectStock(ds.Tables[0].Rows[0]);

                return stock;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public Models.Producto GetProducto(int productoId)
        {
            try
            {
                SelectCommandText = String.Format(GET_PRODUCTO, productoId);

                DataSet ds = ExecuteNonReader();
                Models.Producto producto = ds.Tables[0].Rows.Count <= 0 ? null : _fill.FillObjectProducto(ds.Tables[0].Rows[0]);

                return producto;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public List<Models.Producto> GetProductos()
        {
            try
            {
                SelectCommandText = String.Format(GET_PRODUCTOS);
                DataSet ds = ExecuteNonReader();

                List<Models.Producto> productos = new List<Models.Producto>();

                if (ds.Tables[0].Rows.Count > 0)
                    productos = _fill.FillListProducto(ds);

                return productos;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion
    }
}
