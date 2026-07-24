using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories;

public class UnitOfWorkRepository(CarBookContext context) : IUnitOfWork
{
    public async Task<bool> SaveChangeAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
