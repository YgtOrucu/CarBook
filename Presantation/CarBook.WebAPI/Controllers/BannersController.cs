using CarBook.Application.Features.CQRS.Commands.BannerCommand;
using CarBook.Application.Features.CQRS.Handlers.BannerHandler;
using CarBook.Application.Features.CQRS.Handlers.BannerHandler.Read;
using CarBook.Application.Features.CQRS.Handlers.BannerHandler.Write;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetBannerByIdQueryHandle _queryHandle;
        private readonly GetBannerQueryHandle _getBannerQueryHandle;
        private readonly CreateBannerCommandHandle _createBannerCommandHandle;
        private readonly UpdateBannerCommandHandle _updateBannerCommandHandle;
        private readonly RemoveBannerCommandHandle _removeBannerCommandHandle;

        public BannersController(GetBannerByIdQueryHandle queryHandle, GetBannerQueryHandle getBannerQueryHandle, 
            CreateBannerCommandHandle createBannerCommandHandle, UpdateBannerCommandHandle updateBannerCommandHandle, RemoveBannerCommandHandle removeBannerCommandHandle)
        {
            _queryHandle = queryHandle;
            _getBannerQueryHandle = getBannerQueryHandle;
            _createBannerCommandHandle = createBannerCommandHandle;
            _updateBannerCommandHandle = updateBannerCommandHandle;
            _removeBannerCommandHandle = removeBannerCommandHandle;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _getBannerQueryHandle.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await _queryHandle.Handle(new GetBannerByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createBannerCommandHandle.Handle(command);
            return Ok("Banner bilgisi başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removeBannerCommandHandle.Handle(new RemoveBannerCommand(id));
            return Ok("Banner bilgisi başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandle.Handle(command);
            return Ok("Banner bilgisi başarıyla güncellendi.");
        }
    }
}
