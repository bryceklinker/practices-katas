using Microsoft.AspNetCore.Mvc;

namespace Evercraft.Web.Game
{
    [Route("game")]
    public class GameController : Controller
    {
        public IActionResult StartGame()
        {
            ViewData["title"] = "Start Game";
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}