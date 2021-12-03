using System;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {
        public void XWing()
        {
            for (int i = 1; i < 10; i++)
            {
                XWingTechnique(Grid.ROW,i);
                XWingTechnique(Grid.COLUMNS,i);
            }
        }


        public void XWingTechnique(string name, int number)
        {
            Console.WriteLine("--ENTER" + number + " "+ name);
            List<int> rowColsWithTwoPossibilitiesOfANumber = new List<int>();
            List<string> allIndexesOfNumberInGrid = new List<string>();
            for (int i = 0; i < 9; i++)
            {
                List<int> indexOfPossibilities = new List<int>();
                for (int j = 0; j < 9; j++)
                {
                    var check = new List<int>(){ };
                    if(name ==Grid.ROW)
                    {
                        check = Grid.Rows[i].Cells[j].Possibilities;
                    }

                    else
                    {
                        check = Grid.Columns[i].Cells[j].Possibilities;
                    }
                    if (check.Contains(number))
                    {
                        indexOfPossibilities.Add(j);
                    }
                }
                if (indexOfPossibilities.Count == 2)
                {
                    var allIndexesOfNumberPerRow = string.Join("~", indexOfPossibilities);
                    allIndexesOfNumberInGrid.Add(allIndexesOfNumberPerRow);
                    rowColsWithTwoPossibilitiesOfANumber.Add(i);
                }

            }

           
            IsXWing(name, number,allIndexesOfNumberInGrid,rowColsWithTwoPossibilitiesOfANumber);
        }


        public void IsXWing( string name, int num, List<string> allIndexesOfNumberInGrid, List<int> rowColsWithTwoPossibilitiesOfANumber)
        {
            var doesShareCommonRowOrCol = shareCommonRowAndCol(allIndexesOfNumberInGrid, out int x1, out int y1);
           
            if(doesShareCommonRowOrCol)
            {
                Console.WriteLine("REMOVE STUFF");
                List<int> commonIndexes = new List<int>() { rowColsWithTwoPossibilitiesOfANumber[x1], rowColsWithTwoPossibilitiesOfANumber[y1] };
                
                var xWing = findXWing(allIndexesOfNumberInGrid, commonIndexes, name, x1);
                List<string> rowIntersects = new List<string>();
                List<string> colIntersects = new List<string>();
                foreach (var coordinate in xWing)
                {
                    Grid.SplitTextCoordinate(coordinate, out int x2, out int y2);
                    GetIntersectingCellLists(x2, y2, true, out List<string> intersectBlocks, out List<string> intersectColumns, out List<string> intersectRows);
                    rowIntersects.AddRange(intersectRows);
                    colIntersects.AddRange(intersectColumns);
                }

                  foreach(var possibility in xWing)
                {
                    rowIntersects.RemoveAll(x => x == possibility);
                    colIntersects.RemoveAll(x => x == possibility);
                }

                var distinctRows=    rowIntersects.Distinct().ToList();
                var distinctColumns = colIntersects.Distinct().ToList(); ;

                Grid.RemovePossibilities(distinctRows, num, "X Wing");
                Grid.RemovePossibilities(distinctColumns, num, "X Wing");
            }

            

        }

        public List<int> splitIndexes(List<string> ans, int indexToFind)
        {
            var coOrdinateAtIndex = ans[indexToFind];
            var coordinates =coOrdinateAtIndex.Split("~");
            List<int> coordinateList = new List<int>();
            foreach (var c in coordinates)
            {
                coordinateList.Add(Convert.ToInt32(c));
            }
            return coordinateList;
        }
        public List<string> findXWing(List<string> allCellIndexes, List<int> allRowColIndexes, string name, int indexToFind)
        {
            var commonIndexes = splitIndexes(allCellIndexes, indexToFind);
            
            List<string> answer = new List<string>();
            foreach(var x in commonIndexes)
            {
                foreach(var y in allRowColIndexes)
                {
                    if(name==Grid.ROW)
                    {
                        answer.Add(y + ":" + x);
                    }
                    if(name==Grid.COLUMNS)
                    {
                        answer.Add(x + ":" + y);
                    }
                }
            }
            return answer;

        }
        public bool shareCommonRowAndCol(List<string> coordinates, out int a, out int b)
        {
            List<string> outy = new List<string>();
            for(int i = 0; i<coordinates.Count; i++)
            {
                for(int j = 0; j<coordinates.Count; j++)
                {
                    if(i!=j)
                    {
                        if (coordinates[i] == coordinates[j])
                        {
                            a = i;
                            b = j;
                            return true;
                        }
                    }
                }
            }
            a = -1;
            b = -1;
            return false;
        }
    }
  
}
