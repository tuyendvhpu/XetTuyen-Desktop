using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace BusinessLogic
{
    public class DiemXetTuyenCollection : List<DiemXetTuyen>
    {
    }
    public class DiemXetTuyen
    {
    #region Members
		private bool isChanged;
		private long idhs;
		private int maMon;
		private double diem;
		private string maKhoi;
		#endregion
			
		#region Constructors			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
        public DiemXetTuyen()
        {
           
        }
        public DiemXetTuyen(long idhs, int maMon, double diem, string maKhoi)
		{
			this.idhs = idhs;
			this.maMon = maMon;
			this.diem = diem;
			this.maKhoi = maKhoi;
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
		/// Property relating to database column IDHS
		/// </summary>
		public long Idhs
		{
			get { return idhs; }
			set { isChanged |= idhs != value; idhs = value; }
		}

		/// <summary>
		/// Property relating to database column MaMon
		/// </summary>
		public int MaMon
		{
			get { return maMon; }
			set { isChanged |= maMon != value; maMon = value; }
		}

		/// <summary>
		/// Property relating to database column Diem
		/// </summary>
		public double Diem
		{
			get { return diem; }
			set { isChanged |= diem != value; diem = value; }
		}

		/// <summary>
		/// Property relating to database column MaKhoi
		/// </summary>
		public string MaKhoi
		{
			get { return maKhoi.TrimEnd(); }
			set { isChanged |= maKhoi != value; maKhoi = value; }
		}
		#endregion

    }
}
