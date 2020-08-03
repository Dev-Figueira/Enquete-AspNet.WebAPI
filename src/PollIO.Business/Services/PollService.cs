using PollIO.Business.Interfaces;
using PollIO.Business.Models;
using PollIO.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollIO.Business.Services
{
    public class PollService : BaseService, IPollService
    {
        private readonly IPollRepository _pollRepository;

        public PollService(IPollRepository pollRepository,
                                 INotificador notificador) : base(notificador)
        {
            _pollRepository = pollRepository;
        }

        public async Task<Poll> Adicionar(Poll poll)
        {
            var caunt = 1;
            if (poll.Id == 0)
            {
               poll.Id = _pollRepository.GetAll().Result
                    .Count() == 0 ? 1 : _pollRepository.GetAll().Result.Count() + 1;
            }
            
            foreach (var opcao in poll.Options.ToList())
            {
                opcao.Id = caunt;
                caunt++;
            }

            if (!ExecutarValidacao(new PollValidation(), poll)) return null;

            await _pollRepository.Add(poll);
            return poll;
        }

        public async Task<bool> Atualizar(Poll poll)
        {
            if (!ExecutarValidacao(new PollValidation(), poll)) return false;

            await _pollRepository.Update(poll);
            return true;
        }    

        public async Task<bool> Vote(int id, OptionsPoll option)
        {
            if (!ExecutarValidacao(new PollOptionsValidation(), option)) return false;

            var poll = await _pollRepository.GetPollAndOptions(id);

            if (!ExecutarValidacao(new PollValidation(), poll)) return false;

            var opcao = poll.Options.FirstOrDefault(o => o.Id == option.Id);
            var votos = Convert.ToInt32(opcao.Votes);
            votos++;
            opcao.Votes = votos.ToString();

            await _pollRepository.Update(poll);

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _pollRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _pollRepository?.Dispose();
        }
    }
}
