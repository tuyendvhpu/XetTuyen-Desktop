using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class KhoiMon
    {

      #region Members
		private bool isChanged;
		
		private string maKHoi;
		
		private int nam;
		
		private int maMon;
		#endregion
			
		#region Constructors			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public KhoiMon(string maKHoi, int nam, int  maMon)
		{
			this.maKHoi = maKHoi;
			this.nam = nam;
			this.maMon = maMon;
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
		public int MaMon
		{
			get { return maMon; }
			set { isChanged |= maMon != value; maMon = value; }
		}
		#endregion

		
    }
}
