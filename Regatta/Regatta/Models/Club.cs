using System.Collections.Generic;

namespace Regatta.Models
{
	public class Club
	{
		public int ClubId			{ get; set; }
		public string Name			{ get; set; }
		public string TownOrCity	{ get; set; }
		public string Country		{ get; set; }

		public virtual List<Competitor> ClubMembers { get; set; }
	}
}
