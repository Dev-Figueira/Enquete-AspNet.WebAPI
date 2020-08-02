using PollIO.Business.Interfaces;
using PollIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PollIO.Data.Repository
{
    public class PollRepository : Repository<Poll>, IPollRepository
    {
        public Task Add(Poll entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Poll>> Find(Expression<Func<Poll, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Poll>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Poll> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Poll> GetPollOptions(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Poll> GetPollViews(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task Update(Poll entity)
        {
            throw new NotImplementedException();
        }
    }
}
