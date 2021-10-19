
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.Techniques;
using System;
using System.Collections.Generic;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudokuTests.SudokuSolver.Techniques.Medium
{
    [TestClass()]
    public class DoublePairTests
    {
        public int[,] SudokuOfTheDay { get; set; }

        public int[,] SudokuOfTheDay2 { get; set; }

        public int[,] SudokuOfTheDay3 { get; set; }

        public int[,] SudokuOfTheDay4 { get; set; }

        public int[,] SudokuOfTheDay5 { get; set; }

        public int[,] SudokuOfTheDay6 { get; set; }

        public int[,] SudokuOfTheDay7 { get; set; }

        public int[,] SudokuOfTheDay8 { get; set; }






        public DoublePairTests()
        {
            SudokuOfTheDay = new[,]
{
{9,3,4,0,6,0,0,5,8},
{0,0,6,0,0,4,9,2,3},
{2,0,8,9,0,0,0,4,6},
{8,0,0,5,4,6,0,0,7},
{6,0,0,0,1,0,0,0,5},
{5,0,0,3,9,0,0,6,2},
{3,6,0,4,0,1,2,7,0},
{4,7,0,6,0,0,5,0,0},
{0,8,0,0,0,0,6,3,4}


};


            SudokuOfTheDay2 = new[,]
{
{0,1,8,5,0,7,0,0,2},
{0,7,2,1, 0,3,0,8,0},
{0,5,0,8,6,2,9,7,1},
{1,0,7,4,8,5,2,0,9},
{0,0,0,2,1,9,0,0,0},
{0,2,9,3,7,6,0,1,4},
{0,4,6,7,2,8,1,9,0},
{7,8,1,9,0,4,0,2,0},
{2,9,0,6,0,1,0,0,0}


};


            SudokuOfTheDay3 = new[,]
{
{0,0,1,7,2,5,0,0,0},
{0,9,0,0,4,8,2,7,0},
{0,7,0,0,0,0,5,0,0 },
{1,3,0,5,0,0,0,2,8},
{0,6,0,0,0,0,0,3,5},
{0,0,0,0,0,2,0,1,6 },
{0,0,7,0,5,0,0,4,0},
{0,5,3,2,8,0,0,0,0},
{0,0,0,0,9,0,8,5,0},



};

            SudokuOfTheDay4 = new[,]
{
{0,0,2,8,0,6,7,4,3},
{3,8,0,4,5,7,2,6,0},
{6,4,7,0,0,0,0,0,0},
{8,0,0,0,0,1,0,0,0},
{2,7,6,0,0,0,3,1,4},
{0,0,0,6,0,0,0,0,5},
{0,2,0,0,6,0,0,9,7},
{0,9,3,7,2,4,0,0,0},
{7,6,0,0,0,9,4,3,2 },



};

            SudokuOfTheDay5 = new[,]
{
{2,5,6,0,0,3,0,8,0},
{0,0,4,0,2,0,0,3,6},
{0,3,8,0,0,6,0,2,5},
{0,2,9,3,6,4,0,7,1},
{3,0,0,7,0,2,0,6,4},
{4,6,7,0,0,0,2,0,3},
{6,0,2,9,0,0,3,4,0},
{0,4,0,2,3,0,6,0,0},
{0,9,3,6,4,0,0,1,2},



};

            SudokuOfTheDay6 = new[,]
{
{0,6,5,4,1,8,7,3,0},
{7,1,3,0,5,0,8,0,4},
{8,0,4,0,7,3,0,5,1},
{5,8,7,3,2,1,4,9,6 },
{0,0,1,0,4,7,5,8,3},
{3,4,0,5,8,0,1,0,0},
{4,5,0,7,0,2,0,1,8},
{1,0,2,8,9,4,0,0,5},
{0,0,8,1,0,5,2,4,0},

};

            SudokuOfTheDay7 = new[,]
{
{0,9,0,8,0,1,5,0,0},
{4,0,1,0,6,2,9,8,7},
{0,8,0,0,9,0,0,1,2 },
{6,0,0,0,1,0,8,7,3},
{1,0,0,0,8,0,0,0,0},
{8,7,5,6,0,0,1,0,9},
{7,6,0,0,0,8,0,9,1},
{0,1,0,9,4,6,7,0,8},
{9,0,8,1,0,0,0,6,0},

};

            SudokuOfTheDay8= new[,]
{
{2,0,4,3,0,0,8,0,0},
{0,8,9,0,0,1,2,0,3},
{0,0,1,9,2,8,0,7,0},
{0,0,5,0,0,0,1,0,0},
{0,0,0,1,5,4,0,0,0},
{1,0,7,8,0,2,6,0,0},
{0,1,0,0,8,9,0,0,0},
{4,9,3,2,0,0,0,8,0},
{0,0,8,0,0,3,9,0,6},

};
        }

        [TestMethod()]

        public void SudokuOfTheDay1A()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.DoublePair();
            var actual = t.Grid.Rows[7].Cells[5].Possibilities;
            var expected = new List<int>() { 3,8,9};
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay1B()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.DoublePair();
            var actual = t.Grid.Rows[8].Cells[3].Possibilities;
            var expected = new List<int>() { 7};
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]

        public void SudokuOfTheDay1C()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.DoublePair();
            var actual = t.Grid.Columns[3].Cells[8].Possibilities;
            var expected = new List<int>() { 7 };
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
            t.DoublePair();
            var actual = t.Grid.Blocks[7].Cells[6].Possibilities;
            var expected = new List<int>() { 7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay1E()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.DoublePair();
            var actual = t.Grid.Blocks[7].Cells[8].Possibilities;
            var expected = new List<int>() { 5,7,9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        
        [TestMethod()]



        public void AdjoiningZero()
        {
            Technique t = new Technique();

            var actual = t.findAdjoiningBlocks(0);
            var expected = new List<int>() { 1,2, 3,6};
            foreach(var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void AdjoiningOne()
        {
            Technique t = new Technique();

            var actual = t.findAdjoiningBlocks(1);
            var expected = new List<int>() { 0,2,4,7};
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void AdjoiningTwo()
        {
            Technique t = new Technique();

            var actual = t.findAdjoiningBlocks(2);
            var expected = new List<int>() { 0,1,5,8};
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void AdjoiningThree()
        {
            Technique t = new Technique();

            var actual = t.findAdjoiningBlocks(3);
            var expected = new List<int>() { 0,4,5,6 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void AdjoiningFour()
        {
            Technique t = new Technique();

            var actual = t.findAdjoiningBlocks(4);
            var expected = new List<int>() {1,3,5,7};
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void AdjoiningFive()
        {
            Technique t = new Technique();

            var actual = t.findAdjoiningBlocks(5);
            var expected = new List<int>() { 2,3,4,8 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void AdjoiningSix()
        {
            Technique t = new Technique();

            var actual = t.findAdjoiningBlocks(6);
            var expected = new List<int>() { 0,3,7,8 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void AdjoiningSeven()
        {
            Technique t = new Technique();

            var actual = t.findAdjoiningBlocks(7);
            var expected = new List<int>() { 1, 4,6,8};
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void AdjoiningEight()
        {
            Technique t = new Technique();

            var actual = t.findAdjoiningBlocks(8);
            var expected = new List<int>() { 2,5,6,7};
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
            var actualB = t.Grid.Blocks[4].Cells[3].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.Claiming();
            t.DoublePair();
            var actual = t.Grid.Rows[4].Cells[0].Possibilities;
            var expected = new List<int>() {4,5,8 };
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
            t.DoublePair();
            var actual = t.Grid.Rows[4].Cells[2].Possibilities;
            var expected = new List<int>() { 4, 5 };
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
            t.DoublePair();
            var actual = t.Grid.Columns[0].Cells[6].Possibilities;
            var expected = new List<int>() { 6, 8, 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay3B()
        {
            Technique t = new Technique(SudokuOfTheDay3);
            t.DoublePair();
            var actual = t.Grid.Columns[0].Cells[8].Possibilities;
            var expected = new List<int>() { 4,6 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay3C()
        {
            Technique t = new Technique(SudokuOfTheDay3);
            t.DoublePair();
            var actual = t.Grid.Columns[2].Cells[8].Possibilities;
            var expected = new List<int>() {4,6 };
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
            t.DoublePair();
            var actual = t.Grid.Blocks[8].Cells[0].Possibilities;
            var expected = new List<int>() { 1,5};
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay5A()
        {
            Technique t = new Technique(SudokuOfTheDay5);
            var actualB = t.Grid.Blocks[4].Cells[3].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.Claiming();
            t.DoublePair();
            var actual = t.Grid.Rows[4].Cells[4].Possibilities;
            var expected = new List<int>() { 5,9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay6B() //Might fail needs x filling in
        {
            Technique t = new Technique(SudokuOfTheDay6);
            t.DoublePair();
            var actual = t.Grid.Rows[6].Cells[6].Possibilities;
            var expected = new List<int>() {3, 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay6A()
        {
            Technique t = new Technique(SudokuOfTheDay6);
            t.DoublePair();
            var actual = t.Grid.Blocks[1].Cells[6].Possibilities;
            var expected = new List<int>() { 2,6 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay7A()
        {
            Technique t = new Technique(SudokuOfTheDay7);
            t.DoublePair();
            var actual = t.Grid.Rows[8].Cells[4].Possibilities;
            var expected = new List<int>() { 2,3,7};
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay7B()
        {
            Technique t = new Technique(SudokuOfTheDay7);
            t.DoublePair();
            var actual = t.Grid.Rows[8].Cells[5].Possibilities;
            var expected = new List<int>() { 3, 7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay8A()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actualB = t.Grid.Columns[7].Cells[0].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedPair();
            t.DoublePair();
            var actual = t.Grid.Columns[7].Cells[0].Possibilities;
            var expected = new List<int>() { 1,6,9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay8B()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actualB = t.Grid.Columns[7].Cells[1].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedPair();
            t.DoublePair();
            var actual = t.Grid.Columns[7].Cells[1].Possibilities;
            var expected = new List<int>() {6};
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay8C()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actualB = t.Grid.Columns[8].Cells[0].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.NakedPair();
            t.DoublePair();
            var actual = t.Grid.Columns[8].Cells[0].Possibilities;
            var expected = new List<int>() { 1,  9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}