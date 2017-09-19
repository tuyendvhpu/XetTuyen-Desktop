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
	public class ParamasterConfig
	{
		public string Time;
		public string Address;
		
        public ParamasterConfig()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
