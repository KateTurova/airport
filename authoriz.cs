using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace airport
{
    public partial class authoriz : Form
    {
        public authoriz()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "kate" && textBox2.Text == "1234")
            {
                home h = new home();
                h.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Неверный пароль !!!");
                textBox1.Clear();
                textBox2.Clear();
                return;
            }
            
        }
    }
}
