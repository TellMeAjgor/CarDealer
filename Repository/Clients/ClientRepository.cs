using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CarDealer.Helper;
using CarDealer.Models.Entities;
using Dapper;

namespace CarDealer.Repository.Clients
{
    public class ClientRepository : IClientRepository
    {
        public async Task<IEnumerable<Client>> GetClients()
        {
            using (IDbConnection context = new SqlConnection(ConfigHelper.ConnectionString))
            {
                var clients = await context.QueryAsync<Client>("SELECT * FROM Clients");
                return clients;
            }
        }

        public async Task<bool> DeleteClient(int id)
        {
            using (IDbConnection context = new SqlConnection(ConfigHelper.ConnectionString))
            {
                var query = $"DELETE FROM Clients WHERE Id={id}";
                var result = await context.ExecuteAsync(query);
                return result > 0;
            }
        }

        public async Task<Client> GetClient(int id)
        {
            using (IDbConnection context = new SqlConnection(ConfigHelper.ConnectionString))
            {
                var client = await context.QueryFirstOrDefaultAsync<Client>($"SELECT * FROM Clients WHERE Id={id}");
                return client;
            }
        }

        public async Task<bool> UpdateClient(Client client)
        {
            using (IDbConnection context = new SqlConnection(ConfigHelper.ConnectionString))
            {
                var updatedClient = await context.ExecuteAsync(
                    $"UPDATE Clients SET FirstName='{client.FirstName}', " +
                                            $"LastName='{client.LastName}', " +
                                            $"Email='{client.Email}', " +
                                            $"Phone='{client.Phone}', " +
                                            $"Age={client.Age}, " +
                                            $"City='{client.City}', " +
                                            $"Sex='{client.Sex}'" +
                                            $"WHERE Id={client.Id}");
                return updatedClient > 0;
            }
        }

        public async Task<bool> AddClient(Client client)
        {
            using (IDbConnection context = new SqlConnection(ConfigHelper.ConnectionString))
            {
                var query = ($"INSERT INTO Clients([FirstName], [LastName], [Email], [Phone], [Age], [City], [Sex]) " +
                             $"VALUES(@FirstName, @LastName, @Email, @Phone, @Age, @City, @Sex)");
                var result = await context.ExecuteAsync(query, new
                {
                    client.FirstName,
                    client.LastName,
                    client.Email,
                    client.Phone,
                    client.Age,
                    client.City,
                    client.Sex
                });

                return result > 0;
            }
        }
    }
}