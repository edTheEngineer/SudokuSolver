using System;
using System.Collections.Generic;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {
        public void HiddenSingles() //Applies the Hidden Singles Technique
        {
             Grid.RemovePossibilitiesFromIntersectingCells();
             SetNumberIfOnePossibilityInGroup();
        }
        public bool IsHiddenSingleInGroup(Group g, int num)
        {
            List<int> allPossibilitiesInGroup = FindAllPossibilitiesInAGroup(g);
            var poss = allPossibilitiesInGroup.FindAll((x => x == num));
            return poss.Count == 1;
        } //Checks if there is a Hidden Single in the Group
        public int FindIndexOfPossibilityInGroup(Group g, int num)
        {
            for(int i =0; i<g.Cells.Length; i++)
            {
                var possibilities = g.Cells[i].Possibilities;
                foreach (var possibility in possibilities)
                {
                    if(possibility==num)
                    {
                        return i;
                    }
                }
            }

            return -1;
        } //Find the First Index of a Possibility in a Group. Called when only 1 instance
        public List<int> FindAllPossibilitiesInAGroup(Group g)
        {
            List<int> possibilityInAGroup = new List<int>();
            for(int i = 0; i<9; i++)
            {
                var possibilities = g.Cells[i].Possibilities;

                foreach (var possibility in possibilities)
                {
                    possibilityInAGroup.Add(possibility);
                }
            }

            return possibilityInAGroup;
        } //Lists all the possibilities in a group. Ignores duplicates
        public void SetHiddenSinglesRow(int i) //Sets Any Hidden Singles, in a Row at Position I.
        {
            var row = Grid.Rows[i];
                
                for (int numberValue = 1; numberValue < 10; numberValue++)
                {
                    bool isRow = IsHiddenSingleInGroup(row, numberValue);
                   
                    if (isRow)
                    {
                        var j = FindIndexOfPossibilityInGroup(row, numberValue);
                        Grid.SetNumberRemovePossibilities(i, j, numberValue, "Hidden Singles");
                    }
                }
        }
        public void SetHiddenSinglesColumn(int i)
        {
            
                var col = Grid.Columns[i];

                for (int numberValue = 1; numberValue < 10; numberValue++)
                {
                    bool isCol = IsHiddenSingleInGroup(col, numberValue);
                    if (isCol)
                    {
                        var j = FindIndexOfPossibilityInGroup(col, numberValue);
                        Grid.SetNumberRemovePossibilities(j, i, numberValue, "Hidden Singles");

                    }

                }

        } //Sets Any Hidden Singles, in a Column at Position I.
        public void SetHiddenSinglesBlock(int i)
        {
                var block = Grid.Blocks[i];

                for (int numberValue = 1; numberValue < 10; numberValue++)
                {
                    bool isBlock = IsHiddenSingleInGroup(block, numberValue);
                    
                    if (isBlock)
                    {
                        var j = FindIndexOfPossibilityInGroup(block, numberValue);
                        if (j != -1)
                        {
                            FindIndexForBlock(i, j, out int xCoordinate, out  int yCoordinate);
                            Grid.SetNumberRemovePossibilities(xCoordinate, yCoordinate, numberValue, "Hidden Singles");
                        }
                    }


                }

        } //Sets Any Hidden Singles, in a Block at Position I.
        public void SetNumberIfOnePossibilityInGroup()
        {
            for(int i = 0; i<9; i++)
            {
                SetHiddenSinglesRow(i);
                SetHiddenSinglesColumn(i);
                SetHiddenSinglesBlock(i);
            }
            
        } //Sets Hidden Singles in all positions for each Row, Group and Block if any are found
    }

}