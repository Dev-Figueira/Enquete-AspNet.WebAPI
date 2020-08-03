using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PollIO.Business.Interfaces;
using PollIO.Business.Models;
using PollIO.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PollIO.Data.Repository
{
    public class PollRepository : Repository<Poll>, IPollRepository
    {
        public PollRepository(PollDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Poll>> GetPollAndOptions()
        {
            return await Db.Polls.AsNoTracking()
                .Include(o => o.Options).ToListAsync();
        }

        public async Task<Poll> GetPollAndOptions(int id)
        {
            return await Db.Polls.AsNoTracking()
                .Include(o => o.Options)
                .FirstOrDefaultAsync(o=> o.Id == id);
        }

        public IEnumerable<object> GetPollViews(int id)
        {
            var poll = GetPollAndOptions(id);

            if (poll == null) return null;

            var pollDto = new
            {
                poll.Result.Views
            };

            string jsonPoll = JsonConvert.SerializeObject(pollDto);
            JObject jPoll = JObject.Parse(jsonPoll);

            var options = poll.Result.Options.OrderBy(x => x.PollId).Select(p => new
            {
                option_id = p.PollId,
                qty = p.Votes ?? "0",
            });

            string jsonOptions = JsonConvert.SerializeObject(options);

            JArray jOptions = JArray.Parse(jsonOptions);

            jPoll.Add("options", jOptions);

            return jPoll;
        }
    }
}
