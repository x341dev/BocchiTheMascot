using XBochi.Models.Interfaces;

namespace XBochi.Models.Pets;

public class Cat : Pet, IEatable, ISleepable, IPlayable
{
    public Cat(string name) : base(name) {}
    
    public void Eat()
    {
        PetStats.Hunger += 15; // Less hunger gain
        if (PetStats.Hunger > 100)
            PetStats.Hunger = 100;
        
        UpdateEmotion();
        Console.WriteLine($"{Name} is delicately nibbling... Hunger is now {PetStats.Hunger}");
    }
    
    public void Sleep()
    {
        PetStats.Energy += 30;
        if (PetStats.Energy > 100)
            PetStats.Energy = 100;
        
        PetStats.SnackCount = 0;
        
        UpdateEmotion();
        Console.WriteLine($"{Name} is curled up sleeping... Energy is now {PetStats.Energy}");
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
        Console.WriteLine($"{Name} is chasing a toy! Energy: {PetStats.Energy}, Hunger: {PetStats.Hunger}");
    }
}