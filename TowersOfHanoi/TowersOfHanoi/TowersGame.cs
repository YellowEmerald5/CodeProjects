
namespace TowersOfHanoi
{
    public class TowersGame
    {
        private readonly IUserInterface _userInterface;
        private Towers _tower = new Towers(0);

        public TowersGame(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public void Run()
        {
            if (!_userInterface.BeginGame()) return;
            var amountOfDiscs = _userInterface.PromptAmountOfDiscs();
            if (amountOfDiscs < 1) return;
            _tower = new(amountOfDiscs);
            bool completedGame = false;
            do
            {
                Console.Clear();
                _userInterface.PrintBoard(_tower);
                int[] move = _userInterface.PromptMove();
                if (move[0] == -1)
                {
                    return;
                }
                completedGame = _tower.Move(move);

            } while(!completedGame);
            _userInterface.PrintBoard(_tower);
            _userInterface.PromptVictory(_tower.amountOfMoves,_tower.optimalAmountOfMoves);
        }
    }
}
