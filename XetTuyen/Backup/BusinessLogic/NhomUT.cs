using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace BusinessLogic
{
    public class NhomUTCollection : List<NhomUT>
    {
    }
    public class NhomUT
    {

       
		#region Members
		private bool isChanged;
		
		private string maN;
		
		private string tenNhom;
		
		private int nam;
		#endregion
			
		#region Constructors
		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public NhomUT(string maN)
		{
			isChanged = true;
			this.maN = maN;
		}
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public NhomUT(string maN, string tenNhom, int nam)
		{
			this.maN = maN;
			this.tenNhom = tenNhom;
			this.nam = nam;
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
		/// Property relating to database column MaN
		/// </summary>
		public string MaN
		{
			get { return maN.TrimEnd(); }
			set { isChanged |= maN != value; maN = value; }
		}

		/// <summary>
		/// Property relating to database column TenNhom
		/// </summary>
		public string TenNhom
		{
			get { return tenNhom != null ? tenNhom.TrimEnd() : string.Empty; }
			set { isChanged |= tenNhom != value; tenNhom = value; }
		}

		/// <summary>
		/// Property relating to database column Nam
		/// </summary>
		public int Nam
		{
			get { return nam; }
			set { isChanged |= nam != value; nam = value; }
		}
		#endregion

    }
}
