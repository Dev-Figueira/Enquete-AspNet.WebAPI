using PollIO.Business.Interfaces;
using PollIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollIO.Test
{
    class PollServiceFake : IPollService
    {
        private readonly IList<Business.Models.Poll> _poll;

        public PollServiceFake()
        {
            _poll = new List<Business.Models.Poll>()
            {
                new Business.Models.Poll
                {
                    Id = 1,
                    Poll_description = "Testando 1",
                    Views = "2",
                    Options = new List<OptionsPoll>
                    {
                        new OptionsPoll
                        {
                            Description = "Opção 1",
                            Id = 1,
                            PollId = 1
                        }
                    }
                },
                new Business.Models.Poll
                {
                    Id = 2,
                    Poll_description = "Testando 2",
                    Views = "4",
                    Options = new List<OptionsPoll>
                    {
                        new OptionsPoll
                        {
                            Description = "Opção 2",
                            Id = 2,
                            PollId = 2
                        }
                    }
                },
                new Business.Models.Poll
                {
                    Id = 3,
                    Poll_description = "Testando 3",
                    Views = "6",
                    Options = new List<OptionsPoll>
                    {
                        new OptionsPoll
                        {
                            Description = "Opção 3",
                            Id = 3,
                            PollId = 3
                        }
                    }
                }
            };
        }

        public async Task<Business.Models.Poll> Adicionar(Business.Models.Poll pollParaAdd)
        {
            _poll.Add(pollParaAdd);
            return pollParaAdd;
        }

        public Task<bool> Atualizar(Business.Models.Poll fornecedor)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remover(int id)
        {
            var item = _poll.First(p => p.Id == id);
            _poll.Remove(item);
            return true;
        }

        public Task<bool> Vote(int id, OptionsPoll option)
        {
            throw new NotImplementedException();
        }
    }
}
