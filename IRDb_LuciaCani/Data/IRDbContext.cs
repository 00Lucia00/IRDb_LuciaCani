using IRDb_LuciaCani.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace IRDb_LuciaCani.Data
{
	public class IRDbContext : DbContext
	{
		public IRDbContext(DbContextOptions<IRDbContext> options) : base(options) 
		{
		
		}

		public DbSet<MovieModel> Movies { get; set; }
	}
}
