using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VoteSolution.Services.Interfaces;
using VoteSolution.Web.Models;

namespace VoteSolution.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBlockchainService _blockchainService;

    public HomeController(ILogger<HomeController> logger, IBlockchainService blockchainService)
    {
        _logger = logger;
        _blockchainService = blockchainService;
    }

    public IActionResult Index()
    {
        _blockchainService.CreateVoteAsync("Test");
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
}
