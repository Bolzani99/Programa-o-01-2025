using Microsoft.AspNetCore.Mvc;
using _06_Poo.Models;
using Repository;
using PooModel;


namespace _06_Poo.Controllers
{
    public class CustomerController : Controller
    {
        private CostumerRepository? _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CostumerRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Costumer> customers = _customerRepository.RetriveAll();
            return View(customers);
        }

        [HttpPost]
        public IActionResult Create(Costumer c)
        {
            _customerRepository.Save(c);

            return View("Index");
        }
    }
}

