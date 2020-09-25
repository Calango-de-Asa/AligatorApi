
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AligatorApi.Models
{
    public class Bill
    {
        public Bill()
        {
            PersonBills = new HashSet<PersonBill>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(60)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueTime { get; set; }
        public bool IsPaid { get; set; }

        public ICollection<PersonBill> PersonBills { get; set; }
    }
}
