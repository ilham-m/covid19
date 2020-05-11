using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Test_1_Csharp
{
    public partial class Form2 : Form
    {
        public string sqlnya;
        public string nama;
        public class konek
        {
            public OleDbConnection conn;
            public OleDbDataAdapter DA;
            public DataSet DS;
            public OleDbCommand CMD;
            public void connect()
            {
                conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|/datacov.mdb");
                conn.Open();
            }
        }
        void panggildata()
        {
            konek conec = new konek();
            conec.connect();
            conec.DA = new OleDbDataAdapter("SELECT * FROM tb_datacov", conec.conn);
            conec.DS = new DataSet();
            conec.DS.Clear();
            conec.DA.Fill(conec.DS, "tb_datacov");
            dataGridView1.DataSource = conec.DS.Tables["tb_datacov"].DefaultView;
            dataGridView1.Enabled = true;
        }
        public void run()
        {
            konek conec = new konek();
            conec.connect();
            OleDbCommand objcmd = new OleDbCommand();
            objcmd.CommandType = CommandType.Text;
            objcmd.CommandText = sqlnya;
            objcmd.Connection = conec.conn;
            objcmd.ExecuteNonQuery();
            objcmd.Dispose();
        }
        void dataBase_Function()
        {
            cari.LostFocus += new System.EventHandler(refresh_data);
            cari2.LostFocus += refresh_data;
            button1.LostFocus += refresh_data;
            cari2.LostFocus += refresh_data;
            button3.LostFocus += refresh_data;
            dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(ambil_data_dariTB);
        }
        void hover()
        {
            Label_Menu.MouseHover += new System.EventHandler(hover);
            Label_lihatData.MouseHover += new System.EventHandler(hover2);
            Label_isiForm.MouseHover += new System.EventHandler(hover3);
            Label_lihatData.MouseLeave += new System.EventHandler(LostHover);
            Label_isiForm.MouseLeave += LostHover;
            Label_Menu.MouseLeave += LostHover;

        }

        public Form2()
        {
            InitializeComponent();
            dataBase_Function();
            hover();
        }
        private void hover(object sender, EventArgs e)
        {
            Label_Menu.ForeColor = Color.Crimson;
        }
        private void hover2(object sender, EventArgs e)
        {
            Label_lihatData.ForeColor = Color.Crimson;
        }
        private void hover3(object sender, EventArgs e)
        {
            Label_isiForm.ForeColor = Color.Crimson;
        }
        private void LostHover(object sender, EventArgs e)
        {
            Label_lihatData.ForeColor = Color.Orange;
            Label_isiForm.ForeColor = Color.Orange;
            Label_Menu.ForeColor = Color.Orange;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panggildata();
        }

        private void cariNIS(object sender, EventArgs e)
        {
            konek con = new konek();
            con.connect();
            con.DA = new OleDbDataAdapter("SELECT * from tb_datacov where NIS like '" + cari.Text + "'", con.conn);
            con.DS = new DataSet();
            con.DS.Clear();
            con.DA.Fill(con.DS, "tb_datacov");
            dataGridView1.DataSource = con.DS.Tables["tb_datacov"].DefaultView;
        }
        private void refresh_data(object sender, EventArgs e)
        {
            panggildata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            konek con = new konek();
            con.connect();
            con.DA = new OleDbDataAdapter("SELECT * from tb_datacov where Nama like '" + cari2.Text + "'", con.conn);
            con.DS = new DataSet();
            con.DS.Clear();
            con.DA.Fill(con.DS, "tb_datacov");
            dataGridView1.DataSource = con.DS.Tables["tb_datacov"].DefaultView;
        }
        private void ambil_data_dariTB(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            ID1.Text = (string)dataGridView1[0, i].Value;
            Nama1.Text = (string)dataGridView1[1, i].Value;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            konek con = new konek();
            con.connect();
            if (Nama1.Text == null || ID1.Text == null || Nama1.Text == "" || ID1.Text == "")
            {
                MessageBox.Show("Isi Kolom Nama Dan No handphone dengan benar", "informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            sqlnya = String.Format("delete * from tb_datacov where NIS ='" + ID1.Text + "' and Nama ='" + Nama1.Text + "'");
            run();
            panggildata();
        }

        private void Label_Menu_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Close();
            f1.Show();
        }

        private void Label_isiForm_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Close();
            f1.Show();
            f1.Panelisiform.Show();
            f1.containerNAV.Hide();
            f1.Panelisiform.Location = new System.Drawing.Point(131, 60);
        }

    }
}