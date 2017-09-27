using System;
using System.Collections.Generic;
using Tulsi.Model.DataContainers.DataItems;

namespace Tulsi.Model {
    public class ArrivalTransaction {
        public DateTime Date { get; set; }

        public List<ArrivalItem> ArrivalTransactions { get; set; }
    }
}
