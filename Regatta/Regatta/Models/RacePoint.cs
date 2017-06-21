namespace Regatta.Models
{
	public class RacePoint
	{
		public int RacePointId		{ get; set; }
		public double Points		{ get; set; }
		public bool IsCrossed		{ get; set; }

		public int RaceId			{ get; set; }
		public virtual Race Race	{ get; set; }

		public int RegattaCompetitorId						{ get; set; }
		public virtual RegattaCompetitor RegattaCompetitor	{ get; set; }
	}
}
