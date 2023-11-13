using System.ComponentModel.DataAnnotations;

namespace WebContact.Models
{
    public class ContactViewModel
    {
       public IEnumerable<Contact> Contacts { get; set;}

       public Contact Contact { get; set;}
    }
}
