using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class AuthorizationCollection : List<Authorizations>
    {
    }
    public class Authorizations
    {
       #region Members
		private bool isChanged;
		private Guid authorizationID ;
		private string title;
		private string description;
		private string methodFullName;
		private int moduleID;
		#endregion
			
		#region Constructors
		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
        /// 
        public Authorizations()
        {
            authorizationID = new Guid();
            title = string.Empty;
            description = string.Empty;
            methodFullName = string.Empty;
            moduleID = -1;
        }
		public Authorizations(Guid authorizationID)
		{
			isChanged = true;
			this.authorizationID = authorizationID;
		}
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public Authorizations(Guid authorizationID, string title, string description, string methodFullName, int moduleID)
		{
			this.authorizationID = authorizationID;
			this.title = title;
			this.description = description;
			this.methodFullName = methodFullName;
			this.moduleID = moduleID;
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
		/// Property relating to database column AuthorizationID
		/// </summary>
		public Guid AuthorizationID
		{
			get { return authorizationID; }
			set { isChanged |= authorizationID != value; authorizationID = value; }
		}

		/// <summary>
		/// Property relating to database column Title
		/// </summary>
		public string Title
		{
			get { return title != null ? title.TrimEnd() : string.Empty; }
			set { isChanged |= title != value; title = value; }
		}

		/// <summary>
		/// Property relating to database column Description
		/// </summary>
		public string Description
		{
			get { return description != null ? description.TrimEnd() : string.Empty; }
			set { isChanged |= description != value; description = value; }
		}

		/// <summary>
		/// Property relating to database column MethodFullName
		/// </summary>
		public string MethodFullName
		{
			get { return methodFullName != null ? methodFullName.TrimEnd() : string.Empty; }
			set { isChanged |= methodFullName != value; methodFullName = value; }
		}

		/// <summary>
		/// Property relating to database column ModuleID
		/// </summary>
		public int ModuleID
		{
			get { return moduleID; }
			set { isChanged |= moduleID != value; moduleID = value; }
		}
		#endregion
        #region Method
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Authorizations castObj = (Authorizations)obj;
            return (castObj != null) &&
                (this.authorizationID == castObj.authorizationID);
        }
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * authorizationID.GetHashCode();
            return hash;
        }
        #endregion

    }
}
