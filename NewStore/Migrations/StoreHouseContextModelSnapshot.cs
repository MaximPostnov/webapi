﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NewStore.Models;
using System;

namespace NewStore.Migrations
{
    [DbContext(typeof(StoreHouseContext))]
    partial class StoreHouseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("NewStore.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("City_id");

                    b.Property<int>("CountryId")
                        .HasColumnName("country_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("NewStore.Models.Classification", b =>
                {
                    b.Property<int>("ClassificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Classification_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("ClassificationId");

                    b.ToTable("Classification");
                });

            modelBuilder.Entity("NewStore.Models.County", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Country_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("CountryId");

                    b.ToTable("County");
                });

            modelBuilder.Entity("NewStore.Models.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Manufacturer_id");

                    b.Property<int>("CityId")
                        .HasColumnName("city_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("ManufacturerId");

                    b.HasIndex("CityId");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("NewStore.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Order_id");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<bool>("SoldOut")
                        .HasColumnName("sold_out");

                    b.Property<string>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("NewStore.Models.OrderLine", b =>
                {
                    b.Property<int>("LineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Line_id");

                    b.Property<int>("Amount")
                        .HasColumnName("amount");

                    b.Property<int>("ObjectId")
                        .HasColumnName("object_id");

                    b.Property<int>("OrderId")
                        .HasColumnName("order_id");

                    b.Property<double>("Price")
                        .HasColumnName("price");

                    b.HasKey("LineId");

                    b.HasIndex("ObjectId");

                    b.HasIndex("OrderId");

                    b.ToTable("Order_line");
                });

            modelBuilder.Entity("NewStore.Models.OrderObject", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Object_id");

                    b.Property<int>("Availability")
                        .HasColumnName("availability");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnName("image")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("ManufacturerId")
                        .HasColumnName("manufacturer_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<double>("Price")
                        .HasColumnName("price");

                    b.Property<int>("TypeId")
                        .HasColumnName("type_id");

                    b.HasKey("ObjectId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("TypeId");

                    b.ToTable("Order_object");
                });

            modelBuilder.Entity("NewStore.Models.Type", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Type_id");

                    b.Property<int>("ClassificationId")
                        .HasColumnName("classification_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("TypeId");

                    b.HasIndex("ClassificationId");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("NewStore.Models.UserReg", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NewStore.Models.UserReg")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NewStore.Models.UserReg")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewStore.Models.UserReg")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("NewStore.Models.UserReg")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewStore.Models.City", b =>
                {
                    b.HasOne("NewStore.Models.County", "Country")
                        .WithMany("City")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK_City_County");
                });

            modelBuilder.Entity("NewStore.Models.Manufacturer", b =>
                {
                    b.HasOne("NewStore.Models.City", "City")
                        .WithMany("Manufacturer")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_Manufacturer_City");
                });

            modelBuilder.Entity("NewStore.Models.Order", b =>
                {
                    b.HasOne("NewStore.Models.UserReg", "User")
                        .WithMany("Order")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Order_User");
                });

            modelBuilder.Entity("NewStore.Models.OrderLine", b =>
                {
                    b.HasOne("NewStore.Models.OrderObject", "Object")
                        .WithMany("OrderLine")
                        .HasForeignKey("ObjectId")
                        .HasConstraintName("FK_Order_line_Order_object");

                    b.HasOne("NewStore.Models.Order", "Order")
                        .WithMany("OrderLine")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_Order_line_Order");
                });

            modelBuilder.Entity("NewStore.Models.OrderObject", b =>
                {
                    b.HasOne("NewStore.Models.Manufacturer", "Manufacturer")
                        .WithMany("OrderObject")
                        .HasForeignKey("ManufacturerId")
                        .HasConstraintName("FK_Order_object_Manufacturer");

                    b.HasOne("NewStore.Models.Type", "Type")
                        .WithMany("OrderObject")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK_Order_object_Type");
                });

            modelBuilder.Entity("NewStore.Models.Type", b =>
                {
                    b.HasOne("NewStore.Models.Classification", "Classification")
                        .WithMany("Type")
                        .HasForeignKey("ClassificationId")
                        .HasConstraintName("FK_Type_Classification");
                });
#pragma warning restore 612, 618
        }
    }
}
