using Newtonsoft.Json.Linq;

namespace PuzzleSolver.Models
{
    public abstract class Grid
    {
        public int MaxValue;

        public abstract Square GetSquare(int x, int y);

        public abstract Square? GetSolvableSquare();

        public abstract List<Square> GetFullGrid();

        public abstract List<Square> GetColumn(int x);

        public abstract List<Square> GetRow(int y);

        public virtual void RemovePossibleAnswersFromRow(int row, ref List<int> possibleAnswers)
        {
            List<Square> squareList = GetRow(row);
            foreach (Square square in squareList)
            {
                if (square.Solved)
                {
                    if (possibleAnswers.Any(a => a == square.Value))
                    {
                        possibleAnswers.RemoveAll(a => a == square.Value);
                    }
                }
            }
        }

        public virtual void RemovePossibleAnswersFromColumn(int column, ref List<int> possibleAnswers)
        {
            List<Square> squareList = GetColumn(column);
            foreach (Square square in squareList)
            {
                if (square.Solved)
                {
                    if (possibleAnswers.Any(a => a == square.Value))
                    {
                        possibleAnswers.RemoveAll(a => a == square.Value);
                    }
                }
            }
        }
    }
}
