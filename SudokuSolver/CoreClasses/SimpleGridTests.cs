using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudokuTests.SudokuSolver.CoreClasses
{
    [TestClass()]
    public class SimpleGridTests
    {
        public SimpleGrid SudokuGrid { get; set; }
        public SimpleGridTests()
        {
            SimpleGrid simpleGrid = new SimpleGrid();
            SudokuGrid = simpleGrid;
        }
        [TestMethod]

        public void Is9Columns()
        {
            var expected = 9;
            var actual = SudokuGrid.Columns;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void Is9Rows()
        {
            var expected = 9;
            var actual = SudokuGrid.Rows;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void IsEmptyGridOnCreation()
        {
            {
                var expected = new int[9, 9];
                var actual = SudokuGrid.SudokuGrid;
                CollectionAssert.AreEqual(expected, actual);
            }

        }

        [TestMethod]

        public void CanSetNumberFirst()
        {
            {
                var expected = new[,] 
                { 
                 {9,0,0,0,0,0,0,0,0 },        
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0}
                };

                SudokuGrid.SetGrid(0, 0, 9);
                var actual = SudokuGrid.SudokuGrid;
                CollectionAssert.AreEqual(expected, actual);
            }

        }

        [TestMethod]

        public void CanSetNumberLast()
        {
            {
                var expected = new[,]
                {
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,5}
                };

                SudokuGrid.SetGrid(8,8, 5);
                var actual = SudokuGrid.SudokuGrid;
                CollectionAssert.AreEqual(expected, actual);
            }

        }

        [TestMethod]

        public void CanClearGrid()
        {
            {
                var expected = new[,]
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

                SudokuGrid.SetGrid(0, 0, 9);
                SudokuGrid.SetGrid(0, 1, 2);
                SudokuGrid.SetGrid(0, 1, 3);
                SudokuGrid.ClearGrid();
                var actual = SudokuGrid.SudokuGrid;
                CollectionAssert.AreEqual(expected, actual);
            }

        }
    }
}