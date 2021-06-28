using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RazorPagesSudoku.SudokuSolver.CoreClasses
{


    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings //Class With Settings
        {
            
             ObjectCreationHandling = ObjectCreationHandling.Replace,
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore, //Ignores Metadata
            DateParseHandling = DateParseHandling.None, //No Parsing for Data
            Converters = //Allows Universal Parsing of Dates
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}


