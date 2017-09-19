using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class TruongDH
    {
#region Members
		private bool isChanged;
		
		private string maTruong;
		
		private string maTinh;
		
		private string tenTruong;
		
		private string loaiTruong;
		
		private string diaChi;
		
		private string boNganh;
		
		private bool thiDH;
		
		private int nam;
		
		private string dienThoai;
		#endregion
			
		#region Constructors
		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public TruongDH(string maTruong, string tenTruong)
		{
			isChanged = true;
			this.maTruong = maTruong;
			this.tenTruong = tenTruong;
		}
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public TruongDH(string maTruong, string maTinh, string tenTruong, string loaiTruong, string diaChi, string boNganh, bool thiDH, int nam, string dienThoai)
		{
			this.maTruong = maTruong;
			this.maTinh = maTinh;
			this.tenTruong = tenTruong;
			this.loaiTruong = loaiTruong;
			this.diaChi = diaChi;
			this.boNganh = boNganh;
			this.thiDH = thiDH;
			this.nam = nam;
			this.dienThoai = dienThoai;
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
		/// Property relating to database column MaTinh
		/// </summary>
		public string MaTinh
		{
			get { return maTinh != null ? maTinh.TrimEnd() : string.Empty; }
			set { isChanged |= maTinh != value; maTinh = value; }
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
		/// Property relating to database column LoaiTruong
		/// </summary>
		public string LoaiTruong
		{
			get { return loaiTruong != null ? loaiTruong.TrimEnd() : string.Empty; }
			set { isChanged |= loaiTruong != value; loaiTruong = value; }
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
		/// Property relating to database column BoNganh
		/// </summary>
		public string BoNganh
		{
			get { return boNganh != null ? boNganh.TrimEnd() : string.Empty; }
			set { isChanged |= boNganh != value; boNganh = value; }
		}

		/// <summary>
		/// Property relating to database column ThiDH
		/// </summary>
		public bool ThiDH
		{
			get { return thiDH; }
			set { isChanged |= thiDH != value; thiDH = value; }
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
		/// Property relating to database column DienThoai
		/// </summary>
		public string DienThoai
		{
			get { return dienThoai != null ? dienThoai.TrimEnd() : string.Empty; }
			set { isChanged |= dienThoai != value; dienThoai = value; }
		}
		#endregion
    }
}
