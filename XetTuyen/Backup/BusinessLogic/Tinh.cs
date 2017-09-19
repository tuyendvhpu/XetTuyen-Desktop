using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace BusinessLogic
{
    public class TinhCollection : List<Tinh>
    {
    }
    public class Tinh

    {
        
		#region Members
		private bool isChanged;
		private string maTinh;
		private string tenTinh;
		#endregion
			
		#region Constructors
		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public Tinh(string maTinh)
		{
		    isChanged = true;
			this.maTinh = maTinh;
		}
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public Tinh(string maTinh, string tenTinh)
		{
			this.maTinh = maTinh;
			this.tenTinh = tenTinh;
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
		/// Property relating to database column MaTinh
		/// </summary>
		public string MaTinh
		{
			get { return maTinh.TrimEnd(); }
			set { isChanged |= maTinh != value; maTinh = value; }
		}

		/// <summary>
		/// Property relating to database column TenTinh
		/// </summary>
		public string TenTinh
		{
			get { return tenTinh != null ? tenTinh.TrimEnd() : string.Empty; }
			set { isChanged |= tenTinh != value; tenTinh = value; }
		}
		#endregion

    }
}
