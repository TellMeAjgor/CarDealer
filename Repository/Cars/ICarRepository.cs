using System.Collections.Generic;
using System.Threading.Tasks;
using CarDealer.Models.Entities;

namespace CarDealer.Repository.Cars
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCars();
        Task<Car> GetCar(int id);
        Task<bool> UpdateCar(Car car);
        Task<bool> AddCar(Car car);
    }
}