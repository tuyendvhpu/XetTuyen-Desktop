using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class KhoiMon
    {
#region Members
		private bool isChanged;
		private string maKHoi;
		private int nam;
		private string maMon;
		private int viTri;
		#endregion
			
		#region Constructors
		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public KhoiMon(string maKHoi, int nam, string maMon)
		{
			isChanged = true;
			this.maKHoi = maKHoi;
			this.nam = nam;
			this.maMon = maMon;
		}
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public KhoiMon(string maKHoi, int nam, string maMon, int viTri)
		{
			this.maKHoi = maKHoi;
			this.nam = nam;
			this.maMon = maMon;
			this.viTri = viTri;
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
		/// Property relating to database column MaKHoi
		/// </summary>
		public string MaKHoi
		{
			get { return maKHoi.TrimEnd(); }
			set { isChanged |= maKHoi != value; maKHoi = value; }
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
		/// Property relating to database column MaMon
		/// </summary>
		public string MaMon
		{
			get { return maMon.TrimEnd(); }
			set { isChanged |= maMon != value; maMon = value; }
		}

		/// <summary>
		/// Property relating to database column ViTri
		/// </summary>
		public int ViTri
		{
			get { return viTri; }
			set { isChanged |= viTri != value; viTri = value; }
		}
		#endregion


		
    }
}
