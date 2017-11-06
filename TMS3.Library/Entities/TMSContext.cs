using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMS3.Library.Entities
{
    public class TMSContext:DbContext
    {
       public TMSContext(DbContextOptions<TMSContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
