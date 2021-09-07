using System;
using System.Collections.Generic;
using System.Linq;
using RazorPagesSudoku.SudokuSolver.CoreClasses;
namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {
        public void RemotePairTechnique()
        {
            NakedPairSolve(false);
            var uniqueList = FindCoordinatesOfNakedPairs();
            Console.WriteLine(string.Join("=", uniqueList));
            ListHandling l = new ListHandling();
            var chain = l.FindRemotePairChain(uniqueList);
            var filteredChain = FilterChain(chain);
            foreach (var x in filteredChain)
            {
                var coordinate = x.Split("-").ToList();
                RemoveRemotePairs(coordinate);
            }
        }

        public bool AreSamePossibilities(string [] chain)
        {
            Grid.SplitTextCoordinate(chain[0], out int i, out int j);
            var firstPossibilities = Grid.Rows[i].Cells[j].Possibilities;
            foreach (var x in chain)
            {
                Grid.SplitTextCoordinate(x, out int ii, out int jj);
                var secondPossiblities = Grid.Rows[ii].Cells[jj].Possibilities;
                if (!SamePossiblities(firstPossibilities, secondPossiblities))
                {
                    return false;
                }


            }

            return true;
        }

        public List<string> FilterChain(List<string> chain)
        {
            List<string> answer = new List<string>();
            foreach (var x in chain)
            {
                var chainArray = x.Split("-");
                bool canAddPossibilities = AreSamePossibilities(chainArray);
                if(canAddPossibilities)
                {
                    answer.Add(x);
                }
            }

            foreach(var x in answer)
            {
                Console.WriteLine(x + ", ");
            }
            return answer;
        }
        public bool SamePossiblities(List<int> possibilityListOne, List<int> possibilityListTwo)
        {
            possibilityListOne.Sort();
            possibilityListTwo.Sort();

            if(possibilityListOne.Count !=possibilityListTwo.Count)
            {
                return (false);
            }

            if(possibilityListOne.Count!=2)
            {
                return false;
            }

            if (possibilityListTwo.Count != 2)
            {
                return false;
            }
            for (int i = 0; i<possibilityListOne.Count; i++)
            {
                var one = possibilityListOne[i];
                var two = possibilityListTwo[i];

                if(one !=two)
                {
                    return false;
                }
            }

            return true;
        }
        private void RemoveRemotePairs(List<string> chain)
        {
            int firstChainCount = 0;
            int secondChainCount = 0;
            int one = -1;
            int two = -1;

            ListHandling l = new ListHandling();
            l.SplitRemoteChainList(chain, out List<string> odd, out List<string> even);
            foreach(var first in chain)
            {
                
                foreach(var last in chain)
                {
                    int modFirstChain = firstChainCount % 2;
                    int modSecondChain = secondChainCount % 2;
                    if(first !=last  )
                    
                    {

                        if (modFirstChain != modSecondChain)
                        {

                            Grid.SplitTextCoordinate(first, out int a, out int b);
                            Grid.SplitTextCoordinate(last, out int c, out int d);
                            var possibilityListOne = Grid.Rows[a].Cells[b].Possibilities;
                            var p2 = Grid.Rows[c].Cells[d].Possibilities;
                            if (SamePossiblities(possibilityListOne, p2))
                            {
                                one = possibilityListOne[0];
                                two = p2[1];
                                var intersect = FindIntersect(first, last);

                                if (intersect.Count >= 0)
                                {
                                    Console.WriteLine("REMOVE " + "[" + first + " " + last + "]" + one + " / " + two + " from " + string.Join("@", intersect));
                                    RemoveNumbersFromCoordinates(intersect, one);
                                    RemoveNumbersFromCoordinates(intersect, two);
                                }
                            }
                        }
                        
                    }
                    secondChainCount += 1;
                }
                firstChainCount += 1;
            }
            

            
        }
        private List<string> FindCoordinatesOfNakedPairs()
        {
            List<string> allPairs = new List<string>();

            foreach (var x in pairListC)
            {
                var pair1 = (x.x1 + ";" + x.y1);
                var pair2 = (x.x2 + ";" + x.y2);
                allPairs.Add(pair1);
                allPairs.Add(pair2);
            }

            Console.WriteLine("ALL PAIRS" + allPairs.Count);
            Console.WriteLine("pairList" + pairListC.Count);
            List<string> uniqueList = allPairs.Distinct().ToList();
            return uniqueList;
        }

        public void RemoveNumbersFromCoordinates(List<string> coordinates, int num)
        {
            foreach(var x in coordinates)
            {
                var coordinate = x.Split(";");
                var firstCoordinate = coordinate[0];
                var secondCoordinate = coordinate[1];
                Grid.RemovePossibility(Convert.ToInt32(firstCoordinate), Convert.ToInt32(secondCoordinate), num);
                Grid.RemovePossibility(Convert.ToInt32(firstCoordinate), Convert.ToInt32(firstCoordinate), num);
            }
           
        }

        public bool IsSameRowColumnOrBlock(string x, string y)
        {
            ListHandling L = new ListHandling();
            L.GetRowColumnBlock(x, out int r1, out int c1, out int b1);
            L.GetRowColumnBlock(y, out int r2, out int c2, out int b2);

            if(x ==y)
            {
                return false;
            }

            if( r1 ==r2 || c1==c2 ||b1 ==b2)
            {
                return true;
            }

            return false;
        }
        public List<string> FindIntersect(string p1, string p2)
        {
            List<string> ans = new List<string>();
            Grid.SplitTextCoordinate(p1, out int i1, out int j1);
            Grid.SplitTextCoordinate(p2, out int i2, out int j2);

           
            for(int a = 0; a<9; a++)
            {
                for (int b = 0; b < 9; b++)
                {
                    string x = a + ";" + b;
                    bool aa = IsSameRowColumnOrBlock(x, p1);
                    bool bb = IsSameRowColumnOrBlock(x, p2);

                    if(aa &&bb)
                    {
                        ans.Add(x);
                    }
                }
            }
            var co1 = i1 + ";" + j2;
            var co2 = i2 + ";" + j1;

            return ans;
        }
    }

  
}
