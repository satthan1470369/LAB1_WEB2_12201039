using System.ComponentModel.DataAnnotations;

namespace LAB1_WEB2_12201039.Models.Domain
{
    public class Author
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public List<BookAuthors> BookAuthors { get; set; }
    }
}
