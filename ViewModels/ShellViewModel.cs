using Caliburn.Micro;
using System;
using WPFWithCaliburnMicro.Models;

namespace WPFWithCaliburnMicro.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _firstname = "Vorname";
        private string _lastName;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson;

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Vorname1", LastName = "Nachname1" });
            People.Add(new PersonModel { FirstName = "Vorname2", LastName = "Nachname2" });
            People.Add(new PersonModel { FirstName = "Vorname3", LastName = "Nachname3" });
        }
        public string FirstName
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }

        }
        public BindableCollection<PersonModel> People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;
            }
        }
        public PersonModel SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstName, string lastName) //=> !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
        {
            //return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
            if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ClearText(string firstName, string lastName)
        {
            FirstName = null;
            LastName = null;

        }

        public async void LoadPageOne()
        {
            await ActivateItemAsync(new FirstChildViewModel());
        }

        public async void LoadPageTwo()
        {
            await ActivateItemAsync(new SecondChildViewModel());
        }
    }
}
