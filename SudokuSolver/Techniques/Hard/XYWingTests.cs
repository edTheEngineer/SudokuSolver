using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.Techniques.Hard;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesSudoku.SudokuSolver.Techniques.Tests
{
    [TestClass()]
    public class XYWingTests
    {
        public int[,] SudokuLive1 { get; set; }
        public int[,] SudokuLive2 { get; set; }
        public int[,] SudokuLive3 { get; set; }

        public int[,] SudokuSolver1 { get; set; }

        public int[,] SudokuSolver2 { get; set; }

        public int[,] Sudoku9x9 { get; set; }
        public int[,] BrainBashers1 { get; set; }
        public int[,] BrainBashers2 { get; set; }

        public int[,] Sudopedia { get; set; }

        public int[,] SudokuSnake { get; set; }

        public int[,] Ironmonger1 { get; set; }

        public int[,] IronMonger2 { get; set; }

        public int[,] Hodoku1 { get; set; }

        public int[,] Hodoku2 { get; set; }

        public int[,] SudokuOrg { get; set; }

        public int[,] SudokuDragon1 { get; set; }

        public int[,] SudokuDragon2 { get; set; }


        public XYWingTests()
        {
            SudokuLive1 = new[,]
{
                {6,4,7,9,1,5,3,8,2},
                {3,9,5,2,8,4,7,6,1},
                {0,2,0,3,0,0,5,4,9},
                {0,0,0,7,3,0,0,0,6},
                {0,0,0,5,0,1,0,0,0},
                {9,0,0,8,4,0,0,0,0},
                {0,8,6,0,5,0,0,2,3},
                {5,0,2,6,0,3,0,0,0},
                {0,3,9,0,2,8,6,7,5},

            };


            SudokuLive2 = new[,]
    {
                {5,0,0,2,3,0,8,6,7},
                {0,8,0,9,0,0,0,0,2},
                {2,0,0,8,0,0,0,0,0},
                {0,0,1,0,9,0,2,5,0},
                {0,2,7,3,6,5,1,0,0},
                {0,0,5,1,8,2,3,7,0},
                {0,0,2,0,0,3,0,8,1},
                {6,0,8,0,1,9,0,2,0},
                {1,4,0,0,2,8,0,0,5},

            };

            SudokuSolver1 = new[,]
{
                {0,0,9,0,1,0,0,0,0},
                {1,0,2,6,7,9,0,4,0},
                {4,0,0,0,2,8,1,9,0},
                {7,0,0,0,0,2,0,1,4},
                {0,0,0,7,4,1,0,0,5},
                {0,4,1,0,0,6,7,0,0},
                {8,1,5,2,6,3,4,7,9},
                {3,2,7,0,0,0,0,0,1},
                {9,6,4,1,8,7,3,5,2},

            };

            SudokuSolver2 = new[,]
{
                {8,3,0,0,6,0,5,9,2},
                {1,0,9,0,5,0,6,3,8},
                {6,5,2,3,9,8,0,4,0},
                {0,0,0,8,4,3,9,0,6},
                {9,6,8,7,1,5,4,2,3},
                {0,0,3,6,2,9,8,0,0},
                {0,0,1,0,8,4,3,6,9},
                {3,9,0,0,7,0,0,8,4},
                {0,8,0,9,3,0,0,0,5},

            };

            Sudoku9x9 = new[,]
{
                {4,7,0,8,0,6,2,3,5},
                {8,0,0,0,0,3,0,0,9},
                {3,0,0,0,4,0,1,8,0},
                {9,6,2,0,7,0,3,1,8},
                {0,5,8,9,3,1,0,0,0},
                {0,4,3,6,8,2,5,0,9},
                {5,3,0,0,6,7,0,0,0},
                {2,8,0,1,5,0,0,0,0},
                {6,0,7,3,0,8,4,5,0},

            };

            BrainBashers1 = new[,]
{
                {0,2,6,1,8,0,0,3,4},
                {7,3,8,5,4,6,9,1,2},
                {0,1,4,0,0,2,6,8,0},
                {3,5,7,4,9,8,2,6,1},
                {8,4,2,0,0,1,0,7,9},
                {1,6,9,2,0,0,8,4,0},
                {4,8,1,0,0,0,0,2,0},
                {6,9,3,7,2,4,1,5,8},
                {2,7,5,8,1,3,4,9,6},

            };

            BrainBashers2 = new[,]
{
                {4,2,7,5,8,6,1,9,3},
                {5,9,1,3,4,7,8,2,6},
                {8,3,6,0,0,0,5,4,7},
                {3,4,8,0,0,0,0,7,1},
                {2,1,9,0,0,8,0,3,5},
                {6,7,5,0,0,0,0,8,9},
                {9,8,4,0,0,0,0,1,2},
                {1,5,2,8,0,9,0,6,4},
                {7,6,3,2,1,4,9,5,8},

            };

            Sudopedia = new[,]
{
                {0,0,4,0,1,0,0,3,5},
                {0,0,1,7,0,0,9,0,4},
                {6,0,8,5,4,0,2,7,1},
                {1,8,9,6,0,4,0,0,3},
                {4,0,0,0,0,1,0,0,0},
                {2,6,7,3,0,5,4,1,0},
                {0,1,2,9,5,8,0,4,6},
                {0,0,6,4,3,2,1,0,0},
                {8,4,0,1,6,7,0,0,0},

            };


            SudokuSnake = new[,]
{
                {0,2,9,6,0,8,0,7,0},
                {0,7,0,9,0,5,0,0,0},
                {8,0,3,4,7,2,9,1,0},
                {2,3,7,8,5,6,1,0,0},
                {0,0,0,7,4,9,0,0,3},
                {9,4,8,3,2,1,5,6,7},
                {7,0,2,5,6,4,0,0,1},
                {3,0,0,1,8,7,0,0,0},
                {0,0,6,2,9,3,7,5,0},

            };

            Ironmonger1 = new[,]
{
                {1,7,0,3,4,5,0,0,0},
                {3,0,0,1,9,0,4,5,0},
                {5,4,9,6,8,0,1,0,0},
                {0,0,7,4,0,0,8,0,0},
                {6,9,3,8,7,1,5,4,2},
                {0,0,5,2,0,0,0,0,0 },
                {7,0,1,4,2,8,9,0,5},
                {0,5,0,9,1,3,0,0,4},
                {9,0,4,7,5,6,0,1,0},

            };


            IronMonger2 = new[,]
{
                {1,8,2,0,0,5,3,6,7},
                {4,9,7,3,6,8,1,2,5},
                {5,3,6,2,1,7,9,4,8},
                {3,1,4,5,2,0,7,8,0},
                {0,6,8,0,0,0,4,5,0},
                {0,5,9,0,8,0,0,1,3},
                {8,7,3,6,0,0,0,9,0},
                {6,4,5,0,7,0,8,3,0},
                {9,2,1,8,0,0,0,7,0},

            };

            Hodoku1 = new[,]
 {
                {8,0,0,3,6,0,9,0,0},
                {0,0,9,0,1,0,8,6,3},
                {0,6,3,0,8,9,0,0,5 },
                {9,2,4,6,7,3,1,5,8 },
                {3,8,6,9,5,1,7,2,4},
                {5,7,1,8,2,4,3,9,6},
                {4,3,2,1,9,6,5,8,7},
                {6,9,8,5,3,7,0,0,0},
                {0,0,0,2,4,8,6,3,9},

            };

            Hodoku2 = new[,]
{
                {7,1,4,0,6,0,5,3,8},
                {8,0,0,4,5,3,0,0,7},
                {3,5,6,7,1,8,4,2,9,},
                {0,0,0,0,2,4,0,8,5},
                {4,0,0,0,0,0,3,0,2},
                {2,8,5,3,7,6,9,4,1},
                {9,7,8,6,3,1,2,5,4},
                {0,0,0,0,0,7,0,0,6},
                {0,0,0,0,0,0,0,0,3},

            };

            SudokuOrg = new[,]
{
                {2,7,3,0,0,5,0,8,1},
                {8,1,0,3,0,2,0,0,4},
                {0,0,9,0,1,0,2,0,0,},
                {1,0,0,9,5,3,7,2,8},
                {7,9,2,1,8,6,3,4,5},
                {5,3,8,7,2,4,1,9,6},
                {0,2,1,0,6,0,5,0,0},
                {3,0,0,2,0,1,8,6,9},
                {0,8,0,5,3,0,4,1,2},

            };

            SudokuDragon1 = new[,]
{
                {2,3,0,5,4,0,6,0,0},
                {5,0,1,0,2,0,0,0,0},
                {0,0,9,0,0,8,5,0,2},
                {0,0,0,0,7,3,0,0,0},
                {0,2,3,4,5,0,8,0,7},
                {4,7,5,9,8,0,3,0,0},
                {3,0,4,0,9,0,1,0,0},
                {0,0,0,0,0,4,2,0,9},
                {0,0,2,0,0,5,0,8,0},

            };

            SudokuDragon2 = new[,]
{
                {6,8,0,4,5,2,0,7,3},
                {0,4,2,0,0,9,6,5,8},
                {0,5,0,0,8,0,0,1,2},
                {8,7,0,5,2,0,1,3,0},
                {0,0,5,8,0,3,7,2,0},
                {0,2,0,0,9,0,8,4,5},
                {2,3,0,0,6,0,5,0,0},
                {0,1,8,9,3,5,2,6,0},
                {5,0,0,2,0,0,3,0,1},

            };


        }

        [TestMethod()]
        public void SudokuLive1A()
        {
            Technique t = new Technique(SudokuLive1);
            t.XYWing();
            var expected = new List<int>() { 1 };
            var actual = t.Grid.Rows[7].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuLive1B()
        {
            Technique t = new Technique(SudokuLive1);
            t.XYWing();
            var expected = new List<int>() { 1 };
            var actual = t.Grid.Columns[1].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuLive1C()
        {
            Technique t = new Technique(SudokuLive1);
            t.XYWing();
            var expected = new List<int>() { 1 };
            var actual = t.Grid.Blocks[6].Cells[4].Possibilities;
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
            var before = t.Grid.Columns[2].Cells[1].Possibilities;
            foreach(var x in before)
            {
                Console.WriteLine(x + "~");
            }
            t.Grid.RemovePossibility(1, 2, 3);
            t.Grid.RemovePossibility(2, 2, 3);
            t.XYWing();
            var expected = new List<int>() { 4, 6 };
            var actual = t.Grid.Columns[2].Cells[1].Possibilities;
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
            t.Grid.RemovePossibility(1, 2, 3);
            t.Grid.RemovePossibility(2, 2, 3);
            t.XYWing();
            var expected = new List<int>() { 4, 6 ,9};
            var actual = t.Grid.Columns[2].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSolver1A()
        {
            Technique t = new Technique(SudokuSolver1);
            t.XYWing();
            var expected = new List<int>() { 3, 4 };
            var actual = t.Grid.Rows[0].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuSolver1B2()
        {
            Technique t = new Technique(SudokuSolver1);
            t.XYWing();
            var expected = new List<int>() { 4 };
            var actual = t.Grid.Rows[0].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSolver1B()
        {
            Technique t = new Technique(SudokuSolver1);
            t.XYWing();
            var expected = new List<int>() { 4 };
            var actual = t.Grid.Rows[0].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSolver1C()
        {
            Technique t = new Technique(SudokuSolver1);
            t.XYWing();
            var expected = new List<int>() { 3, 7 };
            var actual = t.Grid.Rows[2].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSolver2A()
        {
            Technique t = new Technique(SudokuSolver2);
            t.XYWing();
            var expected = new List<int>() { 5 };
            var actual = t.Grid.Rows[6].Cells[3].Possibilities;
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
            t.XYWing();
            var expected = new List<int>() { 5, 7 };
            var actual = t.Grid.Blocks[4].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku1D()
        {
            Technique t = new Technique(Hodoku1);
 
            var expected = new List<int>() { 5, 7 };
            var actual = t.Grid.Blocks[0].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku1E()
        {
            Technique t = new Technique(Hodoku1);

            var expected = new List<int>() { 2,5 };
            var actual = t.Grid.Blocks[1].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku1F()
        {
            Technique t = new Technique(Hodoku1);

            var expected = new List<int>() { 2, 7 };
            var actual = t.Grid.Blocks[0].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku2F()
        {
            Technique t = new Technique(Hodoku2);

            var expected = new List<int>() { 1,6};
            var actual = t.Grid.Rows[3].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku22G()
        {
            Technique t = new Technique(Hodoku2);

            var expected = new List<int>() { 1,9};
            var actual = t.Grid.Rows[3].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku2H()
        {
            Technique t = new Technique(Hodoku2);

            var expected = new List<int>() {6,9};
            var actual = t.Grid.Rows[4].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudopediaPossibilityCoordinate()
        {
            Technique t = new Technique(Sudopedia);
            var actual= t.getPossibilitiesByCoordinate("8;8");
            var expected = new List<int>() {2,9 };
           
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
            t.XYWing();
            var expected = new List<int>() { 5, 6, 7 };
            var actual = t.Grid.Blocks[7].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BrainBashers2B()
        {
            Technique t = new Technique(BrainBashers2);
            t.XYWing();
            var expected = new List<int>() { 1, 2 };
            var actual = t.Grid.Blocks[4].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Sudppedia1A()
        {
            Technique t = new Technique(Sudopedia);
            t.XYWing();
            var expected = new List<int>() { 5 };
            var actual = t.Grid.Rows[1].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudoSnake1A()
        {
            Technique t = new Technique(SudokuSnake);
            t.XYWing();
            var expected = new List<int>() { 5, 6 };
            var actual = t.Grid.Rows[4].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IronMonger1A()
        {
            Technique t = new Technique(Ironmonger1);
            t.XYWing();
            var expected = new List<int>() { 2, 8, 9 };
            var actual = t.Grid.Rows[0].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IronMonger1B()
        {
            Technique t = new Technique(Ironmonger1);
            t.XYWing();
            var expected = new List<int>() { 2, 7 };
            var actual = t.Grid.Rows[7].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IronMonger2A()
        {
            Technique t = new Technique(IronMonger2);
            t.XYWing();
            var expected = new List<int>() { 1, 7 };
            var actual = t.Grid.Rows[4].Cells[3].Possibilities;
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
            t.XYWing();
            var expected = new List<int>() { 2,5 };
            var actual = t.Grid.Rows[1].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku1AV2()
        {
            Technique t = new Technique(Hodoku1);
            var actual =t.isXYWing("1;0", "0;2", "0;5");
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku1AV3()
        {
            Technique t = new Technique(Hodoku1);
            var actual = t.isXYWing("0;5", "0;2", "1;0");
            var expected = true;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void HodokuDEBUGA()
        {
            Technique t = new Technique(Hodoku1);
            var actual= t.isXYWing("1;0", "0;2", "0;5");
            var expected = true ;
           
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void HodokuDEBUGB()
        {
            Technique t = new Technique(Hodoku1);
            var actual = t.isXYWing("0;5", "0;2", "1;0");
            var expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku2A()
        {
            Technique t = new Technique(Hodoku2);

            t.XYWing();
            var expected = new List<int>() { 3, 6 };
            var actual = t.Grid.Rows[3].Cells[1].Possibilities;
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
            t.XYWing();
            var expected = new List<int>() { 1, 3, 7 };
            var actual = t.Grid.Rows[3].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku2C()
        {
            Technique t = new Technique(Hodoku2);
            t.XYWing();
            var expected = new List<int>() { 1, 5, 8 };
            var actual = t.Grid.Rows[4].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku2D()
        {
            Technique t = new Technique(Hodoku2);
            t.XYWing();
            var expected = new List<int>() { 8 };
            var actual = t.Grid.Rows[4].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku1A2()
        {
            Technique t = new Technique(Hodoku1);
            t.XYWing();
            var expected = new List<int>() { 2};
            var actual = t.Grid.Rows[0].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku2Dv2()
        {
            Technique t = new Technique(Hodoku2);
            var actual = t.isXYWing("3;0", "3;3", "4;1");
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku2Dv3()
        {
            Technique t = new Technique(Hodoku2);
            var actual = t.isXYWing("3;0", "4;1", "3;3");
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku2Dv43()
        {
            Technique t = new Technique(Hodoku2);
            var actual = t.isXYWing("3;3", "4;1", "3;0");
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku2Dv44()
        {
            Technique t = new Technique(Hodoku2);
            var actual = t.isXYWing("4;1", "3;0", "3;3");
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku2Dv45()
        {
            Technique t = new Technique(Hodoku2);
            var actual = t.isXYWing("3;3", "3;0", "4;1");
            var expected = true;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Hodoku2E()
        {
            Technique t = new Technique(Hodoku2);
            t.XYWing();
            var expected = new List<int>() { 5 };
            var actual = t.Grid.Rows[4].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku2FF()
        {
            Technique t = new Technique(Hodoku2);
            var expected = new List<int>() { 1,6 };
            var actual = t.Grid.Rows[3].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku2G()
        {
            Technique t = new Technique(Hodoku2);
            var expected = new List<int>() {1,9 };
            var actual = t.Grid.Rows[3].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }



        [TestMethod()]
        public void Hodoku2G2()
        {
            Technique t = new Technique(Hodoku2);
            var expected = new List<int>() { 1, 6 };
            var actual = t.Grid.Rows[3].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Hodoku2HH()
        {
            Technique t = new Technique(Hodoku2);
            var expected = new List<int>() { 6, 9 };
            var actual = t.Grid.Rows[4].Cells[1].Possibilities;
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
            t.Grid.RemovePossibility(2, 3, 4);
            t.XYWing();
            var expected = new List<int>() { 9 };
            var actual = t.Grid.Rows[6].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuDragon1A()
        {
            Technique t = new Technique(SudokuDragon1);
            t.XYWing();
            var expected = new List<int>() { 1, 8, 9 };
            var actual = t.Grid.Rows[3].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuDragon1B()
        {
            Technique t = new Technique(SudokuDragon1);
            t.XYWing();
            var expected = new List<int>() { 1, 9 };
            var actual = t.Grid.Rows[4].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuDragon2A()
        {
            Technique t = new Technique(SudokuDragon2);
            t.XYWing();
            var expected = new List<int>() { 6, 7 };
            var actual = t.Grid.Rows[5].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsIntersect1A()
        {
            Technique t = new Technique(SudokuDragon2);
            var actual = t.IsIntersect("0;0", "0;1");
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsIntersect1B()
        {
            Technique t = new Technique(SudokuDragon2);
            var actual = t.IsIntersect("1;0", "1;1");
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsIntersect1C()
        {
            Technique t = new Technique(SudokuDragon2);
            var actual = t.IsIntersect("0;0", "0;8");
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsIntersect1D()
        {
            Technique t = new Technique(SudokuDragon2);
            var actual = t.IsIntersect("0;0", "8;8");
            var expected = false;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void IsIntersect1E()
        {
            Technique t = new Technique(SudokuDragon2);
            var actual = t.IsIntersect("0;0", "1;3");
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SharePoss1()
        {
            Technique t = new Technique(SudokuDragon2);
            var p1 = new List<int>() { 1, 2 };
            var p2 = new List<int>() { 2, 7 };
            var p3 = new List<int>() { 1, 7 };
            var actual = t.sharePossibilities(p1, p2, p3);
            var expected = true;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void SharePoss2()
        {
            Technique t = new Technique(SudokuDragon2);
            var p1 = new List<int>() { 4,6 };
            var p2 = new List<int>() { 6,8 };
            var p3 = new List<int>() { 4,8 };
            var actual = t.sharePossibilities(p1, p2, p3);
            var expected = true;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void SharePoss3()
        {
            Technique t = new Technique(SudokuDragon2);
            var p1 = new List<int>() { 5,8 };
            var p2 = new List<int>() { 2,5 };
            var p3 = new List<int>() { 2,8 };
            var actual = t.sharePossibilities(p1, p2, p3);
            var expected = true;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void SharePoss6()
        {
            Technique t = new Technique(SudokuDragon2);
            var p1 = new List<int>() { 2,5};
            var p2 = new List<int>() { 2,8 };
            var p3 = new List<int>() {5,8};
            var actual = t.sharePossibilities(p1, p2, p3);
            var expected = true;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void SharePoss7()
        {
            Technique t = new Technique(SudokuDragon2);
            var p1 = new List<int>() { 6,9};
            var p2 = new List<int>() { 1,6 };
            var p3 = new List<int>() {1,9};
            var actual = t.sharePossibilities(p1, p2, p3);
            var expected = true;
            Assert.AreEqual(expected, actual);

        }


        [TestMethod()]
        public void SharePossFalse1()
        {
            Technique t = new Technique(SudokuDragon2);
            var p1 = new List<int>() { 1,9 };
            var p2 = new List<int>() { 1,9};
            var p3 = new List<int>() { 2,9 };
            var actual = t.sharePossibilities(p1, p2, p3);
            var expected = false;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void SharePossFalse2()
        {
            Technique t = new Technique(SudokuDragon2);
            var p1 = new List<int>() { 1, 9 };
            var p2 = new List<int>() { 1, 2 };
            var p3 = new List<int>() { 1,2 };
            var actual = t.sharePossibilities(p1, p2, p3);
            var expected = false;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void SharePoss4()
        {
            Technique t = new Technique(SudokuDragon2);
            var p1 = new List<int>() { 2, 8 };
            var p2 = new List<int>() { 2, 5 };
            var p3 = new List<int>() { 2, 8 };
            var actual = t.sharePossibilities(p1, p2, p3);
            var expected = false;
            Assert.AreEqual(expected, actual);

        }


        [TestMethod()]
        public void SharePoss5()
        {
            Technique t = new Technique(SudokuDragon2);
            var p1 = new List<int>() { 5, 8 };
            var p2 = new List<int>() {3,4};
            var p3 = new List<int>() { 1,2};
            var actual = t.sharePossibilities(p1, p2, p3);
            var expected = false;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void SharePoss8()
        {
            Technique t = new Technique(SudokuDragon2);
            var p1 = new List<int>() { 3,7 };
            var p2 = new List<int>() { 3, 4 };
            var p3 = new List<int>() { 3,7};
            var actual = t.sharePossibilities(p1, p2, p3);
            var expected = false;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void IsValidXyWing1A()
        {
            Technique t = new Technique(SudokuOrg);
            var p = new List<string>(){ "0;2", "0;7", "1;8"};
            var actual = t.doCoordinatesFormAXYWing(p);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsValidXyWing1B()
        {
            Technique t = new Technique(SudokuOrg);
            var p = new List<string>() { "2;0", "2;3", "6;3" };
            var actual = t.doCoordinatesFormAXYWing(p);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsValidXyWingReverse()
        {
            Technique t = new Technique(SudokuOrg);
            var p = new List<string>() { "6;3", "2;3", "2;0" };
            var actual = t.doCoordinatesFormAXYWing(p);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsValidXyWing1C()
        {
            Technique t = new Technique(SudokuOrg);
            var p = new List<string>() { "1;0", "0;2","0;6" };
            var actual = t.doCoordinatesFormAXYWing(p);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsValidXyWing1D()
        {
            Technique t = new Technique(SudokuOrg);
            var p = new List<string>() { "1;0", "0;2", "0;5" };
            var actual = t.doCoordinatesFormAXYWing(p);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsValidXyWing1EE()
        {
            Technique t = new Technique(IronMonger2);
            var p = new List<string>() { "7;3", "7;8", "4;8" };
            var actual = t.isValidXYWing(p);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsValidXyWing1EEE()
        {
            Technique t = new Technique(SudokuOrg);
            var p = new List<string>() { "7;3", "7;7", "4;7" };
            var actual = t.doCoordinatesFormAXYWing(p);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsValidXyWing1E()
        {
            Technique t = new Technique(SudokuOrg);
            var p = new List<string>() { "0;6", "8;6", "6;7" };
            var actual = t.doCoordinatesFormAXYWing(p);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BlockIntersect()
        {
            Technique t = new Technique(SudokuOrg);
            var p1 = "3;3";
            var p2 = "4;1";
            var actual = t.FindIntersect(p1, p2);
            var expected = new List<string>() { "3;0", "3;1", "3;2", "4;3", "4;4", "4;5", };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsValidXyWing1F()
        {
            Technique t = new Technique(SudokuOrg);
            var p = new List<string>() { "5;7", "2;5", "2;5" };
            var actual = t.doCoordinatesFormAXYWing(p);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsValidXyWing1G()
        {
            Technique t = new Technique(SudokuOrg);
            var p = new List<string>() { "2;5", "2;5", "5;7" };
            var actual = t.doCoordinatesFormAXYWing(p);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsValidXyWing1FF()
        {
            Technique t = new Technique(SudokuOrg);
            var p = new List<string>() { "8;0", "7;2", "4;2" };
            var actual = t.doCoordinatesFormAXYWing(p);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsValidXyWing1GG()
        {
            Technique t = new Technique(SudokuOrg);
            var p = new List<string>() { "7;0", "0;0", "2;1" };
            var actual = t.doCoordinatesFormAXYWing(p);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsValidXyWing1H()
        {
            Technique t = new Technique(SudokuOrg);
            var p = new List<string>() { "0;0", "7;0", "2;1" };
            var actual = t.doCoordinatesFormAXYWing(p);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsValidXyWing1I()
        {
            Technique t = new Technique(SudokuOrg);
            var p = new List<string>() { "1;4", "8;4", "8;1" };
            var actual = t.doCoordinatesFormAXYWing(p);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsValidXyWing1J()
        {
            Technique t = new Technique(SudokuOrg);
            var p = new List<string>() { "1;4", "8;4", "7;2" };
            var actual = t.doCoordinatesFormAXYWing(p);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ImValidXWingCoordinates()
        {
            Technique t = new Technique(SudokuOrg);
            var p = new List<string>() { "0;0", "1;1", "2;2" };
            var actual = t.doCoordinatesFormAXYWing(p);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ImValidXWingCoordinates2()
        {
            Technique t = new Technique(SudokuOrg);
            var p = new List<string>() { "0;0", "3;1", "8;8" };
            var actual = t.doCoordinatesFormAXYWing(p);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void FindCommon1A()
        {
            Technique t = new Technique(SudokuOrg);
            var a = new List<int> { 1, 2 };
            var b = new List<int> { 1, 7 };
            var actual = t.findCommonPossibility(a, b);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindCommon1C()
        {
            Technique t = new Technique(SudokuOrg);
            var a = new List<int> { 3,5};
            var b = new List<int> { 1,3 };
            var actual = t.findCommonPossibility(a, b);
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindCommon1B()
        {
            Technique t = new Technique(SudokuOrg);
            var a = new List<int> { 4,6};
            var b = new List<int> { 4,8 };
            var actual = t.findCommonPossibility(a, b);
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void FindCommon1D()
        {
            Technique t = new Technique(SudokuOrg);
            var a = new List<int> { 2,5};
            var b = new List<int> { 2,7};
            var actual = t.findCommonPossibility(a, b);
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void FindCommon1E()
        {
            Technique t = new Technique(SudokuOrg);
            var a = new List<int> { 1,9 };
            var b = new List<int> { 2,9 };
            var actual = t.findCommonPossibility(a, b);
            var expected = 9;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void FindCommon1F()
        {
            Technique t = new Technique(SudokuOrg);
            var a = new List<int> { 4, 6 };
            var b = new List<int> { 3,5 };
            var actual = t.findCommonPossibility(a, b);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
    }