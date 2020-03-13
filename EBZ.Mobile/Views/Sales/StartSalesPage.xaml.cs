using EBZ.Mobile.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace EBZ.Mobile.Views.Sales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartSalesPage : ZXingScannerPage
    {
        public ZXingScannerPage scanPage;
        DialogService _dialogService = new DialogService();
        SalesDataService _salesDataService = new SalesDataService();
        public StartSalesPage()
        {
            InitializeComponent();
            var navServ = App.ViewNavigationService;

            string copyright = "\u00a9 ";
            cpyright.Text = copyright + DateTime.Now.Year;

            buttonScanDefaultOverlayCheckIn.Clicked += async delegate
            {
                scanPage = new ZXingScannerPage();
                scanPage.OnScanResult += (result) =>
                {
                    scanPage.IsScanning = false;

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        //_dialogService.ShowLoading("Searching...");
                        var userResult = await _salesDataService.GetUser(result.Text);
                        if (userResult != null)
                        {
                            Application.Current.Properties["checkinCust"] = userResult;
                            //_dialogService.HideLoading();
                            //await Navigation.PopAsync();
                            await navServ.NavigateAsync("PaymentPage");
                        }
                        else
                        {
                            //_dialogService.HideLoading();
                            _dialogService.ShowToast("Sorry! User not found. Please see the Admin, if you think this is not right.");
                            //await navServ.GoBack();
                            //await Navigation.PushAsync(scanPage);
                        }
                    });
                };
                //_dialogService.HideLoading();
                //_dialogService.ShowToast("Sorry! User not found. Please see the Admin, if you think this is not right.");
                await Navigation.PushAsync(scanPage);
            };

            buttonScanDefaultOverlayCheckOut.Clicked += async delegate
            {
                scanPage = new ZXingScannerPage();
                scanPage.OnScanResult += (result) =>
                {
                    scanPage.IsScanning = false;

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        //_dialogService.ShowLoading("Searching...");
                        var userResult = await _salesDataService.GetUser(result.Text);
                        if (userResult != null)
                        {
                            Application.Current.Properties["checkoutCust"] = userResult;
                            //_dialogService.HideLoading();
                            //await Navigation.PopAsync();
                            await navServ.NavigateAsync("CheckoutPage");
                        }
                        else
                        {
                            //_dialogService.HideLoading();
                            _dialogService.ShowToast("Sorry! User not found. Please see the Admin, if you think this is not right.");
                            //await navServ.GoBack();
                            //await Navigation.PushAsync(scanPage);
                        }
                    });
                };
                //_dialogService.HideLoading();
                //_dialogService.ShowToast("Sorry! User not found. Please see the Admin, if you think this is not right.");
                await Navigation.PushAsync(scanPage);
            };

            //btnBegin.Clicked += async delegate
            //{                
            //    Application.Current.Properties["transCustomer"] = "onifademola@gmail.com";
            //    await navServ.NavigateAsync("SelectProductPage");
            //};
        }
    }
}