using System.Collections.Generic;

namespace PuzzleSolver.Models
{
    public abstract class Puzzle
    {
        public int Id { get; set; }
        public Grid PuzzleGrid { get; set; }
        public List<Box> Boxes { get; set; }

        public Puzzle(int[][] values) 
        {
            Boxes = new List<Box>();
            PuzzleGrid = new DictionaryGrid(values);
            SetupBoxes();
            SetupPossibleAnswers();
        }

        public Puzzle(DictionaryGrid grid)
        {
            Boxes = new List<Box>();
            PuzzleGrid = grid;
            SetupBoxes();
            SetupPossibleAnswers();
        }

        public bool PuzzleIsSolved()
        {
            return PuzzleGrid.GetFullGrid().All(a => a.Solved);
        }

        public abstract bool Solve(ref bool madeChange);
        public abstract void SetupBoxes();

        public List<Box> GetMatchingBoxes(List<Square> squares)
        {
            return Boxes.Where(a => a.Squares.Intersect(squares).Any()).ToList();
        }

        public Grid Solve()
        {
            bool madeChange;
            bool solved;
            do
            {
                madeChange = false;
                solved = Solve(ref madeChange);
            } while (!solved && madeChange);
            return PuzzleGrid;
        }

        public virtual void UpdatePuzzle(Square solvedSqure)
        {
            UpdateGrid(solvedSqure);
            Box? box = Boxes.FirstOrDefault(a => a.Squares.Contains(solvedSqure));
            if (box != null)
            {
                RemoveFromPossibleValues(box.Squares, solvedSqure.Value);
            }
        }

        public virtual void RemoveFromPossibleValues(List<Square> squareList, int solvedValue)
        {
            foreach (Square s in squareList)
            {
                if (!s.Solved && s.PossibleValuesContains(solvedValue))
                {
                    s.RemovePossibleValue(solvedValue);
                }
            }
        }

        public virtual void RemoveFromPossibleAnswers(Square square, ref List<int> possibleAnswers)
        {
            RemovePossibleAnswerFromSquares(PuzzleGrid.GetRow(square.Y), ref possibleAnswers);
            RemovePossibleAnswerFromSquares(PuzzleGrid.GetColumn(square.X), ref possibleAnswers);

            Box? box = Boxes.FirstOrDefault(a => a.Squares.Contains(square));
            if (box != null)
            {
                box.RemovePossibleAnswers(ref possibleAnswers);
            }

        }

