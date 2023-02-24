using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_1_威力彩
{
    public partial class Form_Lottery : Form
    {
        public Label LotteryLabel;
        public List<Button> listbutton = new List<Button>();
        public List<int> UserNum = new List<int>();
        //public List<int> LoterryNum = new List<int>();

        public Form_Lottery()
        {
            InitializeComponent();
        }

        private void Form_Lottery_Load(object sender, EventArgs e)
        {
            Label();
            PickButton(4, 10);
            SpecialButton(8, 1); //要問老師
        }

        void Label() //標題
        {
            LotteryLabel = new Label();
            LotteryLabel.BackColor = Color.LightYellow;
            LotteryLabel.ForeColor = Color.Black;
            LotteryLabel.Font = new Font("微軟正黑體", 24);
            LotteryLabel.Name = "lbl_Lottery";
            LotteryLabel.Text = "iSpan威力彩";
            LotteryLabel.TextAlign = ContentAlignment.MiddleCenter;
            LotteryLabel.Location = new Point(40, 20);
            LotteryLabel.Size = new Size(400, 36);

            Controls.Add(LotteryLabel);
        }

        void Button_Click(object sender, EventArgs e)  //一般號按鈕事件
        {
            Button myBtn = (Button)sender;

            if (myBtn.BackColor == Color.Pink)
            {
                myBtn.BackColor = Color.Red;
                MessageBox.Show("你選了號碼:" + myBtn.Text);
                UserNum.Add(Convert.ToInt32(myBtn.Text));
                myPickNum(myBtn.Text); 
            }
            else
            {
                myBtn.BackColor = Color.Pink;
            }

            if (UserNum.Count > 6)
            {
                UserNum.Clear();
                MessageBox.Show("叫你選6個，選那麼多個幹嘛?不給你玩了");
                Application.Exit();
                UserNum.ForEach(i => Console.Write("{0}\t", i));
            }

            void myPickNum(string N1)
            {
                lbl_UserNum1.Text += $" {N1} ";
            }
            //lbl_UserNum1.Text = myBtn.Text;

            /*lbl_UserNum1.Text = Convert.ToString(UserNum[0]);
            lbl_UserNum2.Text = Convert.ToString(UserNum[1]);
            lbl_UserNum3.Text = Convert.ToString(UserNum[2]);
            lbl_UserNum4.Text = Convert.ToString(UserNum[3]);
            lbl_UserNum5.Text = Convert.ToString(UserNum[4]);
            lbl_UserNum6.Text = Convert.ToString(UserNum[5]);

            for (int i = 0; i < UserNum.Count; i++)
            {
                
            }*/


            /*int[] UserNum = new int[6];
            for (int Num = 0; Num < 6; Num++)
            {


            }*/

            /*int UserPick = Convert.ToInt32(myBtn.Text);
            UserNum.Add(UserPick);
            //Number1.Text = UserPick.ToString();
            /*foreach (int PickNum in UserNum)
            {
                Number1.Text = (PickNum.ToString());
            }*/

        }


        void PickButton(int intRow, int intColumn)  //一般號按鈕
        {
            int Number = 0;

            for (int i = 0; i < intRow; i += 1)
            {
                for (int j = 0; j < intColumn; j += 1)
                {
                    Number += 1;
                    Button Pbutton = new Button();
                    Pbutton.BackColor = Color.Pink;
                    Pbutton.ForeColor = Color.Black;
                    Pbutton.Font = new Font("微軟正黑體", 18);
                    Pbutton.Text = Number.ToString();
                    //Pbutton.Name = Number.ToString();
                    Pbutton.Location = new Point(40 + 68 * j, 110 + 42 * i);
                    Pbutton.Size = new Size(66, 40);
                    Pbutton.Click += new EventHandler(Button_Click);  //按鈕事件 // += 事件指定運算子 , -= 事件解除運算子
                    Controls.Add(Pbutton);
                    listbutton.Add(Pbutton);
                    if(Number > 37)
                    {
                        break;
                    }
                }
            }
            
        }

        void SpecialButton(int Row, int Column)  //特別號按鈕
        {
            int SpecialNumber = 0;

            for (int k = 0; k < Row; k += 1)
            {
                for (int l = 0; l < Column; l += 1)
                {
                    SpecialNumber += 1;
                    Button Sbutton = new Button();
                    Sbutton.BackColor = Color.Pink;
                    Sbutton.ForeColor = Color.Black;
                    Sbutton.Font = new Font("微軟粗黑體", 18);
                    Sbutton.Text = SpecialNumber.ToString();
                    Sbutton.Location = new Point(40 + 68 * k, 130 + 42 * (l+5));
                    Sbutton.Size = new Size(66, 40);
                    Sbutton.Click += new EventHandler(SpecialBtn_Click);  //特別號按鈕事件
                    Controls.Add(Sbutton);
                    listbutton.Add(Sbutton);
                    if (SpecialNumber > 7)
                    {
                        break;
                    }
                }
            }
        }

        void SpecialBtn_Click(object sender, EventArgs e)  //特別號按鈕事件
        {
            Button SpeBtn = (Button)sender;

            //MessageBox.Show("你選了號碼:" + myBtn.Text);

            if (SpeBtn.BackColor == Color.Pink)
            {
                SpeBtn.BackColor = Color.Red;
                MessageBox.Show("你選了號碼:" + SpeBtn.Text);
                UserNum.Add(Convert.ToInt32(SpeBtn.Text));
                mySpecialNum(SpeBtn.Text);
            }
            else
            {
                SpeBtn.BackColor = Color.Pink;
            }

            /*if (UserNum.Count >= 2)
            {
                UserNum.Clear();
                MessageBox.Show("叫你選1個，選那麼多個幹嘛?不給你玩了");
                Application.Exit();
                //UserNum.ForEach(i => Console.Write("{0}\t", i));
            }*/

            void mySpecialNum(string N2)
            {
                lbl_UserNum7.Text += $" {N2} ";
            }
        }

            private void btn_Checking_Click(object sender, EventArgs e)  //抽號碼+對獎鈕
        {
            int[] lotoNum = new int[38]; //將所有號碼(1~38)放入陣列威力彩中
            for (int i = 0; i <= 37; i++)
            {
                lotoNum[i] = i + 1;
            }

            int[] luckyNum = new int[6]; 
            Random random = new Random();
            for (int m = 0; m <= 5; m++)
            {
                int temp = random.Next(1, 38);
                if (lotoNum[temp] == 0)
                {
                    m--;
                }
                else
                {
                    luckyNum[m]= lotoNum[temp];
                    lotoNum[temp]= 0;                    
                }

                lbl_LuckyNumber1.Text = Convert.ToString(luckyNum[0]);
                lbl_LuckyNumber2.Text = Convert.ToString(luckyNum[1]);
                lbl_LuckyNumber3.Text = Convert.ToString(luckyNum[2]);
                lbl_LuckyNumber4.Text = Convert.ToString(luckyNum[3]);
                lbl_LuckyNumber5.Text = Convert.ToString(luckyNum[4]);
                lbl_LuckyNumber6.Text = Convert.ToString(luckyNum[5]);
            }

            Random Special = new Random(); //特別號          
            lbl_LuckyNumber7.Text = Special.Next(1, 9).ToString();
            //lbl_LuckyNumber7.Text = Convert.ToString(luckyNum[6]);




            int[] UserPickNum = UserNum.ToArray(); //對獎過程
            List<int> matches = new List<int> ();
            for (int a = 0; a <= 5; a++)
            {
                for (int b = 0; b <= 5; b++)
                {
                    if (luckyNum[a] == UserPickNum[b])
                    { matches.Add(luckyNum[a]); }
                }
            }

           

            int x = Convert.ToInt32(lbl_LuckyNumber7.Text);
            int y = Convert.ToInt32(lbl_UserNum7.Text);
            if (x == y)
            {
                matches.Add(x);
            }
            int n = matches.Count();

            MessageBox.Show("恭喜你對中了"+n.ToString()+"對^o^");
        }

    }
}
