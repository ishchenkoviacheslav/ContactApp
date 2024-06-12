using ContactApp.Models;

namespace ContactApp.Interfaces
{
    public interface IFileService
    {
        List<Contact> Open(string filename);
        void Save(string filename, List<Contact> contactsList);
    }
}