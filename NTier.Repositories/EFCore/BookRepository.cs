using NTier.Entities.Models;
using NTier.Repositories.EFCore.Context;

namespace NTier.Repositories.EFCore;

public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(RepositoryContext context) : base(context) { }

    public void CreateOneBook(Book book) => Create(book);

    public void DeleteOneBook(Book book) => Delete(book);


    public IQueryable<Book> GetAllBook(bool trackChanges) => FindAll(trackChanges).OrderBy(b => b.Id);


    public IQueryable<Book> GetOneBookById(int id, bool trackChanges) => FindByCondition(b => b.Id.Equals(id), trackChanges);


    public void UpdateOneBook(Book book) => Update(book);

}

