using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev
{
    public partial class Form1 : Form
    {
        public List<string> Opr = new List<string>();  
        public List<double> TempVal = new List<double>();                              
        public bool IsValid = false, IsOk = false, ForNegativeNum = true, DividingZero = false;
        public string Keep = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public void OperationProcess(string tt)
        {
            switch (tt)
            {
                case "+":
                    Keep = Convert.ToString(TempVal[0] + TempVal[1]);
                    TempVal.Clear();
                    break;
                case "-":
                    Keep = Convert.ToString(TempVal[0] - TempVal[1]);
                    TempVal.Clear();
                    break;
                case "*":
                    Keep = Convert.ToString(TempVal[0] * TempVal[1]);
                    TempVal.Clear();
                    break;
                case "/":
                    if (TempVal[1] != 0)
                    {
                        Keep = Convert.ToString(TempVal[0] / TempVal[1]);
                        TempVal.Clear();
                    }
                    else
                        DividingZero = true;
                    break;
                case "^":
                    Keep = Convert.ToString(Math.Pow( TempVal[0], TempVal[1]));
                    TempVal.Clear();
                    break;
            }
        }
        private void btn_topla_Click(object sender, EventArgs e)
        {
            RepeitedPlace("+");
        }
        private void btn_cikar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                RepeitedPlace("-");
            }
            else if (ForNegativeNum && (txt_giris.Text == string.Empty) || (txt_giris.Text == "Sıfıra bölme hatası"))
            {
                txt_giris.Text = string.Empty;
                lbl_islemler.Text = string.Empty;
                Keep = string.Empty;
                IsOk = false;
                Keep += "-";
                lbl_islemler.Text += "-";
                txt_giris.Text += "-";
                ForNegativeNum = false;
            }
        }

        private void btn_esit_Click(object sender, EventArgs e)
        {
            if (Opr.Count > 0 && IsValid)
            {
                TempVal.Add(double.Parse(Keep));
                OperationProcess(Opr[0]);
                if (DividingZero)
                {
                    Keep = string.Empty;
                    txt_giris.Text = "Sıfıra bölme hatası";
                    lbl_islemler.Text = string.Empty;
                    Opr.Clear();
                    TempVal.Clear();
                    IsOk = true; // en son ki hata mesajını silmek için
                    ForNegativeNum = true;
                    IsValid = false;
                    DividingZero = false;
                }
                else
                {
                    txt_giris.Text = Keep; // buradaki tut sifirlanmadi cunku bu aslinda sonuctu.
                    Opr.Remove(Opr[0]);
                    IsOk = true;
                    IsValid = true;
                }

            }
        }
        private void btn_c_Click(object sender, EventArgs e)
        {
            
            Keep = string.Empty;
            txt_giris.Text = string.Empty;
            lbl_islemler.Text = string.Empty;
            Opr.Clear();
            TempVal.Clear();
            IsOk = false;
            ForNegativeNum = true;
            IsValid = false;
            DividingZero = false;
        }
        private void btn_carp_Click(object sender, EventArgs e)
        {
            RepeitedPlace("*");
        }
        private void btn_bol_Click(object sender, EventArgs e)
        {
            RepeitedPlace("/");
        }
        private void RepeitedPlace(string sign)
        {
            if (IsValid)
            {
                IsOk = false;
                TempVal.Add(double.Parse(Keep));
                Keep = string.Empty;
                lbl_islemler.Text += sign;
                Opr.Add(sign);
                if (Opr.Count > 1)
                {
                    OperationProcess(Opr[0]);
                    if (DividingZero)
                    {
                        Keep = string.Empty;
                        txt_giris.Text = "Sıfıra bölme hatası";
                        lbl_islemler.Text = string.Empty;
                        Opr.Clear();
                        TempVal.Clear();
                        IsOk = true; // en son ki hata mesajını silmek için
                        ForNegativeNum = true;
                        IsValid = false;
                        DividingZero = false;
                    }
                    else
                    {
                        TempVal.Add(double.Parse(Keep));
                        txt_giris.Text = Keep + sign;
                        Keep = string.Empty;
                        Opr.Remove(Opr[0]);
                    }

                }
                else
                {
                    txt_giris.Text += sign;
                }
                IsValid = false;

            }
        }
        private void btn_kareal_Click(object sender, EventArgs e)
        {
            RepeitedPlace("^");
        }
        private void btn_kokal_Click(object sender, EventArgs e)
        {
            double ress = 0;
            ForSquareRoot ss = new ForSquareRoot(this);
            this.Hide();
            ss.ShowDialog();
            try
            {
                ress = Math.Pow(double.Parse(ss.textBox2.Text), 1.0 / double.Parse(ss.textBox1.Text));
            }
            catch (Exception)
            {
                ress = 0;
                
            }
            if (IsOk)
            {
                txt_giris.Text = string.Empty;
                lbl_islemler.Text = string.Empty;
                Keep = string.Empty;
                IsOk = false;
            }
            Keep += ress.ToString();
            lbl_islemler.Text += ress.ToString();
            txt_giris.Text += ress.ToString();
            IsValid = true;
        }
        private void btn_virgul_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Keep += ".";
                lbl_islemler.Text += ".";
                txt_giris.Text += ".";
                IsValid = false;
            }
        }
        private void btn_ce_Click(object sender, EventArgs e)
        {
            if (lbl_islemler.Text.Length > 0)
            {
                lbl_islemler.Text = lbl_islemler.Text.Remove(lbl_islemler.Text.Length - 1);
            }
        }
        private void btn_1_Click(object sender, EventArgs e)
        {
            if (IsOk)
            {
                txt_giris.Text = string.Empty;
                lbl_islemler.Text = string.Empty;
                Keep = string.Empty;
                IsOk = false;
            }
            Keep += "1";
            lbl_islemler.Text += "1";
            txt_giris.Text += "1";
            IsValid = true;
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            if (IsOk)
            {
                txt_giris.Text = string.Empty;
                lbl_islemler.Text = string.Empty;
                lbl_isim.Text += ",";
                Keep = string.Empty;
                IsOk = false;
            }
            Keep += "2";
            lbl_islemler.Text += "2";
            txt_giris.Text += "2";
            IsValid = true;
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            if (IsOk)
            {
                txt_giris.Text = string.Empty;
                lbl_islemler.Text = string.Empty;
                Keep = string.Empty;
                IsOk = false;
            }
            Keep += "3";
            lbl_islemler.Text += "3";
            txt_giris.Text += "3";
            IsValid = true;
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            if (IsOk)
            {
                txt_giris.Text = string.Empty;
                lbl_islemler.Text = string.Empty;
                Keep = string.Empty;
                IsOk = false;
            }
            Keep += "4";
            lbl_islemler.Text += "4";
            txt_giris.Text += "4";
            IsValid = true;
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            if (IsOk)
            {
                txt_giris.Text = string.Empty;
                lbl_islemler.Text = string.Empty;
                Keep = string.Empty;
                IsOk = false;
            }
            Keep += "5";
            lbl_islemler.Text += "5";
            txt_giris.Text += "5";
            IsValid = true;
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            if (IsOk)
            {
                txt_giris.Text = string.Empty;
                lbl_islemler.Text = string.Empty;
                Keep = string.Empty;
                IsOk = false;
            }
            Keep += "6";
            lbl_islemler.Text += "6";
            txt_giris.Text += "6";
            IsValid = true;
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            if (IsOk)
            {
                txt_giris.Text = string.Empty;
                lbl_islemler.Text = string.Empty;
                Keep = string.Empty;
                IsOk = false;
            }
            Keep += "7";
            lbl_islemler.Text += "7";
            txt_giris.Text += "7";
            IsValid = true;
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            if (IsOk)
            {
                txt_giris.Text = string.Empty;
                lbl_islemler.Text = string.Empty;
                Keep = string.Empty;
                IsOk = false;
            }
            Keep += "8";
            lbl_islemler.Text += "8";
            txt_giris.Text += "8";
            IsValid = true;
        }


        private void btn_9_Click(object sender, EventArgs e)
        {
            if (IsOk)
            {
                txt_giris.Text = string.Empty;
                lbl_islemler.Text = string.Empty;
                Keep = string.Empty;
                IsOk = false;
            }
            Keep += "9";
            lbl_islemler.Text += "9";
            txt_giris.Text += "9";
            IsValid = true;
        }
        private void btn_0_Click(object sender, EventArgs e)
        {
            if (IsOk)
            {
                txt_giris.Text = string.Empty;
                lbl_islemler.Text = string.Empty;
                Keep = string.Empty;
                IsOk = false;
            }
            Keep += "0";
            lbl_islemler.Text += "0";
            txt_giris.Text += "0";
            IsValid = true;
        }

        
    }
}
