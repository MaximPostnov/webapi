using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace NewStore.Models
{
    public partial class StoreHouseContext : IdentityDbContext<UserReg>
    {
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Classification> Classification { get; set; }
        public virtual DbSet<County> County { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderLine> OrderLine { get; set; }
        public virtual DbSet<OrderObject> OrderObject { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<UserReg> User { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=StoreHouse;Trusted_Connection=True;");
        //            }
        //        }


        public StoreHouseContext(DbContextOptions<StoreHouseContext> options)
: base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_County");
            });

            modelBuilder.Entity<Classification>(entity =>
            {
                entity.Property(e => e.ClassificationId).HasColumnName("Classification_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<County>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.CountryId).HasColumnName("Country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.ManufacturerId).HasColumnName("Manufacturer_id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Manufacturer)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manufacturer_City");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.SoldOut).HasColumnName("sold_out");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(e => e.LineId);

                entity.ToTable("Order_line");

                entity.Property(e => e.LineId).HasColumnName("Line_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.OrderLine)
                    .HasForeignKey(d => d.ObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_line_Order_object");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLine)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_line_Order");
            });

            modelBuilder.Entity<OrderObject>(entity =>
            {
                entity.HasKey(e => e.ObjectId);

                entity.ToTable("Order_object");

                entity.Property(e => e.ObjectId).HasColumnName("Object_id");

                entity.Property(e => e.Availability).HasColumnName("availability");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.OrderObject)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_object_Manufacturer");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.OrderObject)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_object_Type");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.TypeId).HasColumnName("Type_id");

                entity.Property(e => e.ClassificationId).HasColumnName("classification_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Classification)
                    .WithMany(p => p.Type)
                    .HasForeignKey(d => d.ClassificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Type_Classification");
            });

            //modelBuilder.Entity<UserReg>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("User_id");

            //    //entity.Property(e => e.)
            //    //    .HasColumnName("image")
            //    //    .HasColumnType("image");

            //    entity.Property(e => e.UserName)
            //        .IsRequired()
            //        .HasColumnName("name")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PasswordHash)
            //        .IsRequired()
            //        .HasColumnName("password")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    //entity.Property(e => e.a).HasColumnName("status_admin");
            //});
        }
    }
}
