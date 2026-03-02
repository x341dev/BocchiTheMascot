using itbXLib.TerminalUtils;

namespace XBochi.UI;

public class GameUI
{
    public string GetPlayerName() => IntInput.ReadString("Enter your name: ", "Player name cannot be empty. Please try again.", 3);
    public int SelectMenuOption(string[] options)
    {
        Console.WriteLine("Select an option:");
        int input = IntInput.ReadInt("Enter the number of your choice: ", "Invalid input. Please enter a valid number.");
        while (input < 1 || input > options.Length)
        {
            if (input == 0) return 0; // Allow exit option
            Console.WriteLine("Invalid choice. Please try again.");
            input = IntInput.ReadInt("Enter the number of your choice: ", "Invalid input. Please enter a valid number.");
        }

        return input;
    }

    public int SelectPet()
    {
        Console.WriteLine("Select a pet:");
        Console.WriteLine("1 - Chick");
        Console.WriteLine("2 - Dog");
        Console.WriteLine("3 - Cat");
        int input = IntInput.ReadInt("Enter the number of your choice: ", "Invalid input. Please enter a valid number.");
        while (input < 1 || input > 3)
        {
            Console.WriteLine("Invalid choice. Please try again.");
            input = IntInput.ReadInt("Enter the number of your choice: ", "Invalid input. Please enter a valid number.");
        }
        return input;
    }
        
    
}