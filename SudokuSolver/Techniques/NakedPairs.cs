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
            NakedPairSolve(true);
        }

        public void XToMain(string name, int i, int pairY1, int pairY2, out int x1, out int y1, out int x2, out int y2)
        {
            x1 = 0; x2 = 0; y1 = 0; y2 = 0;
            if(name ==Grid.ROW)
            {
                Grid.RowToMain(i, pairY1, out  x1, out  y1);
                Grid.RowToMain(i, pairY2, out  x2, out  y2);
            }

            if (name == Grid.COLUMNS)
            {
                Grid.ColumnToMain(i, pairY1, out x1, out y1);
                Grid.ColumnToMain(i, pairY2, out x2, out y2);
            }

            if (name == Grid.BLOCKS)
            {
                Grid.BlockToMain(i, pairY1, out x1, out y1);
                Grid.BlockToMain(i, pairY2, out x2, out y2);
            }
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


        
        private void GetIntersectingCellLists(int x1, int y1,  bool isExclude, out List<string> intersectBlocks, out List<string> intersectColumns, out List<string> intersectRows)
        {
            intersectBlocks = Grid.GetIntersectingCellsInGroup(x1, y1, Grid.BLOCKS, isExclude);
            intersectColumns = Grid.GetIntersectingCellsInGroup(x1, y1, Grid.COLUMNS, isExclude);
            intersectRows = Grid.GetIntersectingCellsInGroup(x1, y1,Grid.ROW, isExclude);
           
        }// Creates a list of the cells that intersect with a particular coordinate

        private void SplitPairIntoNumbers(string pairB,  out int num1, out int num2)
        {
            num1 = Convert.ToInt32(pairB.Substring(0, 1));
            num2 = Convert.ToInt32(pairB.Substring(1, 1));
            
        } //Splits a string pair into the 2 number coordinates

        
        public void NakedPairSolve(bool isSolve) // Examines the Naked Pairs in Blocks, Rows, and Columns
        {
            NakedPairCommon(Grid.Blocks, isSolve, Grid.BLOCKS);
            NakedPairCommon(Grid.Rows, isSolve, Grid.ROW);
           NakedPairCommon(Grid.Columns, isSolve, Grid.COLUMNS);

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
                    else
                    {
                        Console.WriteLine(possibilities[0] + " " + num1 + " " + possibilities[1] + " " +num2);
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

        public void addIntersectLists( int y1, int y2, ref List<string>intersectRows, ref List<string> intersectColumns, ref List<string> intersectBlocks,string name)
        {
            if(name==Grid.ROW)
            {
                intersectRows.AddRange(intersectBlocks);
            }

            if (name == Grid.COLUMNS)
            {
                intersectColumns.AddRange(intersectBlocks);
            }
            if (name == Grid.BLOCKS)
            {
                if (y1 == y2)
                {
                    intersectBlocks.AddRange(intersectColumns);
                }

                else
                {
                    intersectBlocks.AddRange(intersectRows);
                }
            }
        }

        public void printPairs(int y1, int y2, ref List<string> intersectRows, ref List<string> intersectColumns, ref List<string> intersectBlocks, string name)
        {
            if (name == Grid.ROW)
            {
                foreach(var x in intersectRows)
                {
                    Console.WriteLine(x);
                }
            }

            if (name == Grid.COLUMNS)
            {
                foreach (var x in intersectColumns)
                {
                    Console.WriteLine(x);
                }
            }
            if (name == Grid.BLOCKS)
            {
                foreach (var x in intersectBlocks)
                {
                    Console.WriteLine(x);
                }

                
            }
        }
        public void removex(int num1, int num2, ref List<string> intersectRows, ref List<string> intersectColumns, ref List<string> intersectBlocks, string name)
        {
            if (name == Grid.ROW)
            {
                removePoss(intersectRows, num1, num2);
            }

            if (name == Grid.COLUMNS)
            {
                removePoss(intersectColumns, num1, num2);
            }
            if (name == Grid.BLOCKS)
            {
                removePoss(intersectBlocks, num1, num2);
            }
        }

        public void removePoss(List<string> intersect, int num1, int num2)
        {
            
                Grid.RemovePossibilities(intersect, num1, "Naked Pairs");
                Grid.RemovePossibilities(intersect, num2, "Naked Pairs");
            
        }
        public List<PairC> pairListC = new List<PairC>();
        public struct PairC
        {
            public int x1 { get; set; }
            public int x2 { get; set; }
            public int y1 { get; set; }
            public int y2 { get; set; }

            public int num1 { get; set; }

            public int num2 { get; set; }

            public string name { get; set; }
        }

        public void setPairs(int x1, int y1, int x2, int y2, string name, int num1, int num2)
        {
            PairC p = new PairC();
            p.x1 = x1;
            p.x2 = x2;
            p.y1 = y1;
            p.y2 = y2;
            p.name = name;
            p.num1 = num1;
            p.num2 = num2;
            pairListC.Add(p);
        }
        public void NakedPairCommon(Group [] g, bool remove, string name)
        {
            for (int i = 0; i < AdvancedGrid.GroupSize; i++)
            {
                string pairName = FindNakedPair(g[i]);
                if (pairName != "")
                {
                    SplitPairIntoNumbers(pairName, out var num1, out var num2);
                    FindLocationNakedPair(g[i], pairName, out var pairY1, out var pairY2);
                    XToMain(name, i, pairY1, pairY2, out int x1, out int y1, out int x2, out int y2);
                    GetIntersectingCellLists(x1, y1, false, out var intersectBlocks, out var intersectColumns, out var intersectRows);
                    bool isCommonCoordinatesV = IsCommonCoordinates(x1, y1, x2, y2);
                    //MAKE COMMON
                    if (isCommonCoordinatesV)
                    {
                        addIntersectLists(y1, y2, ref intersectRows, ref intersectColumns, ref intersectBlocks, name);
                        
                    }
                    else
                    {
                        setPairs(x1, y1, x2, y2, name, num1, num2);
                    }
                    
                    if (remove)
                    {
                        removex(num1, num2, ref intersectRows, ref intersectColumns, ref intersectBlocks, name);
                    }
                    

                }
            }
        }
    }
}
