namespace XBochi.Models.Core;

public class Stats
{
    public int Hunger { get; set; } = 100;
    public int Energy { get; set; } = 100;
    public int SnackCount { get; set; } = 0;

    public int Health => (Hunger + Energy) / 2;
}