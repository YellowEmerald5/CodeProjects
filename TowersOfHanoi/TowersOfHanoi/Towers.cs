

namespace TowersOfHanoi
{
    public class Towers
    {
        private int[,] _state;
        private int _amountOfPieces;
        private const int amountOfTowers = 3;
        private int[] _posTowers;
        public int amountOfMoves = 0;
        public int optimalAmountOfMoves;
        public Towers(int amountOfPieces)
        {
            _amountOfPieces = amountOfPieces;
           optimalAmountOfMoves = (int)Math.Pow(2,amountOfPieces)-1;
            _state = new int[3, amountOfPieces];
            _posTowers = new int[] { 0 , _amountOfPieces-1, _amountOfPieces-1 };
            int i = 1;
            for (int j = 0; j < amountOfPieces; j++) { 
                _state[0,j] = i;
                i++;
            }
        }

        public void PrintLayout()
        {
            for (int j = 0; j < _amountOfPieces ; j++)
            {
                string str = "";
                for (int i = 0; i < amountOfTowers; i++)
                {
                    var piece = Piece(_state[i,j]);
                    var spacing = Spacing(_state[i,j]);
                    str += spacing + piece + spacing;
                }
                Console.WriteLine(str);
            }
        }

        public bool Move(int[] move)
        {
            int[] moves = new int[] { move[0] - 1, move[1]-1 };
            amountOfMoves ++;

            if (_posTowers[moves[0]] == _amountOfPieces-1 && _state[moves[0], _posTowers[moves[0]]] == 0) return false;
            var numPillar1 = _state[moves[0], _posTowers[moves[0]]];
            var numPillar2 = _state[moves[1], _posTowers[moves[1]]];

            if (numPillar1 < numPillar2 || numPillar2 == 0)
            {
                if (_state[moves[1],_posTowers[moves[1]]] != 0) _posTowers[moves[1]]--;
                _state[moves[1], _posTowers[moves[1]]] = _state[moves[0], _posTowers[moves[0]]];
                _state[moves[0], _posTowers[moves[0]]] = 0;
                if (_posTowers[moves[0]] < _amountOfPieces-1)_posTowers[moves[0]]++;
                if (_state[2, 0] == 1) return true;
            }
            return false;
        }

        private string Spacing(int i)
        {
            string str = "";
            var length = (_amountOfPieces - 1)-(i-1);
            if (i == 0) length = _amountOfPieces - 1;
            for (int j = 0; j < length; j++)
            {
                str += " ";
            }
            return str;
        }

        private string Piece(int i)
        {
            string str = "";
            if(i == 1) return "*";
            if (i == 0) return "|";
            for (int j = 0; j < i+(i-1); j++)
            {
                if((j%2) == 0)
                {
                    str += "*";
                }
                else
                {
                    str += " ";
                }
            }
            return str;
        }
    }
}