using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Classification
{
    internal class DistByClass
    {
        public static int[][] DivideMatrix(int[,] matrix, int newObjectsCount)
        {
            // Находим максимальное число в последнем столбце
            int maxLastColumn = matrix[0, matrix.GetLength(1) - 1];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                int currentNumber = matrix[i, matrix.GetLength(1) - 1];
                if (currentNumber > maxLastColumn)
                {
                    maxLastColumn = currentNumber;
                }
            }

            // Рассчитываем размер класса
            double classSize = (double)maxLastColumn / newObjectsCount;

            // Создаем классы
            int[][] classes = new int[newObjectsCount][];
            for (int i = 0; i < newObjectsCount; i++)
            {
                classes[i] = new int[matrix.GetLength(0)];
            }

            // Распределяем объекты по классам
            int[] rowNumbers = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int rowValue = matrix[i, matrix.GetLength(1) - 1];
                rowNumbers[i] = i + 1; // Сохраняем номер строки
                int classIndex = (int)Math.Floor(rowValue / classSize);
                if (classIndex >= newObjectsCount)
                {
                    classIndex = newObjectsCount - 1;
                }
                classes[classIndex][i] = rowValue;
            }

            Console.WriteLine("......РАСПРЕДЕЛЕНИЕ НА КЛАССЫ......");
            List<int[]> clas = new List<int[]>();
            for (int i = 0; i < newObjectsCount; i++)
            {
                List<int> b = new List<int>();
                Console.WriteLine($"Класс {i + 1}:");
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (classes[i][j] != 0)
                    {
                        b.Add(j+1);
                        Console.WriteLine($"Строка {j + 1}: {classes[i][j]}");
                    }
                }
                clas.Add(b.ToArray());
                Console.WriteLine();
            }
            int[][] cla = clas.ToArray();


            Console.WriteLine("Итоговые классы:");
            for (int i = 0; i < cla.Length; i++)
            {
                Console.Write("Класс №" + (i+1) + ": ");
                int[] b = cla[i];
                for (int j = 0; j < b.Length; j++)
                {
                    Console.Write(b[j] + " ");
                }
                Console.WriteLine();
            }
            return cla;
        }
    }
}
