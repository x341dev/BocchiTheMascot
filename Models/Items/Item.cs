using XBochi.Models.Pets;

namespace XBochi.Models.Items;

public abstract class Item
{
    public string Name { get; protected set; }

    protected Item(string name)
    {
        Name = name;
    }

    public abstract void Use(Pet pet);
}