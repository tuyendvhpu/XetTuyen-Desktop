using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{

    public class GroupCollection : List<Groups>
    {
    }

    public  class Groups
    {
       	#region Members
		private bool isChanged;
		
		private Guid groupID ;
		private string groupName;
		private string note;
		private bool isAdmin;
		#endregion
			
		#region Constructors
		/// <summary>
		/// Create a new instance using the default constructor
		/// </summary>
		public Groups()
		{
			isChanged = true;
		}

		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public Groups(Guid GroupID, bool IsAdmin)
		{
			isChanged = true;
            this.groupID = GroupID;
            this.isAdmin = IsAdmin;
		}
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public Groups(Guid GroupID, string GroupName, string Note, bool IsAdmin)
		{
			this.groupID= GroupID;
			this.groupName = GroupName;
			this.note = Note;
			this.isAdmin = IsAdmin;
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
		/// Property relating to database column GroupName
		/// </summary>
		public string GroupName
		{
            get { return groupName != null ? groupName.TrimEnd() : string.Empty; }
            set { isChanged |= groupName != value; groupName = value; }
		}

		/// <summary>
		/// Property relating to database column Note
		/// </summary>
		public string Note
		{
            get { return note != null ? note.TrimEnd() : string.Empty; }
            set { isChanged |= note != value; note = value; }
		}

		/// <summary>
		/// Property relating to database column IsAdmin
		/// </summary>
		public bool IsAdmin
		{
			get { return isAdmin; }
            set { isChanged |= isAdmin != value; isAdmin = value; }
		}
		#endregion

    }
}
