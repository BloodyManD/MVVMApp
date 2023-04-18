using System;
using System.ComponentModel;
using MVVMApp.Models;

namespace MVVMApp.ViewModels
{
    public class ITCompanyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ITCompaniesListViewModel lvm;
        public ITCompany Company { get; private set; }

        public ITCompanyViewModel()
        {
            Company = new ITCompany();
        }

        public ITCompaniesListViewModel ListViewModel {
            get => lvm;
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Filename
        {
            get => Company.Filename;
            set { if (Company.Filename != value)
                {
                    Company.Filename = value;
                    OnPropertyChanged("Filename");
                }
            }
        } 

        public string Name
        {
            get => Company.Name;
            set { if (Company.Name != value)
                {
                    Company.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        
        public string Geolocation
        {
            get => Company.Geolocation;
            set { if (Company.Geolocation != value)
                {
                    Company.Geolocation = value;
                    OnPropertyChanged("Geolocation");
                }
            }
        }
        
        public string FieldOfActivity
        {
            get => Company.FieldOfActivity;
            set { if (Company.FieldOfActivity != value)
                {
                    Company.FieldOfActivity = value;
                    OnPropertyChanged("FieldOfActivity");
                }
            }
        }
        
        public string NumberOfEmployees
        {
            get => Company.NumberOfEmployees;
            set { if (Company.NumberOfEmployees != value)
                {
                    Company.NumberOfEmployees = value;
                    OnPropertyChanged("NumberOfEmployees");
                }
            }
        }
        
        public string Scale
        {
            get => Company.Scale;
            set { if (Company.Scale != value)
                {
                    Company.Scale = value;
                    OnPropertyChanged("Scale");
                }
            }
        }
        public bool IsValid =>
            ((!string.IsNullOrEmpty(Name)) ||
             (!string.IsNullOrEmpty(Geolocation)) ||
             (!string.IsNullOrEmpty(FieldOfActivity)) ||
             (!string.IsNullOrEmpty(NumberOfEmployees)) ||
             (!string.IsNullOrEmpty(Scale)));

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}