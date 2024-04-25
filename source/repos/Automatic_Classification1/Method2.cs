using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Classification
{
    internal class Method2
    {
        static void ClassifyNewObjectsWithWeights(int[][] newObjects, int[][] classes, double[] weights)
        {
            for (int i = 0; i < newObjects.Length; i++)
            {
                int[] currentObject = newObjects[i];
                double minDistance = double.MaxValue;
                int minClassIndex = -1;

                for (int j = 0; j < classes.Length; j++)
                {
                    double distance = CalculateDistanceWithWeights(currentObject, GetClassCenter(classes[j]), weights);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        minClassIndex = j;
                    }
                }

                Console.WriteLine($"Object {i + 1} belongs to class {minClassIndex + 1} with distance {minDistance}");
            }
        }

        static double CalculateDistanceWithWeights(int[] object1, int[] object2, double[] weights)
        {
            double sum = 0;
            for (int i = 0; i < object1.Length; i++)
            {
                sum += weights[i] * Math.Pow(object1[i] - object2[i], 2);
            }
            return Math.Sqrt(sum);
        }

        static int[] GetClassCenter(int[] classObjects)
        {
            int[] center = new int[classObjects.Length - 1]; // Игнорируем последний элемент, так как он номер строки
            for (int i = 0; i < center.Length; i++)
            {
                center[i] = classObjects[i];
            }
            return center;
        }
    }
}
