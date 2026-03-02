using XBochi.Models.Items;

namespace XBochi.Models.Core;

public class Inventory
{
    private Item[] _items;

    public Inventory(int capacity)
    {
        _items = new Item[capacity];
    }
    
    
}