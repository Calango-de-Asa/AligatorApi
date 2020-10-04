using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AligatorApi.Models
{
    public class House
    {
        public House()
        {
            Name = "New House";
            People = new HashSet<Person>();
        }

        public House(string houseName, Person p, int id = 0)
        {
            Id = id;
            Name = houseName;
            People = new HashSet<Person>();
            AddPerson(p);
            p.IsManager = true;
        }

        public void AddPerson(Person p)
        {
            People.Add(p);
            p.House = this;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public virtual ICollection<Person> People { get; }
    }
}
