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
                    ViewType = ViewType.BankAccountsView
                },
                new ReportsMenuItem {
                    Name = "GROWER",
                    ViewType = ViewType.GrowerView
                },
                new ReportsMenuItem {
                    Name = "BUYER",
                    ViewType = ViewType.BuyerView
                },
                new ReportsMenuItem {
                    Name = "ARRIVAL",
                    ViewType = ViewType.ArrivalView
                },
                new ReportsMenuItem {
                    Name = "EXPENSES",
                    ViewType = ViewType.ExpensesView
                },
                new ReportsMenuItem {
                    Name = "AUDIT LOG",
                    ViewType = ViewType.AuditLogView
                }
            };
        }
    }
}
