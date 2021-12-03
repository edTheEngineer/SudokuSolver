using System;
using System.Collections;
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

          public bool NextPermutation(int[] numList)
    {
        /*
         Knuths
         1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
         2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
         3. Swap a[j] with a[l].
         4. Reverse the sequence from a[j + 1] up to and including the final element a[n].

         */
        var largestIndex = -1;
        for (var i = numList.Length - 2; i >= 0; i--)
        {
            if (numList[i] < numList[i + 1]) {
                largestIndex = i;
                break;
            }
        }

        if (largestIndex < 0) return false;

        var largestIndex2 = -1;
        for (var i = numList.Length - 1 ; i >= 0; i--) {
            if (numList[largestIndex] < numList[i]) {
                largestIndex2 = i;
                break;
            }
        }

        var tmp = numList[largestIndex];
        numList[largestIndex] = numList[largestIndex2];
        numList[largestIndex2] = tmp;

        for (int i = largestIndex + 1, j = numList.Length - 1; i < j; i++, j--) {
            tmp = numList[i];
            numList[i] = numList[j];
            numList[j] = tmp;
        }

        return true;
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

        public List<string> FindRemotePairChain2(List<string> listIn)

        {
            var words = CreateSudokuChain2(new List<string>(), new List<string>(), listIn);
            words.Sort((a, b) => a.Length.CompareTo(b.Length));
            words.Reverse();
            var query = from w in words
                        //where w.Length >= 6
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

        public static void RotateRight(IList sequence, int count)
        {
            object tmp = sequence[count - 1];
            sequence.RemoveAt(count - 1);
            sequence.Insert(0, tmp);
        }

        public static IEnumerable<IList> Permutate(IList sequence, int count)
        {
            if (count == 1) yield return sequence;
            else
            {
                for (int i = 0; i < count; i++)
                {
                    foreach (var perm in Permutate(sequence, count - 1))
                        yield return perm;
                    RotateRight(sequence, count);
                }
            }
        }
       public  void PermutateIntegersTest()
        {
            List<int> seq = new List<int>() { 1, 2, 3, 4 ,5,6,7,8, 9,10,11,12,13,14,15,16,17,18,19,20};
            foreach (var permu in Permutate(seq, seq.Count))
            {
                foreach (var i in permu)
                    Console.Write(i.ToString() + " ");
                Console.WriteLine();
            }
        }
        public List<string> CreateSudokuChain2(List<string> trueAnswer, List<string> answerChain, List<string> sourceList)
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
                    CreateSudokuChain2(trueAnswer, answerChain, sourceList); //repeat
                    sourceList.Insert(i, check); //add back to list //After sudoku chain
                    answerChain.RemoveAt(answerChain.Count - 1); //remove chain
                }
            }

            return trueAnswer;
        }

        public bool CanAppend2(List<string> chain, string coOrdindateToAdd)
        {
            if(chain.Count ==5)
            {
                return false;
            }
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
