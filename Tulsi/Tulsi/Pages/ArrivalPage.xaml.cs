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
using System.Reflection;
using System.IO;

namespace Tulsi {
    public partial class ArrivalPage : ContentPage, IView {

        private readonly ArrivalPageViewModel _viewModel;

        public ArrivalPage() {
            InitializeComponent();

            BindingContext = _viewModel = new ArrivalPageViewModel();

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

        public void ApplyVisualChangesWhileNavigating() {

        }

        private void ArrivalCalendar_DateClicked(object sender, DateTimeEventArgs e) {
            DisplayAlert("Date", e.DateTime.Date.ToString() + " selected", "OK");
        }

        public void Dispose() {
            _viewModel.Dispose();
        }

        public void ReSubscribe() {
            
        }
    }
}
