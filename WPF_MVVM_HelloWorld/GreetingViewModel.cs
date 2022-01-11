using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_MVVM_HelloWorld
{
    public class GreetingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private string firstName;
        private string lastName;
        private string greeting;
        public ICommand cmdClickMe { get; set; }
        private bool CanExecute
        {
            get { return !string.IsNullOrEmpty(FirstName) & !string.IsNullOrEmpty(LastName); }  
        }
        public GreetingViewModel()
        {
            cmdClickMe = new RelayCommand(SayGreeting,() => CanExecute);
        }
        private void SayGreeting()
        {
            Greeting = "Hello " + FirstName + " " + LastName;
        }
        public string FirstName
        {
            get { return firstName; }
            set 
            { 
                firstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                NotifyPropertyChanged("LastName");
            }
        }
        public string Greeting
        {
            get { return greeting; }
            set
            {
                greeting = value;
                NotifyPropertyChanged("Greeting");
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
