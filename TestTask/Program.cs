using System.Globalization;

namespace TestTask;

class Program
{
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("en");
        if (IsConsoleArgsFilled(args))
        {
            if (IsFilePathCorrect(args[0]) && IsFilePathCorrect(args[1]))
            {
                FileDataSorter fileDataSorter = new FileDataSorter(args[0], args[1]);
                fileDataSorter.ReadDataFromFile();

                fileDataSorter.SortData();

                fileDataSorter.WriteDataToFile();
            }
        }
    }

    static bool IsConsoleArgsFilled(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Введите пути к входному и выходному файлу");
            return false;
        }

        return true;
    }

    static bool IsFilePathCorrect(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine($"Файл {path} не сущесвтует");
            return false;
        }
        if (!path.EndsWith(".txt"))
        {
            Console.WriteLine("Введите путь к файлу с расширением .txt");
            return false;
        }
        return true;
    }
}