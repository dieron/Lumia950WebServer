using System.Collections.Generic;
using MDGriphe.Experiments.Lumia950.WebHost.Core.Data;

namespace MDGriphe.Experiments.Lumia950.WebHost.Models
{
	public class MainModel
	{
		public string CpuInfo { get; set; }
		public string TotalLoad { get; set; }
		public string CoreCount { get; set; }


		public int TotalVisitsCount { get; set; }
		public int TodayVisitsCount { get; set; }
		public int YesterdayVisitsCount { get; set; }
		public int LastMonthVisitsCount { get; set; }
		public int CurrentMonthVisitsCount { get; set; }

		public List<Visit> Last10Visits { get; set; }
		public int ControllerTimeMs { get; set; }
	}
}