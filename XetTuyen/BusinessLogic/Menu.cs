using System;
using System.Collections.Generic;

using System.Text;

namespace BusinessLogic
{

    public class MenuCollection : List<Menu>
    {
    }
    [Serializable]
    public  class Menu
    {
        #region Members
		private bool isChanged;
		private string menuID;
		private int menuPosition;
		private string menuValue;
		private string menuFiliationID;
		private string formName;
		#endregion
			
		#region Constructors
		/// <summary>
		/// Create a new instance using the default constructor
		/// </summary>
		public Menu()
		{
			isChanged = true;
            this.menuID = string.Empty;
            this.menuPosition = 0;
            this.menuValue = string.Empty;
            this.menuFiliationID = string.Empty;
            this.formName = string.Empty;
		}

		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public Menu(string MenuID, int MenuPosition)
		{
			isChanged = true;
			this.menuID = MenuID;
            this.menuPosition = MenuPosition;
		}
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public Menu(string MenuID, int MenuPosition, string MenuValue, string MenuFiliationID, string FormName)
		{
			this.menuID = MenuID;
            this.menuPosition = MenuPosition;
            this.menuValue = MenuValue;
            this.menuFiliationID = MenuFiliationID;
            this.formName = FormName;
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
		/// Property relating to database column MenuID
		/// </summary>
		public string MenuID
		{
            get { return menuID.TrimEnd(); }
            set { isChanged |= menuID != value; menuID = value; }
		}

		/// <summary>
		/// Property relating to database column MenuPosition
		/// </summary>
		public int MenuPosition
		{
            get { return menuPosition; }
            set { isChanged |= menuPosition != value; menuPosition = value; }
		}

		/// <summary>
		/// Property relating to database column MenuValue
		/// </summary>
		public string MenuValue
		{
            get { return menuValue != null ? menuValue.TrimEnd() : string.Empty; }
            set { isChanged |= menuValue != value; menuValue = value; }
		}

		/// <summary>
		/// Property relating to database column MenuFiliationID
		/// </summary>
		public string MenuFiliationID
		{
            get { return menuFiliationID != null ? menuFiliationID.TrimEnd() : string.Empty; }
            set { isChanged |= menuFiliationID != value; menuFiliationID = value; }
		}

		/// <summary>
		/// Property relating to database column FormName
		/// </summary>
		public string FormName
		{
            get { return formName != null ? formName.TrimEnd() : string.Empty; }
            set { isChanged |= formName != value; formName = value; }
		}
		#endregion

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Menu castObj = (Menu)obj;
            return (castObj != null) &&
                (this.MenuID == castObj.MenuID);
        }

      


        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * MenuID.GetHashCode();
            return hash;
        }
    }
}
