using WebContact.Models;

namespace WebContact.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);

        bool Add(Contact contact);
        bool Update(Contact contact);
        bool Delete(Contact contact);
        
        bool Save();

    }
}
