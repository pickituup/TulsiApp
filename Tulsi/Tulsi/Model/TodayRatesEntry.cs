using System.Collections.Generic;

namespace Tulsi.Model {
    public class TodayRatesEntry {
        /// <summary>
        /// Public ctor.
        /// </summary>
        public TodayRatesEntry() {
            Items = new List<TodayRatesSubItem>();
        }

        /// <summary>
        /// 
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Sum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<TodayRatesSubItem> Items { get; private set; }
    }
}
