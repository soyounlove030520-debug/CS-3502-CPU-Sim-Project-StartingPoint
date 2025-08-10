using System;
using System.Drawing;
using System.Windows.Forms;

namespace CpuScheduler
{
    /// <summary>
    /// Main form for demonstrating CPU scheduling algorithms.
    /// </summary>
    public partial class CpuSchedulerForm : Form
    {
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="CpuSchedulerForm"/> class.
        /// </summary>
        public CpuSchedulerForm()
        {
            InitializeComponent();
            EnableFormDragging();
        }

        /// <summary>
        /// Enables dragging the borderless form.
        /// </summary>
        private void EnableFormDragging()
        {
            MouseDown += Form_MouseDown;
            MouseMove += Form_MouseMove;
            MouseUp += Form_MouseUp;
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursor = Cursor.Position;
                lastForm = Location;
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentCursor = Cursor.Position;
                Point offset = new Point(currentCursor.X - lastCursor.X, currentCursor.Y - lastCursor.Y);
                Location = new Point(lastForm.X + offset.X, lastForm.Y + offset.Y);
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        /// <summary>
        /// Handles dashboard navigation.
        /// </summary>
        private void DashBoardButton_Click(object sender, EventArgs e)
        {
            //dashBoardTab.Show();
            tabSelection.SelectTab(0);
            sidePanel.Height = btnDashBoard.Height;
            sidePanel.Top = btnDashBoard.Top;

        }

        /// <summary>
        /// Navigates to the CPU scheduler tab.
        /// </summary>
        private void CpuSchedulerButton_Click(object sender, EventArgs e)
        {
            //dashBoardTab.Show();
            tabSelection.SelectTab(1);
            sidePanel.Height = btnCpuScheduler.Height;
            sidePanel.Top = btnCpuScheduler.Top;

        }


        /// <summary>
        /// Executes the First-Come, First-Served algorithm.
        /// </summary>
        private void FirstComeFirstServeButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtProcess.Text, out int processCount) && processCount > 0)
            {
                Algorithms.RunFirstComeFirstServe(txtProcess.Text);
                if (processCount <= 10)
                {
                    progressBar1.Increment(4); //cpu progress bar
                    progressBar1.SetState(1);
                    progressBar2.Increment(13);
                    progressBar2.SetState(1);
                }
                else if (processCount > 10)
                {
                    progressBar1.Increment(15);
                    progressBar1.SetState(1);
                    progressBar2.Increment(38); //memory progress bar
                    progressBar2.SetState(3);
                }

                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < processCount; i++)
                {
                    //listBoxProcess.Items.Add(" Process " + (i + 1));
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("-");
                    listView1.Items.Add(item);
                }
                //listBoxProcess.Items.Add("\n");
                //listBoxProcess.Items.Add(" Total number of processes executed: " + processCount);
                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles: " + processCount);
            }
            else
            {
                MessageBox.Show("Enter a valid number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        /// <summary>
        /// Executes the Shortest Job First algorithm.
        /// </summary>
        private void ShortestJobFirstButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtProcess.Text, out int processCount) && processCount > 0)
            {
                Algorithms.RunShortestJobFirst(txtProcess.Text);
                if (processCount <= 10)
                {
                    progressBar1.Increment(4); //cpu progress bar
                    progressBar1.SetState(1);
                    progressBar2.Increment(13);
                    progressBar2.SetState(1);
                }
                else if (processCount > 10)
                {
                    progressBar1.Increment(15);
                    progressBar1.SetState(1);
                    progressBar2.Increment(38); //memory progress bar
                    progressBar2.SetState(3);
                }

                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < processCount; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("-");
                    listView1.Items.Add(item);
                }

                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles: " + processCount);
            }
            else
            {
                MessageBox.Show("Enter a valid number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        /// <summary>
        /// Executes the Priority algorithm.
        /// </summary>
        private void PriorityButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtProcess.Text, out int processCount) && processCount > 0)
            {
                Algorithms.RunPriorityScheduling(txtProcess.Text);
                if (processCount <= 10)
                {
                    progressBar1.Increment(4); //cpu progress bar
                    progressBar1.SetState(1);  //cpu color progress bar
                    progressBar2.Increment(13);
                    progressBar2.SetState(1);
                }
                else if (processCount > 10)
                {
                    progressBar1.Increment(15);
                    progressBar1.SetState(1);
                    progressBar2.Increment(38); //memory progress bar
                    progressBar2.SetState(3);   //memory color progress bar
                }
                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < processCount; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("-");
                    listView1.Items.Add(item);
                }

                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles : " + processCount);
            }
            else
            {
                MessageBox.Show("Enter a valid number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        /// <summary>
        /// Occurs when the process count text changes.
        /// </summary>
        private void ProcessTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Restarts the application.
        /// </summary>
        private void RestartApp_Click(object sender, EventArgs e)
        {
            Hide();
            CpuSchedulerForm cpuScheduler = new CpuSchedulerForm();
            cpuScheduler.ShowDialog();
        }



        /// <summary>
        /// Handles form load logic.
        /// </summary>
        private void CpuSchedulerForm_Load(object sender, EventArgs e)
        {
            sidePanel.Height = btnDashBoard.Height;
            sidePanel.Top = btnDashBoard.Top;
            progressBar1.Increment(5);
            progressBar2.Increment(17);
            listView1.View = View.Details;
            listView1.GridLines = true;
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Minimizes the application window.
        /// </summary>
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Toggles between maximized and normal window state.
        /// </summary>
        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                btnMaximize.Text = "□";
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                btnMaximize.Text = "⧠";
            }
        }

        /// <summary>
        /// Placeholder event for an unused picture box.
        /// </summary>
        private void PictureBox4_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Executes the Round Robin algorithm.
        /// </summary>
        private void RoundRobinButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtProcess.Text, out int processCount) && processCount > 0)
            {
                Algorithms.RunRoundRobin(txtProcess.Text);
                if (processCount <= 10)
                {
                    progressBar1.Increment(4); //cpu progress bar
                    progressBar1.SetState(1);  //cpu color progress bar
                    progressBar2.Increment(13);
                    progressBar2.SetState(1);
                }
                else if (processCount > 10)
                {
                    progressBar1.Increment(15);
                    progressBar1.SetState(1);
                    progressBar2.Increment(38); //memory progress bar
                    progressBar2.SetState(3);   //memory color progress bar
                }
                string quantumTime = Helper.QuantumTime;
                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < processCount; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add(quantumTime);
                    listView1.Items.Add(item);
                }

                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles: " + processCount);
            }
            else
            {
                MessageBox.Show("Enter a valid number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }


    }
}