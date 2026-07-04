using CarBook.Application.Features.CQRS.Commands.AboutCommant;
using CarBook.Application.Features.CQRS.Handlers.AboutHandler;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandle _createAboutCommandHandler;
        private readonly GetAboutByIdQueryHandle _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandle _getAboutQueryHandler;
        private readonly UpdateAboutCommandHandle _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandle _removeAboutCommandHandler;

        public AboutsController(
            CreateAboutCommandHandle createAboutCommandHandler,
            GetAboutByIdQueryHandle getAboutByIdQueryHandler,
            GetAboutQueryHandle getAboutQueryHandler,
            UpdateAboutCommandHandle updateAboutCommandHandler,
            RemoveAboutCommandHandle removeAboutCommandHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _removeAboutCommandHandler = removeAboutCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _createAboutCommandHandler.Handle(command);
            return Ok("Hakkımda bilgisi başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Hakkımda bilgisi başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _updateAboutCommandHandler.Handle(command);
            return Ok("Hakkımda bilgisi başarıyla güncellendi.");
        }
    }
}
