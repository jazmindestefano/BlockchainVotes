using VoteSolution.Entities.Models;

namespace VoteSolution.Web.Models;

public class VotationDetailsViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Boolean IsActive { get; set; }
    public List<OptionViewModel> Options { get; set; }
    public string WinnerOption { get; set; }

    public VotationDetailsViewModel() {}

    public VotationDetailsViewModel(Votation votation)
    {
        Id = votation.Id;
        Title = votation.Title;
        Description = votation.Description;
        IsActive = votation.IsActive;
        Options = votation.Options.Select(option => new OptionViewModel(option)).ToList();
        if (!IsActive)
        {
            WinnerOption = votation.Options.OrderByDescending(o => o.TotalVotes).First()?.Name;
        }
    }
}