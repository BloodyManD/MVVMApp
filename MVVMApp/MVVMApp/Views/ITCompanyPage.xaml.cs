using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ITCompanyPage : ContentPage
    {
        public ITCompanyViewModel ViewModel { get; private set; }
        public ITCompanyPage(ITCompanyViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}