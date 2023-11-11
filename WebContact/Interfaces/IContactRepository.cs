using WebContact.Models;

namespace WebContact.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactViewModel>> GetAllAsync();
        Task<ContactViewModel> GetByIdAsync(int id);

        bool Add(ContactViewModel contact);
        bool Update(ContactViewModel contact);
        bool Delete(ContactViewModel contact);
        
        bool Save();

    }
}
