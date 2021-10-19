
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.Techniques;
using System;
using System.Collections.Generic;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudokuTests.SudokuSolver.Techniques
{
    [TestClass()]
    public class MultiLineTests
    {
        public int[,] SudokuOfTheDay { get; set; }
        public int[,] SudokuOfTheDay2 { get; set; }
        public int[,] SudokuOfTheDay3 { get; set; }
        public int[,] SudokuOfTheDay4 { get; set; }
        public int[,] SudokuOfTheDay5 { get; set; }
        public int[,] SudokuOfTheDay6 { get; set; }
        public int[,] SudokuOfTheDay7 { get; set; }
        public int[,] SudokuOfTheDay8 { get; set; }

        public int[,] SudokuOfTheDay9 { get; set; }

        public int[,] SudokuOfTheDay10 { get; set; }

        public MultiLineTests()
        {
            SudokuOfTheDay = new[,]
{
{0,0,9,0,3,0,6,0,0},
{0,3,6,0,1,4,0,8,9},
{1,0,0,8,6,9,0,3,5},
{0,9,0,0,0,0,8,0,0},
{0,1,0,0,0,0,0,9,0},
{0,6,8,0,9,0,1,7,0},
{6,0,1,9,0,3,0,0,2},
{9,7,2,6,4,0,3,0,0},
{0,0,3,0,2,0,9,0,0}


};

            SudokuOfTheDay2 = new[,]
{
{9,0,0,0,0,1,3,0,8},
{0,0,0,4,8,3,6,0,0},
{0,0,0,0,9,0,0,0,7},
{0,0,0,0,0,4,0,2,0},
{0,2,7,9,5,6,8,0,0},
{0,1,0,8,0,0,0,0,0},
{8,0,0,0,0,0,0,0,0},
{0,0,6,2,4,9,0,8,0},
{2,0,4,3,0,8,0,0,5}


};

            SudokuOfTheDay3 = new[,]
{
{0,0,6,0,5,0,7,0,0},
{0,5,9,6,0,0,1,0,0,},
{4,7,8,1,9,3,5,2,6},
{6,8,0,5,0,2,9,1,0},
{0,0,0,0,0,0,0,0,0},
{0,9,5,4,0,1,0,8,3},
{0,4,1,7,8,0,3,0,2 },
{8,0,2,0,0,5,4,7,0},
{0,0,7,0,0,0,8,0,0}


};

            SudokuOfTheDay4 = new[,]
{
{0,0,2,8,0,6,7,4,3},
{3,8,0,4,5,7,2,6,0},
{6,4,7,0,0,0,0,0,0},
{8,0,0,0,0,1,0,0,0},
{2,7,6,0,0,0,3,1,4},
{0,0,0,6,0,0,0,0,5 },
{0,2,0,0,6,0,0,9,7 },
{0,9,3,7,2,4,0,0,0},
{7,6,0,0,0,9,4,3,2}


};

            SudokuOfTheDay5 = new[,]
{
{0,0,0,5,1,8,3,2,4},
{1,8,0,0,4,0,9,0,0},
{0,0,0,0,0,9,0,8,1},
{6,1,0,8,9,3,4,5,0},
{0,0,8,1,6,5,0,3,9},
{0,5,0,4,7,2,8,1,6 },
{2,9,0,0,0,0,1,4,8},
{0,0,1,0,8,4,0,9,3},
{8,3,4,9,0,1,0,0,0}


};

            SudokuOfTheDay6 = new[,]
{
{0,0,0,0,0,0,0,7,0},
{0,0,0,4,0,0,9,1,0},
{0,0,0,1,0,0,0,6,3},
{0,4,0,0,9,2,1,0,7},
{8,0,9,0,5,0,6,4,2},
{2,0,7,6,4,0,0,9,0 },
{7,5,0,0,0,3,0,0,0},
{0,9,2,0,0,6,0,0,1},
{0,8,0,0,0,4,0,0,0}


};

            SudokuOfTheDay7 = new[,]
{
{0,6,0,0,3,0,0,7,4},
{0,2,0,4,6,7,9,1,8},
{0,7,0,1,0,0,0,6,3},
{0,4,0,3,9,2,1,8,7},
{8,3,9,7,5,1,6,4,2},
{2,1,7,6,4,8,3,9,5 },
{7,5,0,0,0,3,0,2,0},
{0,9,2,0,7,6,0,0,1},
{0,8,0,0,0,4,7,0,0}


};

            SudokuOfTheDay8 = new[,]
{
{3,8,0,1,0,0,4,0,5},
{0,5,0,0,4,3,0,0,6},
{0,0,4,0,0,0,3,0,9},
{0,3,7,0,0,4,0,9,0},
{0,2,0,0,7,0,0,4,3},
{4,9,0,3,0,0,7,0,0 },
{0,0,0,0,0,0,1,0,4},
{9,1,0,4,6,0,0,3,7},
{5,4,0,7,0,1,9,6,2}


};

            SudokuOfTheDay9 = new[,]
{
{2,0,4,3,0,0,8,0,0},
{0,8,0,0,0,1,2,0,3},
{0,0,1,9,2,8,0,7,0},
{0,0,5,0,0,0,1,0,0},
{0,0,0,1,5,4,0,0,0},
{1,0,7,8,0,2,6,0,0},
{0,1,0,0,8,9,0,0,0},
{4,9,3,2,0,0,0,8,0},
{0,0,8,0,0,3,9,0,6}


};

            SudokuOfTheDay10 = new[,]
{
{1,8,7,9,6,5,2,3,4},
{5,0,0,4,1,3,8,9,7},
{3,9,4,0,2,0,1,6,5},
{0,4,0,5,0,0,3,0,0},
{9,0,3,0,0,0,5,4,6},
{0,5,8,3,4,6,0,1,0},
{4,0,0,0,3,0,6,5,0},
{0,3,5,0,0,4,0,0,1},
{0,0,0,0,5,0,4,2,3}


};
        }

        [TestMethod()]

        public void SudokuOfTheDay1A()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actualB = t.Grid.Rows[3].Cells[0].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.MultiLine();
            var actual = t.Grid.Rows[3].Cells[0].Possibilities;
            var expected = new List<int>() { 2,3,4,7 };


            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }


            //3 or 4
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay1B()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actualB = t.Grid.Columns[0].Cells[3].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.MultiLine();
            var actual = t.Grid.Columns[0].Cells[3].Possibilities;
            var expected = new List<int>() { 2, 3, 4, 7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            //3 or 4
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay1C()
        {

            Technique t = new Technique(SudokuOfTheDay);
            var actualB = t.Grid.Blocks[3].Cells[0].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.MultiLine();
            var actual = t.Grid.Blocks[3].Cells[0].Possibilities;
            var expected = new List<int>() { 2, 3, 4, 7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            //3 or 4
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]


        public void SudokuOfTheDay1D()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actualB = t.Grid.Columns[0].Cells[4].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.MultiLine();
            var actual = t.Grid.Columns[0].Cells[4].Possibilities;
            var expected = new List<int>() { 2, 3, 4, 7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }

            //3 or 4
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]


        public void SudokuOfTheDay1DRows()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actualB = t.Grid.Rows[4].Cells[0].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.MultiLine();
            var actual = t.Grid.Rows[4].Cells[0].Possibilities;
            var expected = new List<int>() { 2, 3, 4, 7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay1E()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actualB = t.Grid.Columns[0].Cells[5].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.MultiLine();
            var actual = t.Grid.Columns[0].Cells[5].Possibilities;
            var expected = new List<int>() { 2, 3, 4 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            //
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay1ERow()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actualB = t.Grid.Rows[5].Cells[0].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.MultiLine();
            
            var actual = t.Grid.Rows[5].Cells[0].Possibilities;
            var expected = new List<int>() {  2,3, 4 };

            CollectionAssert.AreEqual(expected, actual);
        }




        [TestMethod()]

        public void SudokuOfTheDay1F()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.MultiLine();
            var actual = t.Grid.Columns[0].Cells[2].Possibilities;
            var expected = new List<int>() { };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay1G()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.MultiLine();
            var actual = t.Grid.Columns[0].Cells[2].Number;
            var expected = 1;
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay1H()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.MultiLine();
            var actual = t.Grid.Columns[0].Cells[6].Number;
            var expected = 6;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay1I()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.MultiLine();
            var actual = t.Grid.Columns[0].Cells[7].Number;
            var expected = 9;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay1J()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.MultiLine();
            var actual = t.Grid.Columns[0].Cells[8].Possibilities;
            var expected = new List<int>() { 4,5,8};
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay1JRow()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.MultiLine();
            var actual = t.Grid.Rows[8].Cells[0].Possibilities;
            var expected = new List<int>() { 4, 5, 8 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay1K()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.MultiLine();
            var actual = t.Grid.Columns[2].Cells[3].Possibilities;
            var expected = new List<int>() { 4, 5, 7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay1KRow()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.MultiLine();
            var actual = t.Grid.Rows[3].Cells[2].Possibilities;
            var expected = new List<int>() { 4, 5, 7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay1LCol()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.MultiLine();
            var actual = t.Grid.Columns[2].Cells[4].Possibilities;
            var expected = new List<int>() { 4, 5, 7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay1LRow()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.MultiLine();
            var actual = t.Grid.Rows[4].Cells[2].Possibilities;
            var expected = new List<int>() { 4, 5, 7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]

        public void SudokuOfTheDay1M()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.MultiLine();
            var actual = t.Grid.Columns[0].Cells[0].Possibilities;
            var expected = new List<int>() { 2,4,5,7,8};
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuOfTheDay1N()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.MultiLine();
            var actual = t.Grid.Columns[0].Cells[1].Possibilities;
            var expected = new List<int>() { 2, 5,7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing12()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(1, 2);
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing13()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(1,3);
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing23()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(2, 3);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing46()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(4,6);
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing56()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(5, 6);
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing45()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(4, 5);
            var expected = 6;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing79()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(7,9);
            var expected = 8;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing78()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(7, 8);
            var expected = 9;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing25()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(2,5);
            var expected = 8;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing28()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(2, 8);
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing58()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(5,8);
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing36()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(3,6);
            var expected = 9;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing39()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(3,9);
            var expected = 6;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing69()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(6,9);
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing21()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(2,1);
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing31()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(3,1);
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing32()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(3,2);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing17()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(1, 7);
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing47()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(4,7);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing14()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(1,4);
            var expected = 7;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing18()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(1, 8);
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing00()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(0,0);
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void FindMissing48()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findMissingBlock(4,8);
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Adjoining1()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findAdjoiningBlocksNew(1);
            var expected = new List<int>() { 2, 3, 4, 7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Adjoining2()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findAdjoiningBlocksNew(2);
            var expected = new List<int>() { 1,3,5,8};
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Adjoining3()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findAdjoiningBlocksNew(3);
            var expected = new List<int>() { 1,2,6,9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Adjoining4()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findAdjoiningBlocksNew(4);
            var expected = new List<int>() { 1,5,6,7};
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Adjoining5()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findAdjoiningBlocksNew(5);
            var expected = new List<int>() { 2, 4,6,8 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Adjoining6()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findAdjoiningBlocksNew(6);
            var expected = new List<int>() { 3,4,5,9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Adjoining7()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findAdjoiningBlocksNew(7);
            var expected = new List<int>() { 1,4,8,9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Adjoining8()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findAdjoiningBlocksNew(8);
            var expected = new List<int>() { 2,5,7,9};
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Adjoining9()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findAdjoiningBlocksNew(9);
            var expected = new List<int>() { 3,6,7,8 };
            foreach(var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Adjoining0()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.findAdjoiningBlocksNew(0);
            var expected = new List<int>() { };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]

        public void GetCellsA()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.getCellsInRows(1, 0, 1);
            var expected = new List<string>() {"0;0", "0;1", "0;2", "1;0", "1;1", "1;2" };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void GetCellsB()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.getCellsInRows(2, 0, 2);
            var expected = new List<string>() { "0;3", "0;4", "0;5", "2;3", "2;4", "2;5" };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void GetCellsC()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.getCellsInRows(4, 4,5);
            var expected = new List<string>() { "4;0", "4;1", "4;2", "5;0", "5;1", "5;2" };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void GetCellsD()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.getCellsInRows(9, 7,8);
            var expected = new List<string>() {"7;6", "7;7", "7;8", "8;6", "8;7", "8;8" };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void GetCellsAA()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.getCellsInCols(1, 0, 1);
            var expected = new List<string>() { "0;0", "0;1", "1;0", "1;1", "2;0",   "2;1" };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void GetCellsBB()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.getCellsInCols(2, 3,5);
            var expected = new List<string>() { "0;3", "0;5", "1;3", "1;5", "2;3", "2;5" };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void GetCellsCC()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.getCellsInCols(4, 1,2);
            var expected = new List<string>() { "3;1", "3;2", "4;1", "4;2", "5;1", "5;2" };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void GetCellsDD()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.getCellsInCols(9, 7,8);
            var expected = new List<string>() { "6;7", "6;8", "7;7", "7;8", "8;7",  "8;8" };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void CompareCells12()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.compareCells(1, 2);
            var expected = new List<int>() { 1,2,3,4,5,6,10,11,12,13,14,15,19,20,21,22,23,24 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void CompareCells27()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.compareCells(1, 7);
            var expected = new List<int>() { 1, 2, 3, 10,11,12,19,20,21,55,56,57,64,65,66,73,74,75};
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void CompareCells59()
        {
            Technique t = new Technique(SudokuOfTheDay);
            var actual = t.compareCells(5,9);
            var expected = new List<int>() { 31,32,33,40,41,42,49,50,51,61,62,63,70,71,72,79,80,81};
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void RowLineColLineA()
        {
            Technique t = new Technique(SudokuOfTheDay);
             t.findRowLineColLine(1, out int row, out int col);
            var actual = row + ";" + col;
            var expected = "0;0";
            
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]

        public void RowLineColLine81()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.findRowLineColLine(81, out int row, out int col);
            var actual = row + ";" + col;
            var expected = "8;8";

            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]

        public void RowLineColLineC()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.findRowLineColLine(40, out int row, out int col);
            var actual = row + ";" + col;
            var expected = "4;3";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void RowListColLisRow()
        {
            Technique t = new Technique(SudokuOfTheDay);
            List<int> cells = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
            t.findRowColList(cells, 5, out List<int> rowLine, out List<int> colLine, out bool isError);

            var actual = rowLine;
            var expected = new List<int>() { 0,0,0,0,1,1};
            foreach(var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]

        public void RowListColLisCol()
        {
            Technique t = new Technique(SudokuOfTheDay);
            List<int> cells = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
            t.findRowColList(cells, 5, out List<int> rowLine, out List<int> colLine, out bool isError);

            var actual = colLine;
            var expected = new List<int>() { 0, 1, 3, 5, 0,  3 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]

        public void RowListColListMultiEG()
        {
            Technique t = new Technique(SudokuOfTheDay);
            List<int> cells = new List<int>() { 1, 2, 3, 10, 11, 12,19,20,21,55,56,57,64,65,66,73,74,75};
            t.findRowColList(cells, 5, out List<int> rowLine, out List<int> colLine, out bool isError);

            var actual = rowLine;
            var expected = new List<int>() { 0,0,1,6,8, 8};
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void RowListColListMultiEGCol()
        {
            Technique t = new Technique(SudokuOfTheDay);
            List<int> cells = new List<int>() { 1, 2, 3, 10, 11, 12, 19, 20, 21, 55, 56, 57, 64, 65, 66, 73, 74, 75 };
            t.findRowColList(cells, 5, out List<int> rowLine, out List<int> colLine, out bool isError);

            var actual = colLine;
            var expected = new List<int>() {0,1,0,1,0,1};
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


       
        [TestMethod()]
        public void SudokuOfTheFiendish3A()
        {
            Technique t = new Technique(SudokuOfTheDay3);
            var actualB = t.Grid.Columns[0].Cells[4].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.MultiLine();
            var actual = t.Grid.Columns[0].Cells[4].Possibilities;
            var expected = new List<int>() { 1,2,7};
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish3B()
        {
            Technique t = new Technique(SudokuOfTheDay3);
            var actualB = t.Grid.Columns[1].Cells[4].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.MultiLine();
            var actual = t.Grid.Columns[1].Cells[4].Possibilities;
            var expected = new List<int>() { 1, 2 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheFiendish3C()
        {
            Technique t = new Technique(SudokuOfTheDay3);
            var actualB = t.Grid.Rows[4].Cells[0].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.MultiLine();
            var actual = t.Grid.Rows[4].Cells[0].Possibilities;
            var expected = new List<int>() { 1, 2,7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfTheFiendish3D()
        {
            Technique t = new Technique(SudokuOfTheDay3);
            var actualB = t.Grid.Rows[4].Cells[1].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.MultiLine();
            var actual = t.Grid.Rows[4].Cells[1].Possibilities;
            var expected = new List<int>() { 1, 2 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish4A()
        {
            Technique t = new Technique(SudokuOfTheDay4);
            var actualB = t.Grid.Rows[3].Cells[3].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.MultiLine();
            var actual = t.Grid.Rows[3].Cells[3].Possibilities;
            var expected = new List<int>() { 2,3,5 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish4B()
        {
            Technique t = new Technique(SudokuOfTheDay4);
            var actualB = t.Grid.Rows[3].Cells[4].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.MultiLine();
            var actual = t.Grid.Rows[3].Cells[4].Possibilities;
            var expected = new List<int>() { 3,4,7};
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish4C()
        {
            Technique t = new Technique(SudokuOfTheDay4);
            var actualB = t.Grid.Rows[5].Cells[4].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.MultiLine();
            var actual = t.Grid.Rows[5].Cells[4].Possibilities;
            var expected = new List<int>() { 3,4,7,8 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish5A()
        {
            Technique t = new Technique(SudokuOfTheDay5);
            t.MultiLine();
            var actual = t.Grid.Blocks[0].Cells[5].Possibilities;
            var expected = new List<int>() { 2,3,5 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish5B()
        {
            Technique t = new Technique(SudokuOfTheDay5);
            t.MultiLine();
            var actual = t.Grid.Blocks[0].Cells[6].Possibilities;
            var expected = new List<int>() { 3,4,5};
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish5C()
        {
            Technique t = new Technique(SudokuOfTheDay5);
            t.MultiLine();
            var actual = t.Grid.Blocks[0].Cells[7].Possibilities;
            var expected = new List<int>() { 2, 4 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish6A()
        {
            Technique t = new Technique(SudokuOfTheDay6);
            t.MultiLine();
            var actual = t.Grid.Blocks[0].Cells[0].Possibilities;
            var expected = new List<int>() { 1,3,4,5,9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish6B()
        {
            Technique t = new Technique(SudokuOfTheDay6);
            t.MultiLine();
            var actual = t.Grid.Blocks[0].Cells[2].Possibilities;
            var expected = new List<int>() { 1, 3, 4, 5, 8 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish6C()
        {
            Technique t = new Technique(SudokuOfTheDay6);
            t.MultiLine();
            var actual = t.Grid.Blocks[0].Cells[3].Possibilities;
            var expected = new List<int>() { 3,5};
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish6D()
        {
            Technique t = new Technique(SudokuOfTheDay6);
            t.MultiLine();
            var actual = t.Grid.Blocks[0].Cells[5].Possibilities;
            var expected = new List<int>() { 3,5,8 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish7A()
        {
            Technique t = new Technique(SudokuOfTheDay7);
            t.MultiLine();
            var actual = t.Grid.Blocks[0].Cells[0].Possibilities;
            var expected = new List<int>() { 1,9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish7B()
        {
            Technique t = new Technique(SudokuOfTheDay7);
            t.MultiLine();
            var actual = t.Grid.Blocks[0].Cells[2].Possibilities;
            var expected = new List<int>() { 1, 8 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish7C()
        {
            Technique t = new Technique(SudokuOfTheDay7);
            t.MultiLine();
            var actual = t.Grid.Blocks[0].Cells[6].Possibilities;
            var expected = new List<int>() { 4, 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish7D()
        {
            Technique t = new Technique(SudokuOfTheDay7);
            t.MultiLine();
            var actual = t.Grid.Blocks[0].Cells[8].Possibilities;
            var expected = new List<int>() {4,8};
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish8A()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actualB = t.Grid.Rows[3].Cells[0].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.MultiLine();
            t.MultiLine();
            var actual = t.Grid.Rows[3].Cells[0].Possibilities;
            var expected = new List<int>() { 6,8 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SudokuOfTheFiendish8B()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actualB = t.Grid.Rows[5].Cells[2].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.MultiLine();
            t.MultiLine();
            var actual = t.Grid.Rows[5].Cells[2].Possibilities;
            var expected = new List<int>() { 5,6, 8 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuGetDistinctBlocks()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getDistinctBlocks(false);
           
            var expected = new List<string>() { "1;2", "1;3", "1;4", "1;7", "2;3", "2;5", "2;8", "3;6", "3;9", "4;5", "4;6", "4;7", "5;6", "5;8", "6;9", "7;8", "7;9", "8;9" };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void GetCellsInRowBlock4C()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInRows(5, 3, 5);

            var expected = new List<string>() { "3;3", "3;4", "3;5", "5;3", "5;4", "5;5" };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCellsInRowBlock4A()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInRows(5, 3, 4);

            var expected = new List<string>() { "3;3", "3;4", "3;5", "4;3", "4;4", "4;5" };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCellsInRowBlock4B()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInRows(5, 4,5);

            var expected = new List<string>() { "4;3", "4;4", "4;5", "5;3", "5;4", "5;5" };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCellsInColsBlock4C()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInCols(5, 3, 5);

            var expected = new List<string>() { "3;3", "3;5", "4;3", "4;5", "5;3", "5;5" };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCellsInColsBlock4A()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInCols(5, 3, 4);

            var expected = new List<string>() { "3;3", "3;4", "4;3", "4;4", "5;3", "5;4" };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCellsInColsBlock4B()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInCols(5, 4, 5);

            var expected = new List<string>() { "3;4", "3;5", "4;4", "4;5", "5;4", "5;5" };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCellsInColsBlock5A()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInCols(5, 3,5);

            var expected = new List<string>() { "3;3", "3;5", "4;3", "4;5", "5;3", "5;5" };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCellsInColsBlock8B()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInCols(7, 1,2);

            var expected = new List<string>() { "6;1", "6;2", "7;1", "7;2", "8;1", "8;2" };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCellsInColsBlock8C()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInCols(8, 4,5);

            var expected = new List<string>() { "6;4", "6;5", "7;4", "7;5", "8;4","8;5" };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCellsInColsBlockErrorO()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInCols(0, 6, 8);

            var expected = new List<string>() { };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCellsInColsBlockError2()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInCols(1, 1,10);

            var expected = new List<string>() { };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCellsInColsBlockError3()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInCols(2, 10, 0);

            var expected = new List<string>() {  };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }



        [TestMethod()]
        public void GetCellsInColsBlockErrorB()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInCols(1,7,8);

            var expected = new List<string>() { };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCellsInColsBlock9A()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInRows(9, 7,8);

            var expected = new List<string>() { "7;6", "7;7", "7;8", "8;6", "8;7", "8;8" };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCellsInColsBlock9B()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInCols(9, 7, 8);

            var expected = new List<string>() { "6;7", "6;8", "7;7", "7;8", "8;7", "8;8"};
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void GetCellsInColsBlock9()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInRows(9, 1, 2);

            var expected = new List<string>() { };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCellsInRowsBlockErrorO()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInRows(0, 6, 8);

            var expected = new List<string>() { };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCellsInRowsBlockError2()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInRows(1, 1, 10);

            var expected = new List<string>() { };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCellsInRowsBlockError3()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInRows(2, 10, 0);

            var expected = new List<string>() { };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }



        [TestMethod()]
        public void GetCellsInRowsBlockErrorB()
        {
            Technique t = new Technique(SudokuOfTheDay8);
            var actual = t.getCellsInCols(1, 7, 8);

            var expected = new List<string>() {};
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfThDay10()
        {
            Technique t = new Technique(SudokuOfTheDay10);
            t.Claiming();
            t.MultiLine();
            var actualB = t.Grid.Blocks[4].Cells[2].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            var actual = t.Grid.Blocks[4].Cells[2].Possibilities;
            var expected = new List<int>() { 1,2,9};
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfThDay10b()
        {
            Technique t = new Technique(SudokuOfTheDay10);
            var actualB = t.Grid.Blocks[4].Cells[3].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.Claiming();
            t.MultiLine();
            var actual = t.Grid.Blocks[4].Cells[3].Possibilities;
            var expected = new List<int>() { 1, 2, 8 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfThDay10c()
        {
            Technique t = new Technique(SudokuOfTheDay10);
            var actualB = t.Grid.Blocks[4].Cells[5].Possibilities;
            foreach (var x in actualB)
            {
                Console.WriteLine(x + "~");
            }
            t.Claiming();
            t.MultiLine();
            var actual = t.Grid.Blocks[4].Cells[5].Possibilities;
            var expected = new List<int>() { 1, 2, 8 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfThDay9()
        {
            Technique t = new Technique(SudokuOfTheDay9);
            t.MultiLine();
            var actual = t.Grid.Blocks[0].Cells[3].Possibilities;
            var expected = new List<int>() { 5,7,9};
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfThDay9b()
        {
            Technique t = new Technique(SudokuOfTheDay9);
            t.MultiLine();
            var actual = t.Grid.Blocks[0].Cells[1].Possibilities;
            var expected = new List<int>() { 5,7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SudokuOfThDay9c()
        {
            Technique t = new Technique(SudokuOfTheDay9);
            t.MultiLine();
            var actual = t.Grid.Blocks[0].Cells[5].Possibilities;
            var expected = new List<int>() {  9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}