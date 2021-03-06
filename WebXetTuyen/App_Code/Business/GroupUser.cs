﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{

    public class GroupUserCollection : List<GroupUser>
    {
    }

    public  class GroupUser
    {
       #region Members
		private bool isChanged;
		private Guid groupID;
		private string loginID;
		#endregion
			
		#region Constructors
		/// <summary>
		/// Create a new instance using the default constructor
		/// </summary>
		public GroupUser()
		{
			isChanged = true;
		}
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public GroupUser(Guid GroupID, string LoginID)
		{
            this.groupID = GroupID;
            this.loginID = LoginID;
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
		/// Property relating to database column LoginID
		/// </summary>
		public string LoginID
		{
            get { return loginID.TrimEnd(); }
            set { isChanged |= loginID != value; loginID = value; }
		}
		#endregion


    }
}
