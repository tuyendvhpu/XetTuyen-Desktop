using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Huyen
    {

        #region Members
        private bool isChanged;

        private string maHuyen;

        private string maTinh;

        private string tenHuyen;
        #endregion

        #region Constructors
        /// <summary> 
        /// Create a new object using the minimum required information (all not-null fields except 
        /// auto-generated primary keys). 
        /// </summary> 
        public Huyen(string maHuyen, string maTinh)
        {
            isChanged = true;
            this.maHuyen = maHuyen;
            this.maTinh = maTinh;
        }

        /// <summary> 
        /// Create an object from an existing row of data. This will be used by Gentle to 
        /// construct objects from retrieved rows. 
        /// </summary> 
        public Huyen(string maHuyen, string maTinh, string tenHuyen)
        {
            this.maHuyen = maHuyen;
            this.maTinh = maTinh;
            this.tenHuyen = tenHuyen;
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
        /// Property relating to database column MaHuyen
        /// </summary>
        public string MaHuyen
        {
            get { return maHuyen.TrimEnd(); }
            set { isChanged |= maHuyen != value; maHuyen = value; }
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
        /// Property relating to database column TenHuyen
        /// </summary>
        public string TenHuyen
        {
            get { return tenHuyen != null ? tenHuyen.TrimEnd() : string.Empty; }
            set { isChanged |= tenHuyen != value; tenHuyen = value; }
        }
        #endregion
    }
}
