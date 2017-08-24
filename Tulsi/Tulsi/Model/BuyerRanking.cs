using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.Model {
    public sealed class BuyerRanking {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsUp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Change { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ProfileTransaction> ProfileTransactions { get; set; }
    }
}