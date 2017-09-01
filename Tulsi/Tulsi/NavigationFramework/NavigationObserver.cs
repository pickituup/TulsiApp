using System;
using System.Collections.Generic;
using Tulsi.Model;
using Tulsi.NavigationFramework.NavigationArgs;

namespace Tulsi.NavigationFramework {
    public sealed class NavigationObserver {
        
        public event EventHandler<NavigationImportedEventArgs> ReportsImportedSpot = delegate { };

        public event EventHandler<NavigationImportedEventArgs> BuyerRankingsImportedSpot = delegate { };
        
        public event EventHandler<NavigationImportedEventArgs> GrowerImportedSpot = delegate { };

        public event EventHandler<NavigationImportedEventArgs> GrowerViewImportedSpot = delegate { };

        public event EventHandler<NavigationImportedEventArgs> BayerImportedSpot = delegate { };

        public event EventHandler<NavigationImportedEventArgs> BayerViewImportedSpot = delegate { };

        public event EventHandler<NavigationImportedEventArgs> LatePaymentsImportedSpot = delegate { };

        public event EventHandler<NavigationImportedContentEventArgs> NavigatedContent = delegate { };

        public event EventHandler CloseView = delegate { };

        public event EventHandler PressNativeBackButton = delegate { };

        public event EventHandler<ProfileTransactionEventArgs> SendToBuyerProfileTransAction = delegate { };

        public event EventHandler<ProfileTransactionEventArgs> SendToGrowerProfileTransAction = delegate { };

        public void OnPressNativeBackButton() => PressNativeBackButton(this, new EventArgs());

        public void OnSendToBuyerProfileTransAction(List<ProfileTransaction> data) {
            SendToBuyerProfileTransAction(this, new ProfileTransactionEventArgs() { Data = data });
        }

        public void OnSendToGrowerProfileTransAction(List<ProfileTransaction> data) {
            SendToGrowerProfileTransAction(this, new ProfileTransactionEventArgs() { Data = data });
        }

        public void OnCloseView() => CloseView(this, new EventArgs());

        public void OnNavigatedContent(string title, ViewType viewType) {
            NavigatedContent(this, new NavigationImportedContentEventArgs() { Title = title, ViewType = viewType });
        }

        public void OnReportsImportedSpot(ViewType viewType)
            => ReportsImportedSpot(this, new NavigationImportedEventArgs() { ViewType = viewType });

        public void OnBuyerRankingsImportedSpot(ViewType viewType)
            => BuyerRankingsImportedSpot(this, new NavigationImportedEventArgs() { ViewType = viewType });

        public void OnGrowerViewImportedSpot(ViewType viewType)
            => GrowerViewImportedSpot(this, new NavigationImportedEventArgs() { ViewType = viewType });

        public void OnGrowerImportedSpot(ViewType viewType)
            => GrowerImportedSpot(this, new NavigationImportedEventArgs() { ViewType = viewType });

        public void OnBayerViewImportedSpot(ViewType viewType)
            => BayerViewImportedSpot(this, new NavigationImportedEventArgs() { ViewType = viewType });

        public void OnBayerImportedSpot(ViewType viewType)
            => BayerImportedSpot(this, new NavigationImportedEventArgs() { ViewType = viewType });

        public void OnLatePaymentsImportedSpot(ViewType viewType)
            => LatePaymentsImportedSpot(this, new NavigationImportedEventArgs() { ViewType = viewType });
    }
}
