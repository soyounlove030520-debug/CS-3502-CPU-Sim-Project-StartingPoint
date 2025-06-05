using System;
using System.Drawing;
using System.Windows.Forms;

namespace CpuSchedulingWinForms
{
    public partial class CpuScheduler : Form
    {
        public CpuScheduler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dashBoardTab.Show();
            this.tabSelection.SelectTab(0);
            this.sidePanel.Height = btnDashBoard.Height;
            this.sidePanel.Top = btnDashBoard.Top;

        }

        private void btnCpuScheduler_Click(object sender, EventArgs e)
        {
            //this.dashBoardTab.Show();
            this.tabSelection.SelectTab(1);
            this.sidePanel.Height = btnCpuScheduler.Height;
            this.sidePanel.Top = btnCpuScheduler.Top;

        }


        private void btnFCFS_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.fcfsAlgorithm(txtProcess.Text);
                int numberOfProcess = Int16.Parse(txtProcess.Text);
                if (numberOfProcess <= 10)
                {
                    this.progressBar1.Increment(4); //cpu progress bar
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(13);
                    this.progressBar2.SetState(1);
                }
                else if (numberOfProcess > 10)
                {
                    this.progressBar1.Increment(15);
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(38); //memory progress bar
                    this.progressBar2.SetState(3);
                }

                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < numberOfProcess; i++)
                {
                    //listBoxProcess.Items.Add(" Process " + (i + 1));
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("-");
                    listView1.Items.Add(item);
                }
                //listBoxProcess.Items.Add("\n");
                //listBoxProcess.Items.Add(" Total number of processes executed: " + numberOfProcess);
                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles: " + numberOfProcess);
            }
            else
            {
                MessageBox.Show("Enter number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        private void btnSJF_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.sjfAlgorithm(txtProcess.Text);
                int numberOfProcess = Int16.Parse(txtProcess.Text);
                if (numberOfProcess <= 10)
                {
                    this.progressBar1.Increment(4); //cpu progress bar
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(13);
                    this.progressBar2.SetState(1);
                }
                else if (numberOfProcess > 10)
                {
                    this.progressBar1.Increment(15);
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(38); //memory progress bar
                    this.progressBar2.SetState(3);
                }

                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < numberOfProcess; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("-");
                    listView1.Items.Add(item);
                }

                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles: " + numberOfProcess);
            }
            else
            {
                MessageBox.Show("Enter number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        private void btnPriority_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.priorityAlgorithm(txtProcess.Text);
                int numberOfProcess = Int16.Parse(txtProcess.Text);
                if (numberOfProcess <= 10)
                {
                    this.progressBar1.Increment(4); //cpu progress bar
                    this.progressBar1.SetState(1);  //cpu color progress bar
                    this.progressBar2.Increment(13);
                    this.progressBar2.SetState(1);
                }
                else if (numberOfProcess > 10)
                {
                    this.progressBar1.Increment(15);
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(38); //memory progress bar
                    this.progressBar2.SetState(3);   //memory color progress bar
                }
                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < numberOfProcess; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("-");
                    listView1.Items.Add(item);
                }

                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles : " + numberOfProcess);
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

        private void restartApp_Click(object sender, EventArgs e)
        {
            this.Hide();
            CpuScheduler cpuScheduler = new CpuScheduler();
            cpuScheduler.ShowDialog();
        }



        private void CpuScheduler_Load(object sender, EventArgs e)
        {
            this.sidePanel.Height = btnDashBoard.Height;
            this.sidePanel.Top = btnDashBoard.Top;
            this.progressBar1.Increment(5);
            this.progressBar2.Increment(17);
            listView1.View = View.Details;
            listView1.GridLines = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Application.Exit();
            timer1.Start();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnRoundRobin_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.roundRobinAlgorithm(txtProcess.Text);
                int numberOfProcess = Int16.Parse(txtProcess.Text);
                if (numberOfProcess <= 10)
                {
                    this.progressBar1.Increment(4); //cpu progress bar
                    this.progressBar1.SetState(1);  //cpu color progress bar
                    this.progressBar2.Increment(13);
                    this.progressBar2.SetState(1);
                }
                else if (numberOfProcess > 10)
                {
                    this.progressBar1.Increment(15);
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(38); //memory progress bar
                    this.progressBar2.SetState(3);   //memory color progress bar
                }
                string quantumTime = Helper.QuantumTime;
                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < numberOfProcess; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add(quantumTime);
                    listView1.Items.Add(item);
                }

                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles: " + numberOfProcess);
            }
            else
            {
                MessageBox.Show("Enter number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.0)
            {
                this.Opacity -= 0.021;
            }
            else
            {
                timer1.Stop();
                Application.Exit();
            }
        }

    }
}