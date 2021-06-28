using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using RazorPagesSudoku.SudokuSolver.CoreClasses;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;

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

        //Session Variables

        //Selected I
        public string SessionInfoSelectedI { get; private set; }
        public const string SessionKeySelectedI = "_ICell";

        //Selected J
        public string SessionInfoSelectedJ { get; private set; }
        public const string SessionKeySelectedJ = "_JCell";

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

        //Grid
        public string SessionInfoIsNumber { get; set; }
        public const string SessionKeyIsNumber = "_isNumber";

        public void SerializeGrid()
        {
            AdvancedGrid temp = new AdvancedGrid();
            temp =HttpContext.Session.Get<AdvancedGrid>(SessionKeySudokuGrid);
            if (temp==default)
            {
                Grid = new AdvancedGrid();
                HttpContext.Session.Set(SessionKeySudokuGrid, Grid);
            }

            else

            {
                Grid = HttpContext.Session.Get<AdvancedGrid>(SessionKeySudokuGrid);
            }
            
            var check = HttpContext.Session.getA(SessionKeySudokuGrid);
            mapGrid(check);
            
        }

        public void mapGrid(AdvancedGrid g)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)

                {
                    
                    Grid.Rows[i].Cells[j].setPossibilities(g.Rows[i].Cells[j].Possibilities);
                    Grid.Blocks[i].Cells[j].setPossibilities(g.Columns[i].Cells[j].Possibilities);
                    Grid.Columns[i].Cells[j].setPossibilities(g.Blocks[i].Cells[j].Possibilities);
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
            SetSessionStringIfNull(SessionKeyIsMinimum);
            SetSessionStringIfNull(SessionKeyIsValid);
            SetSessionStringIfNull(SessionKeySolved);
            SetSessionStringIfNull(SessionKeyIsNumber);
            SessionInfoSelectedI = HttpContext.Session.GetString(SessionKeySelectedI);
            SessionInfoSelectedJ = HttpContext.Session.GetString(SessionKeySelectedJ);
            SessionInfoIsMinimum = HttpContext.Session.GetString(SessionKeyIsMinimum);
            SessionInfoIsValid = HttpContext.Session.GetString(SessionKeyIsValid);
            SessionInfoSolved = HttpContext.Session.GetString(SessionKeySolved);
            SessionInfoIsNumber = HttpContext.Session.GetString(SessionKeyIsNumber);

        }

        private void SetSessionStringIfNull(string key)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(key)))
            {
                HttpContext.Session.SetString(key, "-");
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
            HttpContext.Session.Set(SessionKeySudokuGrid, Grid);
            HttpContext.Session.SetString(SessionKeyIsValid, IsValid.ToString());

            HttpContext.Session.SetString(SessionKeySolved, IsSolved.ToString());

            HttpContext.Session.SetString(SessionKeyIsMinimum, IsMinimum.ToString());

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
            HttpContext.Session.Set(SessionKeySudokuGrid, Grid);
            
            HttpContext.Session.SetString(SessionKeyIsValid, "-");
            HttpContext.Session.SetString(SessionKeySolved, "-");
            HttpContext.Session.SetString(SessionKeyIsMinimum, "-");
            HttpContext.Session.SetString(SessionKeyIsNumber, "-");
            return RedirectToPage();
            
        }

        public async Task<IActionResult> OnPostIsValidSudokuAsync()
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Is Valid Sudoku";
                return Page();
            }

            ResultInfo = "I will tell you if the Sudoku is Valid";
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

            var iString = i.ToString();
            var jString = j.ToString();


            GetGridCells();
            if(iString ==SessionInfoSelectedI && jString ==SessionInfoSelectedJ)
            {
                HttpContext.Session.SetString(SessionKeySelectedI, "-");
                HttpContext.Session.SetString(SessionKeySelectedJ, "-");
            }

            else
            {
                HttpContext.Session.SetString(SessionKeySelectedI, i.ToString());
                HttpContext.Session.SetString(SessionKeySelectedJ, j.ToString());
            }

            SerializeGrid();
           
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
            Grid.SetNumber(iNumber, jjNumber, num);
            HttpContext.Session.Set(SessionKeySudokuGrid, Grid);
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
            var isNumber = SessionInfoIsNumber;
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
    }
}
