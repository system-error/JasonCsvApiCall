using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using Model;

namespace FrontView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CsvData_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int item = (int)comboBox1.SelectedItem;
            var fordatasource = Query.DisplaySpecificYears(item);

            bindingSource2.DataSource = fordatasource;
            dataGridView1.DataSource = bindingSource2;
        }

        private async void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var years = await Query.CollectTheYears();
                comboBox1.DataSource = years;
                comboBox1.DisplayMember = "years";
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
                dataGridView1.DataSource = bindingSource1;
            }
            //checkBox1.Checked =  checkBox1.Checked ? comboBox1.Enabled = true : comboBox1.Enabled = false;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = await Query.DisplayAllTheData();
        }


    }
}