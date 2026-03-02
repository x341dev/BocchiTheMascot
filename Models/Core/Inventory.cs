using XBochi.Models.Pets;
using XBochi.Models.Items;

namespace XBochi.Models.Core;

public class Inventory
{
    private readonly Item[] _items;
    private int _itemCount;
    private readonly int _capacity;

    public Inventory(int capacity)
    {
        _capacity = capacity;
        _items = new Item[capacity];
        _itemCount = 0;
    }

    public bool AddItem(Item item)
    {
        if (item == null)
        {
            Console.WriteLine("Cannot add null item to inventory.");
            return false;
        }
        
        if (_itemCount >= _capacity)
        {
            Console.WriteLine("Inventory is full! Cannot add more items.");
            return false;
        }
        
        _items[_itemCount] = item;
        _itemCount++;
        Console.WriteLine($"Added '{item.Name}' to inventory.");
        return true;
    }
    
    public bool RemoveItem(int index)
    {
        if (!IsValidIndex(index))
        {
            Console.WriteLine("Invalid item index.");
            return false;
        }
        
        Item removedItem = _items[index];
        
        for (int i = index; i < _itemCount - 1; i++)
        {
            _items[i] = _items[i + 1];
        }
        
        _items[_itemCount - 1] = null!;
        _itemCount--;
        
        Console.WriteLine($"Removed '{removedItem.Name}' from inventory.");
        return true;
    }
    
    public bool UseItem(int index, Pet pet)
    {
        if (pet == null)
        {
            Console.WriteLine("Cannot use item: No pet selected.");
            return false;
        }
        
        if (!IsValidIndex(index))
        {
            Console.WriteLine("Invalid item index.");
            return false;
        }
        
        Item item = _items[index];
        Console.WriteLine($"Using '{item.Name}'...");
        item.Use(pet);
        
        RemoveItem(index);
        return true;
    }
    
    public void DisplayInventory()
    {
        if (_itemCount == 0)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }
        
        Console.WriteLine($"=== Inventory ({_itemCount}/{_capacity}) ===");
        for (int i = 0; i < _itemCount; i++)
        {
            Console.WriteLine($"{i + 1}. {_items[i].Name}");
        }
    }
    
    public int GetItemCount() => _itemCount;
    
    public int GetCapacity() => _capacity;
    
    public Item? GetItem(int index)
    {
        if (!IsValidIndex(index))
            return null;
        return _items[index];
    }
    
    public bool IsFull() => _itemCount >= _capacity;
    
    public bool IsEmpty() => _itemCount == 0;
    
    private bool IsValidIndex(int index)
    {
        return index >= 0 && index < _itemCount;
    }
}