using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RazorPagesSudoku.SudokuSolver.CoreClasses
{
    public class Cell
    {

        [JsonProperty("Number")]
        public int Number { get;  set; } //Number of the Cell

        [JsonProperty("Colour")]
        public string Colour { get; private set; } //Colour of the Cell
        [JsonProperty( PropertyName ="Possibilities")]
        public List<int> Possibilities { get; private set; } //Possibilities of the Cell
         //public int[] Possibilities { get; private set; }
        public void SetPossibilities(List<int> poss)
        {
            for (int i = 0; i<poss.Count; i++)
            {
                AddPossibilities(poss[i]);
            }
        }

        [JsonProperty("IsOriginalValue")]

        public bool IsOriginalValue { get; private set; }
        public Cell()  //Set a blank Cell
        {
            
            if (Possibilities==null)
            {
                Possibilities = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            }

            IsOriginalValue = false;

        }

        public Cell(int number) //Set a Cell with Numbers and No Possibilities
        {
            Number = number;
            
            if(number ==0)
            {
                if(Possibilities == null)
                {
                    Possibilities = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                }
            }

            else
            {
                Possibilities = new List<int>();
                IsOriginalValue = true;
            }

        }

        public void SetNumber(int number) //Add A Number to the Cell, and remove all possibilities
        {
            Number = number;
            if(number ==0)
            {
                AddAllPossibilities();
            }

            else
            {
                RemoveAllPossibilities();
            }
            
        }

        public void SetOriginal(bool isTrue)//Sets the Value of the Cell as one of the givens

        {
            IsOriginalValue = isTrue;
        }
        public void SetColour(string colourIn) //Set the colour of a cell
        {
            if(Colour ==colourIn)
            {
                Colour = "";
            }

            else
            {
                Colour = colourIn;
            }
            
        }
        public void RemoveAllPossibilities() //Remove all Possibilities
        {
            Possibilities.RemoveAll(x => x >= 0);
        }

        private void AddAllPossibilities()
        {
            RemoveAllPossibilities();
            for(int i = 1; i<=9; i++)
            {
                Possibilities.Add(i);
            }

            if(Possibilities.Count!=9)
            {
                Console.Write("ERROR");
            }
        }
        public void AddPossibilities(int number) //Add Possibilities to a cell
        {
            if(Number !=0 || number ==0)
            {
                return;
            }
            if(Possibilities.Contains(number))
            {
                
            }

            else
            {
                Possibilities.Add(number);
            }
        }
        public void RemovePossibilities(int number)//Remove Possibilities from a Cell
        {
            if(Possibilities.Count>1 && Number ==0)
            {
                Possibilities.RemoveAll(x => x == number);
            }
            
        }

      

    }
}
