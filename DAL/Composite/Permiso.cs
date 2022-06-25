﻿using DAL.Conexion;
using DAL.Tools;
using Models.Composite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Composite
{
    public class Permiso : Acceso
    {
        #region Inyección de dependencias
        private readonly Fill _fill;
        public Permiso()
        {
            _fill = new Fill();
        }
        #endregion

        #region Querys
        private const string GUARDAR_COMPONENTE = "INSERT INTO Patente (Nombre, Permiso) OUTPUT inserted.Id VALUES (@parNombre, @parPermiso)";
        private const string BORRAR_FAMILIA = "DELETE FROM FamiliaPatente WHERE PadreId = @parId";
        private const string GUARDAR_FAMILIA = "INSERT INTO FamiliaPatente (PadreId, HijoId) VALUES (@parPadreId, @parHijoId)";
        private const string GET_FAMILIAS = "SELECT * FROM Patente WHERE Permiso IS NULL";
        private const string GET_PATENTES = "SELECT * FROM Patente WHERE Permiso IS NOT NULL";
        private const string GET_FAMILIA_PATENTE = "WITH RECURSIVO AS (SELECT fp.PadreId, fp.HijoId FROM FamiliaPatente fp WHERE fp.PadreId = {0}" +
                                                    " UNION ALL SELECT fp2.PadreId, fp2.HijoId FROM FamiliaPatente fp2 INNER JOIN RECURSIVO r on r.HijoId = fp2.PadreId) " +
                                                    " SELECT r.PadreId, r.HijoId, p.Id as PermisoId, p.Nombre, p.Permiso FROM RECURSIVO r INNER JOIN Patente p on r.HijoId = p.Id";
        #endregion

        #region Métodos CRUD
        public int GuardarPatenteFamilia(Componente componente, bool familia)
        {
            try
            {
                ExecuteCommandText = GUARDAR_COMPONENTE;

                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parNombre", componente.Nombre);
                if (familia) ExecuteParameters.Parameters.AddWithValue("@parPermiso", DBNull.Value);
                else ExecuteParameters.Parameters.AddWithValue("@parPermiso", componente.Permiso.ToString());

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public void GuardarFamiliaCreada(Familia familia)
        {
            try
            {
                ExecuteCommandText = BORRAR_FAMILIA;
                ExecuteParameters.Parameters.Clear();

                ExecuteParameters.Parameters.AddWithValue("@parId", familia.Id);

                ExecuteNonQuery();

                foreach (Componente item in familia.Hijos)
                {
                    ExecuteCommandText = GUARDAR_FAMILIA;
                    ExecuteParameters.Parameters.Clear();

                    ExecuteParameters.Parameters.AddWithValue("@parPadreId", familia.Id);
                    ExecuteParameters.Parameters.AddWithValue("@parHijoId", item.Id);
                    ExecuteNonQuery();
                }
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion

        #region Métodos View
        public IList<Familia> GetFamilias()
        {
            try
            {
                SelectCommandText = String.Format(GET_FAMILIAS);
                DataSet ds = ExecuteNonReader();

                IList<Models.Composite.Familia> familias = new List<Models.Composite.Familia>();

                if (ds.Tables[0].Rows.Count > 0)
                    familias = _fill.FillListFamilia(ds);

                return familias;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public IList<Patente> GetPatentes()
        {
            try
            {
                SelectCommandText = String.Format(GET_PATENTES);
                DataSet ds = ExecuteNonReader();

                IList<Models.Composite.Patente> patentes = new List<Models.Composite.Patente>();

                if (ds.Tables[0].Rows.Count > 0)
                    patentes = _fill.FillListPatente(ds);

                return patentes;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public IList<Models.Composite.Componente> TraerFamiliaPatentes(int familiaId)
        {
            try
            {
                SelectCommandText = String.Format(GET_FAMILIA_PATENTE, familiaId);
                DataSet ds = ExecuteNonReader();
                DataTable dt = ds.Tables[0];


                List<Componente> componentes = new List<Componente>();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow rows in dt.Rows)
                    {
                        int padreId = 0;
                        if (rows["PadreId"] != DBNull.Value)
                        {
                            padreId = int.Parse(rows["PadreId"].ToString());
                        }

                        int Id = int.Parse(rows["PermisoId"].ToString());
                        string nombre = rows["Nombre"].ToString();
                        string permiso = string.Empty;
                        if (rows["Permiso"] != DBNull.Value) permiso = rows["Permiso"].ToString();

                        Componente componente;
                        if (!string.IsNullOrEmpty(permiso)) componente = new Familia();
                        else componente = new Patente();

                        componente.Id = Id;
                        componente.Nombre = nombre;
                        if (!string.IsNullOrEmpty(permiso)) componente.Permiso = (Models.Composite.Permiso)Enum.Parse(typeof(Models.Composite.Permiso), permiso);

                        Componente padre = GetComponente(padreId, componentes);
                        if (padre == null) componentes.Add(componente);
                        else padre.AgregarHijo(componente);
                    }
                }
                return componentes;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion

        #region Tools
        private Componente GetComponente(int id, IList<Componente> lista)
        {
            Componente componente = lista != null ? lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;

            if (componente == null && lista != null)
            {
                foreach (var item in lista)
                {
                    var _lista = GetComponente(id, item.Hijos);
                    if (_lista != null && _lista.Id == id) return _lista;
                    else if (_lista != null) return GetComponente(id, _lista.Hijos);
                }
            }
            return componente;
        }
        #endregion
    }
}
