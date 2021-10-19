using System;
using System.Collections.Generic;
using System.Linq;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {
        public void BlockLine()
        {
            //findRow(1);
            for(int i = 1; i<=9; i++)
            {
                findRow(i);
            }
            
        }

        public void findRow(int num)
        {
            for (int i = 0; i < 9; i++)
            {
                List<int> indexed = new List<int>();
                for (int j = 0; j < 9; j++)
                {
                    var check = Grid.Blocks[i].Cells[j].Possibilities;

                    if (check.Contains(num))
                    {
                        indexed.Add(j);
                    }
                }

                findLocations(indexed, out bool isRow, out bool isCol, out int index);
                var b = findSameBlock(isRow, isCol, i);
                
                if (isRow)
                {
                    Console.WriteLine("BLOCK IS  " + i + "ROW ");
                    eliminateRows(b, index, num);
                }

                if (isCol)
                {
                    Console.WriteLine("BLOCK IS  " + i + "COL ");
                    eliminateCols(b, index, num);
                }
            }
        }

        public void eliminateRows(List<int> blocks, int index, int num)
        {
            //Blocks 4 and 5

            for(int i = 0; i<blocks.Count; i++)
            {
                var row = trueRowNumber(blocks[i], index, true);
                Console.WriteLine("ELIMINATE NUM " + num);
                foreach(var x in row)
                {
                    Console.WriteLine(x + "~");
                }
                Grid.RemovePossibilities(row, num, "BlockLine");
            }
        }

        public List<string> trueRowNumber(int block, int row, bool isRow)
        {
            Console.WriteLine("BLOCK IN " + block + " ROW IN " + row);
            List<string> ans = new List<string>();

            List<int> include   = new List<int>();

            if(isRow)
            {
                row *= 3;
                include.Add(row);
                include.Add(row + 1);
                include.Add(row + 2);
            }

            else
            {
                include.Add(row);
                include.Add(row + 3);
                include.Add(row + 6);
            }

            var cells = Grid.GetCellsInBlock(block+1);

            for (int ii = 0; ii < 9; ii++)
            {
                if(include.Contains(ii))
                {
                    var x = cells[ii];
                    Grid.GetCoOrdinatesOfCell(x, out int i, out int j);
                    if(isRow)
                    {
                        ans.Add(i + ";" + j);
                    }

                    else
                    {
                        ans.Add(i + ";" + j);
                    }
                    
                }



            }

            return ans;
        }
        public void eliminateCols(List<int> blocks, int block, int num)
        {

            for (int i = 0; i < blocks.Count; i++)
            {
                var row = trueRowNumber(blocks[i], block, false);
                Console.WriteLine("ELIMINATE NUM " + num);
               
                foreach (var x in row)
                {
                    Console.WriteLine(x + "~");
                }
                Grid.RemovePossibilities(row, num, "BlockLine");
            }
        }
        public List<int> findSameBlock( bool isRow, bool isCol, int block)
        {
            int checkNum = block / 3;
            int checkMod = block % 3;
            var ans = new List<int>();
           for(int i = 0; i<9; i++)
            {
                var num = i / 3;
                var mod = i % 3;
                 if(block==i)
                {
                    continue;
                }
                if(isRow)
                {
                    if(num == checkNum)
                    {
                        ans.Add(i);
                    }
                }

                if (isCol)
                {
                    if (mod==checkMod)
                    {
                        ans.Add(i);
                    }
                }
            }

            return ans;
           
        }
        public void findLocations(List<int> indexes, out bool isRow, out bool isColumn, out int indexVal)
        {
            isRow = false;
            isColumn = false;
            indexVal = -1;
            if(indexes.Count ==0)
            {
                return;
            }
            List<int> numbers = new List<int>();
            List<int> moduli = new List<int>();
            foreach (var x in indexes)
            {
                var num = x / 3;
                var mod = x % 3;
                numbers.Add(num);
                moduli.Add(mod);
             
            }

            var numbersUnique= numbers.Distinct();
            if(numbersUnique.Count() ==1)
            {
                isRow = true;
                indexVal = numbers[0];
                return;
                
            }

           var modUnique =moduli.Distinct();
            if (modUnique.Count() == 1)
            {
                isColumn = true;
                indexVal = moduli[0];
                return;
            }

        }
    }
}
