using System.Collections.Generic;
using System.Threading.Tasks;
using CarDealer.Models.Entities;

namespace CarDealer.Repository.Clients
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();
        Task<bool> DeleteClient(int id);
        Task<Client> GetClient(int id);
        Task<bool> UpdateClient(Client client);
        Task<bool> AddClient (Client client);
    }
}