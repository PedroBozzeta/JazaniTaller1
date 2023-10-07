using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using JazaniT1.Infrastructure.Cores.Contexts;
using JazaniT1.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace JazaniT1.Infrastructure.Admins.Persistences
{
    public class NotificationRepository : CrudRepository<Notification, int>, INotificationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public NotificationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public override async Task<IReadOnlyList<Notification>> FindAllAsync()
        {
            return await _dbContext.Set<Notification>()
                .Include(x => x.NotificationAction)
                .AsNoTracking()
                .ToListAsync();
        }
        public override async Task<Notification?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Notification>()
                .Include(x => x.NotificationAction)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async override Task<Notification> SaveAsync(Notification entity)
        {
            EntityState state = _dbContext.Entry(entity).State;

            // entity.NotificationAction = await _dbContext.Set<NotificationAction>().FindAsync(entity.NotificationActionId);
            _ = state switch
            {
                EntityState.Detached => _dbContext.Set<Notification>().Add(entity),
                EntityState.Modified => _dbContext.Set<Notification>().Update(entity)

            };

            await _dbContext.SaveChangesAsync();

            //return entity;

            return await FindByIdAsync(entity.Id);
        }
    }
}
