
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AligatorApi.Models
{
    public class Bill
    {
        public Bill()
        {
            PersonBills = new HashSet<PersonBill>();
        }

        public Bill(int id, string name, string description, DateTime dueTime, Person[] people)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            DueTime = dueTime;
            IsPaid = false;
            PersonBills = new HashSet<PersonBill>();

            foreach (Person person in people)
            {
                new PersonBill(person, this);
            }
        }

        public Bill(int id, string name, string description, DateTime dueTime, Person person)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            DueTime = dueTime;
            IsPaid = false;
            PersonBills = new HashSet<PersonBill>();

            new PersonBill(person, this);

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
