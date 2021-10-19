using System;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {
        public void XYWing()
        {
            xyTechnique();

        }

        public void xyTechnique()
        {
            List<string> pairCoordinates = new List<string>();
            createListOfCellsWithTwoPossibilities(pairCoordinates);

            foreach (var x in pairCoordinates)
            {
                Console.WriteLine(x + " * ");
            }
            for (int i = 0; i < pairCoordinates.Count; i++)
            {
                for (int j = 0; j < pairCoordinates.Count; j++)
                {
                    for (int k = 0; k < pairCoordinates.Count; k++)
                    {

                        var firstPair = pairCoordinates[i];
                        var secondPair = pairCoordinates[j];
                        var thirdPair = pairCoordinates[k];

                        var isXWing = isXYWing(firstPair, secondPair, thirdPair);

                        List<string> coordinates = new List<string>() { firstPair, secondPair, thirdPair };

                        if (isXWing)
                        
                        {
                            
                            var isXWingGroup = isValidXYWing(coordinates);


                            if (isXWingGroup)
                            {
                                
                                var pairList = new List<string>() { firstPair, secondPair, thirdPair };
                                var intersect = FindIntersect(pairList[0], pairList[2]);
                                Grid.SplitTextCoordinate(firstPair, out int x1, out int y1);
                                Grid.SplitTextCoordinate(thirdPair, out int x3, out int y3);
                                Console.WriteLine("PAIR TRIPLE IS " + firstPair + " , " + secondPair + " , " + thirdPair);
                                var firstPossibilities = Grid.Rows[x1].Cells[y1].Possibilities;
                                var thirdPossibilities = Grid.Rows[x3].Cells[y3].Possibilities;
                                var number = findCommonPossibility(firstPossibilities, thirdPossibilities);
                                if (number != 0)
                                {
                                    Console.WriteLine("NUMBER TO REMOVE " + number + " ");
                                    Grid.RemovePossibilities(intersect, number, "XYWing");
                                }

                            }
                        }
                    }
                        
                }
            }
        }

        private void createListOfCellsWithTwoPossibilities(List<string> pairCoordinates)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var poss = Grid.Rows[i].Cells[j].Possibilities;

                    if (poss.Count == 2)
                    {
                        pairCoordinates.Add(i + ";" + j);
                    }
                }
            }
        }

        public int findCommonPossibility(List<int> a, List<int> b)
        {
            List<int> all = new List<int>();
            foreach(var x in b)
            {
                if(a.Contains(x))
                {
                    return x;
                }
            }

            return 0;
        }
        
        public bool isXYWing(string x, string y, string z)
        {

            if(x ==y ||y==z ||x ==z)
            {
                return false;
            }
            
           
            List<string> coordinates = new List<string>() { x,y,z};
            if(!doCoordinatesFormAXYWing(coordinates))
            {
                return false;
            }
            foreach(var a in coordinates)
            {
                Grid.SplitTextCoordinate(a, out int i, out int j);
                var possibilities = Grid.Rows[i].Cells[j].Possibilities;
                if(possibilities.Count !=2)
                {
                    return false;
                }


            }

            return true;

        }

        public bool sharePossibilities(List<int> p1, List<int> p2, List<int> p3)
        {

            if(p1.Count!=2 || p2.Count!=2 ||p3.Count!=2)
            {
                return false;
            }

            List<int> all = new List<int>();
            all.AddRange(p1);
            all.AddRange(p3);

            for(int i =0; i<p2.Count; i++)
            {
                if(!all.Contains(p2[i]))
                    {
                    return false;
                   }
            }

            var distinctList = all.Distinct();


            var x = p2[0];
            var y = p2[1];
            var distinctListAsList = distinctList.ToList();
            distinctListAsList.Remove(x);
            distinctListAsList.Remove(y);
            var z = -1;
            if(distinctListAsList.Count >=1)
            {
                z = distinctListAsList[0];
               
            }

            else
            {
                return false;
            }
            

            var firstIsXZ = (p1.Contains(x) && p1.Contains(z));
            var thirdIsXZ = (p3.Contains(x) && p3.Contains(z));
            var firstIsYZ = (p1.Contains(y) && p1.Contains(z));
            var thirdIsYZ = (p3.Contains(z) && p3.Contains(z));
            var xz_xy_yz = firstIsXZ && thirdIsYZ;
            var yz_xy_xz = firstIsYZ && thirdIsXZ;

            if (xz_xy_yz || yz_xy_xz)
            {
                if(xz_xy_yz && yz_xy_xz )
                {
                    return false;
                }

                return true;
            }

            return false;
        }
        public bool IsIntersect(string firstCoordinate, string secondCoordinate)
        {
            if( firstCoordinate==secondCoordinate)
            {
               
                return false;
            }

            Grid.SplitTextCoordinate(firstCoordinate, out int x1, out int y1);
            Grid.SplitTextCoordinate(secondCoordinate, out int x2, out int y2);

            if(x1 ==x2)
            {
                return true;
            }

            if(y1==y2)
            {
                return true;
            }

            var b1 = Grid.GetBlockFromCoOrdinates(x1, y1);
            var b2 = Grid.GetBlockFromCoOrdinates(x2, y2);
            if(b1 ==b2)
            {
                return true;
            }

            return false;
        }

        public  List<int> getPossibilitiesByCoordinate(string x)
        {
            Grid.SplitTextCoordinate(x, out int i, out int j);

            return Grid.Rows[i].Cells[j].Possibilities;
        }

        public bool doCoordinatesFormAXYWing(List<string> coordinates)
        {
            var first = IsIntersect(coordinates[0], coordinates[1]);
            var second = IsIntersect(coordinates[1], coordinates[2]);
            var third = IsIntersect(coordinates[0], coordinates[2]);

            if (first && second && !third)
            {
                return true;

            }

            return false;
        }
        public bool isValidXYWing(List<string> coordinates)
        {
            if(coordinates.Count!=3)
            {
                return false;
            }

            if(!doCoordinatesFormAXYWing(coordinates))
            {
                return false;
            }

            var firstPossibilities = getPossibilitiesByCoordinate(coordinates[0]);
            var secondPossibilities = getPossibilitiesByCoordinate(coordinates[1]);
            var thirdPossibilities = getPossibilitiesByCoordinate(coordinates[2]);

            if(sharePossibilities(firstPossibilities, secondPossibilities, thirdPossibilities))
            {
                return true;
            }

            return false;
        }
    }

}
