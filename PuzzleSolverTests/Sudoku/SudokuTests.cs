using PuzzleSolver.Models;
using PuzzleSolver.Models.Sudoku;

namespace PuzzleSolverTests.SudokuTests
{
    [TestClass]
    public class SudokuTests
    {
        private static bool enableHeavyTests = false;

        [TestMethod]
        public void EasyPuzzleTests()
        {
            int numTests = SudokuPuzzleMaker.GetNumPuzzles(SudokuDifficulty.Easy);

            SudokuPuzzle puzzle;

            for (int i = 0; i < numTests; i++)
            {
                puzzle = new SudokuPuzzle(SudokuPuzzleMaker.CreateEasyPuzzleGrid(i));
                puzzle.Solve();
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
                puzzle.Solve();
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
                puzzle.Solve();
                Assert.IsTrue(puzzle.PuzzleIsSolved(), $"The puzzle {i} was not solved!");
            }
        }


        // DictionaryGrid is slightly faster than ListOfListGrid
        [TestMethod]
        public void EfficiencyTesting()
        {
            if (enableHeavyTests)
            {
                SudokuPuzzle puzzle;

                for (int i = 0; i < 1000; i++)
                {
                    puzzle = new SudokuPuzzle(SudokuPuzzleMaker.CreateHardPuzzleGrid(0));
                    puzzle.Solve();
                    Assert.IsTrue(puzzle.PuzzleIsSolved(), $"The puzzle {i} was not solved!");
                }
            }
        }
    }
}