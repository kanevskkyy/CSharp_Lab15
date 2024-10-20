using System;
using System.IO;

class Task
{
    static void Main()
    {
        string[] comparedWords = File.ReadAllLines("words.txt");
        string[] strings = File.ReadAllLines("text.txt");
        
        int[] frequenty = new int[comparedWords.Length];
        int counter = 0;
        foreach (string comparedWord in comparedWords)
        {
            int wordCounter = 0;
            foreach (string line in strings)
            {
                string replcaedString = line.Replace('-', ' ').Replace(',', ' ').Replace('.', ' ').Replace('?', ' ').Replace('!', ' ').ToLower(); 
                string[] result = replcaedString.Split();
                foreach (string word in result)
                {
                    if (comparedWord.ToLower() == word) wordCounter++;
                }
            }
            frequenty[counter] = wordCounter;
            counter++;
        }

        for (int i = 0; i < frequenty.Length; i++) 
        {
            for (int j = i + 1; j < frequenty.Length; j++) 
            {
                if (frequenty[i] > frequenty[j])
                {
                    int temp = frequenty[i];
                    frequenty[i] = frequenty[j];
                    frequenty[j] = temp;

                    string tempString = comparedWords[i];
                    comparedWords[i] = comparedWords[j];
                    comparedWords[j] = tempString;
                }
            }
        }
        string[] fullResult = new string[frequenty.Length];
        for(int i = 0;i < frequenty.Length; i++)
        {
            fullResult[i] = $"{comparedWords[i]} - {frequenty[i]}";
            Console.WriteLine($"{comparedWords[i]} - {frequenty[i]}");
        }
        Line();
        File.WriteAllLines("actualResult.txt", fullResult);

        string[] expectedResult = File.ReadAllLines("expectedResults.txt");
        bool allEquals = true;
        foreach(string result in expectedResult)
        {
            int k = 0;
            foreach(string word in fullResult)
            {
                if (result == word) k++;
            }
            if (k <= 0) allEquals = false; 
        }

        if (allEquals) Console.WriteLine("All matches with file expectedResults");
        else Console.WriteLine("Somethis went wrong...");

    }

    public static void Line()
    {
        Console.WriteLine("=======================================");
    }
}
