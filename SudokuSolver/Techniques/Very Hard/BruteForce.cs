using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {

        //My Solution

        private List<int> createCellsToAdd()
        {
            List<int> filledInCells = new List<int>();
            for (int i = 1; i <= 81; i++)
            {
                Grid.GetCoOrdinatesOfCell(i, out int x, out int y);
                if (SudokuGrid[x, y] == 0)
                {
                    filledInCells.Add(i);
                }
            }
            return filledInCells;
        }
        public bool isIndexInList(int index, List<int> filledInCells)
        {
            var i = filledInCells.FindIndex(x => x == index);

            return i >= 0;
        }

        public void incrementAfterPlacingNumber(int index, out int start, out bool isBackTrack, out int indexOut)
        {
            index += 1;
            start = 1;
            isBackTrack = false;
            indexOut = index;
        }

        public void backTrack(List<int> cells, int index, out bool isBackTrack, out int start, out int indexOut)
        {
            start = 1;
            isBackTrack = true;
            index -= 1;
            for (; index >= 1; index -= 1)
            {
                if (isIndexInList(index, cells))
                {
                    Grid.GetCoOrdinatesOfCell(index, out int a, out int b);
                    int currentCellVal = Grid.SudokuGrid[a, b];
                    int nextVal = currentCellVal + 1;
                    if (currentCellVal == 9)
                    {
                        undoNumber(cells, index);
                    }

                    else if (canPlaceNumberInCell(false, a, b, nextVal))
                    {
                        canPlaceNumberInCell(true, a, b, nextVal);
                        isBackTrack = false;
                        break;
                    }

                    else
                    {
                        undoNumber(cells, index);
                    }

                }


            }
            index += 1;
            indexOut = index;

        }

        private void undoNumber(List<int> cells, int index)
        {
            Grid.GetCoOrdinatesOfCell(index, out int x, out int y);

            var isIndex = cells.FindIndex(x => x == index);
            if (isIndex >= 0)
            {
                Grid.SetNumber(x, y, 0);
            }

            else
            {
            }
        }
        public void skipNumberAndProgress(int index, bool isBacktrack, out int indexOut, out bool isBack)
        {
            Grid.GetCoOrdinatesOfCell(index, out int x, out int y);
            isBack = isBacktrack;
            if (isBacktrack)
            {
                indexOut = index - 1;
            }

            else
            {
                indexOut = index + 1;
            }
        }
        private void solveAllSudoku(bool isBackTrack, List<int> cells, int index, int start, int currentIteration)
        {

            var maxIteration = 1000000;
            while (currentIteration < maxIteration)
            {
                Grid.GetCoOrdinatesOfCell(index, out int x, out int y);
                if (isIndexInList(index, cells))
                {
                    bool success = canPlaceNumberInCell(false, x, y, start);
                    if (success)
                    {
                        if (isBackTrack && Grid.SudokuGrid[x, y] == 9)
                        {
                            undoNumber(cells, index);
                            index -= 1;
                        }
                        else
                        {
                            canPlaceNumberInCell(true, x, y, start);
                            incrementAfterPlacingNumber(index, out start, out isBackTrack, out index);
                        }

                    }

                    else
                    {
                        backTrack(cells, index, out isBackTrack, out start, out index);
                    }

                }


                else
                {
                    skipNumberAndProgress(index, isBackTrack, out index, out isBackTrack);
                }

                currentIteration += 1;
                if (Grid.IsValidAndIsCompleteSudoku())
                {
                    Console.WriteLine(currentIteration + " Total");
                    currentIteration = maxIteration + 1;
                }
            }
            Console.WriteLine("FINAL INDEX " + index);

        }
        public void solveBruteForce()

        {
            var filledInCells = createCellsToAdd();
            solveAllSudoku(false, filledInCells, 1, 1, 0);

        }
        public bool canPlaceNumberInCell(bool set, int x, int y, int start)
        {
            for (int i = start; i <= 9; i++)
            {
                Grid.SetNumberOnGrid(x, y, i);
                if (Grid.IsValidOrIsCompleteSudoku(true))
                {
                    if (!set)
                    {
                        Grid.SetNumberOnGrid(x, y, 0);
                    }
                    return true;
                }
                else
                {
                    Grid.SetNumberOnGrid(x, y, 0);
                }
            }

            return false;
        }

        //Example Solution

        public int N { get; set; }
        private bool solveExampleSolution(int[,] board, int iterations)
        {
            for (int row = 0; row < GroupSize; row++)
            {
                for (int column = 0; column < GroupSize; column++)
                {
                    if (board[row, column] == 0)
                    {
                        for (int k = 1; k <= GroupSize; k++)
                        {
                            board[row, column] = k;
                            if (isValid(board, row, column) && solveExampleSolution(board, iterations))
                            {
                                return true;
                            }
                            iterations += 1;
                            board[row, column] = 0;
                        }
                        return false;
                    }
                }
            }
            return true;
        }
        private bool checkConstraint( int[,] board,int row, bool[] constraint, int column)
        {
            if (board[row,column] != 0)
            {
                if (!constraint[board[row,column] - 1])
                {
                    constraint[board[row,column] - 1] = true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        private bool subsectionConstraint(int[,] board, int row, int column)
        {
            int BOARD_SIZE =9;
            int SUBSECTION_SIZE = 3;
            bool[] constraint = new bool[BOARD_SIZE];
            int subsectionRowStart = (row / SUBSECTION_SIZE) * SUBSECTION_SIZE;
            int subsectionRowEnd = subsectionRowStart + SUBSECTION_SIZE;

            int subsectionColumnStart = (column / SUBSECTION_SIZE) * SUBSECTION_SIZE;
            int subsectionColumnEnd = subsectionColumnStart + SUBSECTION_SIZE;

            for (int r = subsectionRowStart; r < subsectionRowEnd; r++)
            {
                for (int c = subsectionColumnStart; c < subsectionColumnEnd; c++)
                {
                    if (!checkConstraint(board, r, constraint, c)) return false;
                }
            }
            return true;
        }
        private bool columnConstraint(int[,] board, int column)
        {
            bool[] constraint = new bool[9];
            return Enumerable.Range(0, 9)
           .All(row => checkConstraint(board, row, constraint, column));

        }
        private bool rowConstraint(int[,] board, int row)
        {
            bool[] constraint = new bool[9];
            return Enumerable.Range(0, 9)
             .All(column => checkConstraint(board, row, constraint, column));
        }
        private bool isValid(int[,] board, int row, int column)
        {
            return (rowConstraint(board, row) && columnConstraint(board, column) && subsectionConstraint(board, row, column));
        }
        public void solveBruteForceExample()
        {
            solveExampleSolution(Grid.SudokuGrid, 1);
        }
       
    }
}
