namespace PuzzleSolver.Models.Sudoku
{
    public static class SudokuPuzzleMaker
    {
        public static int GetNumPuzzles(SudokuDifficulty difficulty)
        {
            switch (difficulty)
            {
                case SudokuDifficulty.Easy:
                    return 5;
                    
                case SudokuDifficulty.Medium:
                    return 5;
                    
                case SudokuDifficulty.Hard:
                    return 5;

                default:
                    return 0;
            }
        }
        public static int[][] CreateEasyPuzzleGrid(int i)
        {
            int[][] grid = new int[9][];
            switch (i)
            {
                case 0:
                    grid[0] = new int[] { 7, 1, 0,   0, 0, 5,   8, 0, 3 };
                    grid[1] = new int[] { 0, 0, 0,   3, 4, 0,   0, 7, 5 };
                    grid[2] = new int[] { 3, 2, 0,   8, 9, 7,   0, 0, 0 };

                    grid[3] = new int[] { 6, 0, 0,   0, 0, 2,   4, 8, 0 };
                    grid[4] = new int[] { 1, 0, 7,   0, 0, 3,   5, 0, 0 };
                    grid[5] = new int[] { 8, 0, 0,   0, 5, 4,   3, 0, 7 };

                    grid[6] = new int[] { 0, 8, 9,   7, 0, 0,   1, 3, 4 };
                    grid[7] = new int[] { 0, 7, 1,   4, 0, 0,   0, 0, 0 };
                    grid[8] = new int[] { 0, 0, 0,   0, 0, 0,   0, 2, 8 };
                    break;

                case 1:
                    grid[0] = new int[] { 2, 9, 0,   0, 0, 4,   8, 3, 0 };
                    grid[1] = new int[] { 7, 0, 0,   3, 0, 5,   0, 2, 1 };
                    grid[2] = new int[] { 0, 1, 6,   7, 0, 8,   4, 0, 0 };

                    grid[3] = new int[] { 6, 0, 0,   8, 7, 0,   1, 0, 3 };
                    grid[4] = new int[] { 1, 4, 8,   2, 0, 0,   0, 0, 0 };
                    grid[5] = new int[] { 9, 0, 0,   1, 0, 0,   0, 8, 0 };

                    grid[6] = new int[] { 0, 0, 0,   0, 3, 0,   7, 9, 4 };
                    grid[7] = new int[] { 5, 2, 9,   0, 6, 0,   0, 0, 0 };
                    grid[8] = new int[] { 0, 0, 7,   0, 8, 0,   0, 0, 5 };
                    break;

                case 2:
                    grid[0] = new int[] { 5, 0, 0,   4, 2, 7,   0, 1, 0 };
                    grid[1] = new int[] { 9, 0, 7,   0, 6, 0,   4, 2, 0 };
                    grid[2] = new int[] { 2, 0, 1,   0, 0, 0,   7, 0, 6 };

                    grid[3] = new int[] { 1, 5, 6,   0, 0, 2,   9, 0, 0 };
                    grid[4] = new int[] { 0, 0, 0,   9, 8, 0,   5, 0, 1 };
                    grid[5] = new int[] { 0, 0, 3,   6, 0, 5,   0, 4, 0 };

                    grid[6] = new int[] { 0, 8, 0,   0, 7, 0,   0, 0, 5 };
                    grid[7] = new int[] { 0, 7, 9,   0, 0, 0,   1, 3, 0 };
                    grid[8] = new int[] { 0, 0, 0,   3, 9, 6,   0, 0, 2 };
                    break;

                case 3:
                    grid[0] = new int[] { 0, 6, 2,   0, 0, 0,   0, 0, 4 };
                    grid[1] = new int[] { 1, 0, 7,   4, 0, 8,   9, 0, 0 };
                    grid[2] = new int[] { 8, 0, 4,   0, 7, 9,   1, 0, 3 };

                    grid[3] = new int[] { 4, 0, 0,   9, 3, 1,   8, 0, 0 };
                    grid[4] = new int[] { 7, 0, 1,   8, 0, 0,   4, 0, 2 };
                    grid[5] = new int[] { 5, 0, 3,   0, 4, 0,   0, 0, 0 };

                    grid[6] = new int[] { 0, 4, 0,   0, 9, 3,   0, 6, 7 };
                    grid[7] = new int[] { 0, 7, 0,   2, 0, 0,   0, 0, 1 };
                    grid[8] = new int[] { 3, 1, 0,   0, 0, 0,   0, 4, 0 };
                    break;

                case 4:
                    grid[0] = new int[] { 0, 0, 0,   7, 1, 8,   0, 0, 3 };
                    grid[1] = new int[] { 0, 0, 0,   0, 3, 9,   2, 0, 1 };
                    grid[2] = new int[] { 3, 1, 4,   5, 0, 0,   0, 0, 9 };

                    grid[3] = new int[] { 5, 9, 6,   8, 0, 7,   0, 0, 0 };
                    grid[4] = new int[] { 0, 0, 8,   0, 5, 6,   0, 7, 0 };
                    grid[5] = new int[] { 0, 0, 2,   9, 0, 0,   0, 6, 0 };

                    grid[6] = new int[] { 2, 5, 3,   0, 8, 0,   1, 0, 0 };
                    grid[7] = new int[] { 8, 0, 0,   2, 0, 0,   4, 3, 0 };
                    grid[8] = new int[] { 4, 6, 0,   0, 0, 3,   8, 0, 0 };
                    break;

                default:
                    grid[0] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[1] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[2] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };

                    grid[3] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[4] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[5] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };

