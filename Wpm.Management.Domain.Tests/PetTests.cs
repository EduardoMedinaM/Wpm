using FluentAssertions;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Enums;
using Wpm.Management.Domain.Services;
using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Management.Domain.Tests;

public class PetTests
{
    [Fact]
    public void Pet_should_be_equal()
    {
        FakeBreedService breeService = new();
        BreedId breedId = new(breeService.breeds[0].Id, breeService);

        var id = Guid.NewGuid();
        Pet pet1 = new(id, "Giani", 13, "Three-color", SexOfPet.Female, breedId);
        Pet pet2 = new(id, "Nina", 10, "Three-color", SexOfPet.Female, breedId);

        pet1.Should().Be(pet2);
    }

    [Fact]
    public void Pet_should_be_equal_using_operators()
    {
        FakeBreedService breeService = new();
        BreedId breedId = new(breeService.breeds[0].Id, breeService);

        var id = Guid.NewGuid();
        Pet pet1 = new(id, "Giani", 13, "Three-color", SexOfPet.Female, breedId);
        Pet pet2 = new(id, "Nina", 10, "Three-color", SexOfPet.Female, breedId);

        (pet1 == pet2).Should().BeTrue();
    }

    [Fact]
    public void Pet_should_not_be_equal_using_operators()
    {
        FakeBreedService breeService = new();
        BreedId breedId = new(breeService.breeds[0].Id, breeService);

        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        Pet pet1 = new(id1, "Giani", 13, "Three-color", SexOfPet.Female, breedId);
        Pet pet2 = new(id2, "Nina", 10, "Three-color", SexOfPet.Female, breedId);

        (pet1 != pet2).Should().BeTrue();
    }

    [Fact]
    public void Weight_should_be_equal()
    {
        Weight weight1 = new(20.5m);
        Weight weight2 = new(20.5m);

        weight1.Equals(weight2).Should().BeTrue();
    }

    [Fact]
    public void WeightRange_should_be_equal()
    {
        WeightRange range1 = new(10m, 20m);
        WeightRange range2 = new(10m, 20m);
        range1.Equals(range2).Should().BeTrue();
    }

    [Fact]
    public void BreedId_should_be_valid()
    {
        FakeBreedService breeService = new();
        BreedId breedId = new(breeService.breeds[0].Id, breeService);
        breedId.Should().NotBeNull();
    }

    [Fact]
    public void BreedId_should_not_be_valid()
    {
        FakeBreedService breeService = new();
        Action act = () => new BreedId(Guid.NewGuid(), breeService);
        act.Should()
            .ThrowExactly<ArgumentNullException>();
    }

    [Fact]
    public void WeightClass_should_be_ideal()
    {
        FakeBreedService breeService = new();
        BreedId breedId = new(breeService.breeds[0].Id, breeService);
        Pet pet = new(Guid.NewGuid(), "Giani", 13, "Three-color", SexOfPet.Female, breedId);
        pet.SetWeight(65m, breeService);
        pet.WeightClass.Should().Be(WeightClass.Ideal);

    }

    [Fact]
    public void WeightClass_should_be_overweight()
    {
        FakeBreedService breeService = new();
        BreedId breedId = new(breeService.breeds[0].Id, breeService);
        Pet pet = new(Guid.NewGuid(), "Giani", 13, "Three-color", SexOfPet.Female, breedId);
        pet.SetWeight(100m, breeService);
        pet.WeightClass.Should().Be(WeightClass.Overweight);
    }
}