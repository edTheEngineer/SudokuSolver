using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudokuTests.SudokuSolver.CoreClasses
{
    [TestClass()]
    public class GroupTests
    {
        public Group MyGroup { get; set; }
        public GroupTests()
        {
           MyGroup = new Group();
        }

        [TestMethod()]

        public void CreateGroupBlankFirstNumber()
        {
            var actual = MyGroup.Cells[0].Number;
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void CreateGroupBlankLastNumber()
        {
            var actual = MyGroup.Cells[8].Number;
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void CreateGroupBlankPossibilities()
        {
            var actual = new List<int>(){ 1,2,3,4,5,6,7,8,9};
            var expected = MyGroup.Cells[0].Possibilities;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SetNumber()
        {
            MyGroup.Cells[5].SetNumber(4);
            var actual = MyGroup.Cells[5].Number;
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SetPossibilities()
        {
            MyGroup.Cells[8].SetNumber(4);
            var actual = new List<int>();
            var expected = MyGroup.Cells[8].Possibilities;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        
        public void PopulateGroupNumberSet()
        {
            var numsToAdd = new[] { 1, 3,2, 4, 5, 6, 7, 8, 9 };
            var group = new Group(numsToAdd);
            var actual = group.Cells[1].Number;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void PopulateGroupNumberPossibilitiesSet()
        {
            var numsToAdd = new[] { 1, 3, 2, 4, 5, 6, 7, 8, 9 };
            var group = new Group(numsToAdd);
            var actual = group.Cells[1].Possibilities;
            var expected = new List<int>();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void IsValidIncomplete()
        {
            var group = new Group(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 });
            var actual = group.IsValid();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]

        public void IsValidComplete()
        {
            var group = new Group(new [] { 1,3,5,7,9,2,4,6,8});
            var actual = group.IsValid();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]

        public void IsInvalidRepeatStart()
        {
            var group = new Group(new [] { 1, 1, 3, 4, 5, 6, 7, 8, 0 });
            var actual = group.IsValid();
            Assert.AreEqual(false, actual);
        }

        [TestMethod]

        public void IsInvalidIncompleteEnd()
        {
            var group = new Group(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 8 });
            var actual = group.IsValid();
            Assert.AreEqual(false, actual);
        }

        [TestMethod]

        public void IsValidThreeZeros()
        {
            var group = new Group(new[] { 0,0,0,1,2,3,4,5,6 });
            var actual = group.IsValid();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]

        public void IsInCompleteGroup()
        {
            var group = new Group(new[] { 0, 0, 0, 1, 2, 3, 4, 5, 6 });
            var actual = group.IsComplete();
            Assert.AreEqual(false, actual);
        }

        [TestMethod]

        public void IsCompleteGroup()
        {
            var group = new Group(new [] { 7,8,9, 1, 2, 3, 4, 5, 6 });
            var actual = group.IsComplete();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]

        public void IsCompleteGroup2()
        {
            var group = new Group(new[] { 1,2,3,4,5,6,7,8,9});
            var actual = group.IsComplete();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]

        public void IsCompleteGroupInvalid()
        {
            var group = new Group(new[] { 8,8,8, 1, 2, 3, 4, 5, 6 });
            var actual = group.IsComplete();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]

        public void SetPossibilitiesCell1()
        {
            var group = new Group(new[] { 1, 0, 3, 4, 5, 6, 0, 8, 0 });
            var expected = new List<int>() { 2, 7, 9 };
            var actual = group.Cells[1].Possibilities;
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SetPossibilitiesCellNone()
        {
            var group = new Group(new[] { 1, 0, 3, 4, 5, 6, 0, 8, 0 });
            var expected = new List<int>();
            var actual = group.Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SetPossibilitiesCell6()
        {
            var group = new Group(new[] { 1, 0, 3, 4, 5, 6, 0, 8, 0 });
            var expected = new List<int>() { 2, 7, 9 };
            var actual = group.Cells[6].Possibilities;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SetPossibilitiesCell8()
        {
            var group = new Group(new[] { 1, 0, 3, 4, 5, 6, 0, 8, 0 });
            var expected = new List<int>() { 2, 7, 9 };
            var actual = group.Cells[8].Possibilities;
            foreach(var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]

        public void SetPossibilitiesCellAllBarOne()
        {
            var group = new Group(new[] {0,0,0,0,0,0,0,1,9 });
            var expected = new List<int>() { 2,3,4,5,6,7,8 };
            var actual = group.Cells[0].Possibilities;
            foreach (var x in actual)
            {
                Console.Write(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}