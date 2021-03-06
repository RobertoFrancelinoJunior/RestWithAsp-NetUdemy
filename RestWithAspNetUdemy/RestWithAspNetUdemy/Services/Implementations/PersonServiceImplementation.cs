﻿using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Model.Context;
using RestWithAspNetUdemy.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithAspNetUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private IRepository<Person> repository;

        public PersonServiceImplementation(IRepository<Person> repository)
        {
            this.repository = repository;
        }

        List<Person> IPersonService.FindAll()
        {
            return repository.FindAll();
        }

        Person IPersonService.FindById(long id)
        {
            return repository.FindById(id);
        }

        Person IPersonService.Create(Person person)
        {
            return repository.Create(person);
        }

        Person IPersonService.Update(Person person)
        {
            return repository.Update(person);
        }

        void IPersonService.Delete(long id)
        {
            repository.Delete(id);
        }
    }
}