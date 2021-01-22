using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcViewModels.Model.Data;
using MvcViewModels.Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Database
{
    public class IdentityPersonDbContext : IdentityDbContext<AppUser>
    {

        public IdentityPersonDbContext(DbContextOptions<IdentityPersonDbContext> options) : base(options) { }

        public DbSet<Person> PeopleList { get; set; }

        public DbSet<Country> CountrieList { get; set; }

        public DbSet<City> CityList { get; set; }

        public DbSet<PersonLanguage> PersonLanguages { get; set; }
        public DbSet<Language> LanguagesList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//tells EF how to work with the many-to-many
        {
            base.OnModelCreating(modelBuilder);

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

