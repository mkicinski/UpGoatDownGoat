﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace UpGoatDownGoat
{
    class Program
    {
        /// <summary>
        /// Main entry point
        /// </summary>
        static void Main()
        {
            // Get image locations
            List<string> filePaths = System.IO.Directory.GetFiles("../../Resources").ToList();

            // Randomize image order
            filePaths.Shuffle();

            // Run Algorithm on each goat and print results
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Extensions.PrintResults(filePaths, filePaths.Select(AnalyzeGoat).ToList());
            stopWatch.Stop();
            Console.WriteLine("TIME: " + stopWatch.ElapsedMilliseconds + " ms");
            Console.WriteLine();
            Console.WriteLine("press and key to quit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Returns "Up" or "Down" based on the orientation of the goat in the given file path
        /// </summary>
        /// <param name="goatFilePath"></param>
        static string AnalyzeGoat(string goatFilePath)
        {
            string upOrDown = "";
            
            // Bitmap could be useful!
            //Bitmap bitmap = new Bitmap(goatFilePath); 
            //Color pixelColor = bitmap.GetPixel(0, 0); // R, G, B, A
            //float pixelHue = pixelColor.GetHue(); // Brightness, Stauration




            //************************************************************************
            //************************************************************************ 
            //                        YOUR CODE GOES HERE
            //************************************************************************
            //************************************************************************




            // Return either "Up" or "Down"
            return upOrDown;
        }
    }

    static class Extensions
    {
        private static Random rnd = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void PrintResults(List<string> source, List<string> answers)
        {
            // Yes the answers are here and yes they are in the file name...
            // But cheating is easy
            int correctCount = 0;
            Console.OutputEncoding = Encoding.Unicode;
            for (int i = 0; i < source.Count; i++)
            {
                bool correct = false;
                if ((answers[i].ToUpper() == "UP" || answers[i].ToUpper() == "DOWN") && 
                    source[i].ToUpper().Contains(answers[i].ToUpper()))
                {
                    correctCount++;
                    correct = true;
                }
                Console.WriteLine((correct ? ("\u2713" + " CORRECT:  ") : "X INCORRECT:") + "     Image: " + source[i].Split('\\').Last() + "     Your Answer: " + answers[i]);
            }
            Console.WriteLine();
            Console.WriteLine("SCORE: " + 100.0*((Double)correctCount/(Double)source.Count) + "%");
        }
    }
}
