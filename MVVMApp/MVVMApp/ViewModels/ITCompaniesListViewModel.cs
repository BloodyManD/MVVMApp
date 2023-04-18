using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Input;
using MVVMApp.Models;
using MVVMApp.Views;
using Xamarin.Forms;


namespace MVVMApp.ViewModels
{
    public class ITCompaniesListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ITCompanyViewModel> Companies { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateITCompanyCommand { get; protected set; }
        public ICommand DeleteITCompanyCommand { get; protected set; }
        public ICommand SaveITCompanyCommand { get; protected set; }
        public ICommand BackCommand { get; protected set; }
        ITCompanyViewModel selectedCompany;
        
        public INavigation Navigation { get; set; }
        
        public ITCompaniesListViewModel()
        {
            Companies = new ObservableCollection<ITCompanyViewModel>();
            CreateITCompanyCommand = new Command(CreateITCompany);
            DeleteITCompanyCommand = new Command(DeleteITCompany);
            SaveITCompanyCommand = new Command(SaveITCompany);
            BackCommand = new Command(Back);
        }

        public ITCompanyViewModel SelectedCompany
        {
            get => selectedCompany;
            set
            {
                if (selectedCompany != value)
                {
                    ITCompanyViewModel tempCompany = value;
                    tempCompany.ListViewModel = this;
                    selectedCompany = null;
                    OnPropertyChanged("SelectedITCompany");
                    Navigation.PushAsync(new ITCompanyPage(tempCompany));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        
        private void CreateITCompany()
        {
            Navigation.PushAsync(new ITCompanyPage(new ITCompanyViewModel() { ListViewModel = this }));
        }
        private void DeleteITCompany(object companyObject)
        {
            ITCompanyViewModel company = companyObject as ITCompanyViewModel;
            if (company != null)
            {
                // Companies.Remove(company);
                // Debug.WriteLine(company.Filename);
                if (File.Exists(company.Filename)) File.Delete(company.Filename);
            }
            Back();
        }
        private void SaveITCompany(object companyObject)
        {
            ITCompanyViewModel company = companyObject as ITCompanyViewModel;
            if (company != null && company.IsValid)
            {
                string filename;
                if (string.IsNullOrWhiteSpace(company.Filename))
                {
                    filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.itcompany.txt");
                }
                else
                {
                    filename = company.Filename;
                }
                using (Stream stream = File.Open(filename, FileMode.Create))
                {
                    var binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(stream, company.Company);
                    stream.Close();
                }
            }

                // if (company != null && company.IsValid)
            // {
            //     Companies.Add(company);
            // }
            Back();
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
    }
}