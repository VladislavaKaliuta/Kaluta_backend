//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Data.Sqlite;
using Kaluta_backend.Models;

namespace Kaluta_backend.Models
{
    public class universityContext : DbContext
    {
        public universityContext(DbContextOptions<universityContext> options)
        : base(options)
        {
            Database.Migrate();
        }

       

        public DbSet<Kaluta_backend.Models.group> group { get; set; }
        public DbSet<Kaluta_backend.Models.student> student { get; set; }
        public DbSet<Kaluta_backend.Models.university> university { get; set; } = default!;
        //public DbSet<Kaluta_backend.Models.User> User { get; set; } = default!;
        //public DbSet<Kaluta_back.Models.Models.Request> Request { get; set; } = default!;
    }
}
