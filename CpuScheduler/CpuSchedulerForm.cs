using System;
using System.Windows.Forms;

namespace CpuScheduler
{
    /// <summary>
    /// Main form for demonstrating CPU scheduling algorithms.
    /// </summary>
    public partial class CpuSchedulerForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CpuSchedulerForm"/> class.
        /// </summary>
        public CpuSchedulerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles welcome page navigation.
        /// </summary>
        private void WelcomeButton_Click(object sender, EventArgs e)
        {
            ShowPanel(welcomePanel);
            sidePanel.Height = btnWelcome.Height;
            sidePanel.Top = btnWelcome.Top;
        }

        /// <summary>
        /// Handles results navigation.
        /// </summary>
        private void DashBoardButton_Click(object sender, EventArgs e)
        {
            ShowPanel(resultsPanel);
            sidePanel.Height = btnDashBoard.Height;
            sidePanel.Top = btnDashBoard.Top;
        }

        /// <summary>
        /// Navigates to the scheduler panel.
        /// </summary>
        private void CpuSchedulerButton_Click(object sender, EventArgs e)
        {
            ShowPanel(schedulerPanel);
            sidePanel.Height = btnCpuScheduler.Height;
            sidePanel.Top = btnCpuScheduler.Top;
        }

        /// <summary>
        /// Shows the specified panel and hides all others.
        /// </summary>
        private void ShowPanel(Panel panelToShow)
        {
            welcomePanel.Visible = false;
            schedulerPanel.Visible = false;
            resultsPanel.Visible = false;
            aboutPanel.Visible = false;
            panelToShow.Visible = true;
            panelToShow.BringToFront();
        }

        /// <summary>
        /// Initializes the Welcome panel with introduction and navigation guide.
        /// </summary>
        private void InitializeWelcomeContent()
        {
            welcomeTextBox.Text = @"Welcome to CPU Scheduler Simulator

This educational tool helps CS 3502 students learn and experiment with CPU scheduling algorithms used in operating systems.

GETTING STARTED

Navigate using the sidebar buttons on the left:

🏠 WELCOME
This introduction page explaining the simulator and navigation.

⚙️ SCHEDULER
The main interface where you can:
• Enter the number of processes to simulate
• Choose from 4 scheduling algorithms:
  - FCFS (First Come, First Serve)
  - SJF (Shortest Job First)
  - Priority Scheduling
  - Round Robin
• Run simulations and see immediate feedback

📊 RESULTS
View detailed results from your last algorithm execution:
• Process execution details
• Algorithm-specific information
• Summary statistics
Results persist until you run a new simulation.

📚 ABOUT
Educational content explaining:
• How each algorithm works
• When to use each algorithm
• Learning objectives and concepts
• Algorithm characteristics and trade-offs

🔄 RESTART APPLICATION
Reset the simulator to its initial state.

HOW TO USE
1. Click 'Scheduler' to start
2. Enter number of processes (try 3-5 for learning)
3. Click an algorithm button to run simulation
4. View results in the 'Results' section
5. Learn more in the 'About' section
6. Experiment with different algorithms and process counts

Ready to start? Click 'Scheduler' to begin your CPU scheduling exploration!";
        }

        /// <summary>
        /// Initializes the About tab with educational content about CPU scheduling algorithms.
        /// </summary>
        private void InitializeAboutContent()
        {
            aboutTextBox.Text = @"CPU Scheduling Algorithms

This simulator demonstrates four fundamental CPU scheduling algorithms used in operating systems:

FIRST COME, FIRST SERVE (FCFS)
• Non-preemptive algorithm
• Processes are executed in the order they arrive
• Simple to implement but can lead to convoy effect
• Good for batch systems with long processes

SHORTEST JOB FIRST (SJF)
• Non-preemptive algorithm  
• Selects process with shortest burst time first
• Optimal for minimizing average waiting time
• Requires knowledge of process execution times

PRIORITY SCHEDULING
• Can be preemptive or non-preemptive
• Each process has a priority number
• CPU allocated to highest priority process
• May cause starvation of low-priority processes

ROUND ROBIN (RR)
• Preemptive algorithm using time quantum
• Each process gets equal CPU time slices
• Good for time-sharing systems
• Performance depends on quantum size

Learning Objectives:
• Understand how different algorithms handle process scheduling
• Compare algorithm performance and characteristics  
• Explore trade-offs between fairness and efficiency
• Learn when to use each algorithm type

Instructions:
1. Use the Scheduler tab to run algorithms
2. View execution results in the Results tab
3. Experiment with different process counts
4. Compare algorithm behaviors and outcomes";
        }


