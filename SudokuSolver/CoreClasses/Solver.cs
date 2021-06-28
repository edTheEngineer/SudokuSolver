using System;
using System.Collections.Generic;
using System.Linq;
using RazorPagesSudoku.SudokuSolver.Techniques;

namespace RazorPagesSudoku.SudokuSolver.CoreClasses
{
    public class Solver //Context
    {
        public int NumberOfSteps { get; set; } // Property to hold number of steps
        public List<string> Techniques { get; set; } // Property to hold Techniques used to solve a Sudoku
        public AdvancedGrid Grid { get; set; } //Property to Store a grid

        public bool IsSolved { get; set; }

        public bool IsValid { get; set; }

        public bool IsMinimum { get; set; }

        public int CellsFilled { get; set; }

        public Solver(int[,] numbersIn) //Solver  Constructor that accepts Numbers as an input
        {
            if (numbersIn == null) throw new ArgumentNullException(nameof(numbersIn));
            Grid = new AdvancedGrid(numbersIn);
            Numbers = numbersIn;
        }

       

        public Solver() //Solver constructor that takes a blank grid
        {
            Numbers = new int[9, 9];
            Grid = new AdvancedGrid(Numbers);
            CellsFilled = 0;
           
        }

        public void SaveGrid()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var numR = Grid.Rows[i].Cells[j].Number;
                    if (numR != 0)
                    {
                        Grid.Rows[i].Cells[j].SetOriginal(true);
                    }

                    var numB = Grid.Blocks[i].Cells[j].Number;
                    if (numB != 0)
                    {
                        Grid.Blocks[i].Cells[j].SetOriginal(true);
                    }

                    var numC = Grid.Columns[i].Cells[j].Number;
                    if (numC != 0)
                    {
                        Grid.Columns[i].Cells[j].SetOriginal(true);
                    }
                }

                
                
            }
        }

        public void CountCells()
        {
            int count = 0;
            for (int i = 0; i < AdvancedGrid.GroupSize; i++)
            {
                for (int j = 0; j< AdvancedGrid.GroupSize; j++)
                {
                    if (Grid.SudokuGrid[i, j] != 0)
                    {
                        count += 1;
                    }
                }
            }

            CellsFilled = count;
        }
        public int[,] Numbers { get; set; } //Property of thr Numbers
        public void SolveSudoku()
        {
            SaveGrid();
            CountCells();
            IsMinimum = CellsFilled >= 17;
            Technique ns = new Technique(Numbers);
            if (IsMinimum)
            {
                for (int i = 0; i < 81; i++)
                {
                    if (Grid.IsValidAndIsCompleteSudoku())
                    {
                        IsSolved = true;
                        IsValid = true;
                        Console.WriteLine("NAKED SINGLES SUDOKU TOOK " + i + " passes");
                        break;
                    }
                    ns.NakedSingleTechnique();
                    Grid = ns.Grid;
                }
                for (int i = 0; i < 81; i++)
                {
                    if (Grid.IsValidAndIsCompleteSudoku())
                    {
                        IsSolved = true;
                        IsValid = true;
                        Console.WriteLine("HIDDEN SINGLES SUDOKU TOOK " + i + " passes");
                        break;
                    }
                    ns.HiddenSingles();
                    Grid = ns.Grid;
                }

                for (int i = 0; i < 81; i++)
                {
                    if (Grid.IsValidAndIsCompleteSudoku())
                    {
                        IsSolved = true;
                        IsValid = true;
                        Console.WriteLine("NAKED PAIR SUDOKU TOOK " + i + " passes");
                        break;
                    }
                    ns.NakedPair();
                    Grid = ns.Grid;
                }

                if (Grid.IsValidAndIsCompleteSudoku())
                {
                    IsSolved = true;
                    IsValid = true;
                    Console.WriteLine("No Brute Force needed");
                }


                else
                {
                    ns.solveBruteForce();
                    Grid = ns.Grid;
                    Console.WriteLine("Brute Force Needed");
                }

              
            }
            
            SetIsValidIsComplete();
        } //Method that Solves the Sudoku using available Techniques

        public void SetIsValidIsComplete()
        {
            IsValid = Grid.IsValidOrIsCompleteSudoku(true);
            IsSolved = Grid.IsValidOrIsCompleteSudoku(false);
        }
        public void SolveSudoku(int x)
        {
            Console.WriteLine(x);
        } //Method that solves the next few cells of a Sudoku 
        public void SolveAndUndo() //Method that Solves the Sudoku and undoes Project, to check it will cause a valid solution
        {

        }

    }
}
