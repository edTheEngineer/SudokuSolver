
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.Techniques;
using System;
using System.Collections.Generic;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudokuTests.SudokuSolver.Techniques.Medium
{
    [TestClass()]
    public class BlockLineTests
    {
        public int[,] TectonicBefore { get; set; }
        public int[,] Kristanix { get; set; }

        public int[,] SudokuSnake { get; set; }

        public int[,] WordsUpRow { get; set; }

        public int[,] WordsUpColumn { get; set; }
        public BlockLineTests()
        {
           TectonicBefore = new[,]
            {
                {0,0,0,0,0,5,9,0,0},
                {0,5,0,9,0,0,0,1,0},
                {4,9,2,0,0,0,0,5,0},
                {9,7,4,1,0,6,0,0,0},
                {0,0,0,0,0,8,0,0,6},
                {6,0,0,3,5,7,0,0,0},
                {0,8,0,0,0,1,4,6,3},
                {0,0,1,0,0,0,5,0,7},
                {0,2,0,5,3,0,0,0,0},

            };
            Kristanix = new[,]
            {
                {0,0,0,0,7,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,2,0,1,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,9,0,6,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},

            };

           SudokuSnake = new[,]
{
                {4,0,2,0,0,8,0,3,0},
                {0,1,0,0,9,0,0,0,4},
                {6,0,0,4,0,0,0,0,0},
                {0,0,0,0,0,0,9,0,3},
                {0,0,8,0,0,0,0,2,5},
                {0,0,0,0,0,3,8,7,6},
                {0,4,0,6,0,0,0,0,1},
                {9,0,0,0,1,0,0,0,0},
                {1,0,5,0,0,7,0,0,2},

            };

            WordsUpRow = new[,]
{
                {1,2,4,7,0,0,0,0,8},
                {5,7,9,4,0,8,0,0,2},
                {3,8,6,0,0,0,7,4,5},
                {4,0,1,0,7,0,0,6,3},
                {0,0,0,0,0,0,0,0,7},
                {6,3,7,0,0,0,5,0,4},
                {9,1,0,0,0,0,2,7,6},
                {0,6,0,1,0,7,4,0,9},
                {7,4,0,0,0,9,0,5,1},

            };

            WordsUpColumn = new[,]
{
                {2,5,0,4,6,0,8,9,1},
                {6,0,8,5,0,9,2,0,7},
                {9,0,0,8,0,2,0,0,6},
                {0,2,4,0,8,0,0,0,0},
                {0,8,0,0,4,0,0,1,2},
                {0,0,0,0,2,0,4,8,0},
                {4,0,0,0,0,6,0,2,8},
                {5,6,2,3,0,8,0,7,4},
                {8,0,0,2,0,4,0,6,3},

            };

        }

        

        [TestMethod()]

        public void Kristanix4A()
        {
            Technique t = new Technique(Kristanix);
            t.BlockLine();
            var expected = new List<int>() {1,2,3,4,5,6,8,9};
            var actual = t.Grid.Rows[4].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Kristanix4B()
        {
            Technique t = new Technique(Kristanix);
            t.BlockLine();
            var expected = new List<int>() { 1, 2, 3, 4, 5, 6, 8, 9 };
            var actual = t.Grid.Rows[4].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Kristanix4C()
        {
            Technique t = new Technique(Kristanix);
            t.BlockLine();
            var expected = new List<int>() { 1, 2, 3, 4, 5, 6, 8, 9 };
            var actual = t.Grid.Rows[4].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Kristanix4D()
        {
            Technique t = new Technique(Kristanix);
            t.BlockLine();
            var expected = new List<int>() { 3,4,5,7,8,};
            var actual = t.Grid.Rows[4].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Kristanix4E()
        {
            Technique t = new Technique(Kristanix);
            t.BlockLine();
            var expected = new List<int>() { 3,4,5,8 };
            var actual = t.Grid.Rows[4].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Kristanix4F()
        {
            Technique t = new Technique(Kristanix);
            t.BlockLine();
            var expected = new List<int>() { 3,4,5,7,8 };
            var actual = t.Grid.Rows[4].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]

        public void Kristanix4G()
        {
            Technique t = new Technique(Kristanix);
            t.BlockLine();
            var expected = new List<int>() { 1, 2, 3, 4, 5, 6, 8, 9 };
            var actual = t.Grid.Rows[4].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Kristanix4H()
        {
            Technique t = new Technique(Kristanix);
            t.BlockLine();
            var expected = new List<int>() { 1, 2, 3, 4, 5, 6, 8, 9 };
            var actual = t.Grid.Rows[4].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Kristanix4I()
        {
            Technique t = new Technique(Kristanix);
            t.BlockLine();
            var expected = new List<int>() { 1, 2, 3, 4, 5, 6, 8, 9 };
            var actual = t.Grid.Rows[4].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuSnakePoint()
        {
            Technique t = new Technique(SudokuSnake);
            t.BlockLine();
            var expected = new List<int>() { 1,5,8 };
            var actual = t.Grid.Blocks[2].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void WordUpRow3A()
        {
            Technique t = new Technique(WordsUpRow);
            t.BlockLine();
            var expected = new List<int>() {3,5,6,9};
            var actual = t.Grid.Rows[4].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void WordUpRow3B()
        {
            Technique t = new Technique(WordsUpRow);
            t.BlockLine();
            var expected = new List<int>() { 1,3,4,5,6,9 };
            var actual = t.Grid.Rows[4].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void WordUpRow3C()
        {
            Technique t = new Technique(WordsUpRow);
            t.BlockLine();
            var expected = new List<int>() { 1,3,4,5,6};
            var actual = t.Grid.Rows[4].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void WordUpRow3D()
        {
            Technique t = new Technique(WordsUpRow);
            t.BlockLine();
            var expected = new List<int>() { 1,9 };
            var actual = t.Grid.Rows[4].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void WordUpCol4A()
        {
            Technique t = new Technique(WordsUpColumn);
            t.BlockLine();
            var expected = new List<int>() { 5,7,9 };
            var actual = t.Grid.Columns[4].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void WordUpCol4B()
        {
            Technique t = new Technique(WordsUpColumn);
            t.BlockLine();
            var expected = new List<int>() { 9 };
            var actual = t.Grid.Columns[4].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void WordUpCol4C()
        {
            Technique t = new Technique(WordsUpColumn);
            t.BlockLine();
            var expected = new List<int>() { 5,7, 9 };
            var actual = t.Grid.Columns[4].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}