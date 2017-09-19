using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Nganh
    {
      #region Members
		private bool isChanged;
		
		private string iDNganh;
		
		private string maNganh;
		
		private string maKhoi;
		
		private int nam;
		
		private string tenNganh;
		#endregion
			
		#region Constructors			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public Nganh(string iDNganh, string maNganh, string maKhoi, int nam, string tenNganh)
		{
			this.iDNganh = iDNganh;
			this.maNganh = maNganh;
			this.maKhoi = maKhoi;
			this.nam = nam;
			this.tenNganh = tenNganh;
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
		/// Property relating to database column IDNganh
		/// </summary>
		public string IDNganh
		{
			get { return iDNganh.TrimEnd(); }
			set { isChanged |= iDNganh != value; iDNganh = value; }
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
		/// Property relating to database column MaKhoi
		/// </summary>
		public string MaKhoi
		{
			get { return maKhoi.TrimEnd(); }
			set { isChanged |= maKhoi != value; maKhoi = value; }
		}

		/// <summary>
		/// Property relating to database column Nam
		/// </summary>
		public int Nam
		{
			get { return nam; }
			set { isChanged |= nam != value; nam = value; }
		}

		/// <summary>
		/// Property relating to database column TenNganh
		/// </summary>
		public string TenNganh
		{
			get { return tenNganh.TrimEnd(); }
			set { isChanged |= tenNganh != value; tenNganh = value; }
		}
		#endregion


    }
}
