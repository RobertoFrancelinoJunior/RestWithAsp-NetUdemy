using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Model.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext() { }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        public DbSet<Person> Person { get; set; }
        public DbSet<Book> Book { get; set; }
    }
}
