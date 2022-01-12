using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_ComboBox
{
    public class GreetingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string hello;
        public string Hello
        {
            get { return hello; }
            set { 
                hello = value;
                NotifyPropertyChanged("Hello");
            }
        }

        private List<GreetingModel> countryList;
        public List<GreetingModel> CountryList 
        {
            get { return countryList; }
            set 
            { 
                countryList = value;
                NotifyPropertyChanged("CountryList");
            }
        }

        public GreetingModel selectedCountry;
        public GreetingModel SelectedCountry
        {
            get { return selectedCountry; }
            set 
            { 
                selectedCountry = value; 
                Hello = SelectedCountry.Greeting;
                NotifyPropertyChanged("SelectedCountry");
            }
        }

        public GreetingViewModel()
        {
            CountryList = new List<GreetingModel>() 
            {
                new GreetingModel { CountryID = 1, CountryName = "Italy", Greeting = "Ciao Mondo!" },
                new GreetingModel { CountryID = 2, CountryName = "France", Greeting = "Salut!" },
                new GreetingModel { CountryID = 3, CountryName = "Spain", Greeting = "Hola a todos!" },
                new GreetingModel { CountryID = 4, CountryName = "Georgia", Greeting = "Ciao!" },
                new GreetingModel { CountryID = 5, CountryName = "Mexico", Greeting = "Siesta!" }
            };

            SelectedCountry = CountryList[0];
        }
    }
}