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
        /// Currently Working.
        /// Check for any Square in a column/row/box that is the only one to contain a value in possible values
        /// </summary>
        /// <returns>true if a change was made, otherwise false</returns>
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

        /// <summary>
        /// Check for any Square in squares that is the only one to contain a value in possible values
        /// </summary>
        /// <param name="squares">Current List of Squares to be checked, could be a Column, Row or Box</param>
        /// <param name="madeChange">The value returned by the outer method to prevent infinite loops</param>
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
        /// Currently Working.
        /// This will clean up PossibleValues in groups of squares based on the contents of PossibleValues within those squares
        /// </summary>
        /// <returns>true if a change was made, otherwise false</returns>
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

            FindUniqueGroupings(unsolvedSquares, possibleValues, ref madeChange);
        }

        // Example 1: 4 squares in the list have [4,7],[4,7],[1,4,7,8],[1,4,8]. We find 2 squares match the possibility of size 2 [4,7].
        // Those values are then eliminated from the other squares' possible values leaving: [4,7],[4,7],[1,8],[1,8]
        // Example 2: 4 squares in the list have [3,4],[4,5],[3,5],[3,4,8]. We find 3 squares match the possibility of size 3 [3,4,5].
        // Those values are then eliminated from the other squares' possible values leaving: [3,4],[4,5],[3,5],[8]
        /// <summary>
        /// Find Unique Groups in the list unsolvedSquares and remove their possible values from every other square in unsolvedSquare
        /// </summary>
        /// <param name="unsolvedSquares">A grouping of unsolved squares from a row, column, or box</param>
        /// <param name="possibleValues">All possible values for squares in unsolvedSquares</param>
        /// <param name="madeChange">The value returned by the outer method to prevent infinite loops</param>
        public virtual void FindUniqueGroupings(List<Square> unsolvedSquares, List<int> possibleValues, ref bool madeChange)
        {
            List<List<int>> possibilitiesList = new List<List<int>>();

            for (int i = 2; i < unsolvedSquares.Count; i++)
            {
                possibilitiesList.AddRange(FindPossibilitiesRecursive(0, i, new List<int>(), possibleValues));
            }

            foreach (var possibility in possibilitiesList)
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

        /// <summary>
        /// This will create every possible pairing of possibilities of length numValues
        /// from possibleValues, it will add possibleValues[currentIndex] to newList.
        /// If newList has a length of numValues, it will be added to the return value possibilitiesList,
        /// otherwise it will call itself by passing in currentIndex+1 and newList. It will then call
        /// itself with currentIndex+1 and the subList that was passed in.
        /// </summary>
        /// <param name="currentIndex">The index we are checking</param>
        /// <param name="numValues">The number of values that should be in the possibilityList</param>
        /// <param name="subList">The list of possibilities that have already been added</param>
        /// <param name="possibleValues">The list of possible values that we will be adding from</param>
        /// <returns>A List of Possibility Lists of length numValues</returns>
        public virtual List<List<int>> FindPossibilitiesRecursive(int currentIndex, int numValues, List<int> subList, List<int> possibleValues)
        {
            if (currentIndex == possibleValues.Count)
            {
                return new List<List<int>>();
            }

            List<List<int>> possibilitiesList = new List<List<int>>();
            List<int> newList = new List<int>(subList);

            newList.Add(possibleValues[currentIndex]);

            if (newList.Count == numValues)
            {
                possibilitiesList.Add(newList);
            }
            else
            {
                possibilitiesList = FindPossibilitiesRecursive(currentIndex + 1, numValues, newList, possibleValues);
            }
            possibilitiesList.AddRange(FindPossibilitiesRecursive(currentIndex + 1, numValues, subList, possibleValues));

            return possibilitiesList;

        }

        /// <summary>
        /// A helper method to check if a collection is a subset of another.
        /// </summary>
        /// <param name="bigCollection"></param>
        /// <param name="subsetCollection"></param>
        /// <returns>true if every element in subsetCollection is in bigCollection</returns>
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
