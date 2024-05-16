using LAB1_WEB2_12201039.Models.DTO;
using LAB1_WEB2_12201039.Models.Domain;

namespace LAB1_WEB2_12201039.Repositories
{
    public interface IAuthorRepository
    {
        List<AuthorDTO> GellAllAuthors();
        AuthorNoIdDTO GetAuthorById(int id);
        AddAuthorRequestDTO AddAuthor(AddAuthorRequestDTO addAuthorRequestDTO);
        AuthorNoIdDTO UpdateAuthorById(int id, AuthorNoIdDTO authorNoIdDTO);
        Author? DeleteAuthorById(int id);
    }
}
