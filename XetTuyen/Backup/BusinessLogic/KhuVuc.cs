using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace BusinessLogic
{
    public class KhuVucCollection : List<KhuVuc>
    {
    }
    public class KhuVuc
    {

        #region Members
		private bool isChanged;
		
		private string maKV;
		
		private string tenKV;
		
		private double dienUT;
		
		private int nam;
		#endregion
			
		#region Constructors
		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public KhuVuc(string maKV)
		{
			isChanged = true;
			this.maKV = maKV;
		}
        public KhuVuc()
        {
            isChanged = true;
            
        }
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public KhuVuc(string maKV, string tenKV, double dienUT, int nam)
		{
			this.maKV = maKV;
			this.tenKV = tenKV;
			this.dienUT = dienUT;
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
		/// Property relating to database column MaKV
		/// </summary>
		public string MaKV
		{
			get { return maKV.TrimEnd(); }
			set { isChanged |= maKV != value; maKV = value; }
		}

		/// <summary>
		/// Property relating to database column TenKV
		/// </summary>
		public string TenKV
		{
			get { return tenKV != null ? tenKV.TrimEnd() : string.Empty; }
			set { isChanged |= tenKV != value; tenKV = value; }
		}

		/// <summary>
		/// Property relating to database column DienUT
		/// </summary>
		public double DienUT
		{
			get { return dienUT; }
			set { isChanged |= dienUT != value; dienUT = value; }
		}

		/// <summary>
		/// Property relating to database column Nam
		/// </summary>
		public int Nam
		{
			get { return nam; }
			set { isChanged |= nam != value; nam = value; }
		}
		#endregion

    }
}
