using RestWithAspNetUdemy.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RestWithAspNetUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public object InterLocked { get; private set; }

        Person IPersonService.Create(Person person)
        {
            return person;
        }

        void IPersonService.Delete(long id)
        {
        }

        List<Person> IPersonService.FindAll()
        {
            List<Person> personList = new List<Person>();

            for(int i = 0; i < 8; i++)
            {
                personList.Add(MockPerson(i));
            }

            return personList;
        }

        Person IPersonService.FindById(long id)
        {
            return new Person
            {
                 Id = 1,
                 FirstName = "Roberto",
                 LastName = "Junior",
                 Address = "Rua Settimo Giannini 600",
                 Gender = "Male"
            };
        }

        Person IPersonService.Update(Person person)
        {
            return person;
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "First Name " + i,
                LastName = "Last Name " + i,
                Address = "Same Address " + i,
                Gender = "Male"
            };
        }
    }
}