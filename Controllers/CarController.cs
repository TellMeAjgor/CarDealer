using System.Threading.Tasks;
using CarDealer.Models.Entities;
using CarDealer.Repository.Cars;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace CarDealer.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _repository;
        private readonly IToastNotification _toastNotification;

        public CarController(ICarRepository repository, IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
            _repository = repository;
        }
        
        // GET
        public async Task<IActionResult> Index()
        {
            var cars = await _repository.GetCars();
            return View(cars);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var car = await _repository.GetCar(id);
            return View(car);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(Car car)
        {
            var result = await _repository.UpdateCar(car);

            if (result)
                _toastNotification.AddSuccessToastMessage("Editing was successful");
            else
                _toastNotification.AddErrorToastMessage("It was unsuccessful");

            return RedirectToAction("Index");
        }
    }
}