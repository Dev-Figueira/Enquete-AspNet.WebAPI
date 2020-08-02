using PollIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace PollIO.Business.Interfaces
{
    public interface IPollRepository : IRepository<Poll>
    {
        Task<Models.Poll> GetPollViews(Guid id);
        Task<Models.Poll> GetPollOptions(Guid id);
    }
}
