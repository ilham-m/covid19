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
    public partial class Form1 : Form
    {
        public string sqlnya;
        void isi_data()
        {
            Form3 f3 = new Form3();
            f3.name = NamaF1.Text;
        }
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
            Form2 f2 = new Form2();
            konek conec = new konek();
            conec.connect();
            conec.DA = new OleDbDataAdapter("SELECT * FROM tb_datacov", conec.conn);
            conec.DS = new DataSet();
            conec.DS.Clear();
            conec.DA.Fill(conec.DS, "tb_datacov");
            f2.dataGridView1.DataSource = conec.DS.Tables["tb_datacov"].DefaultView;
            f2.dataGridView1.Enabled = true;
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

        void hover()
        {
            Label_Menu.MouseHover += new System.EventHandler(hover);
            Label_lihatdata.MouseHover += new System.EventHandler(hover2);
            Label_isiform.MouseHover += new System.EventHandler(hover3);
            viruslabel.MouseHover += new System.EventHandler(hover4);
            formlabel.MouseHover += new System.EventHandler(hover5);
            datalabel.MouseHover += new System.EventHandler(hover6);
            Label_lihatdata.MouseLeave += new System.EventHandler(LostHover);
            panahleft.MouseDown += new System.Windows.Forms.MouseEventHandler(GotClick1);
            panahRight.MouseDown += new System.Windows.Forms.MouseEventHandler(GotClick2);
            Label_isiform.MouseLeave += LostHover;
            viruslabel.MouseLeave += LostHover;
            formlabel.MouseLeave += LostHover;
            datalabel.MouseLeave += LostHover;
            Label_Menu.MouseLeave += LostHover;
            datalabel.Click += Label_lihatdata_Click;
            panahleft.MouseUp += LostHover;
            panahRight.MouseUp += LostHover;
        }
        public Form1()
        {
            InitializeComponent();
            hover();
            formlabel.Click += new System.EventHandler(isiform_click);
            Label_isiform.Click += isiform_click;
        }
        private void GotClick1(object o, EventArgs e)
        {
            panahleft.BackColor = Color.Crimson;
        }
        private void GotClick2(object o, EventArgs e)
        {
            panahRight.BackColor = Color.Crimson;
        }
        private void hover(object sender , EventArgs e)
        {
            Label_Menu.ForeColor = Color.Crimson;
        }
        private void hover2(object sender, EventArgs e)
        {
            Label_lihatdata.ForeColor = Color.Crimson;
        }
        private void hover3(object sender, EventArgs e)
        {
            Label_isiform.ForeColor = Color.Crimson;
        }
        private void hover4(object sender, EventArgs e)
        {
            viruslabel.ForeColor = Color.Crimson;
        }
        private void hover5(object sender, EventArgs e)
        {
            formlabel.ForeColor = Color.Crimson;
        }
        private void hover6(object sender, EventArgs e)
        {
            datalabel.ForeColor = Color.Crimson;
        }
        private void LostHover(object sender, EventArgs e)
        {
            Label_lihatdata.ForeColor = Color.Orange;
            Label_isiform.ForeColor = Color.Orange;
            Label_Menu.ForeColor = Color.Orange;
            viruslabel.ForeColor = Color.Orange;
            formlabel.ForeColor = Color.Orange;
            datalabel.ForeColor = Color.Orange;
            panahRight.BackColor = Color.Transparent;
            panahleft.BackColor = Color.Transparent;
        }
        private void isiform_click(object sender, EventArgs a)
        {
            Panelisiform.Show();
            containerNAV.Hide();
            Panelisiform.Location = new System.Drawing.Point(131, 60);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Panelisiform.Hide();
        }

        private void Label_lihatdata_Click(object sender, EventArgs e)
        {
            
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void panahRight_Click(object sender, EventArgs e)
        {
            Panelform.Location = new System.Drawing.Point(Panelform.Location.X - 420, Panelform.Location.Y);
            Panelsiswa.Location = new System.Drawing.Point(Panelsiswa.Location.X - 420, Panelsiswa.Location.Y);
            Panelvirus.Location = new System.Drawing.Point(Panelvirus.Location.X - 420, Panelvirus.Location.Y);
        }

        private void panahleft_Click(object sender, EventArgs e)
        {
            Panelform.Location = new System.Drawing.Point(Panelform.Location.X + 420, Panelform.Location.Y);
            Panelsiswa.Location = new System.Drawing.Point(Panelsiswa.Location.X + 420, Panelsiswa.Location.Y);
            Panelvirus.Location = new System.Drawing.Point(Panelvirus.Location.X + 420, Panelvirus.Location.Y);
        }

        private void Mulai_Click(object sender, EventArgs e)
        {
            konek con = new konek();
            con.connect();
            con.CMD = new OleDbCommand("SELECT COUNT (NIS) FROM tb_datacov Where NIS  ='" + idF1.Text + "'",con.conn);
            int count = Convert.ToInt32(con.CMD.ExecuteScalar());
            if (count > 0)
            {
                MessageBox.Show("Peserta Dengan NIS "+ idF1.Text +"\ntelah Melakukan Pengisian Form");
            }
            else{
            if (NamaF1.Text == null || idF1.Text == null)
            {
                MessageBox.Show("Kolom Nama Dan NIS\nTidak Bisa Kosong", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
            string kirimNama, kirimID;
            kirimID = idF1.Text;
            kirimNama = NamaF1.Text;
            Form3 f1 = new Form3(kirimID,kirimNama);
            this.Hide();
            f1.Show();
                }
            }
        }

        private void Label_Menu_Click(object sender, EventArgs e)
        {
            Panelisiform.Hide();
            containerNAV.Show();
        }




    }
}
