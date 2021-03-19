using System.Collections.Generic;
using System.Threading.Tasks;
using CarDealer.Models.Entities;

namespace CarDealer.Repository.Cars
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCars();
    }
}