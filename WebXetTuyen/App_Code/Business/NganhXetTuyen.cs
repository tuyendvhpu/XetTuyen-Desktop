using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class NganhXetTuyen
    {

        #region Members
        private bool isChanged;
        private long idhs;
        private string iDNganh;
        private string maNganh;
        private string maKhoi;
        private string maDot;
        private int nam;
        private double diemTB = ((0));
        private double diemUTKV;
        private double diemUTDT;
        private double diemTXT;
        private int trangThai = ((0));
        private long id;
        private string sIdNganh;
        private string sMaNganh;
        private string sMaKhoi;
        private string sMaDot;
        private int iNam;
        private double dDiemTB;
        private double dDiemUTKV;
        private double dDiemUTDT;
        private double dDiemTXT;
        private double iTrangThai;
        private DateTime ngayDK;
        #endregion

        #region Constructors

        public NganhXetTuyen()
        {
            isChanged = true;

        }

        public NganhXetTuyen(long idhs, string iDNganh, string maNganh, string maKhoi, string maDot, int nam, double diemUTKV, double diemUTDT,DateTime ngayDK)
        {
            isChanged = true;
            this.idhs = idhs;
            this.iDNganh = iDNganh;
            this.maNganh = maNganh;
            this.maKhoi = maKhoi;
            this.maDot = maDot;
            this.nam = nam;
            this.diemUTKV = diemUTKV;
            this.diemUTDT = diemUTDT;
            this.ngayDK = ngayDK;
        }

        /// <summary> 
        /// Create a new object using the minimum required information (all not-null fields except 
        /// auto-generated primary keys). 
        /// </summary> 
        public NganhXetTuyen(long idhs, string iDNganh, string maNganh, string maKhoi, string maDot, int nam, double diemTB, int trangThai,DateTime ngayDK)
        {
            isChanged = true;
            this.idhs = idhs;
            this.iDNganh = iDNganh;
            this.maNganh = maNganh;
            this.maKhoi = maKhoi;
            this.maDot = maDot;
            this.nam = nam;
            this.diemTB = diemTB;
            this.trangThai = trangThai;
            this.ngayDK = ngayDK;
        }

        /// <summary> 
        /// Create an object from an existing row of data. This will be used by Gentle to 
        /// construct objects from retrieved rows. 
        /// </summary> 
        public NganhXetTuyen(long idhs, string iDNganh, string maNganh, string maKhoi, string maDot, int nam, double diemTB, double diemUTKV, double diemUTDT, double diemTXT, int trangThai,DateTime ngayDK)
        {
            this.idhs = idhs;
            this.iDNganh = iDNganh;
            this.maNganh = maNganh;
            this.maKhoi = maKhoi;
            this.maDot = maDot;
            this.nam = nam;
            this.diemTB = diemTB;
            this.diemUTKV = diemUTKV;
            this.diemUTDT = diemUTDT;
            this.diemTXT = diemTXT;
            this.trangThai = trangThai;
            this.ngayDK = ngayDK;
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
        /// Property relating to database column DiemTB
        /// </summary>
        public double DiemTB
        {
            get { return diemTB; }
            set { isChanged |= diemTB != value; diemTB = value; }
        }

        /// <summary>
        /// Property relating to database column DiemUTKV
        /// </summary>
        public double DiemUTKV
        {
            get { return diemUTKV; }
            set { isChanged |= diemUTKV != value; diemUTKV = value; }
        }

        /// <summary>
        /// Property relating to database column DiemUTDT
        /// </summary>
        public double DiemUTDT
        {
            get { return diemUTDT; }
            set { isChanged |= diemUTDT != value; diemUTDT = value; }
        }

        /// <summary>
        /// Property relating to database column DiemTXT
        /// </summary>
        public double DiemTXT
        {
            get { return diemTXT; }
            set { isChanged |= diemTXT != value; diemTXT = value; }
        }

        /// <summary>
        /// Property relating to database column TrangThai
        /// </summary>
        public int TrangThai
        {
            get { return trangThai; }
            set { isChanged |= trangThai != value; trangThai = value; }
        }

        /// <summary>
        /// Property relating to database column NgayDK
        /// </summary>
        public DateTime NgayDK
        {
            get { return ngayDK; }
            set { isChanged |= ngayDK != value; ngayDK = value; }
        }
        #endregion


        public static bool operator== (NganhXetTuyen b, NganhXetTuyen c)
        {

            if (b.idhs == c.idhs && b.iDNganh == c.iDNganh && b.iNam == c.iNam && b.maDot == c.maDot && b.maKhoi == c.maKhoi)
                return true;
            return false;
        }
        public static bool operator !=(NganhXetTuyen b, NganhXetTuyen c)
        {

            if (b.idhs != c.idhs || b.iDNganh != c.iDNganh || b.iNam != c.iNam || b.maDot != c.maDot || b.maKhoi != c.maKhoi)
                return true;
            return false;
        }
    }
}
