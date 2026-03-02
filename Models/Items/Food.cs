using XBochi.Models.Pets;

namespace XBochi.Models.Items;

public abstract class Food : Consumable
{
    protected Food(string name, int nutritionValue) : base(name, nutritionValue)
    {
    }

    public override void Use(Pet pet)
    {
        pet.PetStats.Hunger += Value;
        if (pet.PetStats.Hunger > 100)
            pet.PetStats.Hunger = 100;

        Console.WriteLine($"{pet.Name} ate {Name}! Hunger restored by {Value} points.");
        pet.UpdateEmotion();
    }
}