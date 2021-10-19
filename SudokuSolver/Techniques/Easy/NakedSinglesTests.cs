using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.CoreClasses;
using RazorPagesSudoku.SudokuSolver.Techniques;

namespace RazorPagesSudokuTests.SudokuSolver.Techniques.Easy
{
    [TestClass()]
    public class NakedSinglesTests
    {

        public int[,] Grid1 { get; set; }
        public int[,] NakedSinglesRowPuzzle { get; set; }
        public int[,] NakedSinglesColumnPuzzle { get; set; }

        public int[,] NakedSinglesBlockPuzzle { get; set; }

        public int[,] InvalidNakedSinglesRowPuzzle { get; set; }
        public int[,] InvalidNakedSinglesColumnPuzzle { get; set; }

        public int[,] InvalidNakedSinglesBlockPuzzle { get; set; }

        public int[,] NakedSinglesAllPuzzle { get; set; }

        public int[,] NakedSinglesRowAfterPuzzle { get; set; }
        public int[,] NakedSinglesColumnAfterPuzzle { get; set; }

        public int[,] NakedSinglesBlockAfter { get; set; }

        public int[,] NakedSinglesAllAfterPuzzle { get; set; }

        public int[,] NakedSinglesMultiplePuzzle { get; set; }

        public int[,] NakedSinglesMultipleAfterPuzzle { get; set; }

        public int[,] NakedSinglesSampleBeforePuzzle { get; set; }

        public int[,] NakedSinglesSampleAfterPuzzle { get; set; }

        public int[,] BlockOnly { get; set; }

        public int[,] RowOnly { get; set; }

        public int[,] ColumnOnly { get; set; }

        public int[,] Insolveable { get; set; }

        public NakedSinglesTests()
        {
            NakedSinglesRowPuzzle = new[,]
                {
                 {  1,2,3,4,5,0,7,8,9},
                 { 0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0}
                };

            NakedSinglesColumnPuzzle = new[,]
    {
                 {  1,2,3,4,5,6,7,8,9},
                 {  2,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  3,0,0,0,0,0,0,0,0},
                 {  4,0,0,0,0,0,0,0,0},
                 {  5,0,0,0,0,0,0,0,0},
                 {  6,0,0,0,0,0,0,0,0},
                 {  7,0,0,0,0,0,0,0,0},
                 {  8,0,0,0,0,0,0,0,0}
    };

            NakedSinglesBlockPuzzle = new[,]
    {
                 {  1,2,3,4,5,6,7,8,9},
                 {  0,0,0,0,0,0,5,4,3},
                 {  0,0,0,0,0,0,1,0,2},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  7,4,5,0,0,0,0,0,0},
                 {  6,3,8,0,0,0,0,0,0},
                 { 2,0,9,0,0,0,0,0,0}
    };

            NakedSinglesAllPuzzle = new[,]
{
                 {  1,2,3,4,5,0,7,8,9},
                 {  0,0,0,2,0,0,5,4,3},
                 {  0,0,0,1,0,0,1,0,2},
                 {  0,0,0,3,0,0,0,0,0},
                 {  0,0,0,5,0,0,0,0,0},
                 {  0,0,0,6,0,0,0,0,0},
                 {  0,0,0,7,0,0,0,0,0},
                 {  0,0,0,8,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0}
};

            NakedSinglesRowAfterPuzzle = new[,]
                {
                 {  1,2,3,4,5,6,7,8,9},
                 { 0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0}
                };

            NakedSinglesColumnAfterPuzzle = new[,]
    {
                 {  1,2,3,4,5,6,7,8,9},
                 {  2,0,0,0,0,0,0,0,0},
                 {  9,0,0,0,0,0,0,0,0},
                 {  3,0,0,0,0,0,0,0,0},
                 {  4,0,0,0,0,0,0,0,0},
                 {  5,0,0,0,0,0,0,0,0},
                 {  6,0,0,0,0,0,0,0,0},
                 {  7,0,0,0,0,0,0,0,0},
                 {  8,0,0,0,0,0,0,0,0}
    };

