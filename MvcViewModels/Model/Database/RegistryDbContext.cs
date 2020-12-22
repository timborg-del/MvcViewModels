using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
    }
}
