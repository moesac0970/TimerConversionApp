using B4.PE2.ManuVanLook.Pages;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace B4.PE2.ManuVanLook
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void TimePage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new TimePage()));
        }

        private async void ConversionPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ConversionPage()));
        }

        private async void FeedbackPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new FeedbackPage()));
        }
    }
}
