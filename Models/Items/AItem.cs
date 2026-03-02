using XBochi.Models.Pets;

namespace XBochi.Models.Items;

public abstract class AItem
{
    public string Name { get; protected set; }

    protected AItem(string name)
    {
        Name = name;
    }

    public abstract void Use(Pet pet);
}