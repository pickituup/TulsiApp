using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.NavigationFramework {
    public enum ViewType {
        /// <summary>
        ///     Base login page
        /// </summary>
        LoginPage,

        /// <summary>
        ///     Base password recovery page
        /// </summary>
        PasswordRecoveryPage,

        /// <summary>
        ///     'Main' dashboard page
        /// </summary>
        DashboardPage,

        /// <summary>
        ///     ProfitPage
        /// </summary>
        ProfitPage,

        /// <summary>
        ///     BuyerPage
        /// </summary>
        BuyerPage,

        /// <summary>
        ///     GrowerPage
        /// </summary>
        GrowerPage,

        /// <summary>
        ///     AuditLogPage
        /// </summary>
        AuditLogPage,

        /// <summary>
        ///     ReportsPage
        /// </summary>
        ReportsPage,

        /// <summary>
        /// ChatPage
        /// </summary>
        ChatPage,

        /// <summary>
        ///     SettingsPage
        /// </summary>
        SettingsPage,

        /// <summary>
        ///     ProfilePage
        /// </summary>
        ProfilePage,

        /// <summary>
        ///     SearchPage
        /// </summary>
        SearchPage,

        /// <summary>
        ///     Ladaan page.
        /// </summary>
        LadaanPage,

        /// <summary>
        ///     Today rate page
        /// </summary>
        TodayRatesPage,

        /// <summary>
        /// BuyerRankingsPage
        /// </summary>
        BuyerRankingsPage,

        /// <summary>
        /// LatePaymentsPage
        /// </summary>
        LatePaymentsPage,

        /// <summary>
        /// BuyerProfilePage
        /// </summary>
        BuyerProfilePage,

        /// <summary>
        ///     Grower profile page.
        /// </summary>
        GrowerProfilePage,

        /// <summary>
        ///     Bank accounts page.
        /// </summary>
        BankAccountsPage,

        /// <summary>
        ///     Arrival page
        /// </summary>
        ArrivalPage,

        /// <summary>
        ///     Expenses page
        /// </summary>
        ExpensesPage,

        /// <summary>
        ///     Arrival detail page.
        /// </summary>
        ArrivalDetailsPage,

        /// <summary>
        ///     BankAccountDetailsPage
        /// </summary>
        BankAccountDetailsPage,

        /// <summary>
        ///     SetupDashboard page.
        /// </summary>
        SetupDashboardPage,

        /// <summary>
        ///     ExpensesListPage
        /// </summary>
        ExpensesListPage,

        /// <summary>
        ///     TODO: maby define separated enum of IView views.
        ///     Buyer profile view.
        /// </summary>
        BuyerProfileView,

        /// <summary>
        ///     Grower profile view.
        /// </summary>
        GrowerProfileView,

        ReportsIntermediatePage,

        BankAccountsView,

        GrowerView,

        BuyerView,

        ArrivalView,

        ExpensesView,

        AuditLogView,

        AuditLogDetailsPage,

        TutorialPage,

        WelcomePage,

        ExpensesCarouselView,

        ExpensesListView,

        ColdStorePage,

        GodownPage,

        /// <summary>
        /// AddReportsAccess page
        /// </summary>
        AddReportAccessPage,

        PasscodePage,

        PasscodeView
    }
}
