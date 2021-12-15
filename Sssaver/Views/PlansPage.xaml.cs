using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Sssaver.Views
{
    public partial class PlansPage : ContentPage
    {
        public PlansPage()
        {
            InitializeComponent();
        }

        private async void Traditional_Plan_Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PlanDescription("Traditional"));
        }

        private async void Royalty_Plan_Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PlanDescription("Royalty"));
        }

        private async void Fibonacci_Plan_Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PlanDescription("Fibonacci"));
        }

        private async void Custom_Plan_Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PlanDescription("Custom"));
        }
    }
}
