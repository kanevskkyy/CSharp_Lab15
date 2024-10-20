using System;

class Task
{
    static void Main()
    {
        string path = "text.txt";
        string[] strings = File.ReadAllLines(path);
        string[] result = new string[10];
        for(int i = 0; i < strings.Length; i++)
        {
            int lettersAmount = 0, symbolsAmount = 0;
            for(int j = 0; j < strings[i].Length; j++)
            {
                if (char.IsLetter(strings[i][j])) lettersAmount++;
                else if(strings[i][j] == '-' || strings[i][j] == ',' || strings[i][j] == '`' || strings[i][j] == '.' || strings[i][j] == '?' || strings[i][j] == '!') symbolsAmount++;
            }
            result[i] = $"Line {i + 1}: ";
            result[i] += strings[i] + $"({lettersAmount})({symbolsAmount})";
        }
        File.WriteAllLines("result.txt", result);
    }
    public static void Line()
    {
        Console.WriteLine("=======================================");
    }
}