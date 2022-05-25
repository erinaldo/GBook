using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace DAL.Conexion
{
    public class Acceso : Conexion
    {
        SqlConnection connection = new SqlConnection();

        private string _SelectCommandText;
        private string _executeCommandText;
        private SqlCommand _ExecuteParameters = new SqlCommand();
        internal readonly DbProviderFactory BaseFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");

        protected string SelectCommandText
        {
            get { return _SelectCommandText; }
            set { _SelectCommandText = value; }
        }
        protected string ExecuteCommandText
        {
            get { return _executeCommandText; }
            set { _executeCommandText = value; }
        }
        protected SqlCommand ExecuteParameters
        {
            get { return _ExecuteParameters; }
            set { _ExecuteParameters = value; }
        }

        private void Conectar()
        {
            connection.ConnectionString = conexion;
            connection.Open();
        }
        private void Desconectar()
        {
            connection.Close();           
        }

        public virtual void executeNonQuery()
        {
            //abro la conexión
            Conectar();

            //comando a ejecutar
            SqlTransaction TR = connection.BeginTransaction();
            SqlCommand command = new SqlCommand(ExecuteCommandText, connection, TR);
            
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();

            //agrego los parámetros al comando
            foreach (SqlParameter p in ExecuteParameters.Parameters)
            {
                command.Parameters.AddWithValue(p.ParameterName, p.SqlValue);
            }

            try
            {
                //ejecuto la sentencia
                command.ExecuteNonQuery();
                TR.Commit();
            }
            //error de SQL
            catch (SqlException exc)
            {
                //en caso de error disparo excepción
                TR.Rollback();
                throw new Exception("ocurrio un Error en BD:" + exc.Message);
            }
            //error general
            catch (Exception exc2)
            {
                //en caso de error disparo excepción
                TR.Rollback();
                throw new Exception("ocurrio un Error :" + exc2.Message);
            }
            finally
            {
                //cierro la conexión
                Desconectar();
            }
        }

        public virtual int ExecuteNonEscalar()
        {
            Conectar();
            SqlTransaction transaction = connection.BeginTransaction();
            SqlCommand command = new SqlCommand(ExecuteCommandText, connection, transaction);
            
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            
            //agrego los parámetros al comando
            foreach (SqlParameter p in ExecuteParameters.Parameters)
            {
                command.Parameters.AddWithValue(p.ParameterName, p.SqlValue);
            }

            //parámetro de retorno
            SqlParameter sp_return = new SqlParameter();
            sp_return.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(sp_return);

            int outputId = 0;

            try
            {
                outputId = (int)command.ExecuteScalar();
                transaction.Commit();
            }
            //error de SQL
            catch (SqlException exc)
            {
                transaction.Rollback();
                throw new Exception("ocurrio un Error en BD:" + exc.Message);
            }
            //error general
            catch (Exception exc2)
            {
                transaction.Rollback();
                throw new Exception("ocurrio un Error :" + exc2.Message);
            }
            finally
            {
                Desconectar();
            }

            return outputId;
        }

        public virtual DataSet Load()
        {
            // Check select command text first 
            if (this.SelectCommandText == "")
                throw new Exception("You must provide SelectCommandText first. Review Framework documentation.");

            // Create Connection
            using (connection)
            {
                // create Adapter
                DbDataAdapter da = this.BaseFactory.CreateDataAdapter();

                // create Command
                da.SelectCommand = this.BaseFactory.CreateCommand();

                // assign Command Text
                da.SelectCommand.CommandText = this.SelectCommandText;

                // assign connection
                da.SelectCommand.Connection = connection;

                // Instance New DataSet
                DataSet ds = new DataSet();
                // open connection and execute command
                try
                {
                    Conectar();
                    da.Fill(ds);
                }
                catch (SqlException e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    Desconectar();
                }

                // return DataSet
                return ds;
            }
        }
    }
}
