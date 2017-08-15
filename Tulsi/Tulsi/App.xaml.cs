using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;
using Tulsi.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Tulsi
{
    public partial class App : Application
    {
        public AuditLogViewModel AuditLogVM;
        public BuyerViewModel BuyerVM;
        public BuyerRankingsViewModel BuyerRankingsVM;
        public DashboardViewModel DashboardVM;
        public ExpensesViewModel ExpensesVM;
        public GrowerViewModel GrowerVM;
        public LadaanViewModel LadaanVM;
        public LatePaymentsViewModel LatePaymentsVM;
        public ProfileViewModel ProfileVM;
        public ProfitViewModel ProfitVM;
        public SearchViewModel SearchVM;
        public StockPendingDetailsViewModel StockPendingDetailsVM;
        public TodayRatesViewModel TodayRatesVM;
        public SideMenuView SideMenu;

        public App()
        {
            InitializeComponent();

            //ViewModels
            AuditLogVM = new AuditLogViewModel();
            BuyerVM = new BuyerViewModel();
            BuyerRankingsVM = new BuyerRankingsViewModel();
            DashboardVM = new DashboardViewModel();
            ExpensesVM = new ExpensesViewModel();
            GrowerVM = new GrowerViewModel();
            LadaanVM = new LadaanViewModel();
            LatePaymentsVM = new LatePaymentsViewModel();
            ProfileVM = new ProfileViewModel();
            ProfitVM = new ProfitViewModel();
            SearchVM = new SearchViewModel();
            StockPendingDetailsVM = new StockPendingDetailsViewModel();
            TodayRatesVM = new TodayRatesViewModel();

            //Menu
            SideMenu = new SideMenuView();

            /*LoginPage lp = new LoginPage();
            DashboardPage dp = new DashboardPage();
            PasswordRecoveryPage prp = new PasswordRecoveryPage();
            PasscodePage pcp = new PasscodePage();
            LadaanPage lap = new LadaanPage();
            TodayRatesPage trp = new TodayRatesPage();
            ChatPage cp = new ChatPage();
            ProfitPage pp = new ProfitPage();
            ExpensesListPage ep = new ExpensesListPage();
            BankAccountsPage bp = new BankAccountsPage();
            BankAccountDetailsPage bdp = new BankAccountDetailsPage();
            ArrivalPage ap = new ArrivalPage();
            ArrivalDetailsPage adp = new ArrivalDetailsPage();
            GrowerProfilePage gpp = new GrowerProfilePage();
            BuyerProfilePage bpp = new BuyerProfilePage();
            LatePaymentsPage lpp = new LatePaymentsPage();
            BuyerRankingsPage brp = new BuyerRankingsPage();
            SearchPage sp = new SearchPage();
            StockPendingPage spp = new StockPendingPage();
            StockPendingDetailsPage spdp = new StockPendingDetailsPage();
            SetupDashboardPage sdp = new SetupDashboardPage();
            NewsPage np = new NewsPage();*/

            DashboardPage dp = new DashboardPage();
            LoginPage lp = new LoginPage();
            MainPage = new NavigationPage(lp);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
    public interface IDisplaySize
    {
        int GetWidth();
        int GetHeight();
        int GetWidthDiP();
        int GetHeightDiP();
        float GetDensity();
    }
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(Source);

            return imageSource;
        }
    }
    public class ProfileTransactionImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return ImageSource.FromResource("Tulsi.Images.ptransaction.png");
            }
            else
            {
                return ImageSource.FromResource("Tulsi.Images.dtransaction.png");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
