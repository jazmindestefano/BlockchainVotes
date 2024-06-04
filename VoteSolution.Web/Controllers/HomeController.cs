using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VoteSolution.Services.DTO;
using VoteSolution.Services.Interfaces;
using VoteSolution.Web.Models;

namespace VoteSolution.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVotationService _votationService;

        public HomeController(ILogger<HomeController> logger, IVotationService votationService)
        {
            _logger = logger;
            _votationService = votationService;
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

        // no cambiar porque rompe con las vistas, dejar para despues
        [HttpPost]
        public IActionResult CreateVote(VoteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Options.ForEach(Console.WriteLine);

            _votationService.CreateVotation(new CreateVotationDto(model.Title, model.Description, model.Options));

            return RedirectToAction("AllVotes");
        }

        // no cambiar porque rompe con las vistas, dejar para despues
        public IActionResult AllVotes()
        {
            var votes = _votationService.GetAllVotations();
            votes.ForEach(v => v.Options.ForEach(o => Console.WriteLine(o.Id)));
            var VotesModelLista = VoteViewModel.MapearAListaModel(votes);

            return View(VotesModelLista);
        }

        // no cambiar porque rompe con las vistas, dejar para despues
        public IActionResult CreateVote()
        {
            return View();
        }

        // Para validar mas adelante que tengas que entrar tu address y valide si podes crear votaciones o no ??
        public IActionResult Help()
        {
            return View();
        }

    }
}
