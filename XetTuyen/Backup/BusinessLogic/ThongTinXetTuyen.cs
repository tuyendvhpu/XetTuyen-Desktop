using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class ThongTinXetTuyen
    {
       	#region Members
		private bool isChanged;
		private string soQD;
		private string status;
		private string maHS;
		private string loginID;
		private DateTime createdDate;
		#endregion
			
		#region Constructors
		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public ThongTinXetTuyen(string soQD, string status, string maHS, string loginID)
		{
			isChanged = true;
			this.soQD = soQD;
			this.status = status;
			this.maHS = maHS;
			this.loginID = loginID;
		}
        public ThongTinXetTuyen()
        {
            isChanged = true;
            this.soQD = "";
            this.status = "";
            this.maHS = "";
            this.loginID = "";
        }
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
        public ThongTinXetTuyen(string soQD, string status, string maHS, string loginID, DateTime createdDate)
		{
			this.soQD = soQD;
			this.status = status;
			this.maHS = maHS;
			this.loginID = loginID;
			this.createdDate = createdDate;
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
		/// Property relating to database column SoQD
		/// </summary>
		public string SoQD
		{
			get { return soQD.TrimEnd(); }
			set { isChanged |= soQD != value; soQD = value; }
		}

		/// <summary>
		/// Property relating to database column Satatus
		/// </summary>
		public string Status
		{
			get { return status.TrimEnd(); }
			set { isChanged |= status != value; status = value; }
		}

		/// <summary>
		/// Property relating to database column MaHS
		/// </summary>
		public string MaHS
		{
			get { return maHS.TrimEnd(); }
			set { isChanged |= maHS != value; maHS = value; }
		}

		/// <summary>
		/// Property relating to database column LoginID
		/// </summary>
		public string LoginID
		{
			get { return loginID.TrimEnd(); }
			set { isChanged |= loginID != value; loginID = value; }
		}

		/// <summary>
		/// Property relating to database column CreatedDate
		/// </summary>
		public DateTime CreatedDate
		{
			get { return createdDate; }
			set { isChanged |= createdDate != value; createdDate = value; }
		}
		#endregion
    }
}
