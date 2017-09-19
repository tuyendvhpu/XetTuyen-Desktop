using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class DieuKienCollection : List<DieuKien>
    {
    }
    public class DieuKien
    {
	    #region Members
		private bool isChanged;
		private string iDNganh;
		private string maNganh;
		private string maKhoi;
		private string maDot;
		private int nam;
		private double diemChuan;
		private double diemSan;
		#endregion
			
		#region Constructors			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
        public DieuKien()
        {
            this.diemChuan = 0;
            this.diemSan = 0;
        }
		public DieuKien(string iDNganh, string maNganh, string maKhoi, string maDot, int nam, double diemChuan, double diemSan)
		{
			this.iDNganh = iDNganh;
			this.maNganh = maNganh;
			this.maKhoi = maKhoi;
			this.maDot = maDot;
			this.nam = nam;
			this.diemChuan = diemChuan;
			this.diemSan = diemSan;
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
		/// Property relating to database column IDNghanh
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
		/// Property relating to database column DiemChuan
		/// </summary>
		public double DiemChuan
		{
			get { return diemChuan; }
			set { isChanged |= diemChuan != value; diemChuan = value; }
		}

		/// <summary>
		/// Property relating to database column DiemSan
		/// </summary>
		public double DiemSan
		{
			get { return diemSan; }
			set { isChanged |= diemSan != value; diemSan = value; }
		}
		#endregion


    }
}
