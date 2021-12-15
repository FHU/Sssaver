using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sssaver.Models
{
    public class SavingsPlan : INotifyPropertyChanged
    {
        public SavingsPlan()
        {
            SavingsChallenges = new ObservableCollection<SavingsChallenge>();
            ChallengeHistory = new ObservableCollection<SavingsChallenge>();
            FutureChallenges = new ObservableCollection<SavingsChallenge>();
        }

        public string Name { get; set; }

        public string Goal { get; set; }
        public string GoalImage { get; set; }

        private int days = 0;
        public int Days {
            get { return days; }
            set { SetProperty(ref days, value); }
        }

        public decimal TotalSavingsAmount { get; set; }

        private decimal currentSavingsAmount;
        public decimal CurrentSavingsAmount {
            get { return currentSavingsAmount; }
            set {
                SetProperty(ref currentSavingsAmount, value);

                // Trigger the linked property to also update.
                OnPropertyChanged("PercentSavingsCompleted");
                OnPropertyChanged("PlanProgress");
            }
        }

        public double PercentSavingsCompleted
        {
            get
            {
                return (double)CurrentSavingsAmount / (double)TotalSavingsAmount;
            }
        }

        public string PlanProgress
        {
            get
            {
                return "$" + CurrentSavingsAmount + " / $" + TotalSavingsAmount;
            }
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ObservableCollection<SavingsChallenge> SavingsChallenges{ get; set; }
        public ObservableCollection<SavingsChallenge> ChallengeHistory { get; set; }
        public ObservableCollection<SavingsChallenge> FutureChallenges { get; set; }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
