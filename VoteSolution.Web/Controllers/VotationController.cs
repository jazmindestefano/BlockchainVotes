using Microsoft.AspNetCore.Mvc;
using VoteSolution.Entities.Models;
using VoteSolution.Services.Interfaces;
using VoteSolution.Web.Models;

namespace VoteSolution.Web.Controllers;

public class VotationController: Controller
{
    private readonly IVoteService _voteService;

    public VotationController(IVoteService voteService)
    {
        _voteService = voteService;
    }

    public IActionResult VotationDetails(int id)
    {
        var voting = _voteService.GetVotationById(id);
        var viewModel = new VotationDetailsViewModel(voting);
        return View(viewModel);
    }
    
    [HttpPost]
    public IActionResult EmitVote(int optionId)
    {
        _voteService.AddVoteToOption(optionId);
        return RedirectToAction("AllVotes", "Home");
    }

}