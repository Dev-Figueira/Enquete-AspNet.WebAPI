using System;

namespace PollIO.Business.Models
{
    public class OptionsPoll : Entity
    {
        public int PollId { get; set; }

        public string Description { get; set; }

        public string Votes { get; set; }

        /* EF Relations */
        public Poll Poll { get; set; }
    }
}
