using System;
using System.Threading.Tasks;
using AutoMapper;
using Hahn.ApplicationProcess.February2021.Domain.Dtos;
using Hahn.ApplicationProcess.February2021.Domain.Entities;
using Hahn.ApplicationProcess.February2021.Domain.Helpers;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;

namespace Hahn.ApplicationProcess.February2021.Domain.Services
{
    public class AssetService : IAssetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AssetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        //method creates a new asset
        public async Task<AssetDto> CreateAsset(AssetDto assetDto)
        {

            // var asset = _mapper.Map<Asset>(assetDto);
            var asset = OrderMapper.Mapper.Map<Asset>(assetDto);

            _unitOfWork.Assets.Add(asset);
            await _unitOfWork.CompleteAsync();

            return OrderMapper.Mapper.Map<AssetDto>(asset);
        }

        public async Task<Asset> GetAssetbyID(int id)
        {
            var asset = await _unitOfWork.Assets.GetByIdAsync(id);

            // return OrderMapper.Mapper.Map<AssetDto>(asset);
            return asset;
        }

        public async Task DeleteAsset(Asset asset)
        {
            // var asset = _mapper.Map<Asset>(assetDto);

            _unitOfWork.Assets.Remove(asset);
            await _unitOfWork.CompleteAsync();

        }

        public async Task<bool> UpdateAsset(AssetDto assetDto, Asset assetReturned)
        {

            // var asset = OrderMapper.Mapper.Map<Asset>(assetReturned);


            var modifiedAsset = OrderMapper.Mapper.Map(assetDto, assetReturned);

            modifiedAsset.ID = assetReturned.ID;

            _unitOfWork.Assets.Update(modifiedAsset);

            if (await _unitOfWork.CompleteAsync() > 0)
                return true;

            return false;
        }


    }
}