            NakedSinglesBlockAfter = new[,]
    {
                 {  1,2,3,4,5,6,7,8,9},
                 {  0,0,0,0,0,0,5,4,3},
                 {  0,0,0,0,0,0,1,6,2},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                {  7,4,5,0,0,0,0,0,0},
                 {  6,3,8,0,0,0,0,0,0},
                 { 2,1,9,0,0,0,0,0,0}
    };

            NakedSinglesAllAfterPuzzle = new [,]
            {
                 {  1,2,3,4,5,6,7,8,9},
                 {  0,0,0,2,0,0,5,4,3},
                 {  0,0,0,1,0,0,1,6,2},
                 {  0,0,0,3,0,0,0,0,0},
                 {  0,0,0,5,0,0,0,0,0},
                 {  0,0,0,6,0,0,0,0,0},
                 {  0,0,0,7,0,0,0,0,0},
                 {  0,0,0,8,0,0,0,0,0},
                 { 0,0,0,9,0,0,0,0,0}
};

            NakedSinglesMultiplePuzzle = new[,]
                {
                 {7,8,3,2,0, 9,5,4,1},
                 { 6,5,2,0,4,8,7,3,9},
                 { 4,0,1,3,5,7,6,8,2},
                 { 1,7,5,6,8,3,2,0,4},
                 { 3,2,8,7,9,0,1,5,6 },
                 { 9,4,6,0,2,1,8,7,3 },
                 { 2,3,0,8,7,6,4,1,5 },
                 {8,6,0,9,1,5,3,2,7},
                 { 5,1,7,4,3,0,9,6,8}
                };

            NakedSinglesMultipleAfterPuzzle = new[,]
                {
                 {7,8,3,2,6, 9,5,4,1},
                 { 6,5,2,1,4,8,7,3,9},
                 { 4,9,1,3,5,7,6,8,2},
                 { 1,7,5,6,8,3,2,9,4},
                 { 3,2,8,7,9,4,1,5,6 },
                 { 9,4,6,5,2,1,8,7,3 },
                 { 2,3,9,8,7,6,4,1,5 },
                 {8,6,4,9,1,5,3,2,7},
                 { 5,1,7,4,3,2,9,6,8}
                };

            NakedSinglesSampleBeforePuzzle = new[,]
                 {
                 { 0,0,0,1,0,2,0,0,0 },
                 { 0,8,0,0,0,0,4,5,0},
                 { 0,0,0,0,0,9,0,0,0},
                 { 0,0,0,0,6,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,7,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0}
                 };

            NakedSinglesSampleAfterPuzzle = new[,]
     {
                 {0,0,0,1,0,2,0,0,0 },
                 { 0,8,0,0,3,0,4,5,0},
                 { 0,0,0,0,0,9,0,0,0},
                 { 0,0,0,0,6,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,7,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0}
     };

            InvalidNakedSinglesRowPuzzle = new[,]
    {
                 {  1,2,3,4,0,0,7,8,9},
                 { 0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0}
    };

            InvalidNakedSinglesColumnPuzzle = new[,]
    {
                 {  1,2,3,4,5,6,7,8,9},
                 { 0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  3,0,0,0,0,0,0,0,0},
                 {  4,0,0,0,0,0,0,0,0},
                 {  5,0,0,0,0,0,0,0,0},
                 {  6,0,0,0,0,0,0,0,0},
                 {  7,0,0,0,0,0,0,0,0},
                 { 8,0,0,0,0,0,0,0,0}
    };

            InvalidNakedSinglesBlockPuzzle = new[,]
    {
                 {  1,2,3,4,5,6,7,8,9},
                 {  0,0,0,0,0,0,5,0,3},
                 {  0,0,0,0,0,0,1,0,2},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0}
    };

            BlockOnly = new[,]

                 {
                 { 7,8,3,2,6, 9,5,4,1},
                 { 6,0,2,1,0,8,7,0,9},
                 { 4,9,1,3,5,7,6,8,2},
                 { 1,7,5,6,8,3,2,9,4},
                 { 3,0,8,7,0,4,1,0,6 },
                 { 9,4,6,5,2,1,8,7,3 },
                 { 2,3,9,8,7,6,4,1,5 },
                 {8,0, 4,9,0,5,3,0,7},
                 { 5,1,7,4,3,2,9,6,8}
                  };

            RowOnly = new[,]

                 {
                 { 7,0,3,2,6, 9,5,4,1},
                 { 6,0,2,1,4,8,7,3,9},
                 { 4,0,1,3,5,7,6,8,2},
                 { 1,0,5,6,8,3,2,9,4},
                 { 3,0,8,7,9,4,1,5,6 },
                 { 9,0,6,5,2,1,8,7,3 },
                 { 2,0,9,8,7,6,4,1,5 },
                 { 8,0,4,9,1,5,3,2,7},
                 { 5,0,7,4,3,2,9,6,8}
                  };

            ColumnOnly = new[,]

                 {
                 { 7,8,3,2,6,9,5,4,1},
                 { 6,5,2,1,4,8,7,3,9},
                 { 4,9,1,3,5,7,6,8,2},
                 { 1,7,5,6,8,3,2,9,4},
                 { 3,2,8,7,9,4,1,5,6 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 2,3,9,8,7,6,4,1,5 },
                 { 8,6,4,9,1,5,3,2,7},
                 { 5,1,7,4,3,2,9,6,8}
                  };

            Insolveable = new[,]
    {
                 {  1,2,3,4,0,0,7,8,9},
                 { 0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 {  0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0}
    };


            Grid1 = new [,]
                    {
                 { 9,1,2,0,0,0,0,0,8 },
                 { 2,8,7,0,0,0,0,0,0 },
                 { 3,5,4,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,6,5,0,0,0 },
                 { 0,0,0,0,0,1,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,7,0},
                 { 3,0,0,0,3,4,0,0,5}
                    };
        }
    
        [TestMethod()]

