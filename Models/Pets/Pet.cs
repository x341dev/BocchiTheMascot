using XBochi.Models.Core;
using XBochi.Models.Enums;

namespace XBochi.Models.Pets;

public abstract class Pet
{
    public string Name { get; protected set; }
    public Emotions Emotion { get; set; }
    public Stats PetStats { get; protected set; }

    protected Pet(string name)
    {
        Name = name;
        Emotion = Emotions.Happy;
        PetStats = new Stats();
    }

    public void UpdateEmotion()
    {
        if (PetStats.Health <= 20 || PetStats.SnackCount >= 3) Emotion = Emotions.Sick;
        else if (PetStats.Energy <= 30) Emotion = Emotions.Tired;
        else if (PetStats.Hunger <= 50) Emotion = Emotions.Angry;
        else Emotion = Emotions.Happy;
    }
}