using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Tulsi.ViewModels.Content;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamForms.Controls;

namespace Tulsi.Pages.Content {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArrivalView : ContentView, IView {

        private readonly ArrivalViewModel _viewModel;

        public ArrivalView() {
            InitializeComponent();

            BindingContext = _viewModel = new ArrivalViewModel();

            CalendarInitialization();
        }

        private void CalendarInitialization() {
            arrivalCalendar.StartDay = DayOfWeek.Sunday;
            // title
            arrivalCalendar.TitleLabelTextColor = Color.FromHex("#2793F5");
            // dates
            arrivalCalendar.DatesBackgroundColor = Color.White;
            arrivalCalendar.DatesBackgroundColorOutsideMonth = Color.White;
            arrivalCalendar.DatesTextColor = Color.FromHex("#999999");
            arrivalCalendar.DatesFontSize = 12;
            arrivalCalendar.DatesTextColorOutsideMonth = Color.White;
            // weekdays
            arrivalCalendar.WeekdaysFontSize = 14;
            arrivalCalendar.WeekdaysFontAttributes = FontAttributes.Bold;
            arrivalCalendar.WeekdaysTextColor = Color.FromHex("#999999");
            arrivalCalendar.WeekdaysShow = true;
            arrivalCalendar.WeekdaysBackgroundColor = Color.White;
            // left arrow
            arrivalCalendar.TitleLeftArrowTextColor = Color.FromHex("#2793F5");
            // right arrow
            arrivalCalendar.TitleRightArrowTextColor = Color.FromHex("#2793F5");
            // borders
            arrivalCalendar.BorderWidth = 0;
            arrivalCalendar.OuterBorderWidth = 0;
            arrivalCalendar.SelectedBorderWidth = 0;
            arrivalCalendar.SelectedTextColor = Color.White;
            arrivalCalendar.SelectedBackgroundColor = Color.FromHex("#2793F5");


            List<SpecialDate> specialDates = new List<SpecialDate>();
            SpecialDate event1 = new SpecialDate(new DateTime(2017, 1, 24));
            event1.BackgroundColor = Color.FromHex("#82DA69");
            event1.Selectable = true;

            SpecialDate event2 = new SpecialDate(new DateTime(2017, 1, 26));
            event2.BackgroundColor = Color.FromHex("#9E7AE6");
            event2.Selectable = true;

            specialDates.Add(event1);
            specialDates.Add(event2);
            arrivalCalendar.SpecialDates = specialDates;
            arrivalCalendar.DateClicked += ArrivalCalendar_DateClicked;
        }

        private void ArrivalCalendar_DateClicked(object sender, DateTimeEventArgs e) {
            _viewModel.DisplayMessage("Date", e.DateTime.Date.ToString() + " selected", "OK");
        }

        public void ApplyVisualChangesWhileNavigating() {
        }

        public void Dispose() {
            _viewModel.Dispose();
        }
    }
}