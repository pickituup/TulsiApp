using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamForms.Controls;
using SlideOverKit;

namespace Tulsi
{
    public partial class ArrivalPage : MenuContainerPage
    {
        public ArrivalPage()
        {
            InitializeComponent();

            int hd = DependencyService.Get<IDisplaySize>().GetHeightDiP();
            AbsoluteLayout.SetLayoutBounds(SideMenuOverlay, new Rectangle(0, 0, 0.9, hd - 20));
            
            CalendarArea.Source = ImageSource.FromResource("Tulsi.Images.calendar_background.png");
            DatesArea.Source = ImageSource.FromResource("Tulsi.Images.dates_background.png");
            c1.Source = ImageSource.FromResource("Tulsi.Images.datesbluecircle.png");
            c2.Source = ImageSource.FromResource("Tulsi.Images.datesbluecircle.png");
            c3.Source = ImageSource.FromResource("Tulsi.Images.datesbluecircle.png");

            cg.Source = ImageSource.FromResource("Tulsi.Images.greencircle.png");
            cp1.Source = ImageSource.FromResource("Tulsi.Images.purplecircle.png");
            cp2.Source = ImageSource.FromResource("Tulsi.Images.purplecircle.png");
            cp3.Source = ImageSource.FromResource("Tulsi.Images.purplecircle.png");

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


            //Slide menu creating
            SlideMenu = ((App)Application.Current).SideMenu;

            //Toolbar taps
            TapGestureRecognizer ToolbarTap1 = new TapGestureRecognizer();
            ToolbarTap1.Tapped += (s, e) =>
            {
                this.ShowMenu();
            };
            Menu.GestureRecognizers.Add(ToolbarTap1);

            TapGestureRecognizer ToolbarTap2 = new TapGestureRecognizer();
            ToolbarTap2.Tapped += (s, e) =>
            {
                SearchPage sp = new SearchPage();
                Application.Current.MainPage.Navigation.PushAsync(sp);
            };
            Search.GestureRecognizers.Add(ToolbarTap2);

            //In page navigation
            TapGestureRecognizer InPageNavigationTap1 = new TapGestureRecognizer();
            InPageNavigationTap1.Tapped += (s, e) =>
            {
                ArrivalDetailsPage adp = new ArrivalDetailsPage();
                Application.Current.MainPage.Navigation.PushAsync(adp);
            };
            DateArrivalsList.GestureRecognizers.Add(InPageNavigationTap1);
            
        }
        private void ArrivalCalendar_DateClicked(object sender, DateTimeEventArgs e)
        {
            DisplayAlert("Date", e.DateTime.Date.ToString() + " selected", "OK");
        }

    }
}
