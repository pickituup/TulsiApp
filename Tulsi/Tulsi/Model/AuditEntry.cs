using System;
using System.Collections.Generic;

namespace Tulsi.Model {
    public  class AuditEntry {
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<AuditAction> AuditActions { get; set; }
    }
}
