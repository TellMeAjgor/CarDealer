using System.Threading.Tasks;
using CarDealer.Models.Entities;
using CarDealer.Repository.Cars;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using AutoMapper;
using CarDealer.Models.View;

namespace CarDealer.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _repository;
        private readonly IToastNotification _toastNotification;
        private readonly IMapper _mapper;

        public CarController(ICarRepository repository, IToastNotification toastNotification, IMapper mapper)
        {
            _toastNotification = toastNotification;
            _repository = repository;
            _mapper = mapper;
        }
        
        // GET
        public async Task<IActionResult> Index()
        {
            var cars = await _repository.GetCars();
            return View(cars);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var car = new Car();

            if(id !=0)
                car = await _repository.GetCar(id);
            
            return View(_mapper.Map<CarVM>(car));
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(CarVM carVM)
        {
            if (!ModelState.IsValid)
                return View(carVM);

            bool result;
            var car = _mapper.Map<Car>(carVM);
            if (car.Id != 0)
                result = await _repository.UpdateCar(car);
            else
                result = await _repository.AddCar(car);

            if (result)
                _toastNotification.AddSuccessToastMessage("Editing was successful");
            else
                _toastNotification.AddErrorToastMessage("It was unsuccessful");

            return RedirectToAction("Index");
        }
    }
}
