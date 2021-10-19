
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorPagesSudoku.SudokuSolver.Techniques;
using System;
using System.Collections.Generic;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudokuTests.SudokuSolver.Techniques.Medium
{
    [TestClass()]
    public class BruteForceTests
    {
        public int[,] MediumPart2 { get; set; }

        public int[,] BruteForceOneCell { get; set; }

        public int[,] BruteForceTwoCell { get; set; }
        public int[,] EasyStart { get; set; }

        public int[,] MediumStart { get; set; }

        public int[,] DifficultStart { get; set; }

        public int[,] SuperDifficultStart { get; set; }

        public int[,] EasyEnd { get; set; }

        public int[,] MediumEnd { get; set; }

        public int[,] DifficultEnd { get; set; }

        public int[,] SuperDifficultEnd { get; set; }

        public int[,] WorkedExample1Start { get; set; }

        public int[,] WorkedExample1End { get; set; }

        public int[,] WorkedExample2Start { get; set; }

        public int[,] WorkedExample2End { get; set; }

        public int[,] WorkedExample3Start { get; set; }

        public int[,] WorkedExample3End { get; set; }

        public int[,] WorkedExampleWikiStart { get; set; }

        public int[,] WorkedExampleWikiEnd { get; set; }

        public int[,] WorkedExampleVisualStart { get; set; }
        public int[,] WorkedExampleVisualEnd { get; set; }
        public int[,] BruteForceThreebyThreeQ { get; set; }
        public int[,] BruteForceThreebyThreeA { get; set; }
        public int[,] SudokuBacktrackingCounterQuestion { get; set; }

        public int[,] SudokuBackTrackingCounterAnswer { get; set; }


        public int[,] LittleBook200Q { get; set; }

        public int[,] LittleBook200Answer { get; set; }

        public BruteForceTests()
        {
            BruteForceOneCell = new[,]
                {
                 {  5,9,7,2,8,3,6,4,1},
                 { 1,2,6,9,7,4,3,5,8},
                 {  3,8,4,6,1,5,2,7,9},
                 {  6,4,9,3,2,7,1,8,5},
                 {  7,3,5,1,9,8,4,6,2},
                 {  2,1,8,4,5,6,7,9,3},
                 {  8,5,2,7,6,1,9,3,4},
                 {  4,6,1,8,3,9,5,2,7},
                 {  9,7,3,5,4,2,8,1,0}
                };

            BruteForceTwoCell = new[,]
    {
                 {  5,9,7,2,8,3,6,4,1},
                 { 1,2,6,9,7,4,3,5,8},
                 {  3,8,4,6,1,5,2,7,9},
                 {  6,4,9,3,2,7,1,8,5},
                 {  7,3,5,1,9,8,4,6,2},
                 {  2,1,8,4,5,6,7,9,3},
                 {  8,5,2,7,6,1,9,3,4},
                 {  4,6,1,8,3,9,0,0,7},
                 {  9,7,3,5,4,2,0,0,6}
                };

            BruteForceThreebyThreeQ = new[,]
                {
                 { 2,0,3},
                 { 1,0,0},
                 { 0,0,1}

                };

            BruteForceThreebyThreeA = new[,]
                {
                 { 2,1,3},
                 { 1,3,2},
                 { 3,2,1}
                };

            EasyStart = new[,]
               {
                 {  0,9,0,0,0,0,6,4,1},
                 {  0,0,0,9,7,4,0,5,8},
                 {  3,0,4,0,0,5,2,7,9},
                 {  6,4,9,3,0,7,0,0,5},
                 {  7,0,5,1,0,8,4,0,2},
                 {  2,0,0,4,0,6,7,9,3},
                 {  8,5,2,7,0,0,9,0,4},
                 {  4,6,0,8,3,9,0,0,0},
                 {  9,7,3,0,0,0,0,1,0}
                };


            LittleBook200Q = new[,]
{
                { 0,0,1,9,5,7,3,0,0},
                { 0,3,0,0,0,0,0,1,0},
                { 2,0,0,0,0,0,0,0,8},
                { 9,0,0,7,0,4,0,0,5},
                { 1,0,0,0,0,0,0,0,6},
                { 3,0,8,0,0,0,1,0,2},
                { 4,0,0,2,6,5,0,0,3},
                { 0,9,0,0,0,0,0,5,0},
                { 0,0,3,1,8,9,2,0,0}
            };

            LittleBook200Answer = new[,]
{
                { 6,8,1,9,5,7,3,2,4},
                { 7,3,4,6,2,8,5,1,9},
                { 2,5,9,3,4,1,7,6,8},
                { 9,2,6,7,1,4,8,3,5},
                { 1,7,5,8,3,2,4,9,6},
                { 3,4,8,5,9,6,1,7,2},
                { 4,1,7,2,6,5,9,8,3},
                { 8,9,2,4,7,3,6,5,1},
                { 5,6,3,1,8,9,2,4,7}
            };

            EasyEnd = new[,]
   {
                 {  5,9,7,2,8,3,6,4,1},
                 {  1,2,6,9,7,4,3,5,8},
                 {  3,8,4,6,1,5,2,7,9},
                 {  6,4,9,3,2,7,1,8,5},
                 {  7,3,5,1,9,8,4,6,2},
                 {  2,1,8,4,5,6,7,9,3},
                 {  8,5,2,7,6,1,9,3,4},
                 {  4,6,1,8,3,9,5,2,7},
                 {  9,7,3,5,4,2,8,1,6}
                };

            MediumStart = new[,]
   {
                 {  0,5,0,0,0,0,7,0,0},
                 {  0,7,0,1,0,0,8,0,6},
                 {  0,0,1,7,0,9,3,0,5},
                 {  2,0,9,0,4,0,5,0,3},
                 {  5,0,0,8,0,0,0,0,9},
                 {  6,0,8,0,2,0,1,0,4},
                 {  7,0,5,4,0,6,2,0,0},
                 {  1,0,4,0,0,8,0,0,0},
                 {  0,0,0,5,0,0,0,6,0}
                };

           

            MediumEnd = new[,]
   {
                 {  9,5,6,3,8,4,7,1,2},
                 {  4,7,3,1,5,2,8,9,6},
                 {  8,2,1,7,6,9,3,4,5},
                 {  2,1,9,6,4,7,5,8,3},
                 {  5,4,7,8,1,3,6,2,9},
                 {  6,3,8,9,2,5,1,7,4},
                 {  7,8,5,4,9,6,2,3,1},
                 {  1,6,4,2,3,8,9,5,7},
                 { 3,9,2,5,7,1,4,6,8}
                };

            DifficultStart = new[,]
   {
                 {  0,0,0,8,0,0,0,0,1},
                 { 0,0,0,0,0,2,0,8,0},
                 { 0,4,1,0,0,0,9,0,0},
                 {  0,0,3,6,0,0,2,0,0},
                 {  1,7,0,0,2,0,0,5,6},
                 {  0,0,9,0,0,5,7,0,0},
                 {  0,0,2,0,0,0,6,7,0},
                 {  0,3,0,1,0,0,0,0,0},
                 { 6,0,0,0,0,3,0,0,0}
                };

            DifficultEnd = new[,]
   {
                 {  7,2,5,8,3,9,4,6,1},
                 { 3,9,6,4,1,2,5,8,7},
                 { 8,4,1,7,5,6,9,3,2},
                 {  4,5,3,6,7,1,2,9,8},
                 {  1,7,8,9,2,4,3,5,6},
                 {  2,6,9,3,8,5,7,1,4},
                 {  9,1,2,5,4,8,6,7,3},
                 {  5,3,4,1,6,7,8,2,9},
                 { 6,8,7,2,9,3,1,4,5}
                };

            SuperDifficultStart = new[,]
   {
                 {  0,0,0,0,3,0,8,7,5},
                 { 4,0,0,0,0,7,0,0,0},
                 {  0,0,0,0,2,0,9,0,0},
                 { 0,5,0,6,0,0,1,0,0},
                 {  0,6,0,0,0,0,0,3,0},
                 {  0,0,1,0,0,5,0,2,0},
                 {  0,0,4,0,8,0,0,0,0},
                 {  0,0,0,3,0,0,0,0,7},
                 { 8,3,9,0,1,0,0,0,0}
                };

            SuperDifficultEnd = new[,]
        {
                {  6,9,2,4,3,1,8,7,5},
                 { 4,8,5,9,6,7,2,1,3},
                 {  7,1,3,5,2,8,9,6,4},
                 { 2,5,8,6,7,3,1,4,9},
                 {  9,6,7,1,4,2,5,3,8},
                 {  3,4,1,8,9,5,7,2,6},
                 {  5,7,4,2,8,6,3,9,1},
                 {  1,2,6,3,5,9,4,8,7},
                 { 8,3,9,7,1,4,6,5,2}
                };


            WorkedExample1Start = new[,]
                    {
                 {  3,0,6,5,0,8,4,0,0},
                 {  5,2,0,0,0,0,0,0,0},
                 {  0,8,7,0,0,0,0,3,1},
                 {  0,0,3,0,1,0,0,8,0},
                 {  9,0,0,8,6,3,0,0,5},
                 {  0,5,0,0,9,0,6,0,0},
                 {  1,3,0,0,0,0,2,5,0},
                 {  0,0,0,0,0,0,0,7,4},
                 {  0,0,5,2,0,6,3,0,0}
                };


            WorkedExample1End = new[,]
                         {
                 {  3,1,6,5,7,8,4,9,2},
                 {  5,2,9,1,3,4,7,6,8},
                 {  4,8,7,6,2,9,5,3,1},
                 {  2,6,3,4,1,5,9,8,7},
                 {  9,7,4,8,6,3,1,2,5},
                 {  8,5,1,7,9,2,6,4,3},
                 {  1,3,8,9,4,7,2,5,6},
                 {  6,9,2,3,5,1,8,7,4},
                 {  7,4,5,2,8,6,3,1,9}
                };

            WorkedExample2Start = new[,]
 {
                 {  0,6,9,8,0,0,0,0,0},
                 {  3,0,4,7,0,6,5,0,0},
                 {  2,0,0,5,9,0,6,0,0},
                 {  0,2,0,0,0,0,0,1,0},
                 {  9,0,0,1,0,7,0,0,8},
                 {  0,3,0,0,0,0,0,4,0},
                 {  0,0,2,0,5,4,0,0,7},
                 {  0,0,3,2,0,1,4,0,5},
                 {  0,0,0,0,0,9,2,6,0}
                };


            WorkedExample2End = new[,]
                         {
                 {  5,6,9,8,4,2,1,7,3},
                 {  3,8,4,7,1,6,5,2,9},
                 {  2,1,7,5,9,3,6,8,4},
                 {  7,2,5,4,3,8,9,1,6},
                 {  9,4,6,1,2,7,3,5,8},
                 {  8,3,1,9,6,5,7,4,2},
                 {  1,9,2,6,5,4,8,3,7},
                 {  6,7,3,2,8,1,4,9,5},
                 {  4,5,8,3,7,9,2,6,1}
                };

            WorkedExample3Start = new[,]
                         {
                 {  6,5,0,8,7,3,0,9,0},
                 {  0,0,3,2,5,0,0,0,8},
                 {  9,8,0,1,0,4,3,5,7},
                 {  1,0,5,0,0,0,0,0,0},
                 {  4,0,0,0,0,0,0,0,2},
                 {  0,0,0,0,0,0,5,0,3},
                 {  5,7,8,3,0,1,0,2,6},
                 {  2,0,0,0,4,8,9,0,0},
                 {  0,9,0,6,2,5,0,8,1}
                };

            WorkedExample3End = new[,]
             {
                 {  6,5,1,8,7,3,2,9,4 },
                 {  7,4,3,2,5,9,1,6,8},
                 {  9,8,2,1,6,4,3,5,7},
                 {  1,2,5,4,3,6,8,7,9},
                 {  4,3,9,5,8,7,6,1,2},
                 {  8,6,7,9,1,2,5,4,3},
                 {  5,7,8,3,9,1,4,2,6},
                 {  2,1,6,7,4,8,9,3,5},
                 {  3,9,4,6,2,5,7,8,1}
                };

            WorkedExampleWikiStart = new[,]
             {
                 {  5,3,0,0,7,0,0,0,0},
                 {  6,0,0,1,9,5,0,0,0},
                 {  0,9,8,0,0,0,0,6,0},
                 {  8,0,0,0,6,0,0,0,3},
                 {  4,0,0,8,0,3,0,0,1},
                 {  7,0,0,0,2,0,0,0,6},
                 {  0,6,0,0,0,0,2,8,0},
                 {  0,0,0,4,1,9,0,0,5},
                 {  0,0,0,0,8,0,0,7,9},
                };

            WorkedExampleWikiEnd = new[,]
             {
                 {  5,3,4,6,7,8,9,1,2},
                 {  6,7,2,1,9,5,3,4,8},
                 {  1,9,8,3,4,2,5,6,7},
                 {  8,5,9,7,6,1,4,2,3},
                 {  4,2,6,8,5,3,7,9,1},
                 {  7,1,3,9,2,4,8,5,6},
                 {  9,6,1,5,3,7,2,8,4},
                 {  2,8,7,4,1,9,6,3,5},
                 {  3,4,5,2,8,6,1,7,9},
                };

            WorkedExampleVisualStart = new[,]
 {
                 {  3,5,0,8,0,9,0,6,7},
                 {  0,0,8,0,0,0,2,9,5},
                 {  4,0,9,0,5,0,3,1,8},
                 {  0,9,4,0,0,0,8,0,2},
                 {  0,3,0,9,0,0,0,5,1},
                 {  5,0,6,1,7,0,0,4,0},
                 {  0,4,5,2,3,0,1,0,0},
                 {  0,0,3,6,0,4,0,2,9 },
                 { 8,6,0,0,9,1,7,0,0},
                };

            WorkedExampleVisualEnd = new[,]
 {
                 {  3,5,1,8,2,9,4,6,7},
                 {  6,7,8,4,1,3,2,9,5},
                 {  4,2,9,7,5,6,3,1,8},
                 {  1,9,4,3,6,5,8,7,2},
                 {  2,3,7,9,4,8,6,5,1},
                 {  5,8,6,1,7,2,9,4,3},
                 {  9,4,5,2,3,7,1,8,6},
                 {  7,1,3,6,8,4,5,2,9},
                 {  8,6,2,5,9,1,7,3,4},
                };

            SudokuBacktrackingCounterQuestion = new[,]
{
                { 0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,3,0,8,5},
                { 0,0,1,0,2,0,0,0,0},
                { 0,0,0,5,0,7,0,0,0},
                { 0,0,4,0,0,0,1,0,0},
                { 0,9,0,0,0,0,0,0,0},
                { 5,0,0,0,0,0,0,7,3},
                { 0,0,2,0,1,0,0,0,0},
                { 0,0,0,0,4,0,0,0,9}
            };


            SudokuBackTrackingCounterAnswer = new[,]
{
                { 9,8,7,6,5,4,3,2,1},
                { 2,4,6,1,7,3,9,8,5},
                { 3,5,1,9,2,8,7,4,6},
                { 1,2,8,5,3,7,6,9,4},
                { 6,3,4,8,9,2,1,5,7},
                { 7,9,5,4,6,1,8,3,2},
                { 5,1,9,2,8,6,4,7,3},
                { 4,7,2,3,1,9,5,6,9},
                { 8,6,3,7,4,5,2,1,9}
            };



        }


        [TestMethod()]

        public void A_BruteForceOneCellTestExample()

        {

            Technique t = new Technique(BruteForceOneCell);
            t.SolveBruteForceExample();
            var actual = t.SudokuGrid;
            var expected = EasyEnd;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod()]

        public void B_BruteForceEasyTestExample()

        {
            Technique t = new Technique(EasyStart);
            t.SolveBruteForceExample();
            var actual = t.SudokuGrid;
            var expected = EasyEnd;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void C_BruteForceMediumTestExample()

        {
            Technique t = new Technique(MediumStart);
            t.SolveBruteForceExample();
            var actual = t.SudokuGrid;
            var expected = MediumEnd;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void D_BruteForceDifficultTestExample()

        {
            Technique t = new Technique(DifficultStart);
            t.SolveBruteForceExample();
            var actual = t.SudokuGrid;
            var expected = DifficultEnd;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void G_BruteForceSuperDifficultTestExample()

        {
            Technique t = new Technique(SuperDifficultStart);
            t.SolveBruteForceExample();
            var actual = t.SudokuGrid;
            var expected = SuperDifficultEnd;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void E_BruteForceWorkedExample1TestExample()

        {
            Technique t = new Technique(WorkedExample1Start);
            t.SolveBruteForceExample();
            var actual = t.SudokuGrid;
            var expected = WorkedExample1End;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]

        public void F_BruteForceWorkedExample2TestExample()

        {
            Technique t = new Technique(WorkedExample2Start);
            t.SolveBruteForceExample();
            var actual = t.SudokuGrid;
            var expected = WorkedExample2End;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void G_BruteForceWorkedExample3TestExample()

        {
            Technique t = new Technique(WorkedExample3Start);
            t.SolveBruteForceExample();
            var actual = t.SudokuGrid;
            var expected = WorkedExample3End;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void H_AlreadySolvedExample()

        {
            Technique t = new Technique(WorkedExample3End);
            t.SolveBruteForceExample();
            var actual = t.SudokuGrid;
            var expected = WorkedExample3End;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void I_BruteForce4CellsBackExample()

        {
            Technique t = new Technique(BruteForceTwoCell);
            t.SolveBruteForceExample();
            var actual = t.SudokuGrid;
            var expected = EasyEnd;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void A_BruteForceOneCellTestCircular()

        {
            Technique t = new Technique(BruteForceOneCell);
            t.SolveBruteForce();
            var actual = t.SudokuGrid;
            var expected = EasyEnd;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod()]

        public void B_BruteForceEasyTestCircular()

        {
            Technique t = new Technique(EasyStart);
            t.SolveBruteForce();
            var actual = t.SudokuGrid;
            var expected = EasyEnd;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void C_BruteForceMediumTestCircular()

        {
            Technique t = new Technique(MediumStart);
            t.SolveBruteForce();
            var actual = t.SudokuGrid;
            var expected = MediumEnd;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void D_BruteForceDifficultTestCircular()

        {
            Technique t = new Technique(DifficultStart);
            t.SolveBruteForce();
            var actual = t.SudokuGrid;
            var expected = DifficultEnd;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void G_BruteForceSuperDifficultTestCircular()

        {
            Technique t = new Technique(SuperDifficultStart);
            t.SolveBruteForce();
            var actual = t.SudokuGrid;
            var expected = SuperDifficultEnd;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void E_BruteForceWorkedExample1TestCircular()

        {
            Technique t = new Technique(WorkedExample1Start);
            t.SolveBruteForce();
            var actual = t.SudokuGrid;
            var expected = WorkedExample1End;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]

        public void F_BruteForceWorkedExample2TestCircular()

        {
            Technique t = new Technique(WorkedExample2Start);
            t.SolveBruteForce();
            var actual = t.SudokuGrid;
            var expected = WorkedExample2End;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void G_BruteForceWorkedExample3TestCircular()

        {
            Technique t = new Technique(WorkedExample3Start);
            t.SolveBruteForce();
            var actual = t.SudokuGrid;
            var expected = WorkedExample3End;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void H_AlreadySolvedCircular()

        {
            Technique t = new Technique(WorkedExample3End);
            t.SolveBruteForce();
            var actual = t.SudokuGrid;
            var expected = WorkedExample3End;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void I_BruteForce4CellsBackCircular()

        {
            Technique t = new Technique(BruteForceTwoCell);
            t.SolveBruteForce();
            var actual = t.SudokuGrid;
            var expected = EasyEnd;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void J_BruteForce4CellsBackCircularWiki()

        {
            Technique t = new Technique(WorkedExampleWikiStart);
            t.SolveBruteForce();
            var actual = t.SudokuGrid;
            var expected = WorkedExampleWikiEnd;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void J_BruteForce4CellsBackJavaWiki()

        {
            Technique t = new Technique(WorkedExampleWikiStart);
            t.SolveBruteForceExample();
            var actual = t.SudokuGrid;
            var expected = WorkedExampleWikiEnd;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void K_BruteForce4CellsBackJavaVisual()

        {
            Technique t = new Technique(WorkedExampleVisualStart);
            t.SolveBruteForce();
            var actual = t.SudokuGrid;
            var expected = WorkedExampleVisualEnd;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void J_BruteForce4CellsBackExampleVisual()

        {
            Technique t = new Technique(WorkedExampleVisualStart);
            t.SolveBruteForceExample();
            var actual = t.SudokuGrid;
            var expected = WorkedExampleVisualEnd;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

   //    [TestMethod()]

        public void L_BruteForce4CellsBackExampleLONG()

        {
            Technique t = new Technique(SudokuBacktrackingCounterQuestion);
            t.SolveBruteForceExample();
            var actual = t.SudokuGrid;
            var expected = SudokuBackTrackingCounterAnswer;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LittleBook200TestExampleSolution()
        {
            Technique s = new Technique(LittleBook200Q);
            s.SolveBruteForceExample();
            var actual = s.Grid.SudokuGrid;
            var expected = LittleBook200Answer;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LittleBook200TestSolution()
        {
            Technique s = new Technique(LittleBook200Q);
            s.SolveBruteForce();
            var actual = s.Grid.SudokuGrid;
            var expected = LittleBook200Answer;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(actual[i, j]);
                }
                Console.WriteLine("");
            }
            CollectionAssert.AreEqual(expected, actual);
        }


    }

}