using XBochi.Models.Pets;
using XBochi.UI;

namespace XBochi.Models.Core;

public class Player
{
    public string Name { get; private set; }
    public Pet CurrentPet { get; set; }
    public Inventory PlayerInventory { get; private set; }

    public Player(string name)
    {
        Name = name;
        PlayerInventory = new Inventory(10);
    }

    public void ChoosePet()
    {
        int petType = GameUI.SelectPet();
        string petName = GameUI.GetPetName();
        switch (petType)
        {
            case 1:
                CurrentPet = new Chick(petName);
                break;
            case 2:
                CurrentPet = new Dog(petName);
                break;
            case 3:
                CurrentPet = new Cat(petName);
                break;
        }
        
    }
    
}