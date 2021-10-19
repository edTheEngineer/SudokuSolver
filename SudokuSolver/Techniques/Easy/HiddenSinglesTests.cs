using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.Techniques;

namespace RazorPagesSudokuTests.SudokuSolver.Techniques.Easy
{
    [TestClass()]
    public class HiddenSinglesTests

        
    {
        //BEFORE
        public int[,] HiddenSinglesSampleDoc { get; set; }

        public int[,] HiddenSinglesSite { get; set; }

        public int[,] HiddenSinglesRow { get; set; }

        public int[,] HiddenSinglesCol { get; set; }

        public int[,] HiddenSinglesBlock { get; set; }

        //After

        public int[,] HiddenSinglesSampleDocAfter { get; set; }

        public int[,] HiddenSinglesSiteAfter { get; set; }

        public int[,] HiddenSinglesRowAfter { get; set; }

        public int[,] HiddenSinglesColAfter { get; set; }

        public int[,] HiddenSinglesBlockAfter { get; set; }

        public int[,] HiddenSinglesLiveBefore { get; set; }

        public int[,] HiddenSinglesLiveAfter { get; set; }

        public int[,] HiddenSinglesLiveBefore2 { get; set; }

        public int[,] HiddenSinglesLiveAfter2 { get; set; }

        public int[,] BlockTest { get; set; }

        public int[,] BlockInteraction { get; set; }
        public HiddenSinglesTests()
        {
            HiddenSinglesSampleDoc = new [,]
                     {
                 {  2,7,8,0,0,0,0,0,0},
                 {  0,0,6,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  1,4,0,0,0,0,0,0,0},
                 {  3,0,0,0,0,0,0,0,0},
                 {  4,0,0,0,0,0,0,0,0},
                 {  6,0,0,0,0,0,0,0,0},
                 {  8,0,0,0,0,0,0,0,0},
                 {  7,0,0,0,0,0,0,0,0}
                     };

            HiddenSinglesSampleDocAfter = new[,]
         {
                 {  2,7,8,0,0,0,0,0,0},
                 {  0,0,6,0,0,0,0,0,0},
                 {  0,0,4,0,0,0,0,0,0},
                 {  1,4,0,0,0,0,0,0,0},
                 {  3,0,0,0,0,0,0,0,0},
                 {  4,0,0,0,0,0,0,0,0},
                 {  6,0,0,0,0,0,0,0,0},
                 {  8,0,0,0,0,0,0,0,0},
                 {  7,0,0,0,0,0,0,0,0}
         };

            HiddenSinglesSite = new[,]
         {
                 {  0,0,0,0,0,0,0,0,2},
                 {  0,0,0,0,9,5,4,0,0},
                 {  0,0,6,8,0,0,0,0,0},
                 {  0,8,5,0,2,0,9,4,1},
                 {  0,0,0,1,0,9,7,3,8},
                 {  1,0,0,0,0,0,2,5,6},
                 {  8,9,3,0,1,0,0,0,0},
                 {  0,0,0,9,0,0,0,0,4},
                 {  0,0,7,6,0,0,3,0,0}
         };

            HiddenSinglesSiteAfter = new[,]
         {
                 {  0,0,0,0,6,0,0,0,2},
                 {  0,0,8,0,9,5,4,6,0},
                 {  0,0,6,8,0,0,0,0,0},
                 {  0,8,5,0,2,6,9,4,1},
                 {  0,0,0,1,5,9,7,3,8},
                 {  1,0,9,0,0,0,2,5,6},
                 {  8,9,3,5,1,4,6,0,0},
                 {  0,0,0,9,0,0,0,0,4},
                 {  0,0,7,6,0,0,3,0,0}
         };

            HiddenSinglesLiveAfter = new[,]
{
                 {  9,6,4,3,0,0,7,5,8},
                 {  8,0,0,9,0,4,3,1,0},
                 {  1,0,0,5,0,7,0,6,0},
                 {  4,3,9,0,5,8,1,7,6},
                 {  2,1,6,7,9,3,0,8,5},
                 {  7,5,8,0,0,0,0,3,0},
                 {  5,9,7,6,3,2,8,4,1 },
                 {  3,8,2,1,4,5,6,9,7 },
                 {  6,4,1,8,7,9,5,2,3}
};

            HiddenSinglesLiveBefore = new[,]
{
                  {  9,6,4,0,0,0,7,0,8},
                 {  8,0,0,0,0,4,3,0,0},
                 {  1,0,0,5,0,0,0,0,0},
                 {  0,0,0,0,0,0,1,7,6},
                 {  2,0,0,0,9,3,0,0,5},
                 {  7,0,8,0,0,0,0,0,0},
                 {  0,0,7,0,3,2,0,4,0 },
                 {  3,8,2,1,0,5,6,0,0 },
                 {  0,4,1,0,0,9,5,2,0}
};

            HiddenSinglesLiveBefore2 = new[,]
            {
                 {  0,0,0,0,2,0,0,7,4},
                 {  0,0,8,3,9,0,0,0,2},
                 {  0,0,0,0,0,0,0,0,0},
                 {  3,7,4,6,1,0,0,9,0 },
                 {  0,1,9,0,0,7,0,0,0},
                 {  0,6,0,0,0,0,0,5,0 },
                 {  0,0,0,0,0,0,0,1,0 },
                 {  0,0,0,5,0,0,3,0,0},
                 {  0,0,3,0,6,0,4,0,0}
};

            HiddenSinglesLiveAfter2 = new [,]
{
                 {  0,3,0,0,2,0,0,7,4},
                 {  7,0,8,3,9,0,0,0,2},
                 {  0,0,0,0,5,0,0,3,0},
                 {  3,7,4,6,1,5,0,9,0 },
                 {  5,1,9,0,0,7,0,4,0},
                 {  8,6,0,0,0,0,0,5,0 },
                 {  0,0,0,0,0,0,0,1,0 },
                 {  0,0,0,5,0,0,3,0,0},
                 {  0,0,3,0,6,0,4,0,0}
};

            HiddenSinglesRow =new [,]
{
                 {  1,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0 },
                 {  0,1,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,1,0,0,0,0,0 },
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,1,0}
};

