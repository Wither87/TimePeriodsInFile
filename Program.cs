using System;
using System.Collections.Generic;
using System.IO;

namespace TimeSum
{
    class Program
    {
        static string[] GetArrayOfFile(string path)
        {
            string timeInFile = File.ReadAllText(path);
            string[] array = timeInFile.Split(' ');
            return array;
        }

        static int[] GetArraysWithJobtime(string[] array, out int[] endJobArray)
        {
            List<int> startJob = new List<int>();
            List<int> endJob = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                string[] time = array[i].Split(':');
                if (i % 2 == 0)
                    startJob.Add((int.Parse(time[0]) * 60) + int.Parse(time[1]));

                else
                    endJob.Add((int.Parse(time[0]) * 60) + int.Parse(time[1]));
            }
            endJobArray = endJob.ToArray();
            return startJob.ToArray();
        }
        static int GetAllJobtime(int[] startJob, int[] endJob)
        {
            int allTime = 0;
            for (int i = 0; i < startJob.Length; i++)
            {
                allTime += endJob[i] - startJob[i];
            }
            return allTime;
        }

        static void Main()
        {
            string path = "../../../TimeINJob3.txt";
            var array = GetArrayOfFile(path);
            int[] startJob = GetArraysWithJobtime(array, out int[] endJob);

            int allTime = GetAllJobtime(startJob, endJob);

            if (allTime / 60 > 8) Console.WriteLine($"Дурак... Проработал {(int)allTime / 60} часов");
            else if (allTime / 60 == 8) Console.WriteLine($"Молодец! Проработал ровно 8 часов");
            else Console.WriteLine($"Ленивец. Проработал {(int)allTime / 60} часов");
        }
    }
}
