using System;
using BusinessLogic;
using BusinessService;
using DataAccess;

namespace Common
{
	/// <summary>
	/// Summary description for CompanyConfig.
	/// </summary>
	[Serializable()]

	public class CompanyConfig
	{
		public string Name;
		public string Phone;
		public string Address;
		public string Header;
        public string Fax;
        public string Mail;
        public string Website;
        public string Logo;
        public int  so;
		public CompanyConfig()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
