using System.Collections.Generic;
using Tulsi.Model.DataContainers.DataItems;
using Tulsi.NavigationFramework;

namespace Tulsi.Model.DataContainers {
    public sealed class ReportsMenuContainer {

        /// <summary>
        ///     Build reports menu.
        /// </summary>
        /// <returns></returns>
        public List<ReportsMenuItem> BuildReportsMenuItems() {
            return new List<ReportsMenuItem>() {
                new ReportsMenuItem {
                    Name = "BANK",
                    ViewType = ViewType.BankAccountsPage
                },
                new ReportsMenuItem {
                    Name = "GROWER",
                    ViewType = ViewType.GrowerPage
                },
                new ReportsMenuItem {
                    Name = "BUYER",
                    ViewType = ViewType.BuyerPage
                },
                new ReportsMenuItem {
                    Name = "ARRIVAL",
                    ViewType = ViewType.ArrivalPage
                },
                new ReportsMenuItem {
                    Name = "EXPENSES",
                    ViewType = ViewType.ExpensesPage
                },
                new ReportsMenuItem {
                    Name = "AUDIT LOG",
                    ViewType = ViewType.AuditLogPage
                }
            };
        }
    }
}
