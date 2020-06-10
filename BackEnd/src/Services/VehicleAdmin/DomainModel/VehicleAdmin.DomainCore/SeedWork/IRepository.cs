using VehicleAdmin.Domain.SeedWork;
using System.Collections.Generic;

namespace VehicleAdmin.DomainCore.SeedWork
{
    public interface IRepository<T> where T : IAggregateRoot
    {        

        List<T> GetAllItems();
    }
}
