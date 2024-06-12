using ContactApp.Helpers;
using ContactApp.Models;
using ContactApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace ContactApp.ViewModels
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Contact> _contacts;
        private Contact _selectedContact;

        private object _listContactView;
        private object _detailsContactView;
        private object _editContactView;

        private RelayCommand _detailsCommand;
        private RelayCommand _returnCommand;
        private RelayCommand _editCommand;
        private RelayCommand _removeCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set
            {
                if (_contacts != value)
                {
                    _contacts = value;
                    //including it won't cause any issues; it's just redundant in specific case (changes to the collection itself, not to its individual elements)
                    OnPropertyChanged(nameof(Contacts));
                }
            }
        }
        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                if (_selectedContact != value)
                {
                    _selectedContact = value;
                    OnPropertyChanged(nameof(SelectedContact));
                }
            }
        }

        public object ListView
        {
            get => _listContactView;
            set
            {
                _listContactView = value;
                OnPropertyChanged(nameof(ListView));
            }
        }

        public object EditContactView
        {
            get => _editContactView;
            set
            {
                _editContactView = value;
                OnPropertyChanged(nameof(EditContactView));
            }
        }
        public object DetailsView
        {
            get => _detailsContactView;
            set
            {
                _detailsContactView = value;
                OnPropertyChanged(nameof(DetailsView));
            }
        }

        public RelayCommand DetailsCommand
        {
            get
            {
                return _detailsCommand ??
                    (_detailsCommand = new RelayCommand(obj =>
                    {
                        if (obj is Contact && SelectedContact is not null)
                        {
                            ListView = new ContactDetailsView();
                        }
                    }));
            }
        }

        public RelayCommand ReturnCommand
        {
            get
            {
                return _returnCommand ??
                    (_returnCommand = new RelayCommand(obj =>
                    {
                        ListView = new ListView();
                    }));
            }
        }

        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand ??
                    (_editCommand = new RelayCommand(obj =>
                    {
                        if (obj is Contact && SelectedContact != null)
                        {
                            var editDialog = new EditContactWindow();
                            editDialog.DataContext = this;
                            editDialog.ShowDialog();
                        }
                    },
                    (obj) => Contacts.Count > 0 && SelectedContact != null));
            }
        }

        public RelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ??
                    (_removeCommand = new RelayCommand(obj =>
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

        public ContactsViewModel()
        {
            ListView = new ListView();
            DetailsView = new ContactDetailsView();
            EditContactView = new EditContactView();
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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
