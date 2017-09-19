using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Audid
    {
	    #region Members
		private bool isChanged;
		
		
		
		private string tableName;
		
		private string columnName;
		
		private string rowID;
		
		private DateTime changedDate;
		
		private string changedBy;
		
		private string oldValue;
		
		private string newValue;

        private string action;
		#endregion
			
		#region Constructors

        public Audid()
        {
            isChanged = true;
            this.tableName = string.Empty;
            this.columnName = string.Empty;
            this.rowID = string.Empty;
            this.changedBy = string.Empty;
            this.newValue = string.Empty;
            this.oldValue = string.Empty;
            this.action = string.Empty;
            
        }

		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
        public Audid(string tableName, string columnName, string rowID, DateTime changedDate, string changedBy, string action)
		{
			isChanged = true;
			
			this.tableName = tableName;
			this.columnName = columnName;
			this.rowID = rowID;
			this.changedDate = changedDate;
			this.changedBy = changedBy;
            this.action = action;
		}

		/// <summary> 
		/// Create a new object by specifying all fields (except the auto-generated primary key field). 
		/// </summary> 
        public Audid(string tableName, string columnName, string rowID, DateTime changedDate, string changedBy, string oldValue, string newValue,string action)
		{
			isChanged = true;
			this.tableName = tableName;
			this.columnName = columnName;
			this.rowID = rowID;
			this.changedDate = changedDate;
			this.changedBy = changedBy;
			this.oldValue = oldValue;
			this.newValue = newValue;
            this.action = action;
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
		/// Property relating to database column TableName
		/// </summary>
		public string TableName
		{
			get { return tableName.TrimEnd(); }
			set { isChanged |= tableName != value; tableName = value; }
		}

		/// <summary>
		/// Property relating to database column ColumnName
		/// </summary>
		public string ColumnName
		{
			get { return columnName.TrimEnd(); }
			set { isChanged |= columnName != value; columnName = value; }
		}

		/// <summary>
		/// Property relating to database column Row_ID
		/// </summary>
		public string RowID
		{
			get { return rowID.TrimEnd(); }
			set { isChanged |= rowID != value; rowID = value; }
		}

		/// <summary>
		/// Property relating to database column Changed_Date
		/// </summary>
        public DateTime ChangedDate
		{
			get { return changedDate; }
			set { isChanged |= changedDate != value; changedDate = value; }
		}

		/// <summary>
		/// Property relating to database column Changed_By
		/// </summary>
		public string ChangedBy
		{
			get { return changedBy.TrimEnd(); }
			set { isChanged |= changedBy != value; changedBy = value; }
		}

		/// <summary>
		/// Property relating to database column Old_Value
		/// </summary>
		public string OldValue
		{
			get { return oldValue != null ? oldValue.TrimEnd() : string.Empty; }
			set { isChanged |= oldValue != value; oldValue = value; }
		}

		/// <summary>
		/// Property relating to database column New_Value
		/// </summary>
		public string NewValue
		{
			get { return newValue != null ? newValue.TrimEnd() : string.Empty; }
			set { isChanged |= newValue != value; newValue = value; }
		}
        /// <summary>
        /// Property relating to database column New_Value
        /// </summary>
        public string Action
        {
            get { return action != null ? action.TrimEnd() : string.Empty; }
            set { isChanged |= action != value; action = value; }
        }
        #endregion


    }
}
