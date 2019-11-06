using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Feedbacker.ViewModels
{
    public class MainPageViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
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

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
