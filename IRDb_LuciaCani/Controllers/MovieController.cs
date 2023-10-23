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
		public IActionResult GetAll()
		{
			var movies = _repo.GetAllMovies();

			return Ok(movies);
		}

		[HttpGet("{id}")]
		public ActionResult<MovieModel> Get(int id)
		{
			MovieModel? movie = _repo.GetMovie(id);

			if (movie != null)
			{
				return Ok(movie);
			}
			return NotFound("This movie is not in database :(");
		}


		[HttpPut("{id}")]
		public void Put(int id, [FromBody] MovieModel AddMovie)
		{
			_repo.UpdateMovie(id, AddMovie);
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_repo.DeleteMovie(id);
		}

		//seed the database
		[HttpGet("FillDb/")]
		public void RunOnce()
		{
			var movies = new List<MovieModel>
			{
					new MovieModel { Id = 1, Title = "The Shawshank Redemption", Director = "Frank Darabont", Year = 1994, Genre = "Drama", Duration = 142, Rating = 9.3 },
					new MovieModel { Id = 2, Title = "The Godfather", Director = "Francis Ford Coppola", Year = 1972, Genre = "Crime, Drama", Duration = 175, Rating = 9.2 },
					new MovieModel { Id = 3, Title = "The Dark Knight", Director = "Christopher Nolan", Year = 2008, Genre = "Action, Crime, Drama", Duration = 152, Rating = 9.0 },
					new MovieModel { Id = 4, Title = "Pulp Fiction", Director = "Quentin Tarantino", Year= 1994, Genre = "Crime, Drama", Duration = 154, Rating = 8.9 },
					new MovieModel { Id = 5, Title = "Fight Club", Director = "David Fincher", Year = 1999, Genre = "Drama", Duration = 139, Rating = 8.8 },
					new MovieModel { Id = 6, Title = "Forrest Gump", Director = "Robert Zemeckis", Year =1994, Genre = "Drama, Romance", Duration = 142, Rating = 8.8 },
					new MovieModel { Id = 7, Title = "Inception", Director = "Christopher Nolan", Year = 2010, Genre = "Action, Adventure, Sci-Fi", Duration = 148, Rating = 8.7 },
					new MovieModel { Id = 8, Title = "The Matrix", Director = "Lana Wachowski, Lilly Wachowski", Year = 1999, Genre = "Action, Sci-Fi", Duration = 136, Rating = 8.7 },
					new MovieModel { Id = 9, Title = "Interstellar", Director = "Christopher Nolan", Year= 2014, Genre = "Adventure, Drama, Sci-Fi", Duration = 169, Rating = 8.6 },
					new MovieModel { Id = 10, Title = "The Lord of the Rings: The Fellowship of the Ring",Director = "Peter Jackson", Year = 2001, Genre = "Adventure, Drama, Fantasy", Duration = 178, Rating = 8.8 }
			};

			foreach (MovieModel m in movies)
			{
				_repo.PostMovie(m);
			}
			
		}
	}
}
