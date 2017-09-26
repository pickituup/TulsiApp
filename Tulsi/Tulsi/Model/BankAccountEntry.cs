using System;
using Xamarin.Forms;

namespace Tulsi.Model {
    public class BankAccountEntry {

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Boxes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Ammounted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsPendingRates { get; set; }
    }
}
