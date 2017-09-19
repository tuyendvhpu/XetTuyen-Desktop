using System;
using System.Collections.Generic;
using System.Text;
using Common;
namespace BusinessLogic
{
    public class NhomNganhCollection : List<NhomNganh>
    {
    }
    public class NhomNganh
    {

     #region Members
		private bool isChanged;
		
		private string maNganh;
		
		private string maTruong;
		
		private string tenNganh;
		
		private string loaiNganh;
		#endregion
			
		#region Constructors
		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public NhomNganh(string maNganh, string maTruong, string tenNganh)
		{
			isChanged = true;
			this.maNganh = maNganh;
			this.maTruong = maTruong;
			this.tenNganh = tenNganh;
		}
        public NhomNganh()
        {
            isChanged = true;
            
        }
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public NhomNganh(string maNganh, string maTruong, string tenNganh, string loaiNganh)
		{
			this.maNganh = maNganh;
			this.maTruong = maTruong;
			this.tenNganh = tenNganh;
			this.loaiNganh = loaiNganh;
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
		/// Property relating to database column MaNganh
		/// </summary>
		public string MaNganh
		{
			get { return maNganh.TrimEnd(); }
			set { isChanged |= maNganh != value; maNganh = value; }
		}

		/// <summary>
		/// Property relating to database column MaTruong
		/// </summary>
		public string MaTruong
		{
			get { return maTruong.TrimEnd(); }
			set { isChanged |= maTruong != value; maTruong = value; }
		}

		/// <summary>
		/// Property relating to database column TenNganh
		/// </summary>
		public string TenNganh
		{
			get { return tenNganh.TrimEnd(); }
			set { isChanged |= tenNganh != value; tenNganh = value; }
		}

		/// <summary>
		/// Property relating to database column LoaiNganh
		/// </summary>
		public string LoaiNganh
		{
			get { return loaiNganh != null ? loaiNganh.TrimEnd() : string.Empty; }
			set { isChanged |= loaiNganh != value; loaiNganh = value; }
		}
		#endregion
    }
}
