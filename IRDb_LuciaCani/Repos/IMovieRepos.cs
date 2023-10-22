using IRDb_LuciaCani.Models;

namespace IRDb_LuciaCani.Repos
{
	public interface IMovieRepos
	{
		public List<MovieModel> GetAllMovies();

		public MovieModel? GetMovie(int id);

		public void PostMovie(MovieModel movie);

		public void DeleteMovie(int id);

		public void UpdateMovie(int id, MovieModel movie);
	}
}
