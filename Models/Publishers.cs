using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LAB1_WEB2_12201039.Models
{
    public class Publishers
    {
        [Key]
        public int PublisherID { get; set; }
        public string? Name { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
