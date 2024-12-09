namespace Wpm.Clinic.Domain.ValueObjects;

public record Text
{
    public Text(string value)
    {
        Validate(value);
        Value = value;
    }
    public string Value { get; init; }

    private static void Validate(string value)
    {
        if (string.IsNullOrEmpty(value?.Trim()))
        {
            throw new ArgumentNullException(nameof(value), "Text is not valid.");
        }

        if (value.Length > 500)
        {
            throw new ArgumentException("Text too large.");
        }
    }

    public static implicit operator Text(string value) => new(value);
}
