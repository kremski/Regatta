using System.Collections.Generic;

namespace Regatta.Models
{
	public class Race
	{
		public int RaceId		{ get; set; }
		public int RaceType		{ get; set; }
		public int RaceNumber	{ get; set; }
		public string Group		{ get; set; }
		public int Round		{ get; set; }
		
		public virtual List<RacePoint> RacePoints { get; set; }
	}
}
