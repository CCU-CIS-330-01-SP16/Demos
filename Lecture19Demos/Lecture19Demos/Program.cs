using System;
using System.Text.RegularExpressions;

namespace Lecture19Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Regex.Match("color", @"colou?r").Success);

            Console.WriteLine(Regex.Match("say 25 miles more", @"\d+(?=\smiles)"));

            Console.WriteLine(Regex.Match("say 25 miles more", @"(?<=say\s)\d+"));

            ExamDemo();
        }

        private static void ExamDemo()
        {
            BaseLogger logger = new Logger();
            logger.Log("Log started");
            logger.Log("Base: Log continuing");
            ((Logger)logger).LogCompleted();
        }
    }
}
