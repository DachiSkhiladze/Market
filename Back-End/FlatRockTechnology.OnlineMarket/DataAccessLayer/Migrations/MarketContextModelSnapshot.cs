﻿// <auto-generated />
using System;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlatRockTechnology.OnlineMarket.DataAccessLayer.Migrations
{
    [DbContext(typeof(MarketContext))]
    partial class MarketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("UserId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ImageURL");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AddressID");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.OrderProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OrderID");

                    b.Property<long>("PriceOfSingleProduct")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("ProductID");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ImageURL");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.ProductCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductID");

                    b.Property<Guid>("SubCategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SubCategoryID");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("ProductId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.SubCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CategoryID");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ImageURL");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.ToTable("SubCategory");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ID");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
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
                            Id = "08046771-00f2-421f-8815-dfbae7eaeb3a",
                            ConcurrencyStamp = "956e2895-9508-41ff-8a9f-0f1a674a0e26",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "a767f04e-719b-41b0-8e75-5ab57cb163fe",
                            ConcurrencyStamp = "77850eb3-101f-4a99-808d-3e002705a4ae",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "3095e87e-8a48-46b7-ab40-c772028e962a",
                            ConcurrencyStamp = "432052bc-d174-4640-9f77-9f2196ac1861",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Address", b =>
                {
                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "CreatedByNavigation")
                        .WithMany("AddressCreatedByNavigation")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("FK__Address__Created__3B75D760");

                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "ModifiedByNavigation")
                        .WithMany("AddressModifiedByNavigation")
                        .HasForeignKey("ModifiedBy")
                        .HasConstraintName("FK__Address__Modifie__3C69FB99");

                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "User")
                        .WithMany("AddressUser")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Address__UserID__3A81B327");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("ModifiedByNavigation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Category", b =>
                {
                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "CreatedByNavigation")
                        .WithMany("CategoryCreatedByNavigation")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("FK__Category__Create__286302EC");

                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "ModifiedByNavigation")
                        .WithMany("CategoryModifiedByNavigation")
                        .HasForeignKey("ModifiedBy")
                        .HasConstraintName("FK__Category__Modifi__29572725");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("ModifiedByNavigation");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Order", b =>
                {
                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Address", "Address")
                        .WithMany("Order")
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("FK__Order__AddressID__3F466844");

                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "CreatedByNavigation")
                        .WithMany("OrderCreatedByNavigation")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("FK__Order__CreatedBy__412EB0B6");

                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "ModifiedByNavigation")
                        .WithMany("OrderModifiedByNavigation")
                        .HasForeignKey("ModifiedBy")
                        .HasConstraintName("FK__Order__ModifiedB__4222D4EF");

                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "User")
                        .WithMany("OrderUser")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Order__UserID__403A8C7D");

                    b.Navigation("Address");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("ModifiedByNavigation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.OrderProduct", b =>
                {
                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "CreatedByNavigation")
                        .WithMany("OrderProductCreatedByNavigation")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("FK__OrderProd__Creat__45F365D3");

                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "ModifiedByNavigation")
                        .WithMany("OrderProductModifiedByNavigation")
                        .HasForeignKey("ModifiedBy")
                        .HasConstraintName("FK__OrderProd__Modif__46E78A0C");

                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Order", "Order")
                        .WithMany("OrderProduct")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK__OrderProd__Order__44FF419A");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("ModifiedByNavigation");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Product", b =>
                {
                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "CreatedByNavigation")
                        .WithMany("ProductCreatedByNavigation")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("FK__Product__Created__30F848ED");

                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "ModifiedByNavigation")
                        .WithMany("ProductModifiedByNavigation")
                        .HasForeignKey("ModifiedBy")
                        .HasConstraintName("FK__Product__Modifie__31EC6D26");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("ModifiedByNavigation");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.ProductCategory", b =>
                {
                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "CreatedByNavigation")
                        .WithMany("ProductCategoryCreatedByNavigation")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("FK__ProductCa__Creat__36B12243");

                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "ModifiedByNavigation")
                        .WithMany("ProductCategoryModifiedByNavigation")
                        .HasForeignKey("ModifiedBy")
                        .HasConstraintName("FK__ProductCa__Modif__37A5467C");

                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Product", "Product")
                        .WithMany("ProductCategory")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__ProductCa__Produ__34C8D9D1");

                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.SubCategory", "SubCategory")
                        .WithMany("ProductCategory")
                        .HasForeignKey("SubCategoryId")
                        .IsRequired()
                        .HasConstraintName("FK__ProductCa__SubCa__35BCFE0A");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("ModifiedByNavigation");

                    b.Navigation("Product");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.SubCategory", b =>
                {
                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Category", "Category")
                        .WithMany("SubCategory")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK__SubCatego__Categ__2C3393D0");

                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "CreatedByNavigation")
                        .WithMany("SubCategoryCreatedByNavigation")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("FK__SubCatego__Creat__2D27B809");

                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "ModifiedByNavigation")
                        .WithMany("SubCategoryModifiedByNavigation")
                        .HasForeignKey("ModifiedBy")
                        .HasConstraintName("FK__SubCatego__Modif__2E1BDC42");

                    b.Navigation("Category");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("ModifiedByNavigation");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", b =>
                {
                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "CreatedByNavigation")
                        .WithMany("InverseCreatedByNavigation")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("FK_Creation8");

                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", "ModifiedByNavigation")
                        .WithMany("InverseModifiedByNavigation")
                        .HasForeignKey("ModifiedBy")
                        .HasConstraintName("FK_Modification8");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("ModifiedByNavigation");
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
                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", null)
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

                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Address", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Category", b =>
                {
                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Order", b =>
                {
                    b.Navigation("OrderProduct");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Product", b =>
                {
                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.SubCategory", b =>
                {
                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.User", b =>
                {
                    b.Navigation("AddressCreatedByNavigation");

                    b.Navigation("AddressModifiedByNavigation");

                    b.Navigation("AddressUser");

                    b.Navigation("CategoryCreatedByNavigation");

                    b.Navigation("CategoryModifiedByNavigation");

                    b.Navigation("InverseCreatedByNavigation");

                    b.Navigation("InverseModifiedByNavigation");

                    b.Navigation("OrderCreatedByNavigation");

                    b.Navigation("OrderModifiedByNavigation");

                    b.Navigation("OrderProductCreatedByNavigation");

                    b.Navigation("OrderProductModifiedByNavigation");

                    b.Navigation("OrderUser");

                    b.Navigation("ProductCategoryCreatedByNavigation");

                    b.Navigation("ProductCategoryModifiedByNavigation");

                    b.Navigation("ProductCreatedByNavigation");

                    b.Navigation("ProductModifiedByNavigation");

                    b.Navigation("SubCategoryCreatedByNavigation");

                    b.Navigation("SubCategoryModifiedByNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
