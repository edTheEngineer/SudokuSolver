using System;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.CoreClasses;
using RazorPagesSudoku.SudokuSolver.Techniques;

namespace RazorPagesSudokuTests.SudokuSolver.CoreClasses
{
    [TestClass()]
    public class RemotePairTests
    {
        public int[,] IronMonger { get; set; }
        public int[,] Example { get; set; }
        public int[,] IronMonger2 { get; set; }
        public int[,] Brainbashers1 { get; set; }

        public int[,] Brainbashers2 { get; set; }

        public int[,] Brainbashers3 { get; set; }

        public int[,] SudokuWikiArticle { get; set; }

        public int[,] SudokuZero { get; set; }

        public int[,] Hodoku { get; set; }

        public int[,] Hodoku2 { get; set; }

        public int[,] SySudoku { get; set; }
        public int[,] SySudoku2 { get; set; }

        public int[,] NonRemotePair { get; set; }


        public RemotePairTests()
        {
            Example = new[,]
               {
                 { 0,8,0,0,2,3,4,0,0 },
                 { 6,2,0,4,0,9,5,0,8 },
                 { 4,1,0,0,8,5,0,2,0, },
                 { 0,4,0,9,0,6,0,8,2 },
                 { 0,6,8,5,4,2,0,0,0},
                 { 2,9,0,0,3,8,6,5,4 },
                 { 1,5,4,2,6,7,8,9,3},
                 { 8,7,2,3,9,4,1,6,5},
                 { 9,3,6,8,5,1,2,4,7}
                };

            IronMonger = new[,]
               {
                 { 2,0,0,6,8,1,7,4,0},
                 { 6,8,7,9,4,0,0,1,3},
                 { 4,1,0,0,7,3,0,6,8},
                 { 1,0,0,8,0,6,4,0,7},
                 { 8,0,6,4,0,7,1,0,0},
                 { 5,7,4,0,0,9,8,0,6},
                 { 9,4,1,7,6,0,3,8,0},
                 { 7,5,8,0,0,4,6,0,1},
                 { 3,6,2,0,0,8,0,7,4}
                };

            IronMonger2 = new[,]
                           {
                 { 1,2,3,0,0,7,0,8,9},
                 { 9,8,5,1,0,2,7,3,0},
                 { 7,4,6,3,8,9,1,2,5 },
                 { 0,3,1,9,7,5,2,0,8},
                 { 0,7,8,2,0,0,5,9,0},
                 { 5,9,2,6,0,8,3,7,0},
                 { 8,6,4,7,2,1,9,5,3},
                 { 3,5,7,8,9,0,0,1,2},
                 { 2,1,9,0,0,0,8,0,7}
                };

            Brainbashers1 = new[,]
                           {
                 { 5,2,0,6,0,9,1,7,3},
                 { 0,1,7,0,0,3,5,6,9},
                 { 3,9,6,1,7,5,4,2,8 },
                 { 7,8,9,5,6,4,3,1,2},
                 { 0,3,0,7,1,8,9,5,6},
                 { 1,6,5,3,9,2,8,4,7},
                 { 6,5,0,0,3,1,7,9,4},
                 { 0,4,1,9,0,7,6,3,5},
                 { 9,7,3,4,5,6,2,8,1}
                };

            Brainbashers2 = new[,]
                           {
                 { 0,1,2,9,0,8,4,3,0},
                 { 0,4,0,1,0,0,0,8,9},
                 { 5,8,9,4,0,3,7,0,1 },
                 { 8,0,0,3,0,7,0,5,4},
                 { 0,0,0,5,8,0,0,0,7},
                 {2,7,5,6,4,1,3,9,8},
                 { 1,0,7,8,0,5,9,4,2},
                 { 0,2,0,7,0,0,0,1,0},
                 { 9,5,0,2,1,4,0,7,0}
                };

            Brainbashers3 = new[,]
                           {
                 { 7,0,3,4,1,5,9,0,8},
                 { 9,8,4,2,6,7,5,1,3},
                 { 1,5,0,0,0,8,0,7,4 },
                 { 8,4,0,0,5,0,0,3,9},
                 { 0,1,0,8,0,9,4,0,0},
                 { 0,9,0,0,7,4,0,8,0},
                 { 4,3,9,0,8,0,0,5,1},
                 { 0,7,1,5,4,3,8,9,0},
                 { 5,0,8,0,0,0,3,4,0}
                };

            SudokuWikiArticle = new[,]
                           {
                 { 1,4,0,0,8,0,0,6,0},
                 { 7,8,6,9,3,1,2,5,4},
                 { 0,2,0,0,6,4,8,0,1 },
                 { 5,9,1,3,4,6,7,2,8},
                 { 2,3,4,8,1,7,5,9,6},
                 { 6,7,8,0,9,0,4,1,3},
                 { 4,5,0,6,2,3,1,8,0},
                 { 8,1,0,4,5,9,6,0,2},
                 { 0,6,2,1,7,8,0,4,5}
                };


            SudokuZero = new[,]
                           {
                 { 0,0,3,7,2,0,6,4,0},
                 { 4,0,2,3,5,6,9,0,1},
                 { 6,0,0,4,8,0,3,2,0 },
                 { 9,3,4,5,7,8,2,1,6},
                 { 0,6,0,1,9,2,4,3,0},
                 { 0,2,0,6,3,4,0,5,9},
                 { 2,5,0,9,1,3,0,6,4},
                 { 0,4,9,2,6,5,1,0,3},
                 { 3,1,6,8,4,7,5,9,2}
                };


            Hodoku = new[,]
                           {
                 { 7,9,8,4,5,2,3,1,6},
                 { 6,0,3,7,8,1,0,9,2},
                 { 0,1,2,0,3,0,8,7,0},
                 { 3,7,0,2,6,5,0,4,8},
                 { 8,2,0,1,4,3,7,6,0},
                 { 0,6,0,8,9,7,0,2,3},
                 { 9,8,0,0,1,4,2,3,7},
                 { 1,0,7,0,2,8,0,5,0},
                 { 2,0,0,0,7,0,0,8,1}
                };


            Hodoku2 = new[,]
                           {
                 { 1,7,8,6,0,9,0,5,0},
                 { 9,3,4,1,5,0,6,0,7},
                 { 2,5,6,7,0,3,0,1,0},
                 { 7,9,3,5,6,0,0,4,1},
                 { 6,4,1,0,3,7,5,9,0},
                 { 8,2,5,9,1,4,7,3,6},
                 { 5,6,7,3,0,1,0,0,0},
                 { 4,1,0,0,7,5,0,6,0},
                 { 3,8,0,4,0,6,1,7,5}
                };

            SySudoku = new[,]
                           {
                 { 8,0,0,0,3,1,2,9,4},
                 { 9,3,0,4,0,2,6,8,1},
                 { 4,2,1,6,9,8,7,3,5},
                 { 0,7,0,0,0,0,9,5,0},
                 { 5,0,8,0,0,9,0,0,2},
                 { 0,9,3,0,0,0,0,7,0},
                 { 3,0,0,0,0,7,8,2,0},
                 { 6,8,2,9,0,3,0,1,7},
                 { 7,1,0,8,2,0,0,0,0},
                };

            SySudoku2 = new[,]
                           {
                 { 0,2,9,0,4,0,3,0,8},
                 { 3,4,8,0,2,9,7,6,0},
                 { 0,5,7,0,0,0,9,2,4},
                 { 5,8,4,6,0,0,0,3,9},
                 { 9,6,0,0,0,4,0,0,7},
                 { 2,7,0,0,9,5,8,4,6},
                 { 4,3,6,0,0,0,0,9,0},
                 { 8,9,2,4,5,1,6,7,3},
                 { 7,1,5,9,6,3,4,8,2}
                };

            NonRemotePair = new[,]
               {
                 { 0,2,9,0,4,0,3,0,8},
                 { 3,4,8,0,2,9,7,6,0},
                 { 0,5,7,0,0,0,9,2,4},
                 { 5,8,4,6,0,0,0,3,9},
                 { 9,6,0,0,0,4,0,0,7},
                 { 2,7,0,0,9,5,8,4,6},
                 { 4,3,6,0,0,0,0,9,0},
                 { 8,9,2,4,5,1,6,7,3},
                 { 7,1,5,9,6,3,4,8,2}
                };
        }

        [TestMethod()]

        public void Example1()
        {

            Technique g = new Technique(Example);
            g.RemotePairTechnique();
            var actual = g.Grid.Rows[1].Cells[2].Possibilities;
            var expected = new List<int>() { 3 };
            var check = g.Grid.Rows[1].Cells[4].Possibilities;
            foreach (var x in check)
            {
                Console.WriteLine(x + "@@@");
            }

            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Example1B()
        {
            Technique g = new Technique(Example);
            g.RemotePairTechnique();
            var actual = g.Grid.Columns[2].Cells[1].Possibilities;
            var expected = new List<int>() { 3 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Example1C()
        {
            Technique g = new Technique(Example);
            g.RemotePairTechnique();
            var actual = g.Grid.Blocks[0].Cells[5].Possibilities;
            var expected = new List<int>() { 3 };
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]

        public void Example_1C()
        {
            Technique g = new Technique(Example);
            g.RemotePairTechnique();
            var actual = g.Grid.Rows[1].Cells[2].Possibilities;
            var expected = new List<int>() { 3 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void IronMonger1A()
        {

            Technique g = new Technique(IronMonger);
            g.RemotePairTechnique();
            var actual = g.Grid.Columns[8].Cells[0].Possibilities;
            var expected = new List<int>() { 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void IronMonger1b()
        {
            Technique g = new Technique(IronMonger);
            g.RemotePairTechnique();
            var actual = g.Grid.Blocks[8].Cells[6].Possibilities;
            var expected = new List<int>() { 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]

        public void IronMonger2a()
        {
            Technique g = new Technique(IronMonger2);
            g.RemotePairTechnique();
            var actual = g.Grid.Blocks[4].Cells[4].Possibilities;
            var expected = new List<int>() { 1, 3 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Z_IronMonger2B()
        {
            Technique g = new Technique(IronMonger2);
            g.RemotePairTechnique();
            var actual = g.Grid.Rows[4].Cells[4].Possibilities;
            var expected = new List<int>() { 1, 3 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void IronMonger2C()
        {
            Technique g = new Technique(IronMonger2);
            g.RemotePairTechnique();
            var actual = g.Grid.Columns[4].Cells[4].Possibilities;
            var expected = new List<int>() { 1, 3 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWiki1a()
        {
            Technique g = new Technique(SudokuWikiArticle);
            g.RemotePairTechnique();
            var actual = g.Grid.Rows[0].Cells[2].Possibilities;
            var expected = new List<int>() { 5 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuZero1a()
        {
            Technique g = new Technique(SudokuZero);
            g.RemotePairTechnique();
            var actual = g.Grid.Columns[0].Cells[5].Possibilities;
            var expected = new List<int>() { 1 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Hodoku2a()
        {
            Technique g = new Technique(Hodoku2);
            g.RemotePairTechnique();

            var actual = g.Grid.Rows[0].Cells[6].Possibilities;
            var s = g.Grid.Rows[7].Cells[3].Possibilities;
            var expected = new List<int>() { 3, 4 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Hodoku2b()
        {
            Technique g = new Technique(Hodoku2);
            g.RemotePairTechnique();
            var actual = g.Grid.Rows[2].Cells[6].Possibilities;
            var expected = new List<int>() { 4, 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Hodoku2c()
        {
            Technique g = new Technique(Hodoku2);
            g.RemotePairTechnique();
            var actual = g.Grid.Columns[4].Cells[6].Possibilities;
            var expected = new List<int>() { 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Hodoku2d()
        {
            Technique g = new Technique(Hodoku2);
            g.RemotePairTechnique();
            var actual = g.Grid.Blocks[8].Cells[2].Possibilities;
            var expected = new List<int>() { 4, 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Hodoku2e()
        {
            Technique g = new Technique(Hodoku2);
            g.RemotePairTechnique();
            var actual = g.Grid.Rows[7].Cells[6].Possibilities;
            var expected = new List<int>() { 3, 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]

        public void Hodoku2f()
        {
            Technique g = new Technique(Hodoku2);
            g.RemotePairTechnique();
            var actual = g.Grid.Rows[7].Cells[8].Possibilities;
            var expected = new List<int>() { 3, 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]

        public void Z_Hodoku1a()
        {
            Technique g = new Technique(Hodoku);
            g.RemotePairTechnique();
            var actual = g.Grid.Rows[5].Cells[6].Possibilities;
            var expected = new List<int>() { 1 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Sysudoku1A()
        {
            Technique g = new Technique(SySudoku);
            g.RemotePairTechnique();
            var actual = g.Grid.Columns[2].Cells[8].Possibilities;
            var expected = new List<int>() { 5, 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }



        [TestMethod()]

        public void Sysudoku2B()
        {
            Technique g = new Technique(SySudoku2);
            g.RemotePairTechnique();
            var actual = g.Grid.Rows[4].Cells[3].Possibilities;
            var expected = new List<int>() { 2, 3, 8 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }




        [TestMethod()]

        public void FindIntersect()
        {
            Technique g = new Technique(SySudoku);
            var actual = g.FindIntersect("1;6", "6;8");

            var expected = new List<string>() { "0;8", "1;8", "2;8", "6;6", "7;6", "8;6" };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }




        [TestMethod()]

        public void RemotePairIntersectTestRow()
        {
            Technique g = new Technique(SySudoku);
            var actual = g.FindIntersect("0;0", "0;1");
            var expected = new List<string>() { "0;2", "0;3", "0;4", "0;5", "0;6", "0;7", "0;8", "1;0", "1;1", "1;2", "2;0", "2;1", "2;2" };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void RemotePairIntersectTestCol()
        {
            Technique g = new Technique(SySudoku);
            var actual = g.FindIntersect("0;0", "8;0");
            var expected = new List<string>() { "1;0", "2;0", "3;0", "4;0", "5;0", "6;0", "7;0" };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void RemotePairIntersectTestBlock()
        {
            Technique g = new Technique(SySudoku);
            var actual = g.FindIntersect("0;0", "2;2");
            var expected = new List<string>() { "0;1", "0;2", "1;0", "1;1", "1;2", "2;0", "2;1" };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void RemotePairIntersectTestCorners()
        {
            Technique g = new Technique(SySudoku);
            var actual = g.FindIntersect("0;0", "8;8");
            var expected = new List<string>() { "0;8", "8;0" };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void RemotePairIntersectTestExample()
        {
            Technique g = new Technique(SySudoku);
            var actual = g.FindIntersect("5;2", "1;4");
            var expected = new List<string>() { "1;2", "5;4" };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void RemotePairIntersectTestExampleReverese()
        {
            Technique g = new Technique(SySudoku);
            var actual = g.FindIntersect("1;4", "5;2");
            var expected = new List<string>() { "1;2", "5;4" };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void RemotePairIntersectTestRectancle()
        {
            Technique g = new Technique(SySudoku);
            var actual = g.FindIntersect("1;4", "3,1");
            var expected = new List<string>() { "1;1", "3;4" };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void NonRemotePairNoChange()
        {
            Technique g = new Technique(NonRemotePair);
            var actual = g.SudokuGrid;
            var expected = NonRemotePair;
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void IsSameTrue()
        {
            Technique g = new Technique(NonRemotePair);
            List<int> input = new List<int>() { 4, 5 };
            List<int> input2 = new List<int>() { 4, 5 };
            var actual = g.SamePossiblities(input, input2);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsSameTrueInverse()
        {
            Technique g = new Technique(NonRemotePair);
            List<int> input = new List<int>() { 4, 5 };
            List<int> input2 = new List<int>() { 5, 4 };
            var actual = g.SamePossiblities(input, input2);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void IsSameFalseNone()
        {
            Technique g = new Technique(NonRemotePair);
            List<int> input = new List<int>() { 4, 5 };
            List<int> input2 = new List<int>() { 1, 3 };
            var actual = g.SamePossiblities(input, input2);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsSameFalse()
        {
            Technique g = new Technique(NonRemotePair);
            List<int> input = new List<int>() { 4, 5 };
            List<int> input2 = new List<int>() { 4, 6 };
            var actual = g.SamePossiblities(input, input2);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsSameFalse2()
        {
            Technique g = new Technique(NonRemotePair);
            List<int> input = new List<int>() { 4, 5 };
            List<int> input2 = new List<int>() { 1, 4 };
            var actual = g.SamePossiblities(input, input2);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }


    }
}