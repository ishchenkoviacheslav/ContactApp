using ContactApp.Helpers;
using ContactApp.Models;
using ContactApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ContactApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Contact> contacts;
        private Contact selectedContact;
        private object _currentView;

        public ICommand SwitchViewCommand { get; }

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        Contact сontact = obj as Contact;
                        if (сontact != null)
                        {
                            var result = MessageBox.Show("Are you sure you want to delete this item?",
                                                      "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (result == MessageBoxResult.Yes)
                            {
                                Contacts.Remove(сontact);
                                MessageBox.Show("Item deleted successfully.", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    },
                    (obj) => Contacts.Count > 0 && SelectedContact != null));
            }
        }
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
            CurrentView = new MainView();
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
                new Contact { Id = Guid.NewGuid(), FirstName = "dfdfg", LastName = "dfg", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "fffff", LastName = "gggg", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "eeeee", LastName = "tttt", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
            };
            SelectedContact = Contacts.FirstOrDefault();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
