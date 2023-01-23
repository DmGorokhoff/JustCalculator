using System;
using System.Windows.Forms;
using System.Data;

namespace JustCalculator
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Form1 cl_frm1 = new Form1();
            Calculations cl_clc = new Calculations();
            Presenter presenter = new Presenter(cl_frm1, cl_clc);

            Application.Run(cl_frm1); 
        }
        public class Presenter
        {
            private readonly IForm1 _iform1;
            private readonly ICalculations _icalc;
            
            public Presenter(IForm1 ifrm, ICalculations iclc)
            {
                _iform1 = ifrm;
                _icalc = iclc;

                _iform1.Evn_btn_persent_Click += _iform1_evn_btn_persent_Click;
                _iform1.Evn_btn_root_Click += _iform1_Evn_btn_root_Click;
                _iform1.Evn_btn_degree_Click += _iform1_Evn_btn_degree_Click;
                _iform1.Evn_btn_result_Click += _iform1_Evn_btn_result_Click;
            }

            private void _iform1_Evn_btn_result_Click(object sender, EventArgs e)
            {
                try
                {
                    string tmp = _iform1.TxtBoxContent;
                    
                    if (!tmp.Contains("^") && !tmp.Contains("√") && !tmp.Contains("%"))
                    {
                        tmp = tmp.Replace(",", ".");
                        DataTable dt = new DataTable();
                        var result = dt.Compute(tmp, "");
                        _iform1.TxtBoxContent = "";
                        _iform1.TxtBoxContent = result.ToString();
                    }

                    if (tmp.Contains("^"))
                        _iform1_Evn_btn_degree_Click(this, EventArgs.Empty);

                    if (tmp.Contains("√"))
                        _iform1_Evn_btn_root_Click(this, EventArgs.Empty);

                    if (tmp.Contains("%"))
                        _iform1_evn_btn_persent_Click(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _iform1.TxtBoxContent =_iform1.TxtBoxContent.Remove(_iform1.TxtBoxContent.Length-1,1);
                }
            }

            private void _iform1_Evn_btn_degree_Click(object sender, EventArgs e)
            {
                try
                {
                    string tmp = _iform1.TxtBoxContent;
                    if (!tmp.Contains("^") & _iform1.TxtBoxContent != "")
                        _iform1.TxtBoxContent += "^";

                    if (tmp.Length > 2)
                    {
                        double tmp1 = _icalc.Calc_Degree(tmp);
                        _iform1.TxtBoxContent = tmp1.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _iform1.TxtBoxContent = "";
                }
            }

            private void _iform1_Evn_btn_root_Click(object sender, EventArgs e)
            {
                try
                {
                    string tmp = _iform1.TxtBoxContent;
                    if (!tmp.Contains("√") & _iform1.TxtBoxContent != "")
                        _iform1.TxtBoxContent += "√";

                    else if(tmp !="")
                    {
                        tmp = _iform1.TxtBoxContent;
                        string[] arr = tmp.Split('√');
                        double x = double.Parse(arr[0].ToString());
                        _icalc.Calc_Root(x);
                        double tmp1 = Math.Sqrt(x);
                        _iform1.TxtBoxContent = tmp1.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _iform1.TxtBoxContent = "";
                }
            }
            private void _iform1_evn_btn_persent_Click(object sender, EventArgs e)
            {
                try
                {
                    string tmp = _iform1.TxtBoxContent;
                    
                    if (!tmp.Contains("%") & _iform1.TxtBoxContent != "")
                        _iform1.TxtBoxContent += "%";
                    else
                    {   
                        tmp = _iform1.TxtBoxContent;
                        tmp = _icalc.Calc_Persent(tmp);
                        _iform1.TxtBoxContent = tmp.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _iform1.TxtBoxContent = "";
                }
            }
        }
    }
}
