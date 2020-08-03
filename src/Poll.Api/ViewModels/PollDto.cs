using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PollIO.Api.ViewModels
{
    public class PollDto
    {
        public int Id { get; set; }

        [DisplayName("Pergunta da Enquete")]
        [Required(ErrorMessage = "Informe a Pergunta da Enquete!")]
        public string Poll_description { get; set; }

        public IEnumerable<OptionPollDto> Options { get; set; }
    }
}
