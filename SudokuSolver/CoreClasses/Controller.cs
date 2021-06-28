namespace RazorPagesSudoku.SudokuSolver.CoreClasses
{
    public class Controller
    {
        public int GroupSize { get; set; } = 9;
        public SimpleGrid CreateGrid(AdvancedGrid grid)
        {
            
        SimpleGrid  s= new SimpleGrid();

            for(int i = 0; i<GroupSize; i++)
            {
                for(int j = 0; j<GroupSize; j++)
                {
                    var x = grid.Rows[i].Cells[j].Number;
                    s.SudokuGrid[i, j] = x;
                }
            }
            return s;
        } //Converts Advanced Grid to Simple Grid

        public AdvancedGrid CreateGrid(SimpleGrid grid)
        {
            return new AdvancedGrid(grid.SudokuGrid);
        } //Converts Simple Grid to Advanced Grid
    }
}
