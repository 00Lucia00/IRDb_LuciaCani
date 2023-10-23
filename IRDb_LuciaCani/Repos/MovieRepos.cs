using IRDb_LuciaCani.Data;
using IRDb_LuciaCani.Models;

namespace IRDb_LuciaCani.Repos
{
	public class MovieRepos : IMovieRepos
	{
		private readonly IRDbContext _context;

		
		public MovieRepos(IRDbContext context)
		{ 
			_context = context; 
		}

		public List<MovieModel> GetAllMovies()
		{
			return _context.Movies.ToList();
		}

		public MovieModel? GetMovie(int id)
		{
			return _context.Movies.FirstOrDefault(x => x.Id == id);
		}

		public void PostMovie(MovieModel movie)
		{
		
			_context.Movies.Add(movie);
			_context.SaveChanges();
		}

		public void UpdateMovie(int id, MovieModel movie) 
		{
			MovieModel? UpdateMovie = _context.Movies.FirstOrDefault(x => x.Id == id);

			if(UpdateMovie != null)
			{
				UpdateMovie.Title = UpdateMovie.Title;
				UpdateMovie.Description = UpdateMovie.Description;
				UpdateMovie.Director = UpdateMovie.Director;
				UpdateMovie.Rating = UpdateMovie.Rating;
				UpdateMovie.Year = UpdateMovie.Year;
				UpdateMovie.Genre = UpdateMovie.Genre;
				UpdateMovie.Duration = UpdateMovie.Duration;

				_context.SaveChanges();
			}
		}


		public void DeleteMovie(int id) 
		{
			MovieModel? Delmovie = _context.Movies.FirstOrDefault(x => x.Id == id);
			if (Delmovie != null) 
			{
				_context.Movies.Remove(Delmovie);
				_context.SaveChanges();
			}
		}

	}
}
