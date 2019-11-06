using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Feedbacker
{
    
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }      


        

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
