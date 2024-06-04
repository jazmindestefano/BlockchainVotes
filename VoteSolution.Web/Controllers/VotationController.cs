using Microsoft.AspNetCore.Mvc;
using VoteSolution.Services.Interfaces;
using VoteSolution.Entities.Models;
using VoteSolution.Services.Interfaces;
using VoteSolution.Web.Models;
using System.Threading.Tasks;
using System.Linq;
using VoteSolution.Services.DTO;

namespace VoteSolution.Web.Controllers;

public class VotationController : Controller
{
    private readonly IVotationService _votationService;
    public VotationController(IVotationService votationService)
    {
        _votationService = votationService;
    }

    public IActionResult VotationDetails(int id)
    {
        var voting = _votationService.GetVotationById(id);
        var viewModel = new VotationDetailsViewModel(voting);
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult EmitVote(int optionId)
    {
        _votationService.AddVoteToOption(optionId);
        return RedirectToAction("AllVotes", "Home");
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(VotationViewModel votationViewModel)
    {
        if (ModelState.IsValid)
        {
            var votation = new CreateVotationDto(votationViewModel.Title, votationViewModel.Description, votationViewModel.Options);
            _votationService.CreateVotation(votation);
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