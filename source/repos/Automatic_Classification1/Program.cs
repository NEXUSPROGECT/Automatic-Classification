using System;
using System.Collections.Generic;
using Accord.Math;
using Accord.MachineLearning;
using Accord.Statistics;

namespace Automatic_Classification
{
    class Program
    {
        static void Main()
        {
            int[,] matrix = {
            {9, 6, 7, 2, 10},
            {6, 7, 2, 3, 40},
            {3, 2, 3, 7, 80},
            {8, 5, 9, 2, 20},
            {4, 4, 6, 9, 80},
            {10, 4, 8, 2,10},
            {7, 9, 3, 6, 50},
            {5, 8, 1, 6, 40},
            {5, 3, 6, 8, 90}
            };

            int[][] newObjects = new int[][]
            {
            new int[] { 4, 4, 4, 9 },
            new int[] { 8, 8, 1, 5 },
            new int[] { 8, 4, 7, 3 }
            };

            //ДЕЛЕНИЕ НА КЛАССЫ
            int[][] classes = DistByClass.DivideMatrix(matrix, newObjects.Length);

            //ВЫЧИСЛЕНИЕ КООРДИНАТ ЦЕНТРОВ ТЯЖЕСТИ КЛАССОВ
            double[][] centroids = CalculateCentr.CalculateClassCenters(matrix, classes);

            //МЕТОД 1: АЛГОРИТМ КЛАССИФИКАЦИИ ПО РАССТОЯНИЮ ОТ ОБЪЕКТОВ ДО ЦЕНТРОВ ТЯЖЕСТИ КЛАССОВ
            Method1.ClassifyObjects(newObjects, centroids);

        }
    }
}

