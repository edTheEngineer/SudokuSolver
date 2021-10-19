using System;
using System.Collections.Generic;
using System.Linq;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {



        public void HiddenTriples()
        {
         HiddenTripleTechnique(Grid.ROW);
          HiddenTripleTechnique(Grid.COLUMNS);
         HiddenTripleTechnique(Grid.BLOCKS);

        }

        private void HiddenTripleTechnique(string name)
        {
            var d = findComboThree(1,10);
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < d.Count; i++)
                {
                    SplitThreeCoordinate(d[i], out int x, out int y, out int z);
                    var firstCoordinate = findInstancesOf(x, j, name);
                    var secondCoordinate = findInstancesOf(y, j, name);
                    var thirdCoordinate = findInstancesOf(z, j, name);

                    compareLists(firstCoordinate, secondCoordinate, thirdCoordinate, out bool isNakedTriple, out int first, out int second, out int third);
                    if (isNakedTriple)
                    {
                        HiddenPairAdjust(j, first, second, third, x,y,z, name);
                    }

                }
            }
        }

        public void AddNumbersExcept(string name, List<int> indexes, int cellI, List<int> nosToAdd)
        {
            for(int j = 0; j<indexes.Count; j++)
            {
                for (int i = 1; i <= 9; i++)
                {
                    int index = indexes[j];
                    if (!nosToAdd.Contains(i))
                    {
                        if (name == Grid.ROW)
                        {
                            Grid.RemovePossibility(cellI, index, i);
                        }

                        if (name == Grid.COLUMNS)
                        {
                            Grid.RemovePossibility(index, cellI, i);
                        }

                        if (name == Grid.BLOCKS)
                        {
                            Grid.BlockToCoOrdinates(cellI, index, out int r1, out int r2, out int c1, out int c2, out int b1, out int b2);
                            Grid.RemovePossibility(r1, r2, i);
                        }
                    }
                }
            }
            
            
        }
        public void HiddenPairAdjust( int index, int i1, int i2, int i3, int n1, int n2, int n3, string name)
        {
                
                List<int> nosToAdd = new List<int>() { n1, n2, n3 };
                List<int> indexesToAdd = new List<int>() { i1, i2, i3 };
                AddNumbersExcept(name, indexesToAdd, index, nosToAdd);
         
            
        }

        public List<int> returnCorrectPossibilities(int groupIndex, int cellIndex, string name)
        {
            if(name ==Grid.ROW)
            {
                return Grid.Rows[groupIndex].Cells[cellIndex].Possibilities;
            }

            if (name == Grid.COLUMNS)
            {
                return Grid.Columns[groupIndex].Cells[cellIndex].Possibilities;
            }

            if (name == Grid.BLOCKS)
            {
                return Grid.Blocks[groupIndex].Cells[cellIndex].Possibilities;
            }



            return new List<int>();
        }
        public List<int> findInstancesOf(int n, int index, string name)
        {
            List<int> ans = new List<int>();
            //ROW 0
               for(int i = 0; i<9; i++)
            {
                var check = returnCorrectPossibilities(index, i, name);
                if(check.Contains(n))
                {
                    ans.Add(i);
                }
            }

            return ans;
        }

    }

}


