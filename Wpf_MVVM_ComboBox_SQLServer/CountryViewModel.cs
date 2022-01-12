using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_MVVM_ComboBox_SQLServer
{
    public class CountryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private string connectionString = Properties.Settings.Default.WPF_Connection;
        public CountryViewModel()
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand("select * from tblCountry", connection);
                dataAdapter.Fill(dataSet);
            }

            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables[0];
            CountryList = new List<CountryModel>();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow = dataTable.Rows[i];
                CountryModel countryModel = new CountryModel();
                
                if((int)dataRow["countryID"] != null)
                    countryModel.CountryID = (int)dataRow["countryID"];
                if(dataRow["countryName"].ToString() != null)
                    countryModel.CountryName = dataRow["countryName"].ToString();
                if (dataRow["greeting"].ToString() != null)
                    countryModel.Greeting = dataRow["greeting"].ToString();

                CountryList.Add(countryModel);
            }

            SelectedCountry = CountryList[0];
        }
        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string hello;
        public string Hello
        {
            get { return hello; }
            set { hello = value; NotifyPropertyChanged("Hello"); }
        }

        private List<CountryModel> countryList;
        public List<CountryModel> CountryList
        {
            get { return countryList; }
            set { countryList = value; NotifyPropertyChanged("CountryList");  }
        }

        private CountryModel selectedCountry;
        public CountryModel SelectedCountry
        {
            get { return selectedCountry; }
            set 
            { 
                selectedCountry = value;
                Hello = SelectedCountry.Greeting;
                NotifyPropertyChanged("SelectedCountry");  
            }
        }
    }
}
