using itbXLib.TerminalUtils;
using XBochi.Models.Enums;
using XBochi.Models.Pets;

namespace XBochi.UI;

public static class GameMessages
{
    // -- COLOR PALETTE --
    private static readonly string TitleColor = Colors.RgbToAnsi("#FF69B4");   // Hot Pink
    private static readonly string MenuColor = Colors.RgbToAnsi("#00FFFF");    // Cyan
    private static readonly string SuccessColor = Colors.RgbToAnsi("#00FF00"); // Lime Green
    private static readonly string ErrorColor = Colors.RgbToAnsi("#FF0000");   // Red
    
    // -- EMOTION COLORS --
    private static readonly string HappyColor = Colors.RgbToAnsi("#FFD700");   // Gold
    private static readonly string SadColor = Colors.RgbToAnsi("#1E90FF");     // Dodger Blue
    private static readonly string AngryColor = Colors.RgbToAnsi("#FF4500");   // Orange Red
    private static readonly string TiredColor = Colors.RgbToAnsi("#9370DB");   // Purple
    private static readonly string SickColor = Colors.RgbToAnsi("#32CD32");    // Toxic Green

    public static void ShowWelcome()
    {
        Console.Clear();
        Console.WriteLine($"{TitleColor}");
        Console.WriteLine(" ╔════════════════════════════════════════════╗ ");
        Console.WriteLine(" ║                                            ║ ");
        Console.WriteLine($" ║   {Styles.FromCodePoint(0x2728)}  WELCOME TO THE XBOCHI PET SYSTEM {Styles.FromCodePoint(0x2728)}    ║ ");
        Console.WriteLine(" ║                                            ║ ");
        Console.WriteLine(" ╚════════════════════════════════════════════╝ ");
        Console.WriteLine($"{Colors.Reset}");
    }

    public static void ShowEmotionStatus(Pet pet)
    {
        string name = pet.GetName();
        Emotions emotion = pet.GetEmotion();

        switch (emotion)
        {
            case Emotions.Happy:
                Console.WriteLine($"{HappyColor}(^_^) YAY! {name} is feeling Happy and energetic!{Colors.Reset}");
                break;
            case Emotions.Sad:
                Console.WriteLine($"{SadColor}(T_T) Oh no... {name} looks away sadly.{Colors.Reset}");
                break;
            case Emotions.Angry:
                Console.WriteLine($"{AngryColor}(>_<) Grrr! {name} is very Angry! Watch out!{Colors.Reset}");
                break;
            case Emotions.Tired:
                Console.WriteLine($"{TiredColor}(-_- ) Zzz... {name} is too Tired and needs a nap.{Colors.Reset}");
                break;
            case Emotions.Sick:
                Console.WriteLine($"{SickColor}(@_@) {name} is feeling Sick! Please give them some medicine!{Colors.Reset}");
                break;
            default:
                Console.WriteLine($"{name} is just staring at you. {Styles.FromCodePoint(0x1f636)}");
                break;
        }
    }
    
    public static void ShowSuccess(string message)
    {
        Console.WriteLine($"{SuccessColor}✓ {message}{Colors.Reset}");
    }
    
    public static void ShowError(string message)
    {
        Console.WriteLine($"{ErrorColor}✗ {message}{Colors.Reset}");
    }
}