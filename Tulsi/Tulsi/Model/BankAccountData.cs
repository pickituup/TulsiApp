using System;
using System.Collections.Generic;

namespace Tulsi.Model {
    public class BankAccountData {
        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<BankAccountEntry> Data { get; set; }
    }
}
