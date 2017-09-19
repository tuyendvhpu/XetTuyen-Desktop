using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace BusinessLogic
{
    public class TruongPTCollection : List<TruongPT>
    {
    }
    public class TruongPT
    {
        #region Members
        private bool isChanged;

        private string maTruong;

        private string maTinh;

        private int nam;

        private string maKV;



        private string tenTruong;

        private string diaChi;
        #endregion

        #region Constructors
        /// <summary> 
        /// Create a new object using the minimum required information (all not-null fields except 
        /// auto-generated primary keys). 
        /// </summary> 
        public TruongPT(string maTruong, string maTinh, int nam, string maKV, string tenTruong)
        {
            isChanged = true;
            this.maTruong = maTruong;
            this.maKV = maKV;
            this.maTinh = maTinh;
            this.tenTruong = tenTruong;
            this.nam = nam;
        }

        /// <summary> 
        /// Create an object from an existing row of data. This will be used by Gentle to 
        /// construct objects from retrieved rows. 
        /// </summary> 
        public TruongPT(string maTruong, string maTinh, int nam, string maKV, string tenTruong, string diaChi)
        {
            this.maTruong = maTruong;
            this.maKV = maKV;
            this.maTinh = maTinh;
            this.tenTruong = tenTruong;
            this.diaChi = diaChi;
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
        /// Property relating to database column MaTruong
        /// </summary>
        public string MaTruong
        {
            get { return maTruong.TrimEnd(); }
            set { isChanged |= maTruong != value; maTruong = value; }
        }

        /// <summary>
        /// Property relating to database column MaKV
        /// </summary>
        public string MaKV
        {
            get { return maKV.TrimEnd(); }
            set { isChanged |= maKV != value; maKV = value; }
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
        /// Property relating to database column Nam
        /// </summary>
        public int Nam
        {
            get { return nam; }
            set { isChanged |= nam != value; nam = value; }
        }
        /// <summary>
        /// Property relating to database column TenTruong
        /// </summary>
        public string TenTruong
        {
            get { return tenTruong.TrimEnd(); }
            set { isChanged |= tenTruong != value; tenTruong = value; }
        }

        /// <summary>
        /// Property relating to database column DiaChi
        /// </summary>
        public string DiaChi
        {
            get { return diaChi != null ? diaChi.TrimEnd() : string.Empty; }
            set { isChanged |= diaChi != value; diaChi = value; }
        }
        #endregion

    }
}