        public void NakedSinglesRow ()
        {
            Technique ns = new Technique(NakedSinglesRowPuzzle);
            ns.NakedSingleTechnique();
            var actual = ns.SudokuGrid;
            var expected = NakedSinglesRowAfterPuzzle;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void NakedSinglesColumn()
        {
            Technique ns = new Technique(NakedSinglesColumnPuzzle);
            ns.NakedSingleTechnique();
            var actual = ns.SudokuGrid;
            var expected = NakedSinglesColumnAfterPuzzle;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void NakedSinglesBlock()
        {
            Technique ns = new Technique(NakedSinglesBlockPuzzle);
            ns.NakedSingleTechnique();
            var actual = ns.SudokuGrid;
            var expected = NakedSinglesBlockAfter;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void NakedSinglesAll()
        {
            Technique ns = new Technique(NakedSinglesAllPuzzle);
            ns.NakedSingleTechnique();
            var actual = ns.SudokuGrid;
            var expected = NakedSinglesAllAfterPuzzle;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void NakedSinglesMultiple()
        {
            Technique ns = new Technique(NakedSinglesMultiplePuzzle);
            ns.NakedSingleTechnique();
            var actual = ns.SudokuGrid;
            var expected = NakedSinglesMultipleAfterPuzzle;
            
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

        public void NakedSinglesBlocksOnly()
        {
            Technique ns = new Technique(BlockOnly);
            ns.NakedSingleTechnique();
            var actual = ns.SudokuGrid;
            var expected = NakedSinglesMultipleAfterPuzzle;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void NakedSinglesRows()
        {
            Technique ns = new Technique(RowOnly);
            ns.NakedSingleTechnique();
            var actual = ns.SudokuGrid;
            var expected = NakedSinglesMultipleAfterPuzzle;

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

        public void NakedSinglesColumns()
        {
            Technique ns = new Technique(ColumnOnly);
            ns.NakedSingleTechnique();
            var actual = ns.SudokuGrid;
            var expected = NakedSinglesMultipleAfterPuzzle;
            for(int i = 0; i<9; i++)
            {
                for(int j=0; j<9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }

            
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void NakedSinglesSampleBefore()
        {
            Technique ns = new Technique(NakedSinglesSampleBeforePuzzle);
            ns.NakedSingleTechnique();
            var actual = ns.SudokuGrid;
            var expected = NakedSinglesSampleAfterPuzzle;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void InvalidNakedSinglesRow()
        {
            Technique ns = new Technique(InvalidNakedSinglesRowPuzzle);
            ns.NakedSingleTechnique();
            var actual = ns.SudokuGrid;
            var expected = InvalidNakedSinglesRowPuzzle;
            CollectionAssert.AreEqual(actual, expected);
        }
        [TestMethod()]

        public void InvalidNakedSinglesColumn()
        {
            Technique ns = new Technique(InvalidNakedSinglesColumnPuzzle);
            ns.NakedSingleTechnique();
            var actual = ns.SudokuGrid;
            var expected = InvalidNakedSinglesColumnPuzzle;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void InvalidNakedSinglesBlock()
        {
            Technique ns = new Technique(InvalidNakedSinglesBlockPuzzle);
            ns.NakedSingleTechnique();
            var actual = ns.SudokuGrid;
            var expected = InvalidNakedSinglesBlockPuzzle;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void InsolveableTest()
        {
            Technique ns = new Technique(Insolveable);
            ns.NakedSingleTechnique();
            var actual = ns.SudokuGrid;
            var expected = Insolveable;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void AlreadyComplete()
        {
            Technique ns = new Technique(NakedSinglesMultipleAfterPuzzle);
            ns.NakedSingleTechnique();
            var actual = ns.SudokuGrid;
            var expected = NakedSinglesMultipleAfterPuzzle;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void FindNakedUnit()
        {
            Technique ns = new Technique();
            List<int> unit = new List<int> (){ 1, 2, 3, 4, 5, 6, 7, 8, 0 };
            var expectedZero = 8;
            var expectedMissing = 9;
            ns.GetNakedUnit(unit, out int zeroIndex, out int indexOfMissingUnit);
            var actual = zeroIndex + ";" + indexOfMissingUnit;
            var expected = expectedZero + ";" + expectedMissing;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]

        public void FindNakedUnitInvalid()
        {
            Technique ns = new Technique();
            List<int> unit = new List<int>()    { 1, 2, 3, 4, 0, 6, 7, 8, 0 };
            var expectedZero = -1;
            var expectedMissing = -1;
            ns.GetNakedUnit(unit, out int zeroIndex, out int indexOfMissingUnit);
            var actual = zeroIndex + ";" + indexOfMissingUnit;
            var expected = expectedZero + ";" + expectedMissing;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindNakedUnitJumbled()
        {
            Technique ns = new Technique();
            List<int> unit = new List<int>()    { 9,7,6,4,2,0,8,1,3 };
            var expectedZero = 5;
            var expectedMissing = 5;
            ns.GetNakedUnit(unit, out int zeroIndex, out int indexOfMissingUnit);
            var actual = zeroIndex + ";" + indexOfMissingUnit;
            var expected = expectedZero + ";" + expectedMissing;
            Assert.AreEqual(expected,actual);
        }

        [TestMethod()]

        public void FindNakedUnitComplete()
        {
            Technique ns = new Technique();
            List<int> unit = new List<int>()    {9, 7, 6, 4, 2, 5, 8, 1, 3 };
            
            var expectedZero = -1;
            var expectedMissing = -1;
            ns.GetNakedUnit(unit, out int zeroIndex, out int indexOfMissingUnit);
            var actual = zeroIndex + ";" + indexOfMissingUnit;
            var expected = expectedZero + ";" + expectedMissing;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindCoordinatesOfBlock_2_4()
        {
            Technique ns = new Technique();
            ns.FindIndexForBlock(2, 4, out int i, out int j);
            var actual = i + ";" + j;
            var expected = "1;7";
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]

        public void FindCoordinatesOfBlock2_4()
        {
            Technique ns = new Technique();
            ns.FindIndexForBlock(2, 4, out int i, out int j);
            var actual = i + ";" + j;
            var expected = "1;7";
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]

        public void FindCoordinatesOfBlock2_7()
        {
            Technique ns = new Technique();
            
            ns.FindIndexForBlock(2,7, out int i, out int j);
            var actual = i + ";" + j;
            var expected = "2;7";
            Assert.AreEqual(expected, actual);


        }

        [TestMethod()]

        public void FindCoordinatesOfBlock6_7()
        {
            Technique ns = new Technique();
            ns.FindIndexForBlock(6, 7, out int i, out int j);
            var actual = i + ";" + j;
            var expected = "8;1";
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]

        public void FindCoordinatesOfBlock8_8()
        {
            Technique ns = new Technique();
            ns.FindIndexForBlock(8,8, out int i, out int j);
            var actual = i + ";" + j;
            var expected = "8;8";
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]

        public void CellsBlock0()
        {
            AdvancedGrid g = new AdvancedGrid(NakedSinglesMultipleAfterPuzzle);
            List<int> actual = g.Blocks[0].CellsToNumbers();
            List<int> expected = new List<int>() { 7,8,3,6,5,2,4,9,1 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void CellsBlock1()
        {
            AdvancedGrid g = new AdvancedGrid(NakedSinglesMultipleAfterPuzzle);
            List<int> actual = g.Blocks[1].CellsToNumbers();
            List<int> expected = new List<int>() { 2,6,9,1,4,8,3,5,7 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void CellsBlock2()
        {
            AdvancedGrid g = new AdvancedGrid(NakedSinglesMultipleAfterPuzzle);
            List<int> actual = g.Blocks[2].CellsToNumbers();
            List<int> expected = new List<int>() { 5,4,1,7,3,9,6,8,2 };
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]

        public void CellsBlock3()
        {
            AdvancedGrid g = new AdvancedGrid(NakedSinglesMultipleAfterPuzzle);
            List<int> actual = g.Blocks[3].CellsToNumbers();
            List<int> expected = new List<int>() { 1,7,5,3,2,8,9,4,6 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void CellsBlock4()
        {
            AdvancedGrid g = new AdvancedGrid(NakedSinglesMultipleAfterPuzzle);
            List<int> actual = g.Blocks[4].CellsToNumbers();
            List<int> expected = new List<int>() { 6,8,3,7,9,4,5,2,1 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void CellsBlock5()
        {
            AdvancedGrid g = new AdvancedGrid(NakedSinglesMultipleAfterPuzzle);
            List<int> actual = g.Blocks[5].CellsToNumbers();
            List<int> expected = new List<int>() { 2,9,4,1,5,6,8,7,3 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void CellsBlock6()
        {
            AdvancedGrid g = new AdvancedGrid(NakedSinglesMultipleAfterPuzzle);
            List<int> actual = g.Blocks[6].CellsToNumbers();
            List<int> expected = new List<int>() { 2,3,9,8,6,4,5,1,7};
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void CellsBlock7()
        {
            AdvancedGrid g = new AdvancedGrid(NakedSinglesMultipleAfterPuzzle);
            List<int> actual = g.Blocks[7].CellsToNumbers();
            List<int> expected = new List<int>() { 8,7,6,9,1,5,4,3,2 };
            CollectionAssert.AreEqual(expected, actual);
        }



        [TestMethod()]

        public void CellsBlock8()
        {
            AdvancedGrid g = new AdvancedGrid(NakedSinglesMultipleAfterPuzzle);
            List<int> actual = g.Blocks[8].CellsToNumbers();
            List<int> expected = new List<int>() { 4,1,5,3,2,7,9,6,8 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void FindIntersectingCellsFirst()
        {
            var grid = new AdvancedGrid(Grid1);
            var actual = grid.GetIntersectingCells(0, 0);
            var expected = new List<string>()
            {"0:0", "0:1","0:2", "0:3", "0:4", "0:5", "0:6", "0:7", "0:8",
            "1:0", "2:0", "3:0", "4:0", "5:0", "6:0", "7:0", "8:0",
            "1:1", "1:2", "2:1", "2:2" };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void FindIntersectingCellsMiddle()
        {
            Technique g = new Technique(Grid1);
            var actual = g.Grid.GetIntersectingCells(4, 4);
            var expected = new List<string>()
            {"4:0", "4:1","4:2", "4:3", "4:4", "4:5", "4:6", "4:7", "4:8",
             "0:4", "1:4", "2:4", "3:4", "5:4", "6:4", "7:4", "8:4",
             "3:3", "3:5", "5:3", "5:5" };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void FindIntersectingCellsLast()
        {
            Technique g = new Technique(Grid1);
            var actual = g.Grid.GetIntersectingCells(8, 8);
            var expected = new List<string>()
            {"8:0", "8:1","8:2", "8:3", "8:4", "8:5", "8:6", "8:7", "8:8",
             "0:8", "1:8", "2:8", "3:8", "4:8", "5:8", "6:8", "7:8",
             "6:6", "6:7", "7:6", "7:7" };
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}