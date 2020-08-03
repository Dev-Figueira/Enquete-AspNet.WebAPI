using PollIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace PollIO.Business.Interfaces
{
    public interface IPollService : IDisposable
    {
        Task<Poll> Adicionar(Poll poll);
        Task<bool> Atualizar(Poll fornecedor);
        Task<bool> Remover(int id);
        Task<bool> Vote(int id, OptionsPoll option);
    }
}
