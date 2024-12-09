using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Services;

public interface IBreedService
{
    Breed? GetBreedById(Guid id);
}


/* Fakes a domain service */
public class FakeBreedService : IBreedService
{
    public readonly List<Breed> breeds =
    [
        new(Guid.NewGuid(), "Golden Retriever", new WeightRange(65m, 75m), new WeightRange(55m, 65m)),
        new (Guid.NewGuid(), "Poodle", new WeightRange(45m, 55m), new WeightRange(45m, 55m))
    ];

    public Breed GetBreedById(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id cannot be empty", nameof(id));
        }

        var result = breeds.Find(x => x.Id == id);
        ArgumentNullException.ThrowIfNull(result);
        return result;
    }
}
