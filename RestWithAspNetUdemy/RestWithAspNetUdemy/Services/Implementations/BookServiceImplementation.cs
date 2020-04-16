using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Model.Context;
using RestWithAspNetUdemy.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithAspNetUdemy.Services.Implementations
{
    public class BookServiceImplementation : IBookService
    {
        private IRepository<Book> repository;

        public BookServiceImplementation(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        List<Book> IBookService.FindAll()
        {
            return repository.FindAll();
        }

        Book IBookService.FindById(long id)
        {
            return repository.FindById(id);
        }

        Book IBookService.Create(Book book)
        {
            return repository.Create(book);
        }

        Book IBookService.Update(Book book)
        {
            return repository.Update(book);
        }

        void IBookService.Delete(long id)
        {
            repository.Delete(id);
        }
    }
}