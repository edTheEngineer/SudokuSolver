using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique

    {
        public int[,] SudokuGrid { get; set; } //Stores array of Numbers
        public AdvancedGrid Grid { get; set; } //Property of the Grid
        public int GroupSize { get; set; } = 9;
        public Technique() //Blank Constructor
        {
            SudokuGrid = new int[GroupSize, GroupSize];
            Grid = new AdvancedGrid(SudokuGrid);
        }
        public Technique(int[,] numbersIn) //Constructor that takes an array of Numbers
        {
            SudokuGrid = numbersIn;
            Grid = new AdvancedGrid(SudokuGrid);
            Grid.RemovePossibilitiesFromIntersectingCells();
        }
        public Technique(AdvancedGrid gridIn) //Blank Constructor
        {
            SudokuGrid = gridIn.SudokuGrid;
            Grid = gridIn;
        }

        public enum GroupName
            {
             Rows,
             Columns,
             Blocks
            
            }

    }
}
