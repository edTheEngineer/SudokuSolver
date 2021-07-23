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


            foreach (var x in pairListC)
            {
                Console.WriteLine("[" + x.x1 + "," + x.y1 + "] " + "[" + x.x2 + "," + x.y2 + "]" + x.name + " = " + x.num1 + " + " + x.num2);
            }

            var query = from pairs in pairListC
                        orderby pairs.x1, pairs.x2, pairs.y1, pairs.y2
                        select (pairs.x1, pairs.x2, pairs.y1, pairs.y2, pairs.num1, pairs.num2);
            for(int i =0; i<query.Count()-1; i++)
            
            {
                var first = query.ElementAt(i);
                var second = query.ElementAt(i+1);
                PairC one = new PairC();
                PairC two = new PairC();
                one.x1 = first.x1;
                one.x2 = first.x2;
                one.y1 = first.y1;
                one.y2 = first.y2;

                two.x1 = second.x1;
                two.x2 = second.x2;
                two.y1 = second.y1;
                two.y2 = second.y2;

                var isChain = isNakedPairChain(one, two);
                Console.WriteLine(isChain + "  ");

                if(!isChain)
                {
                    return;
                }
            }

            var p1 = query.First();
            var p2 = query.Last();

            var a = p1.x1 + ";" + p1.y1;
            var b = p2.x2 + ";" + p2.y2;

            var abc = findIntersect(a, b);

            Console.WriteLine(abc + " Intersect");
            removePairs(abc, p1.num1);
            removePairs(abc, p1.num2);
        }

       public void removePairs(string xxx, int num)
        {
           var a= xxx.Split(" ");
            var a1 = a[0].Split(";");
            var a2 = a[1].Split(";");

            Grid.RemovePossibility(Convert.ToInt32(a1[0]), Convert.ToInt32(a1[1]), num);
            Grid.RemovePossibility(Convert.ToInt32(a2[0]), Convert.ToInt32(a2[1]), num);
        }

        public bool commonCheck(int a, int b, int c, int d)
            {
              if(a ==b &&b==c)
            {
                return false;
            }

            if (a == b && b==d)
            {
                return false;
            }

            if (b==c &&c==d && b==d)
            {
                return false;
            }

            return true;
        }
        public bool isNakedPairChain(PairC pairOne, PairC pairTwo)
        {
            var p1 = pairOne.x1 + ";" + pairOne.y1;
            var p2 = pairOne.x2 + ";" + pairOne.y2;
            var p3 = pairTwo.x1 + ";" + pairTwo.y1;
            var p4 = pairTwo.x2 + ";" + pairTwo.y2;

            var p1R = findRow(p1);
            var p1C = findCol(p1);
            var p1B = findCol(p1);

            var p2R = findRow(p2);
            var p2C = findCol(p2);
            var p2B = findCol(p2);

            var p3R = findRow(p3);
            var p3C = findCol(p3);
            var p3B = findCol(p3);

            var p4R = findRow(p4);
            var p4C = findCol(p4);
            var p4B = findCol(p4);

            if(p1 ==p2||p1==p3 ||p1==p4 || p2 ==p3 ||p3==p4 ||p2==p4)
            {

            }

            else
            {
                if (!commonCheck(p1R, p2R, p3R, p4R))
                {
                    Console.WriteLine("3 ROW");
                    return false;
                }

                if (!commonCheck(p1C, p2C, p3C, p4C))
                {
                    Console.WriteLine("3 COL");
                    return false;
                }

                if (!commonCheck(p1B, p2B, p3B, p4B))
                {
                    Console.WriteLine("3 BLOCK");
                    return false;
                }
            }
            

            if (share(p1, p2, p3, p4) == false)
            {
                Console.WriteLine("SHARE FALSE");
                return false;
            }
            if ( p2R ==p3R || p2C ==p3C || p2B==p3B)
            {
                Console.WriteLine("2 and 3");
                return true;
            }

            if (p2R == p4R || p2C == p4C || p2B == p4B)
            {
                Console.WriteLine("2 and 4");
                return true;
            }

            if (p1R == p4R || p1C == p4C || p1B == p4B)
            {
                Console.WriteLine("1 and 4");
                return true;
            }
            
            
            return false;
        }

        public bool share(string a, string b, string c, string d)
        {
            if(a == b || c==d )
            {
                Console.WriteLine("DUPLICATE");
                Console.WriteLine(a + " / " + b + " / " + c + " / " + d);
                return false;
            }

            if(a ==c &&b==d)
            {
                Console.WriteLine("SAME ");
                Console.WriteLine(a + " / " + b + " / " + c + " / " + d);
                return false;
            }

            return true;
        }

        public int findRow(string p1)
        {
            Grid.SplitTextCoordinate(p1, out int i, out int j);
            return i;
        }

        public int findCol(string p1)
        {
            Grid.SplitTextCoordinate(p1, out int i, out int j);
            return j;
        }

        public int findBlock(string p1)
        {
            Grid.SplitTextCoordinate(p1, out int i, out int j);
            var b =Grid.GetBlockFromCoOrdinates(i, j);
            return b;
        }

        public string findIntersect(string p1, string p2)
        {
            Grid.SplitTextCoordinate(p1, out int i1, out int j1);
            Grid.SplitTextCoordinate(p2, out int i2, out int j2);

            if( i1==i2)
            {
                return "row";
            }

            if(j1==j2)
            {
                return "col";
            }

            var b1 = Grid.GetBlockFromCoOrdinates(i1, j1);
            var b2 = Grid.GetBlockFromCoOrdinates(i2, j2);

            if(b1 ==b2)
            {
                return "block";
            }

            var c1 = i1 + ";" + j2;
            var c2 = i2 + ";" + j1;

            return c1 + " " + c2;
        }
    }
}
