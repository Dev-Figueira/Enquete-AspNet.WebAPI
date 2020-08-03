using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PollIO.Api.ViewModels;
using PollIO.Business.Interfaces;
using PollIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PollIO.Api.Controllers
{
    [Route("api/poll")]
    [ApiController]
    public class PollController : MainController
    {
        private readonly IPollRepository _pollRepository;
        private readonly IMapper _mapper;
        private readonly IPollService _pollService;

        public PollController(IPollRepository pollRepository,
                               IMapper mapper,
                               IPollService pollService,
                               INotificador notificador) :base(notificador)
        {
            _pollRepository = pollRepository;
            _mapper = mapper;
            _pollService = pollService;
        }

        [HttpGet]
        public async Task<IEnumerable<PollDto>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<PollDto>>(await _pollRepository.GetPollAndOptions());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PollDto>> ObterPorId(int id)
        {
            var poll = await ObterPollAndOptions(id);

            if (poll == null) return NotFound();

            return poll;
        }

        [HttpPost]
        public async Task<ActionResult<PollDto>> Adicionar(PollDto pollViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var pollAtualizada = await _pollService.Adicionar(_mapper.Map<Business.Models.Poll>(pollViewModel));
            return CustomResponse(_mapper.Map<PollDto>(pollAtualizada).Id);
        }

        [HttpPost("{id}/vote")]
        public async Task<ActionResult<PollDto>> AdicionarVoto(int id, OptionPollDto options)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pollService.Vote(id, _mapper.Map<OptionsPoll>(options));

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PollDto>> Atualizar(int id, PollDto pollViewModel)
        {
            if (id != pollViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na chamada");
                return CustomResponse(pollViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pollService.Atualizar(_mapper.Map<Business.Models.Poll>(pollViewModel));

            return CustomResponse(pollViewModel);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PollDto>> Excluir(int id)
        {
            var pollViewModel = await _pollRepository.GetById(id);

            if (pollViewModel == null) return NotFound();

            await _pollService.Remover(id);

            return CustomResponse(pollViewModel);
        }

        [Route("{id:int}/stats")]
        public ActionResult<PollDto> RetornaEstatistica(int id)
        {
            var estastistica = _pollRepository.GetPollViews(id);

            if (estastistica == null) return NotFound();

            return Ok(estastistica);
        }

        private async Task<PollDto> ObterPollAndOptions(int id)
        {
            var poll = (await _pollRepository.GetPollAndOptions(id));

            if (poll == null) return null;

            var views = Convert.ToInt32(poll.Views);
            views++;

            poll.Views = views.ToString();
            await _pollService.Atualizar(_mapper.Map<Business.Models.Poll>(poll));

            return _mapper.Map<PollDto>(await _pollRepository.GetPollAndOptions(id)); ;
        }

        

    }
}
