using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Json;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudokuTests.SudokuSolver.CoreClasses
{
    [TestClass()]
    public class ControllerTests
    {
        [TestMethod()]

        public void SimpleToAdvancedRow()
        {
            var intArray = new[,]
                {
                 { 9,1,2,3,4,5,6,7,8 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0}
                };
            SimpleGrid g = new SimpleGrid
            {
                SudokuGrid = intArray //Two assignments in one Call, simplifies object initialisation
            };
            Controller c = new Controller();
            var actual = c.CreateGrid(g);
            var expected = new AdvancedGrid(intArray);
            var js = new JavaScriptSerializer();
            CollectionAssert.AreEqual(expected.SudokuGrid, actual.SudokuGrid);

        }

        [TestMethod()]

        public void AdvancedToSimple()
        {
            var intArray = new[,]
                {
                 { 9,1,2,3,4,5,6,7,8 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0,0},
                 { 0,0,0,0,0,0,0,0,0}
                };
            AdvancedGrid g = new AdvancedGrid(intArray);
            
            Controller c = new Controller();
            var actual = c.CreateGrid(g);
            var gg = new SimpleGrid {SudokuGrid = intArray};
            var expected = gg;
            var js = new JavaScriptSerializer();
            Assert.AreEqual(js.Serialize(expected), js.Serialize(actual));

        }
    }
}