                    grid[6] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[7] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[8] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    break;
            }
            return grid;
        }

        public static int[][] CreateMediumPuzzleGrid(int i)
        {
            int[][] grid = new int[9][];
            switch (i)
            {
                case 0:
                    grid[0] = new int[] { 9, 0, 0,   8, 0, 0,   2, 7, 3 };
                    grid[1] = new int[] { 0, 0, 0,   4, 0, 0,   0, 0, 0 };
                    grid[2] = new int[] { 0, 3, 2,   0, 0, 0,   0, 0, 6 };

                    grid[3] = new int[] { 1, 0, 8,   0, 0, 0,   0, 0, 0 };
                    grid[4] = new int[] { 0, 0, 5,   0, 8, 0,   3, 0, 0 };
                    grid[5] = new int[] { 0, 9, 0,   0, 0, 5,   0, 6, 0 };

                    grid[6] = new int[] { 0, 0, 0,   0, 1, 0,   6, 2, 0 };
                    grid[7] = new int[] { 0, 0, 0,   0, 0, 2,   8, 0, 0 };
                    grid[8] = new int[] { 5, 0, 3,   0, 0, 0,   0, 0, 9 };
                    break;

                case 1:
                    grid[0] = new int[] { 0, 0, 1,   0, 0, 0,   5, 9, 7 };
                    grid[1] = new int[] { 0, 0, 0,   0, 1, 8,   0, 0, 0 };
                    grid[2] = new int[] { 0, 5, 2,   0, 0, 0,   0, 0, 1 };

                    grid[3] = new int[] { 0, 0, 0,   0, 0, 9,   0, 0, 0 };
                    grid[4] = new int[] { 0, 8, 0,   2, 0, 0,   0, 0, 3 };
                    grid[5] = new int[] { 0, 3, 0,   0, 0, 4,   0, 1, 2 };

                    grid[6] = new int[] { 4, 0, 0,   0, 8, 0,   7, 0, 0 };
                    grid[7] = new int[] { 0, 0, 0,   6, 0, 0,   0, 2, 0 };
                    grid[8] = new int[] { 9, 7, 0,   0, 0, 0,   0, 0, 0 };
                    break;

                case 2:
                    grid[0] = new int[] { 0, 5, 0,   1, 0, 2,   0, 7, 8 };
                    grid[1] = new int[] { 1, 0, 4,   5, 0, 0,   0, 9, 0 };
                    grid[2] = new int[] { 0, 0, 0,   8, 0, 0,   0, 0, 0 };

                    grid[3] = new int[] { 8, 0, 5,   0, 0, 0,   0, 0, 2 };
                    grid[4] = new int[] { 0, 6, 0,   0, 0, 3,   0, 0, 0 };
                    grid[5] = new int[] { 7, 2, 0,   0, 4, 0,   0, 0, 0 };

                    grid[6] = new int[] { 0, 0, 0,   0, 0, 0,   9, 5, 6 };
                    grid[7] = new int[] { 0, 0, 8,   0, 0, 0,   0, 0, 0 };
                    grid[8] = new int[] { 0, 0, 0,   0, 7, 0,   0, 1, 0 };
                    break;

                case 3:
                    grid[0] = new int[] { 7, 0, 0,   0, 0, 9,   0, 0, 0 };
                    grid[1] = new int[] { 6, 9, 0,   0, 0, 0,   0, 0, 0 };
                    grid[2] = new int[] { 0, 0, 2,   0, 0, 8,   0, 4, 0 };

                    grid[3] = new int[] { 0, 0, 0,   0, 5, 0,   0, 1, 6 };
                    grid[4] = new int[] { 0, 0, 0,   0, 0, 0,   9, 0, 0 };
                    grid[5] = new int[] { 8, 0, 0,   0, 9, 0,   0, 7, 0 };

                    grid[6] = new int[] { 0, 6, 0,   0, 0, 0,   0, 0, 3 };
                    grid[7] = new int[] { 1, 0, 0,   4, 0, 3,   0, 8, 5 };
                    grid[8] = new int[] { 3, 5, 0,   0, 0, 0,   1, 0, 0 };
                    break;

                case 4:
                    grid[0] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[1] = new int[] { 1, 0, 9,   0, 0, 0,   0, 0, 4 };
                    grid[2] = new int[] { 0, 4, 0,   0, 2, 0,   6, 0, 1 };

                    grid[3] = new int[] { 0, 0, 1,   0, 0, 8,   0, 0, 0 };
                    grid[4] = new int[] { 0, 6, 0,   0, 4, 0,   0, 0, 3 };
                    grid[5] = new int[] { 8, 0, 0,   2, 0, 3,   0, 0, 0 };

                    grid[6] = new int[] { 0, 0, 0,   0, 0, 0,   7, 8, 5 };
                    grid[7] = new int[] { 9, 0, 0,   7, 0, 0,   4, 0, 6 };
                    grid[8] = new int[] { 0, 2, 0,   8, 0, 6,   0, 0, 0 };
                    break;

                default:
                    grid[0] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[1] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[2] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };

                    grid[3] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[4] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[5] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };

                    grid[6] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[7] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[8] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    break;
            }
            return grid;
        }

        public static int[][] CreateHardPuzzleGrid(int i)
        {
            int[][] grid = new int[9][];
            switch (i)
            {
                // Solved
                case 0:
                    grid[0] = new int[] { 0, 0, 9,   3, 0, 0,   0, 8, 0 };
                    grid[1] = new int[] { 8, 6, 0,   0, 0, 7,   0, 0, 5 };
                    grid[2] = new int[] { 5, 0, 0,   0, 0, 8,   0, 0, 6 };

                    grid[3] = new int[] { 0, 0, 0,   0, 0, 0,   0, 4, 0 };
                    grid[4] = new int[] { 0, 0, 0,   0, 0, 1,   2, 0, 3 };
                    grid[5] = new int[] { 6, 0, 0,   0, 2, 0,   0, 0, 0 };

                    grid[6] = new int[] { 0, 7, 2,   0, 0, 0,   0, 0, 0 };
                    grid[7] = new int[] { 4, 0, 0,   8, 0, 0,   3, 5, 0 };
                    grid[8] = new int[] { 0, 0, 5,   0, 4, 0,   1, 0, 0 };
                    break;

                case 1:
                    grid[0] = new int[] { 3, 0, 0,   0, 2, 0,   0, 0, 0 };
                    grid[1] = new int[] { 9, 6, 0,   0, 7, 0,   0, 0, 0 };
                    grid[2] = new int[] { 0, 0, 0,   4, 0, 1,   3, 8, 0 };

                    grid[3] = new int[] { 0, 2, 0,   8, 0, 0,   0, 4, 0 };
                    grid[4] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[5] = new int[] { 6, 4, 0,   0, 1, 0,   0, 3, 0 };

                    grid[6] = new int[] { 0, 0, 3,   0, 0, 0,   7, 0, 0 };
                    grid[7] = new int[] { 2, 0, 0,   0, 0, 7,   8, 0, 9 };
                    grid[8] = new int[] { 0, 0, 0,   0, 0, 0,   0, 2, 0 };
                    break;

                case 2:
                    grid[0] = new int[] { 0, 0, 3,   1, 0, 0,   2, 7, 9 };
                    grid[1] = new int[] { 0, 0, 0,   0, 3, 0,   0, 0, 0 };
                    grid[2] = new int[] { 0, 0, 0,   7, 0, 0,   0, 0, 0 };

                    grid[3] = new int[] { 0, 0, 0,   0, 2, 0,   1, 0, 0 };
                    grid[4] = new int[] { 0, 4, 0,   0, 9, 0,   8, 0, 0 };
                    grid[5] = new int[] { 0, 8, 6,   0, 0, 0,   0, 0, 5 };

                    grid[6] = new int[] { 4, 0, 0,   0, 0, 2,   0, 0, 8 };
                    grid[7] = new int[] { 0, 0, 0,   8, 0, 6,   0, 0, 0 };
                    grid[8] = new int[] { 0, 0, 9,   0, 7, 0,   0, 0, 1 };
                    break;

                case 3:
                    grid[0] = new int[] { 0, 0, 2,   0, 0, 5,   4, 0, 0 };
                    grid[1] = new int[] { 5, 1, 0,   0, 2, 9,   0, 0, 0 };
                    grid[2] = new int[] { 0, 4, 0,   7, 0, 0,   0, 0, 0 };

                    grid[3] = new int[] { 0, 0, 9,   5, 0, 0,   0, 8, 7 };
                    grid[4] = new int[] { 0, 0, 8,   0, 0, 0,   3, 5, 0 };
                    grid[5] = new int[] { 0, 5, 0,   0, 9, 0,   0, 0, 0 };

                    grid[6] = new int[] { 0, 8, 6,   0, 1, 0,   0, 0, 0 };
                    grid[7] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 8 };
                    grid[8] = new int[] { 0, 9, 0,   0, 0, 0,   2, 0, 0 };
                    break;

                case 4:
                    grid[0] = new int[] { 0, 0, 0,   5, 0, 9,   6, 0, 0 };
                    grid[1] = new int[] { 0, 5, 4,   0, 0, 0,   8, 0, 0 };
                    grid[2] = new int[] { 0, 6, 0,   3, 0, 0,   0, 9, 0 };

                    grid[3] = new int[] { 3, 0, 5,   0, 0, 2,   0, 1, 9 };
                    grid[4] = new int[] { 0, 4, 0,   0, 3, 0,   0, 0, 0 };
                    grid[5] = new int[] { 0, 0, 8,   0, 0, 1,   2, 0, 0 };

                    grid[6] = new int[] { 0, 0, 0,   7, 0, 0,   1, 0, 0 };
                    grid[7] = new int[] { 0, 0, 0,   0, 0, 0,   0, 2, 8 };
                    grid[8] = new int[] { 1, 0, 0,   0, 0, 0,   0, 0, 0 };
                    break;

                default:
                    grid[0] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[1] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[2] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };

                    grid[3] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[4] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[5] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };

                    grid[6] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[7] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    grid[8] = new int[] { 0, 0, 0,   0, 0, 0,   0, 0, 0 };
                    break;
            }
            return grid;
        }
    }

    public enum SudokuDifficulty
    {
        Easy,
        Medium,
        Hard
    }
}
