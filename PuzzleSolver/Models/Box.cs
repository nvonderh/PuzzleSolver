namespace PuzzleSolver.Models
{
    public abstract class Box
    {
        public List<Square> Squares { get; set; }
        public List<Rule> Rules { get; set; }
        public int MaxValue { get; set; }

        public Box() 
        {
            Squares = new List<Square>();
            Rules = new List<Rule>();
            MaxValue = 9;
        }

        public List<Square> UnsolvedSquares
        {
            get
            {
                return Squares.Where(a => !a.Solved).ToList();
            }
        }

        public abstract void RemovePossibleAnswers(ref List<int> possibleAnswers);
        public abstract void UpdateBox(Square solvedSquare);
    }
}
