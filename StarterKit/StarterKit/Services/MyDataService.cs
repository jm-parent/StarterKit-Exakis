using StarterKit.Services.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		public ObservableCollection<string> GetListNames()
		{
			return new ObservableCollection<string>(new List<string>()
			{
				"Daniel",
				"Ella",
				"Willner"
			});
		}
	}
}