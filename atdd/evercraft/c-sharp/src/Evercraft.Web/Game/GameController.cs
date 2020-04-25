using System.Threading.Tasks;
using Evercraft.Web.Characters;
using Evercraft.Web.Game.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Evercraft.Web.Game
{
    [Route("game")]
    public class GameController : Controller
    {
        private readonly GetAllCharactersHandler _getAllCharactersHandler;

        public GameController(GetAllCharactersHandler getAllCharactersHandler)
        {
            _getAllCharactersHandler = getAllCharactersHandler;
        }

        [Route("start-game")]
        public IActionResult StartGame()
        {
            ViewData["title"] = "Start Game";
            return View();
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View(new IndexViewModel
            {
                Characters = await _getAllCharactersHandler.Handle()
            });
        }
    }
}