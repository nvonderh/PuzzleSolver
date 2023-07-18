namespace PuzzleSolver.Models
{
    public class Rule
    {
        public RuleTypes Type { get; set; }
        public int Value { get; set; }
    }

    public enum RuleTypes
    {
        None = 0,
        NoDuplicates = 1,
    }
}
