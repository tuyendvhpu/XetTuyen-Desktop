using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class MailQueueServices
    {
        public MailQueueServices() 
         { }
        public static bool Insert(MailQueue MailQueue)
        {
            MailQueueADO MailQueueADO = new MailQueueADO();
            
            return MailQueueADO.Insert(MailQueue);
        }
        public static Boolean Update(MailQueue MailQueue)
        {
            MailQueueADO MailQueueADO = new MailQueueADO();
            return MailQueueADO.Update(MailQueue);
        }
        public static bool Delete(long id)
        {
            MailQueueADO MailQueueADO = new MailQueueADO();
            return MailQueueADO.Delete(id);
        }
        public static DataTable LoadByPrimaryKey(long id)
        {
            MailQueueADO MailQueueADO = new MailQueueADO();
            return MailQueueADO.LoadByPrimaryKey(id);
        }
        public static DataTable LoaAll()
        {
            MailQueueADO MailQueueADO = new MailQueueADO();
            return MailQueueADO.LoadAll();
        }
      
        public static DataTable FindMailQueue(string sql)
        {

            MailQueueADO MailQueueADO = new MailQueueADO();
            return MailQueueADO.FinMailQueue(sql);
        }
    }
}
