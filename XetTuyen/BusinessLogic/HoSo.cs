using System;
using System.Collections.Generic;
using System.Text;
using Common;
namespace BusinessLogic
{
    public class HoSoCollection : List<HoSo>
    {
    }
    public class HoSo
    {
        #region Members
        private bool isChanged;

        private long idhs;

        private string soCMTND;

        private string hoTen;

        private DateTime ngaySinh;

        private string gioiTinh;

        private string hoKhau;

        private string diaChi;

        private string dienThoai;

        private string email;

        private string maTinh;

        private string maHuyen;

        private string maDT;

        private string lop10;

        private string lop10MaTinh;

        private string lop10MaTruong;

        private string lop11;

        private string lop11MaTinh;

        private string lop11MaTruong;

        private string lop12;

        private string lop12MaTinh;

        private string lop12MaTruong;

        private string maKV;

        private string truongDT;

        private string khoiDT;

        private string danToc;

        private string hanhKiem;

        private bool hocBa;

        private string loaiHocBa;

        private int namTotNghiep;

        private bool giayTotNghiep;

        private DateTime ngayNhap;

        private string nguoiNhap;

        private DateTime ngaySua;

        private string nguoiSua;

        private string soBaoDanh;

        private bool dangXetTuyen;

        private int nam;

        private bool nopLePhi;

        private bool lienThong;

        private string totNghiep;

        private bool online;

        private byte heXetTuyen = ((1));

        private byte hinhThuc = ((1));
        private int buoc = ((-1));

        private byte ketQua = ((0));

        private string maHS;
       
        #endregion

        #region Constructors

        public HoSo()
        {
            isChanged = true;
            this.Idhs = 0;
            this.soCMTND = string.Empty;
            this.hoTen = string.Empty;
            this.ngaySinh = DateTime.Now.AddYears(-19);
            this.gioiTinh = string.Empty;
            this.hoKhau = string.Empty;
            this.diaChi = string.Empty; ;
            this.dienThoai = string.Empty;
            this.email = string.Empty;
            this.maTinh = string.Empty;
            this.maHuyen = string.Empty;
            this.maDT = string.Empty;
            this.lop10 = string.Empty;
            this.lop10MaTinh = string.Empty;
            this.lop10MaTruong = string.Empty;
            this.lop11 = string.Empty;
            this.lop11MaTinh = string.Empty;
            this.lop11MaTruong = string.Empty;
            this.lop12 = string.Empty;
            this.lop12MaTinh = string.Empty;
            this.lop12MaTruong = string.Empty;
            this.maKV = string.Empty;
            this.truongDT = string.Empty;
            this.khoiDT = string.Empty;
            this.danToc = string.Empty;
            this.hanhKiem = string.Empty;
            this.hocBa = false;
            this.loaiHocBa = string.Empty;
            this.giayTotNghiep = false;

            this.nguoiSua = string.Empty;
            this.hanhKiem = string.Empty;
            this.soBaoDanh = string.Empty;
            this.dangXetTuyen = false;
            this.nguoiNhap = string.Empty;
            this.nopLePhi = false;
            this.lienThong = false;
            this.totNghiep = string.Empty;
            this.heXetTuyen = 1;
            this.online = false;
            this.ngaySua = DateTime.Now;
            this.ngayNhap = DateTime.Now;
            this.hinhThuc = 1;
            this.buoc = 0;
            this.ketQua = 0;
            this.maHS = string.Empty;
        }
       
		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public HoSo(string soCMTND, string nguoiNhap, string soBaoDanh, int nam, bool nopLePhi)
		{
			isChanged = true;
			idhs = 0;
			this.soCMTND = soCMTND;
			this.nguoiNhap = nguoiNhap;
			this.soBaoDanh = soBaoDanh;
			this.nam = nam;
			this.nopLePhi = nopLePhi;
		}

