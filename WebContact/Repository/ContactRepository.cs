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
        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return  await _context.Contact.ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _context.Contact.FirstAsync(c => c.Id == id);
        }

        public bool Add(Contact contact)
        {
            _context.Add(contact);
            return Save();
        }

        public bool Delete(Contact contact)
        {
            _context.Remove(contact);
            return Save();
        }
       

        public bool Save()
        {
            var saved =  _context.SaveChanges();
            return saved>0 ? true : false;
        }

        public bool Update(Contact contact)
        {
            _context.Update(contact);
            return Save();
        }
    }
}
