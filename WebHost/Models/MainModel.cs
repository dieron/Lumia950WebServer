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
		public List<Visit> Last10Visits { get; set; }
	}
}