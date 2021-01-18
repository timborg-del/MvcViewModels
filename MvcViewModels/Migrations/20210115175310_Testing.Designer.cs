﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcViewModels.Model.Data.Database;

namespace MvcViewModels.Migrations
{
    [DbContext(typeof(RegistryDbContext))]
    [Migration("20210115175310_Testing")]
    partial class Testing
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcViewModels.Model.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountriesId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountriesId");

                    b.ToTable("CityList");
                });

            modelBuilder.Entity("MvcViewModels.Model.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CountrieList");
                });

            modelBuilder.Entity("MvcViewModels.Model.Data.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LanguagesList");
                });

            modelBuilder.Entity("MvcViewModels.Model.Data.PersonLanguage", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageID")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "LanguageID");

                    b.HasIndex("LanguageID");

                    b.ToTable("PersonLanguages");
                });

            modelBuilder.Entity("MvcViewModels.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("LanguageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PeopleList");
                });

            modelBuilder.Entity("MvcViewModels.Model.City", b =>
                {
                    b.HasOne("MvcViewModels.Model.Country", "Countries")
                        .WithMany("Cities")
                        .HasForeignKey("CountriesId");
                });

            modelBuilder.Entity("MvcViewModels.Model.Data.PersonLanguage", b =>
                {
                    b.HasOne("MvcViewModels.Model.Data.Language", "Language")
                        .WithMany("Persons")
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcViewModels.Model.Person", "Person")
                        .WithMany("Languages")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MvcViewModels.Model.Person", b =>
                {
                    b.HasOne("MvcViewModels.Model.City", "City")
                        .WithMany("Citiezens")
                        .HasForeignKey("CityId");

                    b.HasOne("MvcViewModels.Model.Country", "Country")
                        .WithMany("Persons")
                        .HasForeignKey("CountryId");

                    b.HasOne("MvcViewModels.Model.Data.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId");
                });
#pragma warning restore 612, 618
        }
    }
}
