using RestWithAspNetUdemy.Model;
using System.Collections.Generic;

namespace RestWithAspNetUdemy.Services
{
    public interface IBookService
    {
        Book Create(Book book);

        Book FindById(long id);
        
        List<Book> FindAll();

        Book Update(Book book);

        void Delete(long id);
    }
}