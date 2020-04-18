using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Model.Context;
using System.Linq;

namespace RestWithAspNetUdemy.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlServerContext sqlServerContext;

        public UserRepository(SqlServerContext sqlServerContext)
        {
            this.sqlServerContext = sqlServerContext;
        }

        public User FindByLogin(string login)
        {
            return sqlServerContext.User.SingleOrDefault(p => p.Login.Equals(login));
        }
    }
}