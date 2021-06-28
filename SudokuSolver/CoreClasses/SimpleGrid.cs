namespace RazorPagesSudoku.SudokuSolver.CoreClasses
{
    public class SimpleGrid
    {
        public int[,] SudokuGrid { get; set; }

        public int Rows { get; private set; }

        public int Columns { get;  private set; }

        public SimpleGrid()
        {
            Rows = 9;
            Columns = 9;
            SudokuGrid = new int[Rows, Columns];
            CreateGrid();

        }

        private void CreateGrid()
        {
            for(int i = 0; i<Rows; i++)
            {
                for(int j =0; j<Columns; j++)
                {
                    SudokuGrid[i, j] = 0;
                }
            }
        }

        public void SetGrid(int i, int j, int number)
        {
            SudokuGrid[i, j] = number;
        }

        public void ClearGrid()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    SudokuGrid[i, j] = 0;
                }
            }
        }
    }
}
