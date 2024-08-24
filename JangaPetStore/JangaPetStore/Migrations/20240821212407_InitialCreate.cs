using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JangaPetStore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "c0ecce02-62d2-47f5-8624-c961703db3e7", "Admin", "ADMIN" },
                    { "2", "9442c999-b72a-4a6e-8ea1-087efc0004fa", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "a2039aff-8b89-46b2-a054-3955c44f90e5", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEEg19Wne0WmyITAbnvZ7TOu0hsyL8++0SWfZFC/oZ0549cLO7pbKECV6pD3fCsEpFw==", null, false, "d88a77f6-1dfe-41cc-a99a-f75b1a2a4de7", false, "admin" },
                    { "2", 0, "9c2c1e97-20e4-46ec-af8e-9bac0026a28e", "abhishek@example.com", true, false, null, "ABHISHEK@EXAMPLE.COM", "ABHISHEK", "AQAAAAEAACcQAAAAELA9g9pDi9ZqZgds/MJEHFLTuXbjVCsDnAMLuCKloHNFdiFPwCzdaFJCU/+XKGJRcg==", null, false, "8240bb68-67ef-41fa-8084-b6f509c7f363", false, "Abhishek" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Dogs" },
                    { 2, "Cats" },
                    { 3, "Birds" },
                    { 4, "Fish" },
                    { 5, "Reptiles" },
                    { 6, "Small Animals" },
                    { 7, "Pet Supplies" },
                    { 8, "Pet Food" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 30, 1, "A graceful dog with erect ears and a dense soft coat, the Siberian Husky stands 20 to 24 inches (51 to 61 cm) tall at the withers and weighs 35 to 60 pounds (16 to 27 kg). It is usually gray, tan, or black and white, and it may have head markings resembling a cap, a mask, or spectacles.", "/uploads/Husky20240812182712.webp", "Siberian Husky", 123.00m, 123 },
                    { 31, 1, "Rottweiler, breed of working dog that is thought to be descended from drover dogs (cattle-driving dogs) left by the Roman legions in the vicinity of what is now Rottweil, Germany, after the Romans abandoned the region during the 2nd century CE. From the Middle Ages to about 1900 the Rottweiler accompanied local butchers on buying expeditions, carrying money in a neck pouch to market. It has also served as a guard dog, a drover’s dog, a draft dog, a rescue dog, and a police dog.", "/uploads/Rottweiler20240812182905.webp", "Rottweiler", 2500.00m, 20 },
                    { 32, 1, "A regal-looking white spitz breed, the Samoyed is a medium-to-large dog that is white from head to toe. The thick, fluffy nature of the coat makes perfect sense when considering that this dog breed originated in Siberia. The indigenous Samoyed people used these strong and cold weather-tolerant dogs to herd reindeer, pull sleds, and hunt. The Samoyed has a tail that curls up over its back and a thick ruff of fur around its neck. Though these dogs are generally an all-white breed, some mature into a cream or biscuit-colored coat. Life with this white dog breed means a flurry of fur year-round. While these dogs shed their undercoat seasonally, white hair is likely to be found on your clothes and furniture year-round.\r\nGROUP: Working (AKC)\r\n\r\nHEIGHT: 19 to 24 inches\r\n\r\nWEIGHT: 35 to 65 pounds\r\n\r\nCOAT AND COLOR: Thick double coat; colors include white, cream, and biscuit\r\n\r\nLIFE EXPECTANCY: 12 to 14 years", "/uploads/samoyed20240812183532.jpg", "Samoyed", 2000.00m, 10 },
                    { 33, 2, "The British Shorthair is the pedigreed version of the traditional British domestic cat, with a distinctively stocky body, thick coat, and broad face. The most familiar colour variant is the \"British Blue\", with a solid grey-blue coat, pineapple eyes, and a medium-sized tail. The breed has also been developed in a wide range of other colours and patterns, including tabby and colourpoint.", "/uploads/British Shorthair20240812183939.jpg", "British Shorthair", 2300.00m, 23 },
                    { 34, 2, "With their snub noses, chubby cheeks, and long hair, the Persian cat is quite an exquisite breed. Theyre also typically quiet and affectionate cats who enjoy being held, but theyre content just lounging around too. They make a perfect, purring lap warmer!", "/uploads/persian20240812184236.jpg", "Persian", 2500.00m, 2 },
                    { 35, 2, "The sphynx cat is an energetic, acrobatic performer who loves to show off for attention. She has an unexpected sense of humor that is often at odds with her dour expression.\r\n\r\nFriendly and loving, this is a loyal breed who will follow you around the house and try to involve herself in whatever youre doing, grabbing any opportunity to perch on your shoulder or curl up in your lap. As curious and intelligent as she is energetic, these traits can make her a bit of a handful. For her own safety, the sphynx does best as an exclusively indoor cat, and generally gets along well with children other pets.", "/uploads/Sphynx20240812184507.jpg", "Sphynx", 3000.00m, 32 },
                    { 36, 3, "The Hyacinth Macaw is the largest of the parrot species, with striking deep blue feathers and a distinctive yellow ring around its eyes. Native to Brazil, it is known for its intelligence, playful behavior, and ability to mimic human speech.", "/uploads/Macaw20240812184930.jpg", "Hyacinth Macaw", 12000.00m, 12 },
                    { 37, 3, "The Scarlet Macaw is renowned for its vibrant red, yellow, and blue plumage. Native to Central and South America, these birds are highly sought after for their beauty and engaging personalities. They are also known for their loud, raucous calls.", "/uploads/Scarlet Macaw20240812185142.jpg", "Scarlet Macaw", 17500.00m, 12 },
                    { 38, 3, "Known for its exceptional intelligence and ability to mimic human speech, the African Grey Parrot is a medium-sized parrot with predominantly grey feathers and a bright red tail. It is highly prized for its cognitive abilities and its capability to build strong bonds with its owners.", "/uploads/african_grey_20240812185334.jpg", "African Grey Parrot", 18000.00m, 2 },
                    { 40, 4, "The Asian Arowana, also known as the Dragon Fish, is highly prized for its stunning appearance, with its metallic sheen and elongated body. It is native to Southeast Asia and is often considered a symbol of good luck and prosperity. It requires a large tank due to its size and is known for its impressive jumping ability.", "/uploads/Arowana20240812185720.jpg", "Arowana (Asian Arowana)", 30000.00m, 2 },
                    { 41, 4, "Koi are ornamental varieties of the common carp and are celebrated for their bright, vibrant colors and intricate patterns. Originating from Japan, high-quality Koi can have unique colorations and patterns, making them highly sought after by collectors. They are often kept in outdoor ponds but can also be maintained in large aquariums.", "/uploads/Koi20240812190004.jpg", "Koi Fish (Koi Carp)", 7000.00m, 45 },
                    { 42, 4, "The Emperor Angelfish is a strikingly beautiful fish found in the Indo-Pacific region, known for its vibrant blue and yellow stripes and regal appearance. It is a popular choice for saltwater aquariums but requires a spacious tank and specific care due to its size and dietary needs.", "/uploads/pomacanthus20240812190212.jpg", "Pomacanthus (Emperor Angelfish)", 2500.00m, 5 },
                    { 43, 5, "The Bearded Dragon is a friendly and hardy lizard native to Australia. It gets its name from the spiky \"beard\" of scales around its throat. Bearded Dragons are known for their docile nature and interactive behavior, making them a favorite among reptile enthusiasts.\\r\\n", "/uploads/bearded-dragon-on-sand20240812190441.jpg", "Bearded Dragon", 125.00m, 200 },
                    { 44, 5, "The Corn Snake is a non-venomous snake native to North America, known for its vibrant coloration and calm demeanor. They are relatively easy to care for, requiring a secure enclosure with proper heat and humidity. Corn Snakes are great for both novice and experienced reptile keepers.", "/uploads/corn-snake20240812190538.jpg", "Corn Snake", 200.00m, 5 },
                    { 45, 5, "The Ball Python is a small to medium-sized python native to West Africa, recognized for its shy nature and distinctive ball-like coiling behavior when threatened. They are relatively easy to care for, with a habitat that needs proper temperature gradients and humidity. Ball Pythons come in a variety of color morphs, which can affect their price.", "/uploads/Ball-python20240812190656.jpg", "Ball Python", 500.00m, 40 },
                    { 46, 6, "Hamsters are small, nocturnal rodents known for their playful and curious nature. They are easy to care for and typically live in cages with bedding, food, and water. There are several breeds, including Syrian, Dwarf, and Roborovski hamsters.", "/uploads/Hamster20240812191153.jpg", "Hamster", 250.00m, 7 },
                    { 47, 6, "Guinea pigs, or cavies, are social, gentle rodents that thrive in pairs or groups. They have a longer lifespan than hamsters and require a larger cage with plenty of space to roam. They also need a diet rich in hay, vegetables, and specially formulated pellets.", "/uploads/guinea pig20240812191035.jpg", "Guinea Pig (Cavy)", 150.00m, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
