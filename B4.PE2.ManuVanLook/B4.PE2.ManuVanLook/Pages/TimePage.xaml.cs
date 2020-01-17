using B4.PE2.ManuVanLook.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace B4.PE2.ManuVanLook.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimePage : ContentPage
    {
        readonly Stopwatch stopWatch;
        int counter;
        Laptimer timeModel;
        List<Laptimer> laps = new List<Laptimer>();
        public TimePage()
        {
            InitializeComponent();
            Title = "Lap timer";
            stopWatch = new Stopwatch();
            RefreshLaps();
            btnLap.IsEnabled = false;
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

        private void BtnStart_Clicked(object sender, EventArgs e)
        {
            if (!stopWatch.IsRunning)
            {
                counter = 0;
                stopWatch.Start();
                btnStart.Text = "stop";
                laps = new List<Laptimer>();
                RefreshLaps();
                btnLap.IsEnabled = true;
                Device.StartTimer(TimeSpan.FromMilliseconds(1), () =>
                {
                    TimeLapPage.Text = stopWatch.Elapsed.ToString();
                    if (!stopWatch.IsRunning)
                    {
                        btnStart.Text = "start";
                        stopWatch.Reset();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                );
            }
            else
            {
                btnLap.IsEnabled = false;
                btnStart.Text = "stop";
                stopWatch.Stop();
            }
        }

        private void BtnLap_Clicked(object sender, EventArgs e)
        {
            timeModel = new Laptimer();
            timeModel.Time = stopWatch.Elapsed.ToString();
            timeModel.Position = counter;
            if(laps.Count == 0) { timeModel.Diffrence = "0"; }
            else 
            {
                var oldTime = laps.FindLast( t => t.Position <counter );
                TimeSpan ts = TimeSpan.Parse(oldTime.Time) - stopWatch.Elapsed;
                if (TimeSpan.Parse(oldTime.Time) < stopWatch.Elapsed)
                {
                    timeModel.Diffrence = $"- {ts.ToString(@"ss\.fff")} s";
                }
                else
                {
                    timeModel.Diffrence = $"+ {ts.ToString(@"ss\.fff")} s";
                }
            }
            counter++;
            stopWatch.Restart();
            laps.Add(timeModel);
            RefreshLaps();
        }

        private void RefreshLaps()
        {
            lvLaps.ItemsSource = laps.AsQueryable();
        }
    }
}
