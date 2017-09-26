using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Tulsi.SharedService;
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public sealed class PasscodePageViewModel : ViewModelBase, IViewModel {

        private const int PASSCODE_LENGTH = 4;

        private Stack<string> _stackDigits = new Stack<string>();

        string _firstEntry;
        public string FirstEntry {
            get { return _firstEntry; }
            set {
                SetProperty(ref _firstEntry, value);
            }
        }

        string _secondEntry;
        public string SecondEntry {
            get { return _secondEntry; }
            set {
                SetProperty(ref _secondEntry, value);
            }
        }

        string _thirdEntry;
        public string ThirdEntry {
            get { return _thirdEntry; }
            set {
                SetProperty(ref _thirdEntry, value);
            }
        }

        string _fourthEntry;
        public string FourthEntry {
            get { return _fourthEntry; }
            set {
                SetProperty(ref _fourthEntry, value);
            }
        }

        public ICommand ButtonInputCommand { get; private set; }

        public ICommand CleanDigitCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public PasscodePageViewModel() {
            ButtonInputCommand = new Command(OnInputedDigit);

            CleanDigitCommand = new Command(OnCleanDigit);
        }

        private void OnCleanDigit() {
            if (_stackDigits.Count == 0)
                return;

            if (!string.IsNullOrEmpty(FourthEntry)) {
                _stackDigits.Pop();
                FourthEntry = string.Empty;
                return;
            }

            if (!string.IsNullOrEmpty(ThirdEntry)) {
                _stackDigits.Pop();
                ThirdEntry = string.Empty;
                return;
            }

            if (!string.IsNullOrEmpty(SecondEntry)) {
                _stackDigits.Pop();
                SecondEntry = string.Empty;
                return;
            }

            if (!string.IsNullOrEmpty(FirstEntry)) {
                _stackDigits.Pop();
                FirstEntry = string.Empty;
                return;
            }
        }

        private void OnInputedDigit(object obj) {
            SetPasscode((string)obj);

            if (_stackDigits.Count == PASSCODE_LENGTH) {
                CheckPasscode();
            }
        }

        private void CheckPasscode() {
            string result = string.Empty;
            foreach (var item in _stackDigits) {
                result = item + result;
            }

            int.TryParse(result, out int pin);
            bool valid = DependencyService.Get<ISQLiteService>().CheckPin(pin);

            CanEnteredToApp(valid);
        }

        private void CanEnteredToApp(bool valid) {
            if (valid) {
                BaseSingleton<ViewSwitchingLogic>.Instance.BuildNavigationStack(ViewType.DashboardPage);
            } else {
                DisplayAlert("WARNING", "Invalid passcode", "Ok");
            }
        }

        private void SetPasscode(string digit) {
            if (_stackDigits.Count == PASSCODE_LENGTH)
                return;

            if (string.IsNullOrEmpty(FirstEntry)) {
                _stackDigits.Push(digit);
                FirstEntry = digit;
                return;
            }

            if (string.IsNullOrEmpty(SecondEntry)) {
                _stackDigits.Push(digit);
                SecondEntry = digit;
                return;
            }

            if (string.IsNullOrEmpty(ThirdEntry)) {
                _stackDigits.Push(digit);
                ThirdEntry = digit;
                return;
            }

            if (string.IsNullOrEmpty(FourthEntry)) {
                _stackDigits.Push(digit);
                FourthEntry = digit;
                return;
            }
        }

        public void Dispose() {
            _stackDigits.Clear();
        }
    }
}
