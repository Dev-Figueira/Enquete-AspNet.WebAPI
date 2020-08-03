using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PollIO.Api.ViewModels
{
    public class OptionPollDto
    {
        public int Id { get; set; }

        [DisplayName("Opções da Enquete")]
        public string Description { get; set; }

        public string Votes { get; set; }
    }
}
