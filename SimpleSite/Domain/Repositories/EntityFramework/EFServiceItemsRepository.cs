using SimpleSite.Domain.Entities;
using SimpleSite.Domain.Repositories.Abstract;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleSite.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepository : IServiceItemsRepository
    {
        private readonly AppDbContext context;

        public EFServiceItemsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task DeleteServiceItem(Guid id)
        {
            context.ServiceItems.Remove(new ServiceItem() { Id = id });
            await context.SaveChangesAsync();
        }

        public ServiceItem GetServiceItemById(Guid id)
        {
            return context.ServiceItems.FirstOrDefault(s => s.Id == id);
        }

        public IQueryable<ServiceItem> GetServiceItems()
        {
            return context.ServiceItems;
        }

        public async Task SaveServiceItem(ServiceItem serviceItem)
        {
            if (serviceItem.Id == default)
            {
                context.Entry(serviceItem).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                context.Entry(serviceItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            await context.SaveChangesAsync();
        }
    }
}