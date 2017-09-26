using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.MVVM.Core;
using Tulsi.SharedService;
using Xamarin.Forms;

namespace Tulsi.ViewModels.Content {
    public sealed class PasscodeViewModel : ViewModelBase, IViewModel {

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
        public PasscodeViewModel() {
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

            if (_stackDigits.Count == PASSCODE_LENGTH)
                SavePasscode();
        }

        private async void SavePasscode() {
            string res = string.Empty;
            foreach (var item in _stackDigits) {
                res = item + res;
            }

            int.TryParse(res, out int pin);
            DependencyService.Get<ISQLiteService>().SetPin(pin);

            await DisplayAlert("State", "Saved", "Ok");

            ReEnterPasscode();
        }

        private void ReEnterPasscode() {
            ClearImputCell();
        }

        private void ClearImputCell() {
            FirstEntry = string.Empty;
            SecondEntry = string.Empty;
            ThirdEntry = string.Empty;
            FourthEntry = string.Empty;
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
        }
    }
}