        public virtual void RemovePossibleAnswerFromSquares(List<Square> squareList, ref List<int> possibleAnswers)
        {
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

        public virtual void UpdateGrid(Square solvedSquare)
        {
            UpdateRow(solvedSquare);
            UpdateColumn(solvedSquare);
        }

        public virtual void UpdateRow(Square solvedSquare)
        {
            List<Square> squareList = PuzzleGrid.GetRow(solvedSquare.Y);
            RemoveFromPossibleValues(squareList, solvedSquare.Value);
        }

        public virtual void UpdateColumn(Square solvedSquare)
        {
            List<Square> squareList = PuzzleGrid.GetColumn(solvedSquare.X);
            RemoveFromPossibleValues(squareList, solvedSquare.Value);
        }

        /// <summary>
        /// Currently working
        /// </summary>
        /// <returns></returns>
        public virtual bool CheckGridForUniqueValues()
        {
            bool madeChange = false;
            // Check Columns
            for (int i = 0; i < PuzzleGrid.MaxValue; i++)
            {
                FindUniqueValue(PuzzleGrid.GetRow(i), ref madeChange);
            }

            // Check Rows
            for (int i = 0; i < PuzzleGrid.MaxValue; i++)
            {
                FindUniqueValue(PuzzleGrid.GetColumn(i), ref madeChange);
            }

            foreach (Box box in Boxes.Where(a => a.Rules.Any(b => b.Type == RuleTypes.NoDuplicates)))
            {
                FindUniqueValue(box.Squares, ref madeChange);
            }

            return madeChange;


        }

        public virtual void FindUniqueValue(List<Square> squares, ref bool madeChange)
        {
            List<int> solvedValues = squares.Where(a => a.Solved).Select(a => a.Value).ToList();
            List<Square> unsolvedSquares = squares.Where(a => !a.Solved).ToList();

            for (int i = 1; i <= PuzzleGrid.MaxValue; i++)
            {
                if (!solvedValues.Contains(i))
                {
                    if (unsolvedSquares.Where( a => a.PossibleValuesContains(i)).ToList().Count == 1)
                    {
                        var square = unsolvedSquares.FirstOrDefault( a => a.PossibleValuesContains(i));
                        if (square != null)
                        {
                            square.SolveSquare(i);
                            UpdatePuzzle(square);
                            madeChange = true;
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Currently Working
        /// </summary>
        /// <returns></returns>
        public virtual bool EliminatePossibleValues()
        {
            bool madeChange = false;
            // Check Columns
            for (int i = 0; i < PuzzleGrid.MaxValue; i++)
            {
                EliminatePossibleValuesFromGroup(PuzzleGrid.GetRow(i), ref madeChange);
            }

            // Check Rows
            for (int i = 0; i < PuzzleGrid.MaxValue; i++)
            {
                EliminatePossibleValuesFromGroup(PuzzleGrid.GetColumn(i), ref madeChange);
            }

            // Check Boxes with the NoDuplicates RuleType
            foreach (Box box in Boxes.Where(a => a.Rules.Any(b => b.Type == RuleTypes.NoDuplicates)))
            {
                EliminatePossibleValuesFromGroup(box.Squares, ref madeChange);
            }

            return madeChange;
        }

        public virtual void EliminatePossibleValuesFromGroup(List<Square> squares, ref bool madeChange)
        {
            List<int> possibleValues = Enumerable.Range(1, PuzzleGrid.MaxValue).ToList();
            RemovePossibleAnswerFromSquares(squares, ref possibleValues);
            List<Square> unsolvedSquares = squares.Where(a => !a.Solved).ToList();

            for (int i = 2; i < unsolvedSquares.Count; i++)
            {
                FindUniqueGroupings(unsolvedSquares, possibleValues, ref madeChange);
            }
        }

        public virtual void FindUniqueGroupings(List<Square> unsolvedSquares, List<int> possibleValues, ref bool madeChange)
        {
            List<List<int>> list = new List<List<int>>();

            for (int i = 2; i < unsolvedSquares.Count; i++)
            {
                List<int> subList = new List<int>();
                list.AddRange(FindPossibilitiesRecursive(0, i, new List<int>(), possibleValues));
            }

            foreach (var possibility in list)
            {
                List<Square> matchingSquares = unsolvedSquares.Where(a => IsSubset(possibility, a.PossibleValues)).ToList();

                if (matchingSquares.Count() == possibility.Count())
                {
                    foreach (var square in unsolvedSquares.Where(a => !matchingSquares.Contains(a)))
                    {
                        if (square.PossibleValues.Intersect(possibility).Any())
                        {
                            square.RemovePossibleValueRange(possibility);
                            madeChange = true;
                        }
                    }
                }
            }
        }

        public virtual List<List<int>> FindPossibilitiesRecursive(int nextIndex, int numValues, List<int> subList, List<int> possibleValues)
        {
            if (nextIndex == possibleValues.Count)
            {
                return new List<List<int>>();
            }

            List<List<int>> grid = new List<List<int>>();
            List<int> newList = new List<int>(subList);

            newList.Add(possibleValues[nextIndex]);

            if (newList.Count == numValues)
            {
                grid.Add(newList);
            }
            else
            {
                grid = FindPossibilitiesRecursive(nextIndex + 1, numValues, newList, possibleValues);
            }
            grid.AddRange(FindPossibilitiesRecursive(nextIndex + 1, numValues, subList, possibleValues));

            return grid;

        }

        public bool IsSubset(ICollection<int> bigCollection, ICollection<int> subsetCollection)
        {
            return subsetCollection.All(elem => bigCollection.Contains(elem));
        }


        public virtual void SetupPossibleAnswers()
        {
            List<Square> squares = PuzzleGrid.GetFullGrid();
            foreach (Square square in squares)
            {
                if (square.Solved)
                {
                    continue;
                }

                List<int> possibleValues = Enumerable.Range(1, PuzzleGrid.MaxValue).ToList();

                RemoveFromPossibleAnswers(square, ref possibleValues);

                square.PossibleValues = possibleValues;
            }
        }
    }
}
