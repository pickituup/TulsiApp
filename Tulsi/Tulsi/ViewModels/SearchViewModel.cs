using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.ViewModels
{
    public class SearchViewModel
    {
        public bool IsBuyers { get; set; }
        public List<string> Result { get; set; }

        public SearchViewModel()
        {
            Result = new List<string>();
            Result.Add("SKC Arjun");
            Result.Add("MCK Irfan");
            Result.Add("VB Bitto");
            Result.Add("MFC Vickey");
        }
    }
}
