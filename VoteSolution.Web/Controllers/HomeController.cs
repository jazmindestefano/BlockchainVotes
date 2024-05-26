using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using VoteSolution.Services.Interfaces;
using VoteSolution.Web.Models;

namespace VoteSolution.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVoteService _voteService;

        public HomeController(ILogger<HomeController> logger, IVoteService voteService)
        {
            _logger = logger;
            _voteService = voteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CreateVote()
        {
            return View();
        }

        // Para validar mas adelante que tengas que entrar tu address y valide si podes crear votaciones o no
        public IActionResult Help()
        {
            return View();
        }

        public IActionResult AllVotes()
        {
            var votaciones = new List<VoteViewModel>();
            return View(votaciones);
        }

    }
}
