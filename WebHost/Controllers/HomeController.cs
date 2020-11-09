using System;
using System.Diagnostics;
using System.Linq;
using MDGriphe.Experiments.Lumia950.WebHost.Core.Data;
using MDGriphe.Experiments.Lumia950.WebHost.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MDGriphe.Experiments.Lumia950.WebHost.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IServiceProvider _services;

		public HomeController(ILogger<HomeController> logger, IServiceProvider services)
		{
			_logger = logger;
			_services = services;
		}

		public IActionResult Index()
		{
			var mainModel = new MainModel();

			// registering the visit
			using (var scope = _services.CreateScope())
			{
				using (var context = scope.ServiceProvider.GetService<VisitorsDbContext>())
				{
					// loading stats
					int visitsCount = context.Visitors.AsQueryable().Count();
					mainModel.TotalVisitsCount = visitsCount;

					// last 10
					var last10 = context.Visitors.OrderByDescending(visit => visit.Id).Take(10).ToList();
					mainModel.Last10Visits = last10;

					// registering new visit
					var visit = new Visit
					{
						Created = DateTime.UtcNow,
						IP = HttpContext.Connection.RemoteIpAddress.ToString(),
						VisitorId = HttpContext.Connection.Id,
						Query = HttpContext.Request.QueryString.ToString(),
						Path = HttpContext.Request.Path.ToString(),
						Headers = String.Join("; ", HttpContext.Request.Headers.Select(pair =>$"{pair.Key}: {pair.Value}")),
					};
					context.Visitors.Add(visit);

					context.SaveChanges();


				}
			}


			return View(mainModel);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
