using Microsoft.AspNetCore.Mvc;
using VoteSolution.Services.Interfaces;
using VoteSolution.Entities.Models;
using VoteSolution.Web.Models;
using System.Threading.Tasks;
using System.Linq;

namespace VoteSolution.Web.Controllers
{
    public class VotationController : Controller
    {
        private readonly IVotationService _votationService;

        public VotationController(IVotationService votationService)
        {
            _votationService = votationService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VotationViewModel votationViewModel)
        {
            if (ModelState.IsValid)
            {
                var votation = new Votation
                {
                    Title = votationViewModel.Title,
                    Description = votationViewModel.Description,
                    IsActive = votationViewModel.IsActive,
                    Options = votationViewModel.Options.Select(option => new Option { Name = option }).ToList()
                };

                await _votationService.CreateVotationAsync(votation);
                return RedirectToAction("Votation");
            }
            return View(votationViewModel);
        }

        [HttpGet]
        public IActionResult Votation()
        {
            return View();
        }
    }
}
