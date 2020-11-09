using System;
using System.Runtime.InteropServices;
using MDGriphe.Experiments.Lumia950.WebHost.Core.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace MDGriphe.Experiments.Lumia950.WebHost
{
	class Program
	{

		static void Main(string[] args)
		{
			bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
			string osName = isWindows ? "windows" : "linux";

			try
			{
				Console.WriteLine("Running on " + osName);
				IHost host = CreateHostBuilder(args).Build();


				using (var scope = host.Services.CreateScope())
				{
					try
					{
						var context = scope.ServiceProvider.GetService<VisitorsDbContext>();
						Console.WriteLine("Context created");

						// context.Database.EnsureCreated();
						// Console.WriteLine("EnsureCreated ran");

						context.Database.Migrate();
						Console.WriteLine("Migrate ran");
					}
					catch (Exception e)
					{
						Console.WriteLine("Exception: " + e.Message);
						throw;
					}
				}
				host.Run();
			}
			catch (Exception ex)
			{
				//NLog: catch setup errors
				Console.WriteLine("Stopped program because of exception. " + ex);
				throw;
			}
			finally
			{
				// Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
			}
		}

		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			string env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.{env}.json")
				.Build();

			return Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>().UseUrls("http://0.0.0.0:5001/");
				})
				.UseWindowsService()
				.ConfigureLogging((context, builder) =>
				{
					builder.ClearProviders();
					builder.SetMinimumLevel(LogLevel.Trace);
				});
		}

	}
}
