using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PuzzleSolver.Models;

namespace PuzzleSolver.Data
{
    public class PuzzleSolverContext : DbContext
    {
        public PuzzleSolverContext (DbContextOptions<PuzzleSolverContext> options)
            : base(options)
        {
        }

        public DbSet<PuzzleSolver.Models.Square> Square { get; set; } = default!;

        public DbSet<PuzzleSolver.Models.PossibleValue> PossibleValue { get; set; } = default!;
    }
}
