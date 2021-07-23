using System;
using System.Collections.Generic;
using System.Linq;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {
        public void PrintNumbers() //Prints Sudoku Grid. Used for Debugging
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(SudokuGrid[i, j]);
                }
            }
        }
        public void NakedSingleTechnique ()// Gives Naked Singles Technique
        {
            Grid.RemovePossibilitiesFromIntersectingCells();
            SetNumberIfCellHasOnePossibility();
        }
        private void SetNumberIfCellHasOnePossibility() //Sets Number in a cell if has 1 Possibility
        {
            for (int i = 0; i < GroupSize; i++)
            {
                for (int j = 0; j < GroupSize; j++)
                {
                    var possibilitiesPerCell = Grid.Rows[i].Cells[j].Possibilities;
                    var possibilityCount = possibilitiesPerCell.Count;
                    if (possibilityCount == 1)
                    {
                        var firstPossibility = Grid.Rows[i].Cells[j].Possibilities[0];
                        Grid.SetNumberRemovePossibilities(i, j, firstPossibility, "Naked Singles");
                    }
                }
            }
        } //Set Number if Cell has One Possibility
        public void FindIndexForBlock(int blockNumber, int numberInBlock, out int i, out int j) //Find X & y coordinate on the grid for the nth cell in the nth block
        {
            blockNumber += 1;
            AdvancedGrid g = new AdvancedGrid();
            var cells =  g.CellsInBlock(blockNumber);
            var cell = cells[numberInBlock];
            g.GetCoOrdinatesOfCell(cell, out i, out j);

        }
        public void GetNakedUnit(List<int> listOfNumbers, out int missingNumberIndex, out int missingNumberValue) //Get Missing Number from Group and Index where it should go.
        {
            var zeroes = listOfNumbers.Where(x => x == 0);
            missingNumberValue = -1;
            missingNumberIndex = -1;
            if(zeroes.Count() !=1)
            {   
            }

            else

            {
                missingNumberIndex = listOfNumbers.FindIndex(x => x == 0);
                for (int i = 1; i <= 9; i++)
                {
                    var isPresent = listOfNumbers.FindIndex(x => x == i);
                    if (isPresent >= 0)
                    {
                    }

                    else
                    {
                        missingNumberValue = i;
                        break;
                    }
                }

            }
        } 

    }
}
