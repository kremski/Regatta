using System.Collections.Generic;

namespace Regatta.Models
{
	public class RegattaCompetitor
	{
		public int RegattaCompetitorId			{ get; set; }

		public int CompetitorId					{ get; set; }
		public virtual Competitor Competitor	{ get; set; }

		public int RegattaId					{ get; set; }
		public virtual Regatta Regatta			{ get; set; }

		public List<RacePoint> RacePoints		{ get; set; }
	}
}
