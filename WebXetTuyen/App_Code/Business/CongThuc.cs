using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class CongThuc
    {
#region Members
		private bool isChanged;
		
		private string maNganh;
		
		private string iDNganh;
		
		private string maKHoi;
		
		private string maDot;
		
		private int nam;
		
		private double heSo;
		
		private string maMon;
		#endregion
			
		#region Constructors			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public CongThuc(string maNganh, string iDNganh, string maKHoi, string maDot, int nam, double heSo, string maMon)
		{
			this.maNganh = maNganh;
			this.iDNganh = iDNganh;
			this.maKHoi = maKHoi;
			this.maDot = maDot;
			this.nam = nam;
			this.heSo = heSo;
			this.maMon = maMon;
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
		/// Property relating to database column IDNganh
		/// </summary>
		public string IDNganh
		{
			get { return iDNganh.TrimEnd(); }
			set { isChanged |= iDNganh != value; iDNganh = value; }
		}

		/// <summary>
		/// Property relating to database column MaKHoi
		/// </summary>
		public string MaKHoi
		{
			get { return maKHoi.TrimEnd(); }
			set { isChanged |= maKHoi != value; maKHoi = value; }
		}

		/// <summary>
		/// Property relating to database column MaDot
		/// </summary>
		public string MaDot
		{
			get { return maDot.TrimEnd(); }
			set { isChanged |= maDot != value; maDot = value; }
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
		/// Property relating to database column HeSo
		/// </summary>
		public double HeSo
		{
			get { return heSo; }
			set { isChanged |= heSo != value; heSo = value; }
		}

		/// <summary>
		/// Property relating to database column MaMon
		/// </summary>
		public string MaMon
		{
			get { return maMon.TrimEnd(); }
			set { isChanged |= maMon != value; maMon = value; }
		}
		#endregion
    }
}
