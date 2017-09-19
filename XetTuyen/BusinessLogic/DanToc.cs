using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class DanToc
    {
	    #region Members
		private bool isChanged;
		
		private string maDanToc;
		
		private string tenDanToc;
		
		private string moTa;
		#endregion
			
		#region Constructors
		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public DanToc(string maDanToc)
		{
			isChanged = true;
			this.maDanToc = maDanToc;
		}
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public DanToc(string maDanToc, string tenDanToc, string moTa)
		{
			this.maDanToc = maDanToc;
			this.tenDanToc = tenDanToc;
			this.moTa = moTa;
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
		/// Property relating to database column MaDanToc
		/// </summary>
		public string MaDanToc
		{
			get { return maDanToc.TrimEnd(); }
			set { isChanged |= maDanToc != value; maDanToc = value; }
		}

		/// <summary>
		/// Property relating to database column TenDanToc
		/// </summary>
		public string TenDanToc
		{
			get { return tenDanToc != null ? tenDanToc.TrimEnd() : string.Empty; }
			set { isChanged |= tenDanToc != value; tenDanToc = value; }
		}

		/// <summary>
		/// Property relating to database column MoTa
		/// </summary>
		public string MoTa
		{
			get { return moTa != null ? moTa.TrimEnd() : string.Empty; }
			set { isChanged |= moTa != value; moTa = value; }
		}
		#endregion

    }
}
