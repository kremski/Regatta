using Microsoft.AspNetCore.Mvc;
using Regatta.Models;
using System.Collections.Generic;
using System.Linq;

namespace Regatta.Controllers
{
	[Route("api/[controller]")]
	public class ClubController : Controller
	{
		private RegattaContext _context;

		public ClubController()
		{
			_context = new RegattaContext();
		}

		// GET api/club
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return _context.Clubs.Select(x => x.Name);
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			var club = _context.Clubs.Find(id);

			if (club == null)
				return string.Empty;

			return club.Name;
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
