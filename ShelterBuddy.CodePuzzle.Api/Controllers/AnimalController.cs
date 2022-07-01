using Microsoft.AspNetCore.Mvc;
using ShelterBuddy.CodePuzzle.Api.Models;
using ShelterBuddy.CodePuzzle.Core.DataAccess;
using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase
{
    private readonly IRepository<Animal, Guid> repository = new AnimalRepository();

    public AnimalController()
    {

    }

    [HttpGet]
    public AnimalModel[] Get() => repository.GetAll().Select(animal => new AnimalModel
    {
        Id = $"{animal.Id}",
        Name = animal.Name,
        Colour = animal.Colour,
        DateFound = animal.DateFound,
        DateLost = animal.DateLost,
        MicrochipNumber = animal.MicrochipNumber,
        DateInShelter = animal.DateInShelter,
        DateOfBirth = animal.DateOfBirth,
        AgeText = animal.AgeText,
        AgeMonths = animal.AgeMonths,
        AgeWeeks = animal.AgeWeeks,
        AgeYears = animal.AgeYears,
        Species = animal.Species
    }).ToArray();

    [HttpPost]
    public void Post(AnimalModel newAnimal)
    {
        var animal = new Animal();

        animal.Name = newAnimal.Name;
        animal.Colour = newAnimal.Colour;
        animal.DateOfBirth = newAnimal.DateOfBirth;
        animal.DateInShelter = newAnimal.DateInShelter;
        animal.DateLost = newAnimal.DateLost;
        animal.DateFound = newAnimal.DateFound;
        animal.MicrochipNumber = newAnimal.MicrochipNumber;
        animal.AgeYears = newAnimal.AgeYears;
        animal.AgeMonths = newAnimal.AgeMonths;
        animal.AgeWeeks = newAnimal.AgeWeeks;
        animal.Species = newAnimal.Species;

        animal.ValidateProvidedDateOfBirthOrAgeFields();

        repository.Add(animal);
    }    
}