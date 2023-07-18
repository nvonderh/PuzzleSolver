using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuzzleSolver.Models
{
    public class Square
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
        //public List<PossibleValue> PossibleValues { get; set; }
        public List<int> PossibleValues { get; set; }
        public bool Solved { get; set; }

        public Square(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
            PossibleValues = new List<int>();
            Solved = value > 0;
        }

        public void SolveSquare(int value)
        {
            Value = value;
            Solved = true;
            PossibleValues.Clear();
        }

        public void RemovePossibleValue(int value)
        {
            PossibleValues.RemoveAll(a => a == value);
            return;
        }

        public void RemovePossibleValueRange(List<int> possibleValues)
        {
            PossibleValues.RemoveAll(a => possibleValues.Contains(a));
            return;
        }

        public bool PossibleValuesContains(int value)
        {
            return PossibleValues.Contains(value);
        }
    }

}
