using System;
using Tulsi.Model;

namespace Tulsi.NavigationFramework.NavigationArgs {
    public class NavigationImportedEventArgs : EventArgs {
        public ViewType ViewType { get; set; }

        public Contact Contact { get; set; }
    }
}
