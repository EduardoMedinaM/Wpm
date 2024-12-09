namespace Wpm.Clinic.Domain.ValueObjects;

public record class PatientId
{
    public PatientId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(value), "The identifier is not valid.");
        }

        Value = value;
    }

    public Guid Value { get; init; }

    public static implicit operator PatientId(Guid value) => new(value);
}
