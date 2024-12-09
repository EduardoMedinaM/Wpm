using Wpm.Management.Domain.Services;

namespace Wpm.Management.Domain.ValueObjects;

public record BreedId
{
    private readonly IBreedService _breedService;
    public BreedId(Guid value, IBreedService breedService)
    {
        _breedService = breedService;

        ValidateBreed(value);

        Value = value;
    }
    public Guid Value { get; set; }

    private void ValidateBreed(Guid value)
    {
        var breed = _breedService.GetBreedById(value);
        if (breed is null)
        {
            throw new ArgumentException("Breed not found", nameof(value));
        }
    }
}
