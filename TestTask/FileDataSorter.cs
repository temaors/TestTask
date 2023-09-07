namespace TestTask;

public class FileDataSorter
{
    public string InputFilePath { get; set; }
    public string OutputFilePath { get; set; }
    private List<List<string>> Data { get; set; }

    public FileDataSorter(string inputFilePath, string outputFilePath)
    {
        InputFilePath = inputFilePath;
        OutputFilePath = outputFilePath;
        Data = new List<List<string>>();
    }

    public void ReadDataFromFile()
    {
        List<string> lines = new List<string>(File.ReadAllLines(InputFilePath));
        foreach (var line in lines)
        {
            Data.Add(new List<string>(line.Split('\t')));
        }
    }

    public void SortData()
    {
        double number1;
        double number2;
        bool isNumber1;
        bool isNumber2;
        
        Data.Sort((list1, list2) =>
        {
            for (int i = 0; i < Math.Min(list1.Count, list2.Count); i++)
            {
                isNumber1 = double.TryParse(list1[i], out number1);
                isNumber2 = double.TryParse(list2[i], out number2);

                if (isNumber1 && isNumber2)
                {
                    int comparison = number1.CompareTo(number2);
                    if (comparison != 0)
                        return comparison;
                }
                else if (isNumber1)
                {
                    return -1;
                }
                else if (isNumber2)
                {
                    return 1;
                }
                else
                {
                    int comparison = String.CompareOrdinal(list1[i], list2[i]);
                    if (comparison != 0)
                        return comparison;
                }
            }

            return list1.Count.CompareTo(list2.Count);
        });
    }

    public void WriteDataToFile()
    {
        File.WriteAllLines(OutputFilePath, Data.Select(list => string.Join("\t", list)));
    }
}