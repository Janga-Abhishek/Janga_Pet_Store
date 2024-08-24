﻿// <auto-generated />
using System;
using JangaPetStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JangaPetStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240821212407_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JangaPetStore.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("JangaPetStore.Models.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartItemId"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CartItemId");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("JangaPetStore.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Dogs"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Cats"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Birds"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Fish"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Reptiles"
                        },
                        new
                        {
                            CategoryId = 6,
                            Name = "Small Animals"
                        },
                        new
                        {
                            CategoryId = 7,
                            Name = "Pet Supplies"
                        },
                        new
                        {
                            CategoryId = 8,
                            Name = "Pet Food"
                        });
                });

            modelBuilder.Entity("JangaPetStore.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("JangaPetStore.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("JangaPetStore.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 30,
                            CategoryId = 1,
                            Description = "A graceful dog with erect ears and a dense soft coat, the Siberian Husky stands 20 to 24 inches (51 to 61 cm) tall at the withers and weighs 35 to 60 pounds (16 to 27 kg). It is usually gray, tan, or black and white, and it may have head markings resembling a cap, a mask, or spectacles.",
                            ImageUrl = "/uploads/Husky20240812182712.webp",
                            Name = "Siberian Husky",
                            Price = 123.00m,
                            StockQuantity = 123
                        },
                        new
                        {
                            ProductId = 31,
                            CategoryId = 1,
                            Description = "Rottweiler, breed of working dog that is thought to be descended from drover dogs (cattle-driving dogs) left by the Roman legions in the vicinity of what is now Rottweil, Germany, after the Romans abandoned the region during the 2nd century CE. From the Middle Ages to about 1900 the Rottweiler accompanied local butchers on buying expeditions, carrying money in a neck pouch to market. It has also served as a guard dog, a drover’s dog, a draft dog, a rescue dog, and a police dog.",
                            ImageUrl = "/uploads/Rottweiler20240812182905.webp",
                            Name = "Rottweiler",
                            Price = 2500.00m,
                            StockQuantity = 20
                        },
                        new
                        {
                            ProductId = 32,
                            CategoryId = 1,
                            Description = "A regal-looking white spitz breed, the Samoyed is a medium-to-large dog that is white from head to toe. The thick, fluffy nature of the coat makes perfect sense when considering that this dog breed originated in Siberia. The indigenous Samoyed people used these strong and cold weather-tolerant dogs to herd reindeer, pull sleds, and hunt. The Samoyed has a tail that curls up over its back and a thick ruff of fur around its neck. Though these dogs are generally an all-white breed, some mature into a cream or biscuit-colored coat. Life with this white dog breed means a flurry of fur year-round. While these dogs shed their undercoat seasonally, white hair is likely to be found on your clothes and furniture year-round.\r\nGROUP: Working (AKC)\r\n\r\nHEIGHT: 19 to 24 inches\r\n\r\nWEIGHT: 35 to 65 pounds\r\n\r\nCOAT AND COLOR: Thick double coat; colors include white, cream, and biscuit\r\n\r\nLIFE EXPECTANCY: 12 to 14 years",
                            ImageUrl = "/uploads/samoyed20240812183532.jpg",
                            Name = "Samoyed",
                            Price = 2000.00m,
                            StockQuantity = 10
                        },
                        new
                        {
                            ProductId = 33,
                            CategoryId = 2,
                            Description = "The British Shorthair is the pedigreed version of the traditional British domestic cat, with a distinctively stocky body, thick coat, and broad face. The most familiar colour variant is the \"British Blue\", with a solid grey-blue coat, pineapple eyes, and a medium-sized tail. The breed has also been developed in a wide range of other colours and patterns, including tabby and colourpoint.",
                            ImageUrl = "/uploads/British Shorthair20240812183939.jpg",
                            Name = "British Shorthair",
                            Price = 2300.00m,
                            StockQuantity = 23
                        },
                        new
                        {
                            ProductId = 34,
                            CategoryId = 2,
                            Description = "With their snub noses, chubby cheeks, and long hair, the Persian cat is quite an exquisite breed. Theyre also typically quiet and affectionate cats who enjoy being held, but theyre content just lounging around too. They make a perfect, purring lap warmer!",
                            ImageUrl = "/uploads/persian20240812184236.jpg",
                            Name = "Persian",
                            Price = 2500.00m,
                            StockQuantity = 2
                        },
                        new
                        {
                            ProductId = 35,
                            CategoryId = 2,
                            Description = "The sphynx cat is an energetic, acrobatic performer who loves to show off for attention. She has an unexpected sense of humor that is often at odds with her dour expression.\r\n\r\nFriendly and loving, this is a loyal breed who will follow you around the house and try to involve herself in whatever youre doing, grabbing any opportunity to perch on your shoulder or curl up in your lap. As curious and intelligent as she is energetic, these traits can make her a bit of a handful. For her own safety, the sphynx does best as an exclusively indoor cat, and generally gets along well with children other pets.",
                            ImageUrl = "/uploads/Sphynx20240812184507.jpg",
                            Name = "Sphynx",
                            Price = 3000.00m,
                            StockQuantity = 32
                        },
                        new
                        {
                            ProductId = 36,
                            CategoryId = 3,
                            Description = "The Hyacinth Macaw is the largest of the parrot species, with striking deep blue feathers and a distinctive yellow ring around its eyes. Native to Brazil, it is known for its intelligence, playful behavior, and ability to mimic human speech.",
                            ImageUrl = "/uploads/Macaw20240812184930.jpg",
                            Name = "Hyacinth Macaw",
                            Price = 12000.00m,
                            StockQuantity = 12
                        },
                        new
                        {
                            ProductId = 37,
                            CategoryId = 3,
                            Description = "The Scarlet Macaw is renowned for its vibrant red, yellow, and blue plumage. Native to Central and South America, these birds are highly sought after for their beauty and engaging personalities. They are also known for their loud, raucous calls.",
                            ImageUrl = "/uploads/Scarlet Macaw20240812185142.jpg",
                            Name = "Scarlet Macaw",
                            Price = 17500.00m,
                            StockQuantity = 12
                        },
                        new
                        {
                            ProductId = 38,
                            CategoryId = 3,
                            Description = "Known for its exceptional intelligence and ability to mimic human speech, the African Grey Parrot is a medium-sized parrot with predominantly grey feathers and a bright red tail. It is highly prized for its cognitive abilities and its capability to build strong bonds with its owners.",
                            ImageUrl = "/uploads/african_grey_20240812185334.jpg",
                            Name = "African Grey Parrot",
                            Price = 18000.00m,
                            StockQuantity = 2
                        },
                        new
                        {
                            ProductId = 40,
                            CategoryId = 4,
                            Description = "The Asian Arowana, also known as the Dragon Fish, is highly prized for its stunning appearance, with its metallic sheen and elongated body. It is native to Southeast Asia and is often considered a symbol of good luck and prosperity. It requires a large tank due to its size and is known for its impressive jumping ability.",
                            ImageUrl = "/uploads/Arowana20240812185720.jpg",
                            Name = "Arowana (Asian Arowana)",
                            Price = 30000.00m,
                            StockQuantity = 2
                        },
                        new
                        {
                            ProductId = 41,
                            CategoryId = 4,
                            Description = "Koi are ornamental varieties of the common carp and are celebrated for their bright, vibrant colors and intricate patterns. Originating from Japan, high-quality Koi can have unique colorations and patterns, making them highly sought after by collectors. They are often kept in outdoor ponds but can also be maintained in large aquariums.",
                            ImageUrl = "/uploads/Koi20240812190004.jpg",
                            Name = "Koi Fish (Koi Carp)",
                            Price = 7000.00m,
                            StockQuantity = 45
                        },
                        new
                        {
                            ProductId = 42,
                            CategoryId = 4,
                            Description = "The Emperor Angelfish is a strikingly beautiful fish found in the Indo-Pacific region, known for its vibrant blue and yellow stripes and regal appearance. It is a popular choice for saltwater aquariums but requires a spacious tank and specific care due to its size and dietary needs.",
                            ImageUrl = "/uploads/pomacanthus20240812190212.jpg",
                            Name = "Pomacanthus (Emperor Angelfish)",
                            Price = 2500.00m,
                            StockQuantity = 5
                        },
                        new
                        {
                            ProductId = 43,
                            CategoryId = 5,
                            Description = "The Bearded Dragon is a friendly and hardy lizard native to Australia. It gets its name from the spiky \"beard\" of scales around its throat. Bearded Dragons are known for their docile nature and interactive behavior, making them a favorite among reptile enthusiasts.\\r\\n",
                            ImageUrl = "/uploads/bearded-dragon-on-sand20240812190441.jpg",
                            Name = "Bearded Dragon",
                            Price = 125.00m,
                            StockQuantity = 200
                        },
                        new
                        {
                            ProductId = 44,
                            CategoryId = 5,
                            Description = "The Corn Snake is a non-venomous snake native to North America, known for its vibrant coloration and calm demeanor. They are relatively easy to care for, requiring a secure enclosure with proper heat and humidity. Corn Snakes are great for both novice and experienced reptile keepers.",
                            ImageUrl = "/uploads/corn-snake20240812190538.jpg",
                            Name = "Corn Snake",
                            Price = 200.00m,
                            StockQuantity = 5
                        },
                        new
                        {
                            ProductId = 45,
                            CategoryId = 5,
                            Description = "The Ball Python is a small to medium-sized python native to West Africa, recognized for its shy nature and distinctive ball-like coiling behavior when threatened. They are relatively easy to care for, with a habitat that needs proper temperature gradients and humidity. Ball Pythons come in a variety of color morphs, which can affect their price.",
                            ImageUrl = "/uploads/Ball-python20240812190656.jpg",
                            Name = "Ball Python",
                            Price = 500.00m,
                            StockQuantity = 40
                        },
                        new
                        {
                            ProductId = 46,
                            CategoryId = 6,
                            Description = "Hamsters are small, nocturnal rodents known for their playful and curious nature. They are easy to care for and typically live in cages with bedding, food, and water. There are several breeds, including Syrian, Dwarf, and Roborovski hamsters.",
                            ImageUrl = "/uploads/Hamster20240812191153.jpg",
                            Name = "Hamster",
                            Price = 250.00m,
                            StockQuantity = 7
                        },
                        new
                        {
                            ProductId = 47,
                            CategoryId = 6,
                            Description = "Guinea pigs, or cavies, are social, gentle rodents that thrive in pairs or groups. They have a longer lifespan than hamsters and require a larger cage with plenty of space to roam. They also need a diet rich in hay, vegetables, and specially formulated pellets.",
                            ImageUrl = "/uploads/guinea pig20240812191035.jpg",
                            Name = "Guinea Pig (Cavy)",
                            Price = 150.00m,
                            StockQuantity = 4
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "c0ecce02-62d2-47f5-8624-c961703db3e7",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "9442c999-b72a-4a6e-8ea1-087efc0004fa",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a2039aff-8b89-46b2-a054-3955c44f90e5",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEEg19Wne0WmyITAbnvZ7TOu0hsyL8++0SWfZFC/oZ0549cLO7pbKECV6pD3fCsEpFw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d88a77f6-1dfe-41cc-a99a-f75b1a2a4de7",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9c2c1e97-20e4-46ec-af8e-9bac0026a28e",
                            Email = "abhishek@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ABHISHEK@EXAMPLE.COM",
                            NormalizedUserName = "ABHISHEK",
                            PasswordHash = "AQAAAAEAACcQAAAAELA9g9pDi9ZqZgds/MJEHFLTuXbjVCsDnAMLuCKloHNFdiFPwCzdaFJCU/+XKGJRcg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8240bb68-67ef-41fa-8084-b6f509c7f363",
                            TwoFactorEnabled = false,
                            UserName = "Abhishek"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            RoleId = "1"
                        },
                        new
                        {
                            UserId = "2",
                            RoleId = "2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("JangaPetStore.Models.CartItem", b =>
                {
                    b.HasOne("JangaPetStore.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JangaPetStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("JangaPetStore.Models.OrderItem", b =>
                {
                    b.HasOne("JangaPetStore.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JangaPetStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("JangaPetStore.Models.Product", b =>
                {
                    b.HasOne("JangaPetStore.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JangaPetStore.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("JangaPetStore.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("JangaPetStore.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
