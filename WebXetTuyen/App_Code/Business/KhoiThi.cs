using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class KhoiThi
    {

       #region Members
		private bool isChanged;
		
		private string maKhoi;
		
		private int nam;
		
		private string tenKhoi;
		#endregion
			
		#region Constructors
		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public KhoiThi(string maKhoi, int nam)
		{
			isChanged = true;
			this.maKhoi = maKhoi;
			this.nam = nam;
		}
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public KhoiThi(string maKhoi, int nam, string tenKhoi)
		{
			this.maKhoi = maKhoi;
			this.nam = nam;
			this.tenKhoi = tenKhoi;
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
        /// Property relating to database column TenKhoi
        /// </summary>
        public string TenKhoi
        {
            get { return tenKhoi != null ? tenKhoi.TrimEnd() : string.Empty; }
            set { isChanged |= tenKhoi != value; tenKhoi = value; }
        }
        #endregion

    }
}
