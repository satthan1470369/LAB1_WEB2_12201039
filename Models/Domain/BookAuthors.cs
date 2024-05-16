using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace LAB1_WEB2_12201039.Models.Domain
{
    public class BookAuthors
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
