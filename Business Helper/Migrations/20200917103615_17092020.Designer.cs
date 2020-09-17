﻿// <auto-generated />
using Business_Helper.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Business_Helper.Migrations
{
    [DbContext(typeof(ContextApp))]
    [Migration("20200917103615_17092020")]
    partial class _17092020
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Business_Helper.EF.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("Business_Helper.EF.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .HasColumnType("TEXT");

                    b.Property<string>("BIK")
                        .HasColumnType("TEXT");

                    b.Property<string>("BankName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CheckingAcc")
                        .HasColumnType("TEXT");

                    b.Property<string>("CorpAcc")
                        .HasColumnType("TEXT");

                    b.Property<string>("INN")
                        .HasColumnType("TEXT");

                    b.Property<string>("KPP")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sender")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Business_Helper.EF.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Unit")
                        .HasColumnType("TEXT");

                    b.Property<double>("VAT")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Business_Helper.EF.Models.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .HasColumnType("TEXT");

                    b.Property<string>("BIK")
                        .HasColumnType("TEXT");

                    b.Property<string>("BankName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CheckingAcc")
                        .HasColumnType("TEXT");

                    b.Property<string>("CorpAcc")
                        .HasColumnType("TEXT");

                    b.Property<string>("INN")
                        .HasColumnType("TEXT");

                    b.Property<string>("KPP")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sender")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("Business_Helper.EF.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });
#pragma warning restore 612, 618
        }
    }
}
