using System;
using System.Collections.Generic;
using System.Linq;


namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {
        public void XYZWing()
        {
            XYZTechnique();
        }

        private void createListOfCellsWithTwoOrThreePossibilities(List<string> pairCoordinates)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var possibilities = Grid.Rows[i].Cells[j].Possibilities;

                    if (possibilities.Count == 2 || possibilities.Count ==3)
                    {
                        pairCoordinates.Add(i + ";" + j);
                    }
                }
            }
        }

        public bool isXYZWing(string x, string y, string z)
        {

            if (x == y || y == z || x == z)
            {
                return false;
            }


            List<string> coordinates = new List<string>() { x, y, z };
            if (!doCoordinatesFormAXYWing(coordinates))
            {
                return false;
            }

            
            foreach (var a in coordinates)
            {
                Grid.SplitTextCoordinate(a, out int i, out int j);
                var possibilities = Grid.Rows[i].Cells[j].Possibilities;
                if (possibilities.Count >3 || possibilities.Count <2)
                {
                    return false;
                }


            }

            return true;

        }

        public bool sharePossibilitiesXYZWing(List<int> p1, List<int> p2, List<int> p3)
        {

            if (p1.Count != 2 || p2.Count != 3 || p3.Count != 2)
            {
                return false;
            }

            List<int> all = new List<int>();
            all.AddRange(p1);
            all.AddRange(p3);

            for (int i = 0; i < p2.Count; i++)
            {
                if (!all.Contains(p2[i]))
                {
                    return false;
                }
            }

            List<string> xyzList = new List<string>() { "0;1;2", "0;2;1", "1;0;2", "1;2;0", "2;1;0", "2;0;1" }; //Don't know order of x and y and x

            for(int i =0; i<xyzList.Count; i++)
            {
                SplitThreeCoordinate(xyzList[i], out int first, out int second, out int third);

                var x = p2[first];
                var y = p2[second];
                var z = p2[third];

                var firstIsXZ = (p1.Contains(x) && p1.Contains(z));
                var thirdIsXZ = (p3.Contains(x) && p3.Contains(z));
                var firstIsYZ = (p1.Contains(y) && p1.Contains(z));
                var thirdIsYZ = (p3.Contains(z) && p3.Contains(z));
                var xz_xy_yz = firstIsXZ && thirdIsYZ;
                var yz_xy_xz = firstIsYZ && thirdIsXZ;

                Console.WriteLine("X: " + x + " Y: " + y + " Z: " + z);
                if (xz_xy_yz || yz_xy_xz)
                {
                    if(xz_xy_yz && yz_xy_xz)
                    {
                        continue;
                    }
                    else
                    {
                        return true;
                    }
                    
                }
            }
            

            return false;
        }
        public bool isValidXYZWing(List<string> coordinates)
        {
            if (coordinates.Count != 3)
            {
                return false;
            }

            if (!doCoordinatesFormAXYWing(coordinates))
            {
                return false;
            }

            var firstPossibilities = getPossibilitiesByCoordinate(coordinates[0]);
            var secondPossibilities = getPossibilitiesByCoordinate(coordinates[1]);
            var thirdPossibilities = getPossibilitiesByCoordinate(coordinates[2]);

            if (sharePossibilitiesXYZWing(firstPossibilities, secondPossibilities, thirdPossibilities))
            {
                return true;
            }

            return false;
        }

        public int findCommonPossibilityXYZ(List<int> firstPossibilities, List<int> secondPossibilities, List<int> thirdPossibilities)
        {
            List<int> all = new List<int>();
            all.AddRange(firstPossibilities);
            all.AddRange(secondPossibilities);
            all.AddRange(thirdPossibilities);

            all.Sort();

            var countOfValues = 1;
            for(int i = 0; i<all.Count-1; i++)
            {
                if(all[i] ==all[i+1])
                {
                    countOfValues += 1;
                }

                else
                {
                    countOfValues = 1;
                }

                if(countOfValues ==3)
                {
                    return all[i];
                }
            }
            return -1;
        }

        public List<string> FindIntersectXYZ(string firstPossibilities, string secondPossibilities, string thirdPossibilities)
        {
            List<string> ans = new List<string>();
            Grid.SplitTextCoordinate(firstPossibilities, out int i1, out int j1);
            Grid.SplitTextCoordinate(secondPossibilities, out int i2, out int j2);
            Grid.SplitTextCoordinate(thirdPossibilities, out int i3, out int j3);


            for (int a = 0; a < 9; a++)
            {
                for (int b = 0; b < 9; b++)
                {
                    string coordinate = a + ";" + b;
                    bool doesCellIntersectFirstCell = IsSameRowColumnOrBlock(coordinate, firstPossibilities);
                    bool doesCellIntersectSecondCell = IsSameRowColumnOrBlock(coordinate, secondPossibilities);
                    bool doesCellIntersectThirdCell = IsSameRowColumnOrBlock(coordinate, thirdPossibilities);

                    if (doesCellIntersectFirstCell && doesCellIntersectSecondCell && doesCellIntersectThirdCell)
                    {
                        ans.Add(coordinate);
                    }
                }
            }

            return ans;
        }
        public void XYZTechnique()
        {
            List<string> pairCoordinates = new List<string>();
            createListOfCellsWithTwoOrThreePossibilities(pairCoordinates);
            for (int i = 0; i < pairCoordinates.Count; i++)
            {
                for (int j = 0; j < pairCoordinates.Count; j++)
                {
                    for (int k = 0; k < pairCoordinates.Count; k++)
                    {

                        var firstPair = pairCoordinates[i];
                        var secondPair = pairCoordinates[j];
                        var thirdPair = pairCoordinates[k];

                        var isXWing = isXYZWing(firstPair, secondPair, thirdPair);

                        List<string> coordinates = new List<string>() { firstPair, secondPair, thirdPair };

                        if (isXWing)

                        {

                            var isXWingGroup = isValidXYZWing(coordinates);


                            if (isXWingGroup)
                            {
                                var pairList = new List<string>() { firstPair, secondPair, thirdPair };
                                var intersect = FindIntersectXYZ(pairList[0], pairList[1], pairList[2]);
                                Grid.SplitTextCoordinate(firstPair, out int x1, out int y1);
                                Grid.SplitTextCoordinate(secondPair, out int x2, out int y2);
                                Grid.SplitTextCoordinate(thirdPair, out int x3, out int y3);
                                Console.WriteLine("PAIR TRIPLE IS " + firstPair + " , " + secondPair + " , " + thirdPair);
                                var firstPossibilities = Grid.Rows[x1].Cells[y1].Possibilities;
                                var secondPossibilities = Grid.Rows[x2].Cells[y2].Possibilities;
                                var thirdPossibilities = Grid.Rows[x3].Cells[y3].Possibilities;
                                var number = findCommonPossibilityXYZ(firstPossibilities, secondPossibilities, thirdPossibilities);
                                if (number != 0)
                                {
                                    Console.WriteLine("NUMBER TO REMOVE " + number + " ");
                                    Grid.RemovePossibilities(intersect, number, "XYZWing");
                                }

                            }
                        }
                    }

                }
            }

        }



    }
}
