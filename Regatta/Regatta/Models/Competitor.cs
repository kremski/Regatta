using System.Collections.Generic;

namespace Regatta.Models
{
	public class Competitor
	{
		public int CompetitorId			{ get; set; }
		public string FirstName			{ get; set; }
		public string LastName			{ get; set; }
		public string SailNumber		{ get; set; }
		public bool IsRankingClasified	{ get; set; }
		public int AgeGroup				{ get; set; }

		public int? ClubId				{ get; set; }
		public virtual Club Club		{ get; set; }

		public virtual List<RegattaCompetitor> RegattaCompetitors { get; set; }
	}
}
