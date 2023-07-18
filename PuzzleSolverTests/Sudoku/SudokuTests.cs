using PuzzleSolver.Models.Sudoku;
using PuzzleSolver.Models;

namespace PuzzleSolverTests.SudokuTests
{
    [TestClass]
    public class SudokuTests
    {
        [TestMethod]
        public void EasyPuzzleTests()
        {
            int numTests = SudokuPuzzleMaker.GetNumPuzzles(SudokuDifficulty.Easy);

            SudokuPuzzle puzzle;

            for (int i = 0; i < numTests; i++)
            {
                puzzle = new SudokuPuzzle(SudokuPuzzleMaker.CreateEasyPuzzleGrid(i));
                DictionaryGrid solvedGrid = (DictionaryGrid)puzzle.Solve();
                Assert.IsTrue(puzzle.PuzzleIsSolved(), $"The puzzle {i} was not solved!");
            }
        }

        [TestMethod]
        public void MediumPuzzleTests()
        {
            int numTests = SudokuPuzzleMaker.GetNumPuzzles(SudokuDifficulty.Medium);

            SudokuPuzzle puzzle;

            for (int i = 0; i < numTests; i++)
            {
                puzzle = new SudokuPuzzle(SudokuPuzzleMaker.CreateMediumPuzzleGrid(i));
                DictionaryGrid solvedGrid = (DictionaryGrid)puzzle.Solve();
                Assert.IsTrue(puzzle.PuzzleIsSolved(), $"The puzzle {i} was not solved!");
            }
        }

        [TestMethod]
        public void HardPuzzleTests()
        {
            int numTests = SudokuPuzzleMaker.GetNumPuzzles(SudokuDifficulty.Hard);

            SudokuPuzzle puzzle;

            for (int i = 0; i < numTests; i++)
            {
                puzzle = new SudokuPuzzle(SudokuPuzzleMaker.CreateHardPuzzleGrid(i));
                DictionaryGrid solvedGrid = (DictionaryGrid)puzzle.Solve();
                Assert.IsTrue(puzzle.PuzzleIsSolved(), $"The puzzle {i} was not solved!");
            }
        }
    }
}