using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.Techniques.Hard;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    [TestClass()]
    public class XWingTests
    {


        public int[,] LearnSudoku { get; set; }

        public int[,] SudokuWiki1 { get; set; }
        public int[,] SudokuWiki2 { get; set; }
        public int[,] SudokuWiki3 { get; set; }

        public int[,] SudokuBeginner { get; set; }

        public int[,] Sudoku9x9 { get; set; }
        public int[,] SudokuLive{ get; set; }

        public int[,] SudokuLive2 { get; set; }


        public int[,] SudokuLive3 { get; set; }

        public int[,] SudokuLive4 { get; set; }

        public int[,] SudokuOnline { get; set; }

        public int[,] MasteringSudoku { get; set; }

        public int[,] SudokuPrint { get; set; }

        public int[,] SudokuOfTheDay1 { get; set; }

        public int[,] SudokuOfTheDay2 { get; set; }

        public int[,] SudokuOfTheDay3 { get; set; }

        public int[,] SudokuOfTheDay4 { get; set; }

        public int[,] SudokuOrg1 { get; set; }

        public int[,] SudokuOrg2 { get; set; }

        public int[,] BrainBashers1 { get; set; }

        public int[,] BrainBashers2 { get; set; }

        public XWingTests()
        {
           

            LearnSudoku = new[,]
{
                {0,0,3,8,0,0,5,1,0},
                {0,0,8,7,0,0,9,3,0},
                {1,0,0,3,0,5,7,2,8},
                {0,0,0,2,0,0,8,4,9},
                {8,0,1,9,0,6,2,5,7},
                {0,0,0,5,0,0,1,6,3},
                {9,6,4,1,2,7,3,8,5},
                {3,8,2,6,5,9,4,7,1},
                {0,1,0,4,0,0,6,9,2},

            };

            SudokuWiki1 = new[,]
{
                {1,0,0,0,0,0,5,6,9},
                {4,9,2,0,5,6,1,0,8},
                {0,5,6,1,0,9,2,4,0},
                {0,0,9,6,4,0,8,0,1},
                {0,6,4,0,1,0,0,0,0},
                {2,1,8,0,3,5,6,0,4},
                {0,4,0,5,0,0,0,1,6},
                {9,0,5,0,6,1,4,0,2},
                {6,2,1,0,0,0,0,0,5},

            };

            SudokuWiki2 = new[,]
{
                {0,0,0,0,0,0,0,9,4},
                {7,6,0,9,1,0,0,5,0},
                {0,9,0,0,0,2,0,8,1},
                {0,7,0,0,5,0,0,1,0},
                {0,0,0,7,0,9,0,0,0},
                {0,8,0,0,3,1,0,6,7},
                {2,4,0,1,0,0,0,7,0},
                {0,1,0,0,9,0,0,4,5},
                {9,0,0,0,0,0,1,0,0},

            };

            SudokuWiki3 = new[,]
{
                {0,2,0,0,0,0,0,9,4},
                {7,6,0,9,1,0,0,5,0},
                {0,9,0,0,0,2,0,8,1},
                {0,7,0,0,5,0,0,1,0},
                {0,0,0,7,0,9,0,0,0},
                {0,8,0,0,3,1,0,6,7},
                {2,4,0,1,0,0,0,7,0},
                {0,1,0,0,9,0,0,4,5},
                {9,0,0,0,0,0,1,0,0},

            };

            SudokuBeginner = new[,]
{
                {4,5,8,0,0,0,7,9,3},
                {6,9,3,5,0,0,2,1,4},
                {7,0,0,4,9,3,6,8,5},
                {0,0,5,9,0,0,0,0,6},
                {0,4,0,0,3,5,0,7,0},
                {3,0,0,0,0,2,4,5,0},
                {0,6,0,1,0,0,0,0,7},
                {0,0,4,0,0,9,0,6,0},
                {1,0,0,0,5,0,8,4,0},

            };

            Sudoku9x9 = new[,]
{
                {7,4,3,2,9,5,8,1,6},
                {1,5,8,0,6,4,0,9,0},
                {2,6,9,8,0,1,0,0,5},
                {4,8,6,0,1,9,5,0,0},
                {3,7,5,4,8,2,1,6,9},
                {9,2,1,5,0,6,0,8,4},
                {5,3,4,6,2,8,9,7,1},
                {8,9,2,1,4,7,6,5,3},
                {6,1,7,9,5,3,0,0,8},

            };


            SudokuLive = new[,]
{
                {6,0,8,0,9,0,1,0,7},
                {0,7,9,3,0,0,0,2,6},
                {0,0,0,0,6,7,0,0,0},
                {0,0,0,6,0,3,0,7,0},
                {7,0,6,0,0,0,2,0,0},
                {0,8,0,7,0,0,0,6,0},
                {8,0,5,0,3,0,7,4,2},
                {0,4,7,0,0,8,6,1,0},
                {1,0,2,0,7,0,9,0,8},

            };

            SudokuLive2 = new[,]
{
                {4,0,2,5,0,6,7,0,3},
                {7,5,0,0,3,2,0,0,4},
                {1,0,3,7,4,8,0,0,2},
                {0,0,1,0,0,0,0,2,0},
                {0,0,0,2,0,9,0,0,0},
                {0,2,0,0,0,4,6,0,0},
                {3,0,0,4,0,0,2,0,0},
                {2,0,0,0,8,0,0,4,7},
                {5,7,4,0,2,1,8,0,6},

            };

            SudokuLive3 = new[,]
{
                {0,0,1,0,9,0,6,0,0},
                {0,0,0,0,6,0,5,0,1},
                {5,6,0,1,0,8,0,0,4},
                {6,4,2,3,7,9,8,1,5},
                {7,3,8,0,1,0,2,6,9},
                {1,5,9,0,0,6,4,0,0},
                {2,0,0,6,0,1,0,5,8},
                {3,0,5,0,0,0,1,0,6},
                {0,1,6,0,5,0,7,0,0},

            };

            SudokuLive4 = new[,]
{
                {5,3,2,1,4,6,7,9,8},
                {4,6,9,0,0,7,1,3,5},
                {0,0,7,5,3,9,4,6,2},
                {9,0,6,0,0,0,0,7,0},
                {0,0,0,7,6,8,0,0,0},
                {0,7,0,0,9,0,0,0,6},
                {0,0,1,0,7,0,6,0,0},
                {6,0,0,9,0,0,0,1,7},
                {7,0,5,6,1,4,0,2,0},

            };

            SudokuOnline = new[,]
{
                {6,0,0,0,9,5,0,0,7},
                {5,4,0,0,0,7,1,0,0},
                {0,0,2,8,0,0,0,5,0},
                {8,0,0,0,0,0,0,9,0},
                {0,0,0,0,7,8,0,0,0},
                {0,3,0,0,0,0,0,0,8},
                {0,5,0,0,0,2,3,0,0},
                {3,0,4,5,0,0,0,2,0},
                {9,2,0,0,3,0,5,0,4},

            };

            MasteringSudoku = new[,]
{
                {1,0,0,3,0,0,8,0,0},
                {9,7,4,0,8,5,0,3,6},
                {8,2,3,0,0,6,0,0,4},
                {0,0,1,0,5,2,0,9,0},
                {0,8,0,0,1,0,0,0,0},
                {0,0,6,9,0,0,7,0,2},
                {6,3,8,0,0,1,0,0,7},
                {4,1,0,5,0,0,0,6,0},
                {5,9,0,0,6,0,3,0,0},

            };

            SudokuPrint = new[,]
{
                {0,0,8,4,0,0,6,0,0},
                {3,6,0,5,0,7,9,8,0},
                {9,0,2,0,3,0,5,4,7},
                {0,2,0,9,8,4,0,3,0},
                {0,0,7,0,5,0,8,0,0},
                {0,8,0,2,0,3,0,1,0},
                {2,0,3,0,9,0,1,0,8},
                {0,9,0,3,0,1,0,7,0},
                {0,0,1,0,4,0,3,0,0},

            };

            SudokuOfTheDay1 = new[,]
{
                {9,0,0,0,5,1,7,3,0},
                {1,0,7,3,9,8,2,0,5},
                {5,0,0,0,7,6,0,9,1},
                {8,1,0,7,2,4,3,5,0},
                {2,0,0,1,6,5,0,0,7},
                {0,7,5,9,8,3,0,1,2},
                {0,2,1,5,3,7,0,0,0},
                {7,5,8,6,4,9,1,2,3},
                {3,9,0,8,1,2,5,7,0},

            };

            SudokuOfTheDay2 = new[,]
{
                {8,5,7,9,1,2,0,0,6},
                {2,9,1,3,4,6,7,5,8},
                {3,4,6,7,8,5,1,9,2},
                {1,2,4,5,6,0,9,0,3},
                {7,6,0,0,0,0,0,2,5},
                {9,0,5,0,2,0,6,0,1},
                {4,1,2,6,0,0,5,0,7},
                {6,7,0,2,5,0,0,1,0},
                {5,0,0,0,7,0,2,6,0},

            };

            SudokuOfTheDay3 = new[,]
{
                {9,0,1,0,6,3,4,8,2},
                {0,4,8,9,0,2,0,6,1},
                {0,6,0,8,4,1,0,9,0},
                {4,0,6,3,8,5,2,0,9},
                {0,8,0,1,2,0,0,4,6},
                {0,0,0,6,0,4,8,0,0},
                {1,2,0,4,3,0,6,5,8},
                {6,3,0,0,1,8,9,2,4},
                {8,0,4,2,0,6,1,3,7},

            };

            SudokuOfTheDay4 = new[,]
{
                {7,0,3,8,0,6,0,9,0},
                {6,1,4,9,2,3,7,0,0},
                {9,8,0,0,7,4,0,6,3},
                {0,3,0,0,0,0,0,7,0},
                {1,7,9,2,4,5,6,3,0},
                {0,4,0,0,3,0,0,1,0},
                {8,0,1,0,9,0,3,0,6},
                {3,9,7,0,6,0,0,0,1},
                {4,6,0,3,0,1,9,0,7},

            };

            SudokuOrg1 = new[,]
{
                {5,0,0,2,0,8,0,0,3},
                {9,0,0,0,7,0,0,0,5},
                {0,4,0,0,0,0,0,6,0},
                {7,9,1,0,0,0,6,5,8},
                {0,0,0,0,6,0,0,0,7},
                {6,3,0,0,0,7,1,2,4},
                {0,5,0,0,0,0,0,8,0},
                {3,0,0,0,8,0,0,0,6},
                {2,0,0,7,0,4,0,0,9},

            };

            SudokuOrg2 = new[,]
{
                {0,0,7,0,0,0,0,0,0},
                {4,0,0,2,0,9,0,0,7},
                {0,1,0,7,0,5,0,6,0},
                {7,5,4,8,2,1,6,3,9},
                {9,2,1,5,3,6,0,0,8},
                {0,0,6,4,9,7,5,1,2},
                {0,7,0,1,0,2,0,9,0},
                {1,0,0,9,0,8,0,0,5},
                {0,0,0,0,0,0,0,0,0},

            };

            BrainBashers1 = new[,]
{
                {0,8,0,0,1,0,2,6,0},
                {0,0,2,0,8,0,3,0,0},
                {3,0,1,2,0,7,9,0,8},
                {0,0,7,8,0,1,4,0,0},
                {0,0,0,0,4,0,0,0,0},
                {0,0,9,6,0,5,1,0,0},
                {5,0,6,1,0,8,7,0,9},
                {0,0,3,0,0,0,5,0,0},
                {0,7,0,0,0,0,0,2,0},

            };

            BrainBashers2 = new[,]
{
                {0,3,2,8,9,1,6,4,0},
                {0,0,8,6,4,5,3,0,0},
                {0,4,0,7,3,2,0,0,0},
                {2,6,4,9,8,3,7,5,1},
                {3,0,0,5,1,4,2,8,6},
                {1,8,5,2,6,7,9,3,4},
                {0,5,0,1,2,8,4,0,3},
                {8,0,3,4,7,6,5,0,0},
                {4,2,0,3,5,9,0,6,0},

            };
        }

      
        [TestMethod()]
        public void LearnSudoku1A()
        {
            Technique t = new Technique(LearnSudoku);
            t.XWing();
            var expected = new List<int>() { 2,7,9 };
            var actual = t.Grid.Columns[1].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LearnSudoku1BA()
        {
            Technique t = new Technique(LearnSudoku);
            t.XWing();
            var expected = new List<int>() { 2,5};
            var actual = t.Grid.Columns[1].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LearnSudoku1C()
        {
            Technique t = new Technique(LearnSudoku);
            t.XWing();
            var expected = new List<int>() { 2, 7, 9 };
            var actual = t.Grid.Columns[1].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LearnSudoku1D()
        {
            Technique t = new Technique(LearnSudoku);
            t.XWing();
            var expected = new List<int>() {6,9 };
            var actual = t.Grid.Columns[4].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LearnSudoku1E()
        {
            Technique t = new Technique(LearnSudoku);
            t.XWing();
            var expected = new List<int>() {1,6 };
            var actual = t.Grid.Columns[4].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void LearnSudoku1G()
        {
            Technique t = new Technique(LearnSudoku);
            t.XWing();
            var expected = new List<int>() { 1, 6 };
            var actual = t.Grid.Rows[1].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LearnSudoku1F()
        {
            Technique t = new Technique(LearnSudoku);
            t.XWing();
            var expected = new List<int>() { 2,7,9};
            var actual = t.Grid.Columns[1].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1A()
        {
            Technique t = new Technique(SudokuWiki1);
            t.XWing();
            var expected = new List<int>() { 2,3,4,8 };
            var actual = t.Grid.Columns[3].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1B()
        {
            Technique t = new Technique(SudokuWiki1);
            var before = t.Grid.Columns[3].Cells[1].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + ",,,");
            }
            t.XWing();
            var expected = new List<int>() { 2,8,9};
            var actual = t.Grid.Columns[3].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1C()
        {
            Technique t = new Technique(SudokuWiki1);
            var before = t.Grid.Columns[3].Cells[6].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + ",,,");
            }
            t.XWing();
            var expected = new List<int>() { 3,8 };
            var actual = t.Grid.Columns[3].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1D()
        {
            Technique t = new Technique(SudokuWiki1);
            t.XWing();
            var expected = new List<int>() {3,8};
            var actual = t.Grid.Columns[7].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1E()
        {
            Technique t = new Technique(SudokuWiki1);
            t.XWing();
            var expected = new List<int>() {3,8,9 };
            var actual = t.Grid.Columns[7].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1F()
        {
            Technique t = new Technique(SudokuWiki1);
            var before = t.Grid.Columns[3].Cells[8].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + ",,,");
            }
            t.XWing();
            var expected = new List<int>() { 3, 4,8,9 };
            var actual = t.Grid.Columns[3].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki2A()
        {
            Technique t = new Technique(SudokuWiki2);
            t.XWing();
            var expected = new List<int>() { 3,5 };
            var actual = t.Grid.Rows[4].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki2B()
        {
            Technique t = new Technique(SudokuWiki2);
            t.XWing();
            var expected = new List<int>() { 1,3,4,5,6 };
            var actual = t.Grid.Rows[4].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki2C()
        {
            Technique t = new Technique(SudokuWiki2);
            t.XWing();
            var expected = new List<int>() { 3, 4,5,8 };
            var actual = t.Grid.Rows[4].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki2D()
        {
            Technique t = new Technique(SudokuWiki2);
            t.XWing();
            var expected = new List<int>() { 3, 8 };
            var actual = t.Grid.Rows[4].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki2E()
        {
            Technique t = new Technique(SudokuWiki2);
            t.XWing();
            var expected = new List<int>() { 3, 4,5,6,8 };
            var actual = t.Grid.Rows[8].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki2F()
        {
            Technique t = new Technique(SudokuWiki2);
            t.XWing();
            var expected = new List<int>() { 3, 6,8};
            var actual = t.Grid.Rows[8].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki3A()
        {
            Technique t = new Technique(SudokuWiki3);
            t.XWing();
            var expected = new List<int>() {1,4,5,6};
            var actual = t.Grid.Rows[4].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki3B()
        {
            Technique t = new Technique(SudokuWiki3);
            t.XWing();
            var expected = new List<int>() { 1, 4, 5, 6 };
            var actual = t.Grid.Rows[4].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki3C()
        {
            Technique t = new Technique(SudokuWiki3);
            t.XWing();
            var expected = new List<int>() { 4,5,8 };
            var actual = t.Grid.Rows[4].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki3D()
        {
            Technique t = new Technique(SudokuWiki3);
            var before = t.Grid.Rows[4].Cells[0].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + ",,,");
            }
            t.XWing();
            var expected = new List<int>() { 8 };
            var actual = t.Grid.Rows[4].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki3E()
        {
            Technique t = new Technique(SudokuWiki3);
            t.XWing();
            var expected = new List<int>() { 5,6,7,8};
            var actual = t.Grid.Rows[8].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki3F()
        {
            Technique t = new Technique(SudokuWiki3);
            t.XWing();
            var expected = new List<int>() { 4,5,6,8};
            var actual = t.Grid.Rows[8].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki3G()
        {
            Technique t = new Technique(SudokuWiki3);
            var before = t.Grid.Rows[8].Cells[5].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + ",,,");
            }
            t.XWing();
            var expected = new List<int>() { 4,5,6,7,8};
            var actual = t.Grid.Rows[8].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki3H()
        {
            Technique t = new Technique(SudokuWiki3);
            t.XWing();
            var expected = new List<int>() { 6,8 };
            var actual = t.Grid.Rows[8].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuBeginenr1A()
        {
            Technique t = new Technique(SudokuBeginner);
            t.XWing();
            var expected = new List<int>() { 1,2,6};
            var actual = t.Grid.Rows[4].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuBeginenr1B()
        {
            Technique t = new Technique(SudokuBeginner);
            t.XWing();
            var expected = new List<int>() { 1, 2, 8 };
            var actual = t.Grid.Rows[4].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuBeginenr1C()
        {
            Technique t = new Technique(SudokuBeginner);
            t.XWing();
            var expected = new List<int>() { 2};
            var actual = t.Grid.Rows[6].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Sudoku9x91A()
        {
            Technique t = new Technique(Sudoku9x9);
            t.XWing();
            var expected = new List<int>() { 2,3 };
            var actual = t.Grid.Rows[1].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuLive1A()
        {
            Technique t = new Technique(SudokuLive);
            t.XWing();
            var expected = new List<int>() {1,4,5 };
            var actual = t.Grid.Columns[4].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuLive1B()
        {
            Technique t = new Technique(SudokuLive);
            t.XWing();
            var expected = new List<int>() { 3, 4, 5 };
            var actual = t.Grid.Columns[6].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuLive2A()
        {
            Technique t = new Technique(SudokuLive2);
            t.XWing();
            var expected = new List<int>() { 6,8 };
            var actual = t.Grid.Columns[3].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuLive2B()
        {
            Technique t = new Technique(SudokuLive2);
            t.XWing();
            var expected = new List<int>() { 6, 9 };
            var actual = t.Grid.Columns[3].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuLive2C()
        {
            Technique t = new Technique(SudokuLive2);
            t.XWing();
            var expected = new List<int>() { 1,5,7,8};
            var actual = t.Grid.Columns[7].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuLive3A()
        {
            Technique t = new Technique(SudokuLive3);
            t.XWing();
            var expected = new List<int>() {7};
            var actual = t.Grid.Rows[2].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuLive3B()
        {
            Technique t = new Technique(SudokuLive3);
            t.XWing();
            var expected = new List<int>() { 2,7,9 };
            var actual = t.Grid.Rows[2].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuLive4A()
        {
            Technique t = new Technique(SudokuLive4);
            var before = t.Grid.Columns[1].Cells[6].Possibilities;
            foreach(var x in before)
            {
                Console.WriteLine(x + ",,,");
            }
            t.XWing();
            var expected = new List<int>() { 2,4,9};
            var actual = t.Grid.Columns[1].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuLive4B()
        {
            Technique t = new Technique(SudokuLive4);
            t.XWing();
            var expected = new List<int>() { 2, 4 };
            var actual = t.Grid.Columns[1].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuLive4C()
        {
            Technique t = new Technique(SudokuLive4);
            t.XWing();
            var expected = new List<int>() { 2, 3,5 };
            var actual = t.Grid.Columns[6].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuLive4D()
        {
            Technique t = new Technique(SudokuLive4);
            var before = t.Grid.Columns[6].Cells[7].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + ",,,");
            }
            t.XWing();
            var expected = new List<int>() { 3,5 };
            var actual = t.Grid.Columns[6].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }



        [TestMethod()]
        public void SudokuOnline1A()
        {
            Technique t = new Technique(SudokuOnline);
            t.XWing();
            var expected = new List<int>() { 1,6 };
            var actual = t.Grid.Rows[7].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void MasteringSudoku1A()
        {
            Technique t = new Technique(MasteringSudoku);
            t.XWing();
            var expected = new List<int>() { 4,6};
            var actual = t.Grid.Rows[4].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MasteringSudoku1B()
        {
            Technique t = new Technique(MasteringSudoku);
            t.XWing();
            var expected = new List<int>() {   4 };
            var actual = t.Grid.Rows[4].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MasteringSudoku1C()
        {
            Technique t = new Technique(MasteringSudoku);
            t.XWing();
            var expected = new List<int>() { 1,   4,  8 };
            var actual = t.Grid.Rows[5].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MasteringSudoku1D()
        {
            Technique t = new Technique(MasteringSudoku);
            t.XWing();
            var expected = new List<int>() { 2, 7 };
            var actual = t.Grid.Rows[0].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuPrint1A()
        {
            Technique t = new Technique(SudokuPrint);
            t.XWing();
            var expected = new List<int>() {4,7 };
            var actual = t.Grid.Rows[6].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuPrint1B()
        {

            Technique t = new Technique(SudokuPrint);
            var before = t.Grid.Rows[8].Cells[0].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + ",,,");
            }
            t.XWing();
            var expected = new List<int>() {6,7};
            var actual = t.Grid.Rows[8].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuPrint1C()
        {
            Technique t = new Technique(SudokuPrint);
            t.XWing();
            var expected = new List<int>() {  7 };
            var actual = t.Grid.Rows[8].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDay1A()
        {
            Technique t = new Technique(SudokuOfTheDay1);
            t.XWing();
            var expected = new List<int>() {4,8 };
            var actual = t.Grid.Columns[8].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDay1B()
        {
            Technique t = new Technique(SudokuOfTheDay1);
            t.XWing();
            var expected = new List<int>() { 4,8,9 };
            var actual = t.Grid.Columns[8].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDay2A()
        {
            Technique t = new Technique(SudokuOfTheDay2);
            t.XWing();
            var expected = new List<int>() { 1,3,4,9};
            var actual = t.Grid.Rows[4].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDay2B()
        {
            Technique t = new Technique(SudokuOfTheDay2);
            t.XWing();
            var expected = new List<int>() { 3,4,7 };
            var actual = t.Grid.Rows[5].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDay2C()
        {
            Technique t = new Technique(SudokuOfTheDay2);
            t.XWing();
            var expected = new List<int>() { 4,7 };
            var actual = t.Grid.Rows[5].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDay2D()
        {
            Technique t = new Technique(SudokuOfTheDay2);
            var before = t.Grid.Rows[7].Cells[5].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + ",,,");
            }
            t.XWing();
            var expected = new List<int>() { 3,4 };
            var actual = t.Grid.Rows[7].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDay2E()
        {
            Technique t = new Technique(SudokuOfTheDay2);
            t.XWing();
            var expected = new List<int>() { 1,3, 4 };
            var actual = t.Grid.Rows[8].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDay3A()
        {
            Technique t = new Technique(SudokuOfTheDay3);
            t.XWing();
            var expected = new List<int>() {2,3,5,7};
            var actual = t.Grid.Rows[5].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDay4A()
        {
            Technique t = new Technique(SudokuOfTheDay4);
            var before = t.Grid.Rows[7].Cells[6].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + ",,,");
            }
            t.XWing();
            var expected = new List<int>() { 2, 5,8};
            var actual = t.Grid.Rows[7].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOrg1A()
        {
            Technique t = new Technique(SudokuOrg1);
            t.XWing();
            var expected = new List<int>() { 3,5,9};
            var actual = t.Grid.Rows[2].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOrg1B()
        {
            Technique t = new Technique(SudokuOrg1);
            t.XWing();
            var expected = new List<int>() { 3, 5, 9 };
            var actual = t.Grid.Rows[2].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOrg1C()
        {
            Technique t = new Technique(SudokuOrg1);
            t.XWing();
            var expected = new List<int>() { 3, 5, 9 };
            var actual = t.Grid.Rows[2].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOrg2A()
        {
            Technique t = new Technique(SudokuOrg2);
            t.XWing();
            var expected = new List<int>() {8,9 };
            var actual = t.Grid.Columns[1].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOrg2B()
        {
            Technique t = new Technique(SudokuOrg2);
            t.XWing();
            var expected = new List<int>() { 4,8, 9 };
            var actual = t.Grid.Columns[1].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOrg2C()
        {
            Technique t = new Technique(SudokuOrg2);
            t.XWing();
            var expected = new List<int>() { 1,4,8};
            var actual = t.Grid.Columns[4].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOrg2D()
        {
            Technique t = new Technique(SudokuOrg2);
            t.XWing();
            var expected = new List<int>() {4,5 };
            var actual = t.Grid.Columns[4].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOrg2E()
        {
            Technique t = new Technique(SudokuOrg2);
            t.XWing();
            var expected = new List<int>() {4,5,7 };
            var actual = t.Grid.Columns[4].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BrainBashers1A()
        {
            Technique t = new Technique(BrainBashers1);
            t.XWing();
            var expected = new List<int>() {5,6,9 };
            var actual = t.Grid.Columns[1].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BrainBashers1B()
        {
            Technique t = new Technique(BrainBashers1);
            t.XWing();
            var expected = new List<int>() {2,3 };
            var actual = t.Grid.Columns[1].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BrainBashers1C()
        {
            Technique t = new Technique(BrainBashers1);
            t.XWing();
            var expected = new List<int>() {1,2,9 };
            var actual = t.Grid.Columns[1].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BrainBashers1D()
        {
            Technique t = new Technique(BrainBashers1);
            t.XWing();
            var expected = new List<int>() { 1,5,7 };
            var actual = t.Grid.Columns[7].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BrainBashers1E()
        {
            Technique t = new Technique(BrainBashers1);
            t.XWing();
            var expected = new List<int>() {1,8 };
            var actual = t.Grid.Columns[7].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BrainBashers2A()
        {
            Technique t = new Technique(BrainBashers2);
            t.XWing();
            var expected = new List<int>() {9 };
            var actual = t.Grid.Columns[7].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}