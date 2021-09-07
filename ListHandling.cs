using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesSudoku.SudokuSolver.CoreClasses;

namespace RazorPagesSudoku
{
    public class ListHandling
    {
        public void SplitRemoteChainList(List<string> remotePair, out List<string> odd, out List<string> even)
        {
            odd = new List<string>();
            even = new List<string>();

            for(int i = 0; i<remotePair.Count; i++)
            {
                if(i%2==0)
                {
                   even.Add(remotePair[i]);
                }

                else
                {
                    odd.Add(remotePair[i]);
                }
            }
        }
        public List<string> FindRemotePairChain(List<string> listIn)

        {
            var words = CreateSudokuChain(new List<string>(), new List<string>(), listIn);
            words.Sort((a, b) => a.Length.CompareTo(b.Length));
            words.Reverse();
            var query = from w in words
                        where w.Length >= 15
                        select w;

            List<string> final = query.ToList();

            
            return final;

        }
    
       public void GetRowColumnBlock(string coordinate, out int row, out int col, out int block)
        {
            row = 0;
            col = 0;
            block = 0;

            AdvancedGrid g = new AdvancedGrid();
            g.SplitTextCoordinate(coordinate, out int x, out int y);
            block = g.GetBlockFromCoOrdinates(x, y);
            row = x;
            col = y;
        }

     
        public List<string> CreateSudokuChain(List<string> trueAnswer, List<string> answerChain, List<string> sourceList)
        {
            for (int i = 0; i < sourceList.Count; i++)
            {
                var check = sourceList[i];
                if (CanAppend(answerChain, check))
                {
                    answerChain.Add(check);
                    var answer = string.Join("-", answerChain); //adds to list, and
                    trueAnswer.Add(answer);
                    sourceList.RemoveAt(i); //remove  list
                    CreateSudokuChain(trueAnswer, answerChain, sourceList); //repeat
                    sourceList.Insert(i, check); //add back to list //After sudoku chain
                    answerChain.RemoveAt(answerChain.Count - 1); //remove chain
                }
            }

            return trueAnswer;
        }

        public bool CanAppend(List<string> chain, string coOrdindateToAdd)
        {
            AdvancedGrid g = new AdvancedGrid();

            if (chain == null)
            {
                return true;

            }

            if (chain.Count == 0)
            {
                return true;
            }

            var lastCoordinate = chain.Last();

            GetRowColumnBlock(coOrdindateToAdd, out int firstRow, out int firstCol, out int firstBlock);
            GetRowColumnBlock(lastCoordinate, out int lastRow, out int lastCol, out int lastBlock);

            
            if (firstRow == lastRow)
            {
                return true;
            }


            if (firstCol == lastCol)
            {
                return true;
            }

            if (firstBlock == lastBlock)
            {
                return true;
            }
            return false;

        }
    }

    

}
