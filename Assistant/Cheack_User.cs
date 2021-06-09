using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistant
{
    public partial class Cheack_User : Form
    {
        public Cheack_User()
        {
            InitializeComponent();
        }
        string date = Get_UTC_Time.GetStandardTime().ToString();
        Password pwd_list = new Password();
        bool suc = false;
        private void cheack_user_but_pwd_Click(object sender, EventArgs e)
        {
            string pwd = cheack_user_pwd_box.Text;
            if (pwd != "")
            {
                pwd = Processing_chars.Filter_chars(0, pwd);
            }
            else
            {
                MessageBox.Show("密码为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            //Console.WriteLine(date);
            
            switch (date)
            {
                case "202106":
                    suc = pwd == pwd_list.Ym202106 ? true : false;
                    break;
                case "202107":
                    suc = pwd == pwd_list.Ym202107 ? true : false;
                    break;
                case "202108":
                    suc = pwd == pwd_list.Ym202108 ? true : false;
                    break;
                default:
                    suc = false;
                    break;
            }
            if (suc)
            {
                Close();
            }
            else
            {
                MessageBox.Show("密码错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            
        }

        private void Cheack_User_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!suc)
                Application.Exit();
        }
    }
}
