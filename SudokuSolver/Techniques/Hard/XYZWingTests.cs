using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.Techniques.Hard;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    [TestClass()]
    public class XYZWingTests
    {
        public int[,] SudokuWiki1 { get; set; }
        public int[,] SudokuWiki2 { get; set; }

        public int[,] SudokuSnake { get; set; }

        public int[,] SudokuOrg { get; set; }

        public int[,] Sudoku9x9 { get; set; }

        public int[,] BrainBashers1{ get; set; }

        public int[,] Brainbashers2 { get; set; }

        public int[,] SudokuSolver { get; set; }

        public int[,] Hodoku1 { get; set; }

        public int[,] Hodoku2 { get; set; }

        public int[,] KrazyDad{ get; set; }

        public int[,] SysSudoku { get; set; }

        public int[,] Thonky { get; set; }


        public XYZWingTests()
        {
            SudokuWiki1 = new[,]
{
                {0,9,2,0,0,1,7,5,0},
                {5,0,0,2,0,0,0,0,8},
                {0,0,0,0,3,0,2,0,0},
                {3,7,5,0,0,4,9,6,0},
                {2,8,0,0,6,0,0,7,5},
                {0,6,9,7,0,0,0,3,0},
                {0,0,8,0,9,0,0,2,0},
                {7,0,0,0,0,3,0,8,9},
                {9,0,3,8,0,0,0,4,0},

            };

            SudokuWiki2 = new[,]
{
                {6,0,0,0,0,0,0,1,8},
                {5,0,0,9,0,8,0,0,7},
                {8,2,0,0,0,1,0,3,0},
                {3,4,0,2,1,9,0,8,0},
                {2,0,0,0,8,0,3,0,0},
                {1,8,0,3,0,7,0,2,5},
                {7,5,0,4,0,0,0,9,2},
                {9,0,0,0,0,5,0,0,4},
                {4,0,0,0,9,0,0,0,3},

            };

            SudokuSnake = new[,]
{
                {0,2,3,8,0,5,9,0,0},
                {4,0,0,0,0,2,0,0,0},
                {6,8,0,9,0,1,0,0,4},
                {2,0,6,0,1,0,0,5,0},
                {8,0,0,5,0,6,0,0,1},
                {0,5,0,0,2,0,6,0,0},
                {5,6,0,1,0,3,4,8,2},
                {0,0,8,2,0,0,0,6,7},
                {0,0,2,6,0,0,1,9,0},

            };

            SudokuOrg = new[,]
{
                {2,9,1,5,7,8,4,6,3},
                {5,6,7,9,3,4,8,2,1},
                {4,3,8,1,2,6,5,7,9},
                {0,0,6,4,0,5,2,0,0},
                {0,0,0,8,0,2,0,0,0},
                {0,0,2,7,0,3,9,0,0},
                {0,2,0,6,5,7,0,8,0},
                {6,0,3,2,0,1,7,9,5},
                {0,0,5,3,0,9,6,0,2},

            };

            Sudoku9x9 = new[,]
{
                {7,4,3,2,9,5,8,1,6},
                {1,5,8,7,6,4,0,9,0},
                {2,6,9,8,0,1,0,0,5},
                {4,8,6,3,1,9,5,0,0},
                {3,7,5,4,8,2,1,6,9},
                {9,2,1,5,0,6,0,8,4},
                {5,3,4,6,2,8,9,7,1},
                {8,9,2,1,4,7,6,5,3},
                {6,1,7,9,5,3,0,0,8},

            };

            BrainBashers1 = new[,]
{
                {5,3,6,4,1,8,7,2,9},
                {7,2,4,0,0,0,8,1,3},
                {9,8,1,2,3,7,4,5,6},
                {3,0,5,0,0,0,6,0,1},
                {4,0,8,0,0,0,5,9,2},
                {6,0,2,0,0,0,3,0,7},
                {2,4,3,1,8,6,9,7,5},
                {8,5,9,0,0,0,1,6,4},
                {1,6,7,5,9,4,2,3,8},

            };

            Brainbashers2 = new[,]
{
                {0,0,0,8,6,2,5,0,0},
                {0,0,2,1,5,7,8,0,0},
                {0,8,5,4,3,9,0,7,0},
                {5,0,8,7,4,3,6,0,9},
                {0,7,6,9,8,5,3,4,0},
                {4,3,9,2,1,6,7,8,5},
                {0,9,0,3,2,8,0,5,0},
                {0,0,1,5,7,4,9,0,0},
                {0,5,0,6,9,1,0,0,0},

            };

            SudokuSolver = new[,]
{
                {9,0,0,0,8,5,0,7,1},
                {0,0,0,0,9,3,0,8,5},
                {0,8,5,1,2,7,6,9,0},
                {0,0,0,7,0,8,5,2,9},
                {5,9,0,2,0,0,7,0,8 },
                {2,7,8,5,0,9,0,3,6},
                {0,2,9,8,5,0,0,0,0},
                {1,3,4,9,7,6,8,5,2},
                {8,5,0,3,0,2,9,0,0},

            };

            Hodoku1 = new[,]
{
                {8,6,9,4,5,3,7,2,1},
                {0,0,0,9,2,1,5,6,8 },
                {2,1,5,8,0,0,4,3,9},
                {6,2,1,5,3,4,9,8,7},
                {4,0,7,6,1,0,3,5,2},
                {0,0,0,2,0,0,1,4,6},
                {0,0,0,1,0,2,8,0,3},
                {9,3,2,7,8,5,6,1,4},
                {1,0,0,3,4,0,2,0,5},

            };

            Hodoku2 = new[,]
{
                {6,8,3,0,8,0,2,0,9},
                {5,1,4,0,9,2,0,0,3},
                {9,8,2,0,0,0,0,0,5},
                {1,6,7,3,5,9,0,0,2},
                {8,0,9,0,1,0,5,3,6},
                {0,0,5,8,0,0,7,9,1},
                {0,0,6,1,4,0,9,2,8},
                {0,0,1,0,0,8,3,5,4},
                {0,0,8,0,0,0,1,6,7},

            };

            KrazyDad = new[,]
{
                {1,5,9,7,6,3,2,8,4},
                {3,6,0,0,1,8,9,7,5},
                {8,0,7,0,0,5,1,3,6},
                {9,7,0,8,5,0,3,4,2},
                {5,0,0,0,4,0,7,9,0},
                {2,0,0,0,7,0,5,6,0},
                {4,8,5,1,3,7,6,2,9},
                {6,0,3,5,8,0,4,1,7},
                {7,0,0,6,0,4,8,5,3},

            };

            SysSudoku = new[,]
{
                {0,0,0,0,5,8,6,9,1},
                {1,5,9,6,0,0,0,8,0},
                {6,0,8,0,1,9,0,0,0},
                {0,0,6,9,0,0,8,1,2},
                {0,8,0,0,6,1,0,0,0},
                {0,1,0,8,0,0,0,4,6},
                {8,6,1,0,9,0,5,2,3},
                {2,3,5,1,8,6,0,7,0},
                {0,9,0,5,2,3,1,6,8},

            };

            Thonky = new[,]
{
                {9,6,2,7,0,0,1,0,5},
                {0,0,0,9,0,0,0,0,0},
                {7,0,0,1,5,2,9,4,6},
                {6,0,4,2,0,1,0,5,0},
                {0,0,7,6,0,5,0,0,0,},
                {5,2,0,0,0,0,6,1,8 },
                {2,7,0,0,0,9,0,0,0},
                {3,0,0,0,0,0,5,6,2},
                {0,0,0,0,2,0,0,0,0},

            };
        }

        [TestMethod()]
        public void SudokuWiki1A()
        {
            Technique t = new Technique(SudokuWiki1);
            var before = t.Grid.Columns[6].Cells[5].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + "~");
            }
            t.XYZWing();
            var expected = new List<int>() { 4,8};
            var actual = t.Grid.Columns[6].Cells[5].Possibilities;
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
            t.XYZWing();
            var expected = new List<int>() { 4, 8 };
            var actual = t.Grid.Rows[5].Cells[6].Possibilities;
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
            t.XYZWing();
            var expected = new List<int>() { 4, 8 };
            var actual = t.Grid.Blocks[5].Cells[6].Possibilities;
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
            var expected = new List<int>() { 1,2};
            var actual = t.Grid.Rows[3].Cells[8].Possibilities;
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
            var expected = new List<int>() { 1, 2,4 };
            var actual = t.Grid.Rows[5].Cells[8].Possibilities;
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
            t.XYZWing();
            var expected = new List<int>() { 1,4};
            var actual = t.Grid.Rows[5].Cells[0].Possibilities;
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
            t.XYZWing();
            var expected = new List<int>() { 1,9 };
            var actual = t.Grid.Rows[4].Cells[8].Possibilities;
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
            var expected = new List<int>() { 6,7 };
            var actual = t.Grid.Rows[3].Cells[6].Possibilities;
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
            var expected = new List<int>() {4,6};
            var actual = t.Grid.Rows[4].Cells[5].Possibilities;
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
            var expected = new List<int>() { 4,6, 7 };
            var actual = t.Grid.Rows[4].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSnake1A()
        {
            Technique t = new Technique(SudokuSnake);
            t.XYZWing();
            var expected = new List<int>() {3,5,8};
            var actual = t.Grid.Rows[1].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSnake1B()
        {
            Technique t = new Technique(SudokuSnake);
            var expected = new List<int>() { 1,7};
            var actual = t.Grid.Rows[0].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSnake1C()
        {
            Technique t = new Technique(SudokuSnake);
            var expected = new List<int>() { 3, 7 };
            var actual = t.Grid.Rows[1].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSnake1D()
        {
            Technique t = new Technique(SudokuSnake);
            var expected = new List<int>() { 1, 3,7 };
            var actual = t.Grid.Rows[1].Cells[7].Possibilities;
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
            var before = t.Grid.Rows[3].Cells[0].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + "~");
            }
            t.XYZWing();
            var expected = new List<int>() { 1,3,7,9 };
            var actual = t.Grid.Rows[3].Cells[0].Possibilities;
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
            var expected = new List<int>() { 1,7,8 };
            var actual = t.Grid.Rows[3].Cells[1].Possibilities;
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
            var expected = new List<int>() {  7, 8 };
            var actual = t.Grid.Rows[3].Cells[8].Possibilities;
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
            var expected = new List<int>() { 1,  8 };
            var actual = t.Grid.Rows[5].Cells[0].Possibilities;
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
            var before = t.Grid.Rows[1].Cells[6].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + "~");
            }
            t.XYZWing();
            var expected = new List<int>() { 2 };
            var actual = t.Grid.Rows[1].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Sudoku9x91B()
        {
            Technique t = new Technique(Sudoku9x9);
            var expected = new List<int>() { 3,4,7};
            var actual = t.Grid.Rows[2].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Sudoku9x91C()
        {
            Technique t = new Technique(Sudoku9x9);
            var expected = new List<int>() { 3, 4};
            var actual = t.Grid.Rows[2].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Sudoku9x91D()
        {
            Technique t = new Technique(Sudoku9x9);
            var expected = new List<int>() { 3,7};
            var actual = t.Grid.Rows[5].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Brainashers1A()
        {
            Technique t = new Technique(BrainBashers1);
            t.XYZWing();
            var expected = new List<int>() { 2 };
            var actual = t.Grid.Rows[3].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Brainbashers2A()
        {
            Technique t = new Technique(Brainbashers2);
            var before = t.Grid.Rows[7].Cells[8].Possibilities;
            foreach(var x in before)
            {
                Console.WriteLine(x + "~");
            }
            t.XYZWing();
            var expected = new List<int>() { 3,6,8 };
            var actual = t.Grid.Rows[7].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Brainbashers2B()
        {
            Technique t = new Technique(Brainbashers2);
            var expected = new List<int>() { 2,6 };
            var actual = t.Grid.Rows[7].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Brainbashers2C()
        {
            Technique t = new Technique(Brainbashers2);
            var expected = new List<int>() { 2,3, 6 };
            var actual = t.Grid.Rows[7].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Brainbashers2D()
        {
            Technique t = new Technique(Brainbashers2);
            var expected = new List<int>() { 2, 3};
            var actual = t.Grid.Rows[8].Cells[7].Possibilities;
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
            t.XYZWing();
            var expected = new List<int>() { 3,4 };
            var actual = t.Grid.Rows[2].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku1A()
        {
            Technique t = new Technique(Hodoku1);
            t.XYZWing();
            var expected = new List<int>() {8 };
            var actual = t.Grid.Rows[8].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku2A()
        {
            Technique t = new Technique(Hodoku2);
            t.XYZWing();
            var expected = new List<int>() {3,7 };
            var actual = t.Grid.Rows[2].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku2B()
        {
            Technique t = new Technique(Hodoku2);
            t.XYZWing();
            var expected = new List<int>() {1, 3, 4,7 };
            var actual = t.Grid.Rows[2].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void KrazyDad1A()
        {
            Technique t = new Technique(KrazyDad);
            t.XYZWing();
            var expected = new List<int>() { 3};
            var actual = t.Grid.Rows[4].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SysSudoku1A()
        {
            Technique t = new Technique(SysSudoku);
            t.XYZWing();
            var expected = new List<int>() { 4,5 };
            var actual = t.Grid.Rows[3].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SysSudoku1B()
        {
            Technique t = new Technique(SysSudoku);
            var expected = new List<int>() { 4, 7 };
            var actual = t.Grid.Rows[3].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SysSudoku1C()
        {
            Technique t = new Technique(SysSudoku);
            var expected = new List<int>() { 3,4, 7 };
            var actual = t.Grid.Rows[3].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SysSudoku1D()
        {
            Technique t = new Technique(SysSudoku);
            var expected = new List<int>() { 3,7 };
            var actual = t.Grid.Rows[5].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Thonky1A()
        {
            Technique t = new Technique(Thonky);
            t.XYZWing();
            var expected = new List<int>() { 1,8,9 };
            var actual = t.Grid.Rows[4].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}