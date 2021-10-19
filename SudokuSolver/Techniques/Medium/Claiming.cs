using System;
using System.Collections.Generic;
using System.Linq;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {
        public void Claiming()
        {
            for (int i = 1; i <= 9; i++)
            {

                commonClaiming(i, Grid.COLUMNS);
                commonClaiming(i, Grid.BLOCKS);
                commonClaiming(i, Grid.ROW);

            }

        }

        public void getPossibilityGroups(int i, int j, string name, out List<int> possibilities)
        {
            if(name ==Grid.ROW)
            {
                possibilities = Grid.Rows[i].Cells[j].Possibilities;
            }

            if (name == Grid.COLUMNS)
            {
                possibilities = Grid.Columns[i].Cells[j].Possibilities;
            }

            if (name == Grid.BLOCKS)
            {
                possibilities = Grid.Blocks[i].Cells[j].Possibilities;
            }

            else
            {
                possibilities = new List<int>() { };
            }
        }

        public void commonClaiming(int number, string name)
        {
            if(name ==Grid.ROW)
            {
                rowColumnClaiming(number, true);
            }

            if (name == Grid.COLUMNS)
            {
                rowColumnClaiming(number, false);
            }

            if (name == Grid.BLOCKS)
            {
                boxClaiming(number);
            }

        }
               
        public void rowColumnClaiming(int number, bool isClaimRows)
        {
            for (int i = 0; i < 9; i++)
            {
                var c = new List<int>() { };
                for (int j = 0; j < 9; j++)
                {
                    var possibilities = isClaimRows ? Grid.Rows[i].Cells[j].Possibilities : Grid.Columns[i].Cells[j].Possibilities; ;
                    if (possibilities.FindIndex(x => x == number) >= 0)
                    {
                        c.Add(j);
                    }

                }

                CommonBlock(i, c, out var rowColList, out var isRowOrColumn);
                if (isRowOrColumn)
                {
                    var cooordinates = new List<string>();
                    var blockcooordinates = new List<string>();
                    //Console.WriteLine(i);
                    foreach (var x in c)
                    {
                        if(isClaimRows)
                        {
                            cooordinates.Add(i + ";" + x);
                        }

                        else
                        {
                            cooordinates.Add(x + ";" + i);
                        }
                    }


                    var block =  isClaimRows ? Grid.GetBlockFromCoOrdinates(i, c[0]) - 1 : Grid.GetBlockFromCoOrdinates(c[0], i) - 1;

                    var cells = Grid.CellsInBlock(block + 1);
                    var list = new List<string>();
                    foreach (var d in cells)
                    {
                        Grid.GetCoOrdinatesOfCell(d, out int iii, out int j);
                        blockcooordinates.Add(iii + ";" + j);
                    }
                    var fi = filterLargeListBySmallerList(blockcooordinates, cooordinates);
                    Grid.RemovePossibilities(fi, number, "Claiming");
                    c.RemoveAll(x => x >= 0);
                }


            }
        }
        public List<string> filterLargeListBySmallerList(List<string> mainList, List<string> cellsToExclude)
        {
            var answer = new List<string>();
            
            foreach(var cell in mainList)
            {
                if(cellsToExclude.FindIndex(x=>x==cell)<0)

                    answer.Add(cell);
            }

            return answer;
        }

       
        public void boxClaiming(int number)
        {

            for(int i=0; i<9; i++)
            {
                var c = new List<int>() { };
                for (int j = 0; j < 9; j++)
                {
                    
                    var possibilities = Grid.Blocks[i].Cells[j].Possibilities;
                    if(possibilities.FindIndex(x=>x==number)>=0)
                      {
                             c.Add(j);
                      }

                }
                
                CommonRowOrCol(i, c, out bool isRow, out bool isCol, out var rowList, out var colList);
                if (isRow ||isCol)
                {
                    var list =   GetCellsOnSameLine(i, rowList, colList, isRow, isCol);
                    Grid.RemovePossibilities(list, number, "Claiming");
                }
                c.RemoveAll(x => x >= 0);
            }
            
        }

        public int findNewRow(int num, int block)
        {
            var x = (block / Grid.BlockWidth) *Grid.BlockHeight;
            var res = x + num;
            return res;
        }


        public int findNewCol(int num, int block)
        {
            var x = (block  % Grid.BlockWidth)*Grid.BlockHeight;
            var res = x + num;
            return res;
        }

        public List<string> getCellsOnLineNotinBlock(int block, int row, int col)
        {
            var cellList = new List<string>();

            if(row !=-1)
            {
                for(int i = 0; i<Grid.RowCount; i++)
                {
                    Grid.GetBlockNumberAndIndexInBlock(row, i, out int blockNumber, out int BlockIndex);
                    if(blockNumber ==block)
                    {
                    }
                    else
                    {
                        cellList.Add(row + ";" + i);
                    }
                    
                }
            }

            if(col !=-1)
            {
                for (int i = 0; i < Grid.RowCount; i++)
                {
                    Grid.GetBlockNumberAndIndexInBlock(i, col, out int blockNumber, out int BlockIndex);
                    if (blockNumber == block)
                    {
                    }
                    else
                    {
                        cellList.Add(i + ";" + col);
                    }
                }
            }
            return cellList;
        }
        public List<string> GetCellsOnSameLine(int block, List<int> rowList, List<int> colList, bool isRow, bool isCol)
        {
            var newRow = -1;
            var newCol = -1;
            List<int> mainList = new List<int>();
            if(isRow)
            {
                mainList = rowList;
                var first = mainList[0];
                newRow= findNewRow(first, block);
            }

            else
            {
                mainList = colList;
                var first = mainList[0];
                newCol = findNewCol(first, block);
            }

            return getCellsOnLineNotinBlock(block, newRow, newCol);
            
        }

        public void CommonRowOrCol(int blockNumber, List<int> coordinates,  out bool isRow, out bool isCol, out List<int> rowList, out List<int> colList)
        {
             rowList = new List<int>() { };
             colList = new List<int>() { };
             
            foreach(var x in coordinates)
            {
                int row = x / Grid.BlockWidth;
                int col = x % Grid.BlockHeight;
                colList.Add(col);
                rowList.Add(row);
               
            }

            isRow = isListTheSame(rowList);
            isCol = isListTheSame(colList);

        }

        public void CommonBlock(int Number, List<int> coordinates, out List<int> rowList, out bool isRow)
        {
            rowList = new List<int>() { };
            foreach (var x in coordinates)
            {
                var row = x / Grid.BlockHeight;
                rowList.Add(row);

            }

            isRow = isListTheSame(rowList);

        }

        public bool isListTheSame(List<int> coordinates)
        {
            
            if(coordinates.Count ==0)
            {
                return false;
            }
            var check = coordinates[0];
            for(int i = 0; i<coordinates.Count; i++)
            {
                if(check !=coordinates[i])
                {
                    return false;
                }
                check = coordinates[i];
            }

            return true;
        }

      
        
    }
}
