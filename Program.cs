using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    private readonly static string _urltoTxt = "https://drive.usercontent.google.com/u/0/uc?id=1jg43arS4KIUwO0-kao_ga7PWIPWBOXxo&export=download";
    public static async Task Main()
    {
        string[] txt = await GetTextFromUrl(_urltoTxt);
       
        if (txt != null)
        {
            Dictionary<string,int> countWords = new Dictionary<string,int>();

            foreach (string word in txt)
            {
                if (countWords.ContainsKey(word))
                {
                    countWords[word]++;
                }
                else 
                {
                    countWords[word] = 1;
                }

            }

            //оказалось,это сортировка очень медленная
            //countWords = SortDicByDescending(countWords);

            countWords = countWords.OrderByDescending (x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{countWords.ElementAt(i).Key} : {countWords.ElementAt(i).Value}");
            }
            
        }

        Console.ReadLine();
    }

    private static async Task<string[]> GetTextFromUrl(string url)
    {
        try
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string txtTemp = await httpClient.GetStringAsync(url);
                if (txtTemp != null)
                {
                    var noPunctuationText = new string(txtTemp.Where(c => !char.IsPunctuation(c)).ToArray()).ToLower();

                    return noPunctuationText.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                }
                else
                {
                    return null;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    private static Dictionary<string, int> SortDicByDescending(Dictionary<string, int> dic)
    {
        var list = dic.ToList();

        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = 0; j < list.Count - 1 - i; j++)
            {
                if (list[j].Value < list[j + 1].Value)
                {
                    var temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }

        
        return list.ToDictionary(x => x.Key, x => x.Value);
    }
}
