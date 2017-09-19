using System;
using System.Data;
using System.Data.SqlClient;
using BusinessLogic;
using BusinessService;
using Common;
using DataAccess;
namespace DataAccess
{

    public class DbConnection
    {
        private static SqlConnection _cnn = new SqlConnection(clsCommon.sConnectionString);
        public static SqlConnection SqlConnection
        {
            get { return _cnn; }
            set { _cnn = value; }
        }

        public static void Open()
        {
            if(_cnn.State==ConnectionState.Closed)
            _cnn.Open();
        }

        public static void Close()
        {
            if (_cnn.State == ConnectionState.Open)
            _cnn.Close();
        }
    }


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
          
          
            DbConnection.Open();
        }

        /// <summary>
        /// Close Connection
        /// </summary>
        private void Close()
        {
            
           
            DbConnection.Close();
        }
        #endregion

        #region "Transaction"
        /// <summary>
        /// BeginTransction
        /// </summary>
        public void BeginTransaction()
        {
         
            DbConnection.Open();
            _sqlTran = DbConnection.SqlConnection.BeginTransaction();       
        }

        /// <summary>
        /// Close Connection
        /// </summary>
        public void CommitTransaction()
        {
            _sqlTran.Commit();
            DbConnection.Close();
        }

        public void RollbackTransaction()
        {
            _sqlTran.Rollback();
            DbConnection.Close();
        }
        #endregion

        #region "Create and Add parameter for SqlCommand"
        /// <summary>
        /// Create New SqlCommand
        /// </summary>
        public void CreateNewSqlCommand()
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = DbConnection.SqlConnection;       
        }
        public void CreateNewSqlCommandText()
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DbConnection.SqlConnection;
        }
        /// <summary>
        /// Create New SqlCommand from SqlCommand
        /// </summary>
        /// <param name="paramName">SqlCommand</param>
        
        public void CreateNewSqlCommand(SqlCommand cmd)
        {
           // cmd = new SqlCommand();
            this.cmd = cmd;
            cmd.Connection = DbConnection.SqlConnection;  
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
           
            cmd.Parameters.Add(p);
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
