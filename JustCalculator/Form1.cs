using System;
using System.Linq;
using System.Windows.Forms;

namespace JustCalculator
{
    public interface IForm1
    {
        string TxtBoxContent { get; set; }
        
        event EventHandler Evn_btn_persent_Click;
        event EventHandler Evn_btn_root_Click;
        event EventHandler Evn_btn_degree_Click;
        event EventHandler Evn_btn_result_Click;
    }
    public partial class Form1 : Form, IForm1
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region // кнопки
        private void btn1_Click(object sender, EventArgs e)
        {
            string tmp = txtBox.Text;
            if (!tmp.Contains("√"))
                txtBox.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            string tmp = txtBox.Text;
            if (!tmp.Contains("√"))
                txtBox.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            string tmp = txtBox.Text;
            if (!tmp.Contains("√"))
                txtBox.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            string tmp = txtBox.Text;
            if (!tmp.Contains("√"))
                txtBox.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            string tmp = txtBox.Text;
            if (!tmp.Contains("√"))
                txtBox.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            string tmp = txtBox.Text;
            if (!tmp.Contains("√"))
                txtBox.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            string tmp = txtBox.Text;
            if (!tmp.Contains("√"))
                txtBox.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            string tmp = txtBox.Text;
            if (!tmp.Contains("√"))
                txtBox.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            string tmp = txtBox.Text;
            if (!tmp.Contains("√"))
                txtBox.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            string tmp = txtBox.Text;
            if (!tmp.Contains("√"))
                txtBox.Text += "0";
        }

        private void btn_comma_Click(object sender, EventArgs e)
        {
            try
            {
                string tmp = txtBox.Text;
                //string tmpChar = tmp.Contains();
                //switch()

                if (tmp != "" & tmp.Substring(tmp.Length-1) != "+")
                {
                    txtBox.Text += ",";
                    tmp = txtBox.Text;
                    //string str = new Regex("/").ToString();
                    txtBox.Text = tmp.Replace(",,", ",");
                    if (tmp.Count(x => x == ',') > 1 & !tmp.Contains("+"))
                        txtBox.Text = tmp.Substring(0, tmp.Length-1);

                    if(tmp.Substring(tmp.LastIndexOf('+') + 1).Count(x => x == ',') > 1 & tmp.Contains("+"))
                        txtBox.Text = tmp.Remove(tmp.Length - 1,1);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtBox.Clear();
        }

        private void btn_persent_Click(object sender, EventArgs e)
        {
            if (Evn_btn_persent_Click != null) Evn_btn_persent_Click(this, EventArgs.Empty);            
        }

        private void btn_root_Click(object sender, EventArgs e) //Корень
        {
            if (Evn_btn_root_Click != null) Evn_btn_root_Click(this,EventArgs.Empty);            
        }

        private void btn_degree_Click(object sender, EventArgs e) //Степень
        {
            if (Evn_btn_degree_Click != null) Evn_btn_degree_Click(this, EventArgs.Empty);
        }

        private void btn_division_Click(object sender, EventArgs e)
        {
            try
            {
               string tmp = txtBox.Text;
               if (tmp != "")
                {
                    txtBox.Text += "/";
                    tmp = txtBox.Text;                    
                    txtBox.Text = tmp.Replace("//", "/");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void btn_addition_Click(object sender, EventArgs e)
        {
            try
            {
                string tmp = txtBox.Text;
                if (tmp != "")
                {
                    txtBox.Text += "+";
                    tmp = txtBox.Text;
                    txtBox.Text = tmp.Replace("++", "+");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_multiplication_Click(object sender, EventArgs e)
        {
            try
            {
                string tmp = txtBox.Text;
                if (tmp != "")
                {
                    txtBox.Text += "*";
                    tmp = txtBox.Text;
                    txtBox.Text = tmp.Replace("**", "*");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_subtraction_Click(object sender, EventArgs e)
        {
            try
            {
                string tmp = txtBox.Text;
                if (tmp != "")
                {
                    txtBox.Text += "-";
                    tmp = txtBox.Text;
                    txtBox.Text = tmp.Replace("--", "-");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_result_Click(object sender, EventArgs e)
        {
            if (Evn_btn_result_Click != null) Evn_btn_result_Click(this, EventArgs.Empty);           
        }
        
        private void btn_bracket_l_Click(object sender, EventArgs e)
        {
            try
            {
                string tmp = txtBox.Text;
                txtBox.Text += "(";
                tmp = txtBox.Text;
                txtBox.Text = tmp.Replace("((", "(");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_bracket_r_Click(object sender, EventArgs e)
        {
            try
            {
                string tmp = txtBox.Text;
                txtBox.Text += ")";
                tmp = txtBox.Text;
                txtBox.Text = tmp.Replace("))", ")");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            txtBox.Clear();
            Application.Exit();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа \"Калькулятор\", 2022","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtBox_TextChanged(object sender, EventArgs e) //исключить ввод в поле для вычислений посторонних символов (например, текста)
        {                                                           //при вводе текста будет выдано сообщение о неверном вводе данных.
            int ind = 0;
            try
            {
                if (txtBox.Text !="" && txtBox.Text != ",")
                {
                    string[] arrStr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "/", "*","+","-", "^", "%", "(",")", "√", "," };
                    string str = txtBox.Text;
                    string s = str.Substring(str.Length - 1);
                    for (int i = 0; i < arrStr.Length; i++)
                    {
                        if (arrStr[i] == s)
                            ind++;
                    }
                }
                
                if (ind == 0 && txtBox.Text !="")
                    throw new Exception("Неверный формат данных");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtBox.Text = "";
            }
        }

        #endregion
        public string TxtBoxContent 
        {
            get { return txtBox.Text; }
            set { txtBox.Text = value; }
        }
        public event EventHandler Evn_btn_persent_Click;
        public event EventHandler Evn_btn_root_Click;
        public event EventHandler Evn_btn_degree_Click;
        public event EventHandler Evn_btn_result_Click;

        private void Form1_Load(object sender, EventArgs e)
        {
            txtBox.Clear();
        }
    }
}
