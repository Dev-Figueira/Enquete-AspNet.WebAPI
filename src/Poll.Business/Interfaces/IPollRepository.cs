using PollIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PollIO.Business.Interfaces
{
    public interface IPollRepository : IRepository<Poll>
    {
        IEnumerable<object> GetPollViews(int id);
        Task<Poll> GetPollAndOptions(int id);
        Task<IEnumerable<Poll>> GetPollAndOptions();
    }
}
