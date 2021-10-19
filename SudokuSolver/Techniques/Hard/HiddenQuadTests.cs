using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.Techniques;
using System;
using System.Collections.Generic;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudokuTests.SudokuSolver.Techniques
{
    [TestClass()]
    public class HiddenQuadTests
    {
        public int[,] SudokuWiki { get; set; }
        public int[,] SudokuWiki2 { get; set; }
        public int[,] LearnSudoku{ get; set; }

        public int[,] Sudoku9981 { get; set; }

        public int[,] SudokuSolver { get; set; }

        public int[,] Quatrian1 { get; set; }

        public int[,] Quatrian2 { get; set; }

        public int[,] Quatrian3 { get; set; }
        public HiddenQuadTests()
        {
            SudokuWiki = new[,]
            {
                {6,5,0,0,8,7,0,2,4},
                {0,0,0,6,4,9,0,5,3},
                {9,4,0,0,2,5,0,7,0},
                {5,7,0,4,3,8,0,6,1},
                {0,0,0,5,0,1,0,0,0},
                {3,1,0,9,0,2,0,8,5},
                {0,0,0,8,9,0,0,1,0},
                {0,0,0,2,1,3,0,0,0},
                {1,3,4,7,5,0,0,9,8},

            };

            SudokuWiki2 = new[,]
{
                {9,0,1,5,0,0,0,4,6},
                {4,2,5,0,9,0,0,8,1},
                {8,6,0,0,1,0,0,2,0},
                {5,0,2,0,0,0,0,0,0},
                {0,1,9,0,0,0,4,6,0},
                {6,0,0,0,0,0,0,0,2},
                {1,9,6,0,4,0,2,5,3},
                {2,0,0,0,6,0,8,1,7},
                {0,0,0,0,0,1,6,9,4},

            };

            LearnSudoku = new[,]
{

{0,0,0,3,7,4,2,0,0},
{0,0,0,0,8,2,0,4,0},
{0,0,0,0,0,0,0,0,0},
{0,0,0,0,3,0,8,2,6},
{6,0,0,0,9,0,0,0,4},
{8,0,5,0,4,6,9,7,0},
{5,4,7,0,2,0,0,0,9},
{0,0,0,0,0,0,4,0,5},
{0,1,0,4,5,0,7,8,2},
            };

            Sudoku9981 = new[,]
{

{6,3,2,1,4,5,9,7,8 },
{8,1,0,0,9,0,0,0,4},
{0,4,0,0,8,0,0,1,0},
{0,0,0,8,5,0,0,0,0},
{1,6,0,2,7,4,0,0,0},
{0,0,0,9,6,0,0,0,0},
{4,8,1,5,2,9,0,6,0},
{7,5,3,4,1,6,0,0,9},
{2,9,6,7,3,8,0,4,0},
            };

            SudokuSolver = new[,]
{

{0,4,8,3,9,7,0,0,0 },
{2,6,0,0,8,5,0,9,0},
{0,9,0,0,2,6,0,0,0},
{7,0,2,8,6,3,0,4,9},
{9,8,4,5,1,2,0,7,0},
{0,3,6,9,7,4,0,0,0},
{4,0,9,7,3,8,0,6,0},
{8,2,0,6,0,9,0,3,7},
{6,7,3,2,0,1,9,8,0},
            };

            Quatrian1 = new[,]
{

{0,3,0,0,0,7,0,9,5},
{0,5,0,0,0,1,0,0,0},
{8,6,0,0,2,0,0,0,0},
{0,2,0,0,7,3,0,0,8},
{5,0,0,0,0,0,0,6,0},
{0,0,3,0,0,4,9,0,0},
{3,0,5,0,0,0,4,1,7},
{2,4,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0},
            };

            Quatrian2 = new[,]
{

{0,0,0,0,0,0,0,0,1},
{0,0,0,0,1,0,0,0,2},
{0,0,0,6,3,4,9,0,5},
{0,0,0,3,0,9,0,5,6},
{0,0,3,8,6,0,0,4,9},
{6,7,9,1,4,5,8,2,3},
{0,0,0,2,5,1,6,3,8},
{1,2,6,7,8,3,5,9,4},
{8,3,5,4,9,6,2,1,7},
            };

            Quatrian3 = new[,]
{

{8,0,7,3,0,2,9,4,1},
{9,0,1,0,0,8,0,2,3},
{2,3,4,1,0,5,0,0,0},
{4,0,0,0,0,6,0,0,0},
{6,7,0,0,0,1,0,0,0},
{1,2,0,0,3,9,0,0,0},
{3,0,0,2,1,4,0,7,0},
{7,1,6,9,5,3,4,8,2},
{5,4,2,6,8,7,0,0,9},
            };
        }

        [TestMethod()]
        public void SudokuWiki1A()
        {
            Technique t = new Technique(SudokuWiki);
            var before = t.Grid.Columns[6].Cells[6].Possibilities;
            foreach(var x in before)
            {
                Console.WriteLine(x + "#");
            }
            t.HiddenQuads();
            var expected = new List<int>() { 3,4,5,7 };
            var actual = t.Grid.Columns[6].Cells[6].Possibilities;
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
            var before = t.Grid.Columns[6].Cells[7].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + "#");
            }
            t.HiddenQuads();
            var expected = new List<int>() { 4, 5, 7 };
            var actual = t.Grid.Columns[6].Cells[7].Possibilities;
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
            var before = t.Grid.Rows[7].Cells[6].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + "#");
            }
            t.HiddenQuads();
            var expected = new List<int>() { 4, 5, 7 };
            var actual = t.Grid.Rows[7].Cells[6].Possibilities;
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
            var before = t.Grid.Blocks[8].Cells[3].Possibilities;
            foreach (var x in before)
            {
                Console.WriteLine(x + "#");
            }
            t.HiddenQuads();
            var expected = new List<int>() { 4, 5, 7 };
            var actual = t.Grid.Blocks[8].Cells[3].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() {1,9 };
            var actual = t.Grid.Columns[6].Cells[0].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() { 1, 8 };
            var actual = t.Grid.Columns[6].Cells[1].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() { 1, 6,8 };
            var actual = t.Grid.Columns[6].Cells[2].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() { 2, 9 };
            var actual = t.Grid.Columns[6].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1K()
        {
            Technique t = new Technique(SudokuWiki);
            t.HiddenQuads();
            var expected = new List<int>() {4,7 };
            var actual = t.Grid.Columns[6].Cells[5].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() { 2, 6 };
            var actual = t.Grid.Columns[6].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki1L()
        {
            Technique t = new Technique(SudokuWiki);
            t.HiddenQuads();
            var expected = new List<int>() { 3,4,7 };
            var actual = t.Grid.Columns[6].Cells[4].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() { 1,4,6,9};
            var actual = t.Grid.Blocks[4].Cells[0].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() {  4, 6, 9 };
            var actual = t.Grid.Blocks[4].Cells[2].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() { 1, 4, 9 };
            var actual = t.Grid.Blocks[4].Cells[6].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() { 4,9 };
            var actual = t.Grid.Blocks[4].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LearnSudoku1A()
        {
            Technique t = new Technique(LearnSudoku);
            t.HiddenQuads();
            var expected = new List<int>() { 2,4,7 };
            var actual = t.Grid.Rows[2].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LearnSudoku1B()
        {
            Technique t = new Technique(LearnSudoku);
            t.HiddenQuads();
            var expected = new List<int>() { 2, 7,8 };
            var actual = t.Grid.Rows[2].Cells[1].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() { 2,4,8 };
            var actual = t.Grid.Rows[2].Cells[2].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() { 7,8};
            var actual = t.Grid.Rows[2].Cells[8].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() {1,5,6,9 };
            var actual = t.Grid.Rows[2].Cells[3].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() { 1,6 };
            var actual = t.Grid.Rows[2].Cells[4].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() { 1,5,9 };
            var actual = t.Grid.Rows[2].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LearnSudoku1H()
        {
            Technique t = new Technique(LearnSudoku);
            t.HiddenQuads();
            var expected = new List<int>() {1,3,5,6};
            var actual = t.Grid.Rows[2].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LearnSudoku1I()
        {
            Technique t = new Technique(LearnSudoku);
            t.HiddenQuads();
            var expected = new List<int>() { 1, 3, 5, 6,9 };
            var actual = t.Grid.Rows[2].Cells[7].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() {1,4,6,7};
            var actual = t.Grid.Blocks[5].Cells[0].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() { 1, 6, 7 };
            var actual = t.Grid.Blocks[5].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Sudoku9981_1C()
        {
            Technique t = new Technique(Sudoku9981);
            t.HiddenQuads();
            var expected = new List<int>() { 1, 4, 7 };
            var actual = t.Grid.Blocks[5].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Sudoku9981_1D()
        {
            Technique t = new Technique(Sudoku9981);
            t.HiddenQuads();
            var expected = new List<int>() { 1,7 };
            var actual = t.Grid.Blocks[5].Cells[8].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() {3,4,7 };
            var actual = t.Grid.Blocks[2].Cells[3].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() { 3, 4};
            var actual = t.Grid.Blocks[2].Cells[5].Possibilities;
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
            t.HiddenQuads();
            var expected = new List<int>() { 3, 4, 7,8 };
            var actual = t.Grid.Blocks[2].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuSolver1D()
        {
            Technique t = new Technique(SudokuSolver);
            t.HiddenQuads();
            var expected = new List<int>() { 3, 4, 8 };
            var actual = t.Grid.Blocks[2].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Quatrian1A()
        {
            Technique t = new Technique(Quatrian1);
            t.HiddenQuads();
            var expected = new List<int>() { 1,3,7 };
            var actual = t.Grid.Blocks[7].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Quatrian1B()
        {
            Technique t = new Technique(Quatrian1);
            t.HiddenQuads();
            var expected = new List<int>() { 1, 3 };
            var actual = t.Grid.Blocks[7].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Quatrian1C()
        {
            Technique t = new Technique(Quatrian1);
            t.HiddenQuads();
            var expected = new List<int>() { 1, 3,4, 7 };
            var actual = t.Grid.Blocks[7].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Quatrian1D()
        {
            Technique t = new Technique(Quatrian1);
            t.HiddenQuads();
            var expected = new List<int>() { 1, 3,4};
            var actual = t.Grid.Blocks[7].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Quatrian2A()
        {
            Technique t = new Technique(Quatrian2);
            t.HiddenQuads();
            var expected = new List<int>() {3,5,9 };
            var actual = t.Grid.Blocks[0].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Quatrian2B()
        {
            Technique t = new Technique(Quatrian2);
            t.HiddenQuads();
            var expected = new List<int>() { 5,6,9 };
            var actual = t.Grid.Blocks[0].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Quatrian2C()
        {
            Technique t = new Technique(Quatrian2);
            t.HiddenQuads();
            var expected = new List<int>() { 3, 5, 9 };
            var actual = t.Grid.Blocks[0].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Quatrian2D()
        {
            Technique t = new Technique(Quatrian2);
            t.HiddenQuads();
            var expected = new List<int>() { 5,6,9 };
            var actual = t.Grid.Blocks[0].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Quatrian3A()
        {
            Technique t = new Technique(Quatrian3);
            t.HiddenQuads();
            var expected = new List<int>() { 1,2,3 };
            var actual = t.Grid.Rows[3].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Quatrian3B()
        {
            Technique t = new Technique(Quatrian3);
            t.HiddenQuads();
            var expected = new List<int>() { 1,3,9 };
            var actual = t.Grid.Rows[3].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Quatrian4A()
        {
            Technique t = new Technique(Quatrian3);
            t.HiddenQuads();
            var expected = new List<int>() { 2,3};
            var actual = t.Grid.Rows[4].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Quatrian4B()
        {
            Technique t = new Technique(Quatrian3);
            t.HiddenQuads();
            var expected = new List<int>() {  3, 9 };
            var actual = t.Grid.Rows[4].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Quatrian3_E()
        {
            Technique t = new Technique(Quatrian3);
            t.HiddenQuads();
            var expected = new List<int>() {7,8};
            var actual = t.Grid.Blocks[5].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Quatrian3_F()
        {
            Technique t = new Technique(Quatrian3);
            t.HiddenQuads();
            var expected = new List<int>() {4,8};
            var actual = t.Grid.Blocks[5].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Quatrian3_G()
        {
            Technique t = new Technique(Quatrian3);
            t.HiddenQuads();
            var expected = new List<int>() {6,7,8};
            var actual = t.Grid.Blocks[5].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Quatrian3_H()
        {
            Technique t = new Technique(Quatrian3);
            t.HiddenQuads();
            var expected = new List<int>() { 5};
            var actual = t.Grid.Blocks[5].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Quatrian3_I()
        {
            Technique t = new Technique(Quatrian3);
            t.HiddenQuads();
            var expected = new List<int>() {4,6,7,8};
            var actual = t.Grid.Blocks[5].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Quatrian3_J()
        {
            Technique t = new Technique(Quatrian3);
            t.HiddenQuads();
            var expected = new List<int>() { 6,7,8 };
            var actual = t.Grid.Columns[6].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
