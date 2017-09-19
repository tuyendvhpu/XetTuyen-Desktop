using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{

    public class GroupAuthorizationCollection : List<GroupAuthorization>
    {
    }

    public  class GroupAuthorization
    {
       	#region Members
		private bool isChanged;
		private Guid groupID;
		private Guid authorizationID;
		#endregion
			
		#region Constructors
		/// <summary>
		/// Create a new instance using the default constructor
		/// </summary>
		public GroupAuthorization()
		{
			isChanged = true;
		}
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public GroupAuthorization(Guid GroupID, Guid AuthorizationID)
		{
			this.groupID = GroupID;
			this.authorizationID = AuthorizationID;
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
		/// Property relating to database column GroupID
		/// </summary>
		public Guid GroupID
		{
			get { return groupID; }
			set { isChanged |= groupID != value; groupID = value; }
		}

		/// <summary>
		/// Property relating to database column AuthorizationID
		/// </summary>
		public Guid AuthorizationID
		{
			get { return authorizationID; }
			set { isChanged |= authorizationID != value; authorizationID = value; }
		}
		#endregion

    }
}
