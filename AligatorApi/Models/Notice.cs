using System;
using System.ComponentModel.DataAnnotations;

namespace AligatorApi.Models
{
    public class Notice
    {
        public Notice() { }
        public Notice(string body, Person person)
        {
            Body = body;
            CreatedAt = DateTime.UtcNow;
            PersonId = person.Id;
            Person = person;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        [MinLength(2)]
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
