using XBochi.Models.Core;
using XBochi.Models.Interfaces;
using XBochi.Models.Items;
using XBochi.UI;

namespace XBochi;

public class Game
{
    private Player _player = null!;
    private bool _isRunning;

    public Game()
    {
        _isRunning = true;
    }

    public void Start()
    {
        _player = GameUI.DisplayStart();
        InitializeStartingItems();
        GameLoop();
    }

    private void InitializeStartingItems()
    {
        _player.PlayerInventory.AddItem(new Meal("Starter Meal"));
        _player.PlayerInventory.AddItem(new Snack("Cookie"));
        _player.PlayerInventory.AddItem(new Snack("Candy"));
    }

    private void GameLoop()
    {
        while (_isRunning)
        {
            GameMessages.DrawMainScreen(_player.CurrentPet);
            int choice = GameUI.SelectMenuOption();
            ProcessChoice(choice);
            
            if (_isRunning)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }

    private void ProcessChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                HandleEat();
                break;
            case 2:
                HandleSleep();
                break;
            case 3:
                HandlePlay();
                break;
            case 4:
                HandleInventory();
                break;
            case 0:
                HandleExit();
                break;
            default:
                GameMessages.ShowError("Invalid choice!");
                break;
        }
    }

    private void HandleEat()
    {
        if (_player.CurrentPet is IEatable eatable)
        {
            eatable.Eat();
            GameMessages.ShowSuccess($"{_player.CurrentPet.Name} has eaten!");
        }
        else
        {
            GameMessages.ShowError("Your pet cannot eat!");
        }
    }

    private void HandleSleep()
    {
        if (_player.CurrentPet is ISleepable sleepable)
        {
            sleepable.Sleep();
            GameMessages.ShowSuccess($"{_player.CurrentPet.Name} has slept well!");
        }
        else
        {
            GameMessages.ShowError("Your pet cannot sleep!");
        }
    }

    private void HandlePlay()
    {
        if (_player.CurrentPet is IPlayable playable)
        {
            playable.Play();
            GameMessages.ShowSuccess($"{_player.CurrentPet.Name} had fun playing!");
        }
        else
        {
            GameMessages.ShowError("Your pet cannot play!");
        }
    }

    private void HandleInventory()
    {
        Console.WriteLine("\n");
        _player.PlayerInventory.DisplayInventory();

        if (_player.PlayerInventory.IsEmpty())
        {
            return;
        }

        Console.WriteLine("\nWhat would you like to do?");
        Console.WriteLine("Enter item number to use, or 0 to go back");
        
        int itemIndex = GameUI.SelectMenuOption();
        
        if (itemIndex == 0)
        {
            return;
        }

        itemIndex--; // Convert to 0-based index
        
        if (_player.PlayerInventory.UseItem(itemIndex, _player.CurrentPet))
        {
            GameMessages.ShowSuccess("Item used successfully!");
        }
        else
        {
            GameMessages.ShowError("Failed to use item!");
        }
    }

    private void HandleExit()
    {
        Console.WriteLine("\nThank you for playing XBochi!");
        Console.WriteLine($"Goodbye, {_player.Name} and {_player.CurrentPet.Name}!");
        _isRunning = false;
    }
}


