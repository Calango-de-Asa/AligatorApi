using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AligatorApi.Models
{
    public class Notice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
