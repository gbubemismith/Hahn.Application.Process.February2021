using System.Threading.Tasks;
using Hahn.ApplicationProcess.February2021.Data.Data.Repository;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;

namespace Hahn.ApplicationProcess.February2021.Data.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AssetContext _context;
        public UnitOfWork(AssetContext context)
        {
            _context = context;
            Assets = new AssetRepository(_context);


        }
        public IAssetRepository Assets { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}