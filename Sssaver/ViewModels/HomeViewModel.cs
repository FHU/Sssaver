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
                TotalSavingsAmount = 0M,
                CurrentSavingsAmount = 0M,
                StartDate = new DateTime(), //2020, 12, 1
                EndDate = new DateTime(2020, 12, 30),
                SavingsChallenges = new List<SavingsChallenge>()
            };

            Random rnd = new Random();

            // For Date

            for (int i = 0; i < SavingsPlan.Days; i++)
            {
                decimal d = (decimal)rnd.Next(8, 14);
                d += (decimal)rnd.Next(1, 100) / 100.00M;
                DateTime DT = new DateTime(2021, 12, i + 1);
                SavingsChallenge S = new SavingsChallenge(DT, d);
                SavingsPlan.TotalSavingsAmount += d;
                SavingsPlan.SavingsChallenges.Add(S);
            }

            SavingsHistory = new ObservableCollection<SavingsChallenge>();

            for (int i = 0; i < 8; i++)
            {
                SavingsHistory.Add(SavingsPlan.SavingsChallenges[i]);
                SavingsPlan.SavingsChallenges[i].IsCompleted = true;
                SavingsPlan.CurrentSavingsAmount += SavingsPlan.SavingsChallenges[i].Amount;
            }

            // Today's Savings Amount should be extracted from
            // the SavingsChallenges list in the SavingsPlan.

            /*int x = 0;
            do
            {
                bool Check = 
                if (SavingsPlan.SavingsChallenges[x].IsCompleted != true)
                {
                    TodaysSavingsAmount = SavingsPlan.SavingsChallenges[x].Amount;
                }

                i++;
            } while (x < SavingsPlan.Days && ); */


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
