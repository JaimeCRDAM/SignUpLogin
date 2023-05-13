﻿using Cassandra;
using System;
using System.Linq.Expressions;
using GenericTools.Database;
using Cassandra.Data.Linq;
using Cassandra.Mapping;
using SignUpLogin.Models;

namespace SignUpLogin.Repositories
{
    public class SingUpLoginRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private Cluster _cluster;
        private Cassandra.ISession _session;
        private Table<T> _table;
        private IMapper _mapper;

        public SingUpLoginRepository(CassandraBuilder cassandraBuild)
        {
            _cluster = cassandraBuild.myCluster;
            _session = _cluster.Connect("sign_up");
            _mapper = new Mapper(_session);
            // Try to retrieve the table 
            _table = new Table<T>(_session);
            _table.CreateIfNotExists();
            
        }

        public void Add(T entity)
        {
            _table.Insert(entity).Execute();
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _table.Where(predicate).AllowFiltering().Execute();
        }

        public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
