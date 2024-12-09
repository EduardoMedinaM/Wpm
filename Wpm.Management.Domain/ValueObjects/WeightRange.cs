namespace Wpm.Management.Domain.ValueObjects;

public record WeightRange
{
    public WeightRange(decimal from, decimal to)
    {
        From = from;
        To = to;
    }

    public decimal From { get; init; }
    public decimal To { get; init; }
}
