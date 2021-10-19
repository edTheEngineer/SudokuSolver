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
        public Group[] Rows { get; set; } //Row of Cells

        [JsonProperty("Columns")]
        public Group[] Columns { get; set; } //Column of Cells

        [JsonProperty("Blocks")]
        public Group[] Blocks { get; set; }//Block of Cells

        public static int GroupSize { get; set; } = 9; //Sudoku size 9

        [JsonProperty("CellBlock")]
        private Dictionary<int, int> CellBlock { get; set; } = new Dictionary<int, int>(); //Maps Cells to Block

        [JsonProperty("RowCount")]
        public int RowCount { get; set; } // 9 rows

        [JsonProperty("ColumnCount")]
        public int ColumnCount { get; set; } //9 columns

        [JsonProperty("BlockWidth")]
        public int BlockWidth { get; set; }

        [JsonProperty("BlockHeight")]
        public int BlockHeight { get; set; }
        [JsonProperty("SudokuGrid")]
        public int[,] SudokuGrid { get; set; } //Sudoku Grid

        public AdvancedGrid(int[,] numbersIn) //Set up an advanced Grid
        {
            SetBlockDictionary();
            SudokuGrid = numbersIn;
            RowCount = 9;
            ColumnCount = 9;
            BlockHeight = 3;
            BlockWidth = 3;
            Rows = SetRows(numbersIn);
            Columns = SetCols(numbersIn);
            Blocks = SetBlocks(numbersIn);
            SudokuGrid = numbersIn;
            EliminatePossibilitiesInGroups();
            CreateCellsToAdd();
            Techniques = new List<string>();
        }

        public List<string> Techniques { get; set; } // Property to hold Techniques used to solve a Sudoku

        public string ROW = "_ROWS";
        public string COLUMNS = "_COLUMNS";
        public string BLOCKS = "_BLOCKS";
        private void CreateCellsToAdd()
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

        public void RowToCoOrdinates(int i, int j, out int r1, out int r2, out int c1, out int c2, out int b1, out int b2)
        {
            r1 = i;
            r2 = j;
            c1 = j;
            c2 = i;
            GetBlockNumberAndIndexInBlock(i, j, out int x, out int y);
            b1 = x;
            b2 = y;
        }

        public void ColumnToCoOrdinates(int i, int j, out int r1, out int r2, out int c1, out int c2, out int b1, out int b2)
        {
            r1 = j;
            r2 = i;
            c1 = i;
            c2 = j;
            GetBlockNumberAndIndexInBlock(i, j, out int x, out int y);
            b1 = x;
            b2 = y;
        }

        public void BlockToCoOrdinates(int i, int j, out int r1, out int r2, out int c1, out int c2, out int b1, out int b2)
        {
            b1 = i;
            b2 = j;
            var oneD = GetOneDRowIndexFromBlockCoordinates(i, j);
            GetCoOrdinatesOfCell(oneD, out int a, out int b);
            r1 = a;
            r2 = b;
            c1 = b;
            c2 = a;

        }

        public void HighlightNumber(int num, string className)
        {
            UnHighlightAll();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var poss = Rows[i].Cells[j].Possibilities;
                    if(poss.Contains(num))
                    {
                        Rows[i].Cells[j].SetColour(className);
                    }

                }
            }
            
        }

        public void HighlightError()
        {
            UnHighlightAll();
            var poss = findInvalidCells();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var check = i + ";" + j;
                    if (poss.Contains(check))
                    {
                        Rows[i].Cells[j].SetColour("invalidCell");
                    }

                }
            }

        }


        public void UnHighlightNumber(int num)
        {
            UnHighlightAll();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var poss = Rows[i].Cells[j].Possibilities;
                    if (poss.Contains(num))
                    {
                        Rows[i].Cells[j].SetColour("");
                    }

                }
            }

        }

        public void UnHighlightAll()

        {
            for(int i = 0; i<9; i++)
            {
                for(int j = 0; j<9; j++)
                {
                    Rows[i].Cells[j].SetColour("");
                }
            }
        }

        public void RemovePossibilitiesFromCell(int i, int j, string name)
        {
            GetCoOrdinatesFromName(i, j, name, out int r1, out int r2, out int b1, out int b2, out int c1, out int c2);
            //Console.WriteLine("Remove all " +name + " "+ r1 + " " + r2 + " , " + c1 + " " + c2 + " , " + b1 + " " + b2);
            Rows[r1].Cells[r2].RemoveAllPossibilities();
            Columns[c1].Cells[c2].RemoveAllPossibilities();
            Blocks[b1].Cells[b2].RemoveAllPossibilities();

        }

        private void GetCoOrdinatesFromName(int i, int j, string name, out int r1, out int r2, out int b1, out int b2, out int c1, out int c2)
        {
            r1 = 0;
            r2 = 0;
            b1 = 0;
            b2 = 0;
            c1 = 0;
            c2 = 0;
            if (name == ROW)
            {
                RowToCoOrdinates(i, j, out r1, out r2, out c1, out c2, out b1, out b2);

            }
            if (name == COLUMNS)
            {
                ColumnToCoOrdinates(i, j, out r1, out r2, out c1, out c2, out b1, out b2);
            }

            if (name == BLOCKS)
            {

                BlockToCoOrdinates(i, j, out r1, out r2, out c1, out c2, out b1, out b2);
            }
        }

        public void AddPossibilitiesToCell(int i, int j, string name, int num1)
        {
            GetCoOrdinatesFromName(i, j, name, out int r1, out int r2, out int b1, out int b2, out int c1, out int c2);

            Rows[r1].Cells[r2].AddPossibilities(num1);
            Columns[c1].Cells[c2].AddPossibilities(num1);
            Blocks[b1].Cells[b2].AddPossibilities(num1);

        }

        public int GetOneDRowIndexFromBlockCoordinates(int x, int y)
        {
            var i = CellsInBlock(x+1);
            return i[y];
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
            GroupSize = 9;
            SetBlockDictionary();
            SudokuGrid = new int[GroupSize, GroupSize];
            Rows = SetRows(SudokuGrid);
            Columns = SetCols(SudokuGrid);
            Blocks = SetBlocks(SudokuGrid);
            Techniques = new List<string>();

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

        public void SetNumberRemovePossibilities(int i, int j, int num, string techniqueName) //sets a Number
        {
            SetNumber(i, j, num, techniqueName);
            if (num != 0)
            {
                RemovePossibilitiesFromIntersectingCells();
            }

        }

        
        public void SetNumber(int i, int j, int num, string techniqueName)
        {
            RowToCoOrdinates(i, j, out int r1, out int r2, out int c1, out int c2, out int b1, out int b2);
            Rows[r1].Cells[r2].SetNumber(num);
            Rows[r1].Cells[r2].SetColour("");
            Columns[c1].Cells[c2].SetNumber(num);
            Blocks[b1].Cells[b2].SetNumber(num);
            SudokuGrid[r1, r2] = num;
            var coordinates = getUserFriendlyCoordinates(i, j);
            Techniques.Add("Put " + num + " in " + coordinates+ " . Technique is " + techniqueName + ".");
        }

        public void ClearOriginal(int i, int j) //sets a Number
        {
            Rows[i].Cells[j].SetOriginal(false);
            Columns[i].Cells[j].SetOriginal(false);
            Blocks[i].Cells[j].SetOriginal(false);

        }

        public void AddPossibility(int i, int j, int num) //Adds a Possibility to a Cell, and corresponding Rows / Blocks /Columns
        {
            RowToCoOrdinates(i, j, out int r1, out int r2, out int c1, out int c2, out int b1, out int b2);
            Rows[r1].Cells[r2].AddPossibilities(num);
            Columns[c1].Cells[c2].AddPossibilities(num);
            Blocks[b1].Cells[b2].AddPossibilities(num);
            
        }
        public void RemovePossibility(int i, int j, int num) //Removes a possibility from a cell, and corresponding Rows/ Blocks / Columns
        {
            RowToCoOrdinates(i, j, out int r1, out int r2, out int c1, out int c2, out int b1, out int b2);
            Rows[r1].Cells[r2].RemovePossibilities(num);
            Columns[c1].Cells[c2].RemovePossibilities(num);
            Blocks[b1].Cells[b2].RemovePossibilities(num);


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

        
        public List<string> findInvalidCells()
        {
            List<string> ans = new List<string>() {};
            bool isValid = IsValidOrIsCompleteSudoku(true);

            if (isValid)
            {
                return new List<string>();
            }

            else
            {
                var duplicates = ReturnDuplicates();
                return duplicates;
            }
            
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



        public List<string> GetIntersectingCellsInGroup(int xCoordinate, int yCoordinate, string groupName, bool excludeCurrent) //Gets Cells that Intersect with the current cell, including the current cells.
        {

            List<string> answer = new List<string>();

            if (groupName == COLUMNS)
            {
                for (int colNumber = 0; colNumber < GroupSize; colNumber++)
                {
                    if (excludeCurrent)
                    {
                        if(colNumber !=xCoordinate)
                        {
                            answer.Add(colNumber + ":" + yCoordinate);
                        }

                    }

                    else
                    {
                        answer.Add(colNumber + ":" + yCoordinate);
                    }
                    
                }
            }

            if (groupName == ROW)
            {
                //GET COLS
                for (int rowNumber = 0; rowNumber < GroupSize; rowNumber++)
                {
                    if(excludeCurrent)
                    {
                        if(rowNumber!=yCoordinate)
                        {
                            answer.Add(xCoordinate + ":" + rowNumber);
                        }
                    }

                    else
                    {
                        answer.Add(xCoordinate + ":" + rowNumber);
                    }
                    
                }
            }

            if (groupName == BLOCKS)
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
                    RemovePossibilities(intersect, currentNumber, "");
                }
            }
        }  

        public void RemovePossibilities(List<string> intersect, int num, string techniqueName) //Remove Possibilities from the Coordinates sent in. COORDINATES TO BE SPLIT
        {
            foreach (var t in intersect)
            {
                
                SplitTextCoordinate(t, out var i, out var j);
                RemovePossibility(i, j, num);
                var coordinates = getUserFriendlyCoordinates(i, j);
                if(techniqueName !="")
                {
                    Techniques.Add("Remove " + num + " from " + coordinates+" . Technique is " + techniqueName + ".");
                }
                
            }
        }

        public void BlockToMain(int x, int y, out int xx, out int yy)
        {
            //Console.WriteLine(x + "////" + y);
            List<int> cellsInBlock = GetCellsInBlock(x+1);
            var index = cellsInBlock[y];
            GetCoOrdinatesOfCell(index, out xx, out yy);
           
        }

        public void ColumnToMain(int x, int y, out int xx, out int yy)
        {
            xx = y;
            yy = x;
        }

        public void RowToMain(int x, int y, out int xx, out int yy)
        {
            xx = x;
            yy = y;
        }

        public void SetGrid(int i, int j, int number, string techniqueName)
        {
            SetNumberRemovePossibilities(i, j, number, techniqueName);
        }

        public void ClearGrid()
        {
            for (int i = 0; i < GroupSize; i++)
            {
                for (int j = 0; j < GroupSize; j++)
                {
                    SetNumberRemovePossibilities(i, j, 0, "");
                }
            }

            for (int i = 0; i < GroupSize; i++)
            {
                for (int j = 0; j < GroupSize; j++)
                {
                    ClearOriginal(i, j);
                }
            }

            Techniques.RemoveAll(x => x != "");
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

        public List<string> ReturnDuplicates()
        {
            List<string> ans = new List<string>();
            Console.WriteLine("ROWS");
            var r = ReturnInvalidDuplicates(Rows, ROW);
            Console.WriteLine("COLS");
            var c = ReturnInvalidDuplicates(Columns, COLUMNS);
            Console.WriteLine("BLOCKS");
            var b = ReturnInvalidDuplicates(Blocks, BLOCKS);
            ans.AddRange(r);
            ans.AddRange(c);
            ans.AddRange(b);
            ans.Sort();
            var x = ans.Distinct().ToList();
            
            return x;
        }
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

        public List<string> ReturnInvalidDuplicates(Group[] groupSet, string groupName) //Checks that the set of Groups is Valid and Complete
        {
            List<string> trueAns = new List<string>();
            for (int i = 0; i < groupSet.Count(); i++)
            {
                var ans = groupSet[i].InvalidList();
                Console.WriteLine("i is " + i);
                Console.WriteLine(string.Join("-", ans));
                var abc = buildCoordinates(ans, i, groupName);
                Console.WriteLine(string.Join("~", abc));
                trueAns.AddRange(abc);
            }

            return trueAns;
        }

        public List<string> buildCoordinates(List<int> coordinates, int indexIn, string groupName)
        {
            List<string> ans = new List<string>();

            for(int i = 0; i<coordinates.Count; i++)
            {
                if(groupName ==ROW)

                {
                   
                       var check = indexIn + ";" + coordinates[i];
                    ans.Add(check);
                }

                if(groupName ==BLOCKS)
                {

                    var oneD = GetOneDRowIndexFromBlockCoordinates(indexIn, coordinates[i]);
                    GetCoOrdinatesOfCell(oneD, out int a, out int b);
                    ans.Add(a + ";" + b);
                }

                if(groupName ==COLUMNS)
                {
                    var check = coordinates[i] + ";" + indexIn;
                    ans.Add(check);
                }
            }

            Console.WriteLine(string.Join("---", ans));
            return ans;
        }
        public bool IsValidAndIsCompleteSudoku() //Checks Sudoku is Valid and Is Complete
        {
            return IsValidOrIsCompleteSudoku(true) && IsValidOrIsCompleteSudoku(false);
        }

        public void findNextCell(int i, int j, out int x, out int y)
        {

            x = i;
            y = j+1;

            if (y > 8)
            {
                Console.WriteLine("y - 9 and x + 1");
                y -= 9;
                x += 1;

                if (x > 8)
                {
                    Console.WriteLine("x-9");
                    x -= 9;
                }
            }
            /*
            x=0;
            y=0;

            var oneD = Get1DIndex(i,j);
            var newOneD = oneD+2;
            var mod = newOneD % 81;
            if (mod == 0)
            {
                mod = 81;
            }
            
            GetCoOrdinatesOfCell(mod, out x, out y);

            */
        }

        public void findPreviousCell(int i, int j, out int x, out int y)
        {

            x = i;
            y = j-1;
            if (y < 0)
            {
                y += 9;
                x -= 1;
                Console.WriteLine("Y + 9 and X - 1");
                if (x < 0)
                {
                    Console.WriteLine("X + 9");
                    x += 9;
                }
            }
            /*
            x = 0;
            y = 0;

            var oneD = Get1DIndex(i, j);
            var newOneD = oneD;
            var mod = newOneD % 81;
            if (mod == 0)
            {
                mod = 81;
            }
            GetCoOrdinatesOfCell(mod, out x, out y);#*/
        }

        public void findUpwardsCell(int i, int j, out int x, out int y)
        {  //default
            
            x = i - 1;
            y = j;
            if(x<0)
            {
                x += 9;
                y -=1;
                Console.WriteLine("X + 9 and Y - 1");
                if(y<0)
                {
                    Console.WriteLine("Y + 9");
                    y += 9;
                }
            }

        }
    

        public void findDownwardsCell(int i, int j, out int x, out int y)
        {

            x = i + 1;
            y = j;

            if(x >8)
            {
                Console.WriteLine("X - 9 and Y + 1");
                x -= 9;
                y += 1;

                if(y>8)
                {
                    Console.WriteLine("Y-9");
                    y -= 9;
                }
            }
           
        }
        public string getUserFriendlyCoordinates(int i, int j)
        {
            int x = i + 1;
            int a = (char)('A');
            int diff = a+j;
            char y = Convert.ToChar(diff);
            
            return "[" + x + " , " + y+"]";
        }

        public string moveCoordinate(string coordinate, string direction)

        {
            //myInput
            string word = "myInput;";
            string trueCoordinate = coordinate.Substring(8);
            Console.WriteLine(trueCoordinate);
            if(direction =="up")
            {
                return  word + Up(trueCoordinate);
            }

            if (direction == "down")
            {
                return word + Down(trueCoordinate);
            }
            if (direction == "left")
            {
                return word + Left(trueCoordinate);
            }

            if (direction == "right")
            {
                return word + Right(trueCoordinate);
            }
            return coordinate;
        }


        private string Up(string coordinate)
        {
            SplitTextCoordinate(coordinate, out int i, out int j);
            findUpwardsCell(i, j, out int x, out int y);
            return x + ";" + y;
        }

        private string Down(string coordinate)
        {
            SplitTextCoordinate(coordinate, out int i, out int j);
            findDownwardsCell(i, j, out int x, out int y);
            return x + ";" + y;
        }

        private string Left(string coordinate)
        {
            SplitTextCoordinate(coordinate, out int i, out int j);
            findPreviousCell(i, j, out int x, out int y);
            return x + ";" + y;
        }

        private string Right(string coordinate)
        {
            SplitTextCoordinate(coordinate, out int i, out int j);
            findNextCell(i, j, out int x, out int y);
            return x + ";" + y;
        }
    }
}
