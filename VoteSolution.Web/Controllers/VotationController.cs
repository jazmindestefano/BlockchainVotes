using Microsoft.AspNetCore.Mvc;
using VoteSolution.Services.Interfaces;
using VoteSolution.Entities.Models;
using VoteSolution.Services.Interfaces;
using VoteSolution.Web.Models;
using System.Threading.Tasks;
using System.Linq;

namespace VoteSolution.Web.Controllers;

public class VotationController: Controller
{
    private readonly IVoteService _voteService;

    public VotationController(IVoteService voteService)
    {
        _voteService = voteService;
    }
        public VotationController(IVotationService votationService)
        {
            _votationService = votationService;
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

