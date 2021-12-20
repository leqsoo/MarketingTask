using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketingTask.Data;
using MarketingTask.GenericRepository;
using MarketingTask.IRepository;

namespace MarketingTask.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _databaseContext;
        private IGenericRepository<Product> _products;
        private IGenericRepository<Distributor> _distributors;

        public UnitOfWork(ApplicationDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IGenericRepository<Product> Products => _products ??= new GenericRepository<Product>(_databaseContext);

        public IGenericRepository<Distributor> Distributors => _distributors ??= new GenericRepository<Distributor>(_databaseContext);

        public void Dispose()
        {
            _databaseContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
