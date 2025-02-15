using SandBox;
using System;
using System.Collections.Generic;

public class Program
{
    private readonly static string _urltoTxt = "https://drive.usercontent.google.com/u/0/uc?id=1jg43arS4KIUwO0-kao_ga7PWIPWBOXxo&export=download";
    public static async Task Main()
    {
        string[] txtForFirstThread = await GetTextFromUrl(_urltoTxt);
       
        if (txtForFirstThread != null)
        {

            Lists.ListSW(txtForFirstThread);
            Lists.LinkedListSW(txtForFirstThread);


            //В данном случае я пытался запустить два потока,
            //но результаты были разными.
            //Поэтому я решил оставить только один поток.Буду признателен,
            //если вы сможете объяснить мне причину такого поведения.

            //string[] txtForSecondThread = (string[])txtForFirstThread.Clone();

            //Thread threadFirst = new Thread(() => Lists.ListSW(txtForFirstThread));
            //threadFirst.Start();

            //Thread threadSecond = new Thread(() => Lists.LinkedListSW(txtForSecondThread));
            //threadSecond.Start();
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
                    return txtTemp.Split(" ",StringSplitOptions.RemoveEmptyEntries);
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
}
