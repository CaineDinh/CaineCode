using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> textList = new List<string>
        {
            "Audi TT mk1",
            "Audi TT mk1 225.",
            "Audi TT mk1 3.2",
            "Audi TT mk1@",
            "Audi TT mk2"
        };

        Dictionary<string, int> phraseFrequency = new Dictionary<string, int>();

        foreach (string text in textList)
        {
            string[] words = text.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                string phrase = words[i];
                if (phraseFrequency.ContainsKey(phrase))
                {
                    phraseFrequency[phrase]++;
                }
                else
                {
                    phraseFrequency[phrase] = 1;
                }

                if (i < words.Length - 1)
                {
                    string nextPhrase = words[i + 1];
                    phrase = $"{words[i]} {nextPhrase}";
                    if (phraseFrequency.ContainsKey(phrase))
                    {
                        phraseFrequency[phrase]++;
                    }
                    else
                    {
                        phraseFrequency[phrase] = 1;
                    }

                }
            }
        }

        string commonPhrase = phraseFrequency.OrderByDescending(pair => pair.Value).First().Key;
        Console.WriteLine("Common phrase: " + commonPhrase);
    }
}