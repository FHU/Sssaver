using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Sssaver.Models;

namespace Sssaver.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public SavingsPlan SavingsPlan { get; set; }

        public decimal TodaysSavingsAmount { get; set; }

        public ObservableCollection<SavingsChallenge> SavingsHistory { get; set; }

        public bool challengeRevealed = false;
        public bool ChallengeRevealed
        {
            get { return challengeRevealed; }
            set { SetProperty(ref challengeRevealed, value); }
        }

        public bool ChallengeNotRevealed
        {
            get
            {
                return !ChallengeRevealed;
            }
        }

        public HomeViewModel()
        {
            SavingsPlan = new SavingsPlan()
            {
                Name = "Krait Savings",
                Goal = "Transformers Combiner Wars Victorian Box Set Autobots Females MIB New Rare!",
                GoalImage = "https://i.ebayimg.com/images/g/uW4AAOSwUkVhclPT/s-l300.jpg",
                Days = 30,
                TotalSavingsAmount = 339.95M,
                CurrentSavingsAmount = 0,
                StartDate = new DateTime(), //2020, 12, 1
                EndDate = new DateTime(2020, 12, 30),
                SavingsChallenges = new List<SavingsChallenge>()
            };

            Random rnd = new Random();
            for (int i = 0; i < SavingsPlan.Days; i++)
            {
                int r = rnd.Next(8, 14); //returns random integers < 10

                SavingsChallenge S = new SavingsChallenge(new DateTime(), (decimal)r);
                SavingsPlan.SavingsChallenges.Add(S);
            }

            for (int i = 0; i < 8; i++)
            {
                SavingsHistory.Add(SavingsPlan.SavingsChallenges[i]);
                SavingsPlan.SavingsChallenges[i].IsCompleted = true;
                SavingsPlan.CurrentSavingsAmount += SavingsHistory[i].Amount;
            }

            // Today's Savings Amount should be extracted from
            // the SavingsChallenges list in the SavingsPlan.


            // The SavingsHistory should be loaded from the
            // SavingsChallenges list in the SavingsPlan.
        }

        public string ProgressAmount
        {
            get
            {
                return "$" + SavingsPlan.CurrentSavingsAmount + "/$" + SavingsPlan.TotalSavingsAmount;
            }
        }

        public string layoutBounds;

        public string StartDate
        {
            get
            {
                string[] Months = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };
                return Months[SavingsPlan.StartDate.Month - 1] + " " + SavingsPlan.StartDate.Day;
            }
        }

        public string EndDate
        {
            get
            {
                string[] Months = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };
                return Months[SavingsPlan.EndDate.Month - 1] + " " + SavingsPlan.EndDate.Day;
            }
        }

        public void RevealSavingsChellenge()
        {
            ChallengeRevealed = true;
        }
    }
}
