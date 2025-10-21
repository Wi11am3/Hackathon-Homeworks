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

            //�p��ͩR�F��
            int[] answer = (from c in yearmonthday
                            select int.Parse(c.ToString())).ToArray();

            int lifeNumber = (from x in answer
                              select x).Sum();

            while (lifeNumber >= 10)//�T�O�ͩR�F�ƭp�⤣��j��10
            {
                int[] digits = (from c in lifeNumber.ToString()
                                select int.Parse(c.ToString())).ToArray();
                lifeNumber = (from x in digits select x).Sum();
            }

            string searchKeyword = $"�ͩR�F��{lifeNumber}";

            //�M��P�y
            string theZodiac = "aaaaaaa";//�j��~�ŧi�ܼơA�~��b�j���ϥ�
            bool foundZodiac = false;

            List<ZodiacSignData> list = ZodiacSignList();
            foreach (var zodiac in list)
            {
                if ((month == zodiac.StartMonth && day >= zodiac.StartDay) || (month == zodiac.EndMonth && day <= zodiac.EndDay))
                {
                    theZodiac = zodiac.ZodiacSign;
                    foundZodiac = true;
                    label3.Text = $"�A���P�y�O{theZodiac}";
                }
            }
            if (foundZodiac)
            {
                string fileName = "�ͩR�F��.txt";
                if (File.Exists(fileName))
                {
                    var lines = File.ReadAllLines(fileName);

                    bool inTargetZodiac = false;
                    bool foundComment = false;

                    foreach (var line in lines)
                    {
                        if (line.Contains("�i") && line.Contains(theZodiac))
                        {
                            inTargetZodiac = true;
                            continue;
                        }
                        if (inTargetZodiac && line.Contains(searchKeyword))
                        {
                            string trimmedLine = line.Trim();
                            string comment = trimmedLine.Split('�G').Last();
                            label4.Text = $"�A���ͩR�F��{lifeNumber}�G{comment}";
                            foundComment = true;
                            break;
                        }
                    }
                    if (!foundComment)
                    {
                        label4.Text = "�䤣��������ͩR�F�Ƶ��y";
                    }
                }
                else
                {
                    MessageBox.Show("�䤣��ͩR�F��.txt�ɮ�");
                }
            }
            else
            {
                MessageBox.Show("�L�k�P�_�z���P�y");
            }
        }
        static List<ZodiacSignData> ZodiacSignList()
        {
            return new List<ZodiacSignData>()
            {
                new ZodiacSignData { ZodiacSign ="Aries�d�Ϯy" ,       StartMonth=3 ,  StartDay=21 , EndMonth=4 ,  EndDay=19},
                new ZodiacSignData { ZodiacSign ="Taurus�����y" ,      StartMonth=4 ,  StartDay=20 , EndMonth=5 ,  EndDay=20},
                new ZodiacSignData { ZodiacSign ="Gemini���l�y" ,      StartMonth=5 ,  StartDay=21 , EndMonth=6 ,  EndDay=20},
                new ZodiacSignData { ZodiacSign ="Cancer���ɮy" ,      StartMonth=6 ,  StartDay=21 , EndMonth=7 ,  EndDay=22},
                new ZodiacSignData { ZodiacSign ="Leo��l�y" ,         StartMonth=7 ,  StartDay=23 , EndMonth=8 ,  EndDay=22},
                new ZodiacSignData { ZodiacSign ="Virgo�B�k�y" ,       StartMonth=8 ,  StartDay=23 , EndMonth=9 ,  EndDay=22},
                new ZodiacSignData { ZodiacSign ="Libra�ѯ��y" ,       StartMonth=9 ,  StartDay=23 , EndMonth=10 , EndDay=22},
                new ZodiacSignData { ZodiacSign ="Scorpio���Ȯy" ,     StartMonth=10 , StartDay=23 , EndMonth=11 , EndDay=21},
                new ZodiacSignData { ZodiacSign ="Sagittarius�g��y" , StartMonth=11 , StartDay=22 , EndMonth=12 , EndDay=21},
                new ZodiacSignData { ZodiacSign ="Capricorn���~�y" ,   StartMonth=12 , StartDay=22 , EndMonth=1 ,  EndDay=19},
                new ZodiacSignData { ZodiacSign ="Aquarius���~�y" ,    StartMonth=1 ,  StartDay=20 , EndMonth=2 ,  EndDay=18},
                new ZodiacSignData { ZodiacSign ="Pisces�����y" ,      StartMonth=2 ,  StartDay=19 , EndMonth=3 ,  EndDay=20}
            };
        }
    }
}