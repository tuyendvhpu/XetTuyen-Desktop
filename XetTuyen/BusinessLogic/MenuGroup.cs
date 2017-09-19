using System;
using System.Collections.Generic;

using System.Text;

namespace BusinessLogic
{

    public class MenuGroupCollection : List<MenuGroup>
    {
    }

    public  class MenuGroup
    {
       	#region Members
		private bool isChanged;
		private Guid groupID;
		private string menuID;
		#endregion
			
		#region Constructors
		/// <summary>
		/// Create a new instance using the default constructor
		/// </summary>
		public MenuGroup()
		{
			isChanged = true;
		}
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public MenuGroup(Guid GroupID, string MenuID)
		{
			this.groupID = GroupID;
			this.menuID = MenuID;
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
		/// Property relating to database column MenuID
		/// </summary>
		public string MenuID
		{
			get { return menuID.TrimEnd(); }
			set { isChanged |= menuID != value; menuID = value; }
		}
		#endregion


    }
}
