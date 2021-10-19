using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.Techniques;
using System;
using System.Collections.Generic;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudoku.SudokuSolver.Techniques

{
    [TestClass()]
    public class HiddenTriplesTests
    {
        public int[,] Thonky { get; set; }
        public int[,] SudokuOrg { get; set; }

        public int[,] SudokuApp { get; set; }

        public int[,] SudokuApp2 { get; set; }

        public int[,] SudokuSolver { get; set; }

        public int[,] SudokuWiki { get; set; }
        public HiddenTriplesTests()
        {
            Thonky = new[,]
            {
                {0,0,0,0,0,0,2,6,0},
                {0,0,9,0,8,0,0,4,3},
                {5,0,0,0,3,0,0,9,0},
                {0,0,0,2,1,5,0,0,0},
                {3,5,0,0,0,0,1,0,9},
                {1,8,0,3,7,9,0,0,4},
                {8,0,0,0,5,4,9,0,0},
                {0,0,4,0,0,0,0,0,0},
                {0,0,5,0,2,3,4,1,0},

            };

            SudokuOrg = new[,]
    {
                {0,0,3,4,2,5,6,0,0},
                {0,9,2,0,1,6,4,3,0},
                {6,4,0,9,0,3,0,1,0},
                {0,0,0,3,0,9,0,0,0},
                {0,0,6,0,0,0,9,0,0},
                {0,0,0,2,0,8,0,0,0},
                {0,2,0,0,0,0,0,6,0},
                {0,6,8,5,9,2,1,4,0},
                {4,5,1,6,3,7,8,0,0},

            };

            SudokuApp = new[,]
{
                {0,5,2,0,0,0,0,0,0},
                {0,0,0,0,0,0,8,2,0},
                {0,0,8,0,0,0,0,0,5},
                {0,8,0,3,0,0,7,4,0},
                {0,0,0,0,1,5,0,0,0},
                {6,0,0,0,7,8,0,0,3},
                {0,7,0,0,3,0,0,0,2},
                {8,3,0,0,4,0,9,7,6},
                {0,0,0,7,0,0,3,1,0},

            };

            SudokuApp2 = new[,]
{
                {0,8,0,0,0,0,4,3,5},
                {0,2,0,0,4,0,1,8,7},
                {0,1,0,8,0,7,0,0,6},
                {0,0,0,3,0,0,6,0,0},
                {1,0,6,4,0,0,7,0,0},
                {0,0,0,7,6,1,8,4,0},
                {5,0,0,0,0,9,0,6,4},
                {9,0,0,0,0,0,0,0,8},
                {0,6,0,0,0,4,0,7,0},

            };

            SudokuSolver = new[,]
{
                {9,0,7,0,2,0,0,3,0},
                {0,0,2,9,0,0,8,0,0},
                {0,6,1,0,5,3,7,2,9},
                {1,0,5,0,0,0,6,7,0},
                {0,0,9,7,0,0,0,0,0},
                {7,4,6,3,1,5,9,8,2},
                {6,9,4,5,8,0,0,1,7},
                {5,1,3,0,0,0,0,6,8},
                {2,7,8,0,0,0,0,9,5},

            };

            SudokuWiki = new[,]
{
                {0,0,0,0,0,1,0,3,0},
                {2,3,1,0,9,0,0,0,0},
                {0,6,5,0,0,3,1,0,0},
                {6,7,8,9,2,4,3,0,0},
                {1,0,3,0,5,0,0,0,6},
                {0,0,0,1,3,6,7,0,0},
                {0,0,9,3,6,0,5,7,0},
                {0,0,6,0,1,9,8,4,3},
                {3,0,0,0,0,0,0,0,0},

            };
        }

        [TestMethod()]
        public void Thonky1A()
        {
            Technique t = new Technique(Thonky);
            t.HiddenTriples();
            var expected = new List<int>() { 1, 3, 8 };
            var actual = t.Grid.Columns[2].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Thonky1B()
        {
            Technique t = new Technique(Thonky);
            t.HiddenTriples();
            var expected = new List<int>() { 1, 8 };
            var actual = t.Grid.Columns[2].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Thonky1C()
        {
            Technique t = new Technique(Thonky);
            t.HiddenTriples();
            var expected = new List<int>() { 1, 3 };
            var actual = t.Grid.Columns[2].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOrg1A()
        {
            Technique t = new Technique(SudokuOrg);
            t.HiddenTriples();
            var expected = new List<int>() { 1, 4, 6 };
            var actual = t.Grid.Columns[8].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOrg1B()
        {
            Technique t = new Technique(SudokuOrg);
            t.HiddenTriples();
            var expected = new List<int>() { 1, 4 };
            var actual = t.Grid.Columns[8].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOrg1C()
        {
            Technique t = new Technique(SudokuOrg);
            t.HiddenTriples();
            var expected = new List<int>() { 1, 4, 6 };
            var actual = t.Grid.Columns[8].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOrg1D()
        {
            Technique t = new Technique(SudokuOrg);
            t.HiddenTriples();
            var expected = new List<int>() { 1, 4, 6 };
            var actual = t.Grid.Rows[3].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOrg1E()
        {
            Technique t = new Technique(SudokuOrg);
            t.HiddenTriples();
            var expected = new List<int>() { 1, 4 };
            var actual = t.Grid.Rows[4].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOrg1F()
        {
            Technique t = new Technique(SudokuOrg);
            t.HiddenTriples();
            var expected = new List<int>() { 1, 4, 6 };
            var actual = t.Grid.Rows[5].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuOrg1G()
        {
            Technique t = new Technique(SudokuOrg);
            t.HiddenTriples();
            var expected = new List<int>() { 1, 4, 6 };
            var actual = t.Grid.Blocks[5].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuOrg1H()
        {
            Technique t = new Technique(SudokuOrg);
            t.HiddenTriples();
            var expected = new List<int>() { 1, 4 };
            var actual = t.Grid.Blocks[5].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuOrg1I()
        {
            Technique t = new Technique(SudokuOrg);
            t.HiddenTriples();
            var expected = new List<int>() { 1, 4, 6 };
            var actual = t.Grid.Blocks[5].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuApp1()
        {
            Technique t = new Technique(SudokuApp);
            t.HiddenTriples();
            var expected = new List<int>() { 3, 4, 7 };
            var actual = t.Grid.Columns[5].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuApp1B()
        {
            Technique t = new Technique(SudokuApp);
            t.HiddenTriples();
            var expected = new List<int>() { 3, 4, 7 };
            var actual = t.Grid.Columns[5].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuApp1C()
        {
            Technique t = new Technique(SudokuApp);
            var before = t.Grid.Columns[5].Cells[2].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + "~");
            }
            t.HiddenTriples();
            var expected = new List<int>() { 3, 4, 7 };
            var actual = t.Grid.Columns[5].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuApp2A()
        {
            Technique t = new Technique(SudokuApp2);
            t.HiddenTriples();
            var expected = new List<int>() { 4, 7, 8 };
            var actual = t.Grid.Rows[3].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuApp2B()
        {
            Technique t = new Technique(SudokuApp2);
            t.HiddenTriples();
            var expected = new List<int>() { 4, 7 };
            var actual = t.Grid.Rows[3].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuApp2C()
        {
            Technique t = new Technique(SudokuApp2);
            t.HiddenTriples();
            var expected = new List<int>() { 4, 7, 8 };
            var actual = t.Grid.Rows[3].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSolver1A()
        {
            Technique t = new Technique(SudokuSolver);
            t.HiddenTriples();
            var expected = new List<int>() { 6, 7 };
            var actual = t.Grid.Rows[1].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSolver1B()
        {
            Technique t = new Technique(SudokuSolver);
            t.HiddenTriples();
            var expected = new List<int>() { 1, 6, 7 };
            var actual = t.Grid.Rows[1].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSolver1C()
        {
            Technique t = new Technique(SudokuSolver);
            t.HiddenTriples();
            var expected = new List<int>() { 1, 6 };
            var actual = t.Grid.Rows[1].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1A()
        {
            Technique t = new Technique(SudokuWiki);
            t.HiddenTriples();
            var expected = new List<int>() { 2, 5, 6 };
            var actual = t.Grid.Rows[0].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1B()
        {
            Technique t = new Technique(SudokuWiki);
            t.HiddenTriples();
            var expected = new List<int>() { 2, 6 };
            var actual = t.Grid.Rows[0].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1C()
        {
            Technique t = new Technique(SudokuWiki);
            t.HiddenTriples();
            var expected = new List<int>() { 2, 5 };
            var actual = t.Grid.Rows[0].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1CV2()
        {
            Technique t = new Technique(SudokuWiki);
            t.HiddenTriples();
            var expected = new List<int>() { 2, 5 };
            var actual = t.Grid.Columns[8].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuWikiBlocks()
        {
            Technique t = new Technique(SudokuWiki);
            t.HiddenTriples();
            var expected = new List<int>() { 2, 5 };
            var actual = t.Grid.Blocks[2].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1D()
        {
            Technique t = new Technique(SudokuWiki);
            var before  = t.Grid.Columns[8].Cells[1].Possibilities;
            foreach(var x in before)
            {
                Console.WriteLine(x + "~");
            }
            t.HiddenTriples();
            var expected = new List<int>() { 4, 7, 8 };
            var actual = t.Grid.Columns[8].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1DV2()
        {
            Technique t = new Technique(SudokuWiki);
            var before = t.Grid.Rows[1].Cells[8].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + "~");
            }
            t.HiddenTriples();
            var expected = new List<int>() { 4, 7, 8 };
            var actual = t.Grid.Rows[1].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1DV3()
        {
            Technique t = new Technique(SudokuWiki);
            var before = t.Grid.Blocks[2].Cells[5].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + "~");
            }
            t.HiddenTriples();
            var expected = new List<int>() { 4, 7, 8 };
            var actual = t.Grid.Blocks[2].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1E()
        {
            Technique t = new Technique(SudokuWiki);
            var before = t.Grid.Columns[8].Cells[2].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + "~");
            }
            t.HiddenTriples();
            var expected = new List<int>() { 4, 7, 8 };
            var actual = t.Grid.Columns[8].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1F()
        {
            Technique t = new Technique(SudokuWiki);
            var before = t.Grid.Columns[8].Cells[5].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + "~");
            }
            t.HiddenTriples();
            var expected = new List<int>() { 4, 8 };
            var actual = t.Grid.Columns[8].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1G()
        {
            Technique t = new Technique(SudokuWiki);
            var before = t.Grid.Columns[8].Cells[3].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + "~");
            }
            t.HiddenTriples();
            var expected = new List<int>() { 1,5 };
            var actual = t.Grid.Columns[8].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1H()
        {
            Technique t = new Technique(SudokuWiki);
            var before = t.Grid.Columns[8].Cells[6].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + "~");
            }
            t.HiddenTriples();
            var expected = new List<int>() { 1,2};
            var actual = t.Grid.Columns[8].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1I()
        {
            Technique t = new Technique(SudokuWiki);
            var before = t.Grid.Columns[8].Cells[8].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + "~");
            }
            t.HiddenTriples();
            var expected = new List<int>() { 1,2,9};
            var actual = t.Grid.Columns[8].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}