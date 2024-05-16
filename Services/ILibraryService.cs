using LAB1_WEB2_12201039.Models.Domain;


namespace LAB1_WEB2_12201039.Services
{
    public interface ILibraryService
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);

        Task<List<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorAsync(int id);
        Task<Author> AddAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(Author author);
        Task<bool> DeleteAuthorAsync(int id);

        Task<List<Publisher>> GetPublishersAsync();
        Task<Publisher> GetPublisherAsync(int id);
        Task<Publisher> AddPublisherAsync(Publisher publisher);
        Task<Publisher> UpdatePublisherAsync(Publisher publisher);
        Task<bool> DeletePublisherAsync(int id);
    }

}