            HiddenSinglesRowAfter = new[,]
{
                 {  1,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0 },
                 {  0,1,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,1,0,0,0,0,0 },
                 {  0,0,1,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,1,0}
};

            HiddenSinglesCol = new[,]
{
                 {  0,0,0,0,0,0,0,5,0}, 
                 {  1,6,0,9,0,0,0,0,0},
                 {  0,0,9,0,6,4,0,0,0},
                 {  0,0,0,0,0,0,0,0,4 },
                 {  4,0,0,0,2,0,1,0,0},
                 {  0,0,0,3,0,0,0,0,0},
                 {  0,0,2,0,8,9,0,0,0 },
                 {  0,2,0,2,5,0,0,3,0},
                 {  7,0,0,1,0,0,0,0,9}
};

            HiddenSinglesColAfter = new[,]
{
                 {  0,0,0,0,0,0,9,5,6},
                 {  1,6,0,9,0,0,0,0,0},
                 {  0,0,9,0,6,4,0,0,0},
                 {  0,0,0,0,9,0,0,0,4 },
                 {  4,0,0,0,2,0,1,0,0},
                 {  0,0,0,3,4,0,0,0,0},
                 {  0,0,2,4,8,9,0,0,0 },
                 {  9,2,0,2,5,7,0,3,0},
                 {  7,0,0,1,0,0,0,0,9}
};

            HiddenSinglesBlock = new[,]
{
                 {  0,2,8,0,0,7,0,0,0},
                 {  0,1,6,0,8,3,0,7,0},
                 {  0,0,0,0,2,0,8,5,1},
                 {  1,3,7,2,9,0,0,0,0},
                 {  0,0,0,7,3,0,0,0,0},
                 {  0,0,0,0,4,6,3,0,7},
                 {  2,9,0,0,7,0,0,0,0 },
                 {  0,0,0,8,6,0,1,4,0},
                 {  0,0,0,3,0,0,7,0,0}
};

            HiddenSinglesBlockAfter = new[,]
{

                 {  0,2,8,0,0,7,0,0,0},
                 {  0,1,6,0,8,3,0,7,0},
                 {  0,0,0,6,2,0,8,5,1},
                 {  1 ,3,7,2,9,0,0,0,0},
                 {  0,0,0,7,3,0,0,0,0},
                 {  0,0,0,0,4,6,3,0,7},
                 {  2,9,0,0,7,0,0,0,0 },
                 {  0,0,0,8,6,0,1,4,0},
                 {  0,0,0,3,0,0,7,0,0}
};

            BlockTest = new[,]
{

                 {  0,1,2,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,6,7,0},
                 {  0,3,0,0,0,0,0,0,0},
                 {  0,4,0,0,0,0,0,0,0},
                 {  0,5,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0}
};

            BlockInteraction = new[,]
{
                 { 0,0,0,0,0,0,0,0,1 },
                 { 0,3,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 2,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,4,1,0,0,0,0},
                 { 0,0,0,5,6,0,0,0,0 },
                 { 0,0,0,7,8,3,0,0,0}
};


        }

        [TestMethod()]



        public void HiddenSinglesSampleDocTest()

