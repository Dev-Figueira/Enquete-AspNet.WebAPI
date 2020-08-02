using System.Collections.Generic;

namespace PollIO.Business.Models
{
    public class Poll : Entity
    {
        public string Description { get; set; }

        public string Views { get; set; }

        /* EF Relations */
        public IEnumerable<OptionsPoll> Options { get; set; }
    }
}
