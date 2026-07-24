namespace CarBook.Application.Interfaces;

public interface IUnitOfWork
{
    Task<bool> SaveChangeAsync();
}
