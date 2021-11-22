using StarterKit.Services.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StarterKit.Services
{
	public class MyDataService : IMyDataService
	{
        public MyDataService()
        {
			var aze = 0;
        }
		private int nb;
		public string GetMessage()
		{
			nb = nb+1;
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