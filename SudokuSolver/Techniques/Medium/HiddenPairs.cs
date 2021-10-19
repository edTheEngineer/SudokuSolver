using System;
using System.Collections.Generic;
using System.Linq;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique


    {
        public List<HiddenPair> pairList = new List<HiddenPair>();
        
        public void HiddenPairTechnique() //Applies the Naked Pair Technique
        {
            HiddenSolve();
        }

       
        public string JoinCoordinate(int x1, int y1, int x2, int y2)
        {
            return " [ " + x1 + " , " + y1 + "] [ " + x2 + " , " + y2 + " ]";
        }

        public void IsHiddenPair()
        {

            var hiddenPairs = from pair in pairList
                              group pair by new
                              {
                                  pair.Name,
                                  pair.coordinate,
                                  pair.x1,
                                  pair.x2,
                                  pair.y1,
                                  pair.y2
                              } into pairGroup
                              where pairGroup.Count() == 2
                              orderby pairGroup.Key.Name descending
                              select new
                              {
                                  Name = pairGroup.Key.Name,
                                  Coordinate = pairGroup.Key.coordinate,
                                  CountKey = pairGroup.Count(),
                                  X1 = pairGroup.Key.x1,
                                  X2 = pairGroup.Key.x2,
                                  Y1 = pairGroup.Key.y1,
                                  Y2 = pairGroup.Key.y2,

                              };

           
            var hiddenPairValues =  from hidden in hiddenPairs
                     join original in pairList
                     on hidden.Coordinate equals original.coordinate
                     select (original.Number, hidden.Coordinate, original.Name, original.x1, original.x2, original.y1, original.y2)
                      ;

            foreach (var hiddenPair in hiddenPairValues)
            {
                Grid.RemovePossibilitiesFromCell(hiddenPair.x1, hiddenPair.y1, hiddenPair.Name);
                Grid.RemovePossibilitiesFromCell(hiddenPair.x2, hiddenPair.y2, hiddenPair.Name);
                
            }

            foreach (var hiddenPair in hiddenPairValues)
            {
                Grid.AddPossibilitiesToCell(hiddenPair.x1, hiddenPair.y1, hiddenPair.Name, hiddenPair.Number);
                Grid.AddPossibilitiesToCell(hiddenPair.x2, hiddenPair.y2, hiddenPair.Name, hiddenPair.Number);

            }

        }

        public struct HiddenPair
        {
            public string Name;
            public int Number;
            public int x1;
            public int y1;
            public int x2;
            public int y2;
            public string coordinate;

        }

        public void PrintPairs(IEnumerable<HiddenPair> pairQ)
        {
            foreach(var pairs in pairQ)
            {
                Console.WriteLine(pairs.Name+ " " + pairs.Number + " " + "[ " + pairs.x1 + " , " + pairs.y1 + "] " + "[ " + pairs.y1 + " , " + pairs.y2 + " ] ");
            }
            
        }
        private void SetPair(string name, int number, int x1, int y1, int x2, int y2)
        {
            var pairs = new HiddenPair();
            pairs.Name = name;
            pairs.Number = number;
            pairs.x1 = x1;
            pairs.x2 = x2;
            pairs.y1 = y1;
            pairs.y2 = y2;
            pairs.coordinate = JoinCoordinate(x1, y1, x2, y2);
            pairList.Add(pairs);
        }

        private void HiddenSolve()
        {
            for(int i = 1; i<=9; i++)
            {
                CountPossibilitiesPerNumber(i);
            }
            IsHiddenPair();
        }

        private void CountPossibilitiesPerNumber(int number)
        {
            CountPossibilities(number, Grid.Rows, Grid.ROW);
            CountPossibilities(number, Grid.Columns, Grid.COLUMNS);
            CountPossibilities(number, Grid.Blocks, Grid.BLOCKS);
        }
        private void CountPossibilities(int number, Group[] group, string name)
        {
            int count = 0;
            int firstIndex = -1;
            int secondIndex = -1;

            for (int i = 0; i <9; i++)
            {
                count = 0;

                for (int j = 0; j < 9; j++)
                {
                    var possibilities = group[i].Cells[j].Possibilities;

                    var isPoss = possibilities.FindIndex(x => x == number) >= 0;

                    if (isPoss)
                    {
                       
                        if(count ==0)
                        {
                            firstIndex = j;
                        }
                        else
                        {
                            secondIndex = j;
                        }
                        count += 1;
                    }

                }

                if (count == 2)
                {
                    SetPair(name, number, i, firstIndex, i, secondIndex);
                }
            }

        }
    }
}
