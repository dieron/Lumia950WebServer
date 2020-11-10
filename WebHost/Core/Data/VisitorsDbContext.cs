using Microsoft.EntityFrameworkCore;

namespace MDGriphe.Experiments.Lumia950.WebHost.Core.Data
{
	public class VisitorsDbContext : DbContext, IVisitorsDbContext
	{
		public VisitorsDbContext(DbContextOptions<VisitorsDbContext> options) : base(options)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Visit>()
				.HasIndex(e => e.Created);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite("Data Source=db\\sqlitelumia.db");

		public DbSet<Visit> Visitors { get; set; }




	}
}