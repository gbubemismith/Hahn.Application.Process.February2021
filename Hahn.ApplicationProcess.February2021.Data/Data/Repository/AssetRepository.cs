using Hahn.ApplicationProcess.February2021.Domain.Entities;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;

namespace Hahn.ApplicationProcess.February2021.Data.Data.Repository
{
    public class AssetRepository : GenericRepository<Asset>, IAssetRepository
    {
        public AssetRepository(AssetContext context) : base(context)
        {
        }
    }
}