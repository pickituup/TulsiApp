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

        private const string RE_ENTER_PIN = "RE-ENTER PIN";

        private const string NEW_PIN = "ENTER NEW PASSCODE";

        private const int PASSCODE_LENGTH = 4;

        private Stack<string> _stackDigits = new Stack<string>();

        bool _visibilityBullets;
        public bool VisibilityBullets {
            get { return _visibilityBullets; }
            set { SetProperty(ref _visibilityBullets, value); }
        }

        bool _firstIcon;
        public bool FirstIcon {
            get { return _firstIcon; }
            set { SetProperty(ref _firstIcon, value); }
        }

        bool _secondIcon;
        public bool SecondIcon {
            get { return _secondIcon; }
            set { SetProperty(ref _secondIcon, value); }
        }

        bool _thirdIcon;
        public bool ThirdIcon {
            get { return _thirdIcon; }
            set { SetProperty(ref _thirdIcon, value); }
        }

        bool _fourthIcon;
        public bool FourthIcon {
            get { return _fourthIcon; }
            set { SetProperty(ref _fourthIcon, value); }
        }

        string _title;
        public string Title {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

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
            Title = NEW_PIN;

            ButtonInputCommand = new Command(OnInputedDigit);

            CleanDigitCommand = new Command(OnCleanDigit);
        }

        private void OnCleanDigit() {
            if (_stackDigits.Count == 0)
                return;

            if (!string.IsNullOrEmpty(FourthEntry)) {
                _stackDigits.Pop();
                FourthEntry = string.Empty;
                if (VisibilityBullets)
                    FourthIcon = false;
                return;
            }

            if (!string.IsNullOrEmpty(ThirdEntry)) {
                _stackDigits.Pop();
                ThirdEntry = string.Empty;
                if (VisibilityBullets)
                    ThirdIcon = false;
                return;
            }

            if (!string.IsNullOrEmpty(SecondEntry)) {
                _stackDigits.Pop();
                SecondEntry = string.Empty;
                if (VisibilityBullets)
                    SecondIcon = false;
                return;
            }

            if (!string.IsNullOrEmpty(FirstEntry)) {
                _stackDigits.Pop();
                FirstEntry = string.Empty;
                if (VisibilityBullets)
                    FirstIcon = false;
                return;
            }
        }

        private void OnInputedDigit(object obj) {
            SetPasscode((string)obj);

            if (!DependencyService.Get<ISQLiteService>().IsPasscodeExist()) {
                if (_stackDigits.Count == PASSCODE_LENGTH)
                    SavePasscode();
            } else {
                if (_stackDigits.Count == PASSCODE_LENGTH) {
                    ConfirmPasscode();
                }
            }
        }

        private void ConfirmPasscode() {
            string result = string.Empty;
            foreach (var item in _stackDigits) {
                result = item + result;
            }

            int.TryParse(result, out int pin);
            bool valid = DependencyService.Get<ISQLiteService>().CheckPin(pin);

            AutoExitView(valid);
        }

        private async void AutoExitView(bool valid) {
            if (valid) {
                MessagingCenter.Send("autohide", "exitView");
                ClearViewData();
            } else {
                await DisplayAlert("WARNING", "Please re-enter passcode", "ok");
            }
        }

        private void ClearViewData() {
            Title = NEW_PIN;
            _stackDigits.Clear();
            VisibilityBullets = false;
            ClearImputCell();
            ClearIconCell();
        }

        private void ClearIconCell() {
            FirstIcon = false;
            SecondIcon = false;
            ThirdIcon = false;
            FourthIcon = false;
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
            Title = RE_ENTER_PIN;
            _stackDigits.Clear();
            ClearImputCell();
            VisibilityBullets = true;
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
                if (VisibilityBullets)
                    FirstIcon = true;
                return;
            }

            if (string.IsNullOrEmpty(SecondEntry)) {
                _stackDigits.Push(digit);
                SecondEntry = digit;
                if (VisibilityBullets)
                    SecondIcon = true;
                return;
            }

            if (string.IsNullOrEmpty(ThirdEntry)) {
                _stackDigits.Push(digit);
                ThirdEntry = digit;
                if (VisibilityBullets)
                    ThirdIcon = true;
                return;
            }

            if (string.IsNullOrEmpty(FourthEntry)) {
                _stackDigits.Push(digit);
                FourthEntry = digit;
                if (VisibilityBullets)
                    FourthIcon = true;
                return;
            }
        }

        public void Dispose() {
            _stackDigits.Clear();
        }
    }
}
