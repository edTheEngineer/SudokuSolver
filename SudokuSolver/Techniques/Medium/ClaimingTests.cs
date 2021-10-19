
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.Techniques;
using System;
using System.Collections.Generic;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudokuTests.SudokuSolver.Techniques.Medium
{
    [TestClass()]
    public class ClaimingTests
    {
        public int[,] SudokuOfTheDay{ get; set; }

        public int[,] RohanRao { get; set; }

        public int[,] Kristanix { get; set; }

        public int[,] IronMonger1 { get; set; }

        public int[,] IronMonger2 { get; set; }
        public int[,] IronMonger3 { get; set; }

        public int[,] IronMonger4 { get; set; }

        public int[,] SudokuSnake { get; set; }

        public int[,] Wordsup1 { get; set; }
        public int[,] Wordsup2 { get; set; }

        public int[,] SudokuLive1 { get; set; }
        public int[,] SudokuLive2 { get; set; }

        public int[,] SudokuLive3 { get; set; }

        public int[,] Brainbashers1 { get; set; }

        public int[,] Brainbashers2 { get; set; }
        public int[,] Sudopedia { get; set; }
        public int[,] SudokuWiki { get; set; }
        public int[,] SudokuWikiMulti { get; set; }

        public int[,] Nanpre { get; set; }

        public ClaimingTests()
        {
            SudokuOfTheDay = new[,]
            {
{0,0,1,9,5,7,0,6,3},
{0,0,0,8,0,6,0,7,0},
{7,6,9,1,3,0,8,0,5},
{0,0,7,2,6,1,3,5,0},
{3,1,2,4,9,5,7,8,6},
{0,5,6,3,7,8,0,0,0},
{1,0,8,6,0,9,5,0,7},
{0,9,0,7,1,0,6,0,8},
{6,7,4,5,8,3,0,0,0},

            };
            RohanRao = new[,]
{
{0,1,0,0,6,8,7,0,0},
{0,4,8,0,2,7,9,6,0},
{5,0,0,0,0,0,0,3,0},
{1,0,0,4,0,9,0,0,0},
{0,5,0,0,7,0,0,9,0},
{0,0,0,2,0,5,0,0,7},
{0,6,0,0,0,0,0,0,4},
{0,9,5,6,4,0,8,1,0},
{0,0,3,7,8,0,0,5,0},

            };

            Kristanix = new[,]
{
{0,0,0,0,7,0,0,0,0},
{0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0},
{0,0,0,2,0,1,0,0,0},
{0,0,0,0,0,0,0,0,0},
{0,0,0,9,0,6,0,0,0},
{0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0},

            };

            IronMonger1 = new[,]
{
{0,0,0,0,6,2,0,8,9},
{2,0,8,9,0,0,5,6,0},
{4,6,9,0,0,0,0,0,0},
{0,2,0,0,0,7,6,0,0},
{5,0,6,0,8,0,2,0,7},
{0,0,7,6,2,0,0,1,0},
{6,0,0,0,0,0,0,0,1},
{9,8,3,0,0,6,0,0,0},
{7,1,2,5,4,0,0,0,6},

};

            IronMonger2 = new[,]
{
{0,0,8,9,0,2,0,7,0},
{3,6,0,7,1,4,0,2,8},
{2,0,0,0,8,0,0,0,0},
{8,0,1,4,2,7,6,0,0},
{4,0,0,0,0,0,0,0,2},
{0,0,2,5,0,0,7,0,4},
{0,0,0,2,4,0,0,0,7},
{0,2,0,8,7,0,0,3,9},
{7,8,0,0,0,3,2,0,0},

};

            IronMonger3 = new[,]
{
{0,2,0,4,0,6,0,7,0},
{0,7,6,0,2,5,0,0,4},
{4,0,5,0,0,0,6,1,2},
{2,1,7,5,0,0,9,3,6},
{5,0,0,0,0,0,4,2,8},
{0,4,8,0,0,2,7,5,1},
{7,9,2,0,0,0,0,0,0},
{3,5,0,8,0,0,2,6,7},
{0,0,0,2,0,7,0,0,0},

};

            IronMonger4 = new[,]
{
{1,0,2,4,0,8,0,0,9},
{0,0,9,1,0,0,8,0,0},
{0,7,8,2,9,6,0,0,1},
{9,0,5,3,6,0,1,0,0},
{2,1,6,0,8,0,0,9,3},
{7,0,3,9,2,1,6,0,5},
{6,0,4,8,1,0,0,3,7},
{0,0,1,0,4,0,0,0,0},
{8,0,7,6,0,2,9,1,4},

};

            SudokuSnake = new[,]
{
{0,0,4,0,0,0,2,1,3},
{2,0,1,3,0,0,0,0,9},
{0,3,0,0,0,2,4,7,0},
{0,2,0,0,6,0,7,0,0},
{0,0,0,0,0,8,0,0,1},
{0,5,0,0,0,0,0,3,0},
{6,0,0,2,0,0,0,9,0},
{0,0,2,5,0,0,0,6,0},
{0,0,5,6,9,1,0,0,0},

};

            Wordsup1 = new[,]
{
{0,4,2,3,9,5,0,8,1},
{1,0,0,2,0,6,0,0,9},
{0,0,0,0,4,0,0,0,2},
{8,5,0,0,0,2,0,9,3},
{2,3,7,0,0,0,1,0,6},
{9,1,0,0,3,0,0,2,8},
{0,0,0,0,2,0,0,0,0},
{3,0,0,4,0,8,2,0,7},
{0,2,0,7,6,3,0,1,0},

};

            Wordsup2 = new[,]
{
{0,0,8,0,1,0,4,6,0},
{5,0,6,3,0,8,9,1,2},
{0,2,1,6,0,0,8,3,0},
{6,0,0,1,0,4,0,0,8},
{1,0,2,9,8,3,5,0,6},
{0,8,0,7,0,6,0,0,1},
{0,6,3,0,0,0,1,5,4},
{2,0,0,4,3,1,6,8,9},
{0,1,4,0,6,0,7,2,3},

};

            SudokuLive1 = new[,]
 {
{5,0,0,0,0,0,0,0,0},
{6,8,0,0,9,0,3,0,1},
{0,0,0,7,0,4,0,0,0},
{0,0,0,0,0,0,4,3,0},
{0,0,0,0,7,0,0,0,0},
{0,3,5,1,0,0,0,0,6},
{7,6,0,2,3,0,0,4,0},
{0,0,2,0,8,1,0,0,0},
{0,9,0,0,0,0,0,0,0},

            };

            SudokuLive2 = new[,]
 {
{7,3,8,6,0,0,2,4,9 },
{5,0,0,0,9,0,6,8,0},
{0,9,6,0,8,0,1,0,5},
{8,0,0,5,0,4,9,6,0},
{6,5,4,9,0,2,0,1,8},
{0,0,9,1,6,8,5,0,4},
{0,8,0,7,0,9,0,5,6},
{0,0,5,3,0,6,8,9,0},
{9,6,0,8,0,0,0,0,0},

            };

            SudokuLive3 = new[,]
 {
{5,8,0,4,0,1,0,2,9},
{9,4,0,2,0,0,0,0,1},
{2,0,1,5,0,9,4,0,0},
{0,0,0,9,1,0,0,0,6},
{0,9,0,6,4,0,1,0,0},
{0,1,0,8,2,0,7,9,0},
{0,0,4,1,9,2,0,0,0},
{1,0,9,0,0,0,0,0,0},
{8,2,0,0,0,0,9,1,5},

 };

            Brainbashers1 = new[,]
{
{0,9,5,4,0,0,0,1,0},
{0,4,6,0,0,9,0,7,0},
{2,8,0,3,0,0,6,9,4},
{8,0,9,1,3,0,4,0,7},
{0,1,0,0,9,0,0,3,0},
{6,0,3,0,0,4,9,0,1},
{0,7,2,0,0,8,1,0,3},
{0,3,0,2,0,0,7,5,0},
{0,6,0,0,0,3,2,0,0}
};

            Brainbashers2 = new[,]
{
{0,3,0,1,0,0,0,6,5},
{0,0,7,9,0,0,0,0,0},
{6,0,0,0,0,0,0,7,0},
{0,6,0,0,0,4,3,0,8},
{0,0,0,0,8,0,0,0,0},
{2,0,4,7,0,0,0,5,0},
{0,5,0,0,0,0,0,0,1},
{0,0,0,0,0,8,9,0,0},
{4,9,0,0,0,1,0,2,0}
};

            Sudopedia = new[,]
{
{2,0,0,0,0,0,1,0,0},
{1,4,0,0,2,0,0,8,3},
{0,0,3,0,1,0,5,0,0},
{0,0,0,0,0,0,0,0,0},
{0,0,6,7,0,0,0,5,0},
{8,0,9,2,0,1,3,0,0},
{0,0,0,0,0,3,2,0,0},
{0,0,1,8,0,2,0,3,0},
{0,0,0,1,6,0,0,9,4}
};

            SudokuWiki = new[,]
{
{0,1,7,9,0,3,6,0,0},
{0,0,0,0,8,0,0,0,0},
{9,0,0,2,0,0,5,0,7},
{0,7,2,0,1,0,4,3,0},
{0,0,0,4,0,2,0,7,0},
{0,6,4,3,7,0,2,5,0},
{7,0,1,0,0,0,0,6,5},
{0,0,0,0,3,0,0,0,0},
{0,0,5,6,0,1,7,2,0}
};

            SudokuWikiMulti = new[,]
{
{0,3,2,0,0,6,1,0,0},
{4,1,0,0,0,0,0,0,0},
{0,0,0,9,0,1,0,0,0},
{5,0,0,0,9,0,0,0,4},
{0,6,0,0,0,0,0,7,1},
{3,0,0,0,2,0,0,0,5},
{0,0,0,5,0,8,0,0,0},
{0,0,0,0,0,0,5,1,9},
{0,5,7,0,0,9,8,6,0}
};

            Nanpre = new[,]
{
{0,0,0,0,1,0,0,0,6},
{0,0,0,0,0,9,4,0,0},
{9,0,6,0,3,0,5,1,0},
{0,0,8,0,0,7,1,0,3},
{0,7,1,0,0,0,6,0,0},
{6,0,0,0,9,1,0,7,8},
{0,0,3,1,5,0,0,8,0},
{0,8,0,4,0,0,0,0,0},
{0,0,0,0,0,8,0,0,0}
};

        }


  [TestMethod]
        public void SudokuOfTheDayTestRow1()
            {
                Technique t = new Technique(SudokuOfTheDay);
                t.Claiming();
                var actual = t.Grid.Rows[2].Cells[7].Possibilities;
                var expected = new List<int> { 2 };
                foreach (var x in actual)
                {
                    Console.Write(x + ", ");
                }
                CollectionAssert.AreEqual(expected, actual);
            }
        

    [TestMethod]
    public void SudokuOfTheDayTestRow2()
    {
        Technique t = new Technique(SudokuOfTheDay);
        t.Claiming();
        var actual = t.Grid.Rows[5].Cells[7].Possibilities;
        var expected = new List<int> { 1,2,9 };
        foreach (var x in actual)
        {
            Console.Write(x + ", ");
        }
        CollectionAssert.AreEqual(expected, actual);
    }

        [TestMethod]
        public void SudokuOfTheDayTestCol1()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.Claiming();
            var actual = t.Grid.Columns[7].Cells[2].Possibilities;
            var expected = new List<int> { 2 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void SudokuOfTheDayColTest2()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.Claiming();
            var actual = t.Grid.Columns[7].Cells[5].Possibilities;
            var expected = new List<int> { 1, 2, 9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SudokuOfTheDayBlockTest1()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.Claiming();
            var actual = t.Grid.Blocks[2].Cells[7].Possibilities;
            var expected = new List<int> { 2 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void SudokuOfTheDayBlockTest2()
        {
            Technique t = new Technique(SudokuOfTheDay);
            t.Claiming();
            var actual = t.Grid.Blocks[5].Cells[7].Possibilities;
            var expected = new List<int> { 1, 2, 9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RohanRaoTest()
        {
            Technique t = new Technique(RohanRao);
            t.Claiming();
            var actual = t.Grid.Rows[6].Cells[3].Possibilities;
            var expected = new List<int> { 9};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Ironmonger1_A()
        {
            Technique t = new Technique(IronMonger1);
            t.Claiming();
            var actual = t.Grid.Rows[0].Cells[3].Possibilities;
            var expected = new List<int> { 3,4,7};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Ironmonger1_B()
        {
            Technique t = new Technique(IronMonger1);
            t.Claiming();
            var actual = t.Grid.Rows[0].Cells[6].Possibilities;
            var expected = new List<int> { 3, 4, 7 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Ironmonger2_A()
        {
            Technique t = new Technique(IronMonger2);
            t.Claiming();
            var actual = t.Grid.Columns[2].Cells[2].Possibilities;
            var expected = new List<int> {5,7,9};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Ironmonger3_A()
        {
            Technique t = new Technique(IronMonger3);
            t.Claiming();
            var actual = t.Grid.Blocks[1].Cells[1].Possibilities;
            var expected = new List<int> { 1,3,8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Ironmonger3_B()
        {
            Technique t = new Technique(IronMonger3);
            t.Claiming();
            var actual = t.Grid.Blocks[1].Cells[3].Possibilities;
            var expected = new List<int> { 1,3 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Ironmonger4_A()
        {
            Technique t = new Technique(IronMonger4);
            t.Claiming();
            var actual = t.Grid.Blocks[1].Cells[5].Possibilities;
            var expected = new List<int> {3,5 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SudokuSnake_A()
        {
            Technique t = new Technique(SudokuSnake);
            t.Claiming();
            var actual = t.Grid.Blocks[4].Cells[2].Possibilities;
            var expected = new List<int> { 3, 5, 9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SudokuSnake_B()
        {
            Technique t = new Technique(SudokuSnake);
            t.Claiming();
            var actual = t.Grid.Blocks[4].Cells[4].Possibilities;
            var expected = new List<int> { 2,3,5,7 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SudokuSnake_C()
        {
            Technique t = new Technique(SudokuSnake);
            t.Claiming();
            var actual = t.Grid.Blocks[4].Cells[7].Possibilities;
            var expected = new List<int> { 1,2,7 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SudokuSnake_D()
        {
            Technique t = new Technique(SudokuSnake);
            t.Claiming();
            var actual = t.Grid.Blocks[4].Cells[8].Possibilities;
            var expected = new List<int> { 7,9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void KristanixA()
        {
            Technique t = new Technique(Kristanix);
            t.Claiming();
            var actual = t.Grid.Rows[4].Cells[0].Possibilities;
            var expected = new List<int> { 1,2,3,4,5,6,8,9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KristanixB()
        {
            Technique t = new Technique(Kristanix);
            t.Claiming();
            var actual = t.Grid.Rows[4].Cells[1].Possibilities;
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 8, 9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KristanixC()
        {
            Technique t = new Technique(Kristanix);
            t.Claiming();
            var actual = t.Grid.Rows[4].Cells[2].Possibilities;
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 8, 9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void KristanixD()
        {
            Technique t = new Technique(Kristanix);
            t.Claiming();
            var actual = t.Grid.Rows[4].Cells[3].Possibilities;
            var expected = new List<int> {  3, 4, 5, 7, 8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KristanixE()
        {
            Technique t = new Technique(Kristanix);
            t.Claiming();
            var actual = t.Grid.Rows[4].Cells[4].Possibilities;
            var expected = new List<int> { 3,4,5,8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KristanixF()
        {
            Technique t = new Technique(Kristanix);
            t.Claiming();
            var actual = t.Grid.Rows[4].Cells[5].Possibilities;
            var expected = new List<int> { 3,4,5,7,8};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void KristanixG()
        {
            Technique t = new Technique(Kristanix);
            t.Claiming();
            var actual = t.Grid.Rows[4].Cells[6].Possibilities;
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 8, 9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KristanixH()
        {
            Technique t = new Technique(Kristanix);
            t.Claiming();
            var actual = t.Grid.Rows[4].Cells[7].Possibilities;
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 8, 9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KristanixI()
        {
            Technique t = new Technique(Kristanix);
            t.Claiming();
            var actual = t.Grid.Rows[4].Cells[8].Possibilities;
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 8, 9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WordUp1_A()
        {
            Technique t = new Technique(Wordsup1);
            t.Claiming();
            var actual = t.Grid.Rows[6].Cells[1].Possibilities;
            var expected = new List<int> { 6,7,8};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WordUp1_B()
        {
            Technique t = new Technique(Wordsup1);
            t.Claiming();
            var actual = t.Grid.Blocks[6].Cells[2].Possibilities;
            var expected = new List<int> { 1,5,8};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WordUp1_C()
        {
            Technique t = new Technique(Wordsup1);
            t.Claiming();
            var actual = t.Grid.Columns[2].Cells[8].Possibilities;
            var expected = new List<int> {5,8};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WordUp2_A()
        {
            Technique t = new Technique(Wordsup2);
            t.Claiming();
            var actual = t.Grid.Blocks[3].Cells[1].Possibilities;
            var expected = new List<int> { 3,5,7};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WordUp2_B()
        {
            Technique t = new Technique(Wordsup2);
            t.Claiming();
            var actual = t.Grid.Blocks[3].Cells[6].Possibilities;
            var expected = new List<int> { 3,4 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SudokuLive1_A()
        {
            Technique t = new Technique(SudokuLive1);
            t.Claiming();
            var actual = t.Grid.Rows[0].Cells[2].Possibilities;
            var expected = new List<int> {1,7,9};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SudokuLive1_B()
        {
            Technique t = new Technique(SudokuLive1);
            t.Claiming();
            var actual = t.Grid.Rows[2].Cells[0].Possibilities;
            var expected = new List<int> { 1,2, 3,9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SudokuLive1_C()
        {
            Technique t = new Technique(SudokuLive1);
            t.Claiming();
            var actual = t.Grid.Rows[2].Cells[2].Possibilities;
            var expected = new List<int> { 1, 3, 9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SudokuLive2_A()
        {
            Technique t = new Technique(SudokuLive2);
            t.Claiming();
            var actual = t.Grid.Columns[1].Cells[7].Possibilities;
            var expected = new List<int> {2,4,7};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SudokuLive2_B()
        {
            Technique t = new Technique(SudokuLive2);
            t.Claiming();
            var actual = t.Grid.Rows[6].Cells[2].Possibilities;
            var expected = new List<int> { 2,3};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SudokuLive2_C()
        {
            Technique t = new Technique(SudokuLive2);
            t.Claiming();
            var actual = t.Grid.Blocks[6].Cells[8].Possibilities;
            var expected = new List<int> { 2, 3, 7 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SudokuLive3_A()
        {
            Technique t = new Technique(SudokuLive3);
            t.Claiming();
            var actual = t.Grid.Columns[7].Cells[7].Possibilities;
            var expected = new List<int> { 3,4,6,7};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SudokuLive3_B()
        {
            Technique t = new Technique(SudokuLive3);
            t.Claiming();
            var actual = t.Grid.Blocks[8].Cells[3].Possibilities;
            var expected = new List<int> { 2, 3, 6 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SudokuLive3_C()
        {
            Technique t = new Technique(SudokuLive3);
            t.Claiming();
            var actual = t.Grid.Rows[7].Cells[1].Possibilities;
            var expected = new List<int> {3,6,7};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Brainbasher1A()
        {
            Technique t = new Technique(Brainbashers1);
            t.Claiming();
            var actual = t.Grid.Columns[8].Cells[4].Possibilities;
            var expected = new List<int>() { 5, 6, 8 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Brainbasher2A()
        {
            Technique t = new Technique(Brainbashers2);
            t.Claiming();
            var actual = t.Grid.Rows[4].Cells[3].Possibilities;
            var expected = new List<int>() {  5, 6 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Brainbasher2B()
        {
            Technique t = new Technique(Brainbashers2);
            t.Claiming();
            var actual = t.Grid.Rows[4].Cells[5].Possibilities;
            var expected = new List<int>() {  5, 6};
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Sudopedia1A()
        {
            Technique t = new Technique(Sudopedia);
            t.Claiming();
            var actual = t.Grid.Columns[7].Cells[3].Possibilities;
            var expected = new List<int>() { 1, 2,  7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void Sudopedia1B()
        {
            Technique t = new Technique(Sudopedia);
            t.Claiming();
            var actual = t.Grid.Columns[7].Cells[5].Possibilities;
            var expected = new List<int>() { 6, 7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWiki1A()
        {
            Technique t = new Technique(SudokuWiki);
            t.Claiming();
            var actual = t.Grid.Rows[1].Cells[0].Possibilities;
            var expected = new List<int>() { 2, 4, 5, 6 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]

        public void SudokuWiki1B()
        {
            Technique t = new Technique(SudokuWiki);
            t.Claiming();
            var actual = t.Grid.Rows[1].Cells[1].Possibilities;
            var expected = new List<int>() { 2, 4, 5 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]

        public void SudokuWiki1C()
        {
            Technique t = new Technique(SudokuWiki);
            t.Claiming();
            var actual = t.Grid.Rows[1].Cells[2].Possibilities;
            var expected = new List<int>() { 6 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWiki2AC()
        {
            Technique t = new Technique(SudokuWiki);
            t.Claiming();
            var actual = t.Grid.Rows[6].Cells[1].Possibilities;
            var expected = new List<int>() { 3, 4, 8, 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]

        public void SudokuWikiMulti1A()
        {
            Technique t = new Technique(SudokuWikiMulti);
            t.Grid.RemovePossibility(3, 3, 3);
            t.Grid.RemovePossibility(3, 3, 7);
            t.Grid.RemovePossibility(3, 3, 8);
            t.Grid.RemovePossibility(5, 3, 3);
            t.Grid.RemovePossibility(5, 3, 7);
            t.Grid.RemovePossibility(5, 3, 8);
            t.Grid.RemovePossibility(8, 4, 1);
            for (int i = 1; i <= 10; i++)
            {
                t.Claiming();
            }
            var actual = t.Grid.Rows[1].Cells[5].Possibilities;
            var expected = new List<int>() { 2, 3, 5 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWikiMulti2A()
        {
            Technique t = new Technique(SudokuWikiMulti);
            t.Claiming();
            var actual = t.Grid.Blocks[2].Cells[1].Possibilities;
            var expected = new List<int>() { 4, 5, 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWikiMulti2B()
        {
            Technique t = new Technique(SudokuWikiMulti);
            t.Claiming();
            var actual = t.Grid.Blocks[2].Cells[3].Possibilities;
            var expected = new List<int>() { 3, 7, 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWikiMulti2C()
        {
            Technique t = new Technique(SudokuWikiMulti);
            t.Claiming();
            var actual = t.Grid.Blocks[2].Cells[4].Possibilities;
            var expected = new List<int>() { 3, 5, 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWikiMulti1D()
        {
            Technique t = new Technique(SudokuWikiMulti);
            t.Claiming();
            var actual = t.Grid.Blocks[2].Cells[5].Possibilities;
            var expected = new List<int>() { 3, 6, 7, 8 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWikiMulti2E()
        {
            Technique t = new Technique(SudokuWikiMulti);
            t.Claiming();
            var actual = t.Grid.Blocks[2].Cells[6].Possibilities;
            var expected = new List<int>() { 2, 3, 4, 7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWikiMulti12F()
        {
            Technique t = new Technique(SudokuWikiMulti);
            t.Claiming();
            var actual = t.Grid.Blocks[2].Cells[7].Possibilities;
            var expected = new List<int>() { 2, 3, 4, 5 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWikiMulti2G()
        {
            Technique t = new Technique(SudokuWikiMulti);
            for (int i = 1; i <= 10; i++)
            {
                t.Claiming();
            }
            var actual = t.Grid.Blocks[0].Cells[7].Possibilities;
            var expected = new List<int>() { 8 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWikiMulti2H()
        {
            Technique t = new Technique(SudokuWikiMulti);
            t.Grid.RemovePossibility(3, 3, 3);
            t.Grid.RemovePossibility(3, 3, 7);
            t.Grid.RemovePossibility(3, 3, 8);
            t.Grid.RemovePossibility(5, 3, 3);
            t.Grid.RemovePossibility(5, 3, 7);
            t.Grid.RemovePossibility(5, 3, 8);
            t.Grid.RemovePossibility(8, 4, 1);
            for (int i = 1; i <= 10; i++)
            {
                t.Claiming();
            }
            var actual = t.Grid.Rows[4].Cells[0].Possibilities;
            var expected = new List<int>() { 2, 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWikiMulti2I()
        {
            Technique t = new Technique(SudokuWikiMulti);
            t.Grid.RemovePossibility(3, 3, 3);
            t.Grid.RemovePossibility(3, 3, 7);
            t.Grid.RemovePossibility(3, 3, 8);
            t.Grid.RemovePossibility(5, 3, 3);
            t.Grid.RemovePossibility(5, 3, 7);
            t.Grid.RemovePossibility(5, 3, 8);
            t.Grid.RemovePossibility(8, 4, 1);
            t.Claiming();
            var actual = t.Grid.Rows[4].Cells[2].Possibilities;
            var expected = new List<int>() { 4, 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWikiMulti2J()
        {
            Technique t = new Technique(SudokuWikiMulti);
            t.Grid.RemovePossibility(3, 3, 3);
            t.Grid.RemovePossibility(3, 3, 7);
            t.Grid.RemovePossibility(3, 3, 8);
            t.Grid.RemovePossibility(5, 3, 3);
            t.Grid.RemovePossibility(5, 3, 7);
            t.Grid.RemovePossibility(5, 3, 8);
            t.Grid.RemovePossibility(8, 4, 1);
            for (int i = 1; i <= 10; i++)
            {
                t.Claiming();
            }
            var actual = t.Grid.Rows[1].Cells[5].Possibilities;
            var expected = new List<int>() { 2, 3, 5 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWikiMulti2K()
        {
            Technique t = new Technique(SudokuWikiMulti);
            t.Claiming();
            var actual = t.Grid.Columns[1].Cells[6].Possibilities;
            var expected = new List<int>() { 2, 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWikiMulti2L()
        {
            Technique t = new Technique(SudokuWikiMulti);
            t.Claiming();
            var actual = t.Grid.Columns[2].Cells[6].Possibilities;
            var expected = new List<int>() { 3, 6, 9 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWikiMulti2M()
        {
            Technique t = new Technique(SudokuWikiMulti);
            t.Claiming();
            var actual = t.Grid.Blocks[7].Cells[1].Possibilities;
            var expected = new List<int>() { 1, 3, 6 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWikiMulti2N()
        {
            Technique t = new Technique(SudokuWikiMulti);
            t.Claiming();
            var actual = t.Grid.Blocks[7].Cells[3].Possibilities;
            var expected = new List<int>() { 2, 3, 7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWikiMulti2O()
        {
            Technique t = new Technique(SudokuWikiMulti);
            t.Grid.RemovePossibility(3, 2, 3);
            t.Grid.RemovePossibility(3, 2, 7);
            t.Grid.RemovePossibility(3, 2, 8);
            t.Grid.RemovePossibility(5, 2, 3);
            t.Grid.RemovePossibility(5, 2, 7);
            t.Grid.RemovePossibility(5, 2, 8);
            t.Grid.RemovePossibility(8, 4, 1);
            t.Claiming();
            var actual = t.Grid.Rows[7].Cells[4].Possibilities;
            var expected = new List<int>() { 3, 6, 7 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SudokuWikiMulti2P()
        {
            Technique t = new Technique(SudokuWikiMulti);
            t.Grid.RemovePossibility(3, 3, 3);
            t.Grid.RemovePossibility(3, 3, 7);
            t.Grid.RemovePossibility(3, 3, 8);
            t.Grid.RemovePossibility(5, 3, 3);
            t.Grid.RemovePossibility(5, 3, 7);
            t.Grid.RemovePossibility(5, 3, 8);
            t.Grid.RemovePossibility(8, 4, 1);
            for (int i = 1; i <= 10; i++)
            {
                t.Claiming();
            }
            var actual = t.Grid.Columns[5].Cells[7].Possibilities;
            var expected = new List<int>() { 2, 3 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]

        public void Nanpre1()
        {
            Technique t = new Technique(Nanpre);
            // t.DoublePair();
            t.Claiming();
            var actual = t.Grid.Columns[5].Cells[4].Possibilities;
            var expected = new List<int>() { 2, 3, 5 };
            foreach (var x in actual)
            {
                Console.WriteLine(x);
            }
            CollectionAssert.AreEqual(expected, actual);
        }


    }





}