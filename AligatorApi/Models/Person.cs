using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AligatorApi.Models
{
    public class Person
    {
        public Person()
        {
            Notices = new HashSet<Notice>();
            PersonBills = new HashSet<PersonBill>();
            PersonTasks = new HashSet<PersonTask>();
        }

        public Person(int id, string name, string email, bool isManager)
        {
            Id = id;
            Name = name;
            Email = email;
            IsManager = isManager;
        }

        [Key]
        public int Id { get; set; }
        [NotMapped]
        public House House { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [MaxLength(60)]
        public string Email { get; set; }
        public bool IsManager { get; set; }

        public virtual ICollection<Notice> Notices { get; set; }
        public virtual ICollection<PersonBill> PersonBills { get; set; }
        public virtual ICollection<PersonTask> PersonTasks { get; set; }
    }
}
