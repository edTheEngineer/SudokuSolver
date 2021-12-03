using System;
using System.Collections.Generic;
using System.Linq;
using RazorPagesSudoku.SudokuSolver.Techniques;

namespace RazorPagesSudoku.SudokuSolver.CoreClasses
{
    public class Solver //Context
    {
        public int NumberOfSteps { get; set; } // Property to hold number of steps
        
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

        public Solver(AdvancedGrid g, int noAttempts)
        {
            Grid = g;
            Numbers = Grid.SudokuGrid;
            g.UserAttempts = noAttempts;
                
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

        public void Technique(Technique ns, string technique)
        {
            for (int i = 0; i < 81; i++)
            {

                if (!Grid.continueWithTechniques())
                {
                    break;
                }


                if (Grid.IsValidAndIsCompleteSudoku())
                {
                    IsSolved = true;
                    IsValid = true;
                    break;
                }
                performSudokuMethod(technique, ns);
                Grid = ns.Grid;
            }
        }
        public void performSudokuMethod(string name, Technique ns)
        {
            //takes string and performs relevant Method
            switch (name)
            {
                case "NakedSingles":
                ns.NakedSingleTechnique();
                    break;

                case "Claiming":
                    ns.Claiming();
                    break;

                case "DoublePair":
                    ns.DoublePair();
                    break;

                case "NakedTriple":
                    ns.NakedTriple();
                    break;

                case "NakedQuad":
                    ns.NakedQuad();
                    break;

                case "HiddenTriples":
                    ns.HiddenTriples();
                    break;

                case "XWing":
                    ns.XWing();
                    break;
                case "XYWing":
                    ns.XYWing();
                    break;
                case "XYZWing":
                    ns.XYZWing();
                    break;
                case "HiddenQuads":
                    ns.HiddenQuads();
                    break;
                case "HiddenSingles":
                    ns.HiddenSingles();
                    break;
                case "NakedPair":
                    ns.NakedPair();
                    break;
                case "MultiLine":
                    ns.MultiLine();
                    break;
                case "Colouring":
                    ns.Colouring();
                    break;
                case "RemotePair":
                    ns.RemotePairTechnique();
                    break;

                default:
                    ns.SolveBruteForce();
                    break;
            }
            
        }
        public void SolveSudoku(int noAttempts =0)
        {
            SaveGrid();
            CountCells();
            IsMinimum = CellsFilled >= 17;
            Technique ns = new Technique(Numbers, noAttempts);
            if (IsMinimum)
            {
                Technique(ns, "NakedSingles");
                Technique(ns, "Claiming");
                Technique(ns, "DoublePair");
                Technique(ns, "NakedTriple");
                Technique(ns, "NakedQuad");
                Technique(ns, "HiddenTriples");
                Technique(ns, "XWing");
                Technique(ns, "XYWing");
                Technique(ns, "XYZWing");
                Technique(ns, "HiddenQuads");
                Technique(ns, "HiddenSingles");
                Technique(ns, "NakedPair");
                Technique(ns, "MultiLine");
                Technique(ns, "Colouring");
                Technique(ns, "RemotePair");
                if (Grid.IsValidAndIsCompleteSudoku())
                {
                    if (!Grid.continueWithTechniques())
                    {
                        return;
                    }

                    IsSolved = true;
                    IsValid = true;
                    Grid.Techniques.Add("No Brute Force needed");
                }

                else
                {
                    ns.SolveBruteForce();
                    Grid = ns.Grid;

                }


            }

            SetIsValidIsComplete();
        } //Method that Solves the Sudoku using available Techniques

        public void SetIsValidIsComplete()
        {
            IsValid = Grid.IsValidOrIsCompleteSudoku(true);
            IsSolved = Grid.IsValidOrIsCompleteSudoku(false);
        }
       
        public void SolveAndUndo() //Method that Solves the Sudoku and undoes Project, to check it will cause a valid solution
        {

        }

    }
}
