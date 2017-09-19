using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace BusinessLogic
{
    public class NhanVienCollection : List<NhanVien>
    {
    }
    public class NhanVien
    {
        
		#region Members
		private bool isChanged;
		
		private long id;
		
		private string taiKhoan;
		
		private string matKhau;
		
		private string hoTen;
		
		private string nhom;
	
		private DateTime ngaySinh;
		
		private DateTime ngayTao;
		
		private string gioiTinh;
		#endregion
			
		#region Constructors
		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public NhanVien(string taiKhoan)
		{
			isChanged = true;
			id = 0;
			this.taiKhoan = taiKhoan;
		}

		/// <summary> 
		/// Create a new object by specifying all fields (except the auto-generated primary key field). 
		/// </summary> 
		public NhanVien(string taiKhoan, string matKhau, string hoTen, string nhom, DateTime ngaySinh, DateTime ngayTao, string gioiTinh)
		{
			isChanged = true;
			this.taiKhoan = taiKhoan;
			this.matKhau = matKhau;
			this.hoTen = hoTen;
			this.nhom = nhom;
			this.ngaySinh = ngaySinh;
			this.ngayTao = ngayTao;
			this.gioiTinh = gioiTinh;
		}
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public NhanVien(long id, string taiKhoan, string matKhau, string hoTen, string nhom, DateTime ngaySinh, DateTime ngayTao, string gioiTinh)
		{
			this.id = id;
			this.taiKhoan = taiKhoan;
			this.matKhau = matKhau;
			this.hoTen = hoTen;
			this.nhom = nhom;
			this.ngaySinh = ngaySinh;
			this.ngayTao = ngayTao;
			this.gioiTinh = gioiTinh;
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
		/// Property relating to database column ID
		/// </summary>
		public long Id
		{
			get { return id; }
            set { isChanged |= id != value; id = value; }
		}

		/// <summary>
		/// Property relating to database column TaiKhoan
		/// </summary>
		public string TaiKhoan
		{
			get { return taiKhoan.TrimEnd(); }
			set { isChanged |= taiKhoan != value; taiKhoan = value; }
		}

		/// <summary>
		/// Property relating to database column MatKhau
		/// </summary>
		public string MatKhau
		{
			get { return matKhau != null ? matKhau.TrimEnd() : string.Empty; }
			set { isChanged |= matKhau != value; matKhau = value; }
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
		/// Property relating to database column Nhom
		/// </summary>
		public string Nhom
		{
			get { return nhom != null ? nhom.TrimEnd() : string.Empty; }
			set { isChanged |= nhom != value; nhom = value; }
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
		/// Property relating to database column NgayTao
		/// </summary>
		public DateTime NgayTao
		{
			get { return ngayTao; }
			set { isChanged |= ngayTao != value; ngayTao = value; }
		}

		/// <summary>
		/// Property relating to database column GioiTinh
		/// </summary>
		public string GioiTinh
		{
			get { return gioiTinh != null ? gioiTinh.TrimEnd() : string.Empty; }
			set { isChanged |= gioiTinh != value; gioiTinh = value; }
		}
		#endregion

    }
}
