using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace CpuScheduler
{
    /// <summary>
    /// Main form for demonstrating CPU scheduling algorithms.
    /// </summary>
    public partial class CpuSchedulerForm : Form
    {
        private DataTable processTable;
        private Random random = new Random();
        private bool isDarkMode = true; // Default to dark mode
        
        // STUDENTS: Configure these limits based on your algorithm performance requirements
        private const int MIN_PROCESS_COUNT = 1;
        private const int MAX_PROCESS_COUNT = 100;
        private const int DEFAULT_PROCESS_COUNT = 3;

        /// <summary>
        /// Initializes a new instance of the <see cref="CpuSchedulerForm"/> class.
        /// </summary>
        public CpuSchedulerForm()
        {
            InitializeComponent();
            InitializeProcessTable();
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
        /// Handles About page navigation.
        /// </summary>
        private void AboutButton_Click(object sender, EventArgs e)
        {
            ShowPanel(aboutPanel);
            sidePanel.Height = btnAbout.Height;
            sidePanel.Top = btnAbout.Top;
        }

        /// <summary>
        /// Toggles between dark and light mode themes.
        /// </summary>
        private void DarkModeToggle_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme();
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
Learn about the algorithms:
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
        /// STUDENTS: Helper method to get process data from the DataGrid
        /// Use this in your custom algorithm implementations instead of prompting users
        /// Returns: List of process data (ID, Burst Time, Priority, Arrival Time)
        /// </summary>
        public List<ProcessData> GetProcessDataFromGrid()
        {
            var processList = new List<ProcessData>();
            foreach (DataRow row in processTable.Rows)
            {
                processList.Add(new ProcessData
                {
                    ProcessID = row["Process ID"].ToString(),
                    BurstTime = Convert.ToInt32(row["Burst Time"]),
                    Priority = Convert.ToInt32(row["Priority"]),
                    ArrivalTime = Convert.ToInt32(row["Arrival Time"])
                });
            }
            return processList;
        }

        /// <summary>
        /// STUDENTS: Data structure for process information
        /// Use this when implementing your custom scheduling algorithms
        /// </summary>
        public class ProcessData
        {
            public string ProcessID { get; set; }
            public int BurstTime { get; set; }
            public int Priority { get; set; }
            public int ArrivalTime { get; set; }
        }

        /// <summary>
        /// STUDENTS: Validates process count input with configurable limits
        /// Returns true if valid, false otherwise
        /// </summary>
        private bool IsValidProcessCount(string input, out int processCount)
        {
            if (int.TryParse(input, out processCount))
            {
                return processCount >= MIN_PROCESS_COUNT && processCount <= MAX_PROCESS_COUNT;
            }
            processCount = 0;
            return false;
        }

        /// <summary>
        /// STUDENTS: Example FCFS algorithm implementation using DataGrid data
        /// This replaces the old prompt-based system with direct data access
        /// </summary>
        private List<SchedulingResult> RunFCFSAlgorithm(List<ProcessData> processes)
        {
            var results = new List<SchedulingResult>();
            var currentTime = 0;
            
            // Sort by arrival time for FCFS
            var sortedProcesses = processes.OrderBy(p => p.ArrivalTime).ToList();
            
            foreach (var process in sortedProcesses)
            {
                var startTime = Math.Max(currentTime, process.ArrivalTime);
                var finishTime = startTime + process.BurstTime;
                var waitingTime = startTime - process.ArrivalTime;
                var turnaroundTime = finishTime - process.ArrivalTime;
                
                results.Add(new SchedulingResult
                {
                    ProcessID = process.ProcessID,
                    ArrivalTime = process.ArrivalTime,
                    BurstTime = process.BurstTime,
                    StartTime = startTime,
                    FinishTime = finishTime,
                    WaitingTime = waitingTime,
                    TurnaroundTime = turnaroundTime
                });
                
                currentTime = finishTime;
            }
            
            return results;
        }

        /// <summary>
        /// STUDENTS: SJF algorithm implementation using DataGrid data
        /// Shortest Job First - selects process with minimum burst time
        /// </summary>
        private List<SchedulingResult> RunSJFAlgorithm(List<ProcessData> processes)
        {
            var results = new List<SchedulingResult>();
            var currentTime = 0;
            var remainingProcesses = processes.ToList();
            
            while (remainingProcesses.Count > 0)
            {
                // Get processes that have arrived by current time
                var availableProcesses = remainingProcesses.Where(p => p.ArrivalTime <= currentTime).ToList();
                
                if (availableProcesses.Count == 0)
                {
                    // No process has arrived yet, jump to next arrival time
                    currentTime = remainingProcesses.Min(p => p.ArrivalTime);
                    continue;
                }
                
                // Select process with shortest burst time
                var nextProcess = availableProcesses.OrderBy(p => p.BurstTime).ThenBy(p => p.ArrivalTime).First();
                
                var startTime = Math.Max(currentTime, nextProcess.ArrivalTime);
                var finishTime = startTime + nextProcess.BurstTime;
                var waitingTime = startTime - nextProcess.ArrivalTime;
                var turnaroundTime = finishTime - nextProcess.ArrivalTime;
                
                results.Add(new SchedulingResult
                {
                    ProcessID = nextProcess.ProcessID,
                    ArrivalTime = nextProcess.ArrivalTime,
                    BurstTime = nextProcess.BurstTime,
                    StartTime = startTime,
                    FinishTime = finishTime,
                    WaitingTime = waitingTime,
                    TurnaroundTime = turnaroundTime
                });
                
                currentTime = finishTime;
                remainingProcesses.Remove(nextProcess);
            }
            
            return results.OrderBy(r => r.StartTime).ToList();
        }

        /// <summary>
        /// STUDENTS: Priority algorithm implementation using DataGrid data
        /// Higher priority number = higher priority (1 is lowest, higher numbers are higher priority)
        /// </summary>
        private List<SchedulingResult> RunPriorityAlgorithm(List<ProcessData> processes)
        {
            var results = new List<SchedulingResult>();
            var currentTime = 0;
            var remainingProcesses = processes.ToList();
            
            while (remainingProcesses.Count > 0)
            {
                // Get processes that have arrived by current time
                var availableProcesses = remainingProcesses.Where(p => p.ArrivalTime <= currentTime).ToList();
                
                if (availableProcesses.Count == 0)
                {
                    // No process has arrived yet, jump to next arrival time
                    currentTime = remainingProcesses.Min(p => p.ArrivalTime);
                    continue;
                }
                
                // Select process with highest priority (highest number)
                var nextProcess = availableProcesses.OrderByDescending(p => p.Priority).ThenBy(p => p.ArrivalTime).First();
                
                var startTime = Math.Max(currentTime, nextProcess.ArrivalTime);
                var finishTime = startTime + nextProcess.BurstTime;
                var waitingTime = startTime - nextProcess.ArrivalTime;
                var turnaroundTime = finishTime - nextProcess.ArrivalTime;
                
                results.Add(new SchedulingResult
                {
                    ProcessID = nextProcess.ProcessID,
                    ArrivalTime = nextProcess.ArrivalTime,
                    BurstTime = nextProcess.BurstTime,
                    StartTime = startTime,
                    FinishTime = finishTime,
                    WaitingTime = waitingTime,
                    TurnaroundTime = turnaroundTime
                });
                
                currentTime = finishTime;
                remainingProcesses.Remove(nextProcess);
            }
            
            return results.OrderBy(r => r.StartTime).ToList();
        }

        /// <summary>
        /// STUDENTS: Round Robin algorithm implementation using DataGrid data
        /// Each process gets a time quantum, then cycles to next process
        /// </summary>
        private List<SchedulingResult> RunRoundRobinAlgorithm(List<ProcessData> processes, int quantumTime = 4)
        {
            var results = new List<SchedulingResult>();
            var currentTime = 0;
            var processQueue = new Queue<ProcessData>();
            var processResults = new Dictionary<string, SchedulingResult>();
            var remainingBurstTimes = new Dictionary<string, int>();
            
            // Initialize remaining burst times and results
            foreach (var process in processes)
            {
                remainingBurstTimes[process.ProcessID] = process.BurstTime;
                processResults[process.ProcessID] = new SchedulingResult
                {
                    ProcessID = process.ProcessID,
                    ArrivalTime = process.ArrivalTime,
                    BurstTime = process.BurstTime,
                    StartTime = -1, // Will be set on first execution
                    FinishTime = 0,
                    WaitingTime = 0,
                    TurnaroundTime = 0
                };
            }
            
            // Add processes that arrive at time 0
            foreach (var process in processes.Where(p => p.ArrivalTime <= currentTime).OrderBy(p => p.ArrivalTime))
            {
                processQueue.Enqueue(process);
            }
            
            var processesNotInQueue = processes.Where(p => p.ArrivalTime > currentTime).OrderBy(p => p.ArrivalTime).ToList();
            
            while (processQueue.Count > 0 || processesNotInQueue.Count > 0)
            {
                // Add any processes that have now arrived
                while (processesNotInQueue.Count > 0 && processesNotInQueue[0].ArrivalTime <= currentTime)
                {
                    processQueue.Enqueue(processesNotInQueue[0]);
                    processesNotInQueue.RemoveAt(0);
                }
                
                if (processQueue.Count == 0)
                {
                    // No processes in queue, jump to next arrival
                    currentTime = processesNotInQueue[0].ArrivalTime;
                    continue;
                }
                
                var currentProcess = processQueue.Dequeue();
                var result = processResults[currentProcess.ProcessID];
                
                // Set start time if this is the first execution
                if (result.StartTime == -1)
                {
                    result.StartTime = currentTime;
                }
                
                // Execute for quantum time or remaining burst time, whichever is smaller
                var executionTime = Math.Min(quantumTime, remainingBurstTimes[currentProcess.ProcessID]);
                currentTime += executionTime;
                remainingBurstTimes[currentProcess.ProcessID] -= executionTime;
                
                // Add any processes that arrived during this execution
                while (processesNotInQueue.Count > 0 && processesNotInQueue[0].ArrivalTime <= currentTime)
                {
                    processQueue.Enqueue(processesNotInQueue[0]);
                    processesNotInQueue.RemoveAt(0);
                }
                
                // Check if process is completed
                if (remainingBurstTimes[currentProcess.ProcessID] == 0)
                {
                    result.FinishTime = currentTime;
                    result.TurnaroundTime = result.FinishTime - result.ArrivalTime;
                    result.WaitingTime = result.TurnaroundTime - result.BurstTime;
                }
                else
                {
                    // Process not completed, add back to queue
                    processQueue.Enqueue(currentProcess);
                }
            }
            
            return processResults.Values.OrderBy(r => r.StartTime).ToList();
        }

        // === SRTF ALGORITHM ===
        private List<SchedulingResult> RunSRTFAlgorithm(List<ProcessData> processes)
        {
            // Defensive copy and sort by arrival
            var procList = processes.OrderBy(p => p.ArrivalTime).ThenBy(p => p.ProcessID).ToList();
            var remaining = procList.ToDictionary(p => p.ProcessID, p => p.BurstTime);
            var started = new HashSet<string>(); // to mark first start
            var resultsDict = new Dictionary<string, SchedulingResult>();
            int completedCount = 0;
            int currentTime = 0;
            int n = procList.Count;

            // If there are processes that don't arrive at time 0, fast-forward to first arrival
            if (n > 0 && procList[0].ArrivalTime > 0)
                currentTime = procList[0].ArrivalTime;

            while (completedCount < n)
            {
                // Get available processes at current time that are not completed
                var available = procList
                    .Where(p => p.ArrivalTime <= currentTime && remaining[p.ProcessID] > 0)
                    .OrderBy(p => remaining[p.ProcessID])
                    .ThenBy(p => p.ArrivalTime)
                    .ToList();

                if (available.Count == 0)
                {
                    // No available process: advance time to next arrival
                    var nextArrival = procList.Where(p => remaining[p.ProcessID] > 0).Min(p => p.ArrivalTime);
                    currentTime = Math.Max(currentTime + 1, nextArrival);
                    continue;
                }

                var cur = available.First();
                // If this is the first time cur executes, record start time
                if (!started.Contains(cur.ProcessID))
                {
                    started.Add(cur.ProcessID);
                    resultsDict[cur.ProcessID] = new SchedulingResult
                    {
                        ProcessID = cur.ProcessID,
                        ArrivalTime = cur.ArrivalTime,
                        BurstTime = cur.BurstTime,
                        StartTime = currentTime
                    };
                }

                // Execute for 1 time unit (simulate preemption per unit)
                remaining[cur.ProcessID] -= 1;
                currentTime += 1;

                // If finished now, record finish/waiting/turnaround
                if (remaining[cur.ProcessID] == 0)
                {
                    var r = resultsDict[cur.ProcessID];
                    r.FinishTime = currentTime;
                    r.TurnaroundTime = r.FinishTime - r.ArrivalTime;
                    r.WaitingTime = r.TurnaroundTime - r.BurstTime;
                    completedCount++;
                }
            }

            // Return results ordered by StartTime (or ProcessID if needed)
            return resultsDict.Values.OrderBy(r => r.StartTime).ToList();
        }

        // === HRRN ALGORITHM ===
        private List<SchedulingResult> RunHRRNAlgorithm(List<ProcessData> processes)
        {
            var results = new List<SchedulingResult>();
            var remaining = processes.ToList();
            int currentTime = 0;

            while (remaining.Count > 0)
            {
                var available = remaining.Where(p => p.ArrivalTime <= currentTime).ToList();

                if (!available.Any())
                {
                    currentTime++;
                    continue;
                }

                // Calculate response ratio = (waiting + burst) / burst
                var hrrnProcess = available
                    .Select(p => new
                    {
                        Process = p,
                        Ratio = (double)(currentTime - p.ArrivalTime + p.BurstTime) / p.BurstTime
                    })
                    .OrderByDescending(p => p.Ratio)
                    .First().Process;

                int startTime = currentTime;
                int finishTime = startTime + hrrnProcess.BurstTime;
                int waitingTime = startTime - hrrnProcess.ArrivalTime;
                int turnaroundTime = finishTime - hrrnProcess.ArrivalTime;

                results.Add(new SchedulingResult
                {
                    ProcessID = hrrnProcess.ProcessID,
                    ArrivalTime = hrrnProcess.ArrivalTime,
                    BurstTime = hrrnProcess.BurstTime,
                    StartTime = startTime,
                    FinishTime = finishTime,
                    WaitingTime = waitingTime,
                    TurnaroundTime = turnaroundTime
                });

                currentTime = finishTime;
                remaining.Remove(hrrnProcess);
            }

            return results;
        }

        /// <summary>
        /// STUDENTS: Data structure for algorithm results
        /// Use this to store and display scheduling algorithm outcomes
        /// </summary>
        public class SchedulingResult
        {
            public string ProcessID { get; set; }
            public int ArrivalTime { get; set; }
            public int BurstTime { get; set; }
            public int StartTime { get; set; }
            public int FinishTime { get; set; }
            public int WaitingTime { get; set; }
            public int TurnaroundTime { get; set; }
        }

        /// <summary>
        /// STUDENTS: Displays scheduling results in a formatted table
        /// Use this method to show your algorithm results consistently
        /// </summary>
        private void DisplaySchedulingResults(List<SchedulingResult> results, string algorithmName)
        {
            listView1.Clear();
            listView1.View = View.Details;

            // Set up columns for detailed results + metrics section
            listView1.Columns.Add("Process ID", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Arrival", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Burst", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Start", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Finish", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Waiting", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Turnaround", 90, HorizontalAlignment.Center);

            // Add Metric and Value columns next to Turnaround
            listView1.Columns.Add("Metric", 160, HorizontalAlignment.Left);
            listView1.Columns.Add("Value", 180, HorizontalAlignment.Left);

            // --- Compute metrics once ---
            double avgWaiting = results.Average(r => r.WaitingTime);
            double avgTurnaround = results.Average(r => r.TurnaroundTime);
            double avgResponse = results.Average(r => r.StartTime - r.ArrivalTime);
            double totalBurst = results.Sum(r => r.BurstTime);
            double totalTime = results.Max(r => r.FinishTime) - results.Min(r => r.ArrivalTime);
            double cpuUtilization = totalTime > 0 ? (totalBurst / totalTime) * 100.0 : 0.0;
            double throughput = totalTime > 0 ? results.Count / totalTime : 0.0;

            var metricItems = new List<(string, string)>
    {
        ("Average Waiting Time (AWT)", $"{avgWaiting:F2} units"),
        ("Average Turnaround Time (ATT)", $"{avgTurnaround:F2} units"),
        ("Average Response Time (RT)", $"{avgResponse:F2} units"),
        ("CPU Utilization", totalTime > 0 ? $"{cpuUtilization:F2}%" : "N/A"),
        ("Throughput", totalTime > 0 ? $"{throughput:F3} processes/unit time" : "N/A"),
        ("Total Time", $"{totalTime:F2} units")
    };

            // Add process results and inject metrics vertically starting from the first process row
            for (int i = 0; i < results.Count; i++)
            {
                var result = results[i];
                var item = new ListViewItem(result.ProcessID);
                item.SubItems.Add(result.ArrivalTime.ToString());
                item.SubItems.Add(result.BurstTime.ToString());
                item.SubItems.Add(result.StartTime.ToString());
                item.SubItems.Add(result.FinishTime.ToString());
                item.SubItems.Add(result.WaitingTime.ToString());
                item.SubItems.Add(result.TurnaroundTime.ToString());

                // If a metric corresponds to this row index, show it here (metrics start at the first process row)
                if (i < metricItems.Count)
                {
                    item.SubItems.Add(metricItems[i].Item1); // Metric name
                    item.SubItems.Add(metricItems[i].Item2); // Metric value
                }
                else
                {
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                }

                listView1.Items.Add(item);
            }

            // If there are more metrics than processes, add extra rows (empty process columns) to show remaining metrics
            if (metricItems.Count > results.Count)
            {
                for (int j = results.Count; j < metricItems.Count; j++)
                {
                    var metricRow = new ListViewItem(""); // empty Process ID
                    metricRow.SubItems.Add(""); // Arrival
                    metricRow.SubItems.Add(""); // Burst
                    metricRow.SubItems.Add(""); // Start
                    metricRow.SubItems.Add(""); // Finish
                    metricRow.SubItems.Add(""); // Waiting
                    metricRow.SubItems.Add(""); // Turnaround
                    metricRow.SubItems.Add(metricItems[j].Item1); // Metric name
                    metricRow.SubItems.Add(metricItems[j].Item2); // Metric value
                    listView1.Items.Add(metricRow);
                }
            }

            // Add a SUMMARY row (kept as before)
            var summaryItem = new ListViewItem("SUMMARY");
            summaryItem.SubItems.Add(algorithmName);
            summaryItem.SubItems.Add($"{results.Count} processes");
            summaryItem.SubItems.Add($"Avg Wait: {avgWaiting:F1}");
            summaryItem.SubItems.Add($"Avg Turn: {avgTurnaround:F1}");
            summaryItem.SubItems.Add("");
            summaryItem.SubItems.Add("");
            summaryItem.SubItems.Add(""); // Metric col empty for summary
            summaryItem.SubItems.Add(""); // Value col empty for summary
            listView1.Items.Add(summaryItem);

            // === CSV EXPORT BUTTON ===
            if (!resultsPanel.Controls.ContainsKey("btnExportResults"))
            {
                Button exportButton = new Button();
                exportButton.Name = "btnExportResults";
                exportButton.Text = "📁 Export Results to CSV";
                exportButton.Height = 40;
                exportButton.Dock = DockStyle.Bottom;
                exportButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                exportButton.Padding = new Padding(8);
                exportButton.Margin = new Padding(8);
                exportButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                exportButton.BackColor = Color.FromArgb(0, 122, 204);
                exportButton.ForeColor = Color.White;
                exportButton.FlatStyle = FlatStyle.Flat;
                exportButton.FlatAppearance.BorderSize = 0;

                exportButton.Click += (s, ev) =>
                {
                    using (var saveDialog = new SaveFileDialog())
                    {
                        saveDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                        saveDialog.DefaultExt = "csv";
                        saveDialog.FileName = $"{algorithmName.Replace(" ", "_")}_Results.csv";
                        saveDialog.Title = "Export Scheduling Results";

                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                using (var writer = new System.IO.StreamWriter(saveDialog.FileName))
                                {
                                    writer.WriteLine($"Algorithm:,{algorithmName}");
                                    writer.WriteLine($"Export Time:,{DateTime.Now}");
                                    writer.WriteLine();
                                    writer.WriteLine("Process ID,Arrival,Burst,Start,Finish,Waiting,Turnaround,Metric,Value");

                                    foreach (ListViewItem row in listView1.Items)
                                    {
                                        // Ensure commas inside text are escaped or replaced
                                        var cols = row.SubItems.Cast<ListViewItem.ListViewSubItem>()
                                                               .Select(c => (c.Text ?? "").Replace(",", ";"));
                                        writer.WriteLine(string.Join(",", cols));
                                    }
                                }

                                MessageBox.Show($" Export complete!\nFile saved to:\n{saveDialog.FileName}",
                                    "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($" Error exporting file:\n{ex.Message}",
                                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                };

                // Dock the button at the bottom so it stays visible and bring the ListView to front
                resultsPanel.Controls.Add(exportButton);
                listView1.BringToFront();
            }
        }

        /// <summary>
        /// Initializes the process data table structure.
        /// </summary>
        private void InitializeProcessTable()
        {
            processTable = new DataTable();
            processTable.Columns.Add("Process ID", typeof(string));
            processTable.Columns.Add("Burst Time", typeof(int));
            processTable.Columns.Add("Priority", typeof(int));
            processTable.Columns.Add("Arrival Time", typeof(int));

            processDataGrid.DataSource = processTable;
            processDataGrid.AllowUserToAddRows = false;
            processDataGrid.AllowUserToDeleteRows = false;
            
            // Set column widths and configure for larger datasets
            if (processDataGrid.Columns.Count > 0)
            {
                processDataGrid.Columns[0].Width = 100; // Process ID
                processDataGrid.Columns[1].Width = 100; // Burst Time
                processDataGrid.Columns[2].Width = 100; // Priority  
                processDataGrid.Columns[3].Width = 100; // Arrival Time
                
                // STUDENTS: Performance optimizations for larger datasets
                processDataGrid.VirtualMode = false; // Set to true if using 500+ processes
                processDataGrid.RowHeadersVisible = false; // Save space
                processDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Faster rendering
            }
        }

        /// <summary>
        /// Handles the Set Process Count button click.
        /// </summary>
        private void SetProcessCount_Click(object sender, EventArgs e)
        {
            // STUDENTS: Process count validation using helper method
            // Adjust MIN/MAX_PROCESS_COUNT constants above for your requirements
            if (IsValidProcessCount(txtProcess.Text, out int processCount))
            {
                // STUDENTS: Performance warning for large datasets
                if (processCount > 50)
                {
                    var result = MessageBox.Show(
                        $"You are creating {processCount} processes. This may impact performance.\n\nContinue?",
                        "Large Dataset Warning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    
                    if (result == DialogResult.No)
                    {
                        txtProcess.Focus();
                        return;
                    }
                }
                
                processTable.Clear();
                
                for (int i = 0; i < processCount; i++)
                {
                    DataRow row = processTable.NewRow();
                    row["Process ID"] = $"P{i + 1}";
                    row["Burst Time"] = random.Next(1, 11); // Default 1-10
                    row["Priority"] = i + 1; // Default priority
                    row["Arrival Time"] = 0; // Default arrival time
                    processTable.Rows.Add(row);
                }

                // Reset combo box selection
                cmbLoadExample.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show($"Please enter a valid number of processes ({MIN_PROCESS_COUNT}-{MAX_PROCESS_COUNT})", 
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProcess.Focus();
            }
        }

        /// <summary>
        /// Generates random data for the process table.
        /// </summary>
        private void GenerateRandom_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in processTable.Rows)
            {
                row["Burst Time"] = random.Next(1, 21);
                row["Priority"] = random.Next(1, processTable.Rows.Count + 1);
                row["Arrival Time"] = random.Next(0, 10);
            }
        }

        /// <summary>
        /// Clears all process data and resets to default state.
        /// </summary>
        private void ClearAll_Click(object sender, EventArgs e)
        {
            processTable.Clear();
            txtProcess.Text = DEFAULT_PROCESS_COUNT.ToString();
            cmbLoadExample.SelectedIndex = 0;
            txtProcess.Focus();
        }

        /// <summary>
        /// Loads example process scenarios.
        /// </summary>
        private void LoadExample_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLoadExample.SelectedIndex <= 0 || processTable.Rows.Count == 0)
                return;

            switch (cmbLoadExample.SelectedIndex)
            {
                case 1: // Short Processes
                    foreach (DataRow row in processTable.Rows)
                    {
                        row["Burst Time"] = random.Next(1, 6);
                        row["Priority"] = random.Next(1, 5);
                        row["Arrival Time"] = 0;
                    }
                    break;
                    
                case 2: // Mixed Load
                    foreach (DataRow row in processTable.Rows)
                    {
                        row["Burst Time"] = random.Next(1, 21);
                        row["Priority"] = random.Next(1, 10);
                        row["Arrival Time"] = random.Next(0, 5);
                    }
                    break;
                    
                case 3: // Heavy Load
                    foreach (DataRow row in processTable.Rows)
                    {
                        row["Burst Time"] = random.Next(10, 31);
                        row["Priority"] = random.Next(1, 5);
                        row["Arrival Time"] = random.Next(0, 10);
                    }
                    break;
                    
                case 4: // Priority Demo
                    int priority = processTable.Rows.Count;
                    foreach (DataRow row in processTable.Rows)
                    {
                        row["Burst Time"] = random.Next(5, 15);
                        row["Priority"] = priority--;
                        row["Arrival Time"] = 0;
                    }
                    break;
            }
            
            cmbLoadExample.SelectedIndex = 0; // Reset dropdown
        }

        /// <summary>
        /// STUDENTS: Saves DataGrid data to CSV file for external editing or backup
        /// This allows you to prepare process data in Excel/CSV editors
        /// </summary>
        private void SaveData_Click(object sender, EventArgs e)
        {
            if (processTable.Rows.Count == 0)
            {
                MessageBox.Show("No process data to save. Please set process count first.", 
                    "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveDialog.DefaultExt = "csv";
                saveDialog.FileName = "ProcessData.csv";
                saveDialog.Title = "Save Process Data";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var writer = new System.IO.StreamWriter(saveDialog.FileName))
                        {
                            // Write header
                            writer.WriteLine("Process ID,Burst Time,Priority,Arrival Time");
                            
                            // Write data rows
                            foreach (DataRow row in processTable.Rows)
                            {
                                writer.WriteLine($"{row["Process ID"]},{row["Burst Time"]},{row["Priority"]},{row["Arrival Time"]}");
                            }
                        }
                        
                        MessageBox.Show($"Process data saved successfully to:\n{saveDialog.FileName}", 
                            "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", 
                            "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// STUDENTS: Loads process data from CSV file for testing custom datasets
        /// This allows you to prepare complex test scenarios in Excel/CSV editors
        /// </summary>
        private void LoadData_Click(object sender, EventArgs e)
        {
            using (var openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openDialog.DefaultExt = "csv";
                openDialog.Title = "Load Process Data from CSV";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var loadedData = new List<ProcessData>();
                        using (var reader = new System.IO.StreamReader(openDialog.FileName))
                        {
                            // Skip header line
                            var headerLine = reader.ReadLine();
                            if (headerLine == null)
                            {
                                MessageBox.Show("The CSV file is empty.", "Load Error", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            string line;
                            int lineNumber = 1;
                            while ((line = reader.ReadLine()) != null)
                            {
                                lineNumber++;
                                var parts = line.Split(',');
                                
                                if (parts.Length != 4)
                                {
                                    MessageBox.Show($"Invalid format on line {lineNumber}. Expected format: ProcessID,BurstTime,Priority,ArrivalTime", 
                                        "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                try
                                {
                                    loadedData.Add(new ProcessData
                                    {
                                        ProcessID = parts[0].Trim(),
                                        BurstTime = int.Parse(parts[1].Trim()),
                                        Priority = int.Parse(parts[2].Trim()),
                                        ArrivalTime = int.Parse(parts[3].Trim())
                                    });
                                }
                                catch (FormatException)
                                {
                                    MessageBox.Show($"Invalid number format on line {lineNumber}.", 
                                        "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }

                        if (loadedData.Count == 0)
                        {
                            MessageBox.Show("No process data found in the CSV file.", "Load Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (loadedData.Count > MAX_PROCESS_COUNT)
                        {
                            MessageBox.Show($"CSV contains {loadedData.Count} processes, but maximum allowed is {MAX_PROCESS_COUNT}. Loading first {MAX_PROCESS_COUNT} processes.", 
                                "Process Count Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            loadedData = loadedData.Take(MAX_PROCESS_COUNT).ToList();
                        }

                        // Clear existing data and load from CSV
                        processTable.Clear();
                        foreach (var process in loadedData)
                        {
                            DataRow row = processTable.NewRow();
                            row["Process ID"] = process.ProcessID;
                            row["Burst Time"] = process.BurstTime;
                            row["Priority"] = process.Priority;
                            row["Arrival Time"] = process.ArrivalTime;
                            processTable.Rows.Add(row);
                        }

                        // Update UI to reflect loaded data
                        txtProcess.Text = loadedData.Count.ToString();
                        cmbLoadExample.SelectedIndex = 0;

                        MessageBox.Show($"Successfully loaded {loadedData.Count} processes from:\n{openDialog.FileName}", 
                            "Load Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading file: {ex.Message}", 
                            "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        /// <summary>
        /// Executes the First-Come, First-Served algorithm using DataGrid data.
        /// STUDENTS: This demonstrates how to use GetProcessDataFromGrid() instead of prompts
        /// Use this pattern for your custom algorithm implementations
        /// </summary>
        private void FirstComeFirstServeButton_Click(object sender, EventArgs e)
        {
            var processData = GetProcessDataFromGrid();
            if (processData.Count > 0)
            {
                // STUDENTS: Example implementation using DataGrid data
                var results = RunFCFSAlgorithm(processData);

                // Update Results tab with detailed scheduling results
                DisplaySchedulingResults(results, "FCFS - First Come First Serve");
                
                // Switch to Results panel and update sidebar
                ShowPanel(resultsPanel);
                sidePanel.Height = btnDashBoard.Height;
                sidePanel.Top = btnDashBoard.Top;
            }
            else
            {
                MessageBox.Show("Please set process count and ensure the data grid has process data.", 
                    "No Process Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProcess.Focus();
            }
        }

        /// <summary>
        /// Executes the Shortest Job First algorithm using DataGrid data.
        /// STUDENTS: Updated to use GetProcessDataFromGrid() instead of prompts
        /// Use this pattern for your custom algorithm implementations
        /// </summary>
        private void ShortestJobFirstButton_Click(object sender, EventArgs e)
        {
            var processData = GetProcessDataFromGrid();
            if (processData.Count > 0)
            {
                // STUDENTS: Updated implementation using DataGrid data
                var results = RunSJFAlgorithm(processData);

                // Update Results tab with detailed scheduling results
                DisplaySchedulingResults(results, "SJF - Shortest Job First");
                
                // Switch to Results panel and update sidebar
                ShowPanel(resultsPanel);
                sidePanel.Height = btnDashBoard.Height;
                sidePanel.Top = btnDashBoard.Top;
            }
            else
            {
                MessageBox.Show("Please set process count and ensure the data grid has process data.", 
                    "No Process Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProcess.Focus();
            }
        }

        /// <summary>
        /// Executes the Priority algorithm using DataGrid data.
        /// STUDENTS: Updated to use GetProcessDataFromGrid() instead of prompts
        /// Higher priority numbers = higher priority (1=lowest, higher numbers=higher priority)
        /// </summary>
        private void PriorityButton_Click(object sender, EventArgs e)
        {
            var processData = GetProcessDataFromGrid();
            if (processData.Count > 0)
            {
                // STUDENTS: Updated implementation using DataGrid data
                var results = RunPriorityAlgorithm(processData);

                // Update Results tab with detailed scheduling results
                DisplaySchedulingResults(results, "Priority Scheduling (Higher # = Higher Priority)");
                
                // Switch to Results panel and update sidebar
                ShowPanel(resultsPanel);
                sidePanel.Height = btnDashBoard.Height;
                sidePanel.Top = btnDashBoard.Top;
            }
            else
            {
                MessageBox.Show("Please set process count and ensure the data grid has process data.", 
                    "No Process Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        /// STUDENTS: Applies rounded corners to a button for modern UI appearance
        /// Call this method for any custom buttons you add to maintain consistency
        /// </summary>
        private void ApplyRoundedCorners(Button button, int radius = 15)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, button.Width - 1, button.Height - 1);
            
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            
            button.Region = new Region(path);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
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
            // Ensure the ListView fills the results panel and gets scrollbars when needed
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.Scrollable = true;

            // Make sure the results panel can show a bottom-docked control like the export button
            // When export button is Dock = Bottom, we prefer panel's AutoScroll = false so the button stays visible
            resultsPanel.AutoScroll = false;

            // Initialize Results panel with placeholder message
            listView1.Clear();
            listView1.Columns.Add("Information", 400, HorizontalAlignment.Left);
            var welcomeItem = new ListViewItem("No results yet");
            welcomeItem.SubItems.Add("Run a scheduling algorithm to see results here");
            listView1.Items.Add(welcomeItem);

            // Initialize Welcome and About content
            InitializeWelcomeContent();
            InitializeAboutContent();

            // Load default process data for immediate use
            LoadDefaultProcessData();

            // Apply rounded corners to all buttons for modern UI
            ApplyRoundedCorners(btnSetProcessCount);
            ApplyRoundedCorners(btnGenerateRandom);
            ApplyRoundedCorners(btnClearAll);
            ApplyRoundedCorners(btnSaveData);
            ApplyRoundedCorners(btnLoadData);
            ApplyRoundedCorners(btnFCFS);
            ApplyRoundedCorners(btnSJF);
            ApplyRoundedCorners(btnPriority);
            ApplyRoundedCorners(btnRoundRobin);
            ApplyRoundedCorners(btnDarkModeToggle);

            // Move algorithm buttons a bit upward to free space for new buttons
            try
            {
                int offset = 40; // move up by 40 pixels
                if (btnFCFS != null) btnFCFS.Top = Math.Max(5, btnFCFS.Top - offset);
                if (btnSJF != null) btnSJF.Top = Math.Max(5, btnSJF.Top - offset);
                if (btnPriority != null) btnPriority.Top = Math.Max(5, btnPriority.Top - offset);
                if (btnRoundRobin != null) btnRoundRobin.Top = Math.Max(5, btnRoundRobin.Top - offset);
            }
            catch { /* ignore if designer buttons not present */ }

            // Create SRTF and HRRN buttons dynamically (if they don't already exist)
            if (!schedulerPanel.Controls.ContainsKey("btnSRTF"))
            {
                Button btnSRTF = new Button();
                btnSRTF.Name = "btnSRTF";
                btnSRTF.Text = "SRTF";
                btnSRTF.Width = 140;
                btnSRTF.Height = 36;
                btnSRTF.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                btnSRTF.FlatStyle = FlatStyle.Flat;
                btnSRTF.FlatAppearance.BorderSize = 0;
                // Position: align under the other algorithm buttons (adjust as needed)
                btnSRTF.Location = new Point(btnRoundRobin.Left, btnRoundRobin.Bottom + 10);
                btnSRTF.Click += SRTFButton_Click;
                ApplyRoundedCorners(btnSRTF, 10);
                schedulerPanel.Controls.Add(btnSRTF);
            }

            if (!schedulerPanel.Controls.ContainsKey("btnHRRN"))
            {
                Button btnHRRN = new Button();
                btnHRRN.Name = "btnHRRN";
                btnHRRN.Text = "HRRN";
                btnHRRN.Width = 140;
                btnHRRN.Height = 36;
                btnHRRN.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                btnHRRN.FlatStyle = FlatStyle.Flat;
                btnHRRN.FlatAppearance.BorderSize = 0;
                // Position: right next to SRTF
                var srtf = schedulerPanel.Controls["btnSRTF"];
                if (srtf != null)
                    btnHRRN.Location = new Point(srtf.Right + 10, srtf.Top);
                else
                    btnHRRN.Location = new Point(btnRoundRobin.Right + 10, btnRoundRobin.Bottom + 10);

                btnHRRN.Click += HRRNButton_Click;
                ApplyRoundedCorners(btnHRRN, 10);
                schedulerPanel.Controls.Add(btnHRRN);
            }

            // Apply default dark theme
            ApplyTheme();

            // Show Welcome panel by default
            ShowPanel(welcomePanel);
        }

        /// <summary>
        /// STUDENTS: Loads default process data when the application starts
        /// This provides immediate usability without requiring manual setup
        /// </summary>
        private void LoadDefaultProcessData()
        {
            // Populate with 5 default processes for immediate testing
            for (int i = 0; i < 5; i++)
            {
                DataRow row = processTable.NewRow();
                row["Process ID"] = $"P{i + 1}";
                row["Burst Time"] = new int[] { 6, 8, 7, 3, 4 }[i]; // Interesting mix for learning
                row["Priority"] = i + 1; // Sequential priorities
                row["Arrival Time"] = new int[] { 0, 2, 4, 6, 8 }[i]; // Staggered arrivals
                processTable.Rows.Add(row);
            }

            // Set the process count text to match
            txtProcess.Text = "5";
            
            // Set combo box to default selection
            cmbLoadExample.SelectedIndex = 0;
        }

        /// <summary>
        /// STUDENTS: Applies dark or light theme to all UI elements
        /// This provides a modern interface that's easier on the eyes
        /// </summary>
        private void ApplyTheme()
        {
            if (isDarkMode)
            {
                ApplyDarkTheme();
                btnDarkModeToggle.Text = "☀️ Light Mode";
            }
            else
            {
                ApplyLightTheme();
                btnDarkModeToggle.Text = "🌙 Dark Mode";
            }
        }

        /// <summary>
        /// STUDENTS: Applies dark theme colors to all UI components
        /// </summary>
        private void ApplyDarkTheme()
        {
            // Main form background
            this.BackColor = Color.FromArgb(45, 45, 48);
            
            // Sidebar panel
            panel1.BackColor = Color.FromArgb(37, 37, 38);
            sidePanel.BackColor = Color.FromArgb(0, 122, 204); // Blue accent
            
            // All sidebar buttons
            ApplyDarkThemeToButton(btnWelcome);
            ApplyDarkThemeToButton(btnCpuScheduler);
            ApplyDarkThemeToButton(btnDashBoard);
            ApplyDarkThemeToButton(btnAbout);
            ApplyDarkThemeToButton(btnDarkModeToggle);
            
            // Restart label
            restartApp.BackColor = Color.FromArgb(37, 37, 38);
            restartApp.ForeColor = Color.FromArgb(241, 241, 241);
            
            // Copyright label
            label1.ForeColor = Color.FromArgb(153, 153, 153);
            
            // Content panels
            contentPanel.BackColor = Color.FromArgb(30, 30, 30);
            welcomePanel.BackColor = Color.FromArgb(30, 30, 30);
            schedulerPanel.BackColor = Color.FromArgb(30, 30, 30);
            resultsPanel.BackColor = Color.FromArgb(30, 30, 30);
            aboutPanel.BackColor = Color.FromArgb(30, 30, 30);
            
            // Text boxes
            welcomeTextBox.BackColor = Color.FromArgb(37, 37, 38);
            welcomeTextBox.ForeColor = Color.FromArgb(241, 241, 241);
            aboutTextBox.BackColor = Color.FromArgb(37, 37, 38);
            aboutTextBox.ForeColor = Color.FromArgb(241, 241, 241);
            
            // Process input controls
            labelProcess.ForeColor = Color.FromArgb(241, 241, 241);
            txtProcess.BackColor = Color.FromArgb(51, 51, 55);
            txtProcess.ForeColor = Color.FromArgb(241, 241, 241);
            
            // Data grid
            processDataGrid.BackgroundColor = Color.FromArgb(37, 37, 38);
            processDataGrid.DefaultCellStyle.BackColor = Color.FromArgb(51, 51, 55);
            processDataGrid.DefaultCellStyle.ForeColor = Color.FromArgb(241, 241, 241);
            processDataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            processDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(241, 241, 241);
            processDataGrid.GridColor = Color.FromArgb(62, 62, 66);
            
            // Combo box
            cmbLoadExample.BackColor = Color.FromArgb(51, 51, 55);
            cmbLoadExample.ForeColor = Color.FromArgb(241, 241, 241);
            
            // ListView (Results)
            listView1.BackColor = Color.FromArgb(37, 37, 38);
            listView1.ForeColor = Color.FromArgb(241, 241, 241);
            
            // All scheduler buttons with dark theme colors
            ApplyDarkThemeToSchedulerButton(btnSetProcessCount);
            ApplyDarkThemeToSchedulerButton(btnGenerateRandom);
            ApplyDarkThemeToSchedulerButton(btnClearAll);
            ApplyDarkThemeToSchedulerButton(btnSaveData);
            ApplyDarkThemeToSchedulerButton(btnLoadData);
            ApplyDarkThemeToSchedulerButton(btnFCFS);
            ApplyDarkThemeToSchedulerButton(btnSJF);
            ApplyDarkThemeToSchedulerButton(btnPriority);
            ApplyDarkThemeToSchedulerButton(btnRoundRobin);
        }

        /// <summary>
        /// STUDENTS: Applies light theme colors to all UI components
        /// </summary>
        private void ApplyLightTheme()
        {
            // Main form background
            this.BackColor = SystemColors.Control;
            
            // Sidebar panel
            panel1.BackColor = SystemColors.InactiveBorder;
            sidePanel.BackColor = Color.SeaGreen;
            
            // All sidebar buttons
            ApplyLightThemeToButton(btnWelcome);
            ApplyLightThemeToButton(btnCpuScheduler);
            ApplyLightThemeToButton(btnDashBoard);
            ApplyLightThemeToButton(btnAbout);
            ApplyLightThemeToButton(btnDarkModeToggle);
            
            // Restart label
            restartApp.BackColor = SystemColors.InactiveBorder;
            restartApp.ForeColor = Color.DarkBlue;
            
            // Copyright label
            label1.ForeColor = SystemColors.ControlText;
            
            // Content panels
            contentPanel.BackColor = SystemColors.Control;
            welcomePanel.BackColor = SystemColors.Control;
            schedulerPanel.BackColor = SystemColors.Control;
            resultsPanel.BackColor = SystemColors.Control;
            aboutPanel.BackColor = SystemColors.Control;
            
            // Text boxes
            welcomeTextBox.BackColor = SystemColors.Window;
            welcomeTextBox.ForeColor = SystemColors.WindowText;
            aboutTextBox.BackColor = SystemColors.Window;
            aboutTextBox.ForeColor = SystemColors.WindowText;
            
            // Process input controls
            labelProcess.ForeColor = SystemColors.ControlText;
            txtProcess.BackColor = SystemColors.Window;
            txtProcess.ForeColor = SystemColors.WindowText;
            
            // Data grid
            processDataGrid.BackgroundColor = SystemColors.Window;
            processDataGrid.DefaultCellStyle.BackColor = SystemColors.Window;
            processDataGrid.DefaultCellStyle.ForeColor = SystemColors.WindowText;
            processDataGrid.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            processDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
            processDataGrid.GridColor = SystemColors.ControlDark;
            
            // Combo box
            cmbLoadExample.BackColor = SystemColors.Window;
            cmbLoadExample.ForeColor = SystemColors.WindowText;
            
            // ListView (Results)
            listView1.BackColor = SystemColors.Window;
            listView1.ForeColor = SystemColors.WindowText;
            
            // All scheduler buttons with original light colors
            ApplyLightThemeToSchedulerButton(btnSetProcessCount);
            ApplyLightThemeToSchedulerButton(btnGenerateRandom);
            ApplyLightThemeToSchedulerButton(btnClearAll);
            ApplyLightThemeToSchedulerButton(btnSaveData);
            ApplyLightThemeToSchedulerButton(btnLoadData);
            
            // Algorithm buttons with their original colors
            btnFCFS.BackColor = Color.Beige;
            btnSJF.BackColor = Color.AntiqueWhite;
            btnPriority.BackColor = Color.Bisque;
            btnRoundRobin.BackColor = Color.PapayaWhip;
            
            // Reset text color for algorithm buttons
            btnFCFS.ForeColor = SystemColors.ControlText;
            btnSJF.ForeColor = SystemColors.ControlText;
            btnPriority.ForeColor = SystemColors.ControlText;
            btnRoundRobin.ForeColor = SystemColors.ControlText;
        }

        /// <summary>
        /// STUDENTS: Helper method to apply dark theme to sidebar buttons
        /// </summary>
        private void ApplyDarkThemeToButton(Button button)
        {
            button.BackColor = Color.FromArgb(37, 37, 38);
            button.ForeColor = Color.FromArgb(241, 241, 241);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(62, 62, 66);
        }

        /// <summary>
        /// STUDENTS: Helper method to apply light theme to sidebar buttons
        /// </summary>
        private void ApplyLightThemeToButton(Button button)
        {
            button.BackColor = SystemColors.InactiveBorder;
            button.ForeColor = SystemColors.ControlText;
            button.FlatAppearance.MouseOverBackColor = SystemColors.ButtonHighlight;
        }

        /// <summary>
        /// STUDENTS: Helper method to apply dark theme to scheduler buttons
        /// </summary>
        private void ApplyDarkThemeToSchedulerButton(Button button)
        {
            button.BackColor = Color.FromArgb(51, 51, 55);
            button.ForeColor = Color.FromArgb(241, 241, 241);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 122, 204);
        }

        /// <summary>
        /// STUDENTS: Helper method to apply light theme to scheduler buttons
        /// </summary>
        private void ApplyLightThemeToSchedulerButton(Button button)
        {
            button.BackColor = SystemColors.ButtonFace;
            button.ForeColor = SystemColors.ControlText;
            button.FlatAppearance.MouseOverBackColor = Color.PaleGreen;
        }



        /// <summary>
        /// Executes the Round Robin algorithm using DataGrid data.
        /// STUDENTS: Updated to use GetProcessDataFromGrid() instead of prompts
        /// Each process gets a time quantum (default 4) before switching to next process
        /// </summary>
        private void RoundRobinButton_Click(object sender, EventArgs e)
        {
            var processData = GetProcessDataFromGrid();
            if (processData.Count > 0)
            {
                // Prompt for quantum time - this is algorithm-specific parameter
                string quantumInput = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter quantum time for Round Robin scheduling:", 
                    "Quantum Time", 
                    "4");
                
                if (int.TryParse(quantumInput, out int quantumTime) && quantumTime > 0)
                {
                    // STUDENTS: Updated implementation using DataGrid data
                    var results = RunRoundRobinAlgorithm(processData, quantumTime);

                    // Update Results tab with detailed scheduling results
                    DisplaySchedulingResults(results, $"Round Robin (Quantum = {quantumTime})");
                    
                    // Switch to Results panel and update sidebar
                    ShowPanel(resultsPanel);
                    sidePanel.Height = btnDashBoard.Height;
                    sidePanel.Top = btnDashBoard.Top;
                }
                else
                {
                    MessageBox.Show("Please enter a valid quantum time (positive integer).", 
                        "Invalid Quantum Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please set process count and ensure the data grid has process data.", 
                    "No Process Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProcess.Focus();
            }
        }

        // === SRTF (Shortest Remaining Time First) ===
        private void SRTFButton_Click(object sender, EventArgs e)
        {
            var processData = GetProcessDataFromGrid();
            if (processData.Count > 0)
            {
                var results = RunSRTFAlgorithm(processData);

                DisplaySchedulingResults(results, "SRTF - Shortest Remaining Time First");
                ShowPanel(resultsPanel);
                sidePanel.Height = btnDashBoard.Height;
                sidePanel.Top = btnDashBoard.Top;
            }
            else
            {
                MessageBox.Show("Please set process count and ensure the data grid has process data.",
                    "No Process Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProcess.Focus();
            }
        }

        // === HRRN (Highest Response Ratio Next) ===
        private void HRRNButton_Click(object sender, EventArgs e)
        {
            var processData = GetProcessDataFromGrid();
            if (processData.Count > 0)
            {
                var results = RunHRRNAlgorithm(processData);

                DisplaySchedulingResults(results, "HRRN - Highest Response Ratio Next");
                ShowPanel(resultsPanel);
                sidePanel.Height = btnDashBoard.Height;
                sidePanel.Top = btnDashBoard.Top;
            }
            else
            {
                MessageBox.Show("Please set process count and ensure the data grid has process data.",
                    "No Process Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProcess.Focus();
            }
        }


    }

    /// <summary>
    /// STUDENTS: Custom button class with rounded edges for modern UI appearance
    /// You can use this for your custom algorithm buttons to maintain visual consistency
    /// </summary>
    public class RoundedButton : Button
    {
        private int borderRadius = 10;
        private Color borderColor = Color.FromArgb(200, 200, 200);

        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; Invalidate(); }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Create rounded rectangle path
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            path.AddArc(rect.X, rect.Y, borderRadius, borderRadius, 180, 90);
            path.AddArc(rect.X + rect.Width - borderRadius, rect.Y, borderRadius, borderRadius, 270, 90);
            path.AddArc(rect.X + rect.Width - borderRadius, rect.Y + rect.Height - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - borderRadius, borderRadius, borderRadius, 90, 90);
            path.CloseAllFigures();

            // Set button region to rounded shape
            Region = new Region(path);

            // Fill background
            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                g.FillPath(brush, path);
            }

            // Draw border
            using (Pen pen = new Pen(borderColor, 1))
            {
                g.DrawPath(pen, path);
            }

            // Draw text
            TextRenderer.DrawText(g, Text, Font, ClientRectangle, ForeColor, 
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            path.Dispose();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
    }
}
