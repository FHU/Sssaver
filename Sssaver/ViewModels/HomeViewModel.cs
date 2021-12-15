using System;
using System.Collections.ObjectModel;
using Sssaver.Models;

namespace Sssaver.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public SavingsPlan SavingsPlan { get; set; }

        public decimal TodaysSavingsAmount { get; set; }
        
        public ObservableCollection<SavingsChallenge> SavingsHistory { get; set; }

        public HomeViewModel(SavingsPlan savingsPlan = null)    
        {
            if (savingsPlan != null)
            {
                // if no savingsPlan is passed into the constructor,
                // then create one. This is for demo purposes.
                SavingsPlan = new SavingsPlan()
                {
                    Days = 30,
                    Name = "Viper",
                    CurrentSavingsAmount = 30,
                    TotalSavingsAmount = 100
                };

                // Today's Savings Amount should be extracted from
                // the SavingsChallenges list in the SavingsPlan.


                // The SavingsHistory should be loaded from the
                // SavingsChallenges list in the SavingsPlan.
            }
        }
    }
}
