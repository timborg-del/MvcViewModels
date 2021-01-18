using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcViewModels.Model.Data;


namespace MvcViewModels.Model.Data.Database
{
    public class RegistryDbContext : DbContext
    {
        //ctor
        public RegistryDbContext(DbContextOptions<RegistryDbContext> options) : base(options)
        {

        }

        public DbSet<Person> PeopleList { get; set; }

        public DbSet<Country> CountrieList { get; set; }

        public DbSet<City> CityList { get; set; }

        public DbSet<PersonLanguage> PersonLanguages { get; set; }
        public DbSet<Language> LanguagesList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//tells EF how to work with the many-to-many
        {
            modelBuilder.Entity<PersonLanguage>()
                .HasKey(pl => new { pl.PersonId, pl.LanguageID });

            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Person)
                .WithMany(p => p.Languages)
                .HasForeignKey(pl => pl.PersonId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Language)
                .WithMany(l => l.Persons)
                .HasForeignKey(pl => pl.LanguageID);


        }
    }
}
