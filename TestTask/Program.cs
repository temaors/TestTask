using System.Globalization;

namespace TestTask;

class Program
{
    static void Main()
    {
        CultureInfo.CurrentCulture = new CultureInfo("en");
        
        string? inputFilePath = GetInputFilePath();
        if (IsFilePathCorrect(inputFilePath))
        {
            string? outputFilePath = GetOutputFilePath();
            if (IsFilePathCorrect(outputFilePath))
            {
                FileDataSorter fileDataSorter = new FileDataSorter(inputFilePath, outputFilePath);
                fileDataSorter.ReadDataFromFile();

                fileDataSorter.SortData();

                fileDataSorter.WriteDataToFile();
            }
        }
    }

    static string? GetInputFilePath()
    {
        Console.WriteLine("Введите путь к исходному файлу:");
        return Console.ReadLine();
    }

    static string? GetOutputFilePath()
    {
        Console.WriteLine("Введите путь к конечному файлу:");
        return Console.ReadLine();
    }

    static bool IsFilePathCorrect(string? path)
    {
        if (path == null || !File.Exists(path))
        {
            Console.WriteLine("Файл не сущесвтует");
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