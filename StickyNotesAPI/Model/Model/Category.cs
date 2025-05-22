using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
