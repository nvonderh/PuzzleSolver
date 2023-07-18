using Microsoft.AspNetCore.Mvc;

namespace PuzzleSolver.Controllers
{
    public class PuzzleSolverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