        /// <summary>
        /// Executes the First-Come, First-Served algorithm.
        /// </summary>
        private void FirstComeFirstServeButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtProcess.Text, out int processCount) && processCount > 0)
            {
                Algorithms.RunFirstComeFirstServe(txtProcess.Text);

                // Update Results tab
                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Algorithm", 120, HorizontalAlignment.Center);
                listView1.Columns.Add("Status", 100, HorizontalAlignment.Center);

                for (int i = 0; i < processCount; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("FCFS");
                    item.SubItems.Add("Completed");
                    listView1.Items.Add(item);
                }
                
                // Add summary
                var summaryItem = new ListViewItem();
                summaryItem.Text = "Summary";
                summaryItem.SubItems.Add("First Come First Serve");
                summaryItem.SubItems.Add(processCount + " processes executed");
                listView1.Items.Add(summaryItem);
                
                // Switch to Results panel
                ShowPanel(resultsPanel);
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

                // Update Results tab
                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Algorithm", 120, HorizontalAlignment.Center);
                listView1.Columns.Add("Status", 100, HorizontalAlignment.Center);

                for (int i = 0; i < processCount; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("SJF");
                    item.SubItems.Add("Completed");
                    listView1.Items.Add(item);
                }

                // Add summary
                var summaryItem = new ListViewItem();
                summaryItem.Text = "Summary";
                summaryItem.SubItems.Add("Shortest Job First");
                summaryItem.SubItems.Add(processCount + " processes executed");
                listView1.Items.Add(summaryItem);
                
                // Switch to Results panel
                ShowPanel(resultsPanel);
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

                // Update Results tab
                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Algorithm", 120, HorizontalAlignment.Center);
                listView1.Columns.Add("Status", 100, HorizontalAlignment.Center);

                for (int i = 0; i < processCount; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("Priority");
                    item.SubItems.Add("Completed");
                    listView1.Items.Add(item);
                }

                // Add summary
                var summaryItem = new ListViewItem();
                summaryItem.Text = "Summary";
                summaryItem.SubItems.Add("Priority Scheduling");
                summaryItem.SubItems.Add(processCount + " processes executed");
                listView1.Items.Add(summaryItem);
                
                // Switch to Results panel
                ShowPanel(resultsPanel);
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
            // Set default to Welcome panel
            sidePanel.Height = btnWelcome.Height;
            sidePanel.Top = btnWelcome.Top;
            listView1.View = View.Details;
            listView1.GridLines = true;
            
            // Initialize Results panel with placeholder message
            listView1.Clear();
            listView1.Columns.Add("Information", 400, HorizontalAlignment.Left);
            var welcomeItem = new ListViewItem("No results yet");
            welcomeItem.SubItems.Add("Run a scheduling algorithm to see results here");
            listView1.Items.Add(welcomeItem);
            
            // Initialize Welcome and About content
            InitializeWelcomeContent();
            InitializeAboutContent();
            
            // Show Welcome panel by default
            ShowPanel(welcomePanel);
        }



        /// <summary>
        /// Executes the Round Robin algorithm.
        /// </summary>
        private void RoundRobinButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtProcess.Text, out int processCount) && processCount > 0)
            {
                Algorithms.RunRoundRobin(txtProcess.Text);
                string quantumTime = Helper.QuantumTime;

                // Update Results tab
                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Algorithm", 120, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < processCount; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("Round Robin");
                    item.SubItems.Add(quantumTime);
                    listView1.Items.Add(item);
                }

                // Add summary
                var summaryItem = new ListViewItem();
                summaryItem.Text = "Summary";
                summaryItem.SubItems.Add("Round Robin (Q=" + quantumTime + ")");
                summaryItem.SubItems.Add(processCount + " processes executed");
                listView1.Items.Add(summaryItem);
                
                // Switch to Results panel
                ShowPanel(resultsPanel);
            }
            else
            {
                MessageBox.Show("Enter a valid number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }


    }
}