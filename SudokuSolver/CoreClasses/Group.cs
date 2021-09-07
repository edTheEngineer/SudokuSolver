using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RazorPagesSudoku.SudokuSolver.CoreClasses
{
    public class Group
    {
        [JsonProperty("Cells")]
        public Cell[] Cells { get; set; } //Array of Cells (Number, colour and possibility)

        [JsonProperty("GroupSize")]
        public int GroupSize { get; set; } //Group Size 9
        public Group() //Initiate an Empty Group with 9 Cells
        {
            GroupSize = 9;
            Cells = new Cell[GroupSize];
            for(int i = 0; i<GroupSize; i++)
            {
                Cells[i] = new Cell();
            }
        }
        public Group(int[] numbers) //Initiate Group and Initial Possibilities
        {
            GroupSize = 9;
            Cells = new Cell[GroupSize];
            for(int i = 0; i<numbers.Length; i++)
            {
                Cells[i] = new Cell(numbers[i]);
                
            }
            EliminatePossibilitiesInGroup();
        }
        public bool IsValid() //Checks if Group of Cells is Valid
        {
            var list = CellsToNumbers();
            return IsValidSet(list);
        }

        public List<int> InvalidList()
        {
            var list = CellsToNumbers();
            return findDuplicates(list);
        }
        public bool IsComplete() //Checks if Group of cells is complete
        {
                var list = CellsToNumbers();
                return IsCompleteSet(list);
        }
        public List<int> CellsToNumbers() //Puts Cell Array into List of Numbers
        {
            List<int> myList = new List<int>();
           foreach (var cellVal in Cells)
           {
               myList.Add(cellVal.Number);
           }

            return myList;
        }
        private bool IsValidSet(List<int> numbers) //Checks if a List of Numbers is Valid
        {
            var current = 0;
            numbers.Sort();
            foreach (var num in numbers)
            {
                if (num == 0)
                {
                    continue;
                }
                if (num == current)
                {
                    return false;
                }

                current = num;
            }


            return true;
        }


        public List<int> findDuplicates(List<int> numbers)
        {
            List<int> ans = new List<int>();
            for(int i=1; i<=9; i++)
            {
                var repeats = numbers.FindAll(x => x == i);
                
                
                if(repeats.Count>1)
                {
                    List<int> indexes = new List<int>();
                    for (int j = 0; j < 9; j++)
                    {
                        if(numbers[j]==i)
                        {
                            indexes.Add(j);
                        }
                    }
                    ans.AddRange(indexes);
                }
               
            }

            return ans;
        }
        private bool IsCompleteSet(List<int> numbers)//Checks if List of Numbers is Complete
        {
            foreach (var num in numbers)
            {
                if (num < 1 || num >9)
                {
                    return false;
                }
            }
            return true;
        }
        public void EliminatePossibilitiesInGroup()//Eliminate possibilities from a Group
        {
            foreach (var cellVal in Cells)
            {
                var num = cellVal.Number;
                foreach (var cellValue in Cells)
                {
                    cellValue.RemovePossibilities(num);
                }
            }
        }

       
    }
}
