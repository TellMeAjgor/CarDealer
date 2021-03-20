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
        public async Task<Car> GetCar(int id)
        {
            using (IDbConnection context = new SqlConnection(ConfigHelper.ConnectionString))
            {
                var car = await context.QueryFirstOrDefaultAsync<Car>($"SELECT * FROM Cars WHERE Id={id}");
                return car;
            }
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            using  (IDbConnection context = new SqlConnection(ConfigHelper.ConnectionString))
            {
                var cars = await context.QueryAsync<Car>("SELECT * FROM Cars");
                return cars;
            }
        }

        public async Task<bool> UpdateCar(Car car)
        {
            using (IDbConnection context = new SqlConnection(ConfigHelper.ConnectionString))
            {
                var cars = await context.ExecuteAsync($"UPDATE Cars SET Brand='{car.Brand}', Model='{car.Model}', " +
                    $"HorsePower={car.HorsePower}, Mileage={car.Mileage}, Vin='{car.Vin}', Condition='{car.Condition}', " +
                    $"Year='{car.Year}', Color='{car.Color}', Drive='{car.Drive}', Description='{car.Description}' " +
                    $"WHERE Id='{car.Id}'");

                return cars > 0;
            }
        }
    }
}