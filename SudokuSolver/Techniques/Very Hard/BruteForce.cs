using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {

        //My Solution

        private List<int> CreateCellsToAdd()
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
        public bool IsIndexInList(int index, List<int> filledInCells)
        {
            var i = filledInCells.FindIndex(x => x == index);

            return i >= 0;
        }

        public void IncrementAfterPlacingNumber(int index, out int start, out bool isBackTrack, out int indexOut)
        {
            index += 1;
            start = 1;
            isBackTrack = false;
            indexOut = index;
        }

        public void BackTrack(List<int> cells, int index, out bool isBackTrack, out int start, out int indexOut)
        {
            start = 1;
            isBackTrack = true;
            index -= 1;
            for (; index >= 1; index -= 1)
            {
                if (IsIndexInList(index, cells))
                {
                    Grid.GetCoOrdinatesOfCell(index, out int a, out int b);
                    int currentCellVal = Grid.SudokuGrid[a, b];
                    int nextVal = currentCellVal + 1;
                    if (currentCellVal == 9)
                    {
                        UndoNumber(cells, index);
                    }

                    else if (CanPlaceNumberInCell(false, a, b, nextVal))
                    {
                        CanPlaceNumberInCell(true, a, b, nextVal);
                        isBackTrack = false;
                        break;
                    }

                    else
                    {
                        UndoNumber(cells, index);
                    }

                }


            }
            index += 1;
            indexOut = index;

        }

        private void UndoNumber(List<int> cells, int index)
        {
            Grid.GetCoOrdinatesOfCell(index, out int x, out int y);

            var isIndex = cells.FindIndex(x => x == index);
            if (isIndex >= 0)
            {
                Grid.SetNumberRemovePossibilities(x, y, 0, "");
            }

            else
            {
            }
        }
        public void SkipNumberAndProgress(int index, bool isBacktrack, out int indexOut, out bool isBack)
        {
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
        private void SolveAllSudoku(bool isBackTrack, List<int> cells, int index, int start, int currentIteration)
        {

            var maxIteration = 1000000;
            while (currentIteration < maxIteration)
            {
                Grid.GetCoOrdinatesOfCell(index, out int x, out int y);
                if (IsIndexInList(index, cells))
                {
                    bool success = CanPlaceNumberInCell(false, x, y, start);
                    if (success)
                    {
                        if (isBackTrack && Grid.SudokuGrid[x, y] == 9)
                        {
                            UndoNumber(cells, index);
                            index -= 1;
                        }
                        else
                        {
                            CanPlaceNumberInCell(true, x, y, start);
                            IncrementAfterPlacingNumber(index, out start, out isBackTrack, out index);
                        }

                    }

                    else
                    {
                        BackTrack(cells, index, out isBackTrack, out start, out index);
                    }

                }


                else
                {
                    SkipNumberAndProgress(index, isBackTrack, out index, out isBackTrack);
                }

                currentIteration += 1;
                if (Grid.IsValidAndIsCompleteSudoku())
                {
                    currentIteration = maxIteration + 1;
                }
            }

        }
        public void SolveBruteForce()

        {
            var filledInCells = CreateCellsToAdd();
            SolveAllSudoku(false, filledInCells, 1, 1, 0);

        }
        public bool CanPlaceNumberInCell(bool set, int x, int y, int start)
        {
            for (int i = start; i <= 9; i++)
            {
                Grid.SetNumber(x, y, i, "Brute Force");
                if (Grid.IsValidOrIsCompleteSudoku(true))
                {
                    if (!set)
                    {
                        Grid.SetNumber(x, y, 0, "Brute Force");
                    }
                    return true;
                }
                else
                {
                    Grid.SetNumber(x, y, 0, "Brute Force");
                }
            }

            return false;
        }

        //Example Solution

        public int N { get; set; }
        private bool SolveExampleSolution(int[,] board, int iterations)
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
                            if (IsValid(board, row, column) && SolveExampleSolution(board, iterations))
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
        private bool CheckConstraint( int[,] board,int row, bool[] constraint, int column)
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
        private bool SubsectionConstraint(int[,] board, int row, int column)
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
                    if (!CheckConstraint(board, r, constraint, c)) return false;
                }
            }
            return true;
        }
        private bool ColumnConstraint(int[,] board, int column)
        {
            bool[] constraint = new bool[9];
            return Enumerable.Range(0, 9)
           .All(row => CheckConstraint(board, row, constraint, column));

        }
        private bool RowConstraint(int[,] board, int row)
        {
            bool[] constraint = new bool[9];
            return Enumerable.Range(0, 9)
             .All(column => CheckConstraint(board, row, constraint, column));
        }
        private bool IsValid(int[,] board, int row, int column)
        {
            return (RowConstraint(board, row) && ColumnConstraint(board, column) && SubsectionConstraint(board, row, column));
        }
        public void SolveBruteForceExample()
        {
            SolveExampleSolution(Grid.SudokuGrid, 1);
        }
       
    }
}
