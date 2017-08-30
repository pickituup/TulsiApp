using System;
using System.Collections.Generic;

namespace Tulsi.Model {
    public sealed class Transaction {
        public string Name { get; set; }

        public int TCases { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public List<ProfileTransaction> ProfileTransactions { get; set; }
    }
}
