using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tulsi.NavigationFramework {
    public sealed class ViewContainer {
        private static readonly string _ERROR_CANT_GET_VIEW_IN_NAVIGATION_FRAME_BY_TYPE = "Can't get view in navigation frame by it's type",
            _ERROR_CANT_GET_VIEW_BY_TYPE = "Can't get view by it's type";

        /// <summary>
        /// Container for views wrapped by Xamarin.Forms.NavigationPage
        /// </summary>
        private readonly Dictionary<ViewType, Func<Page>> _viewsInNavigationFrame;

        /// <summary>
        /// Container for views
        /// </summary>
        private readonly Dictionary<ViewType, Func<IView>> _views;

        /// <summary>
        /// Public ctor
        /// </summary>
        public ViewContainer() {
            _views = buildViews();
            _viewsInNavigationFrame = buildViewsInNavigationFrames();
        }

        /// <summary>
        /// Get view in navigation frame by type.
        /// </summary>
        /// <param name="viewType"></param>
        /// <returns></returns>
        public Page GetViewInNavigationFrameByType(ViewType viewType) {
            try {
                return _viewsInNavigationFrame[viewType]();
            }
            catch (Exception) {
                throw new InvalidOperationException(string.Format("ViewContainer.GetViewInNavigationFrameByType - {0}", _ERROR_CANT_GET_VIEW_IN_NAVIGATION_FRAME_BY_TYPE));
            }
        }

        /// <summary>
        /// Get view by type
        /// </summary>
        /// <param name="viewType"></param>
        /// <returns></returns>
        public IView GetViewByType(ViewType viewType) {
            try {
                return _views[viewType]();
            }
            catch (Exception) {
                throw new InvalidOperationException(string.Format("ViewContainer.GetViewByType - {0}", _ERROR_CANT_GET_VIEW_BY_TYPE));
            }
        }

        /// <summary>
        /// Build views wrapped by Xamarin.Forms.NavigationPage
        /// </summary>
        /// <returns></returns>
        private Dictionary<ViewType, Func<Page>> buildViewsInNavigationFrames() {
            return new Dictionary<ViewType, Func<Page>>() {
                {
                    ViewType.LoginPage,
                    () => new ViewBuider<LoginPage>().GetViewInNavigationFrame()
                },
                {
                    ViewType.DashboardPage,
                    () => new ViewBuider<DashboardPage>().GetViewInNavigationFrame()
                }
            };
        }

        /// <summary>
        /// Build views
        /// </summary>
        /// <returns></returns>
        private Dictionary<ViewType, Func<IView>> buildViews() {
            return new Dictionary<ViewType, Func<IView>>() {
                {
                    ViewType.LoginPage,
                    () => new ViewBuider<LoginPage>().GetView()
                },
                {
                    ViewType.DashboardPage,
                    () => new ViewBuider<DashboardPage>().GetView()
                },
                {
                    ViewType.PasswordRecoveryPage,
                    () => new ViewBuider<PasswordRecoveryPage>().GetView()
                },
                {
                    ViewType.ProfitPage,
                    () => new ViewBuider<ProfitPage>().GetView()
                },
                {
                    ViewType.BuyerPage,
                    () => new ViewBuider<BuyerPage>().GetView()
                },
                {
                    ViewType.GrowerPage,
                    () => new ViewBuider<GrowerPage>().GetView()
                },
                {
                    ViewType.AuditLogPage,
                    () => new ViewBuider<AuditLogPage>().GetView()
                },
                {
                    ViewType.ReportsPage,
                    () => new ViewBuider<ReportsPage>().GetView()
                },
                {
                    ViewType.ChatPage,
                    () => new ViewBuider<ChatPage>().GetView()
                },
                {
                    ViewType.SettingsPage,
                    () => new ViewBuider<SettingsPage>().GetView()
                },
                {
                    ViewType.ProfilePage,
                    () => new ViewBuider<ProfilePage>().GetView()
                },
                {
                    ViewType.SearchPage,
                    () => new ViewBuider<SearchPage>().GetView()
                },
                {
                    ViewType.LadaanPage,
                    () => new ViewBuider<LadaanPage>().GetView()
                },
                {
                    ViewType.TodayRatePage,
                    () => new ViewBuider<TodayRatesPage>().GetView()
                },
                {
                    ViewType.BuyerRankingsPage,
                    () => new ViewBuider<BuyerRankingsPage>().GetView()
                },
                {
                    ViewType.LatePaymentsPage,
                    () => new ViewBuider<LatePaymentsPage>().GetView()
                },
                {
                    ViewType.BuyerProfilePage,
                    () => new ViewBuider<BuyerProfilePage>().GetView()
                },
                {
                    ViewType.GrowerProfilePage,
                    () => new ViewBuider<GrowerProfilePage>().GetView()
                },
                {
                    ViewType.BankAccountsPage,
                    () => new ViewBuider<BankAccountsPage>().GetView()
                },
                {
                    ViewType.ArrivalPage,
                    () => new ViewBuider<ArrivalPage>().GetView()
                },
                {
                    ViewType.ExpensesPage,
                    () => new ViewBuider<ExpensesPage>().GetView()
                },
                {
                    ViewType.ArrivalDetailPage,
                    () => new ViewBuider<ArrivalDetailsPage>().GetView()
                },
                {
                    ViewType.BankAccountDetailsPage,
                    () => new ViewBuider<BankAccountDetailsPage>().GetView()
                },
                {
                    ViewType.SetupDashboardPage,
                    () => new ViewBuider<SetupDashboardPage>().GetView()
                },
                {
                    ViewType.ExpensesListPage,
                    () => new ViewBuider<ExpensesListPage>().GetView()
                }
            };
        }
    }
}