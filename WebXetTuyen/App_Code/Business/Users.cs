using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public enum UserStatus
    {
        OK = 1,
        Locked = 2,
        ExpiredDate = 3,
        NotExists = 4
    }
    public class UserCollection : List<Users>
    {
    }

    public  class Users
    {
        #region Members
		private bool isChanged;
		
		private string loginID;
		private string password;
		
		private string fullName;
		
		private string email;
	
		private DateTime createdDate;
	
		private bool lockedUser;
	
		private DateTime lockedDate;
	
		private string lockedReason;
	
		private DateTime lastLogIn;
	
		private DateTime lastChangedPassword;
	
		private DateTime deadlineOfUsing;
		
		private DateTime birthDay;
		
		private string gender;
		#endregion
			
		#region Constructors


        /// <summary> 
        /// Create a new object using the minimum required information (all not-null fields except 
        /// auto-generated primary keys). 
        /// </summary> 
        public Users() {
            loginID = string.Empty;
            password = string.Empty;
            fullName = string.Empty;
            email = string.Empty;

            DateTime dtmDefault = new DateTime(1900, 1, 1);
            createdDate = DateTime.Now;
            lockedUser = false;
             lockedDate = dtmDefault;
             lockedReason = string.Empty;
             lastLogIn = dtmDefault;
             lastChangedPassword = dtmDefault;
             deadlineOfUsing = dtmDefault;
             birthDay = dtmDefault;
             gender = string.Empty;

        }
		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public Users(string loginID, string password, string fullName, DateTime createdDate, bool lockedUser)
		{
			isChanged = true;
			this.loginID = loginID;
			this.password = password;
			this.fullName = fullName;
			this.createdDate = createdDate;
			this.lockedUser = lockedUser;
		}
			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public Users(string loginID, string password, string fullName, string email, DateTime createdDate, bool lockedUser, DateTime lockedDate, string lockedReason, DateTime lastLogIn, DateTime lastChangedPassword, DateTime deadlineOfUsing, DateTime birthDay, string gender)
		{
			this.loginID = loginID;
			this.password = password;
			this.fullName = fullName;
			this.email = email;
			this.createdDate = createdDate;
			this.lockedUser = lockedUser;
			this.lockedDate = lockedDate;
			this.lockedReason = lockedReason;
			this.lastLogIn = lastLogIn;
			this.lastChangedPassword = lastChangedPassword;
			this.deadlineOfUsing = deadlineOfUsing;
			this.birthDay = birthDay;
			this.gender = gender;
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
		/// Property relating to database column LoginID
		/// </summary>
		public string LoginID
		{
			get { return loginID.TrimEnd(); }
			set { isChanged |= loginID != value; loginID = value; }
		}

		/// <summary>
		/// Property relating to database column Password
		/// </summary>
		public string Password
		{
			get { return password.TrimEnd(); }
			set { isChanged |= password != value; password = value; }
		}

		/// <summary>
		/// Property relating to database column FullName
		/// </summary>
		public string FullName
		{
			get { return fullName.TrimEnd(); }
			set { isChanged |= fullName != value; fullName = value; }
		}

		/// <summary>
		/// Property relating to database column Email
		/// </summary>
		public string Email
		{
			get { return email != null ? email.TrimEnd() : string.Empty; }
			set { isChanged |= email != value; email = value; }
		}

		/// <summary>
		/// Property relating to database column CreatedDate
		/// </summary>
		public DateTime CreatedDate
		{
			get { return createdDate; }
			set { isChanged |= createdDate != value; createdDate = value; }
		}

		/// <summary>
		/// Property relating to database column LockedUser
		/// </summary>
		public bool LockedUser
		{
			get { return lockedUser; }
			set { isChanged |= lockedUser != value; lockedUser = value; }
		}

		/// <summary>
		/// Property relating to database column LockedDate
		/// </summary>
		public DateTime LockedDate
		{
			get { return lockedDate; }
			set { isChanged |= lockedDate != value; lockedDate = value; }
		}

		/// <summary>
		/// Property relating to database column LockedReason
		/// </summary>
		public string LockedReason
		{
			get { return lockedReason != null ? lockedReason.TrimEnd() : string.Empty; }
			set { isChanged |= lockedReason != value; lockedReason = value; }
		}

		/// <summary>
		/// Property relating to database column LastLogIn
		/// </summary>
		public DateTime LastLogIn
		{
			get { return lastLogIn; }
			set { isChanged |= lastLogIn != value; lastLogIn = value; }
		}

		/// <summary>
		/// Property relating to database column LastChangedPassword
		/// </summary>
		public DateTime LastChangedPassword
		{
			get { return lastChangedPassword; }
			set { isChanged |= lastChangedPassword != value; lastChangedPassword = value; }
		}

		/// <summary>
		/// Property relating to database column DeadlineOfUsing
		/// </summary>
		public DateTime DeadlineOfUsing
		{
			get { return deadlineOfUsing; }
			set { isChanged |= deadlineOfUsing != value; deadlineOfUsing = value; }
		}

		/// <summary>
		/// Property relating to database column BirthDay
		/// </summary>
		public DateTime BirthDay
		{
			get { return birthDay; }
			set { isChanged |= birthDay != value; birthDay = value; }
		}

		/// <summary>
		/// Property relating to database column Gender
		/// </summary>
		public string Gender
		{
			get { return gender != null ? gender.TrimEnd() : string.Empty; }
			set { isChanged |= gender != value; gender = value; }
		}
		#endregion
    }
}
