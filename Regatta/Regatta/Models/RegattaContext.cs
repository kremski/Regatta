using Microsoft.EntityFrameworkCore;

namespace Regatta.Models
{
	public class RegattaContext : DbContext
	{
		public DbSet<Competitor> Competitors				{ get; set; }
		public DbSet<Club> Clubs							{ get; set; }
		public DbSet<Regatta> Regattas						{ get; set; }
		public DbSet<RegattaCompetitor> RegattaCompetitors	{ get; set; }
		public DbSet<Race> Races							{ get; set; }
		public DbSet<RacePoint> RacePoints					{ get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=regatta.db");
		}
	}
}
