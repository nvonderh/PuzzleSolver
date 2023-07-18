namespace PuzzleSolver.Models.Sudoku
{
    public class SudokuBox : Box
    {


        public SudokuBox()
        {
            Squares = new List<Square>();
            Rules = new List<Rule>();
            Rules.Add(new Rule() { Type = RuleTypes.NoDuplicates });
        }

        public override void RemovePossibleAnswers(ref List<int> possibleAnswers)
        {
            foreach (Square square in Squares)
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

        //public override void UpdateBox(Square solvedSquare)
        //{
        //    foreach(Square s in Squares)
        //    {
        //        if (!s.Solved && s.PossibleValues.Any(a => a.Value == solvedSquare.Value))
        //        {
        //            s.PossibleValues.RemoveAll(a => a.Value == solvedSquare.Value);
        //        }
        //    }
        //}
    }
}
