using NTier.Repositories.Contracts;
using NTier.Repositories.EFCore.Context;

namespace NTier.Repositories.EFCore;

public class RepositoryManager:IRepositoryManager
{
    private readonly RepositoryContext _context;
    private readonly Lazy<IBookRepository> _bookRepository;
    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
        _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));
    }

    public IBookRepository Book => _bookRepository.Value;

    IBookRepository IRepositoryManager.Book { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Save()
    {
       _context.SaveChanges();
    }
}
