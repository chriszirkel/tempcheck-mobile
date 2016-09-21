using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempCheckMobile.Model;
using TempCheckMobile.Services;
using TempCheckMobile.ViewModel;
using Xamarin.Forms;

namespace TempCheckMobile.Views
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel ViewModel
        {
            get { return BindingContext as MainViewModel; }
        }

        public MainPage()
        {
            BindingContext = new MainViewModel();

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //ViewModel.StartMonitoring();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModel.StopMonitoring();
        }

        //private async void OnScan(object sender, EventArgs e)
        //{
        //    var platform = DependencyService.Get<IPlatformService>();

        //    var scanner = platform.GetMobileBarcodeScanner();

        //    var result = await scanner.Scan();

        //    if (result != null)
        //        Debug.WriteLine("Scanned Barcode: " + result.Text);
        //}
    }
}
