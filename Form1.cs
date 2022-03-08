using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicApp
{
    public partial class Form1 : Form
    {
        DataTable dtClinic = new DataTable();

        DataTable dtDoctor = new DataTable();
        DataTable dtSpecificClinicDoctors = new DataTable();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filClinicTable();
            filDoctorTable();

            comboBox1.DataSource = dtClinic;
            comboBox1.DisplayMember = "cName";

            comboBox2.DataSource = dtDoctor;
            comboBox2.DisplayMember = "DName";
        }
            private void filClinicTable()
        {
            dtClinic.Columns.Add("CID", typeof(int));
            dtClinic.Columns.Add("CName");
            dtClinic.Columns.Add("CAddress");
            dtClinic.Columns.Add("CRating");

            dtClinic.Rows.Add(1,"Dentist Clinic","chennai","5");
            dtClinic.Rows.Add(2, "therapist Clinic", "chennai", "7");
            dtClinic.Rows.Add(3, "general Clinic", "chennai", "9");
            dtClinic.Rows.Add(4, "brain Clinic", "chennai", "9");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = dtClinic.Rows[comboBox1.SelectedIndex]["CID"].ToString();
            label3.Text = dtClinic.Rows[comboBox1.SelectedIndex]["cName"].ToString();
            label4.Text = dtClinic.Rows[comboBox1.SelectedIndex]["cAddress"].ToString();
            label5.Text = dtClinic.Rows[comboBox1.SelectedIndex]["cRating"].ToString();

            dtSpecificClinicDoctors = dtDoctor.Select("CID = " + dtClinic.Rows[comboBox1.SelectedIndex]["CID"]).CopyToDataTable();
            comboBox2.DataSource = dtSpecificClinicDoctors;
            comboBox2.DisplayMember = "DName";
        }

        private void filDoctorTable()
        {
            dtDoctor.Columns.Add("CID", typeof(int));
            dtDoctor.Columns.Add("DName");
            dtDoctor.Columns.Add("DAddress");
            dtDoctor.Columns.Add("DContact");

            dtDoctor.Rows.Add(1, "Dr.Aishu", "chennai", "9892148985");
            dtDoctor.Rows.Add(2, "Dr.shan", "chennai", "7385870392");
            dtDoctor.Rows.Add(3, "Dr.Raj", "chennai", "9787997679");
            dtDoctor.Rows.Add(4, "Dr.Vikranth", "chennai", "9470158360");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Text = dtSpecificClinicDoctors.Rows[comboBox2.SelectedIndex]["CID"].ToString();
            label8.Text = dtSpecificClinicDoctors.Rows[comboBox2.SelectedIndex]["DName"].ToString();
            label9.Text = dtSpecificClinicDoctors.Rows[comboBox2.SelectedIndex]["DAddress"].ToString();
            label10.Text = dtSpecificClinicDoctors.Rows[comboBox2.SelectedIndex]["DContact"].ToString();
        }
    }
    }

