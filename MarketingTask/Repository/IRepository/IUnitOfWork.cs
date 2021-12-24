using MarketingTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingTask.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Distributor> Distributors { get; }
        IGenericRepository<DistributorSales> DistributorSales { get; }
        IGenericRepository<Bonus> Bonuses { get; }
        Task Save();
    }
}
