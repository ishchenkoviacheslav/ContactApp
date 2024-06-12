using ContactApp.Helpers;
using ContactApp.Interfaces;
using ContactApp.Models;
using ContactApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ContactApp.ViewModels
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Contact> _contacts;
        private Contact _selectedContact;
        private IFileService _fileService;
        private IDialogService _dialogService;
        private object _listContactView;
        private object _detailsContactView;
        private object _editContactView;

        private AsyncRelayCommand _detailsCommand;
        private AsyncRelayCommand _returnCommand;
        private AsyncRelayCommand _editCommand;
        private AsyncRelayCommand _removeCommand;
        private AsyncRelayCommand _updateCommand;
        private AsyncRelayCommand _saveCommand;
        private AsyncRelayCommand _openCommand;

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

        public AsyncRelayCommand DetailsCommand
        {
            get
            {
                return _detailsCommand ??
                    (_detailsCommand = new AsyncRelayCommand(async obj =>
                    {
                        if (obj is Contact && SelectedContact is not null)
                        {
                            ListView = new ContactDetailsView();
                        }
                    }));
            }
        }

        public AsyncRelayCommand ReturnCommand
        {
            get
            {
                return _returnCommand ??
                    (_returnCommand = new AsyncRelayCommand(async obj =>
                    {
                        ListView = new ListOfContactView();
                    }));
            }
        }

        public AsyncRelayCommand EditCommand
        {
            get
            {
                return _editCommand ??
                    (_editCommand = new AsyncRelayCommand(async obj =>
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

        public AsyncRelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ??
                    (_removeCommand = new AsyncRelayCommand(async obj =>
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

        public AsyncRelayCommand UpdateCommand
        {
            get
            {
                return _updateCommand ??
                    (_updateCommand = new AsyncRelayCommand(async obj =>
                    {
                        var editContactView = _editContactView as EditContactView;
                        var firstName = editContactView.FindName("FirstName") as TextBox;
                        var lastName = editContactView.FindName("LastName") as TextBox;
                        var birthDay = editContactView.FindName("DateOfBirth") as TextBox;
                        var company = editContactView.FindName("Company") as TextBox;

                        var binding = firstName.GetBindingExpression(TextBox.TextProperty);
                        binding.UpdateSource();
                        binding = lastName.GetBindingExpression(TextBox.TextProperty);
                        binding.UpdateSource();
                        binding = birthDay.GetBindingExpression(TextBox.TextProperty);
                        binding.UpdateSource();
                        binding = company.GetBindingExpression(TextBox.TextProperty);
                        binding.UpdateSource();
                    }));
            }
        }

        public AsyncRelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                  (_saveCommand = new AsyncRelayCommand(async obj =>
                  {
                      try
                      {
                          if (_dialogService.SaveFileDialog() == true)
                          {
                              await _fileService.SaveAsync(_dialogService.FilePath, Contacts.ToList());
                              _dialogService.ShowMessage("File saved");
                          }
                      }
                      catch (Exception ex)
                      {
                          _dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        public AsyncRelayCommand OpenCommand
        {
            get
            {
                return _openCommand ??
                  (_openCommand = new AsyncRelayCommand(async obj =>
                  {
                      try
                      {
                          if (_dialogService.OpenFileDialog() == true)
                          {
                              var contacts = await _fileService.OpenAsync(_dialogService.FilePath);
                              Contacts.Clear();
                              foreach (var c in contacts)
                              {
                                  Contacts.Add(c);
                              }
                              _dialogService.ShowMessage("File opened");
                          }
                      }
                      catch (Exception ex)
                      {
                          _dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }
        public ContactsViewModel(IDialogService dialogService, IFileService fileService)
        {
            _dialogService = dialogService;
            _fileService = fileService;

            ListView = new ListOfContactView();
            DetailsView = new ContactDetailsView();
            EditContactView = new EditContactView();
            Contacts = new ObservableCollection<Contact>
            {
                new Contact { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", DateOfBirth = new DateOnly(1980, 1, 1), Company = "X" },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "XYZ Corp." },
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "X" },
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
                new Contact { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 5, 15), Company = "X" },
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
