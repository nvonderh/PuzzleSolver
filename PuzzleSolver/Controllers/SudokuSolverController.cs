using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.Models;
using PuzzleSolver.Models.Sudoku;

namespace PuzzleSolver.Controllers
{
    public class SudokuSolverController : Controller
    {
        public IActionResult Index()
        {
            return BlankPuzzle();
        }

        // GET: Sudoku/BlankPuzzle
        public IActionResult BlankPuzzle()
        {
            DictionaryGrid grid = new DictionaryGrid(9);
            return View("Puzzle", grid);
        }


        // GET: Sudoku/SolvePuzzle
        public IActionResult SolvePuzzle()
        {
            SudokuPuzzle puzzle;
            //puzzle = new SudokuPuzzle(SudokuPuzzleMaker.CreateEasyPuzzleGrid(0));
            //puzzle = new SudokuPuzzle(SudokuPuzzleMaker.CreateMediumPuzzleGrid(0));
            puzzle = new SudokuPuzzle(SudokuPuzzleMaker.CreateHardPuzzleGrid(1));
            DictionaryGrid solvedGrid = (DictionaryGrid)puzzle.Solve();
            return View("Solved", solvedGrid);
        }
    }
}
