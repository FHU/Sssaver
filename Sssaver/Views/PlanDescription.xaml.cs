using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Toasts;
using Xamarin.Forms;

namespace Sssaver.Views
{
    public partial class PlanDescription : ContentPage
    {
        public PlanDescription(string planName)
        {
            InitializeComponent();

            if(planName == "Traditional")
            {
                PlanName.Text = "Traditional Plan";
                PlanLength.Text = "10 Days";
                PlanAmount.Text = "SAVE $100";
                PlanDescribed.Text = "This is a simple savings plan designed for you to save $100 in 10 days!";
            }
            else if(planName == "Royalty")
            {
                PlanName.Text = "Royalty Plan";
                PlanLength.Text = "30 Days";
                PlanAmount.Text = "SAVE $1000";
                PlanDescribed.Text = "This is an advanced savings plan designed for you to save $1000 in 30 days!";
            }
            else if(planName == "Fibonacci")
            {
                PlanName.Text = "Fibonacci Plan";
                PlanLength.Text = "10 Days";
                PlanAmount.Text = "SAVE $143";
                PlanDescribed.Text = "This is a simple savings plan designed for you to save $143 in 10 days following the Fibonacci Sequence!";
            }
            else if(planName == "Custom")
            {
                PlanName.Text = "Custom Plan";
                PlanLength.IsVisible = false;
                PlanAmount.IsVisible = false;
                PlanDescribed.IsVisible = false;
                CustomPlanLengthEntry.IsVisible = true;
                CustomPlanAmountEntry.IsVisible = true;
            }
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var notificator = DependencyService.Get<IToastNotificator>();

            var options = new NotificationOptions()
            {
                Title = "Sorry",
                Description = "You already have a Savings Plan Started"
            };

            var result = await notificator.Notify(options);

        }
    }
}
