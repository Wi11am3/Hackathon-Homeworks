using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Schema;

namespace Hackathon3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("輸入一個有意義的英文敘述字串");
            var str = Console.ReadLine().Split(' ');
            for (int i = 0; i < str.Length; i++)
            {
                bool alreadycount = false;

                for (int k = 0; k < i; k++)
                {
                    if (str[i].ToLower() == str[k].ToLower())
                    {
                        alreadycount = true;
                        break;
                    }
                }

                if (alreadycount)
                {
                    continue;
                }

                int count = 0;
                for (int j = i; j < str.Length; j++)
                {
                    if (str[i].ToLower() == str[j].ToLower())
                    {
                        count++;
                    }
                }
                Console.WriteLine($"{str[i]} : {count}");
            }





            //List<string> list = new List<string>(str);

            //while (list.Count > 0)
            //{
            //    string current = list[0];

            //    int count = list.Count(x => x == current);

            //    Console.WriteLine($"{current}出現過{count}次");

            //    list.RemoveAll(x => x == current);
            //}
        }
    }
}
