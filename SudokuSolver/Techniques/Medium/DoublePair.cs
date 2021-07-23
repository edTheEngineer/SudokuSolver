using System;
using System.Collections.Generic;
using RazorPagesSudoku.SudokuSolver.CoreClasses;
using System.Linq;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {
        public void DoublePair()
        {
            for(int i = 1; i<9; i++)
            {
                doublePairTechnique(i);
            }
        }

        public List<PairBlock> pairBlockList = new List<PairBlock>();
        public List<coordinatePair> coordinateList = new List<coordinatePair>();
        public struct PairBlock
        {

            public int x1;
            public int y1;
            public int Block;
            public int Number;
            public int rowMod;
            public int colMod;
            public int OneDRow;
            public int OneDCol;

        }

        public struct coordinatePair 
        {

            public string one;
            public string two;
            public string three;
            public string four;
        }

        public void setCoordinateList(int a, int b, int c, int d, int e, int f, int g, int h)
        {
            coordinatePair pair = new coordinatePair();
            pair.one = "["+a + ";" + b+"]" + "Block = "+Grid.GetBlockFromCoOrdinates(a,b);
            pair.two = "[" + c + ";" + d + "]" + "Block = " + Grid.GetBlockFromCoOrdinates(c,d);
            pair.three = "[" + e + ";" + f + "]" + "Block = " + Grid.GetBlockFromCoOrdinates(e,f);
            pair.four = "[" + g + ";" + h + "]" + "Block = " + Grid.GetBlockFromCoOrdinates(g,h);
            coordinateList.Add(pair);
        }
        public void setPairBlock(int x1, int y1, int Number)
        {
            PairBlock p = new PairBlock();
            var block = Grid.GetBlockFromCoOrdinates(x1, y1);
            p.x1 = x1;
            p.y1 = y1;
            p.Number = Number;
            p.Block = block;
            p.OneDRow = Grid.Get1DIndex(x1, y1);
            p.OneDCol = Grid.Get1DIndex(y1, x1);
            p.rowMod = p.OneDRow % 9;
            p.colMod = p.OneDCol % 9;
            pairBlockList.Add(p);
            
        }

        public bool showTwoUniqueValues(int one, int two, int three, int four)
        {
            
            List<int> numberList = new List<int>();
            numberList.Add(one);
            numberList.Add(two);
            numberList.Add(three);
            numberList.Add(four);


            numberList.Sort();

            if(numberList[0]==numberList[1] && numberList[1]==numberList[2] && numberList[2]==numberList[3])
            {
                return false;
            }


            if (numberList[0] == numberList[1] && numberList[2]==numberList[3])
            {
               
                return true;
            }

            return false;
        }
        public void include(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, out bool isRow, out bool isInclude)
        {
            var blockFirst = Grid.GetBlockFromCoOrdinates(x1, y1);
            var blockSecond = Grid.GetBlockFromCoOrdinates(x2, y2);
            var blockThird = Grid.GetBlockFromCoOrdinates(x3, y3);
            var blockFourth = Grid.GetBlockFromCoOrdinates(x4, y4);
            isRow = false;
            isInclude = false;
            if(blockFirst ==blockSecond &&blockSecond==blockThird &&blockThird==blockFourth)
            {
                return ;
            }

            if(blockFirst ==blockSecond & blockSecond==3)
            {
                return ;
            }

            if( blockSecond ==blockThird &blockThird==blockFourth)
            {
                return ;
            }

            if( blockFirst ==blockThird &&blockThird ==blockFourth)
            {
                return;
            }
            if (x1 ==x2 &&y1 ==y2)
            {
                return;
            }

            if (x2 == x3 && y2 == y3)
            {
                return;
            }

            if (x3 == x4 && y3 == y4)
            {
                return;
            }

            if (x2 == x3 && y2 == y3)
            {
                return;
            }

            if (x2 == x4 && y2 == y4)
            {
                return;
            }
            //1 3 1 4  3 8 4 8

            var one = showTwoUniqueValues(x1, x2, x3, x4);
                
              var two=  showTwoUniqueValues(y1, y2, y3, y4);


            List<int> check = new List<int>();
            check.Add(x1);
            check.Add(y1);
            check.Add(x2);
            check.Add(y2);
            check.Add(x3);
            check.Add(y3);
            check.Add(x4);
            check.Add(y4);

            check.Sort();

            if(check[0]!=check[1])
            {
                return;
            }


            if (check[2] != check[3])
            {
                return;
            }


            if (check[4] != check[5])
            {
                return;
            }


            if (check[6] != check[7])
            {
                return;
            }

            if (check[1] ==check[2])
            {
                return ;
            }

            if (check[3] == check[4])
            {
                return ;
            }

            if (check[5] == check[6])
            {
                return ;
            }

            if(one & two)
            {
                if(x4-x1>3)
                {
                    Console.WriteLine("COL");
                    
                }
                else
                {
                    Console.WriteLine("ROW");
                    isRow = false;
                }
                isInclude= true;
                return;
            }
            return ;
        }

        public List<string> getCoordinatesOfBlock(int block, int num)
        {
            List<string> coOrds = new List<string>();
            for (int j = 0; j < 9; j++)
            {
                var x = Grid.Blocks[block].Cells[j].Possibilities;
                if (x.Contains(num))
                {
                    Grid.BlockToMain(block, j, out int xx, out int yy);
                    coOrds.Add(xx + "," + yy);

                }
            }
           
            return coOrds;
        }
        public void doublePairTechnique(int num)
        {
            for (int i = 0; i < 9; i++)
            {
                List<string> coOrds = new List<string>();
                coOrds = getCoordinatesOfBlock(i, num);
                HowMany(coOrds, out int rowCount, out int columnCount);

                if( rowCount ==0 && columnCount==0)
                {

                }

                else if (rowCount>2 || columnCount>2)
                {

                }
                else
                {
                    
                    var joinBlocks = findAdjoiningBlocks(i);
                    foreach (var x in joinBlocks) 
                    {
                        
                         var joinedBlocks = getCoordinatesOfBlock(x, num);
                        compare(coOrds, joinedBlocks, out bool isV, out bool isRow);
                        if (isV)
                        {
                            getOthersToEliminate(coOrds, isRow, num) ;
                        }

                    }

                   
                }
               
            }
        }

        public void getOthersToEliminate(List<string> coordinates, bool isRow, int number)
        {
            var firstBlock = 0;
            var secondBlock = 0;
           foreach(var x in coordinates)
            {
                Grid.SplitTextCoordinate(x, out int i, out int j);
                var block = Grid.GetBlockFromCoOrdinates(i, j);
                if (firstBlock == 0)
                { 
                    firstBlock = block; 
                }

                else
                {
                    secondBlock = block;
                }

                var blockDifference = Math.Abs(secondBlock - firstBlock);
                var missingBlock = secondBlock + blockDifference;
                
                var cells = Grid.GetCellsInBlock(missingBlock);
                List<int> columnsToEliminate = new List<int>();
                List<int> rowsToEliminate = new List<int>();

                if(!isRow)
                {
                    foreach (var cell in cells)

                    {
                        if (Math.Abs(blockDifference) == 3)
                        {

                            Grid.SplitTextCoordinate(x, out int ii, out int jj);
                            columnsToEliminate.Add(jj);


                        }

                    }

                    List<string> coordinatesToEliminate = new List<string>();
                    var count = 0;
                    if (columnsToEliminate.Count > 0)
                    {
                        foreach (var d in columnsToEliminate)
                        {
                            coordinatesToEliminate.Add(count + ";" + d);
                            count += 1;
                        }

                    }

                    Grid.RemovePossibilities(coordinatesToEliminate, number, "Double Pair");
                    
                }

                else
                {
                    foreach (var cell in cells)

                    {
                            Grid.SplitTextCoordinate(x, out int ii, out int jj);
                            rowsToEliminate.Add(ii);
                    }

                    List<string> elim = new List<string>();
                    var count = 0;
                   
                        foreach (var d in rowsToEliminate)
                        {
                            elim.Add(d + ";" + count);
                            count += 1;
                        }

                    
                }
                
               
            }

        }
        public void compare(List<string> original, List<string> join, out bool isInclude, out bool isRow)
        {
            isInclude = false;
            original.AddRange(join);
            isRow = false;
                if(original.Count!=4)
            {
                return;
            }
           
            Grid.SplitTextCoordinate(original[0], out int a, out int b);
            Grid.SplitTextCoordinate(original[1], out int c, out int d);
            Grid.SplitTextCoordinate(original[2], out int e, out int f);
            Grid.SplitTextCoordinate(original[3], out int g, out int h);
            include(a, b, c, d, e, f, g, h, out isRow, out bool x);
            if(x)
            {
                isInclude = true;
                
                return ;
            }
            return;
        }
        public void HowMany(List<string> nameIn, out int rows, out int cols)
        {
            List<int> rowList = new List<int>();
            List<int> colList = new List<int>();

            foreach(var x in nameIn)
            {
                Grid.SplitTextCoordinate(x, out int i, out int j);
                if(rowList.Contains(i) ==false)
                {
                    rowList.Add(i);
                }

                if (colList.Contains(j) == false)
                {
                    colList.Add(j);
                }


            }

            rows = rowList.Count;
            cols = colList.Count;
        }
        static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }

        public List<int> findAdjoiningBlocks(int number)
        {
            var full = number / 3;
            var mod = number % 3;
            var ans = new List<int>();
            for(int i = 0; i<9; i++)
            {
                if(i ==number)
                {
                    continue;
                }

                if( i/3 ==full || i%3==mod)
                {
                    ans.Add(i);
                }
            }

            
            return ans;
        }
    }
}
