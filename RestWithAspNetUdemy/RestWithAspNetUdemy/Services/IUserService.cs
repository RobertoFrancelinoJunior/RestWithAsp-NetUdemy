using RestWithAspNetUdemy.Model;

namespace RestWithAspNetUdemy.Services
{
    public interface IUserService
    {
        object FindByLogin(User user);
    }
}