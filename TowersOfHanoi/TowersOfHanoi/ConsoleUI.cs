using TowersOfHanoi;

internal class ConsoleUI : IUserInterface
{
    public bool BeginGame()
    {
        Console.WriteLine("Welcome to the Towers of Hanoi game.");
        Console.WriteLine("To move a piece, input the pole to move from followed by the the pole to move to separated with a space. Entering [Q] at any time will stop the game");
        Console.WriteLine("[S]tart game");
        Console.WriteLine("[Q]uit game");
        var input = Console.ReadLine();
        return input.ToLower().Equals("s")?true:false;
    }

    public void PrintBoard(Towers towers)
    {
        towers.PrintLayout();
    }

    public int PromptAmountOfDiscs()
    {
        Console.WriteLine("Input amount of discs for the game:");
        var input = Console.ReadLine();
        if (input.ToLower().Equals("q")) return -1;
        if (input.All(Char.IsDigit))
        {
            return Int32.Parse(input);
        }else
        {
            Console.WriteLine("Incorrect input.");
            PromptAmountOfDiscs();
        }
        return -1;
    }

    public int[] PromptMove()
    {
        Console.WriteLine("Input move:");
        var input = Console.ReadLine();
        var numbers = input.Split(" ");
        if(numbers.Length < 2 || numbers.Length > 2 || numbers[1] == "")
        {
            return IncorrectMove();
        }
        else if (numbers[0].All(Char.IsDigit) && numbers[1].All(Char.IsDigit))
        {
            var numbersInt = new int[] { Int32.Parse(numbers[0]), Int32.Parse(numbers[1]) };
            if (numbersInt[0] >= 1 && numbersInt[0] <= 3 && numbersInt[1] >= 1 && numbersInt[1] <= 3)
            {
                return numbersInt;
            }
            else
            {
                return IncorrectMove();
            }
        }
        return IncorrectMove();
    }

    public void PromptVictory(int amountOfMoves, int optimalAmountOfMoves)
    {
        if (amountOfMoves == optimalAmountOfMoves) Console.WriteLine("Congratulations, you completed the game in the least amount of moves!");
        else {
            Console.WriteLine("Congratulations, you completed the game in: " + amountOfMoves + " moves!");
            Console.WriteLine("The optimal solution is: " + optimalAmountOfMoves + " amount of moves.");
        }
        Console.ReadLine();
    }

    private int[] IncorrectMove()
    {
        Console.WriteLine("Incorrect move.");
        return PromptMove();
    }
}