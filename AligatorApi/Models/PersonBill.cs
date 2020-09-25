using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AligatorApi.Models
{
    public class PersonBill
    {
        public int BillId { get; set; }
        public Bill Bill { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
