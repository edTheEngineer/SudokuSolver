using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RazorPagesSudoku.SudokuSolver.CoreClasses;



using System.Text.Json;

namespace RazorPagesSudoku
{
    public static class SessionExtensions
    {

        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, "");
            var jsonIn = JsonConvert.SerializeObject(value, Converter.Settings);
            session.SetString(key, jsonIn);
        }



        public static T Get<T>(this ISession session, string key)
        {
            var nameOfKey = session.GetString(key);
            if(nameOfKey==null)
            {
                return default;
            }
            return JsonConvert.DeserializeObject<T>(nameOfKey, Converter.Settings); //Just need Converter.Settings
            
        }

        public static AdvancedGrid getA (this ISession session, string key)
        {
            var nameOfKey = session.GetString(key);
            if (nameOfKey == null)
            {
                return default;
            }
            AdvancedGrid g = new AdvancedGrid();
            JsonConvert.PopulateObject(nameOfKey, g, Converter.Settings); //Just need Converter.Settings
            return g;

        }



        /* public static AdvancedGrid Get2(this ISession session, string key)
         {
             var nameOfKey = session.GetString(key);
             if (nameOfKey == null)
             {
                 return default;
             }
             var advancedGrid = AdvancedGrid.FromJson(nameOfKey);

             return advancedGrid;
         }

         */
        //
        //    v
    }
}
