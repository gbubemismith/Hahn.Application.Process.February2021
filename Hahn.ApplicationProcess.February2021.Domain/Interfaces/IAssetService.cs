using System.Threading.Tasks;
using Hahn.ApplicationProcess.February2021.Domain.Dtos;
using Hahn.ApplicationProcess.February2021.Domain.Entities;

namespace Hahn.ApplicationProcess.February2021.Domain.Interfaces
{
    public interface IAssetService
    {
        Task<AssetDto> CreateAsset(AssetDto asset);
        Task<Asset> GetAssetbyID(int id);
        Task<bool> UpdateAsset(AssetDto assetDto, Asset asset);
        Task DeleteAsset(Asset asset);
    }
}