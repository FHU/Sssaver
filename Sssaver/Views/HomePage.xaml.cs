using System;
using System.Collections.Generic;
using Sssaver.ViewModels;
using Xamarin.Forms;

namespace Sssaver.Views
{
    public partial class HomePage : ContentPage
    {
        private HomeViewModel homeViewModel;

        public HomePage()
        {
            InitializeComponent();

            BindingContext = homeViewModel = new HomeViewModel();
        }

        private async void Mystery_Button_Clicked(object sender, System.EventArgs e)
        {
            await MysteryButton.FadeTo(0, 400);
            SaveGoalHidden.IsVisible = false;
            SaveGoalReveal.IsVisible = true;
        }

        private async void Save_Button_Clicked(object sender, System.EventArgs e)
        {
            await SaveGoalReveal.FadeTo(0, 400);
            SaveGoalReveal.IsVisible = false;
            GoalCompletedReveal.IsVisible = true;
            MyParticleCanvas.IsActive = true;
        }

        void FutureChallengesToggler_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (FutureChallengesToggler.IsToggled == true)
            {
                FutureChallenges.IsVisible = true;
            }
            else
            {
                FutureChallenges.IsVisible = false;
            }
        }

    }
}
