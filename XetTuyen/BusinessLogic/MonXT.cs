using System;
using System.Collections.Generic;
using System.Text;
using Common;
namespace BusinessLogic
{
    public class MonXTCollection : List<MonXT>
    {
    }
    public class MonXT
    {

      #region Members
		private bool isChanged;
		
		private string maMon;
		
		private string tenMon;
		#endregion
			
		#region Constructors
		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public MonXT(string maMon)
		{
			isChanged = true;
			this.maMon = maMon;
		}
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public MonXT(string maMon, string tenMon)
		{
			this.maMon = maMon;
			this.tenMon = tenMon;
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
		/// Property relating to database column MaMon
		/// </summary>
		public string MaMon
		{
			get { return maMon.TrimEnd(); }
			set { isChanged |= maMon != value; maMon = value; }
		}

		/// <summary>
		/// Property relating to database column TenMon
		/// </summary>
		public string TenMon
		{
			get { return tenMon != null ? tenMon.TrimEnd() : string.Empty; }
			set { isChanged |= tenMon != value; tenMon = value; }
		}
		#endregion

    }
}
