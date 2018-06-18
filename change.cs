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
    public partial class change : Form
    {
        public change()
        {
            InitializeComponent();
        }

        List<string> t1;
        public List<string> t2
        {
            set { t1 = value; }
        }

        SqlConnection myConnection;
        private DataTable Table(string command)
        {
            DataTable dt = new DataTable();
            SqlCommand myCommand = new SqlCommand(command, myConnection);
            try
            {
                myConnection.Open();
            }
            catch { }

            using (SqlDataReader dr = myCommand.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
            }
            return dt;
        }

        private void change_Load(object sender, EventArgs e)
        {
            textBox2.Text = t1[0];
            string split = t1[1];
            string[] words = split.Split(new char[] { ' ' });
            foreach (string s in words)
            {
                comboBox1.Text = words[0];
                comboBox2.Text = words[2];
            }

            string data_split = t1[2];
            string[] words1 = data_split.Split(new char[] { '.' });
            foreach (string s in words1)
            {
                comboBox3.Text = words1[0];
                comboBox4.Text = words1[1];
                comboBox5.Text = words1[2];
            }

            string time_split = t1[3];
            string[] words2 = time_split.Split(new char[] { ':' });
            foreach (string s in words2)
            {
                comboBox6.Text = words2[0];
                comboBox7.Text = words2[1];
            }
            textBox3.Text = t1[4];
            textBox4.Text = t1[5];

            string Connect = "Data Source=DESKTOP-M94P5FV; Initial Catalog=airport_db;Integrated Security=true;";
            myConnection = new SqlConnection(Connect);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "" || comboBox6.Text == "" || comboBox7.Text == "")
            {
                MessageBox.Show("Запонить пустые поля !!!");
                return;
            }

            string s1 = comboBox1.Text;
            string s2 = comboBox2.Text;

            string d = comboBox3.Text;
            string m = comboBox4.Text;
            string y = comboBox5.Text;

            string chas = comboBox6.Text;
            string minut = comboBox7.Text;

            string city = s1 + " --> " + s2;
            string data = d + "." + m + "." + y;
            string time = chas + ":" + minut;

            string id = textBox2.Text;
            int id_reis = Convert.ToInt32(id, 16);

            string update = "UPDATE table1 SET Название_рейса = '" + city + "', Дата = '"+data+ "', Время = '" + time + "', Кол_во_пасажирова = '" + textBox3.Text + "', N_самолета = '" + textBox4.Text + "' WHERE table1.ID_рейса = '" + textBox2.Text + "';";
            Table(update);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
