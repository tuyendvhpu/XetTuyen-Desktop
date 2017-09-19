using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class DoiTuongUT
    {

        	#region Members
		private bool isChanged;
	
		private string maDT;
	
		private string maN;
	
		private string tenDT;
	
		private int nam;
	
		private double diemUT;
		#endregion
			
		#region Constructors			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public DoiTuongUT(string maDT, string maN, string tenDT, int nam, double diemUT)
		{
			this.maDT = maDT;
			this.maN = maN;
			this.tenDT = tenDT;
			this.nam = nam;
			this.diemUT = diemUT;
		}
        public DoiTuongUT()
        {
            
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
		/// Property relating to database column MaDT
		/// </summary>
		public string MaDT
		{
			get { return maDT.TrimEnd(); }
			set { isChanged |= maDT != value; maDT = value; }
		}

		/// <summary>
		/// Property relating to database column MaN
		/// </summary>
		public string MaN
		{
			get { return maN.TrimEnd(); }
			set { isChanged |= maN != value; maN = value; }
		}

		/// <summary>
		/// Property relating to database column TenDT
		/// </summary>
		public string TenDT
		{
			get { return tenDT.TrimEnd(); }
			set { isChanged |= tenDT != value; tenDT = value; }
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
		/// Property relating to database column DiemUT
		/// </summary>
		public double DiemUT
		{
			get { return diemUT; }
			set { isChanged |= diemUT != value; diemUT = value; }
		}
		#endregion

    }
}
