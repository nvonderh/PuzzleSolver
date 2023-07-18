using System.Collections.Generic;

namespace PuzzleSolver.Models.Sudoku
{
    public class SudokuPuzzle : Puzzle
    {
        public int SquareOfMaxValue
        {
            get
            {
                return (int)Math.Sqrt(PuzzleGrid.MaxValue);
            }
        }
        public SudokuPuzzle(int[][] values)
            : base(values)
        {

        }
        public SudokuPuzzle(DictionaryGrid grid)
            : base(grid)
        {

        }

        public override void SetupBoxes()
        {
            for (int i = 0; i < SquareOfMaxValue; i++)
            {
                for (int j = 0; j < SquareOfMaxValue; j++)
                {
                    Boxes.Add(CreateBox(i * SquareOfMaxValue, j * SquareOfMaxValue));
                }
            }
        }

        public Box CreateBox(int x, int y)
        {
            Box newBox = new SudokuBox();
            for (int i = x; i < x + SquareOfMaxValue; i++)
            {
                for (int j = y; j < y + SquareOfMaxValue; j++)
                {
                    newBox.Squares.Add(PuzzleGrid.GetSquare(i,j));
                }
            }
            return newBox;
        }

        public override bool Solve(ref bool madeChange)
        {
            // Find any squares that have only 1 possible answer
            Square? solvableSqure = PuzzleGrid.GetSolvableSquare();
            while (solvableSqure != null)
            {

                madeChange = true;
                solvableSqure.SolveSquare(solvableSqure.PossibleValues[0]);
                UpdatePuzzle(solvableSqure);

                if (PuzzleIsSolved())
                {
                    return true;
                }

                solvableSqure = PuzzleGrid.GetSolvableSquare();
            }

            // Find a square in a group that is the only one that COULD be a value
            madeChange |= CheckGridForUniqueValues();
            if (PuzzleIsSolved())
            {
                return true;
            }

            // Find a square in a group that is the only one that COULD be a value
            madeChange |= EliminatePossibleValues();
            if (PuzzleIsSolved())
            {
                return true;
            }

            madeChange |= CheckGridForUniqueValuesSubGroups();
            if (PuzzleIsSolved())
            {
                return true;
            }

            return false;
        }

        public virtual bool CheckGridForUniqueValuesSubGroups()
        {
            bool madeChange = false;

            // Check Columns
            for (int i = 0; i < PuzzleGrid.MaxValue; i++)
            {
                CheckGroupforUniqueValuesSubGroups(PuzzleGrid.GetRow(i).Where(a => !a.Solved).ToList(), ref madeChange);
            }

            // Check Rows
            for (int i = 0; i < PuzzleGrid.MaxValue; i++)
            {
                CheckGroupforUniqueValuesSubGroups(PuzzleGrid.GetColumn(i), ref madeChange);
            }

            return madeChange;
        }

        public virtual void CheckGroupforUniqueValuesSubGroups(List<Square> squares, ref bool madeChange)
        {
            List<Box> matchingBoxes = GetMatchingBoxes(squares);
            List<List<int>> possibleValuesSubGroup = new List<List<int>>();

            foreach (Box box in matchingBoxes)
            {
                List<Square> intersection = squares.Intersect(box.Squares).ToList();
                List<int> possibleValues = new List<int>();
                foreach (Square square in intersection)
                {
                    possibleValues.AddRange(square.PossibleValues.Except(possibleValues));
                }
                possibleValuesSubGroup.Add(possibleValues);
            }

            for (int i = 0; i < matchingBoxes.Count; i++)
            {

                List<int> otherGroupsPossibleValues = possibleValuesSubGroup.Where(a => a != possibleValuesSubGroup[i]).SelectMany(b => b).ToList();
                List<int> exceptions = possibleValuesSubGroup[i].Except(otherGroupsPossibleValues).ToList();

                if (exceptions.Count > 0)
                {
                    Box box = matchingBoxes[i];

                    foreach (var square in box.Squares.Where(a => !squares.Contains(a) && !a.Solved))
                    {
                        if (square.PossibleValues.Intersect(exceptions).Any())
                        {
                            square.RemovePossibleValueRange(exceptions);
                            madeChange = true;
                        }
                    }
                }
            }


        }
    }
}
