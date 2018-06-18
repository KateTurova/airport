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
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }

        string id;
        public string ID
        {
            set { id = value; }
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

            {
                using (SqlDataReader dr = myCommand.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dt.Load(dr);
                    }
                }
            }

            return dt;
        }

        private void add_Load(object sender, EventArgs e)
        {
            string Connect = "Data Source=DESKTOP-M94P5FV; Initial Catalog=airport_db;Integrated Security=true;";
            myConnection = new SqlConnection(Connect);
            textBox2.Text = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text=="" || comboBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "" || comboBox6.Text == "" || comboBox7.Text == "")
            {
                MessageBox.Show("Запонить пустые поля!!!");
                return;
            }
         
            string s1 = comboBox1.Text;
            string s2 = comboBox2.Text;

            string d = comboBox3.Text;
            string m = comboBox4.Text;
            string y = comboBox5.Text;

            string chas = comboBox6.Text;
            string minut = comboBox7.Text;

            string city = s1+" --> "+s2;

            string data = d +"."+ m + "." + y;

            string time = chas + ":"+minut;
            
            string id = textBox2.Text;
            int id_reis = Convert.ToInt32(id, 16);

            string myCommand = "INSERT INTO table1 (ID_рейса, Название_рейса, Дата, Время, Кол_во_пасажирова, N_самолета) Values ('" + id_reis + "', '" + city + "', '"+ data + "', '"+time+"', '" + textBox3.Text + "', '" + textBox4.Text + "');";
            Table(myCommand);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}