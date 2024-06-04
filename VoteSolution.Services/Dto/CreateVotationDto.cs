namespace VoteSolution.Services.DTO;

public class CreateVotationDto
{
    public string Title { get; set; }
    public string Description { get; set; }

    public List<string> Options { get; set; }

    public CreateVotationDto(string title, string description, List<string> options)
    {
        Title = title;
        Description = description;
        Options = options;
    }
}