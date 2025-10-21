using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hackathon5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime selectDate = dateTimePicker1.Value;
            string yearmonthday = selectDate.ToString("yyyyMMdd");
            int month = selectDate.Month;
            int day = selectDate.Day;

            //計算生命靈數
            int[] answer = (from c in yearmonthday
                            select int.Parse(c.ToString())).ToArray();

            int lifeNumber = (from x in answer
                              select x).Sum();

            while (lifeNumber >= 10)//確保生命靈數計算不能大於10
            {
                int[] digits = (from c in lifeNumber.ToString()
                                select int.Parse(c.ToString())).ToArray();
                lifeNumber = (from x in digits select x).Sum();
            }

            string searchKeyword = $"生命靈數{lifeNumber}";

            //尋找星座
            string theZodiac = "aaaaaaa";//迴圈外宣告變數，才能在迴圈後使用
            bool foundZodiac = false;

            List<ZodiacSignData> list = ZodiacSignList();
            foreach (var zodiac in list)
            {
                if ((month == zodiac.StartMonth && day >= zodiac.StartDay) || (month == zodiac.EndMonth && day <= zodiac.EndDay))
                {
                    theZodiac = zodiac.ZodiacSign;
                    foundZodiac = true;
                    label3.Text = $"你的星座是{theZodiac}";
                }
            }
            if (foundZodiac)
            {
                string fileName = "生命靈數.txt";
                if (File.Exists(fileName))
                {
                    var lines = File.ReadAllLines(fileName);

                    bool inTargetZodiac = false;
                    bool foundComment = false;

                    foreach (var line in lines)
                    {
                        if (line.Contains("【") && line.Contains(theZodiac))
                        {
                            inTargetZodiac = true;
                            continue;
                        }
                        if (inTargetZodiac && line.Contains(searchKeyword))
                        {
                            string trimmedLine = line.Trim();
                            string comment = trimmedLine.Split('：').Last();
                            label4.Text = $"你的生命靈數{lifeNumber}：{comment}";
                            foundComment = true;
                            break;
                        }
                    }
                    if (!foundComment)
                    {
                        label4.Text = "找不到對應的生命靈數評語";
                    }
                }
                else
                {
                    MessageBox.Show("找不到生命靈數.txt檔案");
                }
            }
            else
            {
                MessageBox.Show("無法判斷您的星座");
            }
        }
        static List<ZodiacSignData> ZodiacSignList()
        {
            return new List<ZodiacSignData>()
            {
                new ZodiacSignData { ZodiacSign ="Aries牡羊座" ,       StartMonth=3 ,  StartDay=21 , EndMonth=4 ,  EndDay=19},
                new ZodiacSignData { ZodiacSign ="Taurus金牛座" ,      StartMonth=4 ,  StartDay=20 , EndMonth=5 ,  EndDay=20},
                new ZodiacSignData { ZodiacSign ="Gemini雙子座" ,      StartMonth=5 ,  StartDay=21 , EndMonth=6 ,  EndDay=20},
                new ZodiacSignData { ZodiacSign ="Cancer巨蟹座" ,      StartMonth=6 ,  StartDay=21 , EndMonth=7 ,  EndDay=22},
                new ZodiacSignData { ZodiacSign ="Leo獅子座" ,         StartMonth=7 ,  StartDay=23 , EndMonth=8 ,  EndDay=22},
                new ZodiacSignData { ZodiacSign ="Virgo處女座" ,       StartMonth=8 ,  StartDay=23 , EndMonth=9 ,  EndDay=22},
                new ZodiacSignData { ZodiacSign ="Libra天秤座" ,       StartMonth=9 ,  StartDay=23 , EndMonth=10 , EndDay=22},
                new ZodiacSignData { ZodiacSign ="Scorpio天蠍座" ,     StartMonth=10 , StartDay=23 , EndMonth=11 , EndDay=21},
                new ZodiacSignData { ZodiacSign ="Sagittarius射手座" , StartMonth=11 , StartDay=22 , EndMonth=12 , EndDay=21},
                new ZodiacSignData { ZodiacSign ="Capricorn摩羯座" ,   StartMonth=12 , StartDay=22 , EndMonth=1 ,  EndDay=19},
                new ZodiacSignData { ZodiacSign ="Aquarius水瓶座" ,    StartMonth=1 ,  StartDay=20 , EndMonth=2 ,  EndDay=18},
                new ZodiacSignData { ZodiacSign ="Pisces雙魚座" ,      StartMonth=2 ,  StartDay=19 , EndMonth=3 ,  EndDay=20}
            };
        }
    }
}