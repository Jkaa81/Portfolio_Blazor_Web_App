namespace WorkoutGenerator.Domain;

public abstract class ApplicationUser
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}