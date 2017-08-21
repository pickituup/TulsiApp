using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamForms.Controls;
using SlideOverKit;
using Tulsi.SharedService;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using Tulsi.ViewModels;

namespace Tulsi {
    public partial class ArrivalPage : MenuContainerPage, IView {

        private readonly ArrivalViewModel _viewModel;

        public ArrivalPage() {
            InitializeComponent();

            //Slide menu creating
            SlideMenu = new SideMenuView();

            BindingContext = _viewModel = new ArrivalViewModel();

            //Calendar initialization
            ArrivalCalendar.DatesBackgroundColor = Color.FromHex("#F3F3F3");
            ArrivalCalendar.DatesFontSize = 12;
            ArrivalCalendar.WeekdaysFontSize = 12;
            ArrivalCalendar.BorderWidth = 0;
            ArrivalCalendar.DisabledBorderWidth = 0;
            ArrivalCalendar.OuterBorderWidth = 0;
            ArrivalCalendar.SelectedBorderWidth = 1;
            ArrivalCalendar.WeekdaysShow = false;

            List<SpecialDate> Dates = new List<SpecialDate>();
            SpecialDate event1 = new SpecialDate(new DateTime(2017, 1, 24));
            event1.BackgroundColor = Color.FromHex("#82DA69");
            event1.Selectable = true;

            SpecialDate event2 = new SpecialDate(new DateTime(2017, 1, 26));
            event2.BackgroundColor = Color.FromHex("#9E7AE6");
            event2.Selectable = true;

            Dates.Add(event1);
            Dates.Add(event2);
            ArrivalCalendar.SpecialDates = Dates;
            ArrivalCalendar.DateClicked += ArrivalCalendar_DateClicked;

            //In page navigation
            TapGestureRecognizer InPageNavigationTap1 = new TapGestureRecognizer();
            InPageNavigationTap1.Tapped += (s, e) => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.ArrivalDetailPage);
            };
            DateArrivalsList.GestureRecognizers.Add(InPageNavigationTap1);

        }

        // Show side menu.
        private void ShowMenuCommand(object sender, EventArgs e) {
            ShowMenu();
        }


        // Auto hide side menu when navigate back for this page.
        public void ApplyVisualChangesWhileNavigating() {
            SlideMenu.HideWithoutAnimations();
        }

        private void ArrivalCalendar_DateClicked(object sender, DateTimeEventArgs e) {
            DisplayAlert("Date", e.DateTime.Date.ToString() + " selected", "OK");
        }
    }
}
