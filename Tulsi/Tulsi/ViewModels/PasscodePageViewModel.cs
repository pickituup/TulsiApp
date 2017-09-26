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

        private const string TITLE = "SECURITY PIN";

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

        public ICommand DisplayForgotPasscodePageCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public PasscodePageViewModel() {
            Title = TITLE;

            VisibilityBullets = true;

            DisplayForgotPasscodePageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.ForgotPasscodePage));

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
