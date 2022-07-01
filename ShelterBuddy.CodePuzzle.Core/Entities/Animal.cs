namespace ShelterBuddy.CodePuzzle.Core.Entities;

public class Animal : BaseEntity<Guid>
{
    public string? Name 
    {
        get
        {
            return name;
        }
        set 
        {
            name = ValidateIsMandatory(value, nameof(Name));
        } 
    }
    public string? Colour { get; set; }
    public string? MicrochipNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? DateInShelter { get; set; }
    public DateTime? DateLost { get; set; }
    public DateTime? DateFound { get; set; }
    public int? AgeYears { get; set; }
    public int? AgeMonths { get; set; }
    public int? AgeWeeks { get; set; }
    public string? Species
    {
        get
        {
            return species;
        }
        set
        {
            species = ValidateIsMandatory(value, nameof(Species));
        }
    }

    public string AgeText => GetDescriptionAgeTextWithYearsMonthsWeeks(AgeYears, AgeMonths, AgeWeeks);


    
    private string? name { get; set; }
    private string? species { get; set; }

    
       
    private string GetDescriptionAgeTextWithYearsMonthsWeeks(int? years, int? months, int? weeks)
    {
        string descriptionYears = years.HasValue ? $"{years} years " : string.Empty;

        string descriptionMonths = months.HasValue ? $"{months} months " : string.Empty;

        string descriptionWeeks = weeks.HasValue ? $"{weeks} weeks" : string.Empty;

        return $"{descriptionYears}{descriptionMonths}{descriptionWeeks}".Trim();
    }

    private string ValidateIsMandatory(string? value, string field)
    {
        return string.IsNullOrEmpty(value) ? throw new ArgumentNullException(field) : value;
    }

    public void ValidateProvidedDateOfBirthOrAgeFields()
    {
        if (!DateOfBirth.HasValue && !AgeYears.HasValue && !AgeMonths.HasValue && !AgeWeeks.HasValue)
        {
            throw new Exception("Must have the date of birth or age fields (years, months, and weeks).");
        }
    }
}