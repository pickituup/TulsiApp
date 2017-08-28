using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.Model {
    public class ContactGroup : List<Contact> {

        /// <summary>
        /// 
        /// </summary>
        public string FirstLetter { get; set; }
    }
}
