using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tulsi.ViewModels
{
    public class ProfileViewModel
    {
        public List<ProfileTransaction> TransactionsData { get; set; }
        public ProfileViewModel()
        {
            TransactionsData = new List<ProfileTransaction>()
            {
                new ProfileTransaction { Code = "SKC", Number = "28", IsP=true, Quantity="8,200" },
                new ProfileTransaction { Code = "SKC", Number = "28", IsP=false, Quantity="8,200" },
                new ProfileTransaction{ Code = "SKC", Number = "28", IsP=true, Quantity="8,200" },
                new ProfileTransaction { Code = "SKC", Number = "28", IsP=true, Quantity="8,200" },
            };
        }
    }
    public class ProfileTransaction
    {
        public string Code { get; set; }
        public string Number { get; set; }
        public bool IsP { get; set; }
    public string Quantity { get; set; }
    }
}
