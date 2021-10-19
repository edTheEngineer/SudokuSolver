
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.Techniques;
using System;
using System.Collections.Generic;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudokuTests.SudokuSolver.Techniques
{
    [TestClass()]
    public class NakedTriplesTests
    {
        public int[,] PuzzleMysteryRow { get; set; }

        public int[,] PuzzleMysteryCol { get; set; }

        public int[,] PuzzleMysteryBlock { get; set; }
        public int[,] SudokuOfTheDayEasy { get; set; }
        public int[,] SudokuOfTheDayMedium { get; set; }

        public int[,] SudokuOfTheDayEG1 { get; set; }

        public int[,] SudokuOfTheDayEG2 { get; set; }

        public int[,] SudokuOfTheDayEG3 { get; set; }

        public int[,] SudokuOfTheDayEG4 { get; set; }

        public int[,] SudokuOfTheDayEG5 { get; set; }

        public int[,] SudokuOfTheDay9981 { get; set; }

        public int[,] SudokuApp1 { get; set; }

        public int[,] SudokuApp2{ get; set; }

 
        public int[,] SudokuLive{ get; set; }

        public int[,] SudokuLive2 { get; set; }

        public int[,] SudokuWiki { get; set; }

        public int[,] SudokuWiki2 { get; set; }

        public int[,] SudokuSolutions { get; set; }

        public int[,] Thonky { get; set; }

        public int[,] Hodoku1 { get; set; }

        public int[,] Hodoku2 { get; set; }


        public NakedTriplesTests()
        {
            PuzzleMysteryRow = new[,]
            {
                {0,0,1,0,0,0,0,4,5},
                {2,0,0,0,8,0,0,0,0},
                {0,0,0,0,1,0,0,0,0},
                {0,0,0,5,3,1,0,0,0},
                {3,0,0,0,0,0,8,0,0},
                {0,0,0,6,4,8,0,0,0},
                {0,5,4,1,0,0,0,0,0},
                {0,6,2,0,0,0,0,7,0},
                {0,0,0,0,0,0,2,0,0},

            };

            PuzzleMysteryCol = new[,]
{
                 {5,6,4,0,0,0,7,2,0},
                {9,0,0,0,4,6,8,1,0},
                {1,0,0,0,0,0,4,6,0},
                {4,0,0,2,5,1,3,8,6},
                {0,0,6,0,0,0,0,9,1},
                {0,1,0,6,0,0,0,4,7 },
                {3,0,0,7,6,0,1,5,8},
                {7,0,0,0,0,5,6,3,4},
                {6,0,0,0,0,8,9,7,2},

            };

            PuzzleMysteryBlock = new[,]
{
                {5,6,4,0,0,0,7,2,0},
                {0,0,0,0,4,6,8,1,0},
                {0,0,0,0,0,0,4,6,0},
                {0,0,0,2,5,1,3,8,6},
                {0,0,6,0,0,0,0,9,1},
                {0,1,0,6,0,0,0,4,7 },
                {3,0,0,7,6,0,1,5,8},
                {0,0,0,0,0,5,6,0,4},
                {6,0,0,0,0,8,9,0,2},

            };

           SudokuOfTheDayEasy = new[,]
{
                {4,0,0,2,7,0,6,0,0},
                {7,9,8,1,5,6,2,3,4},
                {0,2,0,8,4,0,0,0,7},
                {2,3,7,4,6,8,9,5,1},
                {8,4,9,5,3,1,7,2,6},
                {5,6,1,7,9,2,8,4,3},
                {0,8,2,0,1,5,4,7,9},
                {0,7,0,0,2,4,3,0,0},
                {0,0,4,0,8,7,0,0,2},

            };

            SudokuOfTheDayMedium = new[,]
{
                {6,0,0,8,0,2,7,3,5},
                {7,0,2,3,5,6,9,4,0},
                {3,0,0,4,0,7,0,6,2},
                {1,0,0,9,7,5,0,2,4},
                {2,0,0,1,8,3,0,7,9},
                {0,7,9,6,2,4,0,0,3},
                {4,0,0,5,6,0,2,0,7},
                {0,6,7,2,4,0,3,0,0},
                {9,2,0,7,3,8,4,0,6},

            };

            SudokuOfTheDayEG1= new[,]
{
                {4,0,0,3,9,0,0,0,2},
                {2,6,0,0,5,8,3,9,0},
                {5,9,3,6,0,0,1,8,0},
                {1,0,0,8,6,0,0,0,9},
                {6,0,5,9,0,0,2,0,0},
                {0,3,9,2,4,5,0,1,6},
                {0,5,6,0,0,9,0,2,0},
                {0,1,4,7,0,0,9,0,5},
                {9,0,0,5,3,0,0,0,0},

            };

            SudokuOfTheDayEG2 = new[,]
{
                {5,0,0,7,0,6,9,0,2},
                {0,0,9,0,1,0,8,7,5},
                {2,7,0,8,9,5,3,0,6},
                {3,4,7,6,8,9,0,0,1},
                {9,1,5,0,0,0,7,6,8},
                {8,2,6,5,7,1,4,3,9},
                {0,0,2,1,0,0,0,0,7},
                {7,0,0,0,0,0,1,0,3},
                {1,0,3,9,0,7,0,0,4},

            };

            SudokuOfTheDayEG3 = new[,]
{
                {8,9,1,0,0,5,7,6,0},
                {5,3,7,6,9,0,2,0,8},
                {4,6,2,0,0,0,0,0,5},
                {2,4,3,5,1,0,8,0,6},
                {1,5,6,0,0,0,4,0,0},
                {9,7,8,0,4,6,5,0,0},
                {3,1,9,0,5,0,6,8,7},
                {6,8,4,0,0,0,0,5,2},
                {7,2,5,8,6,0,3,0,0},

            };

            SudokuOfTheDayEG4 = new[,]
{
                {4,0,6,0,5,1,2,0,0},
                {0,3,0,0,2,0,0,0,9},
                {0,0,0,0,0,0,0,0,0},
                {0,6,4,2,0,5,7,9,8},
                {7,0,0,0,0,0,5,2,4},
                {2,8,5,7,4,9,6,3,1},
                {0,0,0,0,0,0,9,0,0},
                {9,0,0,0,6,0,0,4,0},
                {0,4,7,5,9,0,1,0,2},

            };

            SudokuOfTheDayEG5 = new[,]
{
                {3,1,4,0,0,0,0,0,9},
                {0,9,0,1,0,4,0,3,0},
                {0,8,0,0,3,0,4,0,1},
                {0,2,8,0,7,0,6,0,3},
                {0,3,5,8,0,6,0,0,0},
                {7,6,9,0,2,3,0,1,0},
                {6,7,1,0,0,0,3,4,2},
                {9,5,2,3,4,7,1,8,6},
                {8,4,3,0,0,0,0,0,5},

            };

            SudokuOfTheDay9981 = new[,]
{
                {2,4,0,0,3,0,0,0,1},
                {5,9,0,0,1,0,3,2,0},
                {0,0,0,0,2,0,0,0,4},
                {3,5,2,1,4,6,8,9,7},
                {4,0,0,3,8,9,5,1,2},
                {1,8,9,5,7,2,6,4,3},
                {0,2,0,0,9,3,1,0,0},
                {6,0,0,0,5,1,0,0,9},
                {9,0,0,0,6,0,0,3,0},

            };



            SudokuApp1 = new[,]
{
                {0,0,0,0,6,0,0,0,8},
                {0,6,0,0,0,9,0,0,4},
                {4,8,0,7,0,0,0,0,0},
                {0,0,9,0,0,0,0,8,1},
                {1,3,0,0,0,0,0,0,0},
                {8,5,0,2,0,1,0,7,0},
                {7,4,3,6,1,2,8,5,9},
                {0,0,0,0,0,0,0,0,0},
                {5,2,8,0,0,0,1,6,7},

            };

            SudokuApp2 = new[,]
{
                {8,7,0,0,9,5,0,0,0},
                {4,5,0,8,0,0,0,0,0},
                {6,9,0,4,0,2,5,7,8},
                {9,0,7,0,4,3,0,6,5},
                {3,4,5,0,0,8,7,0,1},
                {2,0,6,0,5,0,0,0,0},
                {7,3,9,5,8,6,4,1,2},
                {0,2,8,0,0,4,6,0,7},
                {0,6,4,0,0,0,0,0,3},
                

            };

            SudokuLive = new[,]
{
                {0,0,0,0,0,6,0,0,4},
                {0,0,0,0,1,0,0,2,0},
                {2,0,5,8,3,4,1,9,0},
                {0,0,0,0,8,0,0,5,9},
                {0,0,6,7,0,0,0,0,0},
                {0,3,0,0,2,0,0,0,0},
                {0,0,8,0,4,0,3,1,2},
                {9,2,0,0,0,0,0,0,0},
                {0,1,0,0,6,0,0,0,0},


            };


            SudokuLive2 = new[,]
{
                {0,0,0,6,0,8,0,0,4},
                {0,0,0,0,9,3,0,6,0},
                {6,0,3,2,1,4,9,5,0},
                {0,0,6,0,2,1,0,3,5},
                {0,0,8,7,0,5,6,0,0},
                {0,1,0,0,6,9,0,0,0},
                {0,0,2,0,4,0,0,9,6},
                {5,6,0,0,0,0,0,0,0},
                {0,9,0,0,8,6,5,0,0},


            };

            SudokuSolutions = new[,]
{
                {7,1,9,0,3,0,8,6,0},
                {2,4,3,0,8,6,1,0,9},
                {5,6,8,9,1,0,0,4,3},
                {3,0,0,6,0,9,0,8,0},
                {0,0,6,0,0,0,9,0,0},
                {9,0,0,8,0,1,6,3,0},
                {0,3,7,0,9,8,5,2,6},
                {0,0,0,0,6,0,3,9,7},
                {6,9,2,0,5,0,4,1,8},


            };

            Thonky = new[,]
{
                {1,2,6,0,0,9,0,7,3},
                {0,0,5,6,2,7,0,9,0},
                {7,0,8,0,0,3,0,2,0},
                {0,7,0,0,9,2,6,0,0},
                {8,0,0,0,0,6,0,1,9},
                {0,6,0,3,0,5,7,4,0},
                {0,0,9,2,6,4,1,8,7},
                {0,8,0,0,0,1,0,0,0},
                {0,0,0,9,0,8,0,6,0},


            };

            SudokuWiki = new[,]
{
                {0,7,0,4,0,8,0,2,9},
                {0,0,2,0,0,0,0,0,4},
                {8,5,4,0,2,0,0,0,7},
                {0,0,8,3,7,4,2,0,0},
                {0,2,0,0,0,0,0,0,0},
                {0,0,3,2,6,1,7,0,0},
                {0,0,0,0,9,3,6,1,2},
                {2,0,0,0,0,0,4,0,3},
                {1,3,0,6,4,2,0,7,0},


            };

            SudokuWiki2 = new[,]
{
                {2,9,4,5,1,3,0,0,6},
                {6,0,0,8,4,2,3,1,9},
                {3,0,0,6,9,7,2,5,4},
                {0,0,0,0,5,6,0,0,0},
                {0,4,0,0,8,0,0,6,0},
                {0,0,0,4,7,0,0,0,0},
                {7,3,0,1,6,4,0,0,5},
                {9,0,0,7,3,5,0,0,1},
                {4,0,0,9,2,8,6,3,7},


            };

            Hodoku1 = new[,]
{
                {0,0,0,2,9,4,3,8,0},
                {0,0,0,1,7,8,6,4,0 },
                {4,8,0,3,5,6,1,0,0},
                {0,0,4,8,3,7,5,0,1},
                {0,0,0,4,1,5,7,0,0},
                {5,0,0,6,2,9,8,3,4},
                {9,5,3,7,8,2,4,1,6},
                {1,2,6,5,4,3,9,7,8},
                {0,4,0,9,6,1,2,5,3},


            };

            Hodoku2 = new[,]
{
                {3,9,0,0,0,0,7,0,0},
                {0,0,0,0,0,0,6,5,0},
                {5,0,7,0,0,0,3,4,9},
                {0,4,9,3,8,0,5,0,6},
                {6,0,1,0,5,4,9,8,3},
                {8,5,3,0,0,0,4,0,0},
                {9,0,0,8,0,0,1,3,4},
                {0,0,2,9,4,0,8,6,5},
                {4,0,0,0,0,0,2,9,7},


            };


        }
        [TestMethod()]
        public void PuzzleMysteryRowA()
        {
            Technique t = new Technique(PuzzleMysteryRow);
            var actualB = t.Grid.Rows[4].Cells[1].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedTriple();
            var expected = new List<int>() { 1,4 };
            var actual = t.Grid.Rows[4].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PuzzleMysteryRowB()
        {
            Technique t = new Technique(PuzzleMysteryRow);
            var actualB = t.Grid.Columns[1].Cells[4].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedTriple();
            var expected = new List<int>() { 1, 4 };
            var actual = t.Grid.Columns[1].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PuzzleMysteryRowC()
        {
            Technique t = new Technique(PuzzleMysteryRow);
            t.NakedTriple();
            var expected = new List<int>() { 1, 4 };
            var actual = t.Grid.Blocks[3].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void PuzzleMysteryRowD()
        {
            Technique t = new Technique(PuzzleMysteryRow);
            var actualB = t.Grid.Rows[4].Cells[1].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedTriple();
            var expected = new List<int>() { 5,6};
            var actual = t.Grid.Rows[4].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void PuzzleMysteryRowE()
        {
            Technique t = new Technique(PuzzleMysteryRow);
            t.NakedTriple();
            var expected = new List<int>() { 1, 5,6 };
            var actual = t.Grid.Rows[4].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PuzzleMysteryRowF()
        {
            Technique t = new Technique(PuzzleMysteryRow);
            t.NakedTriple();
            var expected = new List<int>() { 1, 4, 6 };
            var actual = t.Grid.Rows[4].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuOfTheDayEasy1()
        {
            Technique t = new Technique(SudokuOfTheDayEasy);
            var actualB = t.Grid.Rows[8].Cells[0].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedTriple();
            var expected = new List<int>() { 3,9};
            var actual = t.Grid.Rows[8].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuOfTheDayEasy2()
        {
            Technique t = new Technique(SudokuOfTheDayEasy);
            var actualB = t.Grid.Rows[8].Cells[7].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedTriple();
            var expected = new List<int>() { 1,6 };
            var actual = t.Grid.Rows[8].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDayMedium1A()
        {
            Technique t = new Technique(SudokuOfTheDayMedium);
            t.NakedTriple();
            var expected = new List<int>() { 4,9 };
            var actual = t.Grid.Columns[1].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuOfTheDayMedium1B()
        {
            Technique t = new Technique(SudokuOfTheDayMedium);
            t.NakedTriple();
            var expected = new List<int>() { 5, 9 };
            var actual = t.Grid.Columns[1].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuOfTheDayEG1A()
        {
            Technique t = new Technique(SudokuOfTheDayEG1);
            t.NakedTriple();
            var expected = new List<int>() { 2,4 };
            var actual = t.Grid.Columns[5].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }



        [TestMethod()]
        public void SudokuOfTheDayEG1B()
        {
            Technique t = new Technique(SudokuOfTheDayEG1);
            var actualB = t.Grid.Columns[5].Cells[8].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedTriple();
            var expected = new List<int>() { 2,4,6 };
            var actual = t.Grid.Columns[5].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDayEG2A()
        {
            Technique t = new Technique(SudokuOfTheDayEG2);
            t.NakedTriple();
            var expected = new List<int>() { 5,6,9};
            var actual = t.Grid.Rows[7].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDayEG2B()
        {
            Technique t = new Technique(SudokuOfTheDayEG2);
            t.NakedTriple();
            var expected = new List<int>() { 5, 6 };
            var actual = t.Grid.Rows[7].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDayEG2C()
        {
            Technique t = new Technique(SudokuOfTheDayEG2);
            t.NakedTriple();
            var expected = new List<int>() { 5, 9 };
            var actual = t.Grid.Rows[7].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDayEG3A()
        {
            Technique t = new Technique(SudokuOfTheDayEG3);
            t.NakedTriple();
            var expected = new List<int>() { 1,7 };
            var actual = t.Grid.Columns[3].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuOfTheDayEG3B()
        {
            Technique t = new Technique(SudokuOfTheDayEG3);
            t.NakedTriple();
            var expected = new List<int>() { 7,9 };
            var actual = t.Grid.Columns[3].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuOfTheDayEG3C()
        {
            Technique t = new Technique(SudokuOfTheDayEG3);
            t.NakedTriple();
            var expected = new List<int>() { 1, 7, 9 };
            var actual = t.Grid.Columns[3].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDayEG4A()
        {
            Technique t = new Technique(SudokuOfTheDayEG4);
            t.NakedTriple();
            var expected = new List<int>() { 2,7,9 };
            var actual = t.Grid.Blocks[0].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuOfTheDayEG4B()
        {
            Technique t = new Technique(SudokuOfTheDayEG4);
            t.NakedTriple();
            var expected = new List<int>() { 2, 9 };
            var actual = t.Grid.Blocks[0].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SudokuOfTheDayEG5A()
        {
            Technique t = new Technique(SudokuOfTheDayEG5);
            t.NakedTriple();
            var expected = new List<int>() { 2, 6,7 };
            var actual = t.Grid.Columns[3].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheDayEG5B()
        {
            Technique t = new Technique(SudokuOfTheDayEG5);
            t.NakedTriple();
            var expected = new List<int>() { 2, 6, 7 };
            var actual = t.Grid.Columns[3].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Sudoku9981A()
        {
            Technique t = new Technique(SudokuOfTheDay9981);
            t.NakedTriple();
            var expected = new List<int>() { 1,3 };
            var actual = t.Grid.Columns[2].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Sudoku9981B()
        {
            Technique t = new Technique(SudokuOfTheDay9981);
            t.NakedTriple();
            var expected = new List<int>() { 4,5 };
            var actual = t.Grid.Columns[2].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Sudoku9981C()
        {
            Technique t = new Technique(SudokuOfTheDay9981);
            t.NakedTriple();
            var expected = new List<int>() { 3,4 };
            var actual = t.Grid.Columns[2].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Sudokuy9981D()
        {
            Technique t = new Technique(SudokuOfTheDay9981);
            t.NakedTriple();
            var expected = new List<int>() { 1,4,5};
            var actual = t.Grid.Columns[2].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }



        [TestMethod()]
        public void SudokuApp1A()
        {
            Technique t = new Technique(SudokuApp1);
            t.NakedTriple();
            var expected = new List<int>() { 5,8 };
            var actual = t.Grid.Rows[7].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuApp1B()
        {
            Technique t = new Technique(SudokuApp1);
            var actualB = t.Grid.Rows[7].Cells[4].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedTriple();
            var expected = new List<int>() { 5,7, 8 };
            var actual = t.Grid.Rows[7].Cells[4].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() {2};
            var actual = t.Grid.Blocks[1].Cells[0].Possibilities;
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
            var actualB = t.Grid.Blocks[7].Cells[0].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedTriple();
            
            var expected = new List<int>() { 5};
            var actual = t.Grid.Blocks[7].Cells[0].Possibilities;
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
            var actualB = t.Grid.Blocks[7].Cells[3].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedTriple();
            var expected = new List<int>() { 9};
            var actual = t.Grid.Blocks[7].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuSolutions1A()
        {
            Technique t = new Technique(SudokuSolutions);
            t.NakedTriple();
            var expected = new List<int>() {3,5 };
            var actual = t.Grid.Blocks[4].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuSolutions1B()
        {
            Technique t = new Technique(SudokuSolutions);
            t.NakedTriple();
            var expected = new List<int>() { 3, 5 };
            var actual = t.Grid.Blocks[4].Cells[5].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() { 1,7 };
            var actual = t.Grid.Blocks[0].Cells[1].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() {4,5 };
            var actual = t.Grid.Blocks[1].Cells[0].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() { 1,2,6 };
            var actual = t.Grid.Blocks[1].Cells[1].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() { 5,8};
            var actual = t.Grid.Blocks[1].Cells[2].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() { 4, 7 };
            var actual = t.Grid.Blocks[1].Cells[3].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku2E()
        {
            Technique t = new Technique(Hodoku2);
            t.NakedTriple();
            var expected = new List<int>() { 3,7,9 };
            var actual = t.Grid.Blocks[1].Cells[4].Possibilities;
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
            var actualB = t.Grid.Blocks[1].Cells[5].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedTriple();
            var expected = new List<int>() {3,7,9};
            var actual = t.Grid.Blocks[1].Cells[5].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() { 1,2,6};
            var actual = t.Grid.Blocks[1].Cells[6].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() { 1,2,6 };
            var actual = t.Grid.Blocks[1].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Hodoku2I()
        {
            Technique t = new Technique(Hodoku2);
            var actualB = t.Grid.Blocks[1].Cells[8].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedTriple();
            var expected = new List<int>() { 8};
            var actual = t.Grid.Blocks[1].Cells[8].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() {4,6,7 };
            var actual = t.Grid.Rows[4].Cells[0].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() { 1, 6, 7 };
            var actual = t.Grid.Rows[4].Cells[2].Possibilities;
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
            var actualB = t.Grid.Rows[4].Cells[6].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedTriple();
            var expected = new List<int>() {1, 3 };
            var actual = t.Grid.Rows[4].Cells[6].Possibilities;
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
            var actualB = t.Grid.Rows[4].Cells[7].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedTriple();
            var expected = new List<int>() { 3,4,6 };
            var actual = t.Grid.Rows[4].Cells[7].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() { 2,7};
            var actual = t.Grid.Columns[1].Cells[3].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() { 2, 6 };
            var actual = t.Grid.Columns[1].Cells[5].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() { 2, 3,7,9 };
            var actual = t.Grid.Columns[2].Cells[3].Possibilities;
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
            var actualB = t.Grid.Columns[2].Cells[4].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedTriple();
            var expected = new List<int>() {2,3 ,7,9 };
            var actual = t.Grid.Columns[2].Cells[4].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() { 2,3,6,9 };
            var actual = t.Grid.Columns[2].Cells[5].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() {1,4,7,9 };
            var actual = t.Grid.Blocks[5].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki2G()
        {
            Technique t = new Technique(SudokuWiki2);
            t.NakedTriple();
            var expected = new List<int>() {  4, 7, 9 };
            var actual = t.Grid.Blocks[5].Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki2H()
        {
            Technique t = new Technique(SudokuWiki2);
            t.NakedTriple();
            var expected = new List<int>() { 1,5,9 };
            var actual = t.Grid.Blocks[5].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuWiki2I()
        {
            Technique t = new Technique(SudokuWiki2);
            t.NakedTriple();
            var expected = new List<int>() {9};
            var actual = t.Grid.Blocks[5].Cells[7].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() { 9 };
            var actual = t.Grid.Rows[2].Cells[1].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() { 6 };
            var actual = t.Grid.Rows[2].Cells[8].Possibilities;
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
            t.NakedTriple();
            var expected = new List<int>() { 9 };
            var actual = t.Grid.Rows[5].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Thonky1D()
        {
            Technique t = new Technique(Thonky);
            t.NakedTriple();
            var expected = new List<int>() {6 };
            var actual = t.Grid.Rows[7].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Thonky1E()
        {
            Technique t = new Technique(Thonky);
            t.NakedTriple();
            var expected = new List<int>() { 4 };
            var actual = t.Grid.Rows[7].Cells[2].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Thonky1F()
        {
            Technique t = new Technique(Thonky);
            t.NakedTriple();
            var expected = new List<int>() {  9 };
            var actual = t.Grid.Rows[7].Cells[6].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Thonky1G()
        {
            Technique t = new Technique(Thonky);
            t.NakedTriple();
            var expected = new List<int>() { 2, 4 };
            var actual = t.Grid.Rows[7].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Thonky1H()
        {
            Technique t = new Technique(Thonky);
            t.NakedTriple();
            var expected = new List<int>() { 2 };
            var actual = t.Grid.Rows[8].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Thonky1I()
        {
            Technique t = new Technique(Thonky);
            t.NakedTriple();
            var expected = new List<int>() { 2, 3 };
            var actual = t.Grid.Columns[6].Cells[4].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Thonky1J()
        {
            Technique t = new Technique(Thonky);
            t.NakedTriple();
            var expected = new List<int>() { 9 };
            var actual = t.Grid.Columns[6].Cells[7].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Thonky1K()
        {
            Technique t = new Technique(Thonky);
            t.NakedTriple();
            var expected = new List<int>() { 2, 3, };
            var actual = t.Grid.Columns[6].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Thonky1L()
        {
            Technique t = new Technique(Thonky);
            t.NakedTriple();
            var expected = new List<int>() { 1 };
            var actual = t.Grid.Blocks[2].Cells[5].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Thonky1M()
        {
            Technique t = new Technique(Thonky);
            t.NakedTriple();
            var expected = new List<int>() { 6 };
            var actual = t.Grid.Blocks[2].Cells[8].Possibilities;
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SplitTest1()
        {
            Technique t = new Technique(Thonky);
            t.SplitThreeCoordinate("1;2;3", out int a, out int b, out int c);
            var expected = 1;
            var actual = a;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SplitTest2()
        {
            Technique t = new Technique(Thonky);
            t.SplitThreeCoordinate("1;2;3", out int a, out int b, out int c);
            var expected = 2;
            var actual = b;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SplitTest3()
        {
            Technique t = new Technique(Thonky);
            t.SplitThreeCoordinate("1;2;3", out int a, out int b, out int c);
            var expected = 3;
            var actual = c;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Order1A()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(1, 2, 3, out int smallest, out int middle, out int biggest);
            var expected = 1;
            var actual = smallest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Order1B()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(1, 2, 3, out int smallest, out int middle, out int biggest);
            var expected = 2;
            var actual = middle;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Order1C()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(1, 2, 3, out int smallest, out int middle, out int biggest);
            var expected = 3;
            var actual = biggest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Order2A()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(2,1,3, out int smallest, out int middle, out int biggest);
            var expected = 1;
            var actual = smallest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Order2B()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(2,1,3, out int smallest, out int middle, out int biggest);
            var expected = 2;
            var actual = middle;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Order2C()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(2,1,3, out int smallest, out int middle, out int biggest);
            var expected = 3;
            var actual = biggest;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Order3A()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(1, 3,2, out int smallest, out int middle, out int biggest);
            var expected = 1;
            var actual = smallest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Order3B()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(1, 3,2, out int smallest, out int middle, out int biggest);
            var expected = 2;
            var actual = middle;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Order3C()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(1, 3,2, out int smallest, out int middle, out int biggest);
            var expected = 3;
            var actual = biggest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Order4A()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(2,3,1, out int smallest, out int middle, out int biggest);
            var expected = 1;
            var actual = smallest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Order4B()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(2,3,1, out int smallest, out int middle, out int biggest);
            var expected = 2;
            var actual = middle;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Order4C()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(2,3,1, out int smallest, out int middle, out int biggest);
            var expected = 3;
            var actual = biggest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Order5A()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(3,1,2, out int smallest, out int middle, out int biggest);
            var expected = 1;
            var actual = smallest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Order5B()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(3,1,2, out int smallest, out int middle, out int biggest);
            var expected = 2;
            var actual = middle;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Order5C()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(3,1,2, out int smallest, out int middle, out int biggest);
            var expected = 3;
            var actual = biggest;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Order6A()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(3,2,1, out int smallest, out int middle, out int biggest);
            var expected = 1;
            var actual = smallest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Order6B()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(3,1,2, out int smallest, out int middle, out int biggest);
            var expected = 2;
            var actual = middle;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Order6C()
        {
            Technique t = new Technique(Thonky);
            t.orderThree(3,1,2, out int smallest, out int middle, out int biggest);
            var expected = 3;
            var actual = biggest;
            Assert.AreEqual(expected, actual);
        }
        //BOOL
        [TestMethod()]
        public void CompareAllThree()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareTwoThreeA()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 1, 2,3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareTwoThreeB()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2,3 };
            var b = new List<int>() { 1, 3 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareTwoThreeC()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareOneThreeA()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1,2 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareOneThreeB()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 3 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 2 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareOneThree()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() {  2, 3 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { 1, 2,3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1A()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2};
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1B()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(a, c,b, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1C()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(b,a,c ,out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1D()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(b,c,a, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1E()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(c,b,a, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1F()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(c,a,b, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllSingles()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1 };
            var b = new List<int>() { 2 };
            var c = new List<int>() { 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllSinglesReverse()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 3 };
            var b = new List<int>() { 2 };
            var c = new List<int>() { 1 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Empty()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() {  };
            var b = new List<int>() {  };
            var c = new List<int>() {  };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OnePoss()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1 };
            var b = new List<int>() { 1 };
            var c = new List<int>() { 1 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TwoPoss1A()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1,2 };
            var b = new List<int>() { 1,2 };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TwoPoss1B()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TwoPoss1C()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FourPoss()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2,3 };
            var b = new List<int>() { 4};
            var c = new List<int>() { 5};
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FourPossTwo()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() {4,5};
            var b = new List<int>() {4,5};
            var c = new List<int>() { 1,2,3};
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ThreeDiffTriplets()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1,2,3 };
            var b = new List<int>() { 4,5,6 };
            var c = new List<int>() {7,8,9 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        //Number 1

        [TestMethod()]
        public void CompareAllThreeNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareTwoThreeANumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected =1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareTwoThreeBNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 3 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareTwoThreeCNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareOneThreeANumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareOneThreeBNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 3 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 2 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareOneThreeNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 2, 3 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1ANumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1BNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(a, c, b, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1CNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(b, a, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1DNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(b, c, a, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1ENumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(c, b, a, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1FNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(c, a, b, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllSinglesNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1 };
            var b = new List<int>() { 2 };
            var c = new List<int>() { 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllSinglesReverseNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 3 };
            var b = new List<int>() { 2 };
            var c = new List<int>() { 1 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EmptyNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { };
            var b = new List<int>() { };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OnePossNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1 };
            var b = new List<int>() { 1 };
            var c = new List<int>() { 1 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first; ;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TwoPoss1ANumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TwoPoss1BNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TwoPoss1CNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FourPossNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 4 };
            var c = new List<int>() { 5 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first; ;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FourPossTwoNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 4, 5 };
            var b = new List<int>() { 4, 5 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ThreeDiffTripletsNumber1()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 4, 5, 6 };
            var c = new List<int>() { 7, 8, 9 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        // Number 2

        [TestMethod()]
        public void CompareAllThreeNNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;   
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareTwoThreeANumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareTwoThreeBNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 3 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareTwoThreeCNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareOneThreeANumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareOneThreeBNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 3 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 2 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareOneThreeNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 2, 3 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1ANumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1BNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(a, c, b, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1CNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(b, a, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1DNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(b, c, a, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1ENumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(c, b, a, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1FNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(c, a, b, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllSinglesNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1 };
            var b = new List<int>() { 2 };
            var c = new List<int>() { 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllSinglesReverseNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 3 };
            var b = new List<int>() { 2 };
            var c = new List<int>() { 1 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EmptyNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { };
            var b = new List<int>() { };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OnePossNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1 };
            var b = new List<int>() { 1 };
            var c = new List<int>() { 1 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TwoPoss1ANumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TwoPoss1BNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TwoPoss1CNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FourPossNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 4 };
            var c = new List<int>() { 5 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FourPossTwoNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 4, 5 };
            var b = new List<int>() { 4, 5 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ThreeDiffTripletsNumber2()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 4, 5, 6 };
            var c = new List<int>() { 7, 8, 9 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        //Number3

        [TestMethod()]
        public void CompareAllThreeNNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareTwoThreeANumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareTwoThreeBNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 3 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareTwoThreeCNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void HodokuExampleFalse()
        { 
            Technique t = new Technique(Hodoku1);
            var a = new List<int>() {6,7};
            var b = new List<int>() {1,6,7};
            var c = new List<int>() {};
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void HodokuExampleFirst()
        {
            Technique t = new Technique(Hodoku1);
            var a = new List<int>() { 6, 7 };
            var b = new List<int>() { 1, 6, 7 };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = first;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void HodokuExampleSecond()
        {
            Technique t = new Technique(Hodoku1);
            var a = new List<int>() { 6, 7 };
            var b = new List<int>() { 1, 6, 7 };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = second;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void HodokuExampleThird()
        {
            Technique t = new Technique(Hodoku1);
            var a = new List<int>() { 6, 7 };
            var b = new List<int>() { 1, 6, 7 };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual =third;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FirstBlank()
        {
            Technique t = new Technique(Hodoku1);
            var a = new List<int>() {  };
            var b = new List<int>() { 1, 6, 7 };
            var c = new List<int>() { 1,6,7};
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SecondBlank()
        {
            Technique t = new Technique(Hodoku1);
            var a = new List<int>() { 6, 7 };
            var b = new List<int>() {  };
            var c = new List<int>() { 1,6,7};
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual =isNakedTriple;
            var expected = false;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void CompareOneThreeANumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareOneThreeBNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 3 };
            var b = new List<int>() { 1, 2, 3 };
            var c = new List<int>() { 2 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareOneThreeNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 2, 3 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1ANumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1BNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(a, c, b, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = isNakedTriple;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1CNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(b, a, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1DNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(b, c, a, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1ENumber32()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(c, b, a, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllPairs1FNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 2, 3 };
            var c = new List<int>() { 1, 3 };
            t.compareLists(c, a, b, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllSinglesNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1 };
            var b = new List<int>() { 2 };
            var c = new List<int>() { 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareAllSinglesReverseNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 3 };
            var b = new List<int>() { 2 };
            var c = new List<int>() { 1 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EmptyNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { };
            var b = new List<int>() { };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OnePossNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1 };
            var b = new List<int>() { 1 };
            var c = new List<int>() { 1 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TwoPoss1ANumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TwoPoss1BNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TwoPoss1CNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2 };
            var b = new List<int>() { 1, 2 };
            var c = new List<int>() { };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FourPossNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 4 };
            var c = new List<int>() { 5 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FourPossTwoNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 4, 5 };
            var b = new List<int>() { 4, 5 };
            var c = new List<int>() { 1, 2, 3 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ThreeDiffTripletsNumber3()
        {
            Technique t = new Technique(Thonky);
            var a = new List<int>() { 1, 2, 3 };
            var b = new List<int>() { 4, 5, 6 };
            var c = new List<int>() { 7, 8, 9 };
            t.compareLists(a, b, c, out bool isNakedTriple, out int first, out int second, out int third);
            var actual = third;
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }
    }
}