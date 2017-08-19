using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.Model;
using Tulsi.MVVM.Core;

namespace Tulsi.ViewModels {
    public sealed class BuyerProfileViewModel : ViewModelBase {
        /// <summary>
        /// Public ctor.
        /// </summary>
        public BuyerProfileViewModel() {
            TransactionsData = new List<ProfileTransaction>()
            {
                new ProfileTransaction { Code = "SKC", Number = "28", IsP=true, Quantity="8,200" },
                new ProfileTransaction { Code = "SKC", Number = "28", IsP=false, Quantity="8,200" },
                new ProfileTransaction{ Code = "SKC", Number = "28", IsP=true, Quantity="8,200" },
                new ProfileTransaction { Code = "SKC", Number = "28", IsP=true, Quantity="8,200" },
            };
        }
        
        /// <summary>
        /// 
        /// </summary>
        public List<ProfileTransaction> TransactionsData { get; set; }
    }
}
