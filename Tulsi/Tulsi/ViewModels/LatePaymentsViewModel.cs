using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.ViewModels
{
    public class LatePaymentsViewModel
    {
        public List<LatePayment> LatePayments { get; set; }
        public LatePaymentsViewModel()
        {
            LatePayments = new List<LatePayment>()
            {
                new LatePayment { Name = "SKC Arjun", Amount=78000 },
                new LatePayment { Name = "DFC Mickey", Amount=78000 },
                new LatePayment { Name = "KK Nandu", Amount=78000 },
                new LatePayment { Name = "(M) Henu", Amount=78000 },
                new LatePayment { Name = "SF", Amount=78000 },
                new LatePayment { Name = "PJB", Amount=78000 },
            };
        }
    }
    public class LatePayment
    {
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