		/// <summary> 
		/// Create a new object by specifying all fields (except the auto-generated primary key field). 
		/// </summary> 
        public HoSo(string soCMTND, string hoTen, DateTime ngaySinh, string gioiTinh, string hoKhau, string diaChi, string dienThoai, string email, string maTinh, string maHuyen, string maDT, string lop10, string lop10MaTinh, string lop10MaTruong, string lop11, string lop11MaTinh, string lop11MaTruong, string lop12, string lop12MaTinh, string lop12MaTruong, string maKV, string truongDT, string khoiDT, string danToc, string hanhKiem, bool hocBa, string loaiHocBa, int namTotNghiep, bool giayTotNghiep, DateTime ngayNhap, string nguoiNhap, DateTime ngaySua, string nguoiSua, string soBaoDanh, bool dangXetTuyen, int nam, bool nopLePhi, bool lienThong, string totNghiep, bool online, byte heXetTuyen, byte hinhThuc,int buoc,byte ketQua)
		{
			isChanged = true;
			this.soCMTND = soCMTND;
			this.hoTen = hoTen;
			this.ngaySinh = ngaySinh;
			this.gioiTinh = gioiTinh;
			this.hoKhau = hoKhau;
			this.diaChi = diaChi;
			this.dienThoai = dienThoai;
			this.email = email;
			this.maTinh = maTinh;
			this.maHuyen = maHuyen;
			this.maDT = maDT;
			this.lop10 = lop10;
			this.lop10MaTinh = lop10MaTinh;
			this.lop10MaTruong = lop10MaTruong;
			this.lop11 = lop11;
			this.lop11MaTinh = lop11MaTinh;
			this.lop11MaTruong = lop11MaTruong;
			this.lop12 = lop12;
			this.lop12MaTinh = lop12MaTinh;
			this.lop12MaTruong = lop12MaTruong;
			this.maKV = maKV;
			this.truongDT = truongDT;
			this.khoiDT = khoiDT;
			this.danToc = danToc;
			this.hanhKiem = hanhKiem;
			this.hocBa = hocBa;
			this.loaiHocBa = loaiHocBa;
			this.namTotNghiep = namTotNghiep;
			this.giayTotNghiep = giayTotNghiep;
			this.ngayNhap = ngayNhap;
			this.nguoiNhap = nguoiNhap;
			this.ngaySua = ngaySua;
			this.nguoiSua = nguoiSua;
			this.soBaoDanh = soBaoDanh;
			this.dangXetTuyen = dangXetTuyen;
			this.nam = nam;
			this.nopLePhi = nopLePhi;
			this.lienThong = lienThong;
			this.totNghiep = totNghiep;
			this.online = online;
			this.heXetTuyen = heXetTuyen;
            this.hinhThuc = hinhThuc;
            this.buoc = buoc;
            this.ketQua = ketQua;
		}

			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
        public HoSo(long idhs, string soCMTND, string hoTen, DateTime ngaySinh, string gioiTinh, string hoKhau, string diaChi, string dienThoai, string email, string maTinh, string maHuyen, string maDT, string lop10, string lop10MaTinh, string lop10MaTruong, string lop11, string lop11MaTinh, string lop11MaTruong, string lop12, string lop12MaTinh, string lop12MaTruong, string maKV, string truongDT, string khoiDT, string danToc, string hanhKiem, bool hocBa, string loaiHocBa, int namTotNghiep, bool giayTotNghiep, DateTime ngayNhap, string nguoiNhap, DateTime ngaySua, string nguoiSua, string soBaoDanh, bool dangXetTuyen, int nam, bool nopLePhi, bool lienThong, string totNghiep, bool online, byte heXetTuyen, byte hinhThuc, int buoc, byte ketQua)
		{
			this.idhs = idhs;
			this.soCMTND = soCMTND;
			this.hoTen = hoTen;
			this.ngaySinh = ngaySinh;
			this.gioiTinh = gioiTinh;
			this.hoKhau = hoKhau;
			this.diaChi = diaChi;
			this.dienThoai = dienThoai;
			this.email = email;
			this.maTinh = maTinh;
			this.maHuyen = maHuyen;
			this.maDT = maDT;
			this.lop10 = lop10;
			this.lop10MaTinh = lop10MaTinh;
			this.lop10MaTruong = lop10MaTruong;
			this.lop11 = lop11;
			this.lop11MaTinh = lop11MaTinh;
			this.lop11MaTruong = lop11MaTruong;
			this.lop12 = lop12;
			this.lop12MaTinh = lop12MaTinh;
			this.lop12MaTruong = lop12MaTruong;
			this.maKV = maKV;
			this.truongDT = truongDT;
			this.khoiDT = khoiDT;
			this.danToc = danToc;
			this.hanhKiem = hanhKiem;
			this.hocBa = hocBa;
			this.loaiHocBa = loaiHocBa;
			this.namTotNghiep = namTotNghiep;
			this.giayTotNghiep = giayTotNghiep;
			this.ngayNhap = ngayNhap;
			this.nguoiNhap = nguoiNhap;
			this.ngaySua = ngaySua;
			this.nguoiSua = nguoiSua;
			this.soBaoDanh = soBaoDanh;
			this.dangXetTuyen = dangXetTuyen;
			this.nam = nam;
			this.nopLePhi = nopLePhi;
			this.lienThong = lienThong;
			this.totNghiep = totNghiep;
			this.online = online;
			this.heXetTuyen = heXetTuyen;
            this.hinhThuc=hinhThuc;
            this.buoc = buoc;
            this.ketQua = ketQua;
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
		/// Property relating to database column SoCMTND
		/// </summary>
		public string SoCMTND
		{
			get { return soCMTND.TrimEnd(); }
			set { isChanged |= soCMTND != value; soCMTND = value; }
		}

		/// <summary>
		/// Property relating to database column HoTen
		/// </summary>
		public string HoTen
		{
			get { return hoTen != null ? hoTen.TrimEnd() : string.Empty; }
			set { isChanged |= hoTen != value; hoTen = value; }
		}

		/// <summary>
		/// Property relating to database column NgaySinh
		/// </summary>
		public DateTime NgaySinh
		{
			get { return ngaySinh; }
			set { isChanged |= ngaySinh != value; ngaySinh = value; }
		}

		/// <summary>
		/// Property relating to database column GioiTinh
		/// </summary>
		public string GioiTinh
		{
			get { return gioiTinh != null ? gioiTinh.TrimEnd() : string.Empty; }
			set { isChanged |= gioiTinh != value; gioiTinh = value; }
		}

		/// <summary>
		/// Property relating to database column HoKhau
		/// </summary>
		public string HoKhau
		{
			get { return hoKhau != null ? hoKhau.TrimEnd() : string.Empty; }
			set { isChanged |= hoKhau != value; hoKhau = value; }
		}

		/// <summary>
		/// Property relating to database column DiaChi
		/// </summary>
		public string DiaChi
		{
			get { return diaChi != null ? diaChi.TrimEnd() : string.Empty; }
			set { isChanged |= diaChi != value; diaChi = value; }
		}

		/// <summary>
		/// Property relating to database column DienThoai
		/// </summary>
		public string DienThoai
		{
			get { return dienThoai != null ? dienThoai.TrimEnd() : string.Empty; }
			set { isChanged |= dienThoai != value; dienThoai = value; }
		}

		/// <summary>
		/// Property relating to database column Email
		/// </summary>
		public string Email
		{
			get { return email != null ? email.TrimEnd() : string.Empty; }
			set { isChanged |= email != value; email = value; }
		}

		/// <summary>
		/// Property relating to database column MaTinh
		/// </summary>
		public string MaTinh
		{
			get { return maTinh != null ? maTinh.TrimEnd() : string.Empty; }
			set { isChanged |= maTinh != value; maTinh = value; }
		}

		/// <summary>
		/// Property relating to database column MaHuyen
		/// </summary>
		public string MaHuyen
		{
			get { return maHuyen != null ? maHuyen.TrimEnd() : string.Empty; }
			set { isChanged |= maHuyen != value; maHuyen = value; }
		}

		/// <summary>
		/// Property relating to database column MaDT
		/// </summary>
		public string MaDT
		{
			get { return maDT != null ? maDT.TrimEnd() : string.Empty; }
			set { isChanged |= maDT != value; maDT = value; }
		}

		/// <summary>
		/// Property relating to database column Lop10
		/// </summary>
		public string Lop10
		{
			get { return lop10 != null ? lop10.TrimEnd() : string.Empty; }
			set { isChanged |= lop10 != value; lop10 = value; }
		}

		/// <summary>
		/// Property relating to database column Lop10MaTinh
		/// </summary>
		public string Lop10MaTinh
		{
			get { return lop10MaTinh != null ? lop10MaTinh.TrimEnd() : string.Empty; }
			set { isChanged |= lop10MaTinh != value; lop10MaTinh = value; }
		}

		/// <summary>
		/// Property relating to database column Lop10MaTruong
		/// </summary>
		public string Lop10MaTruong
		{
			get { return lop10MaTruong != null ? lop10MaTruong.TrimEnd() : string.Empty; }
			set { isChanged |= lop10MaTruong != value; lop10MaTruong = value; }
		}

		/// <summary>
		/// Property relating to database column Lop11
		/// </summary>
		public string Lop11
		{
			get { return lop11 != null ? lop11.TrimEnd() : string.Empty; }
			set { isChanged |= lop11 != value; lop11 = value; }
		}

		/// <summary>
		/// Property relating to database column Lop11MaTinh
		/// </summary>
		public string Lop11MaTinh
		{
			get { return lop11MaTinh != null ? lop11MaTinh.TrimEnd() : string.Empty; }
			set { isChanged |= lop11MaTinh != value; lop11MaTinh = value; }
		}

		/// <summary>
		/// Property relating to database column Lop11MaTruong
		/// </summary>
		public string Lop11MaTruong
		{
			get { return lop11MaTruong != null ? lop11MaTruong.TrimEnd() : string.Empty; }
			set { isChanged |= lop11MaTruong != value; lop11MaTruong = value; }
		}

		/// <summary>
		/// Property relating to database column Lop12
		/// </summary>
		public string Lop12
		{
			get { return lop12 != null ? lop12.TrimEnd() : string.Empty; }
			set { isChanged |= lop12 != value; lop12 = value; }
		}

		/// <summary>
		/// Property relating to database column Lop12MaTinh
		/// </summary>
		public string Lop12MaTinh
		{
			get { return lop12MaTinh != null ? lop12MaTinh.TrimEnd() : string.Empty; }
			set { isChanged |= lop12MaTinh != value; lop12MaTinh = value; }
		}

		/// <summary>
		/// Property relating to database column Lop12MaTruong
		/// </summary>
		public string Lop12MaTruong
		{
			get { return lop12MaTruong != null ? lop12MaTruong.TrimEnd() : string.Empty; }
			set { isChanged |= lop12MaTruong != value; lop12MaTruong = value; }
		}

		/// <summary>
		/// Property relating to database column MaKV
		/// </summary>
		public string MaKV
		{
			get { return maKV != null ? maKV.TrimEnd() : string.Empty; }
			set { isChanged |= maKV != value; maKV = value; }
		}

		/// <summary>
		/// Property relating to database column TruongDT
		/// </summary>
		public string TruongDT
		{
			get { return truongDT != null ? truongDT.TrimEnd() : string.Empty; }
			set { isChanged |= truongDT != value; truongDT = value; }
		}

		/// <summary>
		/// Property relating to database column KhoiDT
		/// </summary>
		public string KhoiDT
		{
			get { return khoiDT != null ? khoiDT.TrimEnd() : string.Empty; }
			set { isChanged |= khoiDT != value; khoiDT = value; }
		}

		/// <summary>
		/// Property relating to database column DanToc
		/// </summary>
		public string DanToc
		{
			get { return danToc != null ? danToc.TrimEnd() : string.Empty; }
			set { isChanged |= danToc != value; danToc = value; }
		}

		/// <summary>
		/// Property relating to database column HanhKiem
		/// </summary>
		public string HanhKiem
		{
			get { return hanhKiem != null ? hanhKiem.TrimEnd() : string.Empty; }
			set { isChanged |= hanhKiem != value; hanhKiem = value; }
		}

		/// <summary>
		/// Property relating to database column HocBa
		/// </summary>
		public bool HocBa
		{
			get { return hocBa; }
			set { isChanged |= hocBa != value; hocBa = value; }
		}

		/// <summary>
		/// Property relating to database column LoaiHocBa
		/// </summary>
		public string LoaiHocBa
		{
			get { return loaiHocBa != null ? loaiHocBa.TrimEnd() : string.Empty; }
			set { isChanged |= loaiHocBa != value; loaiHocBa = value; }
		}

		/// <summary>
		/// Property relating to database column NamTotNghiep
		/// </summary>
		public int NamTotNghiep
		{
			get { return namTotNghiep; }
			set { isChanged |= namTotNghiep != value; namTotNghiep = value; }
		}

		/// <summary>
		/// Property relating to database column GiayTotNghiep
		/// </summary>
		public bool GiayTotNghiep
		{
			get { return giayTotNghiep; }
			set { isChanged |= giayTotNghiep != value; giayTotNghiep = value; }
		}

		/// <summary>
		/// Property relating to database column NgayNhap
		/// </summary>
		public DateTime NgayNhap
		{
			get { return ngayNhap; }
			set { isChanged |= ngayNhap != value; ngayNhap = value; }
		}

		/// <summary>
		/// Property relating to database column NguoiNhap
		/// </summary>
		public string NguoiNhap
		{
			get { return nguoiNhap.TrimEnd(); }
			set { isChanged |= nguoiNhap != value; nguoiNhap = value; }
		}

		/// <summary>
		/// Property relating to database column NgaySua
		/// </summary>
		public DateTime NgaySua
		{
			get { return ngaySua; }
			set { isChanged |= ngaySua != value; ngaySua = value; }
		}

		/// <summary>
		/// Property relating to database column NguoiSua
		/// </summary>
		public string NguoiSua
		{
			get { return nguoiSua != null ? nguoiSua.TrimEnd() : string.Empty; }
			set { isChanged |= nguoiSua != value; nguoiSua = value; }
		}

		/// <summary>
		/// Property relating to database column SoBaoDanh
		/// </summary>
		public string SoBaoDanh
		{
			get { return soBaoDanh.TrimEnd(); }
			set { isChanged |= soBaoDanh != value; soBaoDanh = value; }
		}

		/// <summary>
		/// Property relating to database column DangXetTuyen
		/// </summary>
		public bool DangXetTuyen
		{
			get { return dangXetTuyen; }
			set { isChanged |= dangXetTuyen != value; dangXetTuyen = value; }
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
		/// Property relating to database column NopLePhi
		/// </summary>
		public bool NopLePhi
		{
			get { return nopLePhi; }
			set { isChanged |= nopLePhi != value; nopLePhi = value; }
		}

		/// <summary>
		/// Property relating to database column LienThong
		/// </summary>
		public bool LienThong
		{
			get { return lienThong; }
			set { isChanged |= lienThong != value; lienThong = value; }
		}

		/// <summary>
		/// Property relating to database column TotNghiep
		/// </summary>
		public string TotNghiep
		{
			get { return totNghiep != null ? totNghiep.TrimEnd() : string.Empty; }
			set { isChanged |= totNghiep != value; totNghiep = value; }
		}

		/// <summary>
		/// Property relating to database column Online
		/// </summary>
		public bool Online
		{
			get { return online; }
			set { isChanged |= online != value; online = value; }
		}

		/// <summary>
		/// Property relating to database column HeXetTuyen
		/// </summary>
		public byte HeXetTuyen
		{
			get { return heXetTuyen; }
			set { isChanged |= heXetTuyen != value; heXetTuyen = value; }
		}

        /// <summary>
        /// Property relating to database column HinhThuc
        /// </summary>
        public byte HinhThuc
        {
            get { return hinhThuc; }
            set { isChanged |= hinhThuc != value; hinhThuc = value; }
        }
        /// <summary>
        /// Property relating to database column Buoc
        /// </summary>
        public int Buoc
        {
            get { return buoc; }
            set { isChanged |= buoc != value; buoc = value; }
        }
        /// <summary>
        /// Property relating to database column KetQua
        /// </summary>
        public byte KetQua
        {
            get { return ketQua; }
            set { isChanged |= ketQua != value; ketQua = value; }
        }
        /// <summary>
        /// Property relating to database column MaHS
        /// </summary>
        public string MaHS
        {
            get { return maHS; }
            set { isChanged |= maHS != value; maHS = value; }
        }
		#endregion


    }
}
