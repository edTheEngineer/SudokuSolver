
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.Techniques;
using System;
using System.Collections.Generic;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudokuTests.SudokuSolver.Techniques
{
    [TestClass()]
    public class NakedQuadTests
    {
        public int[,] SudokuSolverApp { get; set; }

        public int[,] SudokuOrg{ get; set; }

        public int[,] Sudoku9981 { get; set; }

        public int[,] PuzzleMystery { get; set; }

        public int[,] Thonky { get; set; }

        public int[,] SudokuOfTheDay { get; set; }

        public int[,] SudokuApp { get; set; }

        public int[,] QuatrianRow { get; set; }

        public int[,] QuatrianColumn { get; set; }

        public int[,] QuatrianBox { get; set; }


        public int[,] ManifestMaster { get; set; }

        public NakedQuadTests()
        {
            SudokuSolverApp = new[,]
            {
                {0,9,5,6,0,0,0,0,7},
                {7,1,2,0,4,0,0,0,6},
                {0,0,0,0,0,0,0,0,0},
                {0,4,0,0,1,0,0,0,0},
                {0,0,1,9,0,7,2,0,4},
                {2,0,0,4,6,8,0,1,9},
                {0,2,0,0,0,6,0,0,5},
                {0,0,0,0,0,0,9,0,2},
                {0,8,0,5,0,0,0,7,1},

            };

            SudokuOrg = new[,]
{
                {0,4,3,5,1,0,2,8,0},
                {0,0,0,4,3,8,0,0,0},
                {8,0,0,9,2,0,3,0,4},
                {0,3,4,0,7,1,5,2,0},
                {0,0,8,3,5,0,6,0,0},
                {0,5,1,0,9,0,0,3,0},
                {4,0,0,7,8,3,0,0,2},
                {0,8,0,1,6,9,0,0,0},
                {0,0,7,2,4,5,8,0,0},

            };

            Sudoku9981 = new[,]
{
                {0,9,4,0,3,6,2,0,0},
                {0,7,0,0,0,0,4,3,5},
                {0,3,0,4,0,0,0,0,0},
                {0,0,0,8,0,1,5,0,0},
                {0,2,0,0,4,0,0,0,0},
                {7,8,0,0,0,0,1,4,6},
                {8,0,0,0,5,7,9,0,4},
                {0,0,7,0,0,4,3,0,0},
                {0,0,0,0,0,2,0,0,7},

            };

            PuzzleMystery = new[,]
{
                {2,0,1,0,0,0,0,0,0},
                {0,0,0,0,4,1,0,3,0},
                {0,0,0,0,9,2,0,0,0},
                {6,0,0,1,3,7,0,0,0},
                {0,0,0,2,5,4,0,0,0},
                {0,3,0,0,0,0,0,4,0},
                {0,0,0,0,0,0,7,0,1},
                {0,5,0,8,0,0,0,0,0},
                {0,0,0,0,0,0,2,0,0},

            };

            Thonky = new[,]
{
                {2,0,9,4,0,1,8,7,0},
                {0,0,7,0,0,0,2,1,0},
                {8,1,3,0,0,5,4,9,6},
                {1,0,2,0,0,4,5,3,8},
                {0,0,0,0,0,0,9,6,4},
                {4,0,6,0,0,0,7,2,1},
                {0,0,0,1,0,3,6,8,2},
                {0,0,0,0,0,0,1,4,7},
                {7,0,0,0,0,0,3,5,9},


            };

            SudokuOfTheDay = new[,]
{
                {6,2,4,9,0,0,0,0,0},
                {7,3,9,1,0,0,0,0,8},
                {8,1,5,0,0,4,0,0,0},
                {4,0,0,0,0,9,3,7,0},
                {3,0,0,0,4,0,0,0,6},
                {5,9,1,0,0,3,0,0,2},
                {9,0,0,4,0,0,2,0,0},
                {1,0,0,2,9,6,0,0,4},
                {2,4,8,3,5,7,1,6,9},


            };

            SudokuApp = new[,]
{
                {0,5,0,0,6,8,0,0,0},
                {0,0,0,0,0,0,2,0,0},
                {0,0,0,9,0,5,0,0,0},
                {0,9,1,8,5,4,6,0,3},
                {3,8,0,0,0,6,4,0,0},
                {5,4,6,0,0,0,0,1,8},
                {0,0,4,6,0,1,5,0,0},
                {0,6,3,5,8,0,0,0,0},
                {0,0,5,0,0,0,0,6,9},


            };

            QuatrianBox = new[,]
{
                {0,0,0,0,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,2},
                {0,1,0,0,3,4,7,0,5},
                {0,0,0,3,0,0,1,5,7},
                {0,4,1,6,0,0,8,2,3},
                {3,7,0,0,0,0,6,4,9},
                {0,9,0,8,5,3,2,1,6},
                {8,3,6,1,9,2,5,7,4},
                {1,5,2,4,0,0,9,3,8},


            };

            QuatrianRow = new[,]
{
                {0,6,0,0,0,0,0,5,4},
                {0,4,0,0,0,0,0,1,2},
                {1,0,3,2,4,5,0,0,6},
                {0,0,0,0,0,0,4,0,0},
                {4,1,0,0,0,0,6,0,0},
                {7,2,6,8,0,4,1,0,5},
                {0,0,1,4,6,0,0,0,0},
                {0,0,4,0,0,0,5,6,1},
                {6,9,0,1,5,0,0,4,7},


            };

            QuatrianColumn = new[,]
{
                {0,0,2,0,0,6,0,0,0},
                {0,0,0,0,0,1,0,2,3},
                {0,0,4,2,5,0,6,0,0},
                {0,0,0,1,2,0,0,0,9},
                {4,0,0,6,7,0,5,1,2},
                {1,2,0,0,0,0,7,8,6},
                {0,0,1,0,6,2,0,0,4},
                {2,0,7,0,0,0,0,6,0},
                {5,0,6,0,0,0,2,0,0},


            };

            ManifestMaster = new[,]
{
                {0,0,0,0,9,0,0,0,0},
                {0,0,0,0,3,1,6,0,0},
                {0,0,0,0,4,8,0,9,0},
                {7,1,9,8,6,3,4,5,2},
                {6,0,0,0,7,0,0,3,0},
                {2,0,0,0,1,0,7,6,0},
                {1,0,0,0,2,0,0,8,6},
                {8,6,0,0,5,9,2,0,0},
                {0,7,0,1,8,6,0,4,5},


            };
        }

        [TestMethod()]
        public void SudokuSolverAppTest1A()
        {
            Technique t = new Technique(SudokuSolverApp);
            t.NakedQuad();
            var expected = new List<int>() { 1,2,7};
            var actual = t.Grid.Rows[2].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSolverAppTest1B()
        {
            Technique t = new Technique(SudokuSolverApp);
            t.NakedQuad();
            var expected = new List<int>() { 1, 2, 7 };
            var actual = t.Grid.Columns[3].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSolverAppTest1C()
        {
            Technique t = new Technique(SudokuSolverApp);
            t.NakedQuad();
            var expected = new List<int>() { 1, 2, 7 };
            var actual = t.Grid.Blocks[1].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSolverAppTest1D()
        {
            Technique t = new Technique(SudokuSolverApp);
            t.NakedQuad();
            var expected = new List<int>() {2,5,7,9 };
            var actual = t.Grid.Rows[2].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSolverAppTest1E()
        {
            Technique t = new Technique(SudokuSolverApp);
            t.NakedQuad();
            var expected = new List<int>() { 1,2,5,9 };
            var actual = t.Grid.Rows[2].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSolverAppTest1F()
        {
            Technique t = new Technique(SudokuSolverApp);
            t.NakedQuad();
            var expected = new List<int>() { 1,5 };
            var actual = t.Grid.Rows[2].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSolverAppTest1G()
        {
            Technique t = new Technique(SudokuSolverApp);
            t.NakedQuad();
            var expected = new List<int>() { 3,8};
            var actual = t.Grid.Rows[2].Cells[8].Possibilities;
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
            t.NakedQuad();
            var expected = new List<int>() { 1,5 };
            var actual = t.Grid.Columns[0].Cells[1].Possibilities;
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
            t.NakedQuad();
            var expected = new List<int>() { 3,5};
            var actual = t.Grid.Columns[0].Cells[7].Possibilities;
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
            t.NakedQuad();
            var expected = new List<int>() { 1, 3};
            var actual = t.Grid.Columns[0].Cells[8].Possibilities;
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
            t.NakedQuad();
            var expected = new List<int>() { 1, 5 };
            var actual = t.Grid.Columns[0].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOrg1E_DOUBLE()
        {
            Technique t = new Technique(SudokuOrg);
            t.NakedQuad();
            t.NakedQuad();
            var expected = new List<int>() {2};
            var actual = t.Grid.Columns[2].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Sudoku9981_1A()
        {
            Technique t = new Technique(Sudoku9981);
            t.NakedQuad();
            var expected = new List<int>() {6,7 };
            var actual = t.Grid.Blocks[4].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Sudoku9981_1B()
        {
            Technique t = new Technique(Sudoku9981);
            t.NakedQuad();
            var expected = new List<int>() { 6, 7 };
            var actual = t.Grid.Blocks[4].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PuzzleMystery1A()
        {
            Technique t = new Technique(PuzzleMystery);
            t.NakedQuad();
            var expected = new List<int>() { 1, 7 };
            var actual = t.Grid.Rows[7].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PuzzleMystery1B()
        {
            Technique t = new Technique(PuzzleMystery);
            t.NakedQuad();
            var expected = new List<int>() { 2, 7 };
            var actual = t.Grid.Rows[7].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PuzzleMystery1C()
        {
            Technique t = new Technique(PuzzleMystery);
            t.NakedQuad();
            var expected = new List<int>() { 1, 2,7 };
            var actual = t.Grid.Rows[7].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }



        [TestMethod()]
        public void PuzzleMystery1D()
        {
            Technique t = new Technique(PuzzleMystery);
            t.NakedQuad();
            var expected = new List<int>() { 3,6,9};
            var actual = t.Grid.Rows[7].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PuzzleMystery1E()
        {
            Technique t = new Technique(PuzzleMystery);
            t.NakedQuad();
            var expected = new List<int>() { 3,4,6,9 };
            var actual = t.Grid.Rows[7].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PuzzleMystery1F()
        {
            Technique t = new Technique(PuzzleMystery);
            t.NakedQuad();
            var expected = new List<int>() {6,9 };
            var actual = t.Grid.Rows[7].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PuzzleMystery1G()
        {
            Technique t = new Technique(PuzzleMystery);
            t.NakedQuad();
            var expected = new List<int>() {3,4,6,9 };
            var actual = t.Grid.Rows[7].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Thonk1A()
        {
            Technique t = new Technique(Thonky);
            t.NakedQuad();
            var expected = new List<int>() { 3,6 };
            var actual = t.Grid.Blocks[6].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Thonk1B()
        {
            Technique t = new Technique(Thonky);
            t.NakedQuad();
            var expected = new List<int>() {2, 3, 6 };
            var actual = t.Grid.Blocks[6].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Thonk1C()
        {
            Technique t = new Technique(Thonky);
            t.NakedQuad();
            var expected = new List<int>() { 2, 6 };
            var actual = t.Grid.Blocks[6].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Thonk1D()
        {
            Technique t = new Technique(Thonky);
            t.NakedQuad();
            var expected = new List<int>() { 1 };
            var actual = t.Grid.Blocks[6].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Thonk1E()
        {
            Technique t = new Technique(Thonky);
            t.NakedQuad();
            var expected = new List<int>() {1};
            var actual = t.Grid.Rows[8].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDay1A()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.NakedQuad();
            var expected = new List<int>() { 4,6 };
            var actual = t.Grid.Blocks[2].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuOfTheDay1B()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.NakedQuad();
            var expected = new List<int>() { 2,4};
            var actual = t.Grid.Blocks[2].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuOfTheDay1C()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.NakedQuad();
            var expected = new List<int>() {6,9 };
            var actual = t.Grid.Blocks[2].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuOfTheDay1D()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.NakedQuad();
            var expected = new List<int>() { 2,9};
            var actual = t.Grid.Blocks[2].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuApp1A()
        {
            Technique t = new Technique(SudokuApp);
            t.NakedQuad();
            var expected = new List<int>() { 6,8,9 };
            var actual = t.Grid.Rows[1].Cells[0].Possibilities;
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
            t.NakedQuad();
            var expected = new List<int>() {  8, 9 };
            var actual = t.Grid.Rows[1].Cells[2].Possibilities;
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
            t.NakedQuad();
            var expected = new List<int>() { 5, 8, 9 };
            var actual = t.Grid.Rows[1].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuApp1D()
        {
            Technique t = new Technique(SudokuApp);
            t.NakedQuad();
            var expected = new List<int>() { 5,6 };
            var actual = t.Grid.Rows[1].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuatrianBox1A()
        {
            Technique t = new Technique(QuatrianBox);
            t.NakedQuad();
            var expected = new List<int>() {4, 5, 7 };
            var actual = t.Grid.Blocks[0].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuatrianBox1B()
        {
            Technique t = new Technique(QuatrianBox);
            t.NakedQuad();
            var expected = new List<int>() { 3,4,5, 7 };
            var actual = t.Grid.Blocks[0].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuatrianBox1C()
        {
            Technique t = new Technique(QuatrianBox);
            t.NakedQuad();
            var expected = new List<int>() { 4,5,7};
            var actual = t.Grid.Blocks[0].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuatrianBox1D()
        {
            Technique t = new Technique(QuatrianBox);
            t.NakedQuad();
            var expected = new List<int>() { 3,4,5,7};
            var actual = t.Grid.Blocks[0].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuatrianBox1E()
        {
            Technique t = new Technique(QuatrianBox);
            t.NakedQuad();
            var expected = new List<int>() {2,6,8 };
            var actual = t.Grid.Blocks[0].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuatrianBox1F()
        {
            Technique t = new Technique(QuatrianBox);
            t.NakedQuad();
            var expected = new List<int>() {6,8 };
            var actual = t.Grid.Blocks[0].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuatrianBox1G()
        {
            Technique t = new Technique(QuatrianBox);
            t.NakedQuad();
            var expected = new List<int>() { 2,6,9};
            var actual = t.Grid.Blocks[0].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuatrianBox1H()
        {
            Technique t = new Technique(QuatrianBox);
            t.NakedQuad();
            var expected = new List<int>() { 8,9 };
            var actual = t.Grid.Blocks[0].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuatrianRow1A()
        {
            Technique t = new Technique(QuatrianRow);
            t.NakedQuad();
            var expected = new List<int>() { 6, 7 };
            var actual = t.Grid.Blocks[4].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuatrianRow1B()
        {
            Technique t = new Technique(QuatrianRow);
            t.NakedQuad();
            var expected = new List<int>() { 1, 2, 7 };
            var actual = t.Grid.Blocks[4].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuatrianRow1C()
        {
            Technique t = new Technique(QuatrianRow);
            t.NakedQuad();
            var expected = new List<int>() { 1,2,6,7};
            var actual = t.Grid.Blocks[4].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuatrianColumn1A()
        {
            Technique t = new Technique(QuatrianColumn);
            t.NakedQuad();
            var expected = new List<int>() { 1,5,7 };
            var actual = t.Grid.Columns[1].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuatrianColumn1B()
        {
            Technique t = new Technique(QuatrianColumn);
            t.NakedQuad();
            var expected = new List<int>() { 5,6,7};
            var actual = t.Grid.Columns[1].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuatrianColumn1C()
        {
            Technique t = new Technique(QuatrianColumn);
            t.NakedQuad();
            var expected = new List<int>() { 1,7 };
            var actual = t.Grid.Columns[1].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Manifest1A()
        {
            Technique t = new Technique(ManifestMaster);
            t.NakedQuad();
            var expected = new List<int>() { 1,2,6, 7 };
            var actual = t.Grid.Columns[2].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Manifest1B()
        {
            Technique t = new Technique(ManifestMaster);
            t.NakedQuad();
            var expected = new List<int>() {  2, 7 };
            var actual = t.Grid.Columns[2].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Manifest1C()
        {
            Technique t = new Technique(ManifestMaster);
            t.NakedQuad();
            var expected = new List<int>() { 1, 2, 6,7 };
            var actual = t.Grid.Columns[2].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Manifest1D()
        {
            Technique t = new Technique(ManifestMaster);
            t.NakedQuad();
            var expected = new List<int>() { 4,5,8 };
            var actual = t.Grid.Columns[2].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Manifest1E()
        {
            Technique t = new Technique(ManifestMaster);
            t.NakedQuad();
            var expected = new List<int>() {3, 4, 5, 8 };
            var actual = t.Grid.Columns[2].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Manifest1F()
        {
            Technique t = new Technique(ManifestMaster);
            t.NakedQuad();
            var expected = new List<int>() { 3,4,5};
            var actual = t.Grid.Columns[2].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Manifest1G()
        {
            Technique t = new Technique(ManifestMaster);
            t.NakedQuad();
            var expected = new List<int>() { 3,4 };
            var actual = t.Grid.Columns[2].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NotSameA()
        {
            Technique t = new Technique(ManifestMaster);
            var actual = t.DifferentIndex(1, 1, 2, 3);
            var expected = false;
            
          Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NotSameB()
        {
            Technique t = new Technique(ManifestMaster);
            var actual = t.DifferentIndex(1, 1, 1, 3);
            var expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NotSameC()
        {
            Technique t = new Technique(ManifestMaster);
            var actual = t.DifferentIndex(1, 1, 1, 1);
            var expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SameD()
        {
            Technique t = new Technique(ManifestMaster);
            var actual = t.DifferentIndex(1, 2,3,4);
            var expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NotSameD()
        {
            Technique t = new Technique(ManifestMaster);
            var actual = t.DifferentIndex(1,2,3,4);
            var expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrderFour()
        {
            Technique t = new Technique(ManifestMaster);
            t.orderFour(1, 2, 3, 4, out int smallest, out int middleA, out int middleB, out int biggest);
            var expected = 1;
            var actual = smallest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrderFourB()
        {
            Technique t = new Technique(ManifestMaster);
            t.orderFour(1, 2, 3, 4, out int smallest, out int middleA, out int middleB, out int biggest);
            var expected = 2;
            var actual = middleA;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrderFourC()
        {
            Technique t = new Technique(ManifestMaster);
            t.orderFour(1, 2, 3, 4, out int smallest, out int middleA, out int middleB, out int biggest);
            var expected = 3;
            var actual = middleB;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrderFourD()
        {
            Technique t = new Technique(ManifestMaster);
            t.orderFour(1, 2, 3, 4, out int smallest, out int middleA, out int middleB, out int biggest);
            var expected = 4;
            var actual = biggest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrderFourE()
        {
            Technique t = new Technique(ManifestMaster);
            t.orderFour(4,3,2,1, out int smallest, out int middleA, out int middleB, out int biggest);
            var expected = 1;
            var actual = smallest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrderFourF()
        {
            Technique t = new Technique(ManifestMaster);
            t.orderFour(4,3,2,1, out int smallest, out int middleA, out int middleB, out int biggest);
            var expected = 2;
            var actual = middleA;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrderFourG()
        {
            Technique t = new Technique(ManifestMaster);
            t.orderFour(4,3,2,1, out int smallest, out int middleA, out int middleB, out int biggest);
            var expected = 3;
            var actual = middleB;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrderFourH()
        {
            Technique t = new Technique(ManifestMaster);
            t.orderFour(4,3,2,1, out int smallest, out int middleA, out int middleB, out int biggest);
            var expected = 4;
            var actual = biggest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrderFourI()
        {
            Technique t = new Technique(ManifestMaster);
            t.orderFour(2,1,4,3, out int smallest, out int middleA, out int middleB, out int biggest);
            var expected = 1;
            var actual = smallest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrderFourJ()
        {
            Technique t = new Technique(ManifestMaster);
            t.orderFour(2,1,4,3, out int smallest, out int middleA, out int middleB, out int biggest);
            var expected = 2;
            var actual = middleA;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrderFourK()
        {
            Technique t = new Technique(ManifestMaster);
            t.orderFour(2,1,4,3, out int smallest, out int middleA, out int middleB, out int biggest);
            var expected = 3;
            var actual = middleB;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrderFourL()
        {
            Technique t = new Technique(ManifestMaster);
            t.orderFour(2,1,4,3, out int smallest, out int middleA, out int middleB, out int biggest);
            var expected = 4;
            var actual = biggest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrderFourM()
        {
            Technique t = new Technique(ManifestMaster);
            t.orderFour(3, 1,2, 4, out int smallest, out int middleA, out int middleB, out int biggest);
            var expected = 1;
            var actual = smallest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrderFourN()
        {
            Technique t = new Technique(ManifestMaster);
            t.orderFour(3, 1, 2, 4, out int smallest, out int middleA, out int middleB, out int biggest);
            var expected = 2;
            var actual = middleA;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrderFourO()
        {
            Technique t = new Technique(ManifestMaster);
            t.orderFour(3, 1, 2, 4, out int smallest, out int middleA, out int middleB, out int biggest);
            var expected = 3;
            var actual = middleB;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrderFourP()
        {
            Technique t = new Technique(ManifestMaster);
            t.orderFour(3, 1, 2, 4, out int smallest, out int middleA, out int middleB, out int biggest);
            var expected = 4;
            var actual = biggest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuads()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 3 };
            var b = new List<int>() { 2 };
            var c = new List<int>() { 1 };
            var d = new List<int>() { 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = isNakedQuad;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsB()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1,2,3,4 };
            var b = new List<int>() { 1,2,3,4 };
            var c = new List<int>() { 1,2,3,4 };
            var d = new List<int>() { 1,2,3,4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = isNakedQuad;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBTopMissing()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3,4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = isNakedQuad;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBSecondMissing()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3,4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = isNakedQuad;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBThirdMissing()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 3, 4 };
            var d = new List<int>() { 1, 2, 3,4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = isNakedQuad;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsFourtMissing()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3,4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = isNakedQuad;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBTwoNaked()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2};
            var b = new List<int>() { 1, 2};
            var c = new List<int>() { 3, 4 };
            var d = new List<int>() { 3,4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = isNakedQuad;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBFive()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4,5 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3,4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = isNakedQuad;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBSix()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 5,6 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = isNakedQuad;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBSeven()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 5,6,7, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = isNakedQuad;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBEight()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4, 5 };
            var b = new List<int>() { 1, 2, 3, 4,6};
            var c = new List<int>() { 1, 2, 3, 4 ,7};
            var d = new List<int>() { 1, 2, 3, 4 ,8};
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = isNakedQuad;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsAll()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4, 5 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 6,7,8,9 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = isNakedQuad;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBThree()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3};
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 1, 2, 3};
            var d = new List<int>() { };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = isNakedQuad;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsTwo()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1,2};
            var b = new List<int>() { 3,4 };
            var c = new List<int>() {  };
            var d = new List<int>() {  };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = isNakedQuad;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        //FIRST

        [TestMethod()]
        public void CompareQuads_No1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 3 };
            var b = new List<int>() { 2 };
            var c = new List<int>() { 1 };
            var d = new List<int>() { 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsB_No()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBTopMissing_No1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBSecondMissing_No1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBThirdMissing_No1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsFourtMissing_No1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBTwoNaked_No1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { 3, 4 };
            var d = new List<int>() { 3,4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBFive_No1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4, 5 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = first;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBSix_No1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 5, 6 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = first;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBSeven_No1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 5, 6, 7, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = first;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBEight_No1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4, 5 };
            var b = new List<int>() { 1, 2, 3, 4, 6 };
            var c = new List<int>() { 1, 2, 3, 4, 7 };
            var d = new List<int>() { 1, 2, 3, 4, 8 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = first;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsAll_No1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4, 5 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 6, 7, 8, 9 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = first;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBThree_No1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 1, 2, 3 };
            var d = new List<int>() { };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = first;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsTwo_No1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 3, 4 };
            var c = new List<int>() { };
            var d = new List<int>() { };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = first;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        //SECOND

        [TestMethod()]
        public void CompareQuads_Second()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 3 };
            var b = new List<int>() { 2 };
            var c = new List<int>() { 1 };
            var d = new List<int>() { 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsB_Second()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBTopMissing_Second()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBSecondMissing_Second()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBThirdMissing_Second()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsFourtMissing_Second()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBTwoNaked_Second()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { 3, 4 };
            var d = new List<int>() { 3,4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBFive_Second()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4, 5 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = second;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBSix_Second()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 5, 6 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = second;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBSeven_Second()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 5, 6, 7, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = second;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBEight_Second()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4, 5 };
            var b = new List<int>() { 1, 2, 3, 4, 6 };
            var c = new List<int>() { 1, 2, 3, 4, 7 };
            var d = new List<int>() { 1, 2, 3, 4, 8 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = second;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsAll_Second()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4, 5 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 6, 7, 8, 9 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = second;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBThree_Second()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 1, 2, 3 };
            var d = new List<int>() { };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = second;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsTwo_Second()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 3, 4 };
            var c = new List<int>() { };
            var d = new List<int>() { };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = second;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        //THIRD

        [TestMethod()]
        public void CompareQuads_Third()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 3 };
            var b = new List<int>() { 2 };
            var c = new List<int>() { 1 };
            var d = new List<int>() { 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsB_Third()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBTopMissing_Third()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBSecondMissing_Third()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBThirdMissing_Third()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsFourtMissing_Third()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBTwoNaked_Third()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { 3, 4 };
            var d = new List<int>() { 3,4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBFive_Third()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4, 5 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = third;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBSix_Third()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 5, 6 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = third;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBSeven_Third()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 5, 6, 7, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = third;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBEight_Third()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4, 5 };
            var b = new List<int>() { 1, 2, 3, 4, 6 };
            var c = new List<int>() { 1, 2, 3, 4, 7 };
            var d = new List<int>() { 1, 2, 3, 4, 8 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = third;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsAll_Third()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4, 5 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 6, 7, 8, 9 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = third;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBThree_Third()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 1, 2, 3 };
            var d = new List<int>() { };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = third;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsTwo_Third()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 3, 4 };
            var c = new List<int>() { };
            var d = new List<int>() { };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = third;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        //FOURTH

        [TestMethod()]
        public void CompareQuads_Fourth()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 3 };
            var b = new List<int>() { 2 };
            var c = new List<int>() { 1 };
            var d = new List<int>() { 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = fourth;
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsB_Fourth()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = fourth;
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBTopMissing_Fourth()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = fourth;
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBSecondMissing_Fourth()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = fourth;
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBThirdMissing_Fourth()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = fourth;
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsFourtMissing_Fourth()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = fourth;
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBTwoNaked_Fourth()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { 3, 4 };
            var d = new List<int>() { 3,4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = fourth;
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBFive_Fourth()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4, 5 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = fourth;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBSix_Fourth()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 5, 6 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = fourth;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBSeven_Fourth()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 1, 2, 3, 4 };
            var d = new List<int>() { 5, 6, 7, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = fourth;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBEight_Fourth()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4, 5 };
            var b = new List<int>() { 1, 2, 3, 4, 6 };
            var c = new List<int>() { 1, 2, 3, 4, 7 };
            var d = new List<int>() { 1, 2, 3, 4, 8 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = fourth;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsAll_Fourth()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3, 4, 5 };
            var b = new List<int>() { 1, 2, 3, 4 };
            var c = new List<int>() { 6, 7, 8, 9 };
            var d = new List<int>() { 1, 2, 3, 4 };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = fourth;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsBThree_Fourth()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 1, 2, 3 };
            var d = new List<int>() { };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = fourth;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareQuadsTwo_Fourth()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 3, 4 };
            var c = new List<int>() { };
            var d = new List<int>() { };
            t.compareListsQuads(a, b, c, d, out bool isNakedQuad, out int first, out int second, out int third, out int fourth);
            var actual = fourth;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SplitFourA()
        {
            Technique t = new Technique(Thonky);
            t.SplitFourCoordinate("1;2;3;4", out int a, out int b, out int c, out int d);
            var actual = a;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SplitFourB()
        {
            Technique t = new Technique(Thonky);
            t.SplitFourCoordinate("1;2;3;4", out int a, out int b, out int c, out int d);
            var actual = b;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SplitFourC()
        {
            Technique t = new Technique(Thonky);
            t.SplitFourCoordinate("1;2;3;4", out int a, out int b, out int c, out int d);
            var actual = c;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SplitFourD()
        {
            Technique t = new Technique(Thonky);
            t.SplitFourCoordinate("1;2;3;4", out int a, out int b, out int c, out int d);
            var actual = d;
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }
    }
}

