using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.Techniques;

namespace RazorPagesSudokuTests.SudokuSolver.Techniques.Easy
{
    [TestClass()]
    public class PencilMarksTests
    {
        public int[,] BlankGrid { get; set; }
        public int[,] AscendingGrid { get; set; }

        public int[,] BlockInteraction { get; set; }

        public List<int> BlankList { get; set; }

       
        public PencilMarksTests()
            {
            BlankGrid = new [,]
                 {
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0}
                 };

            AscendingGrid = new [,]
                 {
                 { 0,0,0,0,0,0,0,0,1 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,4,1,0,0,0,0},
                 { 0,0,0,5,6,0,0,0,0 },
                 { 9,0,0,7,8,3,0,0,0}
                 };

            BlockInteraction = new[,]
     {
                 { 0,0,0,0,0,0,0,0,1 },
                 { 0,3,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 2,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,4,1,0,0,0,0},
                 { 0,0,0,5,6,0,0,0,0 },
                 { 0,0,0,7,8,3,0,0,0}
     };

            BlankList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        [TestMethod()]

        public void CheckPencilMarks_AscendingGridStart()

        {
            Technique t = new Technique(AscendingGrid);
            List<int> expected = new List<int>{2,3,4,5,6,7,8};
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Rows[0].Cells[0].Possibilities;

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void CheckPencilMarks_AscendingGridMiddle()

        {
            Technique t = new Technique(AscendingGrid);
            List<int> expected = new List<int> { 2, 9 };
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Rows[6].Cells[5].Possibilities;
            t.PrintNumbers();
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void CheckPencilMarks_AscendingGridEnd()

        {
            Technique t = new Technique(AscendingGrid);
            List<int> expected = new List<int>() {2,4,5,6};
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Rows[8].Cells[8].Possibilities;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var poss = t.Grid.Rows[i].Cells[j].Possibilities;

                    foreach (var x in poss)
                    {
                        
                        Console.Write(x);
                    }
                    Console.WriteLine("");
                }
            }
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void CheckPencilMarks_BlankGridStart()

        {
            Technique t = new Technique(BlankGrid);
            List<int> expected = BlankList;
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Rows[0].Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void CheckPencilMarks_BlankGridMiddle()

        {
            Technique t = new Technique(BlankGrid);
            List<int> expected = BlankList;
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Rows[5].Cells[5].Possibilities;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void CheckPencilMarks_BlankGridEnd()

        {
            Technique t = new Technique(BlankGrid);
            List<int> expected = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Rows[8].Cells[8].Possibilities;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void CheckRowBlank()

        {
            Technique t = new Technique(BlockInteraction);
            List<int> expected = new List<int>() { 4,5,6,7,8,9};
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Rows[0].Cells[0].Possibilities;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void CheckColumnBlank()

        {
            Technique t = new Technique(BlockInteraction);
            List<int> expected = new List<int>() { 4, 5, 6, 7, 8, 9 };
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Columns[0].Cells[0].Possibilities;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void CheckBlockBlank()

        {
            Technique t = new Technique(BlockInteraction);
            List<int> expected = new List<int>() { 4, 5, 6, 7, 8, 9 };
            t.Grid.RemovePossibilitiesFromIntersectingCells();
            var actual = t.Grid.Blocks[0].Cells[0].Possibilities;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]

        public void BlockListAll()
        {
            Technique t = new Technique(BlockInteraction);
            List<int> expected = new List<int>() 
            { 4, 5, 6, 7, 8, 9,
            2,4,5,6,7,8,9,
            2,4,5,6,7,8,9,
            1,4,5,6,7,8,9,
            1,2,4,5,6,7,8,9,
            1,4,5,6,7,8,9,
            1,2,4,5,6,7,8,9,
            1,2,4,5,6,7,8,9};

            var actual = t.FindAllPossibilitiesInAGroup(t.Grid.Blocks[0]);
            foreach(var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(actual, expected);
        }
    }

    
}