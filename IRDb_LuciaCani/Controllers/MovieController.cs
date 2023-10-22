using IRDb_LuciaCani.Data;
using IRDb_LuciaCani.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IRDb_LuciaCani.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovieController : ControllerBase
	{
		private readonly IRDbContext _context;

		public MovieController(IRDbContext context) 
		{
		     _context = context;
		}

		[HttpPost]
		public void Post([FromBody] MovieModel AddMovie) 
		{ 
			_context.Movies.Add(AddMovie);
			_context.SaveChanges();
		}


	}
}
