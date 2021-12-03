using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesSudoku.SudokuSolver.CoreClasses;
using RazorPagesSudoku.SudokuSolver.Techniques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesSudoku
{
    public class SudokuModel : PageModel
    {
       
        [BindProperty]

        public int CellsToSolve { get; set; }

        [TempData]
        public string ResultInfo { get; set; }

        public string Message { get; set; }
        [BindProperty]
        public string CellSelection { get; set; }
        public string[] Cells = new[] { "Single Cell", "Multi Cell" };

        public AdvancedGrid  Grid{ get; set; }

        public bool IsSolved { get; set; }
        public bool IsMinimum { get; set; }
        public bool IsValid { get; set; }

        public bool IsTyped { get; set; }

        public bool IsAppliedTechniques { get; set; }

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

        //IsTyped

        public string SessionInfoIsTyped { get; private set; }
        public const string SessionKeyIsTyped= "_IsTyped";

        //IsMinimum

        public string SessionInfoIsMinimum { get; private set; }
        public const string SessionKeyIsMinimum = "_IsMinimum";


        //IsSolved
        public string SessionInfoSolved { get;  set; }
        public const string SessionKeySolved = "_IsSolved";

        //IsSolved
        public string SessionInfoTechniqueApplied { get; set; }
        public const string SessionKeyTechniqueApplied = "_IsTechniqueApplied";


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
            SetSessionStringIfNull(SessionKeyIsTyped);
            SetSessionStringIfNull(SessionKeySolved);
            SetSessionStringIfNull(SessionKeyIsNumber);
            SetSessionStringIfNull(SessionKeyTechniqueApplied);
            SessionInfoSelectedI = HttpContext.Session.GetString(SessionKeySelectedI);
            SessionInfoSelectedJ = HttpContext.Session.GetString(SessionKeySelectedJ);
            SessionInfoHighlightedCells = HttpContext.Session.GetString(SessionKeyHighlightedCells);
            SessionInfoIsMinimum = HttpContext.Session.GetString(SessionKeyIsMinimum);
            SessionInfoIsValid = HttpContext.Session.GetString(SessionKeyIsValid);
            SessionInfoIsTyped = HttpContext.Session.GetString(SessionKeyIsTyped);
            SessionInfoSolved = HttpContext.Session.GetString(SessionKeySolved);
            SessionInfoIsNumber = HttpContext.Session.GetString(SessionKeyIsNumber);
            SessionInfoTechniqueApplied = HttpContext.Session.GetString(SessionKeyTechniqueApplied);

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
                HttpContext.Session.SetString(SessionKeyIsTyped, "-");
                HttpContext.Session.SetString(SessionKeySolved, "-");
                HttpContext.Session.SetString(SessionKeyIsMinimum, "-");
                HttpContext.Session.SetString(SessionKeyIsNumber, "-");
                HttpContext.Session.SetString(SessionKeyTechniqueApplied, "-");
            }

            else
            {
                HttpContext.Session.Set(SessionKeySudokuGrid, Grid);
                HttpContext.Session.Set(SessionKeyTechniques, Techniques);
                HttpContext.Session.SetString(SessionKeyIsValid, IsValid.ToString());
                HttpContext.Session.SetString(SessionKeyIsTyped, IsTyped.ToString());
                HttpContext.Session.SetString(SessionKeySolved, IsSolved.ToString());
                HttpContext.Session.SetString(SessionKeyIsMinimum, IsMinimum.ToString());
                HttpContext.Session.SetString(SessionKeyTechniqueApplied, IsAppliedTechniques.ToString());

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


        public async Task<IActionResult> OnPostSolveSudokuAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }

            if (isTyped =="checked")
            {
                SaveTypedSudoku();
            }
            OnGet();
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
            OnGet();
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

        public async Task<IActionResult> OnPostLoadSudokuAsync()
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
{0,0,9,1,8,6,0,5,0},
{5,0,0,0,7,3,8,0,0,},
{8,6,0,9,5,0,1,3,0},
{0,7,2,6,3,5,9,1,0 },
{6,0,0,7,0,9,0,0,3},
{0,9,5,8,1,2,4,7,0},
{0,2,6,0,9,8,0,4,7},
{0,0,3,4,6,0,0,0,5},
{0,5,0,3,2,7,6,0,0}
};
            Solver s = new Solver(example);
            AdvancedGrid g = new AdvancedGrid(example);
            Grid = s.Grid;
            IsSolved = s.IsSolved;
            IsValid = g.IsValidOrIsCompleteSudoku(true);
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
            OnGet();
            
            AdvancedGrid g = new AdvancedGrid(Grid.SudokuGrid);
            Solver s = new Solver(g, CellsToSolve);
            s.SolveSudoku(CellsToSolve);
            IsAppliedTechniques = true;
            Grid = s.Grid;
            IsSolved = s.IsSolved;
            IsValid = s.IsValid;
            IsMinimum = s.IsMinimum;
            Techniques = s.Grid.Techniques;
            setSessionVariables(false);
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

        private void SaveTypedSudoku()
        {
            GetGridCells();
            SerializeGrid();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var idToAdd = "myInput;" + i + ";" + j;
                    var element = Request.Form[idToAdd];
                    string e = element.ToString();
                    if (e != "")
                    {
                        Grid.SetNumberRemovePossibilities(i, j, Convert.ToInt32(e), "");
                    }

                }
            }
            HttpContext.Session.Set(SessionKeySudokuGrid, Grid);
            SerializeGrid();
        }
        private void SaveTypedSudoku(string isTyped)
        {
            if(isTyped=="checked")
            {
                SaveTypedSudoku();
            }
            
            
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
                Grid.HighlightNumber(num, "showPossibilities");
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
                Grid.HighlightNumber(Convert.ToInt32(SessionInfoHighlightedCells), "showPossibilities");
            }
            
            HttpContext.Session.Set(SessionKeySudokuGrid, Grid); 
            AdvancedGrid g = new AdvancedGrid(Grid.SudokuGrid);
            g.findNextCell(iNumber, jjNumber, out int x, out int y);

            setSelectedCell(x, y);
            IsValid = g.IsValidOrIsCompleteSudoku(true);
            HttpContext.Session.SetString(SessionKeyIsValid, IsValid.ToString());
            // Highlight
            var iString = num.ToString();
            //var jString = j.ToString();
            OnGet();
            if (!IsValid)
            {
                Grid.HighlightError();
            }

            HttpContext.Session.Set(SessionKeySudokuGrid, Grid);
            return RedirectToPage();


        }

        public async Task<IActionResult> OnPostSetColourAsync(string className)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Select Number";
                return Page();
            }
            OnGet();
            var iNumber = Convert.ToInt32(SessionInfoSelectedI);
            var jjNumber = Convert.ToInt32(SessionInfoSelectedJ);
            Grid.Rows[iNumber].Cells[jjNumber].SetColour(className);
            HttpContext.Session.Set(SessionKeySudokuGrid, Grid);
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

            OnGet();
            var iNumber = Convert.ToInt32(SessionInfoSelectedI);
            var jjNumber = Convert.ToInt32(SessionInfoSelectedJ);

            var Poss = Grid.Rows[iNumber].Cells[jjNumber].Possibilities;
            var isPoss = Poss.Any(x => x == possibility);
            if (isPoss)
            {
                Grid.RemovePossibility(iNumber, jjNumber, possibility, "");
            }
            else

            {
                Grid.AddPossibility(iNumber, jjNumber, possibility, "");
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

            OnGet();
            var iNumber = Convert.ToInt32(SessionInfoSelectedI);
            var jjNumber = Convert.ToInt32(SessionInfoSelectedJ);
            Grid = HttpContext.Session.Get<AdvancedGrid>(SessionKeySudokuGrid);
            Grid.AddPossibility(iNumber, jjNumber, possibility, "");
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
            OnGet();
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

        public async Task<IActionResult> OnPostShowButtonsOrGridAsync()
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Select Number";
                return Page();
            }
            OnGet();
            if (SessionInfoIsTyped == "False" || SessionInfoIsTyped =="-")
            {
                HttpContext.Session.SetString(SessionKeyIsTyped, "True");
            }

            else
            {
                HttpContext.Session.SetString(SessionKeyIsTyped, "False");
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

        public async Task<IActionResult> OnPostSolveNakedSinglesAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.NakedSingleTechnique();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public void PostApplyTechniques(Technique t)
        {
            IsAppliedTechniques = true;
            Techniques = t.Grid.Techniques;
            Grid = t.Grid;
            IsValid = Grid.IsValidOrIsCompleteSudoku(true);
            setSessionVariables(false);
            HttpContext.Session.Set(SessionKeySudokuGrid, Grid);
        }

        public async Task<IActionResult> OnPostSolveHiddenSinglesAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.HiddenSingles();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveNakedPairsAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }

            if (isTyped == "checked")
            {
                SaveTypedSudoku();
            }
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.NakedPair();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveNakedQuadsAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            GetGridCells();
            SerializeGrid();
            Technique t = new Technique(Grid.SudokuGrid);
            t.NakedQuad();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveHiddenQuadsAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            GetGridCells();
            SerializeGrid();
            Technique t = new Technique(Grid.SudokuGrid);
            t.HiddenQuads();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveHiddenPairsAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            GetGridCells();
            SerializeGrid();
            Technique t = new Technique(Grid.SudokuGrid);
            t.HiddenPairTechnique();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveRemotePairAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.RemotePairTechnique();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolvePointingAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.Claiming();//Pointing is Claiming?
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveClaimingAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.Claiming();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveDoublePairAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.DoublePair();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveMultiLineAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.MultiLine();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveXWingAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.XWing();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveXYWingAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }

            if (isTyped == "checked")
            {
                SaveTypedSudoku();
            }
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.XYWing();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveXYZWingAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.XYZWing();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveXYChainAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.XYChain();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveColouringAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.Colouring();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveNakedTriplesAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.NakedTriple();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveHiddenTriplesAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.HiddenTriples();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveSwordfishAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.Swordfish();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveNishioAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.Nishio();
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveUniqueRectangleAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }
            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            PostApplyTechniques(t);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSolveBruteForceAsync(string isTyped)
        {
            if (!ModelState.IsValid)
            {
                await Task.CompletedTask;
                ResultInfo = "Invalid Sudoku Solve";
                return Page();
            }

            SaveTypedSudoku(isTyped);
            OnGet();
            Technique t = new Technique(Grid.SudokuGrid);
            t.SolveBruteForce();
            PostApplyTechniques(t);
            return RedirectToPage();
        }
    }
}
