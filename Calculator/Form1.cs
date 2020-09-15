using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        List<double> dNums = new List<double>();
        List<char> cOperators = new List<char>();
        double dSum = 0;
        //double dCurrent = 0;
        
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            _btnAdd.Click += _btnAdd_Click;
            _btnSub.Click += _btnSub_Click;
            _btnMulti.Click += _btnMulti_Click;
            _btnDiv.Click += _btnDiv_Click;
            _btnAns.Click += _btnAns_Click;
            _btn0.Click += _btn0_Click;
            _btn1.Click += _btn1_Click;
            _btn2.Click += _btn2_Click;
            _btn3.Click += _btn3_Click;
            _btn4.Click += _btn4_Click;
            _btn5.Click += _btn5_Click;
            _btn6.Click += _btn6_Click;
            _btn7.Click += _btn7_Click;
            _btn8.Click += _btn8_Click;
            _btn9.Click += _btn9_Click;
            _btnDec.Click += _btnDec_Click;
            _btnClear.Click += _btnClear_Click;
            _btnBack.Click += _btnBack_Click;
            _txbNum.Enabled = false;
            
        }

        private void _btnBack_Click(object sender, EventArgs e)
        {
            if (_lblEQN.Text != "")
            {
                _lblEQN.Text = _lblEQN.Text.Remove(_lblEQN.Text.Length - 1);
            }
            if (_txbNum.Text != "")
            {
                _txbNum.Text = _txbNum.Text.Remove(_txbNum.Text.Length - 1);
            }
        }

        private void _btnDec_Click(object sender, EventArgs e)
        {
            if (_txbNum.Text.Last() != '.')
            {
                _txbNum.Text += ".";
                _lblEQN.Text += ".";
            }
        }

        private void _btnClear_Click(object sender, EventArgs e)
        {
            ClearBox();
        }

        private void _btn9_Click(object sender, EventArgs e)
        {
            if (_txbNum.Text == "0")
                _txbNum.Clear();
            _txbNum.Text += "9";
            _lblEQN.Text += "9";
        }

        private void _btn8_Click(object sender, EventArgs e)
        {
            if (_txbNum.Text == "0")
                _txbNum.Clear();
            _txbNum.Text += "8";
            _lblEQN.Text += "8";
        }

        private void _btn7_Click(object sender, EventArgs e)
        {
            if (_txbNum.Text == "0")
                _txbNum.Clear();
            _txbNum.Text += "7";
            _lblEQN.Text += "7";
        }

        private void _btn6_Click(object sender, EventArgs e)
        {
            if (_txbNum.Text == "0")
                _txbNum.Clear();
            _txbNum.Text += "6";
            _lblEQN.Text += "6";
        }

        private void _btn5_Click(object sender, EventArgs e)
        {
            if (_txbNum.Text == "0")
                _txbNum.Clear();
            _txbNum.Text += "5";
            _lblEQN.Text += "5";
        }

        private void _btn4_Click(object sender, EventArgs e)
        {
            if (_txbNum.Text == "0")
                _txbNum.Clear();
            _txbNum.Text += "4";
            _lblEQN.Text += "4";
        }

        private void _btn3_Click(object sender, EventArgs e)
        {
            if (_txbNum.Text == "0")
                _txbNum.Clear();
            _txbNum.Text += "3";
            _lblEQN.Text += "3";
        }

        private void _btn2_Click(object sender, EventArgs e)
        {
            if (_txbNum.Text == "0")
                _txbNum.Clear();
            _txbNum.Text += "2";
            _lblEQN.Text += "2";
        }

        private void _btn1_Click(object sender, EventArgs e)
        {
            if (_txbNum.Text == "0")
                _txbNum.Clear();
            _txbNum.Text += "1";
            _lblEQN.Text += "1";
        }

        private void _btn0_Click(object sender, EventArgs e)
        {
            if (_txbNum.Text != "0")
            {
                _txbNum.Text += "0";
                _lblEQN.Text += "0";
            }
        }

        private void _btnAns_Click(object sender, EventArgs e)
        {
            if (_txbNum.Text.Length > 0)
            {
                try
                {
                    dNums.Add(double.Parse(_txbNum.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error parsing value", "Error", MessageBoxButtons.OK);
                    ClearBox();

                }
                
                    
            }
               
            if (cOperators.Contains('*'))
            {
                try
                {
                    dSum = dNums[cOperators.IndexOf('*')] * dNums[cOperators.IndexOf('*') + 1];
                    dNums.RemoveAt(cOperators.IndexOf('*'));
                    dNums.RemoveAt(cOperators.IndexOf('*'));
                    dNums.Insert(0, dSum);
                    cOperators.RemoveAt(cOperators.IndexOf('*'));
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Calculation Error", "Error",MessageBoxButtons.OK);
                }
                
            }
            for (int i = 0; i < cOperators.Count; ++i)
            {
                
                if (i > 0)
                {
                    if (cOperators[i] == '+')
                    {
                        dSum += dNums[i + 1];
                    }
                    else if (cOperators[i] == '-')
                    {
                        dSum -= dNums[i + 1];
                    }
                    else if (cOperators[i] == '*')
                    {
                        dSum *= dNums[i + 1];
                    }
                    else if (cOperators[i] == '/')
                    {
                        dSum /= dNums[i + 1];
                    }
                }
                else
                {
                    if (cOperators[i] == '+')
                    {
                        dSum = dNums[i] + dNums[i + 1];
                    }
                    else if (cOperators[i] == '-')
                    {
                        dSum = dNums[i] - dNums[i + 1];
                    }
                    else if (cOperators[i] == '*')
                    {
                        dSum = dNums[i] * dNums[i + 1];
                    }
                    else if (cOperators[i] == '/')
                    {
                        dSum = dNums[i] / dNums[i + 1];
                    }
                }
                

                
            }

            _txbNum.Text = dSum.ToString();
            _lblEQN.Text += " = " +dSum.ToString();
            cOperators.Clear();
            dNums.Clear();
            dNums.Add(dSum);
        }

        private void _btnDiv_Click(object sender, EventArgs e)
        {
            if (_lblEQN.Text.EndsWith("/") || _lblEQN.Text.EndsWith("*") || _lblEQN.Text.EndsWith("+") || _lblEQN.Text.EndsWith("-"))
                _lblEQN.Text = _lblEQN.Text.Remove(_lblEQN.Text.Length - 1);
            _lblEQN.Text += "/";
            try
            {
                cOperators.Add('/');
                dNums.Add(double.Parse(_txbNum.Text));
                _txbNum.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing value", "Error", MessageBoxButtons.OK);
                ClearBox();
            }
        }

        private void _btnMulti_Click(object sender, EventArgs e)
        {
            if (_lblEQN.Text.EndsWith("/") || _lblEQN.Text.EndsWith("*") || _lblEQN.Text.EndsWith("+") || _lblEQN.Text.EndsWith("-"))
                _lblEQN.Text = _lblEQN.Text.Remove(_lblEQN.Text.Length - 1);
            _lblEQN.Text += "*";
            try
            {
                cOperators.Add('*');
                dNums.Add(double.Parse(_txbNum.Text));
                _txbNum.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing value", "Error", MessageBoxButtons.OK);
                ClearBox();
            }
        }

        private void _btnSub_Click(object sender, EventArgs e)
        {
            if (_lblEQN.Text.EndsWith("/") || _lblEQN.Text.EndsWith("*") || _lblEQN.Text.EndsWith("+") || _lblEQN.Text.EndsWith("-"))
                _lblEQN.Text = _lblEQN.Text.Remove(_lblEQN.Text.Length - 1);
            _lblEQN.Text += "-";
            try
            {
                cOperators.Add('-');
                dNums.Add(double.Parse(_txbNum.Text));
                _txbNum.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing value", "Error", MessageBoxButtons.OK);
                ClearBox();
            }
        }

        private void _btnAdd_Click(object sender, EventArgs e)
        {
            if (_lblEQN.Text.EndsWith("/") || _lblEQN.Text.EndsWith("*") || _lblEQN.Text.EndsWith("+") || _lblEQN.Text.EndsWith("-"))
                _lblEQN.Text = _lblEQN.Text.Remove(_lblEQN.Text.Length - 1);
            _lblEQN.Text += "+";
            try
            {
                cOperators.Add('+');
                dNums.Add(double.Parse(_txbNum.Text));
                _txbNum.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing value", "Error", MessageBoxButtons.OK);
                ClearBox();
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var key = e.KeyCode;
            switch (e.KeyCode)
            {
                case Keys.D0:
                    _btn0.PerformClick();
                    break;

                case Keys.D1:
                    _btn1.PerformClick();
                    break;

                case Keys.D2:
                    _btn2.PerformClick();
                    break;

                case Keys.D3:
                    _btn3.PerformClick();
                    break;

                case Keys.D4:
                    _btn4.PerformClick();
                    break;

                case Keys.D5:
                    _btn5.PerformClick();
                    break;

                case Keys.D6:
                    _btn6.PerformClick();
                    break;

                case Keys.D7:
                    _btn7.PerformClick();
                    break;

                case Keys.D8:
                    _btn8.PerformClick();
                    break;

                case Keys.D9:
                    _btn9.PerformClick();
                    break;

                case Keys.OemPeriod:
                    _btnDec.PerformClick();
                    break;

                case Keys.Back:
                    _btnBack.PerformClick();
                    break;

                case Keys.C:
                    ClearBox();
                    break;

                case Keys.X:
                    _btnMulti.PerformClick();
                    break;

                case Keys.OemQuestion:
                    _btnDiv.PerformClick();
                    break;

                case Keys.OemMinus:
                    _btnSub.PerformClick();
                    break;

                case Keys.Oemplus:
                    _btnAdd.PerformClick();
                    break;

                case Keys.Enter:
                    _btnAns.PerformClick();                    
                    break;


                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _txbNum.Text = "0";
            this.ActiveControl = _txbNum;
        }

        private void ClearBox()
        {
            _txbNum.Clear();
            _lblEQN.Text = "";
            dNums.Clear();
            cOperators.Clear();
        }

        private string Calculate(string val)
        {
            var nums = val.Split(new[]{"+", "-", "*", "/"}, StringSplitOptions.None);
            for(int i = 0; i < nums.Length; ++i)
            {
                dNums.Add(double.Parse(nums[i]));
            }

            if (val.Contains("+"))
            {
                return dNums.Sum().ToString();
            }
            if (val.Contains("-"))
            {
                double Ans = dNums[0] - dNums[1];
                return Ans.ToString();
            }
            if (val.Contains("*"))
            {
                double Ans = dNums[0] * dNums[1];
                return Ans.ToString();
            }
            if (val.Contains("/"))
            {
                double Ans = dNums[0] / dNums[1];
                return Ans.ToString();
            }

            return "error";
        }
    }
}
