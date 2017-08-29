using System;

namespace Tulsi.NavigationFramework.NavigationArgs {
    public class NavigationImportedContentEventArgs : EventArgs {
        public string Title { get; set; }

        public ViewType ViewType { get; set; }
    }
}
