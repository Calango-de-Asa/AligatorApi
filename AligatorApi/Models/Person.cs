using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

            Notices = new HashSet<Notice>();
            PersonBills = new HashSet<PersonBill>();
            PersonTasks = new HashSet<PersonTask>();
        }

        public void NoticeCreate(string b)
        {
            var notice = new Notice(body: b, person: this);
            Notices.Add(notice) ;
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

        public virtual ICollection<Notice> Notices { get; }
        public virtual ICollection<PersonBill> PersonBills { get; }
        public virtual ICollection<PersonTask> PersonTasks { get; }
    }
}
