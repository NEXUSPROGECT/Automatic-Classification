using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Classification
{
    internal class CalculateCentr
    {
        public static double[][] CalculateClassCenters(int[,] matrix, int[][] classRows)
        {
            int numFeatures = matrix.GetLength(1) - 1; // Игнорируем последний столбец, так как он номер строки
            int numClasses = classRows.Length;
            double[][] classCenters = new double[numClasses][];

            for (int i = 0; i < numClasses; i++)
            {
                int[] rows = classRows[i];
                classCenters[i] = new double[numFeatures];

                // Инициализируем сумму каждого столбца для текущего класса
                double[] sum = new double[numFeatures];

                // Подсчитываем сумму каждого столбца для текущего класса
                foreach (int rowIndex in rows)
                {
                    if (rowIndex - 1 < 0 || rowIndex - 1 >= matrix.GetLength(0)) // учтем, что индексы строк начинаются с 1
                    {
                        throw new ArgumentOutOfRangeException(nameof(rowIndex), "Index was outside the bounds of the array");
                    }

                    for (int j = 0; j < numFeatures; j++)
                    {
                        if (j < 0 || j >= matrix.GetLength(1) - 1) // Игнорируем последний столбец
                        {
                            throw new ArgumentOutOfRangeException(nameof(j), "Index was outside the bounds of the array");
                        }

                        sum[j] += matrix[rowIndex - 1, j]; // учтем, что индексы строк начинаются с 1
                    }
                }

                // Вычисляем среднее значение для каждого столбца текущего класса
                for (int j = 0; j < numFeatures; j++)
                {
                    classCenters[i][j] = sum[j] / rows.Length;
                }
            }

            Console.WriteLine("\n\n\n.....ВЫЧИСЛЕНИЕ КООРДИНАТ ЦЕНТРОВ ТЯЖЕСТИ КЛАССОВ......");
            Console.WriteLine("Центры тяжести классов");
            for (int i = 0; i < classCenters.Length; i++)
            {
                double[] b = classCenters[i];
                for (int j = 0; j < b.Length; j++)
                {
                    Console.Write(b[j] + " ");
                }
                Console.WriteLine();
            }

            return classCenters;
        }
    }
}
