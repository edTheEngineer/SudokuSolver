namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public  partial class Technique
    {
        public void SetInitialPossibilities() //Sets Initial Possibilities
        {
            for (int i = 0; i < GroupSize; i++)
            {
                for (int j = 0; j < GroupSize; j++)
                {
                    var cells = Grid.GetIntersectingCells(i, j);

                    foreach (var cell in cells)
                    {
                        var number = Grid.Rows[i].Cells[j].Number;
                        Grid.SplitTextCoordinate(cell, out var a, out var b);
                        Grid.RemovePossibility(a, b, number);
                    }
                }
            }
        }

    }
}
