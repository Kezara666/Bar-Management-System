﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bar_Management_System.Migrations
{
    [DbContext(typeof(BMSContext))]
    [Migration("20231213014956_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bar_Management_System.Model.InvoiceManagement.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoiceNo")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("TotalItemCount")
                        .HasColumnType("int");

                    b.Property<double>("TotalPurchasePrice")
                        .HasColumnType("float");

                    b.Property<double>("TotalSellPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("Bar_Management_System.Model.InvoiceManagement.SubUnitInvoce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<int>("Empty")
                        .HasColumnType("int");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("NotRecived")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Qnt")
                        .HasColumnType("int");

                    b.Property<double>("TotalPurchasePrice")
                        .HasColumnType("float");

                    b.Property<double>("TotalSellPrice")
                        .HasColumnType("float");

                    b.Property<double>("VAT")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductID");

                    b.ToTable("SubUnitInvoce");
                });

            modelBuilder.Entity("Bar_Management_System.Model.ProductManagement.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Bar_Management_System.Model.ProductManagement.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AlcholPresent")
                        .HasColumnType("float");

                    b.Property<int>("BarCode")
                        .HasColumnType("int");

                    b.Property<int>("BottleCount")
                        .HasColumnType("int");

                    b.Property<double>("BottleHaveMililiter")
                        .HasColumnType("float");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<double>("EmptyPrice")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductCode")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Bar_Management_System.Model.SupplierManagement.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyRegNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TelNo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Data.Model.BranchManagement.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Data.Model.UserManagement.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Data.Model.UserManagement.Window", b =>
                {
                    b.Property<int>("WindowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WindowId"));

                    b.Property<string>("WindowName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WindowId");

                    b.ToTable("Windows");
                });

            modelBuilder.Entity("UserWindow", b =>
                {
                    b.Property<int>("UserWindowsWindowId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("UserWindowsWindowId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserWindow");
                });

            modelBuilder.Entity("Bar_Management_System.Model.InvoiceManagement.Invoice", b =>
                {
                    b.HasOne("Data.Model.BranchManagement.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bar_Management_System.Model.SupplierManagement.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Bar_Management_System.Model.InvoiceManagement.SubUnitInvoce", b =>
                {
                    b.HasOne("Data.Model.BranchManagement.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bar_Management_System.Model.InvoiceManagement.Invoice", null)
                        .WithMany("SubInvoces")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("Bar_Management_System.Model.ProductManagement.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Bar_Management_System.Model.ProductManagement.Category", b =>
                {
                    b.HasOne("Data.Model.BranchManagement.Branch", "Branch")
                        .WithMany("Categories")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("Bar_Management_System.Model.ProductManagement.Product", b =>
                {
                    b.HasOne("Data.Model.BranchManagement.Branch", "Branch")
                        .WithMany("Products")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bar_Management_System.Model.ProductManagement.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bar_Management_System.Model.SupplierManagement.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Bar_Management_System.Model.SupplierManagement.Supplier", b =>
                {
                    b.HasOne("Data.Model.BranchManagement.Branch", "Branch")
                        .WithMany("Suppliers")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("Data.Model.UserManagement.User", b =>
                {
                    b.HasOne("Data.Model.BranchManagement.Branch", "Branch")
                        .WithMany("Users")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("UserWindow", b =>
                {
                    b.HasOne("Data.Model.UserManagement.Window", null)
                        .WithMany()
                        .HasForeignKey("UserWindowsWindowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Model.UserManagement.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bar_Management_System.Model.InvoiceManagement.Invoice", b =>
                {
                    b.Navigation("SubInvoces");
                });

            modelBuilder.Entity("Bar_Management_System.Model.ProductManagement.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Bar_Management_System.Model.SupplierManagement.Supplier", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Data.Model.BranchManagement.Branch", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Products");

                    b.Navigation("Suppliers");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
