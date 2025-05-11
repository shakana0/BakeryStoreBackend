using Domain;

namespace Application.Tests.Infrastructure
{
    public class DataProvider
    {
        public static List<Product> GetBakeryProducts()
        {
            return new List<Product> {
                new Product() {
                Id = 1,
                Name = "1Test name",
                Description = "1Test beskrivning",
                Price = 4,
                Stock = 17,
                CategoryId = 1,
            },
                new Product() {
                Id = 2,
                Name = "2Test name",
                Description = "2Test beskrivning",
                Price = 4,
                Stock = 17,
                CategoryId = 2,
            },
                new Product() {
               Id = 3,
                Name = "3Test name",
                Description = "3Test beskrivning",
                Price = 4,
                Stock = 17,
                CategoryId = 3,
            },
                new Product() {
                Id = 4,
                Name = "4Test name",
                Description = "4Test beskrivning",
                Price = 4,
                Stock = 17,
                CategoryId = 4,
            },
                new Product() {
                Id = 5,
                Name = "5Test name",
                Description = "5Test beskrivning",
                Price = 4,
                Stock = 17,
                CategoryId = 5,
            }};
        }
        public static List<Ingredient> GetBakeryIngredients()
        {
            return new List<Ingredient> {
                new Ingredient() {
                    Id = 1,
                    Name = "Flour",
                    Allergens = "Gluten"
                },
                new Ingredient() {
                    Id = 2,
                    Name = "Sugar",
                    Allergens = "None"
                },
                new Ingredient() {
                    Id = 3,
                    Name = "Eggs",
                    Allergens = "Egg"
                },
                new Ingredient() {
                    Id = 4,
                    Name = "Milk",
                    Allergens = "Dairy"
                },
                new Ingredient() {
                    Id = 5,
                    Name = "Butter",
                    Allergens = "Dairy"
                }
            };
        }
        public static List<Category> GetBakeryCategories()
        {
            return new List<Category>{
                new Category() {
                    Id = 1,
                    Name = "Bread"
                },
                new Category() {
                    Id = 2,
                    Name = "Pastry"
                },
                new Category() {
                    Id = 3,
                    Name = "Cake"
                },
                new Category() {
                    Id = 4,
                    Name = "Cookies"
                },
                new Category() {
                    Id = 5,
                    Name = "Muffins"
                }
            };
        }

    }
}