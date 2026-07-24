using CarBook.Domain.Entities.Comman;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CarBook.Persistence.Interceptors;

public class DbContextInterceptor : SaveChangesInterceptor
{
    public static readonly Dictionary<EntityState, Action<DbContext, AuditableEntity>> Behaviors = new()
    {
        {EntityState.Added,AddedBehavior },
        {EntityState.Modified,UpdateBehavior },
        {EntityState.Deleted,DeletedBehavior }
    };

    private static void AddedBehavior(DbContext context, AuditableEntity entity)
    {
        entity.CreatedDate = DateTime.Now;
        entity.IsDeleted = false;

        context.Entry(entity).Property(x => x.UpdatedDate).IsModified = false;
        context.Entry(entity).Property(x => x.DeletedDate).IsModified = false;
    }

    private static void UpdateBehavior(DbContext context, AuditableEntity entity)
    {
        entity.UpdatedDate = DateTime.Now;
        entity.IsDeleted = false;

        context.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
        context.Entry(entity).Property(x => x.DeletedDate).IsModified = false;
    }

    private static void DeletedBehavior(DbContext context, AuditableEntity entity)
    {
        context.Entry(entity).State = EntityState.Modified;

        entity.DeletedDate = DateTime.Now;
        entity.IsDeleted = true;

        context.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
        context.Entry(entity).Property(x => x.UpdatedDate).IsModified = false;
    }


    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
       InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;
        if (context == null) return base.SavingChangesAsync(eventData, result, cancellationToken);

        var auditEntries = context.ChangeTracker.Entries<AuditableEntity>();


        foreach (var entry in auditEntries)
        {
            if (Behaviors.TryGetValue(entry.State, out var behavior))
            {
                behavior(context, entry.Entity);
            }
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
