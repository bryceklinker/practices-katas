using Evercraft.Web.Characters.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Evercraft.Web.Characters
{
    [Route("characters")]
    public class CharactersController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] CreateCharacterViewModel viewModel)
        {
            return RedirectToAction("Index", "Game");
        }
    }
}