        {
            Technique t = new Technique(HiddenSinglesSampleDoc);
            t.HiddenSingles();
            var actual = t.SudokuGrid;
            var expected = HiddenSinglesSampleDocAfter;
            for(int i = 0; i<9; i++)
            {
                for(int j = 0; j<9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }

            
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void HiddenSinglesSiteTest()

        {
            Technique t = new Technique(HiddenSinglesSite);
            t.HiddenSingles();
            var actual = t.SudokuGrid;
            var expected = HiddenSinglesSiteAfter;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void HiddenSinglesLiveTest()

        {
           // Technique t = new Technique(HiddenSinglesLiveBefore); 
           Technique t = new Technique(HiddenSinglesLiveBefore);
           t.HiddenSingles();
            var actual = t.SudokuGrid;
            var expected = HiddenSinglesLiveAfter;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
           
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void HiddenSinglesLive2Test()

        {
            Technique t = new Technique(HiddenSinglesLiveBefore2);
            t.HiddenSingles();
            var actual = t.SudokuGrid;
            var expected = HiddenSinglesLiveAfter2;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
           
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void HiddenSinglesRowTest()

        {
            Technique t = new Technique(HiddenSinglesRow);
            t.HiddenSingles();
            var actual = t.SudokuGrid;
            var expected = HiddenSinglesRowAfter;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }

           
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void HiddenSinglesColTest()

        {
            Technique t = new Technique(HiddenSinglesCol);
            t.HiddenSingles();
            var actual = t.SudokuGrid;
            var expected = HiddenSinglesColAfter;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void HiddenSinglesBlockTest()

        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.HiddenSingles();
            var actual = t.SudokuGrid;
            var expected = HiddenSinglesBlockAfter;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
           
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]

        public void CorrectGroupRow0()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Rows[0]);
            var expected = new List<int>
            {
                3,4,5,9,1,4,5,6,9,1,5,4,6,9,3,6,9,3,4,6,9
           };
            foreach(var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectRows1()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Rows[1]);
            var expected = new List<int>
            {
                4,5,9,4,5,9,2,4,9,2,4,9
            };
            foreach (var x in actual)
            {
                Console.Write(x) ;
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectGroupRows2()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Rows[2]);
            var expected = new List<int>
            {
                3,4,7,9,4,7,3,4,9,4,6,9,4,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectGroupRows3()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Rows[3]);
            var expected = new List<int>
            {
                5,8,4,5,6,6,8,4,5,6,8
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectRows4()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Rows[4]);
            var expected = new List<int>
            {
                4,5,6,8,9,4,5,6,8,2,4,5,9,1,5,8,2,4,5,6,9,1,2,6,8,9,2,4,5,6,8,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectRows5()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Rows[5]);
            var expected = new List<int>
            {
               5,8,9,5,8,2,5,9,1,5,1,2,8,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectRows6()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Rows[6]);
            var expected = new List<int>
            {
                1,3,4,5,1,4,5,1,4,5,5,6,3,6,8,3,5,6,8
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectRows7()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Rows[7]);
            var expected = new List<int>
            {
                3,5,7,5,7,3,5,2,5,9,2,3,5,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void Rows8()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Rows[8]);
            var expected = new List<int>
            {
                4,5,6,8,4,5,6,8,1,4,5,1,5,1,2,4,5,9,2,6,8,9,2,5,6,8,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        ////
        ///
        [TestMethod]

        public void CorrectGroupColumns0()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Columns[0]);
            var expected = new List<int>
            {
                3,4,5,9,4,5,9,3,4,7,9,4,5,6,8,9,5,8,9,3,5,7,4,5,6,8
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectColumns1()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Columns[1]);
            var expected = new List<int>
            {
                4,7,4,5,6,8,5,8,5,7,4,5,6,8
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectGroupColumns2()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Columns[2]);
            var expected = new List<int>
            {
                3,4,9,2,4,5,9,2,5,9,1,3,4,5,3,5,1,4,5
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectGroupColumns3()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Columns[3]);
            var expected = new List<int>
            {
               1,4,5,6,9,4,5,9,4,6,9,1,5,1,4,5
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectColumns4()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Columns[4]);
            var expected = new List<int>
            {
                1,5,1,5
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectColumns5()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Columns[5]);
            var expected = new List<int>
            {
                4,9,5,8,1,5,8,1,4,5,2,5,9,1,2,4,5,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectColumns6()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Columns[6]);
            var expected = new List<int>
            {
                4,6,9,2,4,9,4,5,6,2,4,5,6,9,5,6
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectColumns7()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Columns[7]);
            var expected = new List<int>
            {
                3,6,9,6,8,1,2,6,8,9,1,2,8,9,3,6,8,2,6,8,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void Columns8()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Columns[8]);
            var expected = new List<int>
            {
               3,4,6,9,2,4,9,4,5,6,8,2,4,5,6,8,9,3,5,6,8,2,3,5,9,2,5,6,8,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        /// [TestMethod]

        public void CorrectGroupBlocks0()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            var expected = new List<int>
            {
                3,4,5,9,4,5,9,3,4,7,9,4,7,3,4,9
                //4//1//0//45//0//0//47//349//34579//
            };
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Blocks[0]);
            
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectBlocks1()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Blocks[1]);
            var expected = new List<int>
            {
              1,4,5,6,9,1,5,4,5,9,4,6,9,4,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectGroupBlocks2()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            //t.removePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Blocks[2]);
            var expected = new List<int>
            {
                4,6,9,3,6,9,3,4,6,9,2,4,9,2,4,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectGroupBlocks3()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Blocks[3]);
            var expected = new List<int>
            {
                4,5,6,8,9,4,5,6,8,2,4,5,9,5,8,9,5,8,2,5,9
                //4568/245924568958259245689
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectBlocks4()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Blocks[4]);
            var expected = new List<int>
            {
                5,8,1,5,8,1,5
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectBlocks5()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Blocks[5]);
            var expected = new List<int>
            {
                4,5,6,6,8,4,5,6,8,2,4,5,6,9,1,2,6,8,9,2,4,5,6,8,9,1,2,8,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectBlocks6()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Blocks[6]);
            var expected = new List<int>
            {
                1,3,4,5,3,5,7,5,7,3,5,4,5,6,8, 4,5,6,8,1,4,5
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void CorrectBlocks7()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Blocks[7]);
            var expected = new List<int>
            {
                1,4,5,1,4,5,2,5,9,1,5,1,2,4,5,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void Blocks8()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Blocks[8]);
            var expected = new List<int>
            {
                5,6,3,6,8,3,5,6,8,2,3,5,9,2,6,8,9,2,5,6,8,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void Blocks0()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Blocks[0]);
            var expected = new List<int>
            {
                3,4,5,9,4,5,9,3,4,7,9,4,7,3,4,9
              //4,4,5,4,7,3,4,9,3,4,5,7,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void IsHiddenSingle()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.IsHiddenSingleInGroup(t.Grid.Rows[2], 6);
            Assert.AreEqual(true, actual);
        }

        [TestMethod]

        public void BlockTestPossibilitiesAll()
        {
            Technique t = new Technique(BlockTest);
            t.Grid.RemovePossibilitiesFromIntersectingCells();

            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Blocks[0]);
            var expected = new List<int>
            {

3,4,5,6,7,8,9,
3,4,5,6,7,8,9,
6,7,8,9,
3,4,5,6,7,8,9,
3,4,5,8,9,
8,9,
3,4,5,8,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void BlockInteractionsAll()
        {
            Technique t = new Technique(BlockTest);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Blocks[0].Cells[7].Possibilities;
            List<int> expected = new List<int>
            {
                8,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void RemoveInteractions()
        {
            Technique t = new Technique(BlockTest);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Blocks[0].Cells[7].Possibilities;
            var expected = new List<int>
            {
                8,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void CheckBlockBlank()

        {
            Technique t = new Technique(BlockInteraction);
            List<int> expected = new List<int>() { 4, 5, 6, 7, 8, 9 };
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Blocks[0].Cells[0].Possibilities;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]

        public void CheckBlocks80()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Blocks[8].Cells[0].Possibilities;
            var expected = new List<int>
            {
                5,6
            };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void CheckBlocks81()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Blocks[8].Cells[1].Possibilities;
            var expected = new List<int>
            {
                3,6,8
            };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void CheckBlocks82()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Blocks[8].Cells[2].Possibilities;
            var expected = new List<int>
            {
                3,5,6,8
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void CheckBlocks83()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Blocks[8].Cells[3].Possibilities;
            var expected = new List<int>();
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void CheckBlocks84()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Blocks[8].Cells[4].Possibilities;
            var expected = new List<int>();
           
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void CheckBlocks85()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Blocks[8].Cells[5].Possibilities;
            var expected = new List<int>
            {
                2,3,5,9
            };
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void checkBlocks86()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Blocks[8].Cells[6].Possibilities;
            var expected = new List<int>();
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void CheckBlocks87()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Blocks[8].Cells[7].Possibilities;
            var expected = new List<int>
            {
                2,6,8,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void CheckBlocks88()
        {
            Technique t = new Technique(HiddenSinglesBlock);
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Blocks[8].Cells[8].Possibilities;
            var expected = new List<int>
            {
                2,5,6,8,9
            };
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}