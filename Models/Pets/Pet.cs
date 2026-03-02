using XBochi.Models.Enums;

namespace XBochi.Models.Pets;

public abstract class Pet
{
    protected string Name { get; set; }
    protected Emotions Emotion { get; set; }
    
    public string GetName() => Name;
    public Emotions GetEmotion() => Emotion;
}