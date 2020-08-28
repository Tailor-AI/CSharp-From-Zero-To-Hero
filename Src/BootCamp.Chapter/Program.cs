using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
            string corruptFile = GetPathToCorruptFile(GetPathToWorkFolder());
            string cleanedFile = GetPathToCleanedFile(GetPathToWorkFolder());
            FileCleaner.Clean(corruptFile, cleanedFile);
            // - FindHighestBalanceEver
            Console.WriteLine(TextTable.Build(BalanceStats.FindHighestBalanceEver(FileCleaner.AccountArray), 3));
            // - FindPersonWithBiggestLoss
            Console.WriteLine(TextTable.Build(BalanceStats.FindPersonWithBiggestLoss(FileCleaner.AccountArray), 3));
            // - FindRichestPerson
            Console.WriteLine(TextTable.Build(BalanceStats.FindRichestPerson(FileCleaner.AccountArray), 3));
            // - FindMostPoorPerson
            Console.WriteLine(TextTable.Build(BalanceStats.FindMostPoorPerson(FileCleaner.AccountArray), 3));
        }
        static string GetPathToWorkFolder()
        {
            string path = Directory.GetCurrentDirectory();
            for (int i = 0; i < 3; i++)
            {
                path = Directory.GetParent(path).ToString();
            }
            return path;
        }
        static string GetPathToCorruptFile(string pathToWorkFolder)
        {
            return (pathToWorkFolder + string.Format(@"\Input\Balances.corrupted"));
        }
        static string GetPathToCleanedFile(string pathToWorkFolder)
        {
            return (pathToWorkFolder + string.Format(@"\Input\BalancesClean.txt"));
        }
    }
}
