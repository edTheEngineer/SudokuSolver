using System;
using System.Collections.Generic;
using System.Linq;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {
        public void NakedTriple()
        {
            NakedTripleRow();
            NakedTripleCol();
            NakedTripleBlock();

        }

        public List<string> findComboThree(int start, int end)
        {
            
            List<string> ans = new List<string>();
            for (int i = start; i < end; i++)
            {
                for (int j = start; j < end; j++)
                {
                    for (int k = start; k < end; k++)
                    {
                        if (i != j && j != k && i != k)
                        {
                            orderThree(i, j, k, out int smallest, out int middle, out int max);
                            string val = smallest + ";" + middle + ";" + max;
                            if (ans.Contains(val))
                            {

                            }
                            else
                            {
                                ans.Add(val);
                            }


                        }
                    }
                }
            }
            return ans;
        }

        public void orderThree(int a, int b, int c, out int smallest, out int middle, out int biggest)
        {
            List<int> ans = new List<int>() { a, b, c };
            var p1 = Math.Min(a, b);
            smallest = Math.Min(p1, c);

            ans.Remove(smallest);
            var p2 = Math.Max(a, b);
            biggest = Math.Max(p2, c);
            ans.Remove(biggest);
            var p3 = Math.Min(a, b);
            middle = ans[0];
        }

        public void SplitThreeCoordinate(string coordinate, out int first, out int second, out int third)
        {
            //2;3;4
            first = 0;
            second = 0;
            third = 0;
            var part1 = coordinate.Substring(0, 1);
            var part2 = coordinate.Substring(2, 1);
            var part3 = coordinate.Substring(4, 1);

            first = Convert.ToInt32(part1);
            second = Convert.ToInt32(part2);
            third = Convert.ToInt32(part3);
        }

        public void RemoveNakedTriples(string name, int index, int first, int second, int third, int i1, int i2, int i3)
        {

           // Console.WriteLine(name + " INDEX " + index + " [" + first + " ; " + second + " ;" + third +"]");

                for (int i = 0; i < 9; i++)
                {
                    if (i == i1 || i == i2 || i == i3)
                    {

                    }

                    else
                    {
                        if(name ==Grid.ROW)
                        {
                            Grid.RemovePossibility(index, i, first);
                            Grid.RemovePossibility(index, i, second);
                            Grid.RemovePossibility(index, i, third);
                        }

                        if(name ==Grid.COLUMNS)
                        {
                        Grid.RemovePossibility(i, index, first);
                        Grid.RemovePossibility(i, index, second);
                        Grid.RemovePossibility(i, index, third);
                        }

                        if(name ==Grid.BLOCKS)
                        {
                        Grid.BlockToCoOrdinates(index, i, out int r1, out int r2, out int c1, out int c2, out int b1, out int b2);
                        //Console.WriteLine("[" + r1 + " , " + r2 + "]" + "LIST  = " + first + " " + second + " " + third);
                        Grid.RemovePossibility(r1, r2, first);
                        Grid.RemovePossibility(r1, r2, second);
                        Grid.RemovePossibility(r1, r2, third);
                         }
                        

                    }
                }
        }

        public List<int> getPossibilitiesByGroup(string name, int GroupIndex, int CellIndex )
        {
            if(name==Grid.ROW)
            {
                return Grid.Rows[GroupIndex].Cells[CellIndex].Possibilities;
            }

            if (name == Grid.COLUMNS)
            {
                return Grid.Columns[GroupIndex].Cells[CellIndex].Possibilities;
            }

            if (name == Grid.BLOCKS)
            {
                return Grid.Blocks[GroupIndex].Cells[CellIndex].Possibilities;
            }

            return new List<int>();
        }
        public void isNakedTriple(string coordinte, string typeName)
        {
            
            SplitThreeCoordinate(coordinte, out int firstNumber, out int secondNumber, out int thirdNumber);

                for (int i = 0; i < 9; i++)
                {
                    var firstPossibilities = getPossibilitiesByGroup(typeName, i, firstNumber);
                    var secondPossibilities = getPossibilitiesByGroup(typeName, i, secondNumber);
                    var thirdPossibilities = getPossibilitiesByGroup(typeName, i, thirdNumber);
                    compareLists(firstPossibilities, secondPossibilities, thirdPossibilities, out bool isNakedTriple, out int first, out int second, out int third);
                    if (isNakedTriple)
                    {
                        Console.WriteLine(coordinte + "IN = " + firstNumber + " " + secondNumber + " c");
                        RemoveNakedTriples(typeName, i, first, second, third, firstNumber,secondNumber,thirdNumber);
                    }
                }

        }

        public void  compareLists(List<int> firstPossibilities, List<int> secondPossibilities, List<int> thirdPossibilities, out bool isNakedTriple, out int first, out int second, out int third)
        {
            first = -1;
            second = -1;
            third = -1;
            isNakedTriple = false;
            if (firstPossibilities.Count == 0 || secondPossibilities.Count == 0 || thirdPossibilities.Count == 0)
            {
                return;
            }
            List<int> all = new List<int>();
            all.AddRange(firstPossibilities);
            all.AddRange(secondPossibilities);
            all.AddRange(thirdPossibilities);
            all.Sort();
            var d = all.Distinct();
            
            
             if( d.Count() ==3)
            {
                isNakedTriple = true;
                first = d.ElementAt(0);
                second = d.ElementAt(1);
                third = d.ElementAt(2);

            }

        }
        public void NakedTripleRow()
        {

           var combos= findComboThree(0,9);
            for (int i = 0; i < combos.Count; i++)
            {
                isNakedTriple(combos[i], Grid.ROW);
            }
        }

        public void NakedTripleCol()
        {
           // Console.WriteLine("COL");
            var combos = findComboThree(0,9);
            for (int i = 0; i < combos.Count; i++)
            {
               isNakedTriple(combos[i], Grid.COLUMNS);
            }
        
        }

        public void NakedTripleBlock()
        {
           // Console.WriteLine("BLOCK");
            var combos = findComboThree(0,9);
            for (int i = 0; i < combos.Count; i++)
            {
                 isNakedTriple(combos[i], Grid.BLOCKS);
            }
        
        }


    }

    
}
