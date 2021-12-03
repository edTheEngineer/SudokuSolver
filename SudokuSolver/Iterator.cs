using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace RazorPagesSudoku.SudokuSolver
{
    public class Iterator
    { 
            public static void RotateRight<T>(IList<T> sequence, int count)
            {
                T tmp = sequence[count - 1];
                sequence.RemoveAt(count - 1);
                sequence.Insert(0, tmp);
            }

            private static void RotateLeft<T>(IList<T> sequence, int start, int count)
            {
                T tmp = sequence[start];
                sequence.RemoveAt(start);
                sequence.Insert(start + count - 1, tmp);
            }

            public static IEnumerable<IList<T>> Permutations<T>(IList<T> sequence, int count)
            {
                if (count == 1) yield return sequence;
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        foreach (var perm in Permutations(sequence, count - 1))
                            yield return perm;
                        RotateRight(sequence, count);
                    }
                }
            }

            public static IEnumerable<IList<T>> Permutations<T>(IList<T> sequence)
            {
                return Permutations(sequence, sequence.Count);
            }

            public static IEnumerable<IList<T>> Combinations<T>(IList<T> sequence, int start, int count, int choose)
            {
                if (choose == 0) yield return sequence;
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        foreach (var perm in Combinations(sequence, start + 1, count - 1 - i, choose - 1))
                            yield return perm;
                        RotateLeft(sequence, start, count);
                    }
                }
            }

            public static IEnumerable<IList<T>> Combinations<T>(IList<T> sequence, int choose)
            {
                return Combinations(sequence, 0, sequence.Count, choose);
            }
        }
    }
