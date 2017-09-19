using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
     class MailQueueADO
    {
         private DataTable dataTable ;
        
        public MailQueueADO()
        {
        }
      

            public  bool Insert(MailQueue MailQueue) {
            SqlCommand cmd = CreateParameters(MailQueue);
            cmd.CommandText = "[proc_MailQueueInsert]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(MailQueue MailQueue) {
            SqlCommand cmd = CreateParameters(MailQueue);
            cmd.CommandText = "[proc_MailQueueUpdate]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
          
        }
       
        public bool Delete( long id)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_MailQueueDelete]";

            SqlParameter p;
            p = cmd.Parameters.Add(Parameters.ID);
            p.Value = id;
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public DataTable LoadAll()
        {

            if (Utilities.conDBConnection == null) Utilities.getConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_MailQueueLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();

           
            return dataTable;
        }
        public DataTable FinMailQueue(string sql) {
            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();

            return dataTable;
        }
        public DataTable LoadByPrimaryKey(long id)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_MailQueueLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.ID;
            p.Value = id;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();

            return dataTable;
        }
        
       
	 protected SqlCommand CreateParameters(MailQueue MailQueue)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

          
            p = cmd.Parameters.Add(Parameters.BCC);
            p.Value = MailQueue.Bcc;

            p = cmd.Parameters.Add(Parameters.Body);
            p.Value = MailQueue.Body;

            p = cmd.Parameters.Add(Parameters.CC);
            p.Value = MailQueue.Cc;

            p = cmd.Parameters.Add(Parameters.DateProcessed);
            p.Value = MailQueue.DateProcessed;

            p = cmd.Parameters.Add(Parameters.DateToProcess);
            p.Value = MailQueue.DateToProcess ;


            p = cmd.Parameters.Add(Parameters.FromAddress);
            p.Value = MailQueue.FromAddress;

            p = cmd.Parameters.Add(Parameters.FromName);
            p.Value = MailQueue.FromName;

            p = cmd.Parameters.Add(Parameters.ID);
            p.Value = MailQueue.Id;

            p = cmd.Parameters.Add(Parameters.Priority);
            p.Value = MailQueue.Priority;

            p = cmd.Parameters.Add(Parameters.Status);
            p.Value = MailQueue.Status;

            

            p = cmd.Parameters.Add(Parameters.ToAddress);
            p.Value = MailQueue.ToAddress;


          

            p = cmd.Parameters.Add(Parameters.Tite);
            p.Value = MailQueue.Tite;





    
            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter ID
         {
             get
             {
                 return new SqlParameter("@ID", SqlDbType.BigInt, 0);
             }
         }

         public static SqlParameter DateToProcess
         {
             get
             {
                 return new SqlParameter("@DateToProcess", SqlDbType.DateTime, 0);
             }
         }

         public static SqlParameter DateProcessed
         {
             get
             {
                 return new SqlParameter("@DateProcessed", SqlDbType.DateTime, 0);
             }
         }

         public static SqlParameter FromName
         {
             get
             {
                 return new SqlParameter("@FromName", SqlDbType.VarChar, 100);
             }
         }

         public static SqlParameter FromAddress
         {
             get
             {
                 return new SqlParameter("@FromAddress", SqlDbType.VarChar, 400);
             }
         }

        

         public static SqlParameter Tite
         {
             get
             {
                 return new SqlParameter("@Tite", SqlDbType.NVarChar, 400);
             }
         }

         public static SqlParameter ToAddress
         {
             get
             {
                 return new SqlParameter("@ToAddress", SqlDbType.VarChar, 400);
             }
         }

         public static SqlParameter CC
         {
             get
             {
                 return new SqlParameter("@CC", SqlDbType.VarChar, 400);
             }
         }

         public static SqlParameter BCC
         {
             get
             {
                 return new SqlParameter("@BCC", SqlDbType.VarChar, 400);
             }
         }

         public static SqlParameter Status
         {
             get
             {
                 return new SqlParameter("@Status", SqlDbType.VarChar, 800);
             }
         }

         public static SqlParameter Priority
         {
             get
             {
                 return new SqlParameter("@Priority", SqlDbType.Int, 0);
             }
         }

         public static SqlParameter Body
         {
             get
             {
                 return new SqlParameter("@Body", SqlDbType.NText, 1073741823);
             }
         }

     }
     #endregion		
	
	
    }
}
