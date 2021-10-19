using System;
using System.Collections.Generic;
using System.Linq;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique

    {
        public void NakedQuad()
        {
            NakedQuadRow();
            NakedQuadCol();
            NakedQuadBlock();

        }

        public bool DifferentIndex(int i, int j, int k, int l)
        {
            List<int> ans = new List<int>() { i, j, k,l };
            var count = ans.Distinct().Count();
            return count == 4;
            
        }
        public List<string> findComboFour(int start, int end)
        {
            List<string> ans = new List<string>();
            for (int i = start; i < end; i++)
            {
                for (int j = start; j < end; j++)
                {
                    for (int k = start; k < end; k++)
                    {

                        for(int l = start; l<end; l++)
                        {
                            if (DifferentIndex(i, j,k,l))
                            {
                                orderFour(i, j, k, l, out int smallest, out int middle, out int middleB, out int max);
                                string val = smallest + ";" + middle + ";" + middleB + ";" +max;
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
            }
            return ans;
        }

        public void orderFour(int a, int b, int c, int d, out int smallest, out int middleA, out int middleB, out int biggest)
        {
            
            List<int> ans = new List<int>() { a, b, c, d };
            ans.Sort();
            smallest = ans[0];
            middleA = ans[1];
            middleB = ans[2];
            biggest = ans[3];
        }

        public void SplitFourCoordinate(string coordinate, out int first, out int second, out int third, out int fourth)
        {

            var part1 = coordinate.Substring(0, 1);
            var part2 = coordinate.Substring(2, 1);
            var part3 = coordinate.Substring(4, 1);
            var part4 = coordinate.Substring(6, 1);


            first = Convert.ToInt32(part1);
            second = Convert.ToInt32(part2);
            third = Convert.ToInt32(part3);
            fourth = Convert.ToInt32(part4);
        }

        public void RemoveNakedQuads(string name, int index, int first, int second, int third, int fourth, int i1, int i2, int i3, int i4)
        {

            //Console.WriteLine(name + " INDEX " + index + " [" + first + " ; " + second + " ;" + third +  ";" + fourth+ "]");

            for (int i = 0; i < 9; i++)
            {
                if (i == i1 || i == i2 || i == i3 || i ==i4)
                {

                }

                else
                {
                    if (name == Grid.ROW)
                    {
                        //Console.WriteLine("[" + index + " , " + i + "]" + "LIST  = " + first + " " + second + " " + third +  " " + fourth);
                        Grid.RemovePossibility(index, i, first);
                        Grid.RemovePossibility(index, i, second);
                        Grid.RemovePossibility(index, i, third);
                        Grid.RemovePossibility(index, i, fourth);
                    }

                    if (name == Grid.COLUMNS)
                    {
                        //Console.WriteLine("[" + index + " , " + i + "]" + "LIST  = " + first + " " + second + " " + third + " " + fourth);
                        Grid.RemovePossibility(i, index, first);
                        Grid.RemovePossibility(i, index, second);
                        Grid.RemovePossibility(i, index, third);
                        Grid.RemovePossibility(i, index, fourth);
                    }

                    if (name == Grid.BLOCKS)
                    {
                        Grid.BlockToCoOrdinates(index, i, out int r1, out int r2, out int c1, out int c2, out int b1, out int b2);
                        //Console.WriteLine("[" + r1 + " , " + r2 + "]" + "LIST  = " + first + " " + second + " " + third + " " + fourth);
                        Grid.RemovePossibility(r1, r2, first);
                        Grid.RemovePossibility(r1, r2, second);
                        Grid.RemovePossibility(r1, r2, third);
                        Grid.RemovePossibility(r1, r2, fourth);
                    }


                }
            }
        }


        public void isNakedQuad(string coordinate, string typeName)
        {

            SplitFourCoordinate(coordinate, out int firstNumber, out int secondNumber, out int thirdNumber, out int fourthNumber);

            for (int i = 0; i < 9; i++)
            {
                var firstPossibilities = getPossibilitiesByGroup(typeName, i, firstNumber);
                var secondPossibilities = getPossibilitiesByGroup(typeName, i, secondNumber);
                var thirdPossibilities = getPossibilitiesByGroup(typeName, i, thirdNumber);
                var fourthPossibilities = getPossibilitiesByGroup(typeName, i, fourthNumber);
                compareListsQuads(firstPossibilities, secondPossibilities, thirdPossibilities, fourthPossibilities, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
                if (isNakedQuad)
                {
                    //Console.WriteLine(coordinte + "IN = " + firstNumber + " " + secondNumber + " c");
                    RemoveNakedQuads(typeName, i, first, second, third, fourth, firstNumber, secondNumber, thirdNumber, fourthNumber);
                }
            }

        }

        public void compareListsQuads(List<int> firstPossibilities, List<int> secondPossibilities, List<int> thirdPossibilities, List<int> fourthPossibilities, out bool isNakedQuad, out int first, out int second, out int third, out int fourth)
        {
            first = -1;
            second = -1;
            third = -1;
            fourth = -1;
            isNakedQuad = false;
            if (firstPossibilities.Count == 0 || secondPossibilities.Count == 0 || thirdPossibilities.Count == 0 ||fourthPossibilities.Count ==0)
            {
                return;
            }
            List<int> all = new List<int>();
            all.AddRange(firstPossibilities);
            all.AddRange(secondPossibilities);
            all.AddRange(thirdPossibilities);
            all.AddRange(fourthPossibilities);
            all.Sort();
            var d = all.Distinct();


            if (d.Count() == 4)
            {
                isNakedQuad = true;
                first = d.ElementAt(0);
                second = d.ElementAt(1);
                third = d.ElementAt(2);
                fourth = d.ElementAt(3);

            }

        }
        public void NakedQuadRow()
        {

            //Console.WriteLine("ROW");
            var combos = findComboFour(0,9);
            for (int i = 0; i < combos.Count; i++)
            {
               // Console.WriteLine(combos[i] + "~");
                isNakedQuad(combos[i], Grid.ROW);
            }
        }

        public void NakedQuadCol()
        {
            //Console.WriteLine("COL");
            var combos = findComboFour(0,9);
            for (int i = 0; i < combos.Count; i++)
            {
                isNakedQuad(combos[i], Grid.COLUMNS);
            }

        }

        public void NakedQuadBlock()
        {
            //Console.WriteLine("BLOCK");
            var combos = findComboFour(0,9);
            for (int i = 0; i < combos.Count; i++)
            {
                isNakedQuad(combos[i], Grid.BLOCKS);
            }

        }
    }
}
