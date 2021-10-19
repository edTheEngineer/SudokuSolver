
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.Techniques;
using System;
using System.Collections.Generic;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudokuTests.SudokuSolver.Techniques.Medium
{
    [TestClass()]
    public class NakedPairsTests
    {
        public int[,] NakedPairBefore { get; set; }
        public int[,] NoNakedPair { get; set; }

        public int[,] NRichNakedPair { get; set; }

        public int[,] NRichNotNakedPair { get; set; }

        public int[,] NakedPairEasy { get; set; }
        public NakedPairsTests()
        {
            NakedPairBefore = new [,]
            {
                {0,0,1,4,9,0,7,0,0},
                {0,0,4,0,0,6,9,0,0},
                {8,0,9,0,1,7,5,4,0},
                {2,8,0,0,7,0,0,5,9,},
                {4,1,7,9,0,0,2,6,8},
                {5,9,0,0,2,0,0,0,0},
                {0,4,5,0,8,0,0,0,3},
                {0,0,8,7,0,0,0,0,0},
                {0,0,2,0,0,9,8,0,0},

            };

            NoNakedPair = new[,]
            {
                {0,0,1,4,9,0,7,0,0},
                {0,0,4,0,0,0,9,0,0},
                {8,0,0,0,1,7,5,0,0},
                {2,8,0,0,7,0,0,5,9,},
                {4,1,7,0,0,0,2,6,8},
                {5,0,0,0,2,0,0,0,0},
                {0,4,0,0,8,0,0,0,3},
                {0,0,8,7,0,0,0,0,0},
                {0,0,2,0,0,0,8,0,0},

            };

            NRichNotNakedPair = new[,]
            {
                {0,0,0,0,9,0,0,0,6},
                {0,0,0,6,0,2,0,0,5},
                {8,0,0,4,0,3,7,2,0},
                {6,4,9,0,0,0,0,0,0},
                {2,0,0,9,0,4,0,0,0},
                {1,0,3,0,6,0,9,0,4},
                {5,0,4,0,0,6,0,8,0},
                {0,0,0,0,4,0,1,0,7},
                {7,1,0,0,0,0,0,4,0},

            };

            NRichNakedPair = new[,]
            {
                {0,0,0,0,9,0,0,0,6},
                {0,0,0,6,0,2,0,0,5},
                {8,0,0,4,0,3,7,2,0},
                {0,4,9,0,0,0,0,0,0},
                {0,0,0,9,0,4,0,0,0},
                {1,0,3,0,6,0,9,0,4},
                {5,0,4,0,0,6,0,8,0},
                {0,0,0,0,4,0,1,0,7},
                {7,1,0,0,0,0,0,4,0},

            };

            NakedPairEasy = new[,]
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
        }

        public void PrintAnswer(List<int> possibilities)
        {
            foreach (var x in possibilities)
            {
                Console.Write(x + ",");
            }
        }
        [TestMethod()]

        public void NakedPairIsNakedPair()
        {
            Technique t = new Technique(NakedPairBefore);
            var actual = t.IsNakedPair();
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]

        public void NakedPairIsNotNakedPair()
        {
            Technique t = new Technique(NoNakedPair);

            var actual = t.IsNakedPair();
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]

        public void NRichIsNakedPair()
        {
            Technique t = new Technique(NRichNakedPair);
            var actual = t.IsNakedPair();
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]

        public void NRichIsNotNakedPair()
        {
            Technique t = new Technique(NRichNotNakedPair);
            var actual = t.IsNakedPair();
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]

        public void NakedPairEliminateNakedPair_1()
        {
            Technique t = new Technique(NakedPairBefore);
            t.NakedPair();
            var expected = new List<int>(){1,6};
            var actual = t.Grid.Rows[3].Cells[3].Possibilities;
            PrintAnswer(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void NakedPairEliminateNakedPair_2()
        {
            Technique t = new Technique(NakedPairBefore);
            t.NakedPair();
            var expected = new List<int>() { 1, 4};
            var actual = t.Grid.Rows[3].Cells[5].Possibilities;
            PrintAnswer(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void NakedPairEliminateNakedPair_3()
        {
            Technique t = new Technique(NakedPairBefore);
            t.NakedPair();
            var expected = new List<int>() { 1,6,8 };
            var actual = t.Grid.Rows[5].Cells[3].Possibilities;
            PrintAnswer(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void NakedPairEliminateNakedPair_4()
        {
            Technique t = new Technique(NakedPairBefore);
            t.NakedPair();
            var expected = new List<int>() { 1,4,8 };
            var actual = t.Grid.Rows[5].Cells[5].Possibilities;
            PrintAnswer(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void NRIchEliminateNakedPair_1()
        {
            Technique t = new Technique(NRichNakedPair);
            t.NakedPair();
            var expected = new List<int>() { 3,4};
            var actual = t.Grid.Rows[0].Cells[0].Possibilities;
            PrintAnswer(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

       
        [TestMethod()]

        public void NRIchEliminateNakedPair_4()
        {
            Technique t = new Technique(NRichNakedPair);
            t.NakedPair();
            var expected = new List<int>() { 5,7,8};
            var actual = t.Grid.Rows[4].Cells[1].Possibilities;
            PrintAnswer(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void NRIchEliminateNakedPair_51()
        {
            Technique t = new Technique(NRichNakedPair);
            t.NakedPair();
            var expected = new List<int>() { 5,7,8 };
            var actual = t.Grid.Rows[4].Cells[2].Possibilities;
            PrintAnswer(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void NRIchEliminateNakedPair_6()
        {
            Technique t = new Technique(NRichNakedPair);
            t.NakedPair();
            var expected = new List<int>() { 5,7,8 };
            var actual = t.Grid.Rows[5].Cells[1].Possibilities;
            PrintAnswer(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void NRIchEliminateNakedPair_9()
        {
            Technique t = new Technique(NRichNakedPair);
            
            t.NakedPair();
            var expected = new List<int>() { 3,9 };
            var actual = t.Grid.Rows[7].Cells[0].Possibilities;
            PrintAnswer(actual);
           

            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void EasyNakedPair()
        {
            Technique t = new Technique(NakedPairEasy);
            t.NakedPair();
            var expected = new List<int>() { 3,6,9 };
            var actual = t.Grid.Rows[8].Cells[0].Possibilities;
            PrintAnswer(actual);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void IsNotNakedPairGroupOneMissing()
        {
            Technique t = new Technique(NRichNakedPair);
            var g = new[] {1, 2, 3, 4, 5, 6, 7, 0, 9};
            Group gr = new Group(g);
            var actual = t.IsNakedPair(gr);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void IsNotNakedPairGroup()
        {
            Technique t = new Technique(NRichNakedPair);
            var g = new [] { 1,2,3,4,5,6,0,0,0 };
            Group gr = new Group(g);
            var actual = t.IsNakedPair(gr);
            Assert.AreEqual(false, actual);
        }
        [TestMethod()]
        public void IsNakedPairGroup()
        {
            Technique t = new Technique(NRichNakedPair);
            var g = new[] { 1, 2, 3, 0,0, 6, 7,8,9};
            Group gr = new Group(g);
            var actual = t.IsNakedPair(gr);
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void IsCommonCoordinatesrOrBlock()
        {
            Technique t = new Technique(NRichNakedPair);

            var actual = t.IsCommonCoordinates(0, 0, 0, 1);
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void IsCommonCoordinatesRowOnly()
        {
            Technique t = new Technique(NRichNakedPair);
            var actual = t.IsCommonCoordinates(0, 0, 0, 8);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void IsCommonCoordinatesColBlock()
        {
            Technique t = new Technique(NRichNakedPair);
            var actual = t.IsCommonCoordinates(1, 0, 1, 1);
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void IsCommonCoordinatesColOnly()
        {
            Technique t = new Technique(NRichNakedPair);
            var actual = t.IsCommonCoordinates(1, 0, 8, 0);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void BlockOnly()
        {
            Technique t = new Technique(NRichNakedPair);
            var actual = t.IsCommonCoordinates(0, 1, 3,3);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void None()
        {
            Technique t = new Technique(NRichNakedPair);
            var actual = t.IsCommonCoordinates(0, 0, 8,8);
            Assert.AreEqual(false, actual);
        }


        [TestMethod()]
        public void IsCommonCoordinatesOrBlockReverse()
        {
            Technique t = new Technique(NRichNakedPair);
            var actual = t.IsCommonCoordinates(0, 1, 0, 0);
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void IsCommonCoordinatesRowOnlyReverse()
        {
            Technique t = new Technique(NRichNakedPair);
            var actual = t.IsCommonCoordinates(0, 8, 0, 0);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void IsCommonCoordinatesColBlockReverse()
        {
            Technique t = new Technique(NRichNakedPair);
            var actual = t.IsCommonCoordinates(1, 1, 1, 0);
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void IsCommonCoordinatesColOnlyReverse()
        {
            Technique t = new Technique(NRichNakedPair);
            var actual = t.IsCommonCoordinates(8, 0, 1, 0);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void BlockOnlyReverse()
        {
            Technique t = new Technique(NRichNakedPair);
            var actual = t.IsCommonCoordinates(3,3, 0,1);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void NoneReverse()
        {
            Technique t = new Technique(NRichNakedPair);
            var actual = t.IsCommonCoordinates(8,8,0,0);
            Assert.AreEqual(false, actual);
        }
    }
}