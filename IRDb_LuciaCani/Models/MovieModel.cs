namespace IRDb_LuciaCani.Models
{
	public class MovieModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string? Description { get; set; }
		public string? Director { get; set; }
		public string Genre { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Duration { get; set; }
        public double Rating { get; set; }
    }
}
