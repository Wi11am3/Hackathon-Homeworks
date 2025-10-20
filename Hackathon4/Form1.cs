namespace Hackathon4
{
    public partial class Form1 : Form
    {
        private string answer;

        private List<string> _list;
        public Form1()
        {
            InitializeComponent();
            answer = string.Empty;
            CreateList();
            SetListBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int randNum = random.Next(0, 10);
            int[] arr = new int[4];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = -1;
            }

            for (int arrIdx = 0; arrIdx < 4; arrIdx++)
            {
                while (Array.IndexOf(arr, randNum) > -1)
                {
                    randNum = random.Next(0, 10);
                }
                arr[arrIdx] = randNum;
            }
            answer = string.Join(string.Empty, arr);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(answer);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string tryanswer = textBox1.Text;
            string[] t = tryanswer.Split(string.Empty);
            string[] a = answer.Split(string.Empty);

            if (tryanswer.Length != 4 || !tryanswer.All(char.IsDigit))
            {
                MessageBox.Show("請輸入四個整數");
                return;
            }

            int acount = 0;
            int bcount = 0;

            for (int i = 0; i < 4; i++)
            {
                if (tryanswer[i] == answer[i])
                {
                    acount++;
                }
                for (int j = 0; j < 4; j++)
                {
                    if (tryanswer[i] == answer[j] && i != j)
                    {
                        bcount++;
                    }
                }
            }
            string result = $"{tryanswer}:{acount}A{bcount}B";
            _list.Add(result);
            SetListBox();

            if (tryanswer == answer)
            {
                MessageBox.Show("恭喜過關");
            }
        }
        private void CreateList()
        {
            _list = new List<string>();
        }
        private void SetListBox()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = _list;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            CreateList();
            SetListBox();
        }
    }
}
