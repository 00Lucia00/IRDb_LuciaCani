using IRDb_LuciaCani.Data;
using IRDb_LuciaCani.Models;
using IRDb_LuciaCani.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IRDb_LuciaCani.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovieController : ControllerBase
	{
		private readonly IMovieRepos _repo;

		public MovieController(IMovieRepos repo) { _repo = repo; }

		[HttpPost]
		public void Post([FromBody] MovieModel AddMovie)
		{
			_repo.PostMovie(AddMovie);
		
		}

	
		[HttpGet]
		public List<MovieModel> GetAll()
		{
			return _repo.GetAllMovies();
		}

		[HttpGet("{id}")]
		public MovieModel Get(int id)
		{
			return _repo.GetMovie(id);
		}


		[HttpPut("{id}")]
		public void Put(int id,[FromBody] MovieModel AddMovie)
		{
			_repo.UpdateMovie(id,AddMovie);
		}

		[HttpDelete("{id}")]
		public void Delete(int id) 
		{
			_repo.DeleteMovie(id);
		}


	}
}
