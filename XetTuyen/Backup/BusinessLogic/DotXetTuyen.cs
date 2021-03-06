﻿using System;
using System.Collections.Generic;
using System.Text;
using Common;
namespace BusinessLogic
{
    public class DotXetTuyenCollection : List<DotXetTuyen>
    {
    }
    public class DotXetTuyen
    {

       #region Members
		private bool isChanged;
		
		private string maDot;
		
		private int nam;
		
		private DateTime ngayBD;
		
		private DateTime ngayKT;
        private string tenDot;
		#endregion
			
		#region Constructors			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
        /// 
        public DotXetTuyen() { this.isChanged = true; }
		public DotXetTuyen(string maDot, int nam, DateTime ngayBD, DateTime ngayKT, string tenDot)
		{
			this.maDot = maDot;
			this.nam = nam;
			this.ngayBD = ngayBD;
			this.ngayKT = ngayKT;
            this.tenDot = tenDot;
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
		/// Property relating to database column NgayBD
		/// </summary>
		public DateTime NgayBD
		{
			get { return ngayBD; }
			set { isChanged |= ngayBD != value; ngayBD = value; }
		}

		/// <summary>
		/// Property relating to database column NgayKT
		/// </summary>
		public DateTime NgayKT
		{
			get { return ngayKT; }
			set { isChanged |= ngayKT != value; ngayKT = value; }
		}
        /// <summary>
        /// Property relating to database column TenDot
        /// </summary>
        public String TenDot
        {
            get { return tenDot; }
            set { isChanged |= tenDot != value; tenDot = value; }
        }
		#endregion
    }
}
