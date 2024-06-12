using ContactApp.Interfaces;
using ContactApp.Models;
using System.IO;
using System.Text.Json;

namespace ContactApp.Implementations
{
    public class JsonFileService : IFileService
    {
        public async Task<List<Contact>> OpenAsync(string filePath)
        {
            var readPeopleJson = await File.ReadAllTextAsync(filePath);
            var deserializedPeople = JsonSerializer.Deserialize<List<Contact>>(readPeopleJson);

            return deserializedPeople;
        }

        public async Task SaveAsync(string filePath, List<Contact> contactsList)
        {
            var contactsAsJson = JsonSerializer.Serialize(contactsList);
            await File.WriteAllTextAsync(filePath, contactsAsJson);
        }
    }
}