using System;
using System.Windows.Forms;

namespace CpuSchedulingWinForms
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void fcfs_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.fcfsAlgorithm(txtProcess.Text);
            }
            else
            {
                MessageBox.Show("Enter number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }

        }


        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.sjfAlgorithm(txtProcess.Text);
            }
            else
            {
                MessageBox.Show("Enter number of processes ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        private void btnPriority_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.priorityAlgorithm(txtProcess.Text);
            }
            else
            {
                MessageBox.Show("Enter number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        private void txtProcess_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
