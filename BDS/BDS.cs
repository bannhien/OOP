using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        String input = File.ReadAllText(@"test.txt");
        int i =0;
        int j = 0;
        Dictionary<int, string> sheet = new Dictionary<int, string>();
        foreach (var row in input.Split('\n'))
        {
            j = 0;
            foreach (var col in row.Trim().Split(','))
            {
                sheet[i*10+j] = col;
                Console.WriteLine(sheet[i*10+j]);
                j++;
            }
            i++;
        }
    }
}
