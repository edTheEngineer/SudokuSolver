using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using RazorPagesSudoku.SudokuSolver.CoreClasses;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RazorPagesSudoku
{
    public class SudokuModel : PageModel
    {
       
        [BindProperty]

        public int CellsToSolve { get; set; }

        [TempData]
        public string ResultInfo { get; set; }


        [BindProperty]
        public string CellSelection { get; set; }
        public string[] Cells = new[] { "Single Cell", "Multi Cell" };

        public AdvancedGrid  Grid{ get; set; }

        public bool IsSolved { get; set; }
        public bool IsMinimum { get; set; }
        public bool IsValid { get; set; }

        public List<string> Techniques { get; set; }

        public List<string> IntersectingTechniques { get; set; }

        //Session Variables

        //Selected I
        public string SessionInfoSelectedI { get; private set; }
        public const string SessionKeySelectedI = "_ICell";

        //Selected J
        public string SessionInfoSelectedJ { get; private set; }
        public const string SessionKeySelectedJ = "_JCell";
        //Selected J
        public string SessionInfoHighlightedCells { get; private set; }
        public const string SessionKeyHighlightedCells = "_HighlightedCells";

        //IsValid

        public string SessionInfoIsValid { get; private set; }
        public const string SessionKeyIsValid = "_IsValid";

        //IsMinimum

        public string SessionInfoIsMinimum { get; private set; }
        public const string SessionKeyIsMinimum = "_IsMinimum";


        //IsSolved
        public string SessionInfoSolved { get;  set; }
        public const string SessionKeySolved = "_IsSolved";


        //Grid
        protected string SessionInfoSudokuGrid { get; set; }
        public const string SessionKeySudokuGrid = "sudokuGrid";

        //IsNumber
        public string SessionInfoIsNumber { get; set; }
        public const string SessionKeyIsNumber = "_isNumber";

        public string SessionInfoTechniques { get; set; }
        public const string SessionKeyTechniques = "_Techniques";

        public string SessionInfoIntersectingTechniques { get; set; }
        public const string SessionKeyIntersectingTechniques = "_IntersectingTechniques";

        public void SerializeGrid()
        {
            AdvancedGrid temp = new AdvancedGrid();
            temp =HttpContext.Session.Get<AdvancedGrid>(SessionKeySudokuGrid);
            if (temp==default)
            {
                Grid = new AdvancedGrid();
                HttpContext.Session.Set(SessionKeySudokuGrid, Grid);
                HttpContext.Session.Set(SessionKeyTechniques, new List<string>());
            }

            else

            {
                Grid = HttpContext.Session.Get<AdvancedGrid>(SessionKeySudokuGrid);
                Techniques = HttpContext.Session.Get<List<string>>(SessionKeyTechniques);
            }
            
            var check = HttpContext.Session.getA(SessionKeySudokuGrid);
            MapGrid(check);
            
        }

        public void MapGrid(AdvancedGrid g)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)

                {
                    
                    Grid.Rows[i].Cells[j].SetPossibilities(g.Rows[i].Cells[j].Possibilities);
                    Grid.Blocks[i].Cells[j].SetPossibilities(g.Columns[i].Cells[j].Possibilities);
                    Grid.Columns[i].Cells[j].SetPossibilities(g.Blocks[i].Cells[j].Possibilities);
                    Grid.SudokuGrid[i, j] = g.SudokuGrid[i, j];
                }
            }

        }

        public void OnGet()
        {
            GetGridCells();
            SerializeGrid();
        }

        private void GetGridCells()
        {
            SetSessionStringIfNull(SessionKeySelectedI);
            SetSessionStringIfNull(SessionKeySelectedJ);
            SetSessionStringIfNull(SessionKeyHighlightedCells);
            SetSessionStringIfNull(SessionKeyIsMinimum);
            SetSessionStringIfNull(SessionKeyIsValid);
            SetSessionStringIfNull(SessionKeySolved);
            SetSessionStringIfNull(SessionKeyIsNumber);
            SessionInfoSelectedI = HttpContext.Session.GetString(SessionKeySelectedI);
            SessionInfoSelectedJ = HttpContext.Session.GetString(SessionKeySelectedJ);
            SessionInfoHighlightedCells = HttpContext.Session.GetString(SessionKeyHighlightedCells);
            SessionInfoIsMinimum = HttpContext.Session.GetString(SessionKeyIsMinimum);
            SessionInfoIsValid = HttpContext.Session.GetString(SessionKeyIsValid);
            SessionInfoSolved = HttpContext.Session.GetString(SessionKeySolved);
            SessionInfoIsNumber = HttpContext.Session.GetString(SessionKeyIsNumber);
            //GetIntersectingTechniques();
        }

        private void SetSessionStringIfNull(string key)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(key)))
            {
                HttpContext.Session.SetString(key, "-");
            }
        }

        private void setSessionVariables(bool isClear)
        {
            if(isClear)
            {
                HttpContext.Session.Set(SessionKeySudokuGrid, Grid);
                HttpContext.Session.SetString(SessionKeyIsValid, "-");
                HttpContext.Session.SetString(SessionKeySolved, "-");
                HttpContext.Session.SetString(SessionKeyIsMinimum, "-");
                HttpContext.Session.SetString(SessionKeyIsNumber, "-");
            }

            else
            {
                HttpContext.Session.Set(SessionKeySudokuGrid, Grid);
                HttpContext.Session.Set(SessionKeyTechniques, Techniques);
                HttpContext.Session.SetString(SessionKeyIsValid, IsValid.ToString());
                HttpContext.Session.SetString(SessionKeySolved, IsSolved.ToString());
                HttpContext.Session.SetString(SessionKeyIsMinimum, IsMinimum.ToString());
            }
            
        }

        private void GetIntersectingTechniques()
        {
            IntersectingTechniques = new List<string> { "Ed", "Likes", "Cheese", SessionInfoSelectedI, SessionInfoSelectedJ };
            var i = Convert.ToInt32(SessionInfoSelectedI);
            var j = Convert.ToInt32(SessionInfoSelectedJ);
            var intersect = Grid.GetIntersectingCells(i, j);
            foreach(var x in intersect)
            {
                IntersectingTechniques.Add(x);
            }
        }


        public async Task<IActionResult> OnPostSolveSudokuAsync()
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            GetGridCells();
            SerializeGrid();
            Solver s = new Solver(Grid.SudokuGrid);
            s.SolveSudoku();
            Grid = s.Grid;
            IsSolved = s.IsSolved;
            IsValid = s.IsValid;
            IsMinimum = s.IsMinimum;
            Techniques = s.Grid.Techniques;
            setSessionVariables(false);
            

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveExampleSudokuAsync()
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            GetGridCells();
            SerializeGrid();
            var example = new[,]
           {
{7,0,9,0,3,8,6,0,0},
{0,6,3,0,0,0,0,0,9},
{0,0,0,0,0,0,0,0,0},
{0,5,7,8,0,6,9,0,4},
{4,0,0,0,0,0,0,0,5},
{6,0,8,4,0,5,7,2,0},
{0,0,0,0,0,0,0,0,0},
{2,0,0,0,0,0,3,9,0},
{0,0,6,7,1,0,5,0,2}
};
            Solver s = new Solver(example);
            s.SolveSudoku();
            Grid = s.Grid;
            IsSolved = s.IsSolved;
            IsValid = s.IsValid;
            IsMinimum = s.IsMinimum;
            Techniques = s.Grid.Techniques;
            setSessionVariables(false);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostClearSudokuAsync()
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid ClearSudoku Solve";
                return Page();
            }

            GetGridCells();
            SerializeGrid();
            Grid = HttpContext.Session.Get<AdvancedGrid>(SessionKeySudokuGrid);
    
            Grid.ClearGrid();
            Grid.UnHighlightAll();
            setSessionVariables(true);
            return RedirectToPage();
            
        }



        public async Task<IActionResult> OnPostSolveNextEntriesAsync()
        {
            if (!ModelState.IsValid)
            {
                ResultInfo = "Invalid Solve Next Entries";
                await Task.CompletedTask;
                return Page();
            }

            ResultInfo = "I will solve the next " + CellsToSolve + "number of cells";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveSelectedCellsAsync()
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Solve Selected Cells";
                return Page();
            }

            ResultInfo = "I will solve the selected cells";
            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostSelectCellAsync(int i, int j)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Select Cell";
                return Page();
            }

            
            
            GetGridCells();
            setSelectedCell(i, j);
            SerializeGrid();
           
            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostHighlightPossiblityAsync(int num)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Select Cell";
                return Page();
            }
            bool isHighlight = false;
            var iString = num.ToString();
            //var jString = j.ToString();
            GetGridCells();
            if (iString == SessionInfoHighlightedCells)
            {
                
                HttpContext.Session.SetString(SessionKeyHighlightedCells, "-");
                HttpContext.Session.SetString(SessionKeySelectedJ, "-");
            }

            else
            {
                isHighlight = true;
                HttpContext.Session.SetString(SessionKeyHighlightedCells, num.ToString());
                
            }

            SerializeGrid();
            if(isHighlight)
            {
                Grid.HighlightNumber(num);
            }

            else
            {
                Grid.UnHighlightNumber(num);
            }
            
            HttpContext.Session.Set(SessionKeySudokuGrid, Grid);
            
            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostSelectNumberAsync( int num)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Select Number";
                return Page();
            }
            GetGridCells();
            var iNumber = Convert.ToInt32(SessionInfoSelectedI);
            var jjNumber = Convert.ToInt32(SessionInfoSelectedJ);

            SerializeGrid();
            Grid.SetNumberRemovePossibilities(iNumber, jjNumber, num, "");
            if(SessionInfoHighlightedCells!="-")
            {
                Grid.HighlightNumber(Convert.ToInt32(SessionInfoHighlightedCells));
            }
            
            HttpContext.Session.Set(SessionKeySudokuGrid, Grid); 
            AdvancedGrid g = new AdvancedGrid(Grid.SudokuGrid);
            g.findNextCell(iNumber, jjNumber, out int x, out int y);

            setSelectedCell(x, y);
            IsValid = g.IsValidOrIsCompleteSudoku(true);
            HttpContext.Session.SetString(SessionKeyIsValid, IsValid.ToString());
            return RedirectToPage();


        }

        public async Task<IActionResult> OnPostSkipNumberAsync()
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Skip Number";
                return Page();
            }
            GetGridCells();
            var iNumber = Convert.ToInt32(SessionInfoSelectedI);
            var jjNumber = Convert.ToInt32(SessionInfoSelectedJ);

            SerializeGrid();
            HttpContext.Session.Set(SessionKeySudokuGrid, Grid);
            AdvancedGrid g = new AdvancedGrid(Grid.SudokuGrid);
            g.findNextCell(iNumber, jjNumber, out int x, out int y);

            var iString = x.ToString();
            var jString = y.ToString();
            if (iString == SessionInfoSelectedI && jString == SessionInfoSelectedJ)
            {
                HttpContext.Session.SetString(SessionKeySelectedI, "-");
                HttpContext.Session.SetString(SessionKeySelectedJ, "-");
            }

            else
            {

                HttpContext.Session.SetString(SessionKeySelectedI, x.ToString());
                HttpContext.Session.SetString(SessionKeySelectedJ, y.ToString());
            }
            IsValid = g.IsValidOrIsCompleteSudoku(true);
            HttpContext.Session.SetString(SessionKeyIsValid, IsValid.ToString());
            return RedirectToPage();


        }
        public async Task<IActionResult> OnPostSelectPossibilityAsync(int possibility)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Select Number";
                return Page();
            }

            GetGridCells();
            var iNumber = Convert.ToInt32(SessionInfoSelectedI);
            var jjNumber = Convert.ToInt32(SessionInfoSelectedJ);

            SerializeGrid();
            var Poss = Grid.Rows[iNumber].Cells[jjNumber].Possibilities;
            var isPoss = Poss.Any(x => x == possibility);
            if (isPoss)
            {
                Grid.RemovePossibility(iNumber, jjNumber, possibility);
            }
            else

            {
                Grid.AddPossibility(iNumber, jjNumber, possibility);
            }
            
            HttpContext.Session.Set(SessionKeySudokuGrid, Grid);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemovePossibilityAsync(int possibility)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Select Number";
                return Page();
            }

            GetGridCells();
            var iNumber = Convert.ToInt32(SessionInfoSelectedI);
            var jjNumber = Convert.ToInt32(SessionInfoSelectedJ);

            SerializeGrid();
            Grid = HttpContext.Session.Get<AdvancedGrid>(SessionKeySudokuGrid);
            Grid.AddPossibility(iNumber, jjNumber, possibility);
            HttpContext.Session.Set(SessionKeySudokuGrid, Grid);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostShowNumbersOrPossibilitiesAsync()
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Select Number";
                return Page();
            }
            GetGridCells();
            SerializeGrid();
            if(SessionInfoIsNumber =="False")
            {
                HttpContext.Session.SetString(SessionKeyIsNumber, "True");
            }

            else
            {
                HttpContext.Session.SetString(SessionKeyIsNumber, "False");
            }
            return RedirectToPage();
        }

        private void setSelectedCell(int x, int y )
        {
            var iString = x.ToString();
            var jString = y.ToString();

            if (iString == SessionInfoSelectedI && jString == SessionInfoSelectedJ)
            {
                HttpContext.Session.SetString(SessionKeySelectedI, "-");
                HttpContext.Session.SetString(SessionKeySelectedJ, "-");
            }

            else
            {

                HttpContext.Session.SetString(SessionKeySelectedI, x.ToString());
                HttpContext.Session.SetString(SessionKeySelectedJ, y.ToString());
            }
        }
    }
}
