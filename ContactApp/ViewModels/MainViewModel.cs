using ContactApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ContactApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Contact> contacts;
        private Contact selectedContact;

        public ObservableCollection<Contact> Contacts
        {
            get => contacts;
            set
            {
                if (contacts != value)
                {
                    contacts = value;
                    //including it won't cause any issues; it's just redundant in specific case (changes to the collection itself, not to its individual elements)
                    OnPropertyChanged(nameof(Contacts));
                }
            }
        }

        public Contact SelectedContact
        {
            get => selectedContact;
            set
            {
                if (selectedContact != value)
                {
                    selectedContact = value;
                    OnPropertyChanged(nameof(SelectedContact));
                }
            }
        }

        public MainViewModel()
        {
            Contacts = new ObservableCollection<Contact>
        {
            new Contact { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", DateOfBirth = new DateOnly(1980, 1, 1), Company = "ABC Inc." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
        };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
