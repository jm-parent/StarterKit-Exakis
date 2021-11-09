using StarterKit.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterKit.Services
{
	public class MyDataService : IMyDataService
	{
		private int nb = 0;
		public string GetMessage()
		{
			++nb;
			return nb.ToString();
		}
	}
}