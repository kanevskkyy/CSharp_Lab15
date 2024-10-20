using System;

class Task
{
    static void Main()
    {
        using (StreamReader streamReader = new StreamReader("text.txt"))
        {
            string line = streamReader.ReadToEnd();
            string[] strings = line.Split('\n');

            for (int i = 0; i < strings.Length; i++)
            {
                if (i % 2 == 0)
                {
                    strings[i] = strings[i].Replace('-', '@');
                    strings[i] = strings[i].Replace(',', '@');
                    strings[i] = strings[i].Replace('.', '@');
                    strings[i] = strings[i].Replace('!', '@');
                    strings[i] = strings[i].Replace('?', '@');
                    string[] result = strings[i].Split();
                    for(int j = result.Length - 1; j >= 0; j--)
                    {
                        Console.Write(result[j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
    public static void Line()
    {
        Console.WriteLine("=======================================");
    }
}