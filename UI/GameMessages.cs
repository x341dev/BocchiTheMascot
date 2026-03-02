using System;
using itbXLib.TerminalUtils;
using XBochi.Models.Enums;
using XBochi.Models.Pets;

namespace XBochi.UI
{
    public static class GameMessages
    {
        private static readonly string BoxColor = Colors.RgbToAnsi("#00FFFF");      // Cyan
        private static readonly string TitleColor = Colors.RgbToAnsi("#FF69B4");    // Hot Pink
        private static readonly string MenuOptionColor = Colors.RgbToAnsi("#FFFFFF"); // White
        private static readonly string MenuNumberColor = Colors.RgbToAnsi("#FFD700"); // Gold

        private static readonly string HappyColor = Colors.RgbToAnsi("#FFD700");    // Gold
        private static readonly string SadColor = Colors.RgbToAnsi("#1E90FF");      // Dodger Blue
        private static readonly string AngryColor = Colors.RgbToAnsi("#FF4500");    // Orange Red
        private static readonly string TiredColor = Colors.RgbToAnsi("#9370DB");    // Purple
        private static readonly string SickColor = Colors.RgbToAnsi("#32CD32");     // Toxic Green

        private static readonly string HungerColor = Colors.RgbToAnsi("#FF00FF");   // Magenta
        private static readonly string EnergyColor = Colors.RgbToAnsi("#FFFF00");   // Yellow
        private static readonly string HealthColor = Colors.RgbToAnsi("#00FF00");   // Green

        private static readonly string SuccessColor = Colors.RgbToAnsi("#00FF00");  // Lime Green
        private static readonly string ErrorColor = Colors.RgbToAnsi("#FF0000");    // Red
        
        public static void DrawMainScreen(Pet pet)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();

            DrawHeader(pet);

            DrawPetArt(pet.Emotion);

            DrawPetInfo(pet);

            DrawStats(pet);

            DrawMenu();
        }

        private static void DrawHeader(Pet pet)
        {
            string typeName = pet.GetType().Name;

            Console.WriteLine($"{BoxColor}╔════════════════════════════════════════════╗{Colors.Reset}");
            Console.WriteLine($"{BoxColor}║{TitleColor}                 XBOCHI                     {BoxColor}║{Colors.Reset}");
            Console.WriteLine($"{BoxColor}║{Colors.Reset}                                {BoxColor}║{Colors.Reset}");
            Console.WriteLine($"{BoxColor}║{Colors.Reset}\t   Type: {typeName,-22}{BoxColor}║{Colors.Reset}");
            Console.WriteLine($"{BoxColor}╚════════════════════════════════════════════╝{Colors.Reset}");
        }

        private static void DrawPetInfo(Pet pet)
        {
            string emotionEmoji = GetEmotionEmoji(pet.Emotion);
            string emotionColor = GetEmotionColor(pet.Emotion);

            Console.WriteLine($"Name: {pet.Name}");
            Console.WriteLine($"Emotional State: {emotionColor}{pet.Emotion} {emotionEmoji}{Colors.Reset} \n");
        }

        private static void DrawStats(Pet pet)
        {
            Console.WriteLine($"{HungerColor}Hunger:{DrawBar(pet.PetStats.Hunger)}{Colors.Reset}");
            Console.WriteLine($"{EnergyColor}Energy:{DrawBar(pet.PetStats.Energy)}{Colors.Reset}");
            Console.WriteLine($"{HealthColor}Health:{DrawBar(pet.PetStats.Health)}{Colors.Reset}");
        }

        private static void DrawMenu()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine($"{MenuNumberColor}1{Colors.Reset} - {MenuOptionColor}Eat{Colors.Reset}");
            Console.WriteLine($"{MenuNumberColor}2{Colors.Reset} - {MenuOptionColor}Sleep{Colors.Reset}");
            Console.WriteLine($"{MenuNumberColor}3{Colors.Reset} - {MenuOptionColor}Play{Colors.Reset}");
            Console.WriteLine($"{MenuNumberColor}4{Colors.Reset} - {MenuOptionColor}Inventory{Colors.Reset}");
            Console.WriteLine($"{MenuNumberColor}0{Colors.Reset} - {MenuOptionColor}Exit{Colors.Reset}");
        }

        private static string DrawBar(int value)
        {
            int totalBlocks = 20;
            value = Math.Max(0, Math.Min(100, value));
            int filledBlocks = value * totalBlocks / 100;

            return "[" +
                   new string('#', filledBlocks) +
                   new string('-', totalBlocks - filledBlocks) +
                   $"] {value}%";
        }

        public static void DrawPetArt(Emotions state)
        {
            string color = GetEmotionColor(state);
            string art = state switch
            {
                Emotions.Happy => @"
      /\_/\      
     ( ^‿^ )     
     /       \    
    |         |   
     \__/\___/    
",
                Emotions.Sad => @"
      /\_/\      
     ( ╥﹏╥ )     
     /       \    
    |         |   
     \__/\___/    
",
                Emotions.Angry => @"
      /\_/\      
     ( ಠ_ಠ )     
     /       \    
    |         |   
     \__/\___/    
",
                Emotions.Tired => @"
      /\_/\      
     ( -_- ) zZ  
     /       \    
    |         |   
     \__/\___/    
",
                Emotions.Sick => @"
      /\_/\      
     ( x_x )     
     /       \    
    |   +--+   |   
     \__/\___/    
",
                _ => ""
            };

            Console.WriteLine($"{color}{art}{Colors.Reset}");
        }

        private static string GetEmotionColor(Emotions state)
        {
            return state switch
            {
                Emotions.Happy => HappyColor,
                Emotions.Sad => SadColor,
                Emotions.Angry => AngryColor,
                Emotions.Tired => TiredColor,
                Emotions.Sick => SickColor,
                _ => Colors.Reset
            };
        }

        private static string GetEmotionEmoji(Emotions state)
        {
             return state switch
            {
                Emotions.Happy => Styles.FromCodePoint(0x1f603), 
                Emotions.Sad => Styles.FromCodePoint(0x1f641),
                Emotions.Angry => Styles.FromCodePoint(0x1f620),
                Emotions.Tired => Styles.FromCodePoint(0x1f634),
                Emotions.Sick => Styles.FromCodePoint(0x1f927),
                _ => ""
            };
        }

        public static void ShowSuccess(string message)
        {
            Console.WriteLine($"\n{SuccessColor}✔ {message}{Colors.Reset}");
        }

        public static void ShowError(string message)
        {
            Console.WriteLine($"\n{ErrorColor}✖ {message}{Colors.Reset}");
        }
    }
}