using Wpm.Management.Domain.Enums;
using Wpm.Management.Domain.Services;
using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Management.Domain.Entities;

public class Pet : Entity
{
    public Pet(Guid id,
        string? name,
        int age,
        string color,
        SexOfPet sexOfPet,
        BreedId breedId)
    {
        Id = id;
        Name = name;
        Age = age;
        Color = color;
        SexOfPet = sexOfPet;
        BreedId = breedId;
    }

    public string? Name { get; init; }
    public int Age { get; init; }
    public string Color { get; init; }
    public BreedId BreedId { get; init; }
    public SexOfPet SexOfPet { get; init; }


    /* Since this one needs to be calculated */
    public Weight Weight { get; private set; }
    public WeightClass WeightClass { get; private set; }


    /* Implementing business rules in the entity*/
    public void SetWeight(Weight weight, IBreedService breedService)
    {
        Weight = weight;
        SetWeightClass(breedService);
    }

    private void SetWeightClass(IBreedService breedService)
    {
        ArgumentNullException.ThrowIfNull(breedService);

        Breed desiredBreed = breedService.GetBreedById(BreedId.Value)!;
        var (from, to) = SexOfPet switch
        {
            SexOfPet.Male => (desiredBreed.MaleIdealWeight.From, desiredBreed.MaleIdealWeight.To),
            SexOfPet.Female => (desiredBreed.FemaleIdealWeight.From, desiredBreed.FemaleIdealWeight.To),
            _ => throw new NotImplementedException()
        };

        WeightClass = Weight.Value switch
        {
            _ when Weight.Value < from => WeightClass.Underweight,
            _ when Weight.Value > to => WeightClass.Overweight,
            _ => WeightClass.Ideal
        };
    }
}