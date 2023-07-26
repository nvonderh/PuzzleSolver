using Newtonsoft.Json.Linq;

namespace PuzzleSolver.Models
{
    public class ListOfListGrid : Grid
    {
        private List<List<Square>> Squares { get; set; }

        public ListOfListGrid(int maxValue)
        {
            MaxValue = maxValue;
            Squares = new List<List<Square>>();

            for (int i = 0; i < MaxValue; i++)
            {
                Squares.Add(new List<Square>());
                for (int j = 0; j < MaxValue; j++)
                {
                    Squares[i].Add(new Square(i, j, 0));
                }
            }
        }

        public ListOfListGrid(int[][] values)
        {
            MaxValue = values.Length;
            Squares = new List<List<Square>>();

            for (int i = 0; i < MaxValue; i++)
            {
                Squares.Add(new List<Square>());
                for (int j = 0; j < MaxValue; j++)
                {
                    Squares[i].Add(new Square(j, i, values[i][j]));
                }
            }
        }

        public int[][] ReturnGridAsArray()
        {
            int[][] intArray = new int[MaxValue][];
            for (int i = 0; i < MaxValue; i++)
            {
                intArray[i] = Squares[i].Select(x => x.Value).ToArray();
            }
            return intArray;
        }

        public override Square GetSquare(int x, int y)
        {
            return Squares[x][y];
        }

        public override Square? GetSolvableSquare()
        {
            return GetFullGrid().FirstOrDefault(a => a.PossibleValues.Count == 1);
        }

        public override List<Square> GetFullGrid()
        {
            return Squares.SelectMany(d => d).ToList();
        }

        public override List<Square> GetColumn(int x)
        {
            List<Square> squares = new List<Square>();
            foreach (var list in Squares)
            {
                squares.Add(list[x]);
            }
            return squares;
        }

        public override List<Square> GetRow(int y)
        {
            return Squares[y];
        }
    }
}
