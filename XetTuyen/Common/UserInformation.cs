using System;
using BusinessLogic;
using BusinessService;
using DataAccess;
namespace Common
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public  class UserInformation
	{
		private int  m_iIDUser;
        private string m_sMaNhanVien;
		private bool m_bLoggedIn;
		private string m_iQuyen;
		private string m_sTen;
        private string m_sUser;

		public  UserInformation()
		{
				m_iIDUser = -1;
				m_bLoggedIn = false;
				m_iQuyen  = null;
				m_sTen = null;
                m_sUser = null;
                m_sMaNhanVien = null;
		}

        public void login(int iIDUser, string iQuyen, string sTen, string sUserName, string sMaNhanVien)
		{
			m_iIDUser = iIDUser;
			m_bLoggedIn = true;
			m_iQuyen = iQuyen;
			m_sTen = sTen;
            m_sUser = sUserName;
            m_sMaNhanVien = sMaNhanVien ;


		}

		public void logout()
		{
			m_bLoggedIn = false;
			m_iIDUser = -1;
			m_iQuyen = null;
			m_sTen = null;
            m_sUser = null;
            m_sMaNhanVien = null;
		}

		public int nID_User
		{
			get
			{
				return m_iIDUser;
			}
		}
		public bool LoggedIn
		{
			get
			{
				return m_bLoggedIn;
			}
		}
        public string iQuyen
		{
			get
			{
				return m_iQuyen; 
			}
		}
        public string sTen
		{
			get
			{
				return m_sTen;
			}
		}
        public string sUser
        {
            get
            {
                return m_sUser;
            }
        }
        public string sMaNhanVien
        {
            get
            {
                return m_sMaNhanVien;
            }
        }
	}
}
