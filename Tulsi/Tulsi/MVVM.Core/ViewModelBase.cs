using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tulsi.MVVM.Core {
    public abstract class ViewModelBase : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Task DisplayAlert(string title, string message, string cancel = "OK") {
            return Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel) {
            return Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null) {
            if (object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}