using System;
using System.Collections.Generic;
using Tulsi.Model;

namespace Tulsi.NavigationFramework.NavigationArgs {
    public sealed class GrowerProfileTransactionEventArgs : EventArgs {
        public List<ProfileTransaction> Data { get; set; }
    }
}
