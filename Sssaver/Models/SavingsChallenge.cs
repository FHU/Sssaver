using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sssaver.Models
{
    public class SavingsChallenge: INotifyPropertyChanged
    {
        public decimal Amount { get; set; }

        public DateTime ScheudledDate { get; set; }

        private bool isCompleted;
        //public bool IsCompleted { get; set; } = false;

        public bool IsCompleted
        {
            get { return isCompleted; }
            set => SetProperty(ref isCompleted, value);
        }

        public SavingsChallenge(DateTime scheduledDate = new DateTime(), decimal amount = (decimal)0.0 )
        {
            ScheduledDate = scheduledDate;
            Amount = amount;
        }

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

        public static implicit operator decimal(SavingsChallenge v)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
