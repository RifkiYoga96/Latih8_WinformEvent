using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Latih8_WinformEvent
{
    public partial class Form1 : Form
    {

        private List<SiswaModel> listSiswa;
        private BindingSource bindingSource;
        public Form1()
        {
            InitializeComponent();
            GenerateData();
        }

        public void GenerateData()
        {
            listSiswa = new List<SiswaModel>
            {
                new SiswaModel("16666","Rifki Yoga",new DateTime(2006,2,3),"Laki-laki","Jl.Suko Mbahmu No.7,Bantul","RPL"),
                new SiswaModel("16668","Rifki Daffa",new DateTime(2006,2,3),"Laki-laki","Jl.Melati No.2 ,Bantul","TKJ"),
                new SiswaModel("16669","Ahmad Nur Zaman",new DateTime(2006,2,3),"Laki-laki","Jl.Suko Mbahmu No.4,Bantul","TKR"),
                new SiswaModel("16667","Beni Setyawan",new DateTime(2006,2,3),"Laki-laki","Jl.Yossudarso,Paten, Bantul","DKV"),
                new SiswaModel("16663","Mela Meliani",new DateTime(2006,2,3),"Perempuan","Jl.Mawar No.57,Sleman","TKJ"),
                new SiswaModel("16665","Yoga Setia Budi",new DateTime(2006,2,3),"Laki-laki","Jl.SukaMaju No.1 ,Bantul","AKL"),
            };

            bindingSource = new BindingSource();
            bindingSource.DataSource = listSiswa;

            comboBox1.Items.Add("Laki-laki");
            comboBox1.Items.Add("Perempuan");

            comboBox2.Items.Add("RPL");
            comboBox2.Items.Add("TKJ");
            comboBox2.Items.Add("TKR");
            comboBox2.Items.Add("DKV");
            comboBox2.Items.Add("AKL");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource;
            dataGridView1.Columns["NIS"].Width = 50;
            dataGridView1.Columns["Nama"].Width = 150;
            dataGridView1.Columns["TglLahir"].Width = 100;
            dataGridView1.Columns["Gender"].Width = 100;
            dataGridView1.Columns["Alamat"].Width = 150;
            dataGridView1.Columns["Jurusan"].Width = 100;
            dataGridView1.Columns["TglLahir"].DefaultCellStyle.Format = "dd-MM-yyyy";
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listSiswa.FirstOrDefault(x => x.NIS == textBox1.Text).Gender = comboBox1.Text;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var nis = dataGridView1.CurrentRow.Cells["NIS"].Value.ToString();
            var siswa = listSiswa.FirstOrDefault(x => x.NIS == nis);

            textBox1.Text = siswa.NIS;
            textBox2.Text = siswa.Nama;
            dateTimePicker1.Value = siswa.TglLahir;
            comboBox1.Text = siswa.Gender;
            textBox3.Text = siswa.Alamat;
            comboBox2.Text = siswa.Jurusan;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            listSiswa.FirstOrDefault(x => x.NIS == textBox1.Text).Nama = textBox2.Text;
            dataGridView1.Refresh();
        }

        private void textBox3_Validated(object sender, EventArgs e)
        {
            listSiswa.FirstOrDefault(x => x.NIS == textBox1.Text).Alamat = textBox3.Text;
            dataGridView1.Refresh();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            listSiswa.FirstOrDefault(x => x.NIS == textBox1.Text).TglLahir = dateTimePicker1.Value;
            dataGridView1.Refresh();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listSiswa.FirstOrDefault(x => x.NIS == textBox1.Text).Jurusan = comboBox2.Text;
            dataGridView1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dddd, dd-MM-yyyy";
        }
    }
}
