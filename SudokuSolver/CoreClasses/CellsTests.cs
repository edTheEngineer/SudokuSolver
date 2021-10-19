using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudokuTests.SudokuSolver.CoreClasses
{
    [TestClass()]

    
    public class CellsTests
    {
        public Cell MyCell { get; set; }
        public CellsTests()
        {
            MyCell = new Cell();
        }

        [TestMethod()]

        public void SetNumber()
        {
            MyCell.SetNumber(3);
            var expected = 3;
            var actual = MyCell.Number;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SetColour()
        {
            MyCell.SetColour("red");
            var expected = "red";
            var actual = MyCell.Colour;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SetNumberLosePossibilities()
        {
            MyCell.SetNumber(3);
            var expected = new  List<int>();
            var actual = MyCell.Possibilities;
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]

        public void RemovePossibilities()
        {
            MyCell.RemovePossibilities(8);
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 9 };
            var actual = MyCell.Possibilities;
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]

        public void CannotSetPossibilities()
        {
            MyCell.SetNumber(5);
            MyCell.AddPossibilities(8);
            var expected = new List<int>();
            var actual = MyCell.Possibilities;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void AddPossibilitiesAfterRemoveNumber()
        {
            MyCell.SetNumber(5);
            MyCell.SetNumber(0);
            MyCell.AddPossibilities(8);
            MyCell.AddPossibilities(4);
            var expected = new List<int> {1,2,3,4,5,6,7,8,9 };
            var actual = MyCell.Possibilities;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SetNumberOnOriginalCell()
        {
            Cell c = new Cell(5);
            c.SetNumber(6);
            var expected = 6;
            var actual = c.Number;
            Console.WriteLine(c.IsOriginalValue);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SetFilledNumber1()
        {
            Cell c = new Cell();
            c.SetNumber(5);
            var expected = 5;
            var actual = c.Number;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SetFilledNumber2()
        {
            Cell c = new Cell();
            c.SetNumber(5);
            c.SetNumber(8);
            var expected = 8;
            var actual = c.Number;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SetNumberReset()
        {
            Cell c = new Cell();
            c.SetNumber(5);
            c.SetNumber(0);
            c.SetNumber(8);
            var expected = 8;
            var actual = c.Number;
            Assert.AreEqual(expected, actual);
        }

        


        [TestMethod()]

        public void SetNumberLoseAllPossibilities()
        {
            Cell c = new Cell();
            c.SetNumber(5);
            var expected = new List<int>{};
            var actual = c.Possibilities;
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}