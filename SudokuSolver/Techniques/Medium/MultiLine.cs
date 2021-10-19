using System;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {

        public void MultiLine()
        {
            MultiLine(false);
        }
        public void MultiLine(bool isDoublePair)
        {
            var distinctBlocks = getDistinctBlocks(isDoublePair);
            for (int num = 1; num<=9; num++)
                {
                for(int i = 0; i<distinctBlocks.Count; i++)
                {
                    var coordinate = distinctBlocks[i];
                    Grid.SplitTextCoordinate(coordinate, out int a, out int b);
                    FindMultiLineTechnique(a, b, num);
                }
            }

        }

        public List<string> getDistinctBlocks(bool isDoublePair)
        {
            List<string> rawAns = new List<string>();
            for(int i = 1; i<=9; i++)
            {
                var adjoiningBlocks = findAdjoiningBlocksNew(i);

                for(int j = 0; j<adjoiningBlocks.Count; j++)
                {
                    int smallest = Math.Min(i, adjoiningBlocks[j]);
                    int biggest = Math.Max(i, adjoiningBlocks[j]);
                    rawAns.Add(smallest + ";"+biggest);
                }
            }

           List<string> ans = new List<string>();
            var doublePairList = rawAns;
           var distinctList = rawAns.Distinct();
            if(isDoublePair)
            {
                foreach (var disinctValue in doublePairList)
                {
                    ans.Add(disinctValue);
                }
            }

            else
            {
                foreach (var disinctValue in distinctList)
                {
                    ans.Add(disinctValue);
                }
            }
           
            return ans;
        }
        public void FindMultiLineTechnique(int blockOne, int blockTwo, int num)
        {
             var cells = compareCells(blockOne, blockTwo);
             findRowColList(cells, num, out List<int> row, out List<int> col, out bool isError);
            if(!isError)
            {
                isSameRowCol(row, col, blockOne, blockTwo, num);
            }
        }

        public bool isErrorCellsInRowsCols(int block, int row1, int row2)
        {
            if (block > 9 || block < 1)
            {
                return true;
            }

            if (row1 > 8 || row1 < 0)
            {
                return true;
            }

            if (row2 > 8 || row2 < 0)
            {
                return true;
            }

            return false;
        }

        public List<int> findAdjoiningBlocksNew(int number)
        {
            number -= 1;
            var full = number / 3;
            var mod = number % 3;
            var ans = new List<int>();
            if (mod<0)
            {
                return new List<int>();
            }

            else
            {
               
                for (int i = 0; i < 9; i++)
                {
                    if (i == number)
                    {
                        continue;
                    }

                    if (i / 3 == full || i % 3 == mod)
                    {

                        ans.Add(i + 1);
                    }
                }

            }


            return ans;
        }
        public int findMissingBlock(int b1, int b2)
        {
            var diff = Math.Abs(b1 - b2);

            int smallest = Math.Min(b1, b2);
            int biggest = Math.Max(b1, b2);

            if(diff==1)
            {

                int smallestDivided = (smallest-1) / 3;
                int biggestDivided = (biggest-1) / 3;

                int newBigDivided = biggest / 3;

                if (newBigDivided==biggestDivided)
                {
                    return  biggest+1;
                }

                else
                {
                    return smallest - 1;
                }

            }

            if(diff ==2)
            {
                return biggest - 1;
            }

            if(diff==3)
            {
                var newResult = biggest + 3;

                if (newResult <=9)
                {
                    return biggest += 3;
                }

                else

                {
                    return smallest -= 3;
                }
            }

            if(diff==6)
            {
                return biggest - 3;
            }
            if( b1 <0 ||b1<0 ||b2>9 ||b1>9)
            {
                return -1;
            }
            return -1;
        }

        public List<string> getCellsInRows(int block, int row1, int row2)
        {
            List<string> ans = new List<string>();
            List<string> coordinates = new List<string>();
            if (isErrorCellsInRowsCols(block, row1, row2))
            {
                return new List<string>();
            }
            var cells = Grid.GetCellsInBlock(block);
           // Console.WriteLine("BLOCK " + block  + " " + row1 + " " + row2 + " " + cells.Count);
            for(int i = 0; i<cells.Count; i++)
            {

                    Grid.GetCoOrdinatesOfCell(cells[i], out int x, out int y);
                     if(row1 ==x || row2 ==x)
                {
                    coordinates.Add(x + ";" + y);
                }
                    

            }

            coordinates.Sort();
            return coordinates;
        }

        public List<string> getCellsInCols(int block, int row1, int row2)
        {
            List<string> ans = new List<string>();
            List<string> coordinates = new List<string>();

           if(isErrorCellsInRowsCols(block, row1, row2))
            {
                return new List<string>();
            }
            var cells = Grid.GetCellsInBlock(block);

            for (int i = 0; i < cells.Count; i++)
            {
                    Grid.GetCoOrdinatesOfCell(cells[i], out int x, out int y);

                if(row1 ==y || row2 ==y)
                {
                    coordinates.Add(x + ";" + y);
                }
                   

            }
            coordinates.Sort();
            return coordinates;

        }
        public void isSameRowCol(List<int> row, List<int> col, int firstBlock, int secondBlock, int num)
        {

            var distinctInRow = row.Distinct();
            var distinctInColumn = col.Distinct();

            if (distinctInRow.Count() == 2)
            {
               var missingBlockIndex =  findMissingBlock(firstBlock, secondBlock);
               if(missingBlockIndex>=0)
                {
                    
                    var c  = getCellsInRows(missingBlockIndex, distinctInRow.ElementAt(0), distinctInRow.ElementAt(1));
                    
                    if(c.Count>0)
                    {
                       // Console.WriteLine(num + "###");
                        Grid.RemovePossibilities(c, num, "MultiLine");
                    }
                    
                }


            }

            if (distinctInColumn.Count() == 2)
            {

                var b = findMissingBlock(firstBlock, secondBlock);
                
                if (b < 0)
                {
                    Console.WriteLine(firstBlock + " " + secondBlock);
                }

                else
                {
                    //Console.WriteLine("Distinct Col");
                   // Console.WriteLine("IN COL" + b + ", " + cd.ElementAt(0) + " , " +cd.ElementAt(1) + " REMOVE " + num);
                    var c = getCellsInCols(b, distinctInColumn.ElementAt(0), distinctInColumn.ElementAt(1));
                    if (c.Count > 0)
                    {
                        Grid.RemovePossibilities(c, num, "MultiLine");
                    }


                }

            }
        }
        public List<int> compareCells(int firstBlock, int secondBlock)
        {
            var cellsInFirstBlock = Grid.GetCellsInBlock(firstBlock);//1-9
            var cellsInSecondBlock = Grid.GetCellsInBlock(secondBlock);//1-9
            List<int> ans = new List<int>();
            ans.AddRange(cellsInFirstBlock);
            ans.AddRange(cellsInSecondBlock);
            ans.Sort();
            return ans;
        }

        public void findRowColList(List<int> cells, int num, out List<int> rowLine, out List<int> colLine, out bool isError)
        {
            rowLine = new List<int>();
            colLine = new List<int>();
            isError = false;
            foreach (var y in cells)
            {
                Grid.GetCoOrdinatesOfCell(y, out int i, out int j);
                var check = Grid.Rows[i].Cells[j].Possibilities;
                var numberCheck = Grid.Rows[i].Cells[j].Number;

                if(numberCheck ==num)

                {
                    isError = true;
                }
               else if (check.Contains(num))
                {
                    findRowLineColLine(y, out int rowL, out int colL);
                    rowLine.Add(rowL);
                    colLine.Add(colL);
                }
            }
        }

       

        public void findRowLineColLine(int cell, out int rowLine, out int ColLine)
        {
            Grid.GetCoOrdinatesOfCell(cell, out int i, out int y);
            rowLine =i;
            ColLine = y;
        }


    }
}
