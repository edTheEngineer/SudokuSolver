using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RazorPagesSudoku.SudokuSolver.CoreClasses
{
    public static class Serialize
    {
        public static string ToJson(this AdvancedGrid self)
        {
            return JsonConvert.SerializeObject(self, Converter.Settings);
        }
    }
}
