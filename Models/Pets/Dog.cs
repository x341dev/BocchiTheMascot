using XBochi.Models.Interfaces;

namespace XBochi.Models.Pets;

public class Dog : Pet, IEatable, ISleepable, IPlayable
{
    public Dog(string name) : base(name) { }
    
    public void Eat()
    {
        PetStats.Hunger += 20;
        if (PetStats.Hunger > 100)
            PetStats.Hunger = 100;
        
        UpdateEmotion();
        Console.WriteLine($"{Name} is happily munching food... Hunger is now {PetStats.Hunger}");
    }
    
    public void Sleep()
    {
        PetStats.Energy += 40;
        if (PetStats.Energy > 100)
            PetStats.Energy = 100;
        
        PetStats.SnackCount = 0;
        
        UpdateEmotion();
        Console.WriteLine($"{Name} is snoring peacefully... Energy is now {PetStats.Energy}");
    }
    
    public void Play()
    {
        PetStats.Energy -= 15;
        if (PetStats.Energy < 0)
            PetStats.Energy = 0;
        
        PetStats.Hunger -= 10;
        if (PetStats.Hunger < 0)
            PetStats.Hunger = 0;
        
        UpdateEmotion();
        Console.WriteLine($"{Name} is wagging tail and running around! Energy: {PetStats.Energy}, Hunger: {PetStats.Hunger}");
    }
}