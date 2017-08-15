using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.ViewModels
{
    public class AuditLogViewModel
    {
        public List<AuditEntry> AuditData { get; set; }
        public AuditLogViewModel()
        {
            AuditData = new List<AuditEntry>()
            {
                new AuditEntry { Action = "Modified Buyer", Code = "SKC" },
                new AuditEntry { Action = "Changed Rates", Code = "SKC" },
                new AuditEntry { Action = "Deposit Received", Code = "MKC" },
                new AuditEntry { Action = "Modified Buyer", Code = "SKC" },
                new AuditEntry { Action = "Changed Rates", Code = "SKC" },
                new AuditEntry { Action = "Deposit Received", Code = "MKC" },
            };
        }
    }


    public class AuditEntry
    {
        public string Action { get; set; }
        public string Code { get; set; }
    }
}
