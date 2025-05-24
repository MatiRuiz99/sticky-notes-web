using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;

namespace Model.DTO
{
    public class NoteDTO
    {
        public string Text { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
