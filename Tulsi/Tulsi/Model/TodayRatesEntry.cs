using System;
using System.Collections.Generic;

namespace Tulsi.Model {
    public class TodayRatesEntry {

        public DateTime Date { get; set; }

        public string GroupName { get; set; }

        public int Sum { get; set; }

        public List<TodayRatesSubItem> Items { get; set; }
    }
}
