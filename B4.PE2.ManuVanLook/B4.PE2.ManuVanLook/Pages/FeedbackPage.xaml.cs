using B4.PE2.ManuVanLook.Domain.Services;
using B4.PE2.ManuVanLook.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Net.Mail;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace B4.PE2.ManuVanLook.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedbackPage : ContentPage
    {
        MailService mailService;
        public FeedbackPage()
        {
            InitializeComponent();
            Title = "feedback form";
            ImageSource src;
            src = Device.RuntimePlatform == Device.UWP ? ImageSource.FromFile("home.png") : ImageSource.FromFile("images/home.png");
            ToolbarItem homeToolBar = new ToolbarItem
            {
                Text = "Home",
                IconImageSource = src,
                Priority = 1
            };
            homeToolBar.Clicked += HomeToolBar_Clicked;
            ToolbarItems.Add(homeToolBar);
        }
        private async void HomeToolBar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            // utilities
            FeedbackValidator validator = new FeedbackValidator();
            bool ValidationResult = true;

            // entries
            List<Entry> entries = new List<Entry>();
            entries.Add(txtEmail); entries.Add(txtFamName); entries.Add(txtName);
            entries.Add(txtOther); entries.Add(txtQuestion); entries.Add(txtSubject);

            foreach (var entry in entries)
            {
                var result = validator.Validate(entry);
                ValidationResult = result.IsValid == true ? true : false;
            }


            if (!ValidationResult)
            {
                lblErrorEmail.IsVisible = true;
                lblErrorName.IsVisible = true;
                lblFamName.IsVisible = true;
                lblSubject.IsVisible = true;

            }
            if (!RegexUtilities.IsValidEmail(txtEmail.Text))
            {
                lblErrorEmail.IsVisible = true;
                lblErrorEmail.Text = "not a valid email";
                ValidationResult = false;
            }
            if (RegexUtilities.IsValidEmail(txtEmail.Text))
            {
                lblErrorEmail.IsVisible = false;
            }
            if (ValidationResult)
            {
                btnSubmit.Text = "busy";
                btnSubmit.IsEnabled = false;

                // message body and subject
                MailMessage mailMessage = new MailMessage
                {
                    Subject = txtSubject.Text,
                    Body = $"Hi {txtEmail.Text},\r\n" +
                    $"feedback :\r\n" +
                    $"bugreport : {txtBugReport.Text}\r\n" +
                    $"question : {txtQuestion.Text}\r\n" +
                    $"other: {txtOther.Text}\r\n" +
                    $"--------------------------" + "--------------------------" + "--------------------------\r\n\r\n" +
                    $"Greetings, {txtFamName.Text} {txtName.Text}"
                };

                // receivers:
                mailMessage.To.Add(new MailAddress(txtEmail.Text));
                mailService = new MailService();
                try
                {

                    await mailService.SendMail(mailMessage);
                    await DisplayAlert("Sent", "email sent", "ok");
                    await Navigation.PopModalAsync();
                }
                catch
                {
                    await DisplayAlert("Something went wrong", "Check your connectivity, or the fields", "ok");
                }
            }
        }

    }
}