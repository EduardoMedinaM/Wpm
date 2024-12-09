namespace Wpm.SharedKernel;
public record Weight
{
    /*Avoids primitive obsession anti-pattern*/
    public Weight(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException("Invalid Weight");
        }

        Value = value;
    }

    public decimal Value { get; init; }

     
    /* Implicit operators in value objects. 
     * You just need to pass the decimal value to create the instance.
     * It applies when you have a single value
     */
    public static implicit operator Weight(decimal value) => new(value);
}
