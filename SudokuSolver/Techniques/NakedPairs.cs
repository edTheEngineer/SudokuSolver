using System;
using System.Collections.Generic;
using RazorPagesSudoku.SudokuSolver.CoreClasses;
using System.Linq;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {

        public void NakedPair() //Applies the Naked Pair Technique
        {
            NakedPairSolve();
        }

        public void NakedPairTechnique() //Find the Naked Pair and place numbers in cell that have one possibility
        {
            NakedPair();
            SetNumberIfCellHasOnePossibility();

        }

        public bool IsCommonCoordinates(int x1, int y1, int x2, int y2)

        {
            var isRow = y1 == y2;
            var isCol = x1 == x2;
            var block1 = Grid.GetBlockFromCoOrdinates(x1, y1);
            var block2 = Grid.GetBlockFromCoOrdinates(x2, y2);
            var isBlock = block1 == block2;

            return (isRow && isBlock ||isCol&&isBlock);
        } //Finds if 2 Coordinates exist on the same row or block, and same column & block

        public void NakedPairBlocks()
        {
            for (int i = 0; i < AdvancedGrid.GroupSize; i++)
            {
               
                string pairB = FindNakedPair(Grid.Blocks[i]);
                if (pairB != "")
                {
                    SplitPairIntoNumbers(pairB, out var num1, out var num2);
                    FindLocationNakedPair(Grid.Blocks[i], pairB, out var pairY1, out var pairY2);
                    Grid.BlockToMain(i,pairY1, out var x1, out var y1);
                    Grid.BlockToMain(i, pairY2, out var x2, out var y2);
                    GetIntersectingCellLists(x1, y1, out var intersectBlocks, out var intersectColumns, out var intersectRows);
                    if (IsCommonCoordinates( x1, y1, x2, y2))
                    {
                        if (y1==y2)
                        {
                            intersectBlocks.AddRange(intersectColumns);
                        }

                        else
                        {
                            intersectBlocks.AddRange(intersectRows);
                        }
                        
                    }

                    Grid.RemovePossibilities(intersectBlocks, num1);
                    Grid.RemovePossibilities(intersectBlocks, num2);

                }
            }
        } //Examines the Blocks and finds Naked Pairs within them

        private void GetIntersectingCellLists(int x1, int y1, out List<string> intersectBlocks, out List<string> intersectColumns, out List<string> intersectRows)
        {
            intersectBlocks = Grid.GetIntersectingCellsInGroup(x1, y1, "B");
            intersectColumns = Grid.GetIntersectingCellsInGroup(x1, y1, "C");
            intersectRows = Grid.GetIntersectingCellsInGroup(x1, y1, "R");
           
        }// Creates a list of the cells that intersect with a particular coordinate

        private void SplitPairIntoNumbers(string pairB,  out int num1, out int num2)
        {
            num1 = Convert.ToInt32(pairB.Substring(0, 1));
            num2 = Convert.ToInt32(pairB.Substring(1, 1));
            
        } //Splits a string pair into the 2 number coordinates

        public void NakedPairColumns() //Examines the Columns and finds Naked Pairs within them
        {
            for (int i = 0; i < AdvancedGrid.GroupSize; i++)
            {
                string pairC = FindNakedPair(Grid.Columns[i]);
                if (pairC != "")
                {
                    SplitPairIntoNumbers(pairC, out var num1, out var num2);
                    FindLocationNakedPair(Grid.Columns[i], pairC, out var pairY1,  out var pairY2);
                    Grid.ColumnToMain(i, pairY1, out var x1, out var y1);
                    Grid.ColumnToMain(i, pairY2, out var b3, out var b4);
                    GetIntersectingCellLists(x1, y1, out var intersectBlocks, out var intersectColumns, out _);

                    if (IsCommonCoordinates(x1,y1,b3,b4))
                    {
                        intersectColumns.AddRange(intersectBlocks);
                    }

                    Grid.RemovePossibilities(intersectColumns, num1);
                    Grid.RemovePossibilities(intersectColumns, num2);

                }
            }
        }

        public void NakedPairRows() //Examines the Rows and finds Naked Pairs within them
        {
            for (int i = 0; i < AdvancedGrid.GroupSize; i++)
            {
                string pairR = FindNakedPair(Grid.Rows[i]);
                if (pairR != "")
                {
                    SplitPairIntoNumbers(pairR, out var num1, out var num2);
                    
                    FindLocationNakedPair(Grid.Rows[i], pairR, out var pairY1, out  var pairY2);
                    int x =i;
                    int y =pairY1;
                    GetIntersectingCellLists(x, y, out var intersectBlocks, out _, out var intersectRows);
                    if (IsCommonCoordinates(x, pairY1, i, pairY2))
                    {
                        intersectRows.AddRange(intersectBlocks);
                    }
                    Grid.RemovePossibilities(intersectRows, num1);
                    Grid.RemovePossibilities(intersectRows, num2);

                }
            }
        }

        public void NakedPairSolve() // Examines the Naked Pairs in Blocks, Rows, and Columns
        {
            NakedPairBlocks();
            NakedPairRows();
            NakedPairColumns();
            
        }

        public string FindNakedPair(Group g)
        {
            var pairs = CreateListOfPairs(g);
            foreach (var pair in pairs)
            {
                var pairCount = CountInList(pairs, pair);

                if (pairCount == 2)
                {
                    return pair;
                }
            }
            return "";
        } //Finds a Naked Pairs within a Group of cells

        public int FindLocationNakedPair(Group g, string pair)
        {
            SplitPairIntoNumbers(pair, out var num1, out var num2);
            for (int i = 0; i < g.Cells.Length; i++)
            {
                var possibilities = g.Cells[i].Possibilities;
                if (possibilities.Count == 2)
                {
                    if (possibilities[0] == num1 && possibilities[1] == num2)
                    {
                        return i;
                    }
                }
            }

            return -1;
        } //Find the Location in a Group of a Naked Pair


        public void FindLocationNakedPair(Group g, string pair, out int x1, out int y1) //Finds Both Locations of a Naked Pair within a Group

        {
            x1 = -1;
            y1 = -1;
            SplitPairIntoNumbers(pair, out var num1, out var num2);
            int numbersFound = 0;
            for (int i = 0; i < g.Cells.Length; i++)
            {
                var possibilitiesList = g.Cells[i].Possibilities;
                if (possibilitiesList.Count == 2)
                {
                    if (numbersFound == 0)
                    {
                        if (possibilitiesList[0] == num1 && possibilitiesList[1] == num2)
                        {
                            x1 = i;
                            numbersFound += 1;
                            continue;
                        }
                    }

                    if (numbersFound == 1)
                    {
                        if (possibilitiesList[0] == num1 && possibilitiesList[1] == num2)
                        {
                           y1 = i;
                           return;
                        }
                        
                    }
                    
                }
            }
        }
        public bool IsNakedPair(Group g) //Checks if there is a Naked Pair within a Group
        {
            var pairs = CreateListOfPairs(g);

            var isNakedPairs = pairs.GroupBy(n => n).Any(c => c.Count() > 1); //Looks for duplicate Entries

            return isNakedPairs;
        }

        public int CountInList(List<string> myList, string val)
        {
            var count = 0;
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i] == val)
                {
                    count += 1;
                }
            }

            return count;
        } // Counts instances of a number in a list

        private static List<string> CreateListOfPairs(Group g)
        {
            List<string> pairs = new List<string>();

            for (int i = 0; i < AdvancedGrid.GroupSize; i++)
            {
                if (g.Cells[i].Possibilities.Count == 2)
                {
                    var possibilityList = "";
                    for (int j = 0; j < g.Cells[i].Possibilities.Count; j++)
                    {
                        possibilityList += g.Cells[i].Possibilities[j];
                    }

                    pairs.Add(possibilityList);
                }
            }

            return pairs;
        }

        public  bool GroupPair(Group g)
        {
            for (int i = 0; i < GroupSize; i++)
            {
                if (IsNakedPair(g))
                {
                    return true;
                }
            }
            return false;
        } //Checks if a Naked Pair within a Group
        
        public bool IsNakedPair()
        {
            for (int i = 0; i < AdvancedGrid.GroupSize; i++)
            {
                var row = Grid.Rows[i];
                var block = Grid.Blocks[i];
                var column = Grid.Columns[i];

                if (IsNakedPair(block) || IsNakedPair(row) || IsNakedPair(column))
                {
                    return true;
                }

            }

            return false;
        } //Checks if there is a Naked Pair
    }
}
