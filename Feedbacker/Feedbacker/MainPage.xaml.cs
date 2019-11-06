using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Feedbacker
{
    
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            RedCommand = new Command(
                execute: () =>
                {
                    Analytics.TrackEvent("Color selected", new Dictionary<string, string> {
                        { "EventCategory", "Color" },
                        { "SelectedText", "Red"}
                    });
                });
            GreenCommand = new Command(
                execute: () =>
                {
                    Analytics.TrackEvent("Color selected", new Dictionary<string, string> {
                        { "EventCategory", "Color" },
                        { "SelectedText", "Green"}
                    });
                });
            BlueCommand = new Command(
                execute: () =>
                {
                    Analytics.TrackEvent("Color selected", new Dictionary<string, string> {
                        { "EventCategory", "Color" },
                        { "SelectedText", "Blue"}
                    });
                });

            //Creating test crashes using API
            CrashACommand = new Command(
              execute: () =>
              {
                  Crashes.GenerateTestCrash();
              });

            //Creating crash from code
            CrashBCommand = new Command(
               execute: () =>
               {
                   try
                   {
                       //Causing a divide by zero exception
                       double denom = 0;
                       double fraction = 1.0 / denom;
                   }
                   catch (Exception exception)
                   {
                       var properties = new Dictionary<string, string>
                        {
                            { "Category", "Music" },
                            { "Wifi", "On"}
                        };
                       Crashes.TrackError(exception, properties);
                   }
               });
        }

        public Command RedCommand { private set; get; }
        public Command GreenCommand { private set; get; }
        public Command BlueCommand { private set; get; }


        public Command CrashACommand { private set; get; }
        public Command CrashBCommand { private set; get; }


        private void Switch_Toggled(object sender, ToggledEventArgs e) 
            => Analytics.SetEnabledAsync((sender as Switch).IsToggled);

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }
        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {

        }


    }
}
