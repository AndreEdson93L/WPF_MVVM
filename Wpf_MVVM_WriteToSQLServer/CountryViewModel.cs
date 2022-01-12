using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wpf_MVVM_WriteToSQLServer;
public class CountryViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public ICommand cmdSave { get; private set; }
    public bool CanExecute { get { return !string.IsNullOrEmpty(CountryName) & !string.IsNullOrEmpty(Greeting); } }
    private string countryName;
    private string greeting;
    private string errorMessage;
    private string connectionString = Properties.Settings.Default.Wpf_Connection_String;
    public CountryViewModel()
    {
        cmdSave = new RelayCommand(Save,() => CanExecute);
    }

    private void Save()
    {
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "insert into tblCountry(CountryName, Greeting) values(@CountryName, @Greeting)";
        cmd.Parameters.AddWithValue("@CountryName", CountryName);
        cmd.Parameters.AddWithValue("@Greeting", Greeting);

        try
        {
            connection.Open();
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            ErrorMessage = ex.Message;
        }
        finally
        {

        }

        ErrorMessage = "Data saved successfully";
    }

    private void NotifyPropertyChanged([CallerMemberName] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    public string CountryName
    {
        get { return countryName; }
        set { countryName = value; NotifyPropertyChanged("CountryName"); }
    }
    public string Greeting
    {
        get { return greeting; }
        set { greeting = value; NotifyPropertyChanged("Greeting"); }
    }
    public string ErrorMessage
    {
        get { return errorMessage; }
        set { errorMessage = value; NotifyPropertyChanged("ErrorMessage"); }
    }

    
}
