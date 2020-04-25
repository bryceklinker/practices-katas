using System.Threading.Tasks;
using Evercraft.Web.Characters.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Evercraft.Web.Characters
{
    [Route("characters")]
    public class CharactersController : Controller
    {
        private readonly CreateCharacterHandler _createCharacterHandler;

        public CharactersController(CreateCharacterHandler createCharacterHandler)
        {
            _createCharacterHandler = createCharacterHandler;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCharacterViewModel viewModel)
        {
            await _createCharacterHandler.Handle(viewModel);
            return RedirectToAction("Index", "Game");
        }
    }
}