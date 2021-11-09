using StarterKit.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterKit.Services
{
	public class MyDataService : IMyDataService
	{
		public string GetMessage()
		{
			return "This is from MyDataService";
		}
	}
}