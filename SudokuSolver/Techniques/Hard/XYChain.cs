using System;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{

    
    public partial class Technique
    {
        //arr[] input array
        //data[] temp array tp store combp
        //index current index aray
        //size combo  
        public char CoordinateToAsciiChar(string x)
        {
            Grid.SplitTextCoordinate(x, out int i, out int y);
           var yy = Grid.Get1DIndex(i, y);
            yy += 33;
            char charData;
            // 98 is the ascii value for b
            charData = (char)yy;
            // This will display c


            return charData;

        }

        public string ASCIICharToCoordinate(char xxx)
        {
           
            int d = (int)(xxx);

            d -= 32;

            Grid.GetCoOrdinatesOfCell(d, out int x, out int y);

            return x + ";" + y;
        }
        public List<string> xyc { get; set; } = new List<string>();

        public List<List<string>> xycChain { get; set; } = new List<List<string>>();
        public void CombinationsPermutations(string s, int count)
        {
            foreach (var combo in Iterator.Combinations(
    s.ToCharArray().ToList(),
    count))
            {
                foreach (var permu in Iterator.Permutations(combo, count))
                {
                    string r = new string(permu.Take(count).ToArray());
                    //Console.Write("{0,-8}", r);
                    xyc.Add(r);
                }
            }
           // Console.WriteLine("----");

        }

       
        public void combinationUtil(string[] arr, int n, int r, int index, string [] data, int i)
        {
            if (index == r)
            //current combo print it
            {

                for (int j = 0; j < r; j++)
                    Console.Write(data[j] + " ");//No brces first statement belongs to body
                    Console.WriteLine("--");
                    if (isXYChain(data.ToList()))
                    {
                    xycChain.Add(data.ToList());
                      
                    }

                return;

            }
                if (i >= n)
                    return;//When no more elmeents to put ithe data

                // curent included, put next at next location
                 data[index] = arr[i];
                combinationUtil(arr, n, r, index + 1, data, i + 1);


            //current eccluded, replace next, i+1 is passed, index not changed

           
                combinationUtil(arr, n, r, index, data, i + 1);


            
        }

        //main function prints all ocmbo size r in arr [] of sieze n

        public void printCombination (string[] arr, int n, int r)
        {
           string[] data =new string[r];//te,p array tp stpre all combination one on r
            combinationUtil(arr, n, r, 0, data, 0);//print all combination using tmp array datat
        }

        public  IEnumerable<T []> Combinations<T> (IEnumerable<T> source)
        {
            if (null == source)
                throw new ArgumentNullException(nameof (source));
            
            T[] data = source.ToArray();

            var list = new List<int> { 1, 2, 3, 4, 56 };
            
            return Enumerable
                .Range(3, (3 << data.Length)-1)
                .Select(index => data
                .Where((v, i ) => (index &( 3<<i)) !=0)
                .ToArray());

           
        }
        public bool isXYChain(List<string> listIn)
        {
            if(listIn.Count<3)
            {
                return false;
            }
            ListHandling l = new ListHandling();
            List<string> ans = new List<string>();
            for(int i = 0; i< listIn.Count; i++)
            {
                var first = listIn[i];

                if(!l.CanAppend(ans, first))
                {
                    return false;
                }

                if(i <listIn.Count-1)
                {
                    var check = listIn[i];
                    var check2 = listIn[i + 1];

                    Grid.SplitTextCoordinate(check, out int x1, out int y1);
                    Grid.SplitTextCoordinate(check2, out int x2, out int y2);
                    var p1 = Grid.Rows[x1].Cells[y1].Possibilities;
                    var p2 = Grid.Rows[x2].Cells[y2].Possibilities;


                    if (!SharePossibilitiesTwo(p1, p2))
                    {
                        return false;
                    }
                }

                ans.Add(first);
            }

            var c = listIn.Count;
            if (canStartEnd(listIn[0], listIn[c - 1]))
            {
                return true;
            }

            {
                return false;
            }

        }

         public  void driverDo(int max)
        {

            var arr =getNakedPairs();
            int r = max;
            int n = arr.Count;
            printCombination(arr.ToArray(), n, r);
        }
        private static void CombinationsOverIntegers()
        {
            List<int> l = new List<int>() { 1, 2, 3, 4, 5, 6 };
            int count = 4;
            foreach (var comb in Iterator.Combinations(l, count))
            {
                string s = comb.Take(count).Aggregate<int, string>("", (x, y) => x + y);
                Console.Write("{0,-8}", s);
            }
            Console.WriteLine();
        }

        public List<string> ASCCIListToCoordinateList(List<string> iiii)
        {
            List<string> ans = new List<string>();
            foreach(var x in iiii)
            {
                var value = "";
                foreach(var y in x)
                {
                    var fc = ASCIICharToCoordinate(y);
                    value += fc;
                }

                ans.Add(value);
                
            }

            return ans;
        }

        public List<string> chaininfy(string chain)
        {
            List<string> ans = new List<string>();
            for (int i = 0; i < chain.Length - 2; i+=3)
            {
                string x = chain[i] +""+chain[i + 1] +chain[i + 2];
                ans.Add(x);
            }


            return ans;
        }
        public void XYChain()
        {
            var x = getNakedPairs();
             var permutationStrings = listify(x);
             CombinationsPermutations(permutationStrings, 4);
            var ccc = ASCCIListToCoordinateList(xyc);
            var distinctChain = ccc.Distinct();
            
            //Console.WriteLine("COMBOS OF 4 " + xyc.Count);

            
           
                foreach(var chain in distinctChain)
                {

                var chained = chaininfy(chain);
                 if (isXYChain(chained))
                    {
                    var first = chained.ElementAt(0).ToString();
                    var last = chained.ElementAt(chained.Count() - 1).ToString();
                    
                    Grid.SplitTextCoordinate(first, out int xx1, out int yy1);
                    Grid.SplitTextCoordinate(last, out int xx2, out int yy2);
                    var p1 = Grid.Rows[xx1].Cells[yy1].Possibilities;
                    var p2 = Grid.Rows[xx2].Cells[yy2].Possibilities;
                    var c = findCommonPossibility(p1, p2);

                    if(c!=0)
                    {
                        Console.WriteLine(string.Join("~", chaininfy(chain)) + " REMOVE " + c);
                        var intersect = FindIntersect(first, last);
                        Grid.RemovePossibilities(intersect, c, "XYChain");
                    }
                    
                }
                
                }
               
           
             
           
        }
        public struct XYC
        {
            public string coordinate { get; set; }
            public int row { get; set; }
          public  int col{ get; set; }
       public int block { get; set; }

            public List<int> poss { get; set; }

        }

        public List<XYC> xycList = new List<XYC>();

        public bool IsCommonCoordinatesRC(int x1, int y1, int x2, int y2)

        {
            var isRow = y1 == y2;
            var isCol = x1 == x2;
            var block1 = Grid.GetBlockFromCoOrdinates(x1, y1);
            var block2 = Grid.GetBlockFromCoOrdinates(x2, y2);
            var isBlock = block1 == block2;

            return (isRow ||isBlock || isCol );
        } 
        public bool canStartEnd(string a, string b)
        {
            if(a ==b)
            {
                return false;
            }

            Grid.SplitTextCoordinate(a, out int x1, out int y1);
            Grid.SplitTextCoordinate(b, out int x2, out int y2);



           if( IsCommonCoordinatesRC(x1, y1, x2, y2))
            {
                return false;
            }

            var p1 = Grid.Rows[x1].Cells[y1].Possibilities;
            var p2 = Grid.Rows[x2].Cells[y2].Possibilities;

            if (SharePossibilitiesTwo(p1, p2))
            {
                
                return true;
            }
            return false;
        }

        public bool SharePossibilitiesTwo(List<int> possibilityListOne, List<int> possibilityListTwo)
        {

            List<int> all = new List<int>();
            all.AddRange(possibilityListOne);
            all.AddRange(possibilityListTwo);

            var d = all.Distinct();

            if(d.Count() ==4)
            {
                return false;
            }
            return true;
        }

        public bool share(string a, string b)
        {
            Grid.SplitTextCoordinate(a, out int x1, out int y1);
            Grid.SplitTextCoordinate(b, out int x2, out int y2);

            return IsCommonCoordinates(x1, y1, x2, y2);
        }


        private void Old2()
        {
            var uniqueList = getNakedPairs();
            Console.WriteLine(string.Join("=", uniqueList));
            List<string> start = new List<string>();
            List<string> end = new List<string>();
            bool isShare = false;
            for (int i = 0; i < uniqueList.Count; i++)
            {
                isShare = false;
                for (int j = 0; j < uniqueList.Count; j++)
                {
                    var c1 = uniqueList[i];
                    var c2 = uniqueList[j];

                    if (canStartEnd(c1, c2))
                    {
                        start.Add(c1);
                        end.Add(c2);
                    }

                    if (share(c1, c2))
                    {
                        isShare = true;
                    }
                }

                if (isShare = false)
                {
                    Console.WriteLine(i + "NO SHAREY");
                }
            }



            foreach (var x in start)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("----");
            foreach (var x in end)
            {
                Console.WriteLine(x);
            }
        }

        private void Old(List<string> uniqueList)
        {
            foreach (var x in uniqueList)
            {
                getV(x, out int row, out int col, out int block);
                XYC ed = new XYC();
                ed.row = row;
                ed.col = col;
                ed.block = block;
                ed.coordinate = x;
                ed.poss = Grid.Rows[row].Cells[col].Possibilities;
                xycList.Add(ed);

            }

            var rowSort = from a in xycList
                          orderby a.row
                          select a;

            var colSort = from a in xycList
                          orderby a.col
                          select a;

            var blockSort = from a in xycList
                            orderby a.block
                            select a;


            foreach (var x in rowSort)
            {
                Console.WriteLine(x.coordinate + " " + x.row + " " + x.col + " " + x.block + string.Join("~", x.poss));
            }

            Console.WriteLine("---");
            foreach (var x in colSort)
            {
                Console.WriteLine(x.coordinate + " " + x.row + " " + x.col + " " + x.block);
            }
            Console.WriteLine("----");
            foreach (var x in blockSort)
            {
                Console.WriteLine(x.coordinate + " " + x.row + " " + x.col + " " + x.block);
            }
        }

        public void getV(string coordinate, out int row, out int col, out int block)
        {
            Grid.SplitTextCoordinate(coordinate, out row, out  col);
            block = Grid.GetBlockFromCoOrdinates(row, col);
        }

        static void Ed(string[] args)
        {
            var values = PermutationsWithDuplicates("abc", 3);
            foreach (var permutation in values)
            {
                Console.WriteLine(permutation);
            }
        }

        static IEnumerable<string> PermutationsWithDuplicates(string word, int length)
        {
            if (length == 1) return word.Select(c => c.ToString());
            return PermutationsWithDuplicates(word, length - 1)
                .SelectMany(c => word,
                    (c1, c2) => String.Concat(c1, c2));
        }
        private List<string> FindCoordinatesOfPairs()
        {
            var pairs = getNakedPairs();
            List<string> allPairs = new List<string>();

            foreach (var x in pairs)
            {
                allPairs.Add(x);

            }

            // Console.WriteLine("ALL PAIRS" + allPairs.Count);
            // Console.WriteLine("pairList" + pairListC.Count);
            List<string> uniqueList = allPairs.Distinct().ToList();
            return uniqueList;
        }

        public string listify(List<string> ed)
        {
            var ans = "";
            foreach(var x in ed)
            {
                var c = CoordinateToAsciiChar(x);
                ans += c;
            }

            return ans;
        }
        public List<string> getNakedPairs()
        {
            List<string> ans = new List<string>();
            for(int i = 0; i<9; i++)
            {
                for(int j = 0; j<9; j++)
                {
                    var poss = Grid.Rows[i].Cells[j].Possibilities;

                    if(poss.Count ==2)
                    {
                        ans.Add(i + ";" + j);
                    }
                }
            }

     
        
            return ans;
        }
}
}
