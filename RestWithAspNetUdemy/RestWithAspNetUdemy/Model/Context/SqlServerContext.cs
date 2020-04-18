using Microsoft.EntityFrameworkCore;

namespace RestWithAspNetUdemy.Model.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext() { }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        public DbSet<Person> Person { get; set; }

        public DbSet<Book> Book { get; set; }

        public DbSet<User> User { get; set; }

    }
}
