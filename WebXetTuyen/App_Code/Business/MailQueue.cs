using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class MailQueue
    {
        #region Members
        private bool isChanged;
        private long id;
        private DateTime dateToProcess;
        private DateTime dateProcessed;
        private string fromName;
        private string fromAddress;
        private string tite;
        private string toAddress;
        private string cc;
        private string bcc;
        private string status;
        private int priority;
        private string body;
        #endregion

        #region Constructors
        /// <summary> 
        /// Create a new object using the minimum required information (all not-null fields except 
        /// auto-generated primary keys). 
        /// </summary> 
        public MailQueue()
        {
            isChanged = true;
            id = 0;
        }

        /// <summary> 
        /// Create a new object by specifying all fields (except the auto-generated primary key field). 
        /// </summary> 
        public MailQueue(DateTime dateToProcess, DateTime dateProcessed, string fromName, string fromAddress,string tite, string toAddress, string cc, string bcc, string status, int priority, string body)
        {
            isChanged = true;
            this.dateToProcess = dateToProcess;
            this.dateProcessed = dateProcessed;
            this.fromName = fromName;
            this.fromAddress = fromAddress;
            this.tite = tite;
            this.toAddress = toAddress;
            this.cc = cc;
            this.bcc = bcc;
            this.status = status;
            this.priority = priority;
            this.body = body;
        }

        /// <summary> 
        /// Create an object from an existing row of data. This will be used by Gentle to 
        /// construct objects from retrieved rows. 
        /// </summary> 
        public MailQueue(long id, DateTime dateToProcess, DateTime dateProcessed, string fromName, string fromAddress,  string tite, string toAddress, string cc, string bcc, string status, int priority, string body)
        {
            this.id = id;
            this.dateToProcess = dateToProcess;
            this.dateProcessed = dateProcessed;
            this.fromName = fromName;
            this.fromAddress = fromAddress;
            this.tite = tite;
            this.toAddress = toAddress;
            this.cc = cc;
            this.bcc = bcc;
            this.status = status;
            this.priority = priority;
            this.body = body;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Indicates whether the entity is changed and requires saving or not.
        /// </summary>
        public bool IsChanged
        {
            get { return isChanged; }
        }

        /// <summary>
        /// Property relating to database column ID
        /// </summary>
        public long Id
        {
            get { return id; }
        }

        /// <summary>
        /// Property relating to database column DateToProcess
        /// </summary>
        public DateTime DateToProcess
        {
            get { return dateToProcess; }
            set { isChanged |= dateToProcess != value; dateToProcess = value; }
        }

        /// <summary>
        /// Property relating to database column DateProcessed
        /// </summary>
        public DateTime DateProcessed
        {
            get { return dateProcessed; }
            set { isChanged |= dateProcessed != value; dateProcessed = value; }
        }

        /// <summary>
        /// Property relating to database column FromName
        /// </summary>
        public string FromName
        {
            get { return fromName != null ? fromName.TrimEnd() : string.Empty; }
            set { isChanged |= fromName != value; fromName = value; }
        }

        /// <summary>
        /// Property relating to database column FromAddress
        /// </summary>
        public string FromAddress
        {
            get { return fromAddress != null ? fromAddress.TrimEnd() : string.Empty; }
            set { isChanged |= fromAddress != value; fromAddress = value; }
        }

       

        /// <summary>
        /// Property relating to database column Tite
        /// </summary>
        public string Tite
        {
            get { return tite != null ? tite.TrimEnd() : string.Empty; }
            set { isChanged |= tite != value; tite = value; }
        }

        /// <summary>
        /// Property relating to database column ToAddress
        /// </summary>
        public string ToAddress
        {
            get { return toAddress != null ? toAddress.TrimEnd() : string.Empty; }
            set { isChanged |= toAddress != value; toAddress = value; }
        }

        /// <summary>
        /// Property relating to database column CC
        /// </summary>
        public string Cc
        {
            get { return cc != null ? cc.TrimEnd() : string.Empty; }
            set { isChanged |= cc != value; cc = value; }
        }

        /// <summary>
        /// Property relating to database column BCC
        /// </summary>
        public string Bcc
        {
            get { return bcc != null ? bcc.TrimEnd() : string.Empty; }
            set { isChanged |= bcc != value; bcc = value; }
        }

        /// <summary>
        /// Property relating to database column Status
        /// </summary>
        public string Status
        {
            get { return status != null ? status.TrimEnd() : string.Empty; }
            set { isChanged |= status != value; status = value; }
        }

        /// <summary>
        /// Property relating to database column Priority
        /// </summary>
        public int Priority
        {
            get { return priority; }
            set { isChanged |= priority != value; priority = value; }
        }

        /// <summary>
        /// Property relating to database column Body
        /// </summary>
        public string Body
        {
            get { return body != null ? body.TrimEnd() : string.Empty; }
            set { isChanged |= body != value; body = value; }
        }
        #endregion
    }
}
