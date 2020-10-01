using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        [Key]
        public int Id { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
