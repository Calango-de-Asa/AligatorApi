using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AligatorApi.Models
{
    public class House
    {
        public House()
        {
            People = new HashSet<Person>();
        }

        public House(int id)
        {
            Id = id;
            People = new HashSet<Person>();
        }
        
        public House(int id, Person p)
        {
            Id = id;
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
        public virtual ICollection<Person> People { get; }
    }
}
