using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudokuTests.SudokuSolver.CoreClasses
{
    [TestClass()]
    public class AdvancedGridTests
    {
        public int[,] Grid1 { get; set; }
        public int[,] GridValidExample { get; set; }
        public int[,] InvalidRow { get; set; }

        public int[,] InvalidRow2 { get; set; }

        public int[,] InvalidCol { get; set; }
        public int[,] InvalidBlock { get; set; }
        public int[,] InvalidMultiRC { get; set; }

        public int[,] InvalidMultiRB { get; set; }

        public int[,] InvalidMultiCB { get; set; }

        public int[,] InvalidMultiRCB { get; set; }

        public int[,] InvalidMultiAll { get; set; }

        public int[,]  Blank { get; set; }

        public AdvancedGridTests()

        {
            
            Grid1 = new[,]
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

            GridValidExample = new[,]
    {
                 { 5,0,0,0,0,2,0,8,0 },
                 { 4,2,8,3,0,0,0,0,7 },
                 { 0,0,3,0,0,0,0,0,6 },
                 { 0,0,2,1,0,0,0,0,0},
                 { 1,0,0,5,0,6,0,0,4 },
                 { 0,0,0,0,0,3,9,0,0 },
                 { 3,0,0,0,0,0,5,0,0 },
                 { 7,0,0,0,0,1,4,6,2},
                 { 0,1,0,7,0,0,0,0,3}
                };

            InvalidRow = new[,]
                {
                 { 0,0,0,0,0,0,0,0,0 },
                 { 1,8,3,4,5,6,7,8,9},
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0}
                };
            InvalidRow2 = new[,]
     {
                 { 0,0,0,0,0,0,0,0,0 },
                 { 1,2,3,4,5,6,7,8,8},
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0}
                };

            InvalidCol = new[,]
     {
                 { 0,0,0,0,0,0,0,1,0 },
                 { 0,0,0,0,0,0,0,2,0 },
                 { 0,0,0,0,0,0,0,3,0 },
                 { 0,0,0,0,0,0,0,4,0},
                 { 0,0,0,0,0,0,0,3,0 },
                 { 0,0,0,0,0,0,0,5,0 },
                 { 0,0,0,0,0,0,0,6,0 },
                 { 0,0,0,0,0,0,0,7,0},
                 { 0,0,0,0,0,0,0,8,0}
                };

            InvalidBlock = new[,]
     {
                 { 1,2,3,0,0,0,0,0,0 },
                 { 4,5,6,0,0,0,0,0,0 },
                 { 7,8,6,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0}
                };

            InvalidMultiCB= new[,]
                {
                 { 0,0,0,0,2,0,0,3,0 },
                 { 0,0,0,0,0,0,0,0,3 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,2,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0}
                };


            InvalidMultiRB = new[,]
                {
                 { 0,0,0,8,0,0,0,8,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,4,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,4}
                };


            InvalidMultiRC = new[,]
                {
                 { 1,1,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,7,0},
                 { 0,0,0,0,0,0,0,7,0}
                };


            InvalidMultiRCB = new[,]
                {
                 { 1,1,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,2,0 },
                 { 0,0,0,0,0,0,0,2,0},
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,3,0,0,0,0},
                 { 0,0,0,0,0,3,0,0,0}
                };


            InvalidMultiAll = new[,]
                {
                 { 1,1,1,1,1,1,1,1,1 },
                 { 2,2,2,2,2,2,2,2,2 },
                 { 3,3,3,3,3,3,3,3,3},
                 { 4,4,4,4,4,4,4,4,4 },
                 { 5,5,5,5,5,5,5,5,5 },
                 { 6,6,6,6,6,6,6,6,6},
                 { 7,7,7,7,7,7,7,7,7},
                 { 8,8,8,8,8,8,8,8,8},
                 { 9,9,9,9,9,9,9,9,9}
                };


            Blank = new[,]
                {
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0}
                };


            
        }
    
        [TestMethod]

        public void SetRowsFirstCellFirstRow()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            var actual = g.Rows[0].Cells[0].Number;
            var expected = 9;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]

        public void SetRowsMiddleCellMiddleRow()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            var actual = g.Rows[4].Cells[4].Number;
            var expected = 6;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]

        public void SetRowsLastCellLastRow()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            var actual = g.Rows[8].Cells[8].Number;
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SetColumnsFirstCellFirstRow()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            var actual = g.Columns[1].Cells[0].Number;
            var expected = 1;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]

        public void SetColumnsMiddleCellMiddleRow()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            var actual = g.Columns[5].Cells[5].Number;
            var expected = 1;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]

        public void SetColumnsPenultimateCellPenultimate()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            var actual = g.Rows[7].Cells[7].Number;
            var expected = 7;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SetBlockFourthCellFirstBlock()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            var actual = g.Blocks[0].Cells[3].Number;
            var expected = 2;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]

        public void SetBlockFifthLastBlock()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            var actual = g.Blocks[4].Cells[8].Number;
            var expected = 1;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]

        public void SetBlocksPenultimateCellPenultimateRow()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            var actual = g.Blocks[7].Cells[7].Number;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SetNumberOnGridUpdateRows()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            g.SetNumberRemovePossibilities(0, 4, 8, "");
            var actual = g.Rows[0].Cells[4].Number;
            var expected = 8;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SetNumberOnGridUpdateColumns()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            g.SetNumberRemovePossibilities(7, 6, 5, "");
            var actual = g.Columns[6].Cells[7].Number;
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SetNumberOnGridUpdateBlocks()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            g.SetNumberRemovePossibilities(3,6, 8, "");
            var actual = g.Blocks[5].Cells[0].Number;
            var expected = 8;
            Assert.AreEqual(expected, actual);
        }

       
        [TestMethod]
        public void GetCellFromCoOrdinateLast()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
          
            g.GetCoOrdinatesOfCell(81, out int i, out int j);
            var expected = "8:8";
            var actual = i + ":" + j;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetCellFromCoOrdinateZero()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            g.GetCoOrdinatesOfCell(1, out int i, out int j);
            var expected = "0:0";
            var actual = i + ":" + j;
            Console.WriteLine(expected, actual);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetCellFromCoOrdinate48()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            g.GetCoOrdinatesOfCell(48, out int i, out int j);
            var expected = "5:2";
            var actual = i + ":" + j;
            Console.WriteLine(expected, actual);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetCellFromCoOrdinate43()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            g.GetCoOrdinatesOfCell(43, out int i, out int j);
            var expected = "4:6";
            var actual = i + ":" + j;
            Console.WriteLine(expected, actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCellFromCoOrdinate2()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            g.GetCoOrdinatesOfCell(2, out int i, out int j);
            var expected = "0:1";
            var actual = i + ":" + j;
            Console.WriteLine(expected, actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCellFromCoOrdinate3()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            g.GetCoOrdinatesOfCell(3, out int i, out int j);
            var expected = "0:2";
            var actual = i + ":" + j;
            Console.WriteLine(expected, actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCellFromCoOrdinate10()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            g.GetCoOrdinatesOfCell(10, out int i, out int j);
            var expected = "1:0";
            var actual = i + ":" + j;
            Console.WriteLine(expected, actual);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetCellFromCoOrdinate11()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            g.GetCoOrdinatesOfCell(11, out int i, out int j);
            var expected = "1:1";
            var actual = i + ":" + j;
            Console.WriteLine(expected, actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCellFromCoOrdinate12()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            g.GetCoOrdinatesOfCell(12, out int i, out int j);
            var expected = "1:2";
            var actual = i + ":" + j;
            Console.WriteLine(expected, actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCellFromCoOrdinate19()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            g.GetCoOrdinatesOfCell(19, out int i, out int j);
            var expected = "2:0";
            var actual = i + ":" + j;
            Console.WriteLine(expected, actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCellFromCoOrdinate20()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            g.GetCoOrdinatesOfCell(20, out int i, out  int j);
            var expected = "2:1";
            var actual = i + ":" + j;
            Console.WriteLine(expected, actual);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetCellFromCoOrdinate21()
        {
            AdvancedGrid g = new AdvancedGrid(Grid1);
            g.GetCoOrdinatesOfCell(21, out int i, out int j);
            var expected = "2:2";
            var actual = i + ":" + j;
            Console.WriteLine(expected, actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BlockPossibility1()
        {
            AdvancedGrid g = new AdvancedGrid();
            g.RemovePossibility(0,0,1);
            var expected = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9 };
            var actual = g.Blocks[0].Cells[0].Possibilities;
            
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BlockPossibility2()
        {
            AdvancedGrid g = new AdvancedGrid();
            g.RemovePossibility(0, 0, 1);
            g.RemovePossibility(0, 0, 3);
            g.RemovePossibility(0, 0, 5);
            g.RemovePossibility(0, 0, 7);
            var expected = new List<int>() { 2,  4,  6, 8, 9 };
            var actual = g.Blocks[0].Cells[0].Possibilities;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BlockPossibility3()
        {
            AdvancedGrid g = new AdvancedGrid();
            g.SetNumberRemovePossibilities(0, 1, 1, "");
            g.SetNumberRemovePossibilities(1, 0, 2, "");
            g.SetNumberRemovePossibilities(1, 1, 3, "");
            g.RemovePossibilitiesFromIntersectingCells();
            var expected = new List<int>() { 4,5,6,7,8,9 };
            var actual = g.Blocks[0].Cells[0].Possibilities;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void AdvancedGridBlockToNorm()
        {
            AdvancedGrid g = new AdvancedGrid();
            g.BlockToMain(3, 3, out int a, out int b);
            var actual = a + ":" + b;
            var expected = "4:0";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void AdvancedGridBlockToNorm2()
        {
            AdvancedGrid g = new AdvancedGrid();
            g.BlockToMain(0,0, out int a, out int b);
            var actual = a + ":" + b;
            var expected = "0:0";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void AdvancedGridBlockToNorm3()
        {
            AdvancedGrid g = new AdvancedGrid();
            g.BlockToMain(8,8, out int a, out int b);
            var actual = a + ":" + b;
            var expected = "8:8";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void AdvancedGridBlockToNorm4()
        {
            AdvancedGrid g = new AdvancedGrid();
          
            g.BlockToMain(1,8, out int a, out int  b);
            var actual = a + ":" + b;
            var expected = "2:5";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void AdvancedGridBlockToNorm5()
        {
            AdvancedGrid g = new AdvancedGrid();

            g.BlockToMain(7,0, out int a, out int b);
            var actual = a + ":" + b;
            var expected = "6:3";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void AdvancedGridSetNumber()
        {
            AdvancedGrid g = new AdvancedGrid();

            g.SetGrid(0, 0, 1, "");

            var actual = g.Rows[0].Cells[1].Possibilities;
            var expected = new List<int> {2, 3, 4, 5, 6, 7, 8, 9};
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void NextCellSimple()
        {
            AdvancedGrid g = new AdvancedGrid();

             g.findNextCell(0, 0, out int x, out int y);
            var actual = x + ";" + y;
            var expected = "0;1";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void NextCellSecond()
        {
            AdvancedGrid g = new AdvancedGrid();

            g.findNextCell(0, 1, out int x, out int y);
            var actual = x + ";" + y;
            var expected = "0;2";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void NextCellNewRow()
        {
            AdvancedGrid g = new AdvancedGrid();

            g.findNextCell(0, 8, out int x, out int y);
            var actual = x + ";" + y;
            var expected = "1;0";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void NextCellNextRow()
        {
            AdvancedGrid g = new AdvancedGrid();

            g.findNextCell(7, 8, out int x, out int y);
            var actual = x + ";" + y;
            var expected = "8;0";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void NextCellEnd()
        {
            AdvancedGrid g = new AdvancedGrid();

            g.findNextCell(8,8, out int x, out int y);
            var actual = x + ";" + y;
            var expected = "0;0";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void NextCellMiddle()
        {
            AdvancedGrid g = new AdvancedGrid();

            g.findNextCell(5,7, out int x, out int y);
            var actual = x + ";" + y;
            var expected = "5;8";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void NextCellPenultimate()
        {
            AdvancedGrid g = new AdvancedGrid();

            g.findNextCell(8, 7, out int x, out int y);
            var actual = x + ";" + y;
            var expected = "8;8";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void StartCoordinate()
        {
            AdvancedGrid g = new AdvancedGrid();

            var expected = g.getUserFriendlyCoordinates(0, 0);
            var actual = "[1 , A]";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void MiddleCoordinate()
        {
            AdvancedGrid g = new AdvancedGrid();

            var expected = g.getUserFriendlyCoordinates(1, 4);
            var actual = "[2 , E]";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void EndCoordinate()
        {
            AdvancedGrid g = new AdvancedGrid();

            var expected = g.getUserFriendlyCoordinates(8,8);
            var actual = "[9 , I]";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void CoordinateB()
        {
            AdvancedGrid g = new AdvancedGrid();

            var expected = g.getUserFriendlyCoordinates(6,1);
            var actual = "[7 , B]";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void CoordinateC()
        {
            AdvancedGrid g = new AdvancedGrid();

            var expected = g.getUserFriendlyCoordinates(3,2);
            var actual = "[4 , C]";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void CoordinateD()
        {
            AdvancedGrid g = new AdvancedGrid();

            var expected = g.getUserFriendlyCoordinates(4,3);
            var actual = "[5 , D]";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void CoordinateF()
        {
            AdvancedGrid g = new AdvancedGrid();

            var expected = g.getUserFriendlyCoordinates(7,5);
            var actual = "[8 , F]";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void CoordinateG()
        {
            AdvancedGrid g = new AdvancedGrid();

            var expected = g.getUserFriendlyCoordinates(2,6);
            var actual = "[3 , G]";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void CoordinateH()
        {
            AdvancedGrid g = new AdvancedGrid();

            var expected = g.getUserFriendlyCoordinates(5,6);
            var actual = "[6 , G]";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void InvalidRowTest()
        {
            AdvancedGrid g = new AdvancedGrid(InvalidRow);

            var expected = new List<string>() { "1;1", "1;7" };
            var actual = g.findInvalidCells();
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void InvalidRowTest2()
        {
            AdvancedGrid g = new AdvancedGrid(InvalidRow2);

            var expected = new List<string>() { "1;7", "1;8" };
            var actual = g.findInvalidCells();
            foreach(var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void InvalidColTest()
        {
            AdvancedGrid g = new AdvancedGrid(InvalidCol);

            var expected = new List<string>() { "2;7", "4;7" };
            var actual = g.findInvalidCells();
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void InvalidBlockTest()
        {
            AdvancedGrid g = new AdvancedGrid(InvalidBlock);

            var expected = new List<string>() { "1;2", "2;2" };
            var actual = g.findInvalidCells();
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void InvalidMultiCBTest()
        {
            AdvancedGrid g = new AdvancedGrid(InvalidMultiCB);

            var expected = new List<string>() { "0;4", "0;7", "1;8", "3;4" };
            var actual = g.findInvalidCells();
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void InvalidMultiCRTest()
        {
            AdvancedGrid g = new AdvancedGrid(InvalidMultiRC);

            var expected = new List<string>() { "0;0", "0;1", "7;7", "8;7" };
            var actual = g.findInvalidCells();
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void InvalidMultiRBTest()
        {
            AdvancedGrid g = new AdvancedGrid(InvalidMultiRB);

            var expected = new List<string>() { "0;3", "0;7", "6;6", "8;8"};
            var actual = g.findInvalidCells();
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void InvalidMultiRCBTest()
        {
            AdvancedGrid g = new AdvancedGrid(InvalidMultiRCB);

            var expected = new List<string>() { "0;0", "0;1", "2;7", "3;7", "7;4", "8;5" };
            var actual = g.findInvalidCells();
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void InvalidMultiAllTest()
        {
            AdvancedGrid g = new AdvancedGrid(InvalidMultiAll);

            var expected = new List<string>() 
            { 
                "0;0", "0;1", "0;2", "0;3", "0;4", "0;5", "0;6", "0;7", "0;8",
                "1;0", "1;1", "1;2", "1;3", "1;4", "1;5", "1;6", "1;7", "1;8",
                "2;0", "2;1", "2;2", "2;3", "2;4", "2;5", "2;6", "2;7", "2;8",
                "3;0", "3;1", "3;2", "3;3", "3;4", "3;5", "3;6", "3;7", "3;8",
                "4;0", "4;1", "4;2", "4;3", "4;4", "4;5", "4;6", "4;7", "4;8",
                "5;0", "5;1", "5;2", "5;3", "5;4", "5;5", "5;6", "5;7", "5;8",
                "6;0", "6;1", "6;2", "6;3", "6;4", "6;5", "6;6", "6;7", "6;8",
                "7;0", "7;1", "7;2", "7;3", "7;4", "7;5", "7;6", "7;7", "7;8",
                "8;0", "8;1", "8;2", "8;3", "8;4", "8;5", "8;6", "8;7", "8;8",


            };
            var actual = g.findInvalidCells();
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void InvalidBlankTest()
        {
            AdvancedGrid g = new AdvancedGrid(Blank);

            var expected = new List<string>() {  };
            var actual = g.findInvalidCells();
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void ValidGridTest()
        {
            AdvancedGrid g = new AdvancedGrid(GridValidExample);

            var expected = new List<string>() {  };
            var actual = g.findInvalidCells();
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void RightNormal()
        {
            AdvancedGrid g = new AdvancedGrid(GridValidExample);

            var expected = "myInput;0;1";
            var actual = g.moveCoordinate("myInput;0;0", "right");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void RightNewRow()
        {
            AdvancedGrid g = new AdvancedGrid(GridValidExample);

            var expected = "myInput;1;0";
            var actual = g.moveCoordinate("myInput;0;8", "right");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void RightBackToStart()
        {
            AdvancedGrid g = new AdvancedGrid(GridValidExample);

            var expected = "myInput;0;0";
            var actual = g.moveCoordinate("myInput;8;8", "right");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void LeftNormal()
        {
            AdvancedGrid g = new AdvancedGrid(GridValidExample);

            var expected = "myInput;0;0";
            var actual = g.moveCoordinate("myInput;0;1", "left");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void LeftNewRow()
        {
            AdvancedGrid g = new AdvancedGrid(GridValidExample);

            var expected = "myInput;0;8";
            var actual = g.moveCoordinate("myInput;1;0", "left");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void LeftBackToEnd()
        {
            AdvancedGrid g = new AdvancedGrid(GridValidExample);

            var expected = "myInput;8;8";
            var actual = g.moveCoordinate("myInput;0;0", "left");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void UpNormal()
        {
            AdvancedGrid g = new AdvancedGrid(GridValidExample);

            var expected = "myInput;3;4";
            var actual = g.moveCoordinate("myInput;4;4", "up");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void UpRowBreak()
        {
            AdvancedGrid g = new AdvancedGrid(GridValidExample);

            var expected = "myInput;8;6";
            var actual = g.moveCoordinate("myInput;0;7", "up");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void UpTotal()
        {
            AdvancedGrid g = new AdvancedGrid(GridValidExample);

            var expected = "myInput;8;8";
            var actual = g.moveCoordinate("myInput;0;0", "up");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void DownNormal()
        {
            AdvancedGrid g = new AdvancedGrid(GridValidExample);

            var expected = "myInput;5;4";
            var actual = g.moveCoordinate("myInput;4;4", "down");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void DownRowBreak()
        {
            AdvancedGrid g = new AdvancedGrid(GridValidExample);

            var expected = "myInput;0;7";
            var actual = g.moveCoordinate("myInput;8;6", "down");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void DownNewGrid()
        {
            AdvancedGrid g = new AdvancedGrid(GridValidExample);

            var expected = "myInput;0;0";
            var actual = g.moveCoordinate("myInput;8;8", "down");
            Assert.AreEqual(expected, actual);
        }
    }
}