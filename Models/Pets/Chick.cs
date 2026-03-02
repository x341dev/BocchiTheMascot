using XBochi.Models.Interfaces;

namespace XBochi.Models.Pets;

public class Chick : Pet, IEatable, ISleepable, IPlayable
{
    public Chick(string name) : base(name) { }
    
    public void Eat()
    {
        PetStats.Hunger += 20;
        if (PetStats.Hunger > 100)
            PetStats.Hunger = 100;
        
        UpdateEmotion();
        Console.WriteLine($"{Name} is pecking at food... Hunger is now {PetStats.Hunger}");
    }
    
    public void Sleep()
    {
        PetStats.Energy += 30;
        if (PetStats.Energy > 100)
            PetStats.Energy = 100;
        
        PetStats.SnackCount = 0;
        
        UpdateEmotion();
        Console.WriteLine($"{Name} is napping with head tucked under wing... Energy is now {PetStats.Energy}");
    }
    
    public void Play()
    {
        PetStats.Energy -= 10;
        if (PetStats.Energy < 0)
            PetStats.Energy = 0;
        
        PetStats.Hunger -= 10;
        if (PetStats.Hunger < 0)
            PetStats.Hunger = 0;
        
        UpdateEmotion();
        Console.WriteLine($"{Name} is chirping and hopping around playfully! Energy: {PetStats.Energy}, Hunger: {PetStats.Hunger}");
    }
}