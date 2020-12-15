using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Data.Database
{
    public class PeopleDbContext : DbContext
    {
        //ctor
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {

        }

        public DbSet<Person> PeopleList { get; set; }
    }
}
