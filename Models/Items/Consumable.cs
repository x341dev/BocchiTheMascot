using XBochi.Models.Pets;

namespace XBochi.Models.Items;

public abstract class Consumable : Item
{
    public int Value { get; protected set; }

    protected Consumable(string name, int value) : base(name)
    {
        Value = value;
    }

    public abstract override void Use(Pet pet);
}