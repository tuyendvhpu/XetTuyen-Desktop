using System;
using System.Data;
using System.Data.SqlClient;
namespace DataAccess
{
    public class DbAccess
    {
        SqlCommand cmd;


        SqlTransaction _sqlTran;
        #region "Open-Close Connection"
        /// <summary>
        /// Open Connection
        /// </summary>
        private void Open()
        {
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            if (Utilities.conDBConnection.State == ConnectionState.Closed)
                Utilities.conDBConnection.Open();
        }

        /// <summary>
        /// Close Connection
        /// </summary>
        private void Close()
        {

            if (Utilities.conDBConnection.State == ConnectionState.Open)
            {
                Utilities.conDBConnection.Close(); 
            }
        }
        #endregion

        #region "Transaction"
        /// <summary>
        /// BeginTransction
        /// </summary>
        public void BeginTransaction()
        {
            //  Utilities.getConnection();
            if (Utilities.conDBConnection.State == ConnectionState.Closed)
                Utilities.conDBConnection.Open();
            _sqlTran = Utilities.conDBConnection.BeginTransaction();
        }

        /// <summary>
        /// Close Connection
        /// </summary>
        public void CommitTransaction()
        {
            _sqlTran.Commit();
            Utilities.conDBConnection.Close();Utilities.conDBConnection.Dispose();
        }

        public void RollbackTransaction()
        {
            _sqlTran.Rollback();
            Utilities.conDBConnection.Close();Utilities.conDBConnection.Dispose();
        }
        #endregion

        #region "Create and Add parameter for SqlCommand"
        /// <summary>
        /// Create New SqlCommand
        /// </summary>
        public void CreateNewSqlCommand()
        {
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            this.cmd = Utilities.conDBConnection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            
        }
        /// <summary>
        /// Create New SqlCommand from SqlCommand
        /// </summary>
        /// <param name="paramName">SqlCommand</param>

        public void CreateNewSqlCommand(SqlCommand cmd)
        {
            this.cmd = new SqlCommand();
            this.cmd = cmd;
            cmd.Connection = Utilities.conDBConnection;
        }

        /// <summary>
        /// Add Parameters for calling stored procedures
        /// </summary>
        /// <param name="paramName">Name of Parameter</param>
        /// <param name="value">Value of Parameter</param>
        public void AddParameter(string paramName, object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = paramName;
            param.Value = value;
            cmd.Parameters.Add(param);
        }

        /// <summary>
        /// Add Parameters for calling stored procedures
        /// </summary>
        /// <param name="paramName">SqlParameter</param>

        public void AddParameter(SqlParameter p)
        {

            this.cmd.Parameters.Add(p);
        }
        #endregion

        #region "Execute SqlCommand"
        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="sProcName">Name of Stored Procedure</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sProcName)
        {
            try
            {
                cmd.CommandText = sProcName;
                this.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Close();
            }
        }

        /// <summary>
        /// ExecuteNonQueryWithTransaction
        /// </summary>
        /// <param name="sProcName">Name of Stored Procedure</param>        
        /// <returns></returns>
        public bool ExecuteNonQueryWithTransaction(string sProcName)
        {
            try
            {
                cmd.CommandText = sProcName;
                cmd.Transaction = _sqlTran;
                cmd.ExecuteNonQuery();
                this.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <param name="sProcName">Name of Stored Procedure</param>
        /// <returns></returns>
        public object ExecuteScalar(string sProcName)
        {
            try
            {
                cmd.CommandText = sProcName;
                this.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Close();
            }
        }

        /// <summary>
        /// ExecuteReader
        /// </summary>
        /// <param name="sProcName">Name of Stored Procedure</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sProcName)
        {
            try
            {
                cmd.CommandText = sProcName;
                this.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ExecuteReaderWithOpenningConnection - Not close connection after reading
        /// </summary>
        /// <param name="sProcName">Name of Stored Procedure</param>        
        /// <returns></returns>
        public SqlDataReader ExecuteReaderWithOpenningConnection(string sProcName)
        {
            try
            {
                cmd.CommandText = sProcName;

                cmd.Transaction = _sqlTran;
                return cmd.ExecuteReader();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ExecuteDataTable
        /// </summary>
        /// <param name="sProcName">Name of Stored Procedure</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sProcName)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandText = sProcName;
                da.SelectCommand = cmd;
                da.Fill(dt);
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
        #endregion
    }
}
