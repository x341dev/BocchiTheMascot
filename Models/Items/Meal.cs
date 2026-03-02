namespace XBochi.Models.Items;

public class Meal : Food
{
    private const int DefaultNutritionValue = 30;

    public Meal(string name) : base(name, DefaultNutritionValue)
    {
    }

    public Meal(string name, int customNutritionValue) : base(name, customNutritionValue)
    {
    }
}