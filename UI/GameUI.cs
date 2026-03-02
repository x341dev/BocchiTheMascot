using itbXLib.TerminalUtils;
using XBochi.Models.Core;

namespace XBochi.UI;

public static class GameUI
{
    private const string EnterNumberMessage = "Enter the number of your choice: ";
    private const string InvalidInputMessage = "Invalid input. Please try again.";
    
    public static string GetPlayerName() => IntInput.ReadString("Enter your name: ", "Player name cannot be empty. Please try again.", 3);
    public static int SelectMenuOption()
    {
        Console.WriteLine("Select an option:");
        int input = IntInput.ReadInt(EnterNumberMessage, InvalidInputMessage);
        while (input < 1 || input > 4)
        {
            if (input == 0) return 0; // Allow exit option
            Console.WriteLine("Invalid choice. Please try again.");
            input = IntInput.ReadInt(EnterNumberMessage, InvalidInputMessage);
        }

        return input;
    }

    public static int SelectPet()
    {
        Console.WriteLine("Select a pet:");
        Console.WriteLine("1 - Chick");
        Console.WriteLine("2 - Dog");
        Console.WriteLine("3 - Cat");
        int input = IntInput.ReadInt(EnterNumberMessage, InvalidInputMessage);
        while (input < 1 || input > 3)
        {
            Console.WriteLine("Invalid choice. Please try again.");
            input = IntInput.ReadInt(EnterNumberMessage, InvalidInputMessage);
        }
        return input;
    }
        
    public static string GetPetName() => IntInput.ReadString("Enter your pet's name: ", "Pet name cannot be empty. Please try again.", 3);

    public static Player DisplayStart()
    {
        Console.WriteLine("Welcome to XBochi!");
        string playerName = GameUI.GetPlayerName();
        Player player = new Player(playerName);
        Console.WriteLine($"Hello, {player.Name}! Let's choose your pet.");
        player.ChoosePet();
        Console.WriteLine($"You have chosen {player.CurrentPet.Name} the {player.CurrentPet.GetType().Name}!");
        return player;
    }
}