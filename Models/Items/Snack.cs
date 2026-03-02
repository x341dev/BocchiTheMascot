using XBochi.Models.Enums;
using XBochi.Models.Pets;

namespace XBochi.Models.Items;

public class Snack : Food
{
    private const int DefaultNutritionValue = 10;
    private const int SnackLimitBeforeSick = 3;

    public Snack(string name) : base(name, DefaultNutritionValue)
    {
    }

    public Snack(string name, int customNutritionValue) : base(name, customNutritionValue)
    {
    }

    public override void Use(Pet pet)
    {
        base.Use(pet);

        pet.PetStats.SnackCount++;

        if (pet.PetStats.SnackCount >= SnackLimitBeforeSick)
        {
            pet.Emotion = Emotions.Sick;
            Console.WriteLine($"⚠️  {pet.Name} has eaten too many snacks and feels sick!");
        }
        else if (pet.PetStats.SnackCount == SnackLimitBeforeSick - 1)
        {
            Console.WriteLine($"⚠️  Warning: {pet.Name} shouldn't eat too many snacks!");
        }
        else
        {
            pet.Emotion = Emotions.Happy;
            Console.WriteLine($"😊 {pet.Name} enjoyed the snack!");
        }
    }
}