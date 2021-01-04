using SimpleSite.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleSite.Domain.Repositories.Abstract
{
    public interface IServiceItemsRepository
    {
        IQueryable<ServiceItem> GetServiceItems();

        ServiceItem GetServiceItemById(Guid id);

        Task SaveServiceItem(ServiceItem serviceItem);

        Task DeleteServiceItem(Guid id);
    }
}