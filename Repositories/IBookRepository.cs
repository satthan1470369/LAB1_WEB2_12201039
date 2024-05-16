using LAB1_WEB2_12201039.Models.Domain;
using LAB1_WEB2_12201039.Models.DTO;

namespace LAB1_WEB2_12201039.Repositories
{
    public interface IBookRepository
    {
        List<BookWithAuthorAndPublisherDTO> GetAllBooks(string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000);
        BookWithAuthorAndPublisherDTO GetBookById(int id);
        AddBookRequestDTO AddBook(AddBookRequestDTO addBookRequestDTO);
        AddBookRequestDTO? UpdateBookById(int id, AddBookRequestDTO bookDTO);
        Book? DeleteBookById(int id);
    }
}
