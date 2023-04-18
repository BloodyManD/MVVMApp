using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using MVVMApp.Models;
using MVVMApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ITCompaniesListPage : ContentPage
    {
        public ITCompaniesListPage()
        {
            InitializeComponent();
            BindingContext = new ITCompaniesListViewModel() { Navigation = this.Navigation };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var context = (ITCompaniesListViewModel)BindingContext;
            context.Companies.Clear();
            var files = Directory.EnumerateFiles(App.FolderPath, searchPattern: "*.itcompany.txt");
            foreach (var filename in files)
            {
                using (Stream stream = File.Open(filename, FileMode.Open))
                {
                    var binaryFormatter = new BinaryFormatter();
                    Debug.WriteLine(filename);
                    
                    var company = (ITCompany)binaryFormatter.Deserialize(stream);
                    company.Filename = filename;
                    Debug.WriteLine(company.Filename);

                    context.Companies.Add(new ITCompanyViewModel
                    {
                        Filename = company.Filename,
                        Name = company.Name,
                        Geolocation = company.Geolocation,
                        FieldOfActivity = company.FieldOfActivity,
                        NumberOfEmployees = company.NumberOfEmployees,
                        Scale = company.Scale
                    });
                }
                
            }
        }
    }
    
}