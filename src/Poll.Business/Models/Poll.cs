using System.Collections.Generic;

namespace PollIO.Business.Models
{
    public class Poll : Entity
    {
        public string Poll_description { get; set; }

        public string Views { get; set; }

        /* EF Relations */
        public IEnumerable<OptionsPoll> Options { get; set; }
    }
}
