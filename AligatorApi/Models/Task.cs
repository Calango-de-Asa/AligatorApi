using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AligatorApi.Models
{
    public class Task
    {
        public Task()
        {
            PersonTasks = new HashSet<PersonTask>();
        }

        public Task(int id, string name, string description, DateTime dueTime, Person[] people)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            DueTime = dueTime;
            Done = false;

            PersonTasks = new HashSet<PersonTask>();

            foreach(Person person in people)
            {
                new PersonTask(person, this);
            }
        }
        
        public Task(int id, string name, string description, DateTime dueTime, Person person)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            DueTime = dueTime;
            Done = false;

            PersonTasks = new HashSet<PersonTask>();

            new PersonTask(person, this);
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        [Required]
        [MaxLength(120)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueTime { get; set; }
        public bool Done { get; set; }

        public virtual ICollection<PersonTask> PersonTasks { get; set; }
    }
}
