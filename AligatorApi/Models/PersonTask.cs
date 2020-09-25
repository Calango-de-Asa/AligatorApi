using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AligatorApi.Models
{
    public class PersonTask
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
