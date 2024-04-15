using System;
using System.Collections.Generic;
using Accord.Math;
using Accord.MachineLearning;

namespace Automatic_Classification
{
    class Program
    {
        static void Main()
        {
            // Пример исходной матрицы
            double[][] data = new double[][]
            {
            new double[] {9, 6, 7, 2, 10},
            new double[] {6, 7, 2, 3, 40},
            new double[] {3, 2, 3, 7, 80},
            new double[] {8, 5, 9, 2, 20},
            new double[] {4, 4, 6, 9, 80},
            new double[] {10, 4, 6, 9, 10},
            new double[] {7, 9, 3, 6, 50},
            new double[] {5, 8, 1, 6, 40},
            new double[] {5, 3, 6, 8, 90}
            };

            // Пример новых объектов
            double[][] newObjects = new double[][]
            {
            new double[] {4, 4, 4, 9},
            new double[] {8, 8, 1, 5},
            new double[] {8, 4, 7, 3}
            };

            // Выполнение кластеризации методом k-средних
            KMeans kmeans = new KMeans(k: 3);
            int[] labels = kmeans.Compute(data);

            // Вывод классов для исходных данных
            Console.WriteLine("Классы для исходных данных:");
            for (int i = 0; i < labels.Length; i++)
            {
                Console.WriteLine($"Объект {i + 1}: Класс {labels[i] + 1}");
            }
            Console.WriteLine();

            // Вычисление центров тяжести классов
            double[][] centroids = kmeans.Centroids;

            // Классификация новых объектов
            Console.WriteLine("Классификация новых объектов:");
            foreach (var newObj in newObjects)
            {
                int predictedClass = ClassifyWithCentroids(newObj, centroids);
                Console.WriteLine($"Новый объект: Класс {predictedClass + 1}");
            }
        }

        // Функция для классификации новых объектов на основе центров тяжести классов
        static int ClassifyWithCentroids(double[] newObject, double[][] centroids)
        {
            double minDistance = double.MaxValue;
            int predictedClass = -1;

            for (int i = 0; i < centroids.GetLength(0); i++)
            {
                double distance = DistanceI(newObject, centroids[i]);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    predictedClass = i;
                }
            }

            return predictedClass;
        }

        // Функция для вычисления евклидова расстояния между двумя точками
        static double DistanceI(double[] point1, double[] point2)
        {
            return Distance.Euclidean(point1, point2);
        }
    }
}

