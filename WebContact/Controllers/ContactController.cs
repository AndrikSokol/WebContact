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
            IEnumerable<Contact> contacts =  await _contactRepository.GetAllAsync();
            ContactViewModel contactViewModel = new ContactViewModel();
            contactViewModel.Contacts = contacts;
            return View(contactViewModel);
        }

        [HttpPost]
        public IActionResult Create(ContactViewModel cvm)
        {
            _contactRepository.Add(cvm.Contact);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(ContactViewModel cvm)
        {
            Contact contact = await _contactRepository.GetByIdAsync(cvm.Contact.Id);
            if (contact != null)
            {
                contact.Name = cvm.Contact.Name;
                contact.MobilePhone = cvm.Contact.MobilePhone;
                contact.JobTitle = cvm.Contact.JobTitle;
                contact.BirthDate = cvm.Contact.BirthDate;
                _contactRepository.Update(contact);
            }                 
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> GetContact(int id)
        {
            Contact contact =  await _contactRepository.GetByIdAsync(id);
            return Json(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Contact contact =  await _contactRepository.GetByIdAsync(id);
            if(contact != null)
                _contactRepository.Delete(contact);
            return RedirectToAction("Index");
        }

    }
}
