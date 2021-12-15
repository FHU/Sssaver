using System;
using System.Collections.ObjectModel;
using Sssaver.Models;
using Xamarin.Forms;

namespace Sssaver.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public SavingsPlan SavingsPlan { get; set; }

        public decimal TodaysSavingsAmount { get; set; }

        public Command UpdateProgress { get; }

        public HomeViewModel()    
        {
            // if no savingsPlan is passed into the constructor,
            // then create one. This is for demo purposes.
            SavingsPlan = new SavingsPlan()
            {
                Days = 30,
                Name = "Fibonacci Plan",
                CurrentSavingsAmount = 54,
                TotalSavingsAmount = 143
            };

            TodaysSavingsAmount = 34;

            SavingsPlan.SavingsChallenges.Add(new SavingsChallenge() { ScheudledDate = new DateTime(2021, 12, 1, 10, 13, 46), Amount = 1, IsCompleted = true });
            SavingsPlan.SavingsChallenges.Add(new SavingsChallenge() { ScheudledDate = new DateTime(2021, 12, 2, 12, 42, 21), Amount = 1, IsCompleted = true });
            SavingsPlan.SavingsChallenges.Add(new SavingsChallenge() { ScheudledDate = new DateTime(2021, 12, 3, 11, 53, 11), Amount = 2, IsCompleted = true });
            SavingsPlan.SavingsChallenges.Add(new SavingsChallenge() { ScheudledDate = new DateTime(2021, 12, 4, 14, 02, 46), Amount = 3, IsCompleted = true });
            SavingsPlan.SavingsChallenges.Add(new SavingsChallenge() { ScheudledDate = new DateTime(2021, 12, 5, 16, 55, 34), Amount = 5, IsCompleted = true });
            SavingsPlan.SavingsChallenges.Add(new SavingsChallenge() { ScheudledDate = new DateTime(2021, 12, 6, 9, 24, 43), Amount = 8, IsCompleted = true });
            SavingsPlan.SavingsChallenges.Add(new SavingsChallenge() { ScheudledDate = new DateTime(2021, 12, 7, 11, 34, 21), Amount = 13, IsCompleted = true });
            SavingsPlan.SavingsChallenges.Add(new SavingsChallenge() { ScheudledDate = new DateTime(2021, 12, 8, 13, 01, 33), Amount = 21, IsCompleted = true });
            SavingsPlan.SavingsChallenges.Add(new SavingsChallenge() { ScheudledDate = new DateTime(2021, 12, 9, 13, 29, 04), Amount = 34, IsCompleted = false });
            SavingsPlan.SavingsChallenges.Add(new SavingsChallenge() { ScheudledDate = new DateTime(2021, 12, 10, 14, 16, 25), Amount = 55, IsCompleted = false });

            foreach (SavingsChallenge challenge in SavingsPlan.SavingsChallenges)
            {
                if (challenge.IsCompleted == true)
                {
                    SavingsPlan.ChallengeHistory.Add(challenge);
                }
                else
                {
                    SavingsPlan.FutureChallenges.Add(challenge);
                }
            }

            UpdateProgress = new Command(() =>
            {
                SavingsPlan.CurrentSavingsAmount += TodaysSavingsAmount;
                SavingsPlan.FutureChallenges[0].IsCompleted = true;
                SavingsPlan.ChallengeHistory.Add(SavingsPlan.FutureChallenges[0]);
                SavingsPlan.FutureChallenges.Remove(SavingsPlan.FutureChallenges[0]);
            });
        }
    }
}
