using ContactApp.Models;

namespace ContactApp.Interfaces
{
    public interface IFileService
    {
        Task<List<Contact>> OpenAsync(string filename);
        Task SaveAsync(string filename, List<Contact> contactsList);
    }
}