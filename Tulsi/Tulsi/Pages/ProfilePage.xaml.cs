using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Xamarin.Forms;
using Tulsi.ViewModels;

namespace Tulsi {
    public partial class ProfilePage : ContentPage, IView {
        public ProfilePage() {
            InitializeComponent();

            ProfileViewModel pvm = new ProfileViewModel();

            //Toolbar taps
            TapGestureRecognizer tapGestureRecognizer1 = new TapGestureRecognizer();
            tapGestureRecognizer1.Tapped += (s, e) => {
                Application.Current.MainPage.Navigation.PopAsync();
            };
            HeaderBackIcon.GestureRecognizers.Add(tapGestureRecognizer1);
            HeaderCloseIcon.GestureRecognizers.Add(tapGestureRecognizer1);


        }
    }
}
