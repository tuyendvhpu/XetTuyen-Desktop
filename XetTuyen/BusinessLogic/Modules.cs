using System;
using System.Collections.Generic;

using System.Text;

namespace BusinessLogic
{

    public class ModulesCollection : List<Modules>
    {
    }

    public  class Modules
    {
       #region Members
		private bool isChanged;
		private int moduleID;
		private string moduleName;
		private string note;
		#endregion
			
		#region Constructors
		/// <summary>
		/// Create a new instance using the default constructor
		/// </summary>
		public Modules()
		{
			isChanged = true;
            ModuleID = -1;
            ModuleName = string.Empty;
            Note = string.Empty;
		}

		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public Modules(int ModuleID)
		{
			isChanged = true;
			this.moduleID = ModuleID;
		}
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public Modules(int ModuleID, string ModuleName, string Note)
		{
            this.moduleID = ModuleID;
            this.moduleName = ModuleName;
            this.note = Note;
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
		/// Property relating to database column ModuleID
		/// </summary>
		public int ModuleID
		{
            get { return moduleID; }
            set { isChanged |= moduleID != value; moduleID = value; }
		}

		/// <summary>
		/// Property relating to database column ModuleName
		/// </summary>
		public string ModuleName
		{
            get { return moduleName != null ? moduleName.TrimEnd() : string.Empty; }
            set { isChanged |= moduleName != value; moduleName = value; }
		}

		/// <summary>
		/// Property relating to database column Note
		/// </summary>
		public string Note
		{
            get { return note != null ? note.TrimEnd() : string.Empty; }
            set { isChanged |= note != value; note = value; }
		}
		#endregion
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Modules castObj = (Modules)obj;
            return (castObj != null) &&
                (this.ModuleID == castObj.ModuleID);
        }

        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * ModuleID.GetHashCode();
            return hash;
        }
    }
}
