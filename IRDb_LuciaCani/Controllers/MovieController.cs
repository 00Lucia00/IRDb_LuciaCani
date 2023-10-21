using IRDb_LuciaCani.Data;
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


	}
}
