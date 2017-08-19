using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.Model;
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public class ProfileViewModel {
        public List<ProfileTransaction> TransactionsData { get; set; }
        public ProfileViewModel() {
            TransactionsData = new List<ProfileTransaction>()
            {
                new ProfileTransaction { Code = "SKC", Number = "28", IsP=true, Quantity="8,200" },
                new ProfileTransaction { Code = "SKC", Number = "28", IsP=false, Quantity="8,200" },
                new ProfileTransaction{ Code = "SKC", Number = "28", IsP=true, Quantity="8,200" },
                new ProfileTransaction { Code = "SKC", Number = "28", IsP=true, Quantity="8,200" },
            };
        }
    }
}
