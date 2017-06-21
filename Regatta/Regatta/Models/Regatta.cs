using System;
using System.Collections.Generic;

namespace Regatta.Models
{
	public class Regatta
	{
		public int RegattaId		{ get; set; }
		public string Name			{ get; set; }
		public DateTime StartDate	{ get; set; }
		public DateTime EndDate		{ get; set; }
		public string Class			{ get; set; }
		public int Rating			{ get; set; }

		public List<RegattaCompetitor> RegattaCompetitors { get; set; }
	}
}
