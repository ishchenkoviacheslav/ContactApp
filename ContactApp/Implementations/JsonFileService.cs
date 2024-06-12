using ContactApp.Interfaces;
using ContactApp.Models;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace ContactApp.Implementations
{
    public class JsonFileService : IFileService
    {
        public List<Contact> Open(string filePath)
        {
            var readPeopleJson = File.ReadAllText(filePath);
            var deserializedPeople = JsonSerializer.Deserialize<List<Contact>>(readPeopleJson);

            return deserializedPeople;
        }

        public void Save(string filePath, List<Contact> contactsList)
        {
            var contactsAsJson = JsonSerializer.Serialize(contactsList);
            File.WriteAllText(filePath, contactsAsJson);
        }
    }
}