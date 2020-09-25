using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AligatorApi.Models
{
    public class Task
    {
        public Task()
        {
            PersonTasks = new HashSet<PersonTask>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [MaxLength(40)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueTime { get; set; }
        public bool Done { get; set; }

        public virtual ICollection<PersonTask> PersonTasks { get; set; }
    }
}
