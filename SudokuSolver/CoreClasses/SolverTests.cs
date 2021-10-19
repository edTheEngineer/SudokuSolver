using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudokuTests.SudokuSolver.CoreClasses
{
    [TestClass()]
    public class SolverTests
    {
        public int[,] ValidIncompletePuzzle { get; set; }
        public int[,] InvalidIncomplete { get; set; }

        public int[,] ValidCompletePuzzle { get; set; }

        public int[,] InvalidCompletePuzzle { get; set; }

        public int[,] ValidOneMissing { get; set; }

        public int[,] Easy1Question { get; set; }

        public int[,] Easy1Answer { get; set; }

        public int[,] Easy50Question { get; set; }

        public int[,] Easy50Answer { get; set; }

        public int[,] Easy2Question { get; set; }

        public int[,] Easy2Answer { get; set; }

        public int[,] Easy10Question { get; set; }

        public int[,] Easy10Answer { get; set; }

        public int[,] SuperDifficult165Question { get; set; }

        public int[,] SuperDifficult165Answer { get; set; }

        public int[,] SuperDifficult200Question { get; set; }

        public int[,] SuperDifficult200Answer { get; set; }

        public int[,] Medium51Question { get; set; }

        public int[,] Medium51Answer { get; set; }

        public int[,] Medium110Question { get; set; }

        public int[,] Medium110Answer { get; set; }

        public int[,] Difficult111Question { get; set; }

        public int[,] Difficult111Answer { get; set; }

        public int[,] Difficult160Question { get; set; }

        public int[,] Difficult160Answer { get; set; }

        //Hidden Singles Test
        public int[,] HiddenSinglesSite { get; set; }

        public int[,] HiddenSinglesLiveBefore { get; set; }

        public int[,] HiddenSinglesLiveBefore2 { get; set; }

        public int[,] HiddenSinglesBlock { get; set; }

        public int[,] HiddenSinglesSiteAfter { get; set; }

        public int[,] HiddenSinglesLiveBeforeAfter { get; set; }

        public int[,] HiddenSinglesLiveBefore2After { get; set; }

        public int[,] HiddenSinglesBlockAfter { get; set; }

        public int[,] ZeroCellSudoku { get; set; }
        public int[,] SixteenCellSudoku { get; set; }

        public int[,] SeventeenCellSudoku { get; set; }

        public int[,] InvalidComplete { get; set; }


        public int[,] ExpertQuestion { get; set; }

        public int[,] ExpertAnswer { get; set; }

        public int[,] FiendishQuestion1 { get; set; }

        public int[,] FiendishAnswer1 { get; set; }

        public int[,] FiendishQuestion175 { get; set; }

        public int[,] FiendishAnswer175{ get; set; }

        public int[,] SuperFiendishQuestion176 { get; set; }

        public int[,] SuperFiendishAnswer176 { get; set; }

        public int[,] SuperFiendishQuestion200 { get; set; }

        public int[,] SuperFiendishAnswer200{ get; set; }

        public int[,] SudokuBacktrackingCounterQuestion { get; set; }

        public int[,] SudokuBackTrackingCounterAnswer { get; set; }

        public int[,] LittleBook200Q { get; set; }

        public int[,] LittleBook200Answer{ get; set; }
        public SolverTests()
    {
            ValidIncompletePuzzle = new[,]
                {
                 { 0,8,3,0,0, 9,0,0,1},
                 { 6,0,0,0,4,0,0,0,9},
                 { 4,0,1,3,0,7,6,8, 2},
                 { 1,0,0,0,8,3,0,9,0},
                 { 0,2,8,7,0,4,1,5,0 },
                 { 0,4,0,5,2,0,0,0,3 },
                 { 2,3,9,0,0,6,4,0,5 },
                 {8,0,0,0,1,0,3,0,7},
                 { 5,0,0,4,0,2,0,0,0}
                };

            ValidCompletePuzzle = new[,]
                {
                 {7,8,3,2,6, 9,5,4,1},
                 { 6,5,2,1,4,8,7,3,9},
                 { 4,9,1,3,5,7,6,8, 2},
                 { 1,7,5,6,8,3,2,9,4},
                 { 3,2,8,7,9,4,1,5,6 },
                 { 9,4,6,5,2,1,8,7,3 },
                 { 2,3,9,8,7,6,4,1,5 },
                 {8,6,4,9,1,5,3,2,7},
                 { 5,1,7,4,3,2,9,6,8}
                };

            InvalidCompletePuzzle = new[,]
                {
                 { 7,8,3,2,6,9,5,4,1},
                 { 6,5,2,1,4,8,7,3,9},
                 { 4,9,5,3,5,7,6,8,2},
                 { 1,7,5,6,8,3,2,9,4},
                 { 3,2,8,7,9,4,1,5,6},
                 { 9,4,6,5,2,1,8,7,3},
                 { 2,3,9,8,7,6,4,1,5},
                 { 8,6,4,9,1,5,3,2,7},
                 { 5,1,7,4,3,2,9,6,8}
                };

            InvalidIncomplete = new[,]
    {
                 { 7,8,0,0,6,9,5,4,1},
                 { 6,5,2,1,4,8,7,3,9},
                 { 4,9,5,3,5,7,6,8,2},
                 { 1,7,5,6,8,3,2,9,4},
                 { 3,2,8,7,9,4,1,5,6},
                 { 9,4,6,5,2,1,8,7,3},
                 { 2,3,9,8,7,6,4,1,5},
                 { 8,6,4,9,1,5,3,2,7},
                 { 5,1,7,4,3,2,9,6,8}
    };

            ValidOneMissing = new[,]
    {
                 {7,8,3,2,6, 9,5,4,1},
                 { 6,5,2,1,4,8,7,3,9},
                 { 4,9,1,3,5,7,6,8,2},
                 { 1,7,5,6,8,3,2,9,4},
                 { 3,2,8,7,9,4,1,5,6 },
                 { 9,4,6,5,2,1,8,7,3 },
                 { 2,3,9,8,7,6,4,1,5 },
                 { 8,6,4,9,1,5,3,2,7},
                 { 5,1,7,4,3,2,9,0,8}
    };

            ValidOneMissing = new[,]
{
                 {7,8,3,2,6, 9,5,4,1},
                 { 6,5,2,1,4,8,7,3,9},
                 { 4,9,1,3,5,7,6,8,2},
                 { 1,7,5,6,8,3,2,9,4},
                 { 3,2,8,7,9,4,1,5,6 },
                 { 9,4,6,5,2,1,8,7,3 },
                 { 2,3,9,8,7,6,4,1,5 },
                 { 8,6,4,9,1,5,3,2,7},
                 { 5,1,7,4,3,2,9,0,8}
};

            Easy1Question = new[,]
{
                 {0,5,0,3,0,6,0,0,7},
                 { 0,0,0,0,8,5,0,2,4},
                 { 0,9,8,4,2,0,6,0,3},
                 { 9,0,1,0,0,3,2,0,6},
                 { 0,3,0,0,0,0,0,1,0 },
                 { 5,0,7,2,6,0,9,0,8 },
                 { 4,0,5,0,9,0,3,8,0 },
                 { 0,1,0,5,7,0,0,0,2 },
                 {  8,0,0,1,0,4,0,7,9}
};


            Easy1Answer = new[,]
                {
                 {2,5,4,3,1,6,8,9,7},
                 {7,6,3,9,8,5,1,2,4},
                 { 1,9,8,4,2,7,6,5,3},
                 { 9,8,1,7,5,3,2,4,6},
                 { 6,3,2,8,4,9,7,1,5 },
                 { 5,4,7,2,6,1,9,3,8},
                 { 4,7,5,6,9,2,3,8,1 },
                 { 3,1,9,5,7,8,4,6,2 },
                 {  8,2,6,1,3,4,5,7,9}
                };

            Easy50Question = new[,]
{
                 {0,0,1,0,0,0,0,9,3},
                 { 2,5,0,0,0,8,1,6,4},
                 { 3,0,9,0,1,7,0,0,5},
                 { 7,3,8,0,2,0,5,4,6},
                 { 0,1,5,0,0,0,9,3,0 },
                 { 9,2,6,0,5,0,8,7,1 },
                 { 5,0,0,3,7,0,6,0,8 },
                 { 1,7,4,8,0,0,0,5,9},
                 { 6,8,0,0,0,0,4,0,0}
};

            Easy50Answer = new[,]
{
                 {8,6,1,2,4,5,7,9,3},
                 { 2,5,7,9,3,8,1,6,4},
                 { 3,4,9,6,1,7,2,8,5},
                 { 7,3,8,1,2,9,5,4,6},
                 { 4,1,5,7,8,6,9,3,2 },
                 { 9,2,6,4,5,3,8,7,1 },
                 { 5,9,2,3,7,4,6,1,8 },
                 { 1,7,4,8,6,2,3,5,9},
                 { 6,8,3,5,9,1,4,2,7}
};

            SuperDifficult200Question = new[,]
{
                 {0,0,0,0,0,0,0,0,0},
                 { 0,0,0,3,9,0,2,8,0},
                 { 0,4,0,0,2,1,0,9,3},
                 { 6,0,0,0,7,0,9,0,0},
                 { 9,0,0,5,0,2,0,0,6 },
                 { 0,0,5,0,6,0,0,0,1 },
                 { 1,8,0,2,5,0,0,3,0},
                 { 0,6,4,0,1,8,0,0,0},
                 { 0,0,0,0,0,0,0,0,0}
};

            SuperDifficult200Answer = new [,]
{
                  {2,3,9,4,8,5,1,6,7},
                 { 7,5,1,3,9,6,2,8,4},
                 {8,4,6,7,2,1,5,9,3},
                 {6,2,8,1,7,3,9,4,5},
                 { 9,1,3,5,4,2,8,7,6},
                 { 4,7,5,8,6,9,3,2,1} ,
                 { 1,8,7,2,5,4,6,3,9},
                 { 3,6,4,9,1,8,7,5,2},
                 { 5,9,2,6,3,7,4,1,8}
};

            Easy2Question = new[,]
{
{7,0,6,0,0,1,0,8,0},
{8,0,0,7,0,0,0,4,9},
{0,1,3,0,5,4,2,0,0},
{0,0,4,3,0,7,0,5,0},
{6,2,0,9,0,5,0,0,1},
{0,3,0,6,0,2,8,0,0},
{2,0,5,4,3,0,9,1,0},
{3,0,0,0,0,9,0,0,8},
{4,8,0,1,2,0,7,0,0}
};

            Easy2Answer = new[,]
{
{7,4,6,2,9,1,5,8,3},
{8,5,2,7,6,3,1,4,9},
{9,1,3,8,5,4,2,6,7},
{1,9,4,3,8,7,6,5,2},
{6,2,8,9,4,5,3,7,1},
{5,3,7,6,1,2,8,9,4},
{2,7,5,4,3,8,9,1,6},
{3,6,1,5,7,9,4,2,8},
{4,8,9,1,2,6,7,3,5}
};

            Easy10Question = new[,]
{
{5,0,9,6,0,0,0,0,1},
{7,0,0,0,0,4,3,0,2},
{0,0,4,1,2,0,9,7,0},
{9,0,8,0,5,0,1,0,7},
{0,1,0,2,7,3,0,8,0},
{6,0,2,0,1,0,4,0,5},
{0,5,7,0,8,9,2,0,0},
{0,0,6,7,0,0,0,0,3},
{2,4,0,0,6,0,0,9,0}
};

            Easy10Answer = new[,]
{
{5,2,9,6,3,7,8,4,1},
{7,6,1,8,9,4,3,5,2},
{3,8,4,1,2,5,9,7,6},
{9,3,8,4,5,6,1,2,7},
{4,1,5,2,7,3,6,8,9},
{6,7,2,9,1,8,4,3,5},
{1,5,7,3,8,9,2,6,4},
{8,9,6,7,4,2,5,1,3},
{2,4,3,5,6,1,7,9,8}
};

            Medium51Question = new[,]
{
{4,5,0,3,0,9,0,0,0},
{0,7,2,0,1,8,0,5,0},
{0,0,0,0,4,0,0,6,0},
{0,6,4,0,0,7,3,8,1},
{3,8,0,4,0,1,0,9,6},
{5,9,1,8,0,0,2,7,0},
{0,4,0,0,5,0,0,0,0},
{0,3,0,9,6,0,1,2,0},
{0,0,0,1,0,3,0,4,5}
};

            Medium51Answer = new[,]
{
{4,5,6,3,7,9,8,1,2},
{9,7,2,6,1,8,4,5,3},
{8,1,3,2,4,5,9,6,7},
{2,6,4,5,9,7,3,8,1},
{3,8,7,4,2,1,5,9,6},
{5,9,1,8,3,6,2,7,4},
{1,4,8,7,5,2,6,3,9},
{7,3,5,9,6,4,1,2,8},
{6,2,9,1,8,3,7,4,5}
};

            Medium110Question = new[,]
{
{0,3,5,0,0,8,0,6,0},
{8,0,0,0,3,0,7,0,0},
{0,0,0,6,0,4,3,0,0},
{1,4,0,8,9,0,0,7,0},
{2,0,0,5,0,0,6,0,8},
{0,8,0,0,7,6,0,9,2},
{0,0,7,9,0,1,0,0,0},
{0,0,4,0,8,0,0,0,5},
{0,2,0,0,0,0,1,0,0}
};

            Medium110Answer = new[,]
{
{4,3,5,7,1,8,2,6,9},
{8,6,1,2,3,9,7,5,4},
{7,9,2,6,5,4,3,8,1},
{1,4,6,8,9,2,5,7,3},
{2,7,9,5,4,3,6,1,8},
{5,8,3,1,7,6,4,9,2},
{3,5,7,9,2,1,8,4,6},
{6,1,4,3,8,7,9,2,5},
{9,2,8,4,6,5,1,3,7}
};

            Difficult111Question = new[,]
{
{0,0,0,6,0,0,0,5,0},
{0,0,0,0,0,8,9,4,0},
{0,0,0,0,2,0,7,6,0},
{3,0,0,7,4,0,0,0,6},
{0,9,7,0,0,0,1,8,0},
{6,0,0,0,9,5,0,0,2},
{0,2,6,0,5,0,0,0,0},
{0,7,4,2,0,0,0,0,0},
{0,5,0,0,0,6,0,0,0}
};

            Difficult111Answer = new[,]
{
{7,1,9,6,3,4,2,5,8},
{2,6,5,1,7,8,9,4,3},
{4,3,8,5,2,9,7,6,1},
{3,8,2,7,4,1,5,9,6},
{5,9,7,3,6,2,1,8,4},
{6,4,1,8,9,5,3,7,2},
{1,2,6,4,5,7,8,3,9},
{9,7,4,2,8,3,6,1,5},
{8,5,3,9,1,6,4,2,7}
};

            Difficult160Question = new[,]
{
{0,0,0,0,0,0,0,0,0},
{0,0,0,0,4,0,0,3,8},
{0,7,0,9,3,0,4,6,1},
{6,0,0,0,8,3,1,0,0},
{8,0,0,0,0,0,0,0,6},
{0,0,1,6,9,0,0,0,2},
{3,9,4,0,1,6,0,5,0},
{2,1,0,0,5,0,0,0,0},
{0,0,0,0,0,0,0,0,0}
};

            Difficult160Answer = new[,]
{
{1,4,3,5,6,8,7,2,9},
{9,6,2,1,4,7,5,3,8},
{5,7,8,9,3,2,4,6,1},
{6,2,7,4,8,3,1,9,5},
{8,5,9,2,7,1,3,4,6},
{4,3,1,6,9,5,8,7,2},
{3,9,4,8,1,6,2,5,7},
{2,1,6,7,5,4,9,8,3},
{7,8,5,3,2,9,6,1,4}
};

            HiddenSinglesSite = new[,]
{
                 {  0,0,0,0,0,0,0,0,2},
                 {  0,0,0,0,9,5,4,0,0},
                 {  0,0,6,8,0,0,0,0,0},
                 {  0,8,5,0,2,0,9,4,1},
                 {  0,0,0,1,0,9,7,3,8},
                 {  1,0,0,0,0,0,2,5,6},
                 {  8,9,3,0,1,0,0,0,0},
                 {  0,0,0,9,0,0,0,0,4},
                 {  0,0,7,6,0,0,3,0,0}
};

            HiddenSinglesLiveBefore = new[,]
{
                 {  9,6,0,0,0,0,7,0,8},
                 {  8,0,0,0,0,4,3,0,0},
                 {  1,0,0,5,0,0,0,0,0},
                 {  0,0,0,0,0,0,1,7,6},
                 {  2,0,0,0,9,3,0,0,5},
                 {  7,0,8,0,0,0,0,0,0},
                 {  0,0,7,0,3,2,0,4,0 },
                 {  3,8,2,1,0,5,6,0,0 },
                 {  0,4,1,0,0,9,5,2,0}
};

            HiddenSinglesLiveBefore2 = new[,]
{
                 {  0,0,0,0,2,0,0,7,4},
                 {  0,0,8,3,9,0,0,0,2},
                 {  0,0,0,0,0,0,0,0,0},
                 {  3,7,4,6,1,0,0,9,0 },
                 {  0,1,9,0,0,7,0,0,0},
                 {  0,6,0,0,0,0,0,5,0 },
                 {  0,0,0,0,0,0,0,1,0 },
                 { 0,0,0,5,0,0,3,0,0},
                 {  0,0,3,0,6,0,4,0,0}
};
            HiddenSinglesBlock = new[,]
{
                 {  0,2,8,0,0,7,0,0,0},
                 {  0,1,6,0,8,3,0,7,0},
                 {  0,0,0,0,2,0,8,5,1},
                 {  1,3,7,2,9,0,0,0,0},
                 {  0,0,0,7,3,0,0,0,0},
                 {  0,0,0,0,4,6,3,0,7},
                 {  2,9,0,0,7,0,0,0,0 },
                 {  0,0,0,8,6,0,1,4,0},
                 {  0,0,0,3,0,0,7,0,0}
};

            HiddenSinglesSiteAfter = new[,]
{
                 {  9,5,4,3,6,1,8,7,2},
                 {  7,1,8,2,9,5,4,6,3},
                 {  2,3,6,8,4,7,1,9,5},
                 {  3,8,5,7,2,6,9,4,1},
                 {  4,6,2,1,5,9,7,3,8},
                 {  1,7,9,4,3,8,2,5,6},
                 {  8,9,3,5,1,4,6,2,7},
                 {  6,2,1,9,7,3,5,8,4},
                 {  5,4,7,6,8,2,3,1,9}
};

            HiddenSinglesLiveBeforeAfter = new[,]
{
                 {  9,6,4,3,2,1,7,5,8},
                 {  8,7,5,9,6,4,3,1,2},
                 {  1,2,3,5,8,7,9,6,4},
                 {  4,3,9,2,5,8,1,7,6},
                 {  2,1,6,7,9,3,4,8,5},
                 {  7,5,8,4,1,6,2,3,9},
                 {  5,9,7,6,3,2,8,4,1 },
                 {  3,8,2,1,4,5,6,9,7 },
                 {  6,4,1,8,7,9,5,2,3}
};

            HiddenSinglesLiveBefore2After = new[,]
{
                 {  9,3,5,8,2,6,1,7,4},
                 {  7,4,8,3,9,1,5,6,2},
                 {  1,2,6,7,5,4,8,3,9},
                 {  3,7,4,6,1,5,2,9,8 },
                 {  5,1,9,2,8,7,6,4,3},
                 { 8,6,2,9,4,3,7,5,1},
                 {  6,8,7,4,3,2,9,1,5 },
                 { 4,9,1,5,7,8,3,2,6},
                 { 2,5,3,1,6,9,4,8,7}
};
           

            HiddenSinglesBlockAfter = new[,]
            {
                {  4,2,8,1,5,7,9,3,6},
                {  5,1,6,9,8,3,4,7,2},
                {  3,7,9,6,2,4,8,5,1},
                {  1,3,7,2,9,8,5,6,4},
                {  6,4,5,7,3,1,2,9,8},
                {  9,8,2,5,4,6,3,1,7},
                {  2,9,1,4,7,5,6,8,3 },
                {  7,5,3,8,6,2,1,4,9},
                {  8,6,4,3,1,9,7,2,5}
            };

            ZeroCellSudoku = new[,]
            {
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0 },
                {  0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0}
            };

            SixteenCellSudoku = new[,]
            {
                {  1,2,3,4,5,6,7,8,9},
                {  9,8,7,6,5,4,3,0,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0 },
                {  0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0}
            };

            SeventeenCellSudoku = new[,]
            {
                {  2,3,9,4,8,5,1,6,7},
                {  7,5,1,3,9,6,2,8,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0 },
                {  0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0}
            };

            ZeroCellSudoku = new[,]
            {
                {  1,2,3,4,5,6,7,8,9},
                {  9,8,7,6,5,4,3,2,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0},
                {  0,0,0,0,0,0,0,0,0 },
                {  0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0}
            };

            InvalidComplete = new[,]
            {
                { 2,5,4,3,1,6,8,9,9},
                { 7,6,3,9,8,5,1,2,4},
                { 1,9,8,4,2,7,6,5,3},
                { 9,8,1,7,5,3,2,4,6},
                { 6,3,2,8,4,9,7,1,5 },
                { 5,4,7,2,6,1,9,3,8},
                { 4,7,5,6,9,2,3,8,1 },
                { 3,1,9,5,7,8,4,6,2 },
                { 8,2,6,1,3,4,5,7,9}
            };

            SuperDifficult165Question = new[,]
{
                { 7,0,0,0,0,6,0,0,0},
                { 0,0,1,0,4,0,0,0,0},
                { 2,5,8,0,1,0,6,0,0},
                { 5,0,0,0,0,1,0,9,0},
                { 3,0,0,0,7,0,0,0,1},
                { 0,6,0,9,0,0,0,0,8},
                { 0,0,5,0,2,0,9,3,7},
                { 0,0,0,0,9,0,2,0,0},
                { 0,0,0,3,0,0,0,0,5}
            };

            SuperDifficult165Answer = new[,]
{
                { 7,4,9,8,3,6,1,5,2},
                { 6,3,1,5,4,2,8,7,9},
                { 2,5,8,7,1,9,6,4,3},
                { 5,8,7,2,6,1,3,9,4},
                { 3,9,2,4,7,8,5,6,1},
                { 1,6,4,9,5,3,7,2,8},
                { 8,1,5,6,2,4,9,3,7},
                { 4,7,3,1,9,5,2,8,6},
                { 9,2,6,3,8,7,4,1,5}
            };


            ExpertQuestion = new[,]
{
                { 9,7,0,6,0,0,0,0,0,},
                { 0,0,0,0,0,3,0,7,0},
                { 0,0,0,5,0,0,2,0,0},
                { 0,3,0,0,1,4,0,0,0},
                { 0,0,1,0,2,0,0,5,0},
                { 0,0,4,0,0,0,0,0,0},
                { 0,0,0,0,0,0,4,2,1},
                { 3,0,6,0,0,0,0,0,5},
                { 8,0,0,0,0,0,0,0,3}
            };


            ExpertAnswer = new[,]
{
                { 9,7,5,6,4,2,1,3,8},
                { 4,2,8,1,9,3,5,7,6},
                { 1,6,3,5,8,7,2,4,9},
                { 5,3,7,9,1,4,6,8,2},
                { 6,9,1,7,2,8,3,5,4},
                { 2,8,4,3,6,5,9,1,7},
                { 7,5,9,8,3,6,4,2,1},
                { 3,4,6,2,7,1,8,9,5},
                { 8,1,2,4,5,9,7,6,3}
            };

            FiendishQuestion1 = new[,]
{
                { 0,1,0,6,0,0,0,3,4,},
                { 3,0,0,8,0,0,6,0,0},
                { 0,0,4,0,7,0,0,0,0},
                { 0,0,1,0,0,0,0,2,8},
                { 0,0,0,9,0,5,0,0,0},
                { 7,3,0,0,0,8,5,0,0},
                { 0,0,3,0,8,0,9,0,0},
                { 0,0,9,0,0,4,0,0,7},
                { 2,7,0,0,0,6,0,5,0}
            };


            FiendishQuestion175 = new[,]
{
                { 1,0,4,0,8,0,0,0,6},
                { 0,0,0,0,0,6,0,0,0},
                { 0,0,0,5,4,9,0,0,7},
                { 0,8,1,0,0,0,9,0,0},
                { 5,0,6,0,1,0,4,0,8},
                { 0,0,9,0,0,0,2,1,0},
                { 8,0,0,2,9,7,0,0,0},
                { 0,0,0,4,0,0,0,0,0},
                { 9,0,0,0,5,0,3,0,4}
            };

            FiendishAnswer1 = new[,]
{
                { 8,1,5,6,2,9,7,3,4},
                { 3,2,7,8,4,1,6,9,5},
                { 6,9,4,5,7,3,8,1,2},
                { 9,5,1,4,6,7,3,2,8},
                { 4,8,2,9,3,5,1,7,6},
                { 7,3,6,2,1,8,5,4,9},
                { 5,4,3,7,8,2,9,6,1},
                { 1,6,9,3,5,4,2,8,7},
                { 2,7,8,1,9,6,4,5,3}
            };


            FiendishAnswer175 = new[,]
{
                { 1,7,4,3,8,2,5,9,6},
                { 3,9,5,1,7,6,8,4,2},
                { 2,6,8,5,4,9,1,3,7,},
                { 4,8,1,7,2,5,9,6,3},
                { 5,2,6,9,1,3,4,7,8},
                { 7,3,9,8,6,4,2,1,5},
                { 8,4,3,2,9,7,6,5,1},
                { 6,5,2,4,3,1,7,8,9},
                { 9,1,7,6,5,8,3,2,4}
            };

            SuperFiendishQuestion176 = new[,]
{
                { 0,0,0,8,0,0,4,0,7},
                { 0,7,0,0,0,0,0,0,2},
                { 0,0,8,0,0,0,0,3,1},
                { 4,2,0,6,3,0,0,0,0},
                { 8,0,0,0,4,0,0,0,3},
                { 0,0,0,0,5,7,0,2,4},
                { 6,5,0,0,0,0,9,0,0},
                { 7,0,0,0,0,0,0,4,0},
                { 1,0,3,0,0,5,0,0,0}
            };


            SuperFiendishAnswer176 = new[,]
{
                { 5,6,1,8,2,3,4,9,7},
                { 3,7,9,5,1,4,6,8,2},
                { 2,4,8,7,9,6,5,3,1},
                { 4,2,7,6,3,8,1,5,9},
                { 8,1,5,2,4,9,7,6,3},
                { 9,3,6,1,5,7,8,2,4},
                { 6,5,4,3,7,2,9,1,8},
                { 7,8,2,9,6,1,3,4,5},
                {1,9,3,4,8,5,2,7,6}
            };

           SuperFiendishQuestion200 = new[,]
{
                { 0,3,8,0,0,0,7,9,0},
                { 0,0,5,3,0,9,8,0,0},
                { 9,0,0,0,0,0,0,0,6},
                { 0,0,0,8,2,5,0,0,9},
                {0,0,9,1,3,4,5,0,0},
                { 0,0,0,6,9,7,0,0,0},
                { 7,9,0,0,0,0,0,0,3},
                { 0,0,3,9,0,1,4,0,0},
                { 0,1,4,0,0,3,9,8,0}
            };


            SuperFiendishAnswer200 = new[,]
{
                { 1,3,8,2,4,6,7,9,5},
                { 4,6,5,3,7,9,8,2,1},
                { 9,7,2,5,1,8,3,4,6},
                { 3,4,7,8,2,5,6,1,9},
                { 6,2,9,1,3,4,5,7,8},
                { 8,5,1,6,9,7,2,3,4},
                { 7,9,6,4,8,2,1,5,3},
                { 2,8,3,9,5,1,4,6,7},
                { 5,1,4,7,6,3,9,8,2}
            };

            SudokuBacktrackingCounterQuestion = new[,]
{
                { 0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,3,0,8,5},
                { 0,0,1,0,2,0,0,0,0},
                { 0,0,0,5,0,7,0,0,0},
                { 0,0,4,0,0,0,1,0,0},
                { 0,9,0,0,0,0,0,0,0},
                { 5,0,0,0,0,0,0,7,3},
                { 0,0,2,0,1,0,0,0,0},
                { 0,0,0,0,4,0,0,0,9}
            };


            LittleBook200Q = new[,]
{
                { 0,0,1,9,5,7,3,0,0},
                { 0,3,0,0,0,0,0,1,0},
                { 2,0,0,0,0,0,0,0,8},
                { 9,0,0,7,0,4,0,0,5},
                { 1,0,0,0,0,0,0,0,6},
                { 3,0,8,0,0,0,1,0,2},
                { 4,0,0,2,6,5,0,0,3},
                { 0,9,0,0,0,0,0,5,0},
                { 0,0,3,1,8,9,2,0,0}
            };

            LittleBook200Answer = new[,]
{
                { 6,8,1,9,5,7,3,2,4},
                { 7,3,4,6,2,8,5,1,9},
                { 2,5,9,3,4,1,7,6,8},
                { 9,2,6,7,1,4,8,3,5},
                { 1,7,5,8,3,2,4,9,6},
                { 3,4,8,5,9,6,1,7,2},
                { 4,1,7,2,6,5,9,8,3},
                { 8,9,2,4,7,3,6,5,1},
                { 5,6,3,1,8,9,2,4,7}
            };

            SudokuBackTrackingCounterAnswer = new[,]
{
                { 9,8,7,6,5,4,3,2,1},
                { 2,4,6,1,7,3,9,8,5},
                { 3,5,1,9,2,8,7,4,6},
                { 1,2,8,5,3,7,6,9,4},
                { 6,3,4,8,9,2,1,5,7},
                { 7,9,5,4,6,1,8,3,2},
                { 5,1,9,2,8,6,4,7,3},
                { 4,7,2,3,1,9,5,6,8},
                { 8,6,3,7,4,5,2,1,9}
            };


        }
        [TestMethod()]

        public void ValidAndComplete ()
        {
            Solver s = new Solver(ValidCompletePuzzle);
            var actual = s.Grid.IsValidOrIsCompleteSudoku(true);
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]

        public void ValidAndInComplete()
        {
            Solver s = new Solver(ValidIncompletePuzzle);
            var actual = s.Grid.IsValidOrIsCompleteSudoku(true);
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]

        public void ValidAndOneMissing()
        {
            Solver s = new Solver(ValidOneMissing);
            var actual = s.Grid.IsValidOrIsCompleteSudoku(true);
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]

        public void InValidAndComplete()
        {
            Solver s = new Solver(InvalidCompletePuzzle);
            var actual = s.Grid.IsValidOrIsCompleteSudoku(true);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]

        public void InvalidInComplete()
        {
            Solver s = new Solver(InvalidIncomplete);
            var actual = s.Grid.IsValidOrIsCompleteSudoku(true);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]

        public void CompleteAndValid()
        {
            Solver s = new Solver(ValidCompletePuzzle);
            var actual = s.Grid.IsValidOrIsCompleteSudoku( false);
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]

        public void IncompleteValid()
        {
            Solver s = new Solver(ValidIncompletePuzzle);
            var actual = s.Grid.IsValidOrIsCompleteSudoku( false);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]

        public void OneMissing()
        {
            Solver s = new Solver(ValidOneMissing);
            var actual = s.Grid.IsValidOrIsCompleteSudoku(false);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]

        public void CompleteInvalid()
        {
            Solver s = new Solver(InvalidCompletePuzzle);
            var actual = s.Grid.IsValidOrIsCompleteSudoku( false);
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]

        public void IncompleteInvalid()
        {
            Solver s = new Solver(InvalidIncomplete);
            var actual = s.Grid.IsValidOrIsCompleteSudoku(false);
            Assert.AreEqual(false, actual);
        }

        //--
        [TestMethod()]

        public void ValidAndCompleteAll()
        {
            Solver s = new Solver(ValidCompletePuzzle);
            var actual = s.Grid.IsValidAndIsCompleteSudoku();
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]

        public void ValidAndInCompleteAll()
        {
            Solver s = new Solver(ValidIncompletePuzzle);
            var actual = s.Grid.IsValidAndIsCompleteSudoku();
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]

        public void ValidAndOneMissingAll()
        {
            Solver s = new Solver(ValidOneMissing);
            var actual = s.Grid.IsValidAndIsCompleteSudoku();
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]

        public void InValidAndCompleteAll()
        {
            Solver s = new Solver(InvalidCompletePuzzle);
            var actual = s.Grid.IsValidAndIsCompleteSudoku();
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]

        public void InvalidInCompleteAll()
        {
            Solver s = new Solver(InvalidIncomplete);
            var actual = s.Grid.IsValidAndIsCompleteSudoku();
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]

        public void SolveSolvedSudoku()
        {
            Solver s = new Solver(ValidCompletePuzzle);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = ValidCompletePuzzle;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveEasySudoku()
        {
            Solver s = new Solver(ValidIncompletePuzzle);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = ValidCompletePuzzle;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveOneMissingSudoku()
        {
            Solver s = new Solver(ValidOneMissing);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = ValidCompletePuzzle;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveEasySudokuOne()
        {
            Solver s = new Solver(Easy1Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = Easy1Answer;
            for(int i = 0; i< 9; i++)
            {
                for(int j = 0; j<9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveEasySudoku50()
        {
            Solver s = new Solver(Easy50Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = Easy50Answer;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveEasySudoku2()
        {
            Solver s = new Solver(Easy2Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = Easy2Answer;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveEasySudoku10()
        {
            Solver s = new Solver(Easy10Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = Easy10Answer;
            CollectionAssert.AreEqual(expected, actual);
        }

       [TestMethod()]

        public void SolveSuperDifficult200()
        {
            Solver s = new Solver(SuperDifficult200Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = SuperDifficult200Answer;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("----------");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(expected[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveMedium51()
        {
            Solver s = new Solver(Medium51Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = Medium51Answer;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveMedium110()
        {
            Solver s = new Solver(Medium110Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = Medium110Answer;
            CollectionAssert.AreEqual(expected, actual);
        }

       [TestMethod()]

        public void SolveDifficult111()
        {
            Solver s = new Solver(Difficult111Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = Difficult111Answer;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

         [TestMethod()]

        public void SolveHiddenSingles1()
        {
            Solver s = new Solver(HiddenSinglesSite);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = HiddenSinglesSiteAfter;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveHiddenSingles2()
        {
            Solver s = new Solver(HiddenSinglesLiveBefore);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = HiddenSinglesLiveBeforeAfter;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]

        public void SolveHiddenSinglesLive2()
        {
            Solver s = new Solver(HiddenSinglesLiveBefore2);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = HiddenSinglesLiveBefore2After;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


       [TestMethod()]

        public void SolveHiddenSinglesBlock()
        {
            Solver s = new Solver(HiddenSinglesBlock);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = HiddenSinglesBlockAfter;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        public void SolveOneMissingSudoku_2()
        {
            Solver s = new Solver(ValidOneMissing);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = ValidCompletePuzzle;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveEasySudokuOne_2()
        {
            Solver s = new Solver(Easy1Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = Easy1Answer;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveEasySudoku50_2()
        {
            Solver s = new Solver(Easy50Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = Easy50Answer;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveEasySudoku2_2()
        {
            Solver s = new Solver(Easy2Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = Easy2Answer;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveEasySudoku10_2()
        {
            Solver s = new Solver(Easy10Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = Easy10Answer;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveSuperDifficult165()
        {
            Solver s = new Solver(SuperDifficult165Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = SuperDifficult165Answer;

           
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveMedium51_2()
        {
            Solver s = new Solver(Medium51Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = Medium51Answer;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveMedium110_2()
        {
            Solver s = new Solver(Medium110Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = Medium110Answer;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

       [TestMethod()]

        public void SolveDifficult111_1()
        {
            Solver s = new Solver(Difficult111Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = Difficult111Answer;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SolveDifficult111_2()
        {
            Solver s = new Solver(Difficult111Question);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = Difficult111Answer;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BlankSolve()
        {
            Solver s = new Solver();
            s.SolveSudoku();
            var actual = s.IsMinimum;
            Assert.AreEqual(false, actual);
        }
        [TestMethod()]
        public void SixteenCellsCannotSolve()
        {
            Solver s = new Solver(SixteenCellSudoku);
            s.SolveSudoku();
            var actual = s.IsMinimum;
            Assert.AreEqual(false, actual);
        }
        [TestMethod()]
        public void SeventeenIsMinimum() 
        {
            Solver s = new Solver(SeventeenCellSudoku);
            s.SolveSudoku();
            var actual = s.IsMinimum;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(s.Grid.SudokuGrid[i,j]);
                }

                Console.WriteLine("");
            }
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void ValidComplete()
        {
            Solver s = new Solver(Easy10Question);
            s.SolveSudoku();
            var actual = s.IsValid;
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void ValidIncomplete()
        {
            Solver s = new Solver(SeventeenCellSudoku);
            s.SolveSudoku();
            var actual = s.IsValid;
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void InValidComplete_Solved()
        {
            Solver s = new Solver(InvalidComplete);
            s.SolveSudoku();
            var actual = s.IsSolved;
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void InValidComplete_Valid()
        {
            Solver s = new Solver(InvalidComplete);
            s.SolveSudoku();
            var actual = s.IsValid;
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void CanSolve()
        {
            Solver s = new Solver(Easy10Question);
            s.SolveSudoku();
            var actual = s.IsSolved;
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void SixteenCellsCannotSolve_Solve()
        {
            Solver s = new Solver(SixteenCellSudoku);
            s.SolveSudoku();
            var actual = s.IsSolved;
            Assert.AreEqual(expected: false, actual);
        }
        [TestMethod()]
        public void SeventeenIsMinimum_Solved() //Change once can solve
        {
            Solver s = new Solver(SeventeenCellSudoku);
            s.SolveSudoku();
            var actual = s.IsSolved;
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void IsNewFalse() 
        {
            Solver s = new Solver(Easy1Question);
            s.SolveSudoku();
            var actual = s.Grid.Rows[0].Cells[0].IsOriginalValue;
            Console.WriteLine(s.Grid.Rows[0].Cells[0].Number);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void IsNewTrue() 
        {
            Solver s = new Solver(Easy1Question);
            Console.WriteLine(s.Grid.Rows[0].Cells[1].Number);
            s.SolveSudoku();
            var actual = s.Grid.Rows[0].Cells[1].IsOriginalValue;
            Console.WriteLine(s.Grid.Rows[0].Cells[1].Number);
            Assert.AreEqual(true, actual);
        }
        [TestMethod()]
        public void IsNewFalse2() 
        {
            Solver s = new Solver(Easy1Question);
            s.SolveSudoku();
            AdvancedGrid Grid = new AdvancedGrid(Easy1Question);
            Console.WriteLine(Grid.Rows[0].Cells[0].IsOriginalValue);//true
            Console.WriteLine(s.Grid.Rows[0].Cells[0].IsOriginalValue); //false
            Grid.SudokuGrid = s.Grid.SudokuGrid;
            Grid = s.Grid;
            var actual = Grid.Rows[0].Cells[0].IsOriginalValue;
            Console.WriteLine(Grid.Rows[0].Cells[0].Number);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void IsNewTrueTwo() 
        {
            Solver s = new Solver(Easy1Question);
            s.SolveSudoku();
            AdvancedGrid Grid = new AdvancedGrid(Easy1Question);
            Grid.SudokuGrid = s.Grid.SudokuGrid;
            Grid = s.Grid;
            var actual = Grid.Rows[0].Cells[1].IsOriginalValue;
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void ExpertOne()
        {
            Solver s = new Solver(ExpertQuestion);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = ExpertAnswer;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Fiendish1()
        {
            Solver s = new Solver(FiendishQuestion1);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = FiendishAnswer1;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Fiendish175()
        {
            Solver s = new Solver(FiendishQuestion175);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = FiendishAnswer175;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SuperFiendish176()
        {
            Solver s = new Solver(SuperFiendishQuestion176);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = SuperFiendishAnswer176;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SuperFiendish200()
        {
            Solver s = new Solver(SuperFiendishQuestion200);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = SuperFiendishAnswer200;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BacktrackingWorkagainst()
        {
            Solver s = new Solver(SudokuBacktrackingCounterQuestion);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = SudokuBackTrackingCounterAnswer;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LittleBook200Test()
        {
            Solver s = new Solver(LittleBook200Q);
            s.SolveSudoku();
            var actual = s.Grid.SudokuGrid;
            var expected = LittleBook200Answer;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}