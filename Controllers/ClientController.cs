using System.Threading.Tasks;
using AutoMapper;
using CarDealer.Models.Entities;
using CarDealer.Models.View;
using CarDealer.Repository.Clients;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace CarDealer.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public ClientController(IClientRepository repository, IMapper mapper, IToastNotification toastNotification)
        {
            _repository = repository;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }
        
        // GET
        public async Task<IActionResult> Index()
        {
            var clients = await _repository.GetClients();
            return View(clients);
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var client = new Client();

            if(id !=0)
                client = await _repository.GetClient(id);
            
            return View(_mapper.Map<ClientVM>(client));
        }

        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteClient(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(ClientVM clientVM)
        {
            if (!ModelState.IsValid)
                return View(clientVM);

            bool result;
            var client = _mapper.Map<Client>(clientVM);
            if (client.Id != 0)
                result = await _repository.UpdateClient(client);
            else
                result = await _repository.AddClient(client);

            if (result)
                _toastNotification.AddSuccessToastMessage("Editing was successful");
            else
                _toastNotification.AddErrorToastMessage("It was unsuccessful");

            return RedirectToAction("Index");
        }

    }
}