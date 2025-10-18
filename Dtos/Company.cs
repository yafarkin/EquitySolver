namespace EquitySolver.Dtos;

public sealed record Company
{
    public string Name { get; init; } = string.Empty;

    public Dictionary<string, double> OwnedCompanies { get; init; } = new();
}