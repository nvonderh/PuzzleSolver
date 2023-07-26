using Newtonsoft.Json.Linq;

namespace PuzzleSolver.Models
{
    public class DictionaryGrid : Grid
    {
        private Dictionary<GridIndex, Square> Squares { get; set; }

        public DictionaryGrid(int maxValue)
        {
            MaxValue = maxValue;
            Squares = new Dictionary<GridIndex, Square>();
            GridIndex index;

            for (int y = 0; y < MaxValue; y++)
            {
                for (int x = 0; x < MaxValue; x++)
                {
                    index = new GridIndex(x, y);
                    Squares[index] = new Square(x, y, 0);
                }
            }
        }

        public DictionaryGrid(int[][] values)
        {
            MaxValue = values.Length;
            Squares = new Dictionary<GridIndex, Square>();
            GridIndex index;

            for (int y = 0; y < MaxValue; y++)
            {
                for (int x = 0; x < MaxValue; x++)
                {
                    index = new GridIndex(x, y);
                    Squares[index] = new Square(x, y, values[y][x]);
                }
            }
        }

        public int[][] ReturnGridAsArray()
        {
            int[][] intArray = new int[MaxValue][];
            GridIndex index;
            for (int i = 0; i < MaxValue; i++)
            {
                intArray[i] = new int[MaxValue];
                for (int j = 0; j < MaxValue; j++)
                {
                    index = new GridIndex(i, j);
                    intArray[i][j] = Squares[index].Value;
                }
            }
            return intArray;
        }

        public override Square GetSquare(int x, int y)
        {
            return Squares[new GridIndex(x, y)];
        }

        public override Square? GetSolvableSquare()
        {
            return Squares.Values.FirstOrDefault(a => a.PossibleValues.Count == 1);
        }

        public override List<Square> GetFullGrid()
        {
            return Squares.Values.ToList();
        }

        public override List<Square> GetColumn(int x)
        {
            List<GridIndex> indices = Squares.Keys.Where(a => a.x == x).ToList();
            List<Square> squares = new List<Square>();
            foreach (GridIndex index in indices)
            {
                squares.Add(Squares[index]);
            }
            return squares;
        }

        public override List<Square> GetRow(int y)
        {
            List<GridIndex> indices = Squares.Keys.Where(a => a.y == y).ToList();
            List<Square> squares = new List<Square>();
            foreach (GridIndex index in indices)
            {
                squares.Add(Squares[index]);
            }
            return squares;
        }
    }

    public class GridIndex
    {
        public int x;
        public int y;

        public GridIndex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is GridIndex))
            {
                return false;
            }
            return this.x == ((GridIndex)obj).x && this.y == ((GridIndex)obj).y;
        }

        public override int GetHashCode()
        {
            return x * 100 + y;
        }
    }
}
