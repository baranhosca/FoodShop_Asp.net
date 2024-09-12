using Microsoft.EntityFrameworkCore;

namespace FoodShop.Models
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=BARANPC\\SQLEXPRESS; database=FoodShopDB; Trusted_Connection=True; TrustServerCertificate=true");
		}
		public DbSet<Food> Foods { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Admin> Admins { get; set; }
	}
}
