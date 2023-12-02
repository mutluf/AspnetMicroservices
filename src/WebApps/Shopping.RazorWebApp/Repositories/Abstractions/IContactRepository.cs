using Shopping.RazorWebApp.Entities;

namespace Shopping.RazorWebApp.Repositories.Abstractions
{
    public interface IContactRepository
    {
        Task<Contact> SendMessage(Contact contact);
        Task<Contact> Subscribe(string address);
    }
}
