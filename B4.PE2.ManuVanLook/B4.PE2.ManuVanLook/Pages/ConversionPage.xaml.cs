using B4.PE2.ManuVanLook.Domain.Models.ConversionEenheden;
using B4.PE2.ManuVanLook.Domain.Models.Conversions;
using B4.PE2.ManuVanLook.Domain.Services;
using B4.PE2.ManuVanLook.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Xamarin.Forms;

namespace B4.PE2.ManuVanLook.Pages
{
    public partial class ConversionPage : ContentPage
    {
        readonly ConversionServiceTijd conversionService = new ConversionServiceTijd();
        readonly ConversionValidator conversionvalidator = new ConversionValidator();
        List<ValidationResult> validationResults;
        ConversionTijd conv;



        public ConversionPage()
        {
            InitializeComponent();
            // conversion pickers value's
            imgArrow.Source = Device.RuntimePlatform == Device.UWP ? ImageSource.FromFile("arrow.png") : ImageSource.FromFile("images/arrow.png");
            Title = "ConversionPage";
            ImageSource src;
            src = Device.RuntimePlatform == Device.UWP ? ImageSource.FromFile("home.png") : ImageSource.FromFile("images/home.png");
            ToolbarItem homeToolBar = new ToolbarItem
            {
                Text = "Home",
                IconImageSource = src,
                Priority = 1
            };
            ToolbarItems.Add(homeToolBar);
            homeToolBar.Clicked += HomeToolBar_Clicked;

            foreach (var item in Enum.GetNames(typeof(TijdsEenheid)))
            {
                conversionHerkomst.Items.Add(item);
                conversionToekomst.Items.Add(item);
            }
            conversionHerkomst.SelectedIndex = 1;
            conversionToekomst.SelectedIndex = 1;


        }

        private void BtnConvert_Clicked(object sender, EventArgs e)
        {
            validationResults = new List<ValidationResult>();

            try
            {
                conv = new ConversionTijd
                {
                    HerkomstGetal = Convert.ToDouble(entryHerkomst.Text),
                    TijdseenheidHerkomst = (TijdsEenheid)Enum.Parse(typeof(TijdsEenheid), conversionHerkomst.SelectedItem.ToString()),
                    TijdseenheidToekomst = (TijdsEenheid)Enum.Parse(typeof(TijdsEenheid), conversionToekomst.SelectedItem.ToString())
                };
            }
            catch
            {

                DisplayAlert("Alert", "you didn't fill everything in correctly", "Ok");
            }

            // extra validations on conversion model
            validationResults = conversionvalidator.Validate(conv);
            if (validationResults.Count == 0)
            {
                lblToekomst.Text = conversionService.Convert(conv).ToString();
            }
            else
            {
                string errorMsg = "";
                foreach (var error in validationResults) { errorMsg += $"{error.ErrorMessage}"; }
                DisplayAlert("Alert", errorMsg, "OK");
            }
        }
        private async void HomeToolBar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}