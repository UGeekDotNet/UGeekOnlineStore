﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UGeekStore.DAL;

namespace UGeekStore.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20200121132954_For my branch")]
    partial class Formybranch
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UGeekStore.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("UGeekStore.Core.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mesagge")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<DateTime>("ReadDate");

                    b.Property<int>("ReciverID");

                    b.Property<DateTime>("SendTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2020, 1, 21, 17, 29, 40, 63, DateTimeKind.Local).AddTicks(2621));

                    b.Property<int>("SenderID");

                    b.HasKey("Id");

                    b.HasIndex("ReciverID");

                    b.HasIndex("SenderID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("UGeekStore.Core.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(25)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(25)");

                    b.Property<DateTime>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2020, 1, 21, 17, 29, 40, 56, DateTimeKind.Local).AddTicks(6831));

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(25)");

                    b.Property<DateTime>("ShippedDate");

                    b.Property<int>("ShipperID");

                    b.Property<int>("UserID");

                    b.HasKey("Id");

                    b.HasIndex("ShipperID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("UGeekStore.Core.Entities.OrderDetail", b =>
                {
                    b.Property<int>("ProductID");

                    b.Property<int>("OrderID");

                    b.Property<float>("Discount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0f);

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<decimal>("UnitPrice")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0m);

                    b.HasKey("ProductID", "OrderID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("UGeekStore.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValue(new DateTime(2020, 1, 21, 0, 0, 0, 0, DateTimeKind.Local));

                    b.Property<int>("CategoryID");

                    b.Property<int>("Count")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(40)");

                    b.Property<int>("SupplierID");

                    b.Property<decimal>("UnitPrice")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0m);

                    b.Property<float>("Weight")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0f);

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.HasIndex("Name");

                    b.HasIndex("SupplierID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("UGeekStore.Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDefault")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(30)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("UGeekStore.Core.Entities.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("City")
                        .HasColumnType("NVARCHAR(25)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("Country")
                        .HasColumnType("NVARCHAR(30)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("CompanyName");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("UGeekStore.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessID");

                    b.Property<string>("Address")
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("City")
                        .HasColumnType("NVARCHAR(30)");

                    b.Property<string>("Country")
                        .HasColumnType("NVARCHAR(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(40)");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("PostalCode")
                        .HasColumnType("NVARCHAR(10)");

                    b.Property<DateTime>("RegisterDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValue(new DateTime(2020, 1, 21, 0, 0, 0, 0, DateTimeKind.Local));

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.HasAlternateKey("UserName");

                    b.HasIndex("AccessID");

                    b.HasIndex("FirstName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UGeekStore.DAL.Entities.Shipper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(12)");

                    b.Property<decimal>("Salary")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(80000m);

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.HasAlternateKey("Phone");

                    b.ToTable("Shippers");
                });

            modelBuilder.Entity("UGeekStore.Core.Entities.Message", b =>
                {
                    b.HasOne("UGeekStore.Core.Entities.User", "Reciver")
                        .WithMany("ReciversMessages")
                        .HasForeignKey("ReciverID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UGeekStore.Core.Entities.User", "Sender")
                        .WithMany("SendersMessages")
                        .HasForeignKey("SenderID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("UGeekStore.Core.Entities.Order", b =>
                {
                    b.HasOne("UGeekStore.DAL.Entities.Shipper", "Shipper")
                        .WithMany("Orders")
                        .HasForeignKey("ShipperID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UGeekStore.Core.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("UGeekStore.Core.Entities.OrderDetail", b =>
                {
                    b.HasOne("UGeekStore.Core.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UGeekStore.Core.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("UGeekStore.Core.Entities.Product", b =>
                {
                    b.HasOne("UGeekStore.Core.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UGeekStore.Core.Entities.Supplier", "Suplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("UGeekStore.Core.Entities.User", b =>
                {
                    b.HasOne("UGeekStore.Core.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("AccessID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
