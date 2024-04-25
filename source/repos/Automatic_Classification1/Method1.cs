using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Classification
{
    internal class Method1
    {
        // Функция для вычисления расстояния между двумя точками
        //static double Distance(double[] point1, double[] point2)
        //{
        //    if (point1.Length != point2.Length)
        //    {
        //       //throw new ArgumentException("Points must have the same dimensionality");
        //    }

        //    double sum = 0.0;
        //    for (int i = 0; i < point1.Length; i++)
        //    {
        //        sum += Math.Pow(point1[i] - point2[i], 2);
        //    }
        //    return Math.Sqrt(sum);
        //}

        //// Функция для классификации объектов
        //public static int[] Classify(double[][] centroids, double[][] objects)
        //{
        //    int[] classifications = new int[objects.Length];

        //    for (int i = 0; i < objects.Length; i++)
        //    {
        //        double minDistance = double.MaxValue;
        //        int closestCentroidIndex = -1;

        //        for (int j = 0; j < centroids.Length; j++)
        //        {
        //            double distance = Distance(centroids[j], objects[i]);
        //            if (distance < minDistance)
        //            {
        //                minDistance = distance;
        //                closestCentroidIndex = j;
        //            }
        //        }

        //        classifications[i] = closestCentroidIndex;
        //    }
        //    Console.WriteLine("Classification Results:");
        //    for (int i = 0; i < classifications.Length; i++)
        //    {
        //        Console.WriteLine($"Object {i + 1} belongs to class {classifications[i] + 1}");
        //    }


        //    return classifications;







        public static void ClassifyObjects(int[][] newObjects, double[][] classCenters)
        {
            Console.WriteLine("\n\n\n..МЕТОД 1: АЛГОРИТМ КЛАССИФИКАЦИИ ПО РАССТОЯНИЮ ОТ ОБЪЕКТОВ ДО ЦЕНТРОВ ТЯЖЕСТИ КЛАССОВ..");
            foreach (var newObject in newObjects)
            {
                int nearestClassIndex = FindNearestClassIndex(newObject, classCenters);
                Console.WriteLine($"Новый объект: {string.Join(", ", newObject)} принадлежит к классу №{nearestClassIndex + 1}");
            }
        }

        static int FindNearestClassIndex(int[] newObject, double[][] classCenters)
        {
            double minDistance = double.MaxValue;
            int nearestClassIndex = -1;

            for (int i = 0; i < classCenters.Length; i++)
            {
                double distance = CalculateDistance(newObject, classCenters[i]);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestClassIndex = i;
                }
            }

            return nearestClassIndex;
        }

        static double CalculateDistance(int[] object1, double[] object2)
        {
            // Проверяем, что размеры массивов совпадают
            if (object1.Length != object2.Length)
            {
                throw new ArgumentException("Arrays must be of equal length");
            }

            double sum = 0;
            for (int i = 0; i < object1.Length; i++)
            {
                sum += Math.Pow(object1[i] - object2[i], 2);
            }
            return Math.Sqrt(sum);
        }
    }
}
