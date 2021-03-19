using System.Threading.Tasks;
using CarDealer.Repository.Cars;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _repository;

        public CarController(ICarRepository repository)
        {
            _repository = repository;
        }
        
        // GET
        public async Task<IActionResult> Index()
        {
            var cars = await _repository.GetCars();
            return View(cars);
        }
    }
}