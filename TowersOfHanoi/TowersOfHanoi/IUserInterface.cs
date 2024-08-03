namespace TowersOfHanoi
{
    public interface IUserInterface
    {
        bool BeginGame();
        void PrintBoard(Towers towers);
        int PromptAmountOfDiscs();
        int[] PromptMove();
        void PromptVictory(int amountOfMoves, int optimalAmountOfMoves);
    }
}