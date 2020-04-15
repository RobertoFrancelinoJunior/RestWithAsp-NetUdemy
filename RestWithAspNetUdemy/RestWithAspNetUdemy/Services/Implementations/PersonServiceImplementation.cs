using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithAspNetUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private SqlServerContext sqlServerContext;

        public PersonServiceImplementation(SqlServerContext  sqlServerContext)
        {
            this.sqlServerContext = sqlServerContext;
        }

        List<Person> IPersonService.FindAll()
        {
            return sqlServerContext.Person.ToList();
        }

        Person IPersonService.FindById(long id)
        {
            return sqlServerContext.Person.SingleOrDefault(person => person.Id.Equals(id));
        }

        Person IPersonService.Create(Person person)
        {
            try
            {
                sqlServerContext.Add(person);
                sqlServerContext.SaveChanges();
            }
            catch(Exception exception)
            {
                throw exception;
            }

            return person;
        }

        Person IPersonService.Update(Person person)
        {
            if(!Exist(person.Id))
            {
                return new Person();
            }

            var result = sqlServerContext.Person.SingleOrDefault(p => p.Id.Equals(person.Id));

            try
            {
                sqlServerContext.Entry(result).CurrentValues.SetValues(person);
                sqlServerContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return person;
        }

        void IPersonService.Delete(long id)
        {
            var result = sqlServerContext.Person.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if (result != null)
                { 
                    sqlServerContext.Person.Remove(result); 
                }
                
                sqlServerContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private bool Exist(long id)
        {
            return sqlServerContext.Person.Any(p => p.Id.Equals(id));
        }
    }
}