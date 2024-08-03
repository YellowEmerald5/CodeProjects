using TowersOfHanoi;

internal class Program
{
    private static void Main(string[] args)
    {
        var game = new TowersGame(new ConsoleUI());
        game.Run();
    }
}