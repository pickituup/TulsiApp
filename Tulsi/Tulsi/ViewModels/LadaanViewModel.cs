using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.ViewModels
{
    public class LadaanViewModel
    {
        public List<LadaanEntry> LadaanData { get; set; }
        public LadaanViewModel()
        {
            LadaanData = new List<LadaanEntry>()
            {
                new LadaanEntry { Code = "NS Cuttack", Number = "285 Cases" },
                new LadaanEntry { Code = "SFT Bharampur", Number = "285 Cases" },
                new LadaanEntry { Code = "AR Cuttack", Number = "285 Cases" },
                new LadaanEntry { Code = "NS Cuttack", Number = "285 Cases" },
                new LadaanEntry { Code = "SFT Bharampur", Number = "285 Cases" },
                new LadaanEntry { Code = "AR Cuttack", Number = "285 Cases" },
                new LadaanEntry { Code = "SFT Bharampur", Number = "285 Cases" },
                new LadaanEntry { Code = "AR Cuttack", Number = "285 Cases" },
                new LadaanEntry { Code = "SFT Bharampur", Number = "285 Cases" },
            };
        }
    }
    public class LadaanEntry
    {
        public string Code { get; set; }
        public string Number { get; set; }
    }
}
