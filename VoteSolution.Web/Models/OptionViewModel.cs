using VoteSolution.Entities.Models;

namespace VoteSolution.Web.Models;

public class OptionViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TotalVotes { get; set; }

    public OptionViewModel() {}

    public OptionViewModel(Option option)
    {
        Id = option.Id;
        Name = option.Name;
        TotalVotes = option.TotalVotes;
    }

}