
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.Techniques;
using System;
using System.Collections.Generic;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudokuTests.SudokuSolver.Techniques.Medium
{
    [TestClass()]
    public class HiddenPairsTests
    {
        public int[,] SudokuOrg { get; set; }

        public int[,] SudokuSolution{ get; set; }

        public int[,] SudokuApp { get; set; }

        public int[,] SudokuApp2 { get; set; }

        public int[,] SudokusSolver { get; set; }

        public int[,] SudokuLive { get; set; }

        public int[,] Hodoku1 { get; set; }

        public int[,] Hodoku2{ get; set; }

        public int[,] PuzzleMysteryHiddenSquare{ get; set; }

        public int[,] PuzzleMysteryHiddenRow { get; set; }

        public int[,] PuzzleMysteryHiddenCol { get; set; }

        public int[,]Sudoku9981 { get; set; }

        public int[,] SudokuLitmus { get; set; }

        public int[,] HiddenBlockOnly { get; set; }
        public HiddenPairsTests()
        {
            SudokuOrg = new[,]
            {
{0,0,0,7,0,0,0,0,0},
{0,2,7,0,0,0,3,1,0},
{3,9,0,6,0,0,7,9,2},
{0,0,0,2,0,8,0,0,0},
{2,3,0,0,0,0,0,7,1},
{0,0,0,4,0,1,0,0,0},
{1,0,0,0,0,7,0,8,5},
{0,7,5,1,0,0,9,3,0},
{0,0,0,0,0,0,1,0,7},

            };

            SudokuSolution = new[,]
{
{4,6,5,0,8,0,3,2,0},
{7,9,8,0,3,2,6,0,5},
{1,2,3,5,6,0,0,9,8},
{8,0,0,2,0,5,0,3,0},
{0,0,2,0,0,0,5,0,0},  //Middle Pair 1 and 8 here
{5,0,0,3,0,6,2,8,0},
{0,8,4,0,5,3,1,7,2},
{0,0,0,0,2,0,8,5,4},
{2,5,7,0,1,0,9,6,3},

            };

            SudokuApp = new[,]
{
{0,4,0,0,0,0,0,0,8},
{5,0,3,6,8,4,1,0,2},
{1,0,0,7,9,0,0,5,0},
{0,0,0,8,0,0,0,0,0},
{0,0,0,3,5,0,7,0,0},
{0,0,0,0,0,0,0,1,0},
{0,0,2,0,0,0,0,0,0}, //3 and 6 here
{0,3,7,1,0,8,6,0,5},
{6,0,5,0,0,0,0,3,0},

            };

            SudokuApp2 = new[,]
{
{0,5,0,0,6,8,0,0,0},
{0,0,0,0,0,0,2,0,0},
{0,0,0,9,0,5,0,0,0},
{0,9,1,0,5,0,0,0,3},
{0,8,0,0,0,0,4,0,0},
{0,4,6,0,0,0,0,1,8},
{0,0,4,0,0,1,5,0,0}, //3 and 8 in final box
{0,3,7,1,0,8,6,0,0},
{0,0,0,0,0,0,0,6,9},

            };

            SudokusSolver = new[,]
{

{0,0,1,5,0,4,0,2,6},
{0,5,0,0,0,0,4,0,1},
{0,8,4,2,1,6,0,5,3},
{5,4,0,1,0,0,0,6,9},
{1,6,8,3,4,9,5,7,2},
{0,2,0,6,0,5,0,0,4},
{0,0,5,0,0,0,0,0,8}, //2 and 6 in 1st and 3rd of 3nd row
{0,9,0,0,0,1,2,3,5},
{0,1,0,9,5,0,6,4,7},

            };

            SudokuLive = new[,]
{

//2 and 5 in 5th col

{2,0,4,7,1,0,3,6,0},
{6,0,7,0,0,9,0,0,0},
{0,0,5,0,6,0,0,0,0},
{8,7,1,4,9,2,6,5,3},
{5,2,9,0,0,0,0,8,4},
{0,0,6,5,8,0,9,0,2},
{0,6,3,0,0,0,8,9,7},
{0,5,8,0,0,0,2,4,1},
{0,0,2,0,0,0,5,3,6},

            };

            Hodoku1 = new[,]
{

{0,4,9,1,3,2,0,0,0},
{0,8,1,4,7,9,0,0,0},
{3,2,7,6,8,5,9,1,4},
{0,9,6,0,5,1,8,0,0},
{0,7,5,0,2,8,0,0,0},
{0,3,8,0,4,6,0,0,5},
{8,5,3,2,6,7,0,0,0},
{7,1,2,8,9,4,5,6,3},
{9,6,4,5,1,3,0,0,0},

            };

            Hodoku2 = new[,]
{
{0,0,0,0,6,0,0,0,0},
{0,0,0,0,4,2,7,3,6},
{0,0,6,7,3,0,0,4,0},
{0,9,4,0,0,0,0,6,8},
{0,0,0,0,9,6,4,0,7},
{6,0,7,0,5,0,9,2,3},
{1,0,0,0,0,0,0,8,5},
{0,6,0,0,8,0,2,7,1},
{0,0,5,0,1,0,0,9,4},

            };


            PuzzleMysteryHiddenSquare = new[,]
{
//1 and 4 in Block7

{0,0,6,8,0,3,0,1,0},
{0,0,0,0,6,0,0,5,8},
{0,0,0,0,0,1,6,0,0},
{1,8,5,7,3,6,4,2,9},
{6,2,3,0,0,5,8,7,1},
{4,9,7,1,8,2,5,6,3},
{0,0,9,6,0,0,0,0,5},
{5,7,0,3,0,0,0,0,6},
{0,6,0,5,0,4,1,0,0},

            };

            PuzzleMysteryHiddenRow = new[,]
{
//2 and 6 in 4th row

{0,8,3,0,1,0,4,0,0},
{0,9,2,0,0,0,3,6,1},
{5,1,6,0,0,0,9,0,0},
{1,0,0,0,0,0,0,3,4},
{0,0,0,0,6,1,7,0,0},
{0,0,5,0,2,0,0,1,0},
{9,0,1,0,0,0,0,4,0},
{8,0,7,1,0,0,0,0,3},
{0,3,4,8,0,7,1,0,0},

            };

            PuzzleMysteryHiddenCol = new[,]
{
//4 and 8 in 8th column

{5,0,0,1,9,7,0,0,0},
{0,1,3,8,5,4,2,0,0},
{0,7,9,2,0,0,0,1,0},
{0,0,0,0,1,0,4,0,8},
{3,0,0,0,0,0,0,0,1},
{9,0,1,0,0,0,0,0,0},
{0,6,0,0,0,8,1,5,0},
{0,0,5,0,0,1,0,6,0},
{1,0,0,7,6,5,0,0,3},

            };

            Sudoku9981 = new[,]
{

{0,0,7,0,6,1,0,0,0},
{0,0,0,0,0,8,0,6,0},
{1,0,6,0,7,4,0,0,3},
{0,2,0,0,0,3,8,0,6},
{0,0,0,0,0,0,0,0,0},
{0,0,0,0,1,0,0,5,0},
{0,0,8,7,3,2,6,0,5 },
{6,0,2,1,8,5,0,4,0},
{5,7,0,6,4,9,2,0,0},

            };

            SudokuLitmus = new[,]
{


{2,0,0,5,4,0,1,0,7},
{9,0,0,0,0,0,2,4,0},
{8,4,0,2,7,0,5,6,0},
{7,1,2,4,9,8,3,5,6},
{6,3,8,0,0,0,4,0,0},
{5,9,4,6,0,0,0,2,0},
{4,5,0,3,0,7,9,1,2},
{1,0,0,9,0,4,0,3,5},
{3,0,9,0,1,0,0,0,4},

            };

           HiddenBlockOnly = new[,]
{//PaulPc repair


{0,0,0,6,0,0,0,0,0},
{0,7,2,5,9,1,0,4,0},
{0,0,1,0,3,0,0,0,5},
{0,4,3,2,0,0,0,0,0},
{1,0,0,0,0,0,0,0,4},
{2,8,7,0,0,6,5,9,0},
{5,0,0,0,6,0,4,0,0},
{0,2,0,0,5,8,6,3,0},
{0,0,0,0,0,7,0,0,0},

            };

        }

        [TestMethod]

        public void SudokuOrgTest1()
        {
            Technique t = new Technique(SudokuOrg);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[3].Cells[8].Possibilities;
            var expected = new List<int> { 3,9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuOrgTest2()
        {
            Technique t = new Technique(SudokuOrg);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[5].Cells[8].Possibilities;
            var expected = new List<int> { 3, 9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuOrgTest3()
        {
            Technique t = new Technique(SudokuOrg);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[6].Cells[2].Possibilities;
            var expected = new List<int> {2,3 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuOrgTest4()
        {
            Technique t = new Technique(SudokuOrg);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[8].Cells[2].Possibilities;
            var expected = new List<int> { 2,3};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void SudokuSolutionRow1()
        {
            Technique t = new Technique(SudokuSolution);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[4].Cells[3].Possibilities;
            var expected = new List<int> { 1,8};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuSolutionRow2()
        {
            Technique t = new Technique(SudokuSolution);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[4].Cells[5].Possibilities;
            var expected = new List<int> { 1, 8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuSolutionsCol1()
        {
            Technique t = new Technique(SudokuSolution);
            t.HiddenPairTechnique();
            var actual = t.Grid.Columns[3].Cells[4].Possibilities;
            var expected = new List<int> { 1, 8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuSolutionsCol2()
        {
            Technique t = new Technique(SudokuSolution);
            t.HiddenPairTechnique();
            var actual = t.Grid.Columns[5].Cells[4].Possibilities;
            var expected = new List<int> { 1, 8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuSolutionsBlock1()
        {
            Technique t = new Technique(SudokuSolution);
            t.HiddenPairTechnique();
            var actual = t.Grid.Blocks[4].Cells[3].Possibilities;
            var expected = new List<int> { 1, 8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuSolutionsBlock2()
        {
            Technique t = new Technique(SudokuSolution);
            t.HiddenPairTechnique();
            var actual = t.Grid.Blocks[4].Cells[5].Possibilities;
            var expected = new List<int> { 1, 8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void SudokuApp1A()
        {
            Technique t = new Technique(SudokuApp);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[6].Cells[4].Possibilities;
            var expected = new List<int> { 3,6};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuApp1B()
        {
            Technique t = new Technique(SudokuApp);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[6].Cells[5].Possibilities;
            var expected = new List<int> { 3, 6 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void SudokuApp2A()
        {
            Technique t = new Technique(SudokuApp2);
            t.HiddenPairTechnique();
            var actual = t.Grid.Blocks[8].Cells[1].Possibilities;
            var expected = new List<int> { 3, 8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuApp2B()
        {
            Technique t = new Technique(SudokuApp2);
            t.HiddenPairTechnique();
            var actual = t.Grid.Blocks[8].Cells[6].Possibilities;
            var expected = new List<int> { 3, 8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuSolverA()
        {
            Technique t = new Technique(SudokusSolver);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[1].Cells[0].Possibilities;
            var expected = new List<int> { 2,6 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuSolverB()
        {
            Technique t = new Technique(SudokusSolver);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[1].Cells[2].Possibilities;
            var expected = new List<int> { 2,6 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuLiveA()
        {
            Technique t = new Technique(SudokuLive);
            t.HiddenPairTechnique();
            var actual = t.Grid.Columns[4].Cells[1].Possibilities;
            var expected = new List<int> { 2, 5 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuLiveB()
        {
            Technique t = new Technique(SudokuLive);
            t.HiddenPairTechnique();
            var actual = t.Grid.Columns[4].Cells[6].Possibilities;
            var expected = new List<int> { 2, 5 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void Hodoku1A()
        {
            Technique t = new Technique(Hodoku1);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[4].Cells[8].Possibilities;
            var expected = new List<int> { 1,9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void Hodoku1C()
        {
            Technique t = new Technique(Hodoku1);
            t.HiddenPairTechnique();
            var actual = t.Grid.Columns[8].Cells[4].Possibilities;
            var expected = new List<int> { 1, 9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void Hodoku1D()
        {
            Technique t = new Technique(Hodoku1);
            t.HiddenPairTechnique();
            var actual = t.Grid.Columns[8].Cells[6].Possibilities;
            var expected = new List<int> { 1, 9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void Hodoku1B()
        {
            Technique t = new Technique(Hodoku1);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[6].Cells[8].Possibilities;
            var expected = new List<int> { 1, 9 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void Hodoku2A()
        {
            Technique t = new Technique(Hodoku2);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[0].Cells[0].Possibilities;
            var expected = new List<int> { 4, 7 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void Hodoku2B()
        {
            Technique t = new Technique(Hodoku2);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[0].Cells[1].Possibilities;
            var expected = new List<int> { 4,7 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void PuzzleMysterySquare1()
        {
            Technique t = new Technique(PuzzleMysteryHiddenSquare);
            t.HiddenPairTechnique();
            var actual = t.Grid.Blocks[6].Cells[1].Possibilities;
            var expected = new List<int> {1,4};
            foreach(var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void PuzzleMysterySquare2()
        {
            Technique t = new Technique(PuzzleMysteryHiddenSquare);
            t.HiddenPairTechnique();
            var actual = t.Grid.Blocks[6].Cells[5].Possibilities;
            var expected = new List<int> { 1,4};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void PuzzleMysteryRow1()
        {
            Technique t = new Technique(PuzzleMysteryHiddenRow);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[3].Cells[1].Possibilities;
            var expected = new List<int> {2,6 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void PuzzleMysteryRow2()
        {
            Technique t = new Technique(PuzzleMysteryHiddenRow);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[3].Cells[6].Possibilities;
            var expected = new List<int> { 2,6 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void PuzzleMysteryCol1()
        {
            Technique t = new Technique(PuzzleMysteryHiddenCol);
            t.HiddenPairTechnique();
            var actual = t.Grid.Columns[7].Cells[0].Possibilities;
            var expected = new List<int> { 4, 8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void PuzzleMysteryCol2()
        {
            Technique t = new Technique(PuzzleMysteryHiddenCol);
            t.HiddenPairTechnique();
            var actual = t.Grid.Columns[7].Cells[0].Possibilities;
            var expected = new List<int> { 4,8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void Sudoku9981_Row1()
        {
            Technique t = new Technique(Sudoku9981);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[1].Cells[6].Possibilities;
            var expected = new List<int> { 1,7};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void Sudoku9981Row2()
        {
            Technique t = new Technique(Sudoku9981);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[1].Cells[8].Possibilities;
            var expected = new List<int> {1,7};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void Sudoku9981_Col1()
        {
            Technique t = new Technique(Sudoku9981);
            t.HiddenPairTechnique();
            var actual = t.Grid.Columns[6].Cells[1].Possibilities;
            var expected = new List<int> { 1, 7 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void Sudoku9981Col2()
        {
            Technique t = new Technique(Sudoku9981);
            t.HiddenPairTechnique();
            var actual = t.Grid.Columns[8].Cells[1].Possibilities;
            var expected = new List<int> { 1, 7 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void Sudoku9981Block1()
        {
            Technique t = new Technique(Sudoku9981);
            t.HiddenPairTechnique();
            var actual = t.Grid.Blocks[2].Cells[3].Possibilities;
            var expected = new List<int> { 1, 7 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void Sudoku9981Block2()
        {
            Technique t = new Technique(Sudoku9981);
            t.HiddenPairTechnique();
            var actual = t.Grid.Blocks[2].Cells[5].Possibilities;
            var expected = new List<int> { 1, 7 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuLitmusRow1()
        {
            Technique t = new Technique(SudokuLitmus);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[4].Cells[4].Possibilities;
            var expected = new List<int> { 2,5 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void SudokuLitmusRow2()
        {
            Technique t = new Technique(SudokuLitmus);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[4].Cells[5].Possibilities;
            var expected = new List<int> { 2, 5 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuLitmusCol1()
        {
            Technique t = new Technique(SudokuLitmus);
            t.HiddenPairTechnique();
            var actual = t.Grid.Columns[4].Cells[4].Possibilities;
            var expected = new List<int> { 2, 5 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void SudokuLitmusCol2()
        {
            Technique t = new Technique(SudokuLitmus);
            t.HiddenPairTechnique();
            var actual = t.Grid.Columns[5].Cells[4].Possibilities;
            var expected = new List<int> { 2, 5 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SudokuLitmusBlock1()
        {
            Technique t = new Technique(SudokuLitmus);
            t.HiddenPairTechnique();
            var actual = t.Grid.Blocks[4].Cells[4].Possibilities;
            var expected = new List<int> { 2, 5 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void SudokuLitmusBlock2()
        {
            Technique t = new Technique(SudokuLitmus);
            t.HiddenPairTechnique();
            var actual = t.Grid.Blocks[4].Cells[5].Possibilities;
            var expected = new List<int> { 2, 5 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void HiddenBlockBlock1()
        {
            Technique t = new Technique(HiddenBlockOnly);
            t.HiddenPairTechnique();
            var actual = t.Grid.Blocks[1].Cells[1].Possibilities;
            var expected = new List<int> {7,8};
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }



        [TestMethod]

        public void HiddenBlockBlock2()
        {
            Technique t = new Technique(HiddenBlockOnly);
            t.HiddenPairTechnique();
            var actual = t.Grid.Blocks[1].Cells[6].Possibilities;
            var expected = new List<int> { 7, 8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void HiddenBlockCols1()
        {
            Technique t = new Technique(HiddenBlockOnly);
            t.HiddenPairTechnique();
            var actual = t.Grid.Columns[3].Cells[2].Possibilities;
            var expected = new List<int> { 7, 8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }



        [TestMethod]

        public void HiddenBlockCols2()
        {
            Technique t = new Technique(HiddenBlockOnly);
            t.HiddenPairTechnique();
            var actual = t.Grid.Columns[4].Cells[0].Possibilities;
            var expected = new List<int> { 7, 8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void HiddenBlockRow1()
        {
            Technique t = new Technique(HiddenBlockOnly);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[0].Cells[4].Possibilities;
            var expected = new List<int> { 7, 8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }



        [TestMethod]

        public void HiddenBlockRows2()
        {
            Technique t = new Technique(HiddenBlockOnly);
            t.HiddenPairTechnique();
            var actual = t.Grid.Rows[2].Cells[3].Possibilities;
            var expected = new List<int> { 7, 8 };
            foreach (var x in actual)
            {
                Console.Write(x + ", ");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}