namespace PuzzleSolver.Models
{
    public abstract class Box
    {
        public List<Square> Squares { get; set; }
        public List<Rule> Rules { get; set; }

        public Box() 
        {
            Squares = new List<Square>();
            Rules = new List<Rule>();
        }

        public abstract void RemovePossibleAnswers(ref List<int> possibleAnswers);
        public virtual void FindUniqueValue(List<Square> squares, ref bool madeChange)
        {
            if (Rules.Any(a => a.Type ==  RuleTypes.NoDuplicates)) 
            {

            }
        }
        //public abstract void UpdateBox(Square solvedSquare);
    }
}
