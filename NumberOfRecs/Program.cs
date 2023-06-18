using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace AlgorithmTraining
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.GetNumberOfWaysToGetSameSum(new int[][] { new int[] { 1, 1, -2 }, new int[] { 3, 2, 4 }, new int[] { -1, -2, -2 } }));
            Console.ReadLine();
        }
        public int GetNumberOfWaysToGetSameSum(int[][] N)
        {
            int WayCount = 0;
            int ColumnCount = 0;
            int RowCount = 0;
            decimal sum = 0;

            foreach (int[] n in N)
            {
                RowCount++;
                foreach (int p in n)
                {
                    ColumnCount++;
                    sum = sum + p;
                }
            }

            ColumnCount = ColumnCount / RowCount;

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    int innerColumnCount = 1;
                there:
                    int innerRowCount = 1;
                here:
                    decimal totalSum = 0;

                    for (int a = i; a < innerRowCount + i; a++)
                    {
                        for (int b = j; b < innerColumnCount + j; b++)
                        {
                            totalSum = totalSum + N[a][b];
                            if (totalSum == sum / 2 && b == innerColumnCount + j - 1 && a == innerRowCount + i - 1)
                            {
                                WayCount++;
                            }
                        }
                    }

                    if (innerRowCount < RowCount - i)
                    {
                        innerRowCount++;
                        goto here;
                    }

                    if (innerRowCount == RowCount - i)
                    {
                        if (innerColumnCount == ColumnCount - j) goto end;
                        innerColumnCount++;
                        goto there;
                    }
                end:;
                }
            }

            return WayCount;
        }
    }
}