using System.ComponentModel.DataAnnotations;

namespace LAB1_WEB2_12201039.Models.Domain
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
