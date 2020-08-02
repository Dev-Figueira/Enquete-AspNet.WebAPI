using System;
using System.Collections.Generic;
using System.Text;

namespace PollIO.Business.Models
{
    public class OptionsPoll : Entity
    {
        public Guid PollId { get; set; }
        public string Description { get; set; }

        public string Votes { get; set; }

        /* EF Relations */
        public Poll Poll { get; set; }
    }
}
