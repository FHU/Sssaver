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

    }
}
