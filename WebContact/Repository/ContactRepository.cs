using Microsoft.EntityFrameworkCore;
using WebContact.Data;
using WebContact.Interfaces;
using WebContact.Models;

namespace WebContact.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ContactViewModel>> GetAllAsync()
        {
            return await _context.Contact.ToListAsync();
        }

        public Task<ContactViewModel> GetByIdAsync(int id)
        {
            return _context.Contact.FirstOrDefaultAsync(contact => contact.Id == id);
        }

        public bool Add(ContactViewModel contact)
        {
            _context.Add(contact);
            return Save();
        }

        public bool Delete(ContactViewModel contact)
        {
            _context.Remove(contact);
            return Save();
        }

       

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved>0 ? true : false;
        }

        public bool Update(ContactViewModel contact)
        {
            _context.Update(contact);
            return Save();
        }
    }
}
