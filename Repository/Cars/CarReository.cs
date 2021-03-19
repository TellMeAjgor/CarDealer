using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Helper;
using CarDealer.Models.Entities;
using Dapper;

namespace CarDealer.Repository.Cars
{
    public class CarReository : ICarRepository
    {
        public async Task<IEnumerable<Car>> GetCars()
        {
            using  (IDbConnection context = new SqlConnection(ConfigHelper.ConnectionString))
            {
                var cars = await context.QueryAsync<Car>("SELECT * FROM Cars");
                return cars;
            }
        }
    }
}