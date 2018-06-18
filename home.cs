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
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
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

        private void home_Load(object sender, EventArgs e)// загрузка на отображение
        {
            string Connect = "Data Source=DESKTOP-M94P5FV; Initial Catalog=airport_db;Integrated Security=true;";
            myConnection = new SqlConnection(Connect);
            string CommandText = "select * from table1";
            dataGridView1.DataSource = Table(CommandText);
        }

        private void button1_Click(object sender, EventArgs e)// добавление
        {
            add f3 = new add();
            int id = Int32.Parse(dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Value.ToString()) + 1;
            f3.ID = id.ToString();
            f3.ShowDialog();
            string CommandText = "select * from table1";
            dataGridView1.DataSource = Table(CommandText);
        }

        private void button3_Click(object sender, EventArgs e)// удаление
        {
            int nom = dataGridView1.CurrentRow.Index;

            string id = dataGridView1.Rows[nom].Cells[0].Value.ToString();
            string DeleteCom = "DELETE FROM table1 WHERE table1.ID_рейса = " + id + ";";
            Table(DeleteCom);

            string CommandText = "select * from table1";
            dataGridView1.DataSource = Table(CommandText);
        }

        private void button2_Click(object sender, EventArgs e)// поиск
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Запонить пустые поля !!!");
                return;
            }
            string poisk = textBox1.Text;
            int k = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value.ToString() == poisk)
                    {
                        dataGridView1.Rows[i].Selected = true;
                        k++;
                    }
                }
            }
            if (k == 0)
            { MessageBox.Show("Не найдено !!!"); }
        }

        int nom;
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)// изменение
        {
            nom = dataGridView1.CurrentRow.Index;
            change p1 = new change();
            List<string> t1 = new List<string>();
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                t1.Add(dataGridView1.Rows[nom].Cells[i].Value.ToString());
            p1.t2 = t1;
            p1.ShowDialog();

            string CommandText = "select * from table1";
            dataGridView1.DataSource = Table(CommandText);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}