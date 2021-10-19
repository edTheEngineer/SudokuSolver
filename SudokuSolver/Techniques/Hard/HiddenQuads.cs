using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {
        public void HiddenQuads()
        {
            HiddenQuadsTechnique(Grid.ROW);
            HiddenQuadsTechnique(Grid.COLUMNS);
            HiddenQuadsTechnique(Grid.BLOCKS);
        }

        private void HiddenQuadsTechnique(string name)
        {
            var d = findComboFour(1, 10);
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < d.Count; i++)
                {
                    SplitFourCoordinate(d[i], out int firstNumber, out int secondNumber, out int thirdNumber, out int fourthNumber);
                    var firstPossibilities = findInstancesOf(firstNumber, j, name);
                    var secondPossibilities = findInstancesOf(secondNumber, j, name);
                    var thirdPossibilities = findInstancesOf(thirdNumber, j, name);
                    var fourthPossiblities = findInstancesOf(fourthNumber, j, name);
                    compareListsQuads(firstPossibilities, secondPossibilities, thirdPossibilities, fourthPossiblities, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
                    if (isNakedQuad)
                    {
                        HiddenQuadsAdjust(j, first, second, third, fourth, firstNumber, secondNumber, thirdNumber, fourthNumber, name);
                    }

                }
            }
        }

        public void HiddenQuadsAdjust(int index, int i1, int i2, int i3, int i4, int n1, int n2, int n3, int n4, string name)
        {
            List<int> nosToAdd = new List<int>() { n1, n2, n3 , n4};
            List<int> indexesToAdd = new List<int>() { i1, i2, i3 , i4};
            AddNumbersExcept(name, indexesToAdd, index, nosToAdd);


        }



    }

    
            
}
