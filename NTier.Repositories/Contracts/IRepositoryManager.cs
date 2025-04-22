using NTier.Repositories.EFCore;

namespace NTier.Repositories.Contracts;

public interface IRepositoryManager
{
    IBookRepository Book { get; }
    void Save();
}
