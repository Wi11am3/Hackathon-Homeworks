using System.Collections.Generic;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hackathon5
{

    public partial class Form1 : Form
    {
        private int[] answer;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime selectDate = dateTimePicker1.Value;

            int year = selectDate.Year;
            int month = selectDate.Month;
            int day = selectDate.Day;

            string stryear = year.ToString();
            string strmonth = month.ToString();
            string strday = day.ToString();
            string yearmonthday = stryear + strmonth + strday;

            MessageBox.Show(yearmonthday);

            //int[] answer = yearmonthday.Split(string.Empty).Select(int.Parse).ToArray();

            int[] answer = (from c in yearmonthday
                            select int.Parse(ToString())).ToArray();

            int sum = (from x in answer
                      select x).Sum();

            MessageBox.Show($"{ sum}");

            //int a = 0;
            //for (int i = 0; i < answer.Length; i++)
            //{
            //    a += answer[i];
            //}
            //MessageBox.Show($"{a}");

            List<ZodiacSignData> list = ZodiacSignList();
            foreach (var zodiac in list)
            {
                if ((month == zodiac.StartMonth && day >= zodiac.StartDay) || (month == zodiac.EndMonth && day <= zodiac.EndDay))
                {
                    MessageBox.Show($"{zodiac.ZodiacSign}");
                }
            }

            //string fileName = "生命靈數.txt";
            //if (File.Exists(fileName))
            //{
            //    var lines = File.ReadAllLines(fileName);

                //先找到星座區塊,要如何區隔不同星座
                //找到生命靈數,再找評語
                //如何區分生命靈數與平語,Split 分隔



                //var result = lines.Where(line => line.Contains());
                //MessageBox.Show(Plus(answer.Length));
            //}
        }
        //private int Plus(int n)
        //{
        //    if (answer.Length == 1)
        //        return 1;
        //    else
        //        return answer[answer.Length] + Plus(answer[answer.Length - 1]);
        //}


        static List<ZodiacSignData> ZodiacSignList()
        {
            return new List<ZodiacSignData>()
            {
                new ZodiacSignData { ZodiacSign ="Aries" , StartMonth=3 , StartDay=21 , EndMonth=4 , EndDay=19},
                new ZodiacSignData { ZodiacSign ="Taurus" , StartMonth=4 , StartDay=20 , EndMonth=5 , EndDay=20},
                new ZodiacSignData { ZodiacSign ="Gemini" , StartMonth=5 , StartDay=21 , EndMonth=6 , EndDay=20},
                new ZodiacSignData { ZodiacSign ="Cancer" , StartMonth=6 , StartDay=21 ,EndMonth=7 , EndDay=22},
                new ZodiacSignData { ZodiacSign ="Leo" , StartMonth=7 , StartDay=23 , EndMonth=8 , EndDay=22},
                new ZodiacSignData { ZodiacSign ="Virgo" , StartMonth=8 , StartDay=23 , EndMonth=9 , EndDay=22},
                new ZodiacSignData { ZodiacSign ="Libra" , StartMonth=9 , StartDay=23 , EndMonth=10 , EndDay=22},
                new ZodiacSignData { ZodiacSign ="Scorpio" , StartMonth=10 , StartDay=23,EndMonth=11 , EndDay=21},
                new ZodiacSignData { ZodiacSign ="Sagittarius" , StartMonth=11 , StartDay=22 , EndMonth=12 , EndDay=21},
                new ZodiacSignData { ZodiacSign ="Capricorn" , StartMonth=12 , StartDay=22, EndMonth=1 , EndDay=19},
                new ZodiacSignData { ZodiacSign ="Aquarius" , StartMonth=1 , StartDay=20 , EndMonth=2 ,EndDay=18},
                new ZodiacSignData { ZodiacSign ="Pisces" , StartMonth=2 , StartDay=19 , EndMonth=3 ,EndDay=20}
            };
        }
    }
}
