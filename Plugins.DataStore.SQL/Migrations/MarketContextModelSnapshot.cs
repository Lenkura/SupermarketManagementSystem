// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Plugins.DataStore.SQL;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    [DbContext(typeof(MarketContext))]
    partial class MarketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoreBusiness.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            Description = "Beverage",
                            Name = "Beverage"
                        },
                        new
                        {
                            CategoryID = 2,
                            Description = "Bakery",
                            Name = "Bakery"
                        },
                        new
                        {
                            CategoryID = 3,
                            Description = "Meat",
                            Name = "Meat"
                        });
                });

            modelBuilder.Entity("CoreBusiness.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<int?>("CategoryID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryID = 1,
                            Name = "Iced Tea",
                            Price = 1.99,
                            Quantity = 100
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryID = 1,
                            Name = "Ginger Ale",
                            Price = 4.9900000000000002,
                            Quantity = 200
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryID = 2,
                            Name = "Wholemeal Bread",
                            Price = 2.0,
                            Quantity = 300
                        },
                        new
                        {
                            ProductID = 4,
                            CategoryID = 2,
                            Name = "White Bread",
                            Price = 1.0,
                            Quantity = 300
                        },
                        new
                        {
                            ProductID = 5,
                            CategoryID = 3,
                            Name = "Lamb",
                            Price = 15.0,
                            Quantity = 25
                        },
                        new
                        {
                            ProductID = 6,
                            CategoryID = 3,
                            Name = "Beef",
                            Price = 9.5,
                            Quantity = 50
                        });
                });

            modelBuilder.Entity("CoreBusiness.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionID"));

                    b.Property<string>("CashierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("PriorQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoldQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionID");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("CoreBusiness.Product", b =>
                {
                    b.HasOne("CoreBusiness.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CoreBusiness.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
