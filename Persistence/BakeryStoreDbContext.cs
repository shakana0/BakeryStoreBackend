using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
	public class BakeryStoreDbContext : DbContext
	//DbContext represents a session with the database and can be used to query and save data.
	{
		//These properties represent tables in the database. Each DbSet corresponds to a table.
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductIngredient> ProductIngredients { get; set; }
		//This constructor initializes the DbContext with options, such as the database connection string
		public BakeryStoreDbContext(DbContextOptions<BakeryStoreDbContext> options) : base(options)
		{
			//The if statement checks if the database provider is in-memory
			if (Database.ProviderName == DatabaseProvider.InMemory)
				return;
		}
		//This method is used to configure the model (the shape of the tables and relationships) using the ModelBuilder.
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// The modelBuilder.Entity method is used to configure the entity type.
			var builder = modelBuilder.Entity<Product>().ToTable("Product", "dbo");
			builder.HasKey(e => e.Id);
			builder.HasOne<Category>()
				   .WithMany()
				   .HasForeignKey(e => e.CategoryId)
				   .OnDelete(DeleteBehavior.Restrict);
			builder.Property(p => p.Price)
						  .HasPrecision(18, 2); // Precision: 18, Scale: 2
			var builder1 = modelBuilder.Entity<Category>().ToTable("Category", "dbo");
			builder1.HasKey(e => e.Id);

			var builder2 = modelBuilder.Entity<Ingredient>().ToTable("Ingredient", "dbo");
			builder2.HasKey(e => e.Id);

			var builder3 = modelBuilder.Entity<ProductIngredient>().ToTable("ProductIngredient", "dbo");
			builder3.HasKey(e => e.Id);
			builder3.Property(p => p.Quantity)
			  .HasPrecision(18, 2); // Precision: 18, Scale: 2
		}

	}
}
