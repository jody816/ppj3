using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ppj3
{
    public partial class 관리자_로그인 : Form
    {
        public 관리자_로그인()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "1" && textBox2.Text == "1")
            {            
                new 관리자_페이지().ShowDialog();             
            }
            else
            {
                MessageBox.Show("틀렸어용");
            }
        }
    }
}
