using System;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public partial class Technique
    {
        public void Colouring()
        {
            for(int i = 1; i<=9; i++)
            {
               
                ColourWrapWhole(i);
                ColourTrapWhole(i);
            }

        }

        public void ColourWrapWhole(int i)
        {
            var colours = ColourPerNumber(i);
            ColourWrap(colours, i);
            removeColours();
        }

        public void ColourTrapWhole(int i)
        {
            var colours = ColourPerNumber(i);
            colourTrap(colours, i);
            removeColours();
        }
        

        public List<string> ColourPerNumber(int i)
        {
            var list = setConjugatePairs(i);
            //printHiddenPair(list);
            setColours(list, i);
            var colours = findColours(i);
            Console.WriteLine(string.Join(",,,", colours));
            return colours;
            

        }

        public List<string> findColours(int i)
        {
            List<string> colouredCells = new List<string>();
            for (int a = 0; a < 9; a++)
            {
                for (int b = 0; b < 9; b++)
                {
                    var cod = a + ";" + b;
                    if(Grid.Rows[a].Cells[b].Colour!="")
                    {
                        //Console.WriteLine(Grid.Rows[a].Cells[b].Colour + ":" + a + " " + b);
                        colouredCells.Add(a + ";" + b);
                    }
                   
                }
            }

            return colouredCells;
        }

        public bool isOpposingColour(string a, string b)
        {
            var isIntersect = IsIntersect(a, b);
            Grid.SplitTextCoordinate(a, out int x1, out int y1);
            Grid.SplitTextCoordinate(b, out int x2, out int y2);

            var colour1 = Grid.Rows[x1].Cells[y1].Colour;
            var colour2 = Grid.Rows[x2].Cells[y2].Colour;

            var isColourOpposite = ((colour1 == "blue" && colour2 == "green") ||
                (colour2 == "blue" && colour1 == "green")
                ) ;

            return  isColourOpposite;
        }

        public bool isSameColour(string c1, string c2)
        {
            if(c1 ==c2)
            {
                return false;
            }

            Grid.SplitTextCoordinate(c1, out int x1, out int y1);
            Grid.SplitTextCoordinate(c2, out int x2, out int y2);

            var colourA = Grid.Rows[x1].Cells[y1].Colour;
            var colourB = Grid.Rows[x2].Cells[y2].Colour;

            return colourA == colourB;
        }

        public void setAllCells(string colour, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var x = Grid.Rows[i].Cells[j].Colour;
                    if (x == colour)
                    {
                        //Console.WriteLine("REMOVE " + i + ";" + j + " " + x + "");
                        Grid.SetNumber(i, j, num, "ColourWrap");
                    }
                }
            }
        }
        public void removeAllCells(string colour, int num)
        {
            for (int i = 0; i<9; i++)
            {
                for(int j = 0; j<9; j++)
                {
                    var x = Grid.Rows[i].Cells[j].Colour;
                    if (x == colour)
                    {
                        //Console.WriteLine("REMOVE " + i + ";" + j + " " + x + "");
                        Grid.RemovePossibility(i, j, num, "Colouring");
                    }
                }
            }
        }
        public void ColourWrap(List<string> colours, int num)
        {
            for (int i = 0; i < colours.Count; i++)
            {
                for (int j = 0; j < colours.Count; j++)

                {
                    
                    var intersect = (IsIntersect(colours[i], colours[j]));
                    var sameColour = isSameColour(colours[i], colours[j]);
                    if(num ==2)
                    {
                        Console.WriteLine(colours[i] + " " + colours[j] + " " + intersect + " " + sameColour);
                    }
                    
                    if (intersect &&sameColour)
                    {
                        
                        Console.WriteLine(intersect + " " + sameColour);
                        Console.Write("COLOUR WRAP" + colours[i] + " , " + colours[j] + " , ");
                        Grid.SplitTextCoordinate(colours[i], out int x1, out int y1);
                        Grid.SplitTextCoordinate(colours[j], out int x2, out int y2);
                        var colour = Grid.Rows[x1].Cells[y1].Colour;
                        var opposingColour = getColour(Grid.Rows[x1].Cells[y1].Colour);
                        removeAllCells(colour, num);
                        setAllCells(opposingColour, num);
                    }
                }
            }
        }

        public bool intersectTwoColours(List<string> colours, string coordinate)
        {
            List<string> coloursIn = new List<string>();
            foreach(var x in colours)
            {
                if(IsIntersect(x, coordinate))
                {
                    Grid.SplitTextCoordinate(x, out int x1, out int y1);
                    coloursIn.Add(Grid.Rows[x1].Cells[y1].Colour);
                    
                }
            }

            var colours2 = coloursIn.Distinct().ToList();
            return (colours2.Count >= 2);
        }
        public void colourTrap(List<string> colours, int num)
        {
            for(int i = 0; i<9; i++)
            {
                for(int j =0; j<9; j++)
                {
                    var coord = i + ";" + j;

                    var hasColour = Grid.Rows[i].Cells[j].Colour;
                    if (intersectTwoColours(colours, coord) && hasColour=="")
                    {
                        Grid.RemovePossibility(i, j, num, "Colouring");
                    }
                }
            }
        }
        public void removeColours()
        {
            for(int i =0; i<9; i++)
            {
                for(int j = 0; j<9; j++)
                {
                    Grid.SetColour(i, j, "");
                }
            }
        }

        public List<string> findColour(List<string> row, List<string> col, List<string> block)
        {
            List<string> cool = new List<string>();
            foreach(var x in row)
            {
                Grid.SplitTextCoordinate(x, out int a, out int b);

                    var colour = Grid.Rows[a].Cells[b].Colour;
                    if(colour!="")
                    {
                    cool.Add(colour);
                    }
                

            }

            foreach (var x in col)
            {
                Grid.SplitTextCoordinate(x, out int a, out int b);

                var colour = Grid.Columns[a].Cells[b].Colour;
                if (colour != "")
                {
                    cool.Add(colour);
                }


            }

            foreach (var x in block)
            {
                Grid.SplitTextCoordinate(x, out int a, out int b);

                var colour = Grid.Blocks[a].Cells[b].Colour;
                if (colour != "")
                {
                    cool.Add(colour);
                }


            }

            return cool;
        }

        public bool doColoursIntersect(List<string> col)
        {
            var d = col.Distinct().ToList();
            return d.Count == 2;

        

            
        }
        public void intersectColours(string coordinate, int number)
        {
            Grid.SplitTextCoordinate(coordinate, out int x, out int y);
            GetIntersectingCellLists(x, y, true, out List<string> blocks,out  List<string> columns, out List<string> rows);
            Console.WriteLine("----");
            Console.WriteLine(string.Join(",", rows));
            Console.WriteLine(string.Join(".", columns));
            Console.WriteLine(string.Join("*", blocks));
            var colours = findColour(rows, columns, blocks);
            var distinctColours = colours.Distinct().ToList();

            var isIntersect = doColoursIntersect(colours);
            if(isIntersect)
            {
              // Console.WriteLine("REMOVE " + number + " from " +coordinate);
                Grid.RemovePossibility(x, y, number , "Colouring");

            }

            

        }
        public string getColour(string colour)
        {
            var m1 = "blue";
            var m2 = "green";

            if(colour ==m1)
            {
                return m2;
            }

            if(colour ==m2)
            {
                return m1;
            }

            return colour;
        }
        public void setInverseColour(HiddenPair a)
        {
            var c1 = Grid.Rows[a.x1].Cells[a.y1].Colour;

            var c2 = Grid.Rows[a.x2].Cells[a.y2].Colour;

            if (c1 =="" && c2 == "")
            {
                //Console.WriteLine("HERE a" + c1 + " " + c2);
                return;
            }

            if (c1!="" & c2!="")
            {
                //Console.WriteLine("HERE b" + c1 + " " + c2);
                return;
            }


            if (c1 == "")
            {
                string col = getColour(c2);
                //Console.WriteLine("no C1" +a.x1 + " " + a.y1 + " " + col);
                Grid.SetColour(a.x1, a.y1, col);
            }

            if (c2 == "")
            {
                string col = getColour(c1);
                //Console.WriteLine("no C2" + a.x2 + " " + a.y2 + " " + col);
                Grid.SetColour(a.x2, a.y2, col);
            }
        }

        public void setInverseColours(string p1, string p2)
        {
            if (p1==p2)
            {
                //Console.WriteLine("SAME STRING");
                return;
            }
            Grid.SplitTextCoordinate(p1, out int x1, out int y1);
            Grid.SplitTextCoordinate(p2, out int x2, out int y2);
            var c1 = Grid.Rows[x1].Cells[y1].Colour;

            var c2 = Grid.Rows[x2].Cells[y2].Colour;
            
            if (c1 == "" && c2 == "")
            {
                //Console.WriteLine("No Colour can be set" + p1  + " " +p2);
                return;
            }

            if (c1 != "" & c2 != "")
            {
                //Console.WriteLine("Both Colours Set" + p1 + " " + p2);
                return;
            }


            if (c1 == "")
            {
                string col = getColour(c2);

                if(IsIntersect(p1, p2))
                {
                    //Console.WriteLine("SET " + p1 + " " + col + " as " + p2 + " is " + c2);
                    Grid.SetColour(x1, y1, col);
                }
                
            }

            if (c2 == "")
            {
                string col = getColour(c1);
                //Console.WriteLine("no C2" + a.x2 + " " + a.y2 + " " + col);
                if(IsIntersect(p1, p2))
                {
                    //Console.WriteLine("SET " + p2 + " " + col + " as " + p1+ " is " + c1);
                    Grid.SetColour(x2, y2, col);
                }
                
            }
        }
        
        public void setInverseColours(string p1, string p2, string p3, string p4)
        {
            setInverseColours(p1, p2);
            setInverseColours(p3, p4);
            setInverseColours(p1, p3);
            setInverseColours(p1, p4);
            setInverseColours(p2, p3);
            setInverseColours(p2, p4);
            
           
        }

        public void setInverseColour(HiddenPair a, HiddenPair b)
        {
            var pair1 = a.x1 + ";" + a.y1;
            var pair2 = a.x2 + ";" + a.y2;
            var pair3 = b.x1 + ";" + b.y1;
            var pair4 = b.x2 + ";" + b.y2;

            if(pair1==pair3 || pair1 ==pair4 ||pair2 ==pair3 ||pair2 ==pair4)
            {
                setInverseColours(pair1, pair2, pair3, pair4);
            }
            


        }

        public void printHiddenPair(List<HiddenPair> listIn)
        {
            foreach (var a in listIn)
            {
                string c1 = a.x1 + ";" + a.y1;
                string c2 = a.x2 + ";" + a.y2;
                string printString = a.Name + ": " + "( " + a.Number + " ) " + c1 + " , " + c2 + " , " + a.Number;
                Console.WriteLine(printString);
            }
        }

       
        public List<HiddenPair> filter(List<HiddenPair> listIn, string coordinate)
        {
            var ans = new List<HiddenPair>();

            Grid.SplitTextCoordinate(coordinate, out int x1, out int y1);

            foreach(var x in listIn)

            {
                if((x.x1 ==x1 &&x.y1 ==y1) || (x.x2 == x1 && x.y2 == y1))
                {
                    ans.Add(x);
                }
            }
            return ans;
        }

        public List<string> getStartPoints(List<HiddenPair> hpIn)
        {

            List<string> hp = new List<string>();

            foreach(var x in hpIn)
            {
                int b1 = Grid.GetBlockFromCoOrdinates(x.x1, x.y1);
                int b2 = Grid.GetBlockFromCoOrdinates(x.x2, x.y2);
                hp.Add(b1+"/"+x.x1 + ";" + x.y1);
                hp.Add(b2+"/"+x.x2 + ";" + x.y2);
            }

            var GroupByQS = from std in hp
                            
                            group std by std into stdGroup
                            orderby stdGroup.Key 
                            
                            select new
                            {
                                Key = stdGroup.Key,
                               
                            };

            List<string> xx = new List<string>();

            foreach(var a in GroupByQS)
            {
                xx.Add(a.Key);
            }

            List<string> ans = new List<string>();

            foreach(var xxx in xx)
            {
                var toAdd = xxx.Substring(2);
                ans.Add(toAdd);
            }

            return ans;
        }

        public void removeColourClash(List<string> pairs, string currentCoordinate)
        {
            
            Grid.SplitTextCoordinate(currentCoordinate, out int x, out int y);

            foreach(var a in pairs)
            {
               foreach(var X in pairs)
                {
                    setInverseColours(a, X);
                }

            }
        }
        public void setColours(List<HiddenPair> listIn, int i)
        {
            if(listIn.Count==0)
            {
                return;
            }

                var firstList = getStartPoints(listIn);
                //Console.WriteLine(string.Join("**", firstList));
                var first = firstList[0];
                var firstColour = "green";
                Grid.SplitTextCoordinate(first, out int x1, out int y1);
                Grid.SetColour(x1, y1, firstColour);
                        
                foreach (var d in listIn)
                {

                foreach(var e in listIn)
                {
                    setInverseColour(d, e);
                }
                

                }

            

        }
        public List<HiddenPair> convertToRows(List<HiddenPair> listIn)
        {
            var ans = new List<HiddenPair>() { };

            foreach(var x in listIn)
            {
                if(x.Name ==Grid.ROW)
                {
                    var d = x;
                    d.Name = "FINAL";
                    d.Number = x.Number;
                    ans.Add(d);

                }

                if (x.Name == Grid.COLUMNS)
                {
                    var d = new HiddenPair();
                    d.Name = "FINAL";
                    Grid.ColumnToMain(x.x1, x.y1, out d.x1, out d.y1);
                    Grid.ColumnToMain(x.x2, x.y2, out d.x2, out d.y2);
                    d.Number = x.Number;
                    ans.Add(d);
                }

                if (x.Name == Grid.BLOCKS)
                {
                    var d = new HiddenPair();
                    d.Name = "FINAL";
                    Grid.BlockToMain(x.x1, x.y1, out d.x1, out d.y1);
                    Grid.BlockToMain(x.x2, x.y2, out d.x2, out d.y2);
                    
                    d.Number = x.Number;
                    ans.Add(d);
                }
            }

            var distinctAns = ans.Distinct();
            return distinctAns.ToList();
        }
       public List<HiddenPair> setConjugatePairs(int x)
        {
            List<string> ans = new List<string>();
            pairList = new List<HiddenPair>();
            
            CountPossibilitiesPerNumber(x);
           // Console.WriteLine("INITIAL");
            //printHiddenPair(pairList);
            var final = convertToRows(pairList);
           
           
            return final;
        }
    }
}
