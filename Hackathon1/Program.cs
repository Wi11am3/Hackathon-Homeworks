namespace Hackathon1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入一個大於99的整數:");
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("Dann");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("School");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
        }
    }
}
