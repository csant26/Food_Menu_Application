using Food_Menu_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Menu_Application.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            });
            modelBuilder.Entity<DishIngredient>()
                .HasOne(d => d.Dish)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredient>()
                .HasOne(i => i.Ingredient)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(i => i.IngredientId);

            modelBuilder.Entity<Dish>()
                .HasData(
                new Dish{
                    Id = 1,
                    Name = "Margherita",
                    ImageUrl = "https://www.abeautifulplate.com/wp-content/uploads/2015/08/the-best-homemade-margherita-pizza-1-4-500x500.jpg",
                    Price = 350.50
                },
                new Dish
                {
                    Id = 2,
                    Name = "Hawaiann",
                    ImageUrl = "https://www.jessicagavin.com/wp-content/uploads/2020/07/hawaiian-pizza-16-1200.jpg",
                    Price = 560.60
                },
                new Dish
                {
                    Id = 3,
                    Name = "Pepperoni",
                    ImageUrl = "https://www.simplyrecipes.com/thmb/I4razizFmeF8ua2jwuD0Pq4XpP8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2019__09__easy-pepperoni-pizza-lead-4-82c60893fcad4ade906a8a9f59b8da9d.jpg",
                    Price = 600.30
                });

            modelBuilder.Entity<Ingredient>()
                .HasData(
                new Ingredient { Id = 1, Name = "Tomata Sauce"},
                new Ingredient { Id = 2, Name = "Mozarella"},
                new Ingredient { Id = 3, Name = "Pineapple"},
                new Ingredient { Id = 4, Name = "Ham"},
                new Ingredient { Id = 5, Name = "Pepperoni"}
                );

            modelBuilder.Entity<DishIngredient>()
                .HasData(
                new DishIngredient { DishId = 1, IngredientId = 1},
                new DishIngredient { DishId = 1, IngredientId = 2},
                new DishIngredient { DishId = 2, IngredientId = 1},
                new DishIngredient { DishId = 2, IngredientId = 2 },
                new DishIngredient { DishId = 2, IngredientId = 3 },
                new DishIngredient { DishId = 2, IngredientId = 4 },
                new DishIngredient { DishId = 3, IngredientId = 1 },
                new DishIngredient { DishId = 3, IngredientId = 2 },
                new DishIngredient { DishId = 3, IngredientId = 5 }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    
    }

}
