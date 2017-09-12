using System;
using System.Collections.Generic;

namespace Tulsi.Model {
    public class ColdStoreData {
        public DateTime Date { get; set; }

        public List<ColdStoreEntry> Data { get; set; }
    }
}
