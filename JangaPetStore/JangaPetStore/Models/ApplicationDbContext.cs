using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JangaPetStore.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
            );

            // Seed users
            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "1",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "admin"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new IdentityUser
                {
                    Id = "2",
                    UserName = "Abhishek",
                    NormalizedUserName = "ABHISHEK",
                    Email = "abhishek@example.com",
                    NormalizedEmail = "ABHISHEK@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abhishek"),
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "1", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "2", RoleId = "2" }
                
            );

            // Seed categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Dogs" },
                new Category { CategoryId = 2, Name = "Cats" },
                new Category { CategoryId = 3, Name = "Birds" },
                new Category { CategoryId = 4, Name = "Fish" },
                new Category { CategoryId = 5, Name = "Reptiles" },
                new Category { CategoryId = 6, Name = "Small Animals" },
                new Category { CategoryId = 7, Name = "Pet Supplies" },
                new Category { CategoryId = 8, Name = "Pet Food" }
            );

            // Seed products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 30, Name = "Siberian Husky", Description = "A graceful dog with erect ears and a dense soft coat, the Siberian Husky stands 20 to 24 inches (51 to 61 cm) tall at the withers and weighs 35 to 60 pounds (16 to 27 kg). It is usually gray, tan, or black and white, and it may have head markings resembling a cap, a mask, or spectacles.", Price = 123.00m, StockQuantity = 123, CategoryId = 1, ImageUrl = "/uploads/Husky20240812182712.webp" },
                new Product { ProductId = 31, Name = "Rottweiler", Description = "Rottweiler, breed of working dog that is thought to be descended from drover dogs (cattle-driving dogs) left by the Roman legions in the vicinity of what is now Rottweil, Germany, after the Romans abandoned the region during the 2nd century CE. From the Middle Ages to about 1900 the Rottweiler accompanied local butchers on buying expeditions, carrying money in a neck pouch to market. It has also served as a guard dog, a drover’s dog, a draft dog, a rescue dog, and a police dog.", Price = 2500.00m, StockQuantity = 20, CategoryId = 1, ImageUrl = "/uploads/Rottweiler20240812182905.webp" },
                new Product { ProductId = 32, Name = "Samoyed", Description = "A regal-looking white spitz breed, the Samoyed is a medium-to-large dog that is white from head to toe. The thick, fluffy nature of the coat makes perfect sense when considering that this dog breed originated in Siberia. The indigenous Samoyed people used these strong and cold weather-tolerant dogs to herd reindeer, pull sleds, and hunt. The Samoyed has a tail that curls up over its back and a thick ruff of fur around its neck. Though these dogs are generally an all-white breed, some mature into a cream or biscuit-colored coat. Life with this white dog breed means a flurry of fur year-round. While these dogs shed their undercoat seasonally, white hair is likely to be found on your clothes and furniture year-round.\r\nGROUP: Working (AKC)\r\n\r\nHEIGHT: 19 to 24 inches\r\n\r\nWEIGHT: 35 to 65 pounds\r\n\r\nCOAT AND COLOR: Thick double coat; colors include white, cream, and biscuit\r\n\r\nLIFE EXPECTANCY: 12 to 14 years", Price = 2000.00m, StockQuantity = 10, CategoryId = 1, ImageUrl = "/uploads/samoyed20240812183532.jpg" },
                new Product { ProductId = 33, Name = "British Shorthair", Description = "The British Shorthair is the pedigreed version of the traditional British domestic cat, with a distinctively stocky body, thick coat, and broad face. The most familiar colour variant is the \"British Blue\", with a solid grey-blue coat, pineapple eyes, and a medium-sized tail. The breed has also been developed in a wide range of other colours and patterns, including tabby and colourpoint.", Price = 2300.00m, StockQuantity = 23, CategoryId = 2, ImageUrl = "/uploads/British Shorthair20240812183939.jpg" },
                new Product { ProductId = 34, Name = "Persian", Description = "With their snub noses, chubby cheeks, and long hair, the Persian cat is quite an exquisite breed. Theyre also typically quiet and affectionate cats who enjoy being held, but theyre content just lounging around too. They make a perfect, purring lap warmer!", Price = 2500.00m, StockQuantity = 2, CategoryId = 2, ImageUrl = "/uploads/persian20240812184236.jpg" },
                new Product { ProductId = 35, Name = "Sphynx", Description = "The sphynx cat is an energetic, acrobatic performer who loves to show off for attention. She has an unexpected sense of humor that is often at odds with her dour expression.\r\n\r\nFriendly and loving, this is a loyal breed who will follow you around the house and try to involve herself in whatever youre doing, grabbing any opportunity to perch on your shoulder or curl up in your lap. As curious and intelligent as she is energetic, these traits can make her a bit of a handful. For her own safety, the sphynx does best as an exclusively indoor cat, and generally gets along well with children other pets.", Price = 3000.00m, StockQuantity = 32, CategoryId = 2, ImageUrl = "/uploads/Sphynx20240812184507.jpg" },
                new Product { ProductId = 36, Name = "Hyacinth Macaw", Description = "The Hyacinth Macaw is the largest of the parrot species, with striking deep blue feathers and a distinctive yellow ring around its eyes. Native to Brazil, it is known for its intelligence, playful behavior, and ability to mimic human speech.", Price = 12000.00m, StockQuantity = 12, CategoryId = 3, ImageUrl = "/uploads/Macaw20240812184930.jpg" },
                new Product { ProductId = 37, Name = "Scarlet Macaw", Description = "The Scarlet Macaw is renowned for its vibrant red, yellow, and blue plumage. Native to Central and South America, these birds are highly sought after for their beauty and engaging personalities. They are also known for their loud, raucous calls.", Price = 17500.00m, StockQuantity = 12, CategoryId = 3, ImageUrl = "/uploads/Scarlet Macaw20240812185142.jpg" },
                new Product { ProductId = 38, Name = "African Grey Parrot", Description = "Known for its exceptional intelligence and ability to mimic human speech, the African Grey Parrot is a medium-sized parrot with predominantly grey feathers and a bright red tail. It is highly prized for its cognitive abilities and its capability to build strong bonds with its owners.", Price = 18000.00m, StockQuantity = 2, CategoryId = 3, ImageUrl = "/uploads/african_grey_20240812185334.jpg" },
                new Product { ProductId = 40, Name = "Arowana (Asian Arowana)", Description = "The Asian Arowana, also known as the Dragon Fish, is highly prized for its stunning appearance, with its metallic sheen and elongated body. It is native to Southeast Asia and is often considered a symbol of good luck and prosperity. It requires a large tank due to its size and is known for its impressive jumping ability.", Price = 30000.00m, StockQuantity = 2, CategoryId = 4, ImageUrl = "/uploads/Arowana20240812185720.jpg" },
                new Product { ProductId = 41, Name = "Koi Fish (Koi Carp)", Description = "Koi are ornamental varieties of the common carp and are celebrated for their bright, vibrant colors and intricate patterns. Originating from Japan, high-quality Koi can have unique colorations and patterns, making them highly sought after by collectors. They are often kept in outdoor ponds but can also be maintained in large aquariums.", Price = 7000.00m, StockQuantity = 45, CategoryId = 4, ImageUrl = "/uploads/Koi20240812190004.jpg" },
                new Product { ProductId = 42, Name = "Pomacanthus (Emperor Angelfish)", Description = "The Emperor Angelfish is a strikingly beautiful fish found in the Indo-Pacific region, known for its vibrant blue and yellow stripes and regal appearance. It is a popular choice for saltwater aquariums but requires a spacious tank and specific care due to its size and dietary needs.", Price = 2500.00m, StockQuantity = 5, CategoryId = 4, ImageUrl = "/uploads/pomacanthus20240812190212.jpg" },
                new Product { ProductId = 43, Name = "Bearded Dragon", Description = "The Bearded Dragon is a friendly and hardy lizard native to Australia. It gets its name from the spiky \"beard\" of scales around its throat. Bearded Dragons are known for their docile nature and interactive behavior, making them a favorite among reptile enthusiasts.\\r\\n", Price = 125.00m, StockQuantity = 200, CategoryId = 5, ImageUrl = "/uploads/bearded-dragon-on-sand20240812190441.jpg" },
                new Product { ProductId = 44, Name = "Corn Snake", Description = "The Corn Snake is a non-venomous snake native to North America, known for its vibrant coloration and calm demeanor. They are relatively easy to care for, requiring a secure enclosure with proper heat and humidity. Corn Snakes are great for both novice and experienced reptile keepers.", Price = 200.00m, StockQuantity = 5, CategoryId = 5, ImageUrl = "/uploads/corn-snake20240812190538.jpg" },
                new Product { ProductId = 45, Name = "Ball Python", Description = "The Ball Python is a small to medium-sized python native to West Africa, recognized for its shy nature and distinctive ball-like coiling behavior when threatened. They are relatively easy to care for, with a habitat that needs proper temperature gradients and humidity. Ball Pythons come in a variety of color morphs, which can affect their price.", Price = 500.00m, StockQuantity = 40, CategoryId = 5, ImageUrl = "/uploads/Ball-python20240812190656.jpg" },
                new Product { ProductId = 46, Name = "Hamster", Description = "Hamsters are small, nocturnal rodents known for their playful and curious nature. They are easy to care for and typically live in cages with bedding, food, and water. There are several breeds, including Syrian, Dwarf, and Roborovski hamsters.", Price = 250.00m, StockQuantity = 7, CategoryId = 6, ImageUrl = "/uploads/Hamster20240812191153.jpg" },
                new Product { ProductId = 47, Name = "Guinea Pig (Cavy)", Description = "Guinea pigs, or cavies, are social, gentle rodents that thrive in pairs or groups. They have a longer lifespan than hamsters and require a larger cage with plenty of space to roam. They also need a diet rich in hay, vegetables, and specially formulated pellets.", Price = 150.00m, StockQuantity = 4, CategoryId = 6, ImageUrl = "/uploads/guinea pig20240812191035.jpg" }
            );
        }
    }
}
