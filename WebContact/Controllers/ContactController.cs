using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebContact.Data;
using WebContact.Interfaces;
using WebContact.Models;

namespace WebContact.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository) 
        {
            _contactRepository = contactRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ContactViewModel> contacts = await _contactRepository.GetAllAsync();
            return View(contacts);
        }

        public IActionResult Delete()
        {


            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
