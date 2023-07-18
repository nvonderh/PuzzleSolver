using Newtonsoft.Json.Linq;

namespace PuzzleSolver.Models
{
    public class DatabaseGrid : Grid
    {
        private Dictionary<GridIndex, Square> Squares { get; set; }

        public DatabaseGrid(int maxValue)
        {
            MaxValue = maxValue;
            Squares = new Dictionary<GridIndex, Square>();
            GridIndex index;

            for (int i = 0; i < MaxValue; i++)
            {
                for (int j = 0; j < MaxValue; j++)
                {
                    index = new GridIndex(i, j);
                    Squares[index] = new Square(i, j, 0);
                }
            }
        }

        public DatabaseGrid(int[][] values)
        {
            MaxValue = values.Length;
            Squares = new Dictionary<GridIndex, Square>();
            GridIndex index;

            for (int i = 0; i < MaxValue; i++)
            {
                for (int j = 0; j < MaxValue; j++)
                {
                    index = new GridIndex(i, j);
                    Squares[index] = new Square(i, j, values[i][j]);
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
            throw new NotImplementedException();
        }

        public override List<Square> GetFullGrid()
        {
            return Squares.Values.ToList();
        }

        public override List<Square> GetColumn(int x)
        {
            throw new NotImplementedException();
        }

        public override List<Square> GetRow(int y)
        {
            throw new NotImplementedException();
        }

        //public override void UpdateRow(Square solvedSquare)
        //{
        //    throw new NotImplementedException();
        //}

        //public override void UpdateColumn(Square solvedSquare)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
