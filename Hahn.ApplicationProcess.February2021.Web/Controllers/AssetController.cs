using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hahn.ApplicationProcess.February2021.Domain.Dtos;
using Hahn.ApplicationProcess.February2021.Domain.Extensions;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Hahn.ApplicationProcess.February2021.Web.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hahn.ApplicationProcess.February2021.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;
        private readonly IMapper _mapper;
        public AssetController(IAssetService assetService, IMapper mapper)
        {
            _mapper = mapper;
            _assetService = assetService;

        }

        [HttpGet("{id}", Name = "GetAsset")]
        public async Task<IActionResult> GetAssetByID(int id)
        {

            var asset = await _assetService.GetAssetbyID(id);

            if (asset == null)
                return NotFound(new ApiResponse(404));

            var assetDisplay = _mapper.Map<AssetDto>(asset);

            return Ok(assetDisplay);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsset(AssetDto assetDto)
        {
            var assetReturn = await _assetService.CreateAsset(assetDto);

            return CreatedAtRoute("GetAsset", new { Controller = "Asset", id = assetReturn.ID }, assetReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsset(int id, AssetDto asssetForUpdateDto)
        {
            var assetFromGet = await _assetService.GetAssetbyID(id);

            if (assetFromGet == null)
                return NotFound();

            if (await _assetService.UpdateAsset(asssetForUpdateDto, assetFromGet))
                return NoContent();

            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(500, "Something went wrong"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            var asset = await _assetService.GetAssetbyID(id);

            if (asset == null)
                return NotFound();

            await _assetService.DeleteAsset(asset);

            return NoContent();

        }
    }
}