using System;
using System.Collections.Generic;
using Tulsi.Model;
using Tulsi.NavigationFramework.NavigationArgs;

namespace Tulsi.NavigationFramework {
    public sealed class NavigationObserver {

        public event EventHandler<NavigationImportedEventArgs> ImportedSpot = delegate { };

        public event EventHandler<NavigationImportedContentEventArgs> NavigatedContent = delegate { };

        public event EventHandler CloseView = delegate { };

        public event EventHandler<GrowerProfileTransactionEventArgs> SendProfileTransAction = delegate { };

        public void OnSendProfileTransAction(List<ProfileTransaction> data) {
            SendProfileTransAction(this, new GrowerProfileTransactionEventArgs() { Data = data });
        }

        public void OnCloseView() => CloseView(this, new EventArgs());

        public void OnNavigatedContent(string title, ViewType viewType) {
            NavigatedContent(this, new NavigationImportedContentEventArgs() { Title = title, ViewType = viewType });
        }

        public void OnImportedSpot(ViewType viewType) => ImportedSpot(this, new NavigationImportedEventArgs() { ViewType = viewType });
    }
}
