using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LAB1_WEB2_12201039.Models.Domain
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string? FullName { get; set; }
        [JsonIgnore]
        public ICollection<BookAuthors>? BookAuthors { get; set; }
    }
}
