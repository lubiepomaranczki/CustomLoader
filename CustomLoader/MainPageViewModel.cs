using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CustomLoader
{
    public class MainPageViewModel
    {
        #region Fields

        private bool isBusy;
        private string longText;

        #endregion

        #region Properties

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public string LongText
        {
            get { return longText; }
            set { SetProperty(ref longText, value); }
        }

        #endregion

        #region Constructor(s)

        public MainPageViewModel()
        {
            LongText = "Lorem ipsum dolor sit amet, et qui noster dolorum, ea oblique maiorum nusquam his. Melius regione cu per. Ei mei sententiae percipitur. Has noster abhorreant no. Mel vidisse aliquip ei.";
            IsBusy = true;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T backupValue, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backupValue, value))
            {
                return false;
            }

            backupValue = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
            {
                return;
            }

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
