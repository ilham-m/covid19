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
    public partial class Form3 : Form
    {
        public Form1 f1 = new Form1();
        public int safe, risk, i;
        public string sakit, saran, saran1;
        public string[] soal;
        public string name,id;
        
        void isidatabox()
        {

            nama.Text = name;
            idtxtbox.Text = id;
            resiko.Text = sakit;
            resiko.BackColor = TextBox1.BackColor;
            advice.Text = saran + "\n" + saran1;
            ya.Text = risk.ToString();
            gak.Text = safe.ToString();
            resiko.Enabled = false;
            nama.Enabled = false;
            idtxtbox.Enabled = false;
            ya.Enabled = false;
            gak.Enabled = false;
        }
        void hasil_Akhir()
        {
            GroupBox2.Hide();
            TextBox1.Hide();
            Label2.Text = "Selesai";
            Button1.Enabled = false;
            Button1.Hide();
            Button2.Enabled = false;
            Data.Enabled = false;
            Button2.Show();
            Data.Show();
            Button2.Location = new System.Drawing.Point(569, 275);
        }
        void quit_kedata()
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }
        void quit_kemenu()
        {
            f1.Show();
            this.Close();
        }
        public string sqlnya;
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

        public Form3()
        {
            InitializeComponent();
            opsi1.MouseHover += new System.EventHandler(hover_opsi);
            opsi1.MouseLeave += new System.EventHandler(lost_Hover);
            
        }
        public Form3(String iden, String nama1)
            :this()
        {
            name = nama1;
            id = iden;
        }
        private void hover_opsi(object send, EventArgs e)
        {
            opsi1.BackColor = Color.DarkCyan;
        }
        private void lost_Hover(object send, EventArgs e)
        {
            opsi1.BackColor = Color.Transparent;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            konek con = new konek();
            con.connect();
            Menu1.Hide();
            lihatData.Hide();
            soal = new string[23];
            soal[0] = "saya pergi keluar rumah";
            soal[1] = "saya menggunakan transportasi umum : online,angkot,Taxi,Bus,Kereta";
            soal[2] = "saya Tidak Memakai Masker pada saat berkumpul dengan orang lain";
            soal[3] = "Saya berjabat tangan dengan orang lain";
            soal[4] = "Saya tidak membersihkan tangan dengan handsanitizer/tissue basah sebelum memegang gagang motor atau stir mobil";
            soal[5] = "Saya menyentuh benda / uang yang juga disentuh orang lain";
            soal[6] = "Saya tidak berjarak 1,5 meter dengan orang lain ketika : berbelanja, berkumpul, bekerja,DLL";
            soal[7] = "Saya makan di luar rumah (warung/restoran)";
            soal[8] = "Saya tidak minum hangat / tidak mencuci tangan ketika tiba di tujuan";
            soal[9] = "Saya berada di Redzone (daerah penularan covid-19)";
            soal[10] = "Saya Tidak pasang handsanitizer di depan pintu masuk, untuk membersihkan tangan sebelum memegang gagan pintu masuk";
            soal[11] = "Saya Tidak Mencuci Tangan Dengan sabun setelah tiba di rumah";
            soal[12] = "Saya tidak menyediakan : Tissu Basah, Handsanitizer, Masker, Sabun antiseptic bagi keluarga di rumah";
            soal[13] = "Saya tidak segera merendam baju & celana bekas pakai di luar rumah ke dalam airpanas / air sabun";
            soal[14] = "Saya tidak segera mandi setelah tiba di rumah";
            soal[15] = "Saya tidak mensosialisasikan sensus ini kepada keluarga ???!!!";
            soal[16] = "Saya dalam sehari tidak kena cahaya matahari (minimal 15 menit)";
            soal[17] = "Saya tidak berolahraga (Minimal 30 menit)";
            soal[18] = "Saya jarang Minum Vit C & E dan kurang tidur";
            soal[19] = "Usia Saya Diatas 60 Tahun";
            soal[20] = "Saya mempunyai penyakit kronis (diabetes/kanker/jantung/gangguan pernafasan kronik)";
            soal[21] = "SELESAI";
            soal[22] = "Tekan lanjut untuk Mulai";
            Label1.Text = soal[22];
            Label2.Text = "";
            RadioButton1.Enabled = false;
            RadioButton2.Enabled = false;
            Button2.Enabled = false;
            TextBox1.Enabled = false;
            Menu1.Hide();
            hasilAkhir.Hide();
            Button2.Hide();
            opsi2.Hide();
            lihatData.Hide();
            Data.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RadioButton1.Enabled = true;
            RadioButton2.Enabled = true;
            Label2.Text = "Soal No : " + (i + 1);
            Label1.Text = soal[i];
            if (RadioButton1.Checked == true)
            {
                risk += 1;
            }
            else if (RadioButton2.Checked == true)
            {
                safe += 1;
            }

            if (risk <= 7)
            {
                saran = "Pertahankan terus Hidup sehat-MU";
                sakit = "Rendah";
            }
            else if (risk <= 14)
            {
                saran = "Tingkatkan lagi Pola hidup sehat-MU";
                saran1 = "Jika Kondisi Kurang Baik Segera Lakukan Medical CheckUp";
                sakit = "Sedang";
                TextBox1.BackColor = Color.Yellow;
            }
            else
            {
                saran = "segera lakukan Medical CheckUp";
                saran1 = "";
                sakit = "Tinggi";
                TextBox1.BackColor = Color.OrangeRed;
            }

            if (i >= 10)
            {
                GroupBox1.Text = "Potensi Tertular Di Rumah";
            }

            if (i >= 16)
            {
                GroupBox1.Text = "IMUNE/Daya Tahan Tubuh";
            }
            if (i == 20)
            {
                Button1.Text = "Selesai";
            }
            if (i > 20)
            {
                isidatabox();
                hasil_Akhir();
                hasilAkhir.Show();
                MessageBox.Show("Anda beresiko " + sakit + " terpapar virus covid-19 \n" + saran + "\n" + saran1, "Hasil");

            }
            TextBox1.Text = sakit;
            i++;
        }

        private void Data_Click(object sender, EventArgs e)
        {
            quit_kedata();
        }

        private void simpan_btn_Click(object sender, EventArgs e)
        {
            sqlnya = string.Format("insert into tb_datacov(NIS,Nama,Resiko_Terkena_Covid,Total_Jawaban_Ya)values('{0}','{1}','{2}','{3}')",id,name,TextBox1.Text,risk);
            run();
            panggildata();
            MessageBox.Show("Berhasil Disimpan", "Informasi");
            Data.Enabled = true;
            Button2.Enabled = true;
            simpan_btn.Enabled = false;
        }

        private void opsi1_Click(object sender, EventArgs e)
        {
            Menu1.Show();
            lihatData.Show();
            opsi1.Hide();
            opsi2.Show();
            opsi2.Location = new System.Drawing.Point(3, 3);
        }

        private void opsi2_Click(object sender, EventArgs e)
        {
            Menu1.Hide();
            lihatData.Hide();
            opsi2.Hide();
            opsi1.Show();
        }

        private void Menu1_Click(object sender, EventArgs e)
        {
            DialogResult jawab = MessageBox.Show("Jika Anda Meninggalkan Laman Ini\nSemua data yang telah diisi akan hilang", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (jawab == DialogResult.Yes)
            {
                quit_kemenu();
            }
    }

        private void lihatData_Click(object sender, EventArgs e)
        {
            DialogResult jawab = MessageBox.Show("Jika Anda Meninggalkan Laman Ini\nSemua data yang telah diisi akan hilang", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (jawab == DialogResult.Yes)
            {
                quit_kedata();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            quit_kemenu();
        }
    }
}