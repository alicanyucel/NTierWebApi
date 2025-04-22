using NTier.Entities.Models;

namespace NTier.Repositories.EFCore;

public interface IBookRepository:IRepositoryBase<Book>
{
    IQueryable<Book> GetAllBook(bool trackChanges);
    Book GetOneBookById(int id,bool trackChanges);
    void CreateOneBook(Book book);
    void UpdateOneBook(Book book);
    void DeleteOneBook(Book book);
}
