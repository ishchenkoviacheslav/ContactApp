using System.ComponentModel;

namespace ContactApp.Models
{
    public class Contact : INotifyPropertyChanged
    {
        private Guid id;
        private string firstName;
        private string lastName;
        private DateOnly dateOfBirth;
        private string company;

        public Guid Id
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        public DateOnly DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                if (dateOfBirth != value)
                {
                    dateOfBirth = value;
                    OnPropertyChanged(nameof(DateOfBirth));
                }
            }
        }

        public string Company
        {
            get => company;
            set
            {
                if (company != value)
                {
                    company = value;
                    OnPropertyChanged(nameof(Company));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
