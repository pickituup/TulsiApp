using System;
using System.Collections.Generic;

namespace Tulsi.Model {
    public  class AuditEntry {
        public DateTime Date { get; set; }

        public List<AuditAction> AuditActions { get; set; }
    }
}
