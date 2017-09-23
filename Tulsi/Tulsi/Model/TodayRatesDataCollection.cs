using System;
using System.Collections.Generic;

namespace Tulsi.Model {
    public class TodayRatesDataCollection {
        public DateTime Date { get; set; }

        public List<TodayRatesEntry> TodayRates { get; set; }
    }
}
