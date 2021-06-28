using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace RazorPagesSudoku.SudokuSolver.CoreClasses
{
    public class AdvancedGrid
    {
        [JsonProperty("Rows")] //NEED FOR JSON DESERIALISATION
        public Group [] Rows { get; set; } //Row of Cells

        [JsonProperty("Columns")]
        public Group [] Columns { get; set; } //Column of Cells

        [JsonProperty("Blocks")]
        public Group [] Blocks { get; set; }//Block of Cells
       
        public static int GroupSize { get; set; } = 9; //Sudoku size 9

        [JsonProperty("CellBlock")]
        private Dictionary<int, int> CellBlock { get; set; } = new Dictionary<int, int>(); //Maps Cells to Block

        [JsonProperty("RowCount")]
        public int RowCount { get; set; } // 9 rows

        [JsonProperty("ColumnCount")]
        public int ColumnCount { get; set; } //9 columns
        [JsonProperty("SudokuGrid")]
        public int[,] SudokuGrid { get; set; } //Sudoku Grid

       // [JsonProperty("filledInCells")]
       // public List<int> filledInCells { get; set; } = new List<int>();
        public AdvancedGrid(int [,] numbersIn) //Set up an advanced Grid
        {
            SetBlockDictionary();
            SudokuGrid = numbersIn;
            RowCount = 9;
            Rows = SetRows(numbersIn);
            Columns = SetCols(numbersIn);
            Blocks = SetBlocks(numbersIn);
            SudokuGrid = numbersIn;
            EliminatePossibilitiesInGroups();
            createCellsToAdd();
        }

        private void createCellsToAdd()
        {
            var filledInCells = new List<int>();
            for (int i = 1; i <= 81; i++)
            {
                GetCoOrdinatesOfCell(i, out int x, out int y);
                if (SudokuGrid[x, y] == 0)
                {
                    filledInCells.Add(i);
                }
            }

        }

        public void EliminatePossibilitiesInGroups()
        {
            for (int i= 0; i < 9; i++)
            {
                Rows[i].EliminatePossibilitiesInGroup();
                Columns[i].EliminatePossibilitiesInGroup();
                Blocks[i].EliminatePossibilitiesInGroup();
            }
        } //Eliminate Possibilities in Group where the Number is present
        public AdvancedGrid() //Set up a Grid with No Cells
        {
            RowCount = 9;
            SetBlockDictionary();
            SudokuGrid = new int[GroupSize, GroupSize];
            Rows = SetRows(SudokuGrid);
            Columns = SetCols(SudokuGrid);
            Blocks = SetBlocks(SudokuGrid);
            
        }
        public Group[] SetRows(int[,] numbers) //Sets up Row Groups
        {
            Group[] myGroup = new Group[GroupSize];
            for (int i = 0; i < GroupSize; i++)
            {
                int[] myArray = new int[GroupSize];
                for (int j = 0; j < GroupSize; j++)
                {
                    myArray[j] = numbers[i, j];
                }

                var g = new Group(myArray);
                
                myGroup[i] = g;
            }
            
            return myGroup;
        }
        public Group[] SetCols(int[,] numbers) //Sets up Column Groups
        {
            Group[] myGroup = new Group[GroupSize];
            for (int i = 0; i < GroupSize; i++)
            {
                int[] myArray = new int[GroupSize];
                for (int j = 0; j < GroupSize; j++)
                {
                    myArray[j] = numbers[j,i];
                }

                var g = new Group(myArray);
                myGroup[i] = g;
            }

            return myGroup;
        }

        public Group[] SetBlocks(int[,] numbers) //Sets up Block Groups
        {

            Group[] myGroup = new Group[GroupSize];

            for(int i = 1; i<= GroupSize; i++)
            {
                var cellsInCurrentBlock = CellsInBlock(i);
               
                int counter = 1;
                int arrayCounter = 0;
                int[] numbersInCurrentBlock = new int[GroupSize];
                for (int j = 0; j < GroupSize; j++)
                {
                    for (int k = 0; k < GroupSize; k++)
                    {
                        if (arrayCounter == GroupSize)
                        {
                            continue;
                        }
                        if (counter == cellsInCurrentBlock[arrayCounter])
                        {
                            numbersInCurrentBlock[arrayCounter] = numbers[j, k];
                            arrayCounter += 1;
                            counter += 1;
                        }
                        else
                        {
                            counter += 1;
                        }
                    }
                }
                var currentGroup = new Group(numbersInCurrentBlock);
                myGroup[i-1] = currentGroup;
            }
            
            return myGroup;
        }

        public int[] CellsInBlock(int numberIn) //Find 1D Index of the Cells in a Block
        {
            List<int> myList = new List<int>();
            for(int i = 1; i<=CellBlock.Count; i++)
            {
                if(CellBlock[i] ==numberIn)
                {
                    myList.Add(i);
                }
            }
            return myList.ToArray(); 
        }

        

        public void SetBlockDictionary() //sets up block dictionary
        {
            
            var block = 1;
            int blockStart;
            int key = 1;
            for(blockStart = 1; blockStart<10;)
            {
                for(int rowsPerBlock = 0; rowsPerBlock<3; rowsPerBlock++)
                {
                    for (int columnsPerBlock = 0; columnsPerBlock < 3; columnsPerBlock++)
                    {
                        for (int blocksPerSection = 0; blocksPerSection < 3; blocksPerSection++)
                        {
                            if (CellBlock.ContainsKey(key))
                            {
                            }
                            else
                            {
                                CellBlock.Add(key, block);
                            }
                            
                            key += 1;
                        }

                        block += 1;
                    }
                    block = blockStart;
                }

                block += 3;
                blockStart += 3;
                
            }

        }

        public void SetNumber(int i, int j, int num) //sets a Number
        {
            Rows[i].Cells[j].SetNumber(num);
            Columns[j].Cells[i].SetNumber(num);
            GetBlockNumberAndIndexInBlock(i,j, out int x, out int y);
            Blocks[x].Cells[y].SetNumber(num);
            SudokuGrid[i, j] = num;
            //removePossibility(i, j, num);
            if(num!=0)
            {
                RemovePossibilitiesFromIntersectingCells();
            }
            
        }

        public void SetNumberOnGrid(int i, int j, int num) //sets a Number
        {
            Rows[i].Cells[j].SetNumber(num);
            Columns[j].Cells[i].SetNumber(num);
            GetBlockNumberAndIndexInBlock(i, j, out int x, out int y);
            Blocks[x].Cells[y].SetNumber(num);
            SudokuGrid[i, j] = num;
            //removePossibility(i, j, num);
            

        }
        public void ClearOriginal(int i, int j) //sets a Number
        {
            Rows[i].Cells[j].SetOriginal(false);
            Columns[i].Cells[j].SetOriginal(false);
            Blocks[i].Cells[j].SetOriginal(false);

        }

        public void AddPossibility(int i, int j, int num) //Adds a Possibility to a Cell, and corresponding Rows / Blocks /Columns
        {
            Rows[i].Cells[j].AddPossibilities(num);
            Columns[j].Cells[i].AddPossibilities(num);
            GetBlockNumberAndIndexInBlock(i, j, out int x, out int y);
            Blocks[x].Cells[y].AddPossibilities(num);
            
        }
        public void RemovePossibility(int i, int j, int num) //Removes a possibility from a cell, and corresponding Rows/ Blocks / Columns
        {
           
            Rows[i].Cells[j].RemovePossibilities(num);
            Columns[j].Cells[i].RemovePossibilities(num);
            GetBlockNumberAndIndexInBlock(i, j, out int x, out int y);
            Blocks[x].Cells[y].RemovePossibilities(num);


        }
        public int GetBlockFromCoOrdinates(int x, int y)
        {
            int cell = Get1DIndex(x, y);
            return CellBlock[cell + 1];
        } //Gets a Block from the Coordinates

        public int Get1DIndex(int x, int y)
        {
            return x * GroupSize + y;
        } //Gets 1D Index from the Coordinates


        public void GetBlockNumberAndIndexInBlock(int gridX,  int inY,  out int blockNumber, out int blockIndex) //Gets Block Number and Index in Block from the Sudoku Grid
        {
             int cell = Get1DIndex(gridX, inY);
             
             blockNumber = GetBlockFromCoOrdinates(gridX, inY); //6th block (INDEX 5);
             blockIndex = 0;
            List<int>  cellsInBlock= GetCellsInBlock(blockNumber);
           
            blockNumber -= 1;
            for (int j = 0; j<cellsInBlock.Count; j++)
            {
                if(cellsInBlock[j]==cell +1)
                {
                    blockIndex = j;
                }
            }
           
        } //

        public List<int> GetCellsInBlock(int numIn) //Get 1D Index of Cells in Block
        {
            var result = from cells in CellBlock
                         where cells.Value == numIn
                         select cells.Key;
            List<int> listOut = result.ToList();
            return listOut;
        }

        

        public void GetCoOrdinatesOfCell(int cellIn, out int i, out int y) //Gets x and Y coordinate of a singular Index
        {
            cellIn -= 1;
            i =cellIn  / GroupSize;
            //y = cellIn - (i * 9) Can be represented as modulus ;
            y = cellIn % GroupSize;


        } 

        public void SplitTextCoordinate(string x, out int i, out int y) //Split coordinate of 2:3 into 2 and 3
        {
            i = Convert.ToInt32(x.Substring(0, 1));
            y = Convert.ToInt32(x.Substring(2, 1));
        }



        public List<string> GetIntersectingCellsInGroup(int xCoordinate, int yCoordinate, string groupName) //Gets Cells that Intersect with the current cell, including the current cells.
        {

            List<string> answer = new List<string>();

            if (groupName == "C")
            {
                for (int colNumber = 0; colNumber < GroupSize; colNumber++)
                {
                    answer.Add(colNumber + ":" + yCoordinate);
                }
            }

            if (groupName == "R")
            {
                //GET COLS
                for (int rowNumber = 0; rowNumber < GroupSize; rowNumber++)
                {
                    answer.Add(xCoordinate + ":" + rowNumber);
                }
            }

            if (groupName == "B")
            {
                int block = GetBlockFromCoOrdinates(xCoordinate, yCoordinate);
                var cells = CellsInBlock(block);

                foreach (var cellValue in cells)
                {
                    GetCoOrdinatesOfCell(cellValue, out int xOut, out int yOut);
                    answer.Add(xOut + ":" + yOut);
                }
            }

            answer = answer.Distinct().ToList();
            return answer;
        }

        public List<string> GetIntersectingCells(int xCoordinate, int yCoordinate) //Gets Cells that Intersect with the current cell, including the current cells.
        {

            List<string> answer = new List<string>();

            //ROW
            for (int colNumber = 0; colNumber < GroupSize; colNumber++)
                {
                    answer.Add(xCoordinate + ":" + colNumber);
                }



                //GET COLS
                for (int rowNumber = 0; rowNumber < GroupSize; rowNumber++)
                {
                    answer.Add(rowNumber + ":" + yCoordinate);
                }

                int block = GetBlockFromCoOrdinates(xCoordinate, yCoordinate);
                var cells = CellsInBlock(block);

                foreach (var cellValue in cells)
                {
                    GetCoOrdinatesOfCell(cellValue, out int xOut, out int yOut);
                    answer.Add(xOut + ":" + yOut);
                }
          
            answer = answer.Distinct().ToList();
            return answer;
        }
        public void RemovePossibilitiesFromIntersectingCells() //Removes Possibilities from cells that share the same row, column or block as a cell with a number in.
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var currentNumber = Rows[i].Cells[j].Number;

                    var intersect = GetIntersectingCells(i, j);
                    RemovePossibilities(intersect, currentNumber);
                }
            }
        }  

        public void RemovePossibilities(List<string> intersect, int num) //Remove Possibilities from the Coordinates sent in. COORDINATES TO BE SPLIT
        {
            foreach (var t in intersect)
            {
                SplitTextCoordinate(t, out var i, out var j);
                RemovePossibility(i, j, num);
            }
        }

        public void BlockToMain(int x, int y, out int xx, out int yy)
        {
            List<int> cellsInBlock = GetCellsInBlock(x+1);
            var index = cellsInBlock[y];
            GetCoOrdinatesOfCell(index, out xx, out yy);
           
        }

        public void ColumnToMain(int x, int y, out int xx, out int yy)
        {
            xx = y;
            yy = x;
        }

        public void SetGrid(int i, int j, int number)
        {
            SetNumber(i, j, number);
        }

        public void ClearGrid()
        {
            for (int i = 0; i < GroupSize; i++)
            {
                for (int j = 0; j < GroupSize; j++)
                {
                    SetNumber(i, j, 0);
                }
            }

            for (int i = 0; i < GroupSize; i++)
            {
                for (int j = 0; j < GroupSize; j++)
                {
                    ClearOriginal(i, j);
                }
            }
        }

        public static AdvancedGrid FromJson(string json)
        {
            return JsonConvert.DeserializeObject<AdvancedGrid>(json, Converter.Settings);

            //Takes Json Files, and puts Converter Settings
        }

        public bool IsValidOrIsCompleteSudoku(bool isValidComplete) //Method that checks if a Sudoku is Valid or is Complete based on the value sent in
        {
            return IsValidOrIsCompleteGroups(Rows, isValidComplete) && IsValidOrIsCompleteGroups(Columns, isValidComplete) && IsValidOrIsCompleteGroups(Blocks, isValidComplete);
        } //Checks the Sudoku is Valid & Complete
        public bool IsValidOrIsCompleteGroups(Group[] groupSet, bool isValidCompleteCall) //Checks that the set of Groups is Valid and Complete
        {
            for (int i = 0; i < groupSet.Count(); i++)
            {
                bool isValidComplete;
                if (isValidCompleteCall)
                {
                    isValidComplete = groupSet[i].IsValid();
                }

                else
                {
                    isValidComplete = groupSet[i].IsComplete();
                }

                if (!isValidComplete)
                {
                    return false;
                }
            }

            return true;
        }
        public bool IsValidAndIsCompleteSudoku() //Checks Sudoku is Valid and Is Complete
        {
            return IsValidOrIsCompleteSudoku(true) && IsValidOrIsCompleteSudoku(false);
        }

    }
}
