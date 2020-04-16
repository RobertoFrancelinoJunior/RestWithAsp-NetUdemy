using Microsoft.EntityFrameworkCore;
using RestWithAspNetUdemy.Model.Base;
using RestWithAspNetUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNetUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private SqlServerContext sqlServerContext;

        private DbSet<T> dataSet;

        public GenericRepository(SqlServerContext sqlServerContext)
        {
            this.sqlServerContext = sqlServerContext;
            this.dataSet = sqlServerContext.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataSet.Add(item);
                sqlServerContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public void Delete(long id)
        {
            var result = dataSet.SingleOrDefault(i => i.Id.Equals(id));

            try
            {
                if (result != null) dataSet.Remove(result);
                sqlServerContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(long id)
        {
            return dataSet.Any(i => i.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T FindById(long id)
        {
            return dataSet.SingleOrDefault(i => i.Id.Equals(id));
        }

        public T Update(T item)
        {
            if(!Exists(item.Id))
            {
                return null;
            }

            var result = dataSet.SingleOrDefault(i => i.Id.Equals(item.Id));

            try
            {
                sqlServerContext.Entry(result).CurrentValues.SetValues(item);
                sqlServerContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}
