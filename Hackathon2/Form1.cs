namespace Hackathon2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (double.TryParse(textBox1.Text, out double value))

                {
                    double fahrenheit = value * 9 / 5 + 32;
                    label1.Text = $"結果 : {textBox1.Text} °C = {fahrenheit:F2} °F";
                }
                else
                {
                    label1.Text = "請輸入有效數字";
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (double.TryParse(textBox1.Text, out double value))
                {
                    double celsius = (value - 32) * 5 / 9;
                    label1.Text = $"結果 : {textBox1.Text} °F = {celsius:F2} C";
                }
                else
                {
                    label1.Text = "請輸入有效數字";
                }
            }
            else
            {
                label1.Text = "請選擇你想要轉換的溫度單位";
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            textBox1.Text += btn.Tag.ToString();
        }
    }
}
