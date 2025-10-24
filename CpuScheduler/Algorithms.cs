using System;
using System.Windows.Forms;

namespace CpuScheduler
{
    public static class Algorithms
    {
        /// <summary>
        /// Executes the First Come First Serve scheduling algorithm.
        /// </summary>
        /// <param name="processCountInput">The number of processes to schedule.</param>
        public static void RunFirstComeFirstServe(string processCountInput)
        {
            if (!int.TryParse(processCountInput, out int processCount) || processCount <= 0)
            {
                MessageBox.Show("Invalid number of processes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double[] burstTimes = new double[processCount];
            double[] waitingTimes = new double[processCount];
            double totalWaitingTime = 0.0;
            double averageWaitingTime;
            int i;

            DialogResult result = MessageBox.Show(
                "First Come First Serve Scheduling",
                string.Empty,
                MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (i = 0; i < processCount; i++)
                {
                    string input = Microsoft.VisualBasic.Interaction.InputBox(
                        "Enter Burst time:",
                        "Burst time for P" + (i + 1),
                        string.Empty,
                        -1,
                        -1);

                    if (!double.TryParse(input, out burstTimes[i]) || burstTimes[i] < 0)
                    {
                        MessageBox.Show("Invalid burst time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

                for (i = 0; i < processCount; i++)
                {
                    if (i == 0)
                    {
                        waitingTimes[i] = 0;
                    }
                    else
                    {
                        waitingTimes[i] = waitingTimes[i - 1] + burstTimes[i - 1];
                        MessageBox.Show(
                            "Waiting time for P" + (i + 1) + " = " + waitingTimes[i],
                            "Job Queue",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.None);
                    }
                }
                for (i = 0; i < processCount; i++)
                {
                    totalWaitingTime = totalWaitingTime + waitingTimes[i];
                }
                averageWaitingTime = totalWaitingTime / processCount;
                MessageBox.Show(
                    "Average waiting time for " + processCount + " processes = " + averageWaitingTime + " sec(s)",
                    "Average Waiting Time",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.None);
            }
        }

        /// <summary>
        /// Executes the Shortest Job First scheduling algorithm.
        /// </summary>
        /// <param name="processCountInput">The number of processes to schedule.</param>
        public static void RunShortestJobFirst(string processCountInput)
        {
            if (!int.TryParse(processCountInput, out int processCount) || processCount <= 0)
            {
                MessageBox.Show("Invalid number of processes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double[] burstTimes = new double[processCount];
            double[] waitingTimes = new double[processCount];
            double[] sortedBurstTimes = new double[processCount];
            double totalWaitingTime = 0.0;
            double averageWaitingTime;
            int x, i;
            double temp = 0.0;
            bool found = false;

            DialogResult result = MessageBox.Show(
                "Shortest Job First Scheduling",
                string.Empty,
                MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (i = 0; i < processCount; i++)
                {
                    string input =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                           "Burst time for P" + (i + 1),
                                                           "",
                                                           -1, -1);

                    if (!double.TryParse(input, out burstTimes[i]) || burstTimes[i] < 0)
                    {
                        MessageBox.Show("Invalid burst time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                for (i = 0; i < processCount; i++)
                {
                    sortedBurstTimes[i] = burstTimes[i];
                }
                for (x = 0; x <= processCount - 2; x++)
                {
                    for (i = 0; i <= processCount - 2; i++)
                    {
                        if (sortedBurstTimes[i] > sortedBurstTimes[i + 1])
                        {
                            temp = sortedBurstTimes[i];
                            sortedBurstTimes[i] = sortedBurstTimes[i + 1];
                            sortedBurstTimes[i + 1] = temp;
                        }
                    }
                }
                for (i = 0; i < processCount; i++)
                {
                    if (i == 0)
                    {
                        for (x = 0; x < processCount; x++)
                        {
                            if (sortedBurstTimes[i] == burstTimes[x] && found == false)
                            {
                                waitingTimes[i] = 0;
                                MessageBox.Show(
                                    "Waiting time for P" + (x + 1) + " = " + waitingTimes[i],
                                    "Waiting time:",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                                burstTimes[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                    else
                    {
                        for (x = 0; x < processCount; x++)
                        {
                            if (sortedBurstTimes[i] == burstTimes[x] && found == false)
                            {
                                waitingTimes[i] = waitingTimes[i - 1] + sortedBurstTimes[i - 1];
                                MessageBox.Show(
                                    "Waiting time for P" + (x + 1) + " = " + waitingTimes[i],
                                    "Waiting time",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                                burstTimes[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                }
                for (i = 0; i < processCount; i++)
                {
                    totalWaitingTime = totalWaitingTime + waitingTimes[i];
                }
                averageWaitingTime = totalWaitingTime / processCount;
                MessageBox.Show(
                    "Average waiting time for " + processCount + " processes = " + averageWaitingTime + " sec(s)",
                    "Average waiting time",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Executes the Priority scheduling algorithm.
        /// </summary>
        /// <param name="processCountInput">The number of processes to schedule.</param>
        public static void RunPriorityScheduling(string processCountInput)
        {
            if (!int.TryParse(processCountInput, out int processCount) || processCount <= 0)
            {
                MessageBox.Show("Invalid number of processes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Priority Scheduling",
                string.Empty,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                double[] burstTimes = new double[processCount];
                double[] waitingTimes = new double[processCount + 1];
                int[] priorities = new int[processCount];
                int[] sortedPriorities = new int[processCount];
                int x, i;
                double totalWaitingTime = 0.0;
                double averageWaitingTime;
                int temp = 0;
                bool found = false;
                for (i = 0; i < processCount; i++)
                {
                    string input =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                           "Burst time for P" + (i + 1),
                                                           "",
                                                           -1, -1);
                    if (!double.TryParse(input, out burstTimes[i]) || burstTimes[i] < 0)
                    {
                        MessageBox.Show("Invalid burst time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                for (i = 0; i < processCount; i++)
                {
                    string input2 =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter priority: ",
                                                           "Priority for P" + (i + 1),
                                                           "",
                                                           -1, -1);
                    if (!int.TryParse(input2, out priorities[i]) || priorities[i] < 0)
                    {
                        MessageBox.Show("Invalid priority", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                for (i = 0; i < processCount; i++)
                {
                    sortedPriorities[i] = priorities[i];
                }
                for (x = 0; x <= processCount - 2; x++)
                {
                    for (i = 0; i <= processCount - 2; i++)
                    {
                        if (sortedPriorities[i] > sortedPriorities[i + 1])
                        {
                            temp = sortedPriorities[i];
                            sortedPriorities[i] = sortedPriorities[i + 1];
                            sortedPriorities[i + 1] = temp;
                        }
                    }
                }
                for (i = 0; i < processCount; i++)
                {
                    if (i == 0)
                    {
                        for (x = 0; x < processCount; x++)
                        {
                            if (sortedPriorities[i] == priorities[x] && found == false)
                            {
                                waitingTimes[i] = 0;
                                MessageBox.Show(
                                    "Waiting time for P" + (x + 1) + " = " + waitingTimes[i],
                                    "Waiting time",
                                    MessageBoxButtons.OK);
                                temp = x;
                                priorities[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                    else
                    {
                        for (x = 0; x < processCount; x++)
                        {
                            if (sortedPriorities[i] == priorities[x] && found == false)
                            {
                                waitingTimes[i] = waitingTimes[i - 1] + burstTimes[temp];
                                MessageBox.Show(
                                    "Waiting time for P" + (x + 1) + " = " + waitingTimes[i],
                                    "Waiting time",
                                    MessageBoxButtons.OK);
                                temp = x;
                                priorities[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                }
                for (i = 0; i < processCount; i++)
                {
                    totalWaitingTime = totalWaitingTime + waitingTimes[i];
                }
                averageWaitingTime = totalWaitingTime / processCount;
                MessageBox.Show(
                    "Average waiting time for " + processCount + " processes = " + averageWaitingTime + " sec(s)",
                    "Average waiting time",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Executes the Round Robin scheduling algorithm.
        /// </summary>
        /// <param name="processCountInput">The number of processes to schedule.</param>
        public static void RunRoundRobin(string processCountInput)
        {
            if (!int.TryParse(processCountInput, out int processCount) || processCount <= 0)
            {
                MessageBox.Show("Invalid number of processes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int index, counter = 0;
            double total;
            double timeQuantum;
            double waitTime = 0, turnaroundTime = 0;
            double averageWaitTime, averageTurnaroundTime;
            double[] arrivalTimes = new double[processCount];
            double[] burstTimes = new double[processCount];
            double[] remainingTimes = new double[processCount];
            int remainingProcesses = processCount;

            DialogResult result = MessageBox.Show(
                "Round Robin Scheduling",
                string.Empty,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (index = 0; index < processCount; index++)
                {
                    string arrivalInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter arrival time: ",
                                                               "Arrival time for P" + (index + 1),
                                                               "",
                                                               -1, -1);
                    if (!double.TryParse(arrivalInput, out arrivalTimes[index]) || arrivalTimes[index] < 0)
                    {
                        MessageBox.Show("Invalid arrival time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string burstInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                               "Burst time for P" + (index + 1),
                                                               "",
                                                               -1, -1);
                    if (!double.TryParse(burstInput, out burstTimes[index]) || burstTimes[index] < 0)
                    {
                        MessageBox.Show("Invalid burst time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    remainingTimes[index] = burstTimes[index];
                }
                string timeQuantumInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter time quantum: ", "Time Quantum",
                                                               "",
                                                               -1, -1);

                if (!double.TryParse(timeQuantumInput, out timeQuantum) || timeQuantum <= 0)
                {
                    MessageBox.Show("Invalid quantum time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Helper.QuantumTime = timeQuantumInput;

                for (total = 0, index = 0; remainingProcesses != 0;)
                {
                    if (remainingTimes[index] <= timeQuantum && remainingTimes[index] > 0)
                    {
                        total = total + remainingTimes[index];
                        remainingTimes[index] = 0;
                        counter = 1;
                    }
                    else if (remainingTimes[index] > 0)
                    {
                        remainingTimes[index] = remainingTimes[index] - timeQuantum;
                        total = total + timeQuantum;
                    }
                    if (remainingTimes[index] == 0 && counter == 1)
                    {
                        remainingProcesses--;
                        MessageBox.Show("Turnaround time for Process " + (index + 1) + " : " + (total - arrivalTimes[index]), "Turnaround time for Process " + (index + 1), MessageBoxButtons.OK);
                        MessageBox.Show("Wait time for Process " + (index + 1) + " : " + (total - arrivalTimes[index] - burstTimes[index]), "Wait time for Process " + (index + 1), MessageBoxButtons.OK);
                        turnaroundTime = turnaroundTime + total - arrivalTimes[index];
                        waitTime = waitTime + total - arrivalTimes[index] - burstTimes[index];
                        counter = 0;
                    }
                    if (index == processCount - 1)
                    {
                        index = 0;
                    }
                    else if (arrivalTimes[index + 1] <= total)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
                averageWaitTime = Convert.ToInt64(waitTime * 1.0 / processCount);
                averageTurnaroundTime = Convert.ToInt64(turnaroundTime * 1.0 / processCount);
                MessageBox.Show("Average wait time for " + processCount + " processes: " + averageWaitTime + " sec(s)", string.Empty, MessageBoxButtons.OK);
                MessageBox.Show("Average turnaround time for " + processCount + " processes: " + averageTurnaroundTime + " sec(s)", string.Empty, MessageBoxButtons.OK);
            }
        }

        // TODO: Add new scheduling algorithms below. Use the above methods as
        // examples when expanding functionality.

        public static void RunSRTF(string processCountInput)
        {
            if (!int.TryParse(processCountInput, out int processCount) || processCount <= 0)
            {
                MessageBox.Show("Invalid number of processes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double[] arrivalTimes = new double[processCount];
            double[] burstTimes = new double[processCount];
            double[] remainingTimes = new double[processCount];
            double[] waitingTimes = new double[processCount];
            double[] turnaroundTimes = new double[processCount];
            bool[] completed = new bool[processCount];

            double totalWaitingTime = 0, totalTurnaroundTime = 0;
            double currentTime = 0;
            int completedCount = 0, i, shortest = -1;
            double minRemaining = double.MaxValue;

            DialogResult result = MessageBox.Show(
                "Shortest Remaining Time First (SRTF) Scheduling",
                string.Empty,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (i = 0; i < processCount; i++)
                {
                    string atInput = Microsoft.VisualBasic.Interaction.InputBox("Enter arrival time:", "Arrival time for P" + (i + 1), "", -1, -1);
                    if (!double.TryParse(atInput, out arrivalTimes[i]) || arrivalTimes[i] < 0)
                    {
                        MessageBox.Show("Invalid arrival time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string btInput = Microsoft.VisualBasic.Interaction.InputBox("Enter burst time:", "Burst time for P" + (i + 1), "", -1, -1);
                    if (!double.TryParse(btInput, out burstTimes[i]) || burstTimes[i] < 0)
                    {
                        MessageBox.Show("Invalid burst time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    remainingTimes[i] = burstTimes[i];
                }

                // prepare first-start tracking and total burst
                int[] firstStart = new int[processCount];
                for (int k = 0; k < processCount; k++) firstStart[k] = -1;

                double totalBurst = 0;
                for (i = 0; i < processCount; i++) totalBurst += burstTimes[i];

                while (completedCount < processCount)
                {
                    minRemaining = double.MaxValue;
                    shortest = -1;

                    for (i = 0; i < processCount; i++)
                    {
                        if (arrivalTimes[i] <= currentTime && !completed[i] && remainingTimes[i] < minRemaining && remainingTimes[i] > 0)
                        {
                            minRemaining = remainingTimes[i];
                            shortest = i;
                        }
                    }

                    if (shortest == -1)
                    {
                        currentTime++;
                        continue;
                    }

                    // record first start time for response time calculation
                    if (firstStart[shortest] == -1)
                        firstStart[shortest] = (int)currentTime;

                    remainingTimes[shortest]--;
                    currentTime++;

                    if (remainingTimes[shortest] == 0)
                    {
                        completed[shortest] = true;
                        completedCount++;
                        double finishTime = currentTime;
                        turnaroundTimes[shortest] = finishTime - arrivalTimes[shortest];
                        waitingTimes[shortest] = turnaroundTimes[shortest] - burstTimes[shortest];
                    }
                }

                for (i = 0; i < processCount; i++)
                {
                    totalWaitingTime += waitingTimes[i];
                    totalTurnaroundTime += turnaroundTimes[i];
                    MessageBox.Show($"P{i + 1}: Waiting = {waitingTimes[i]}, Turnaround = {turnaroundTimes[i]}");
                }

                double avgWT = totalWaitingTime / processCount;
                double avgTT = totalTurnaroundTime / processCount;
                double totalTime = currentTime; // simulation end time

                // build response times array
                double[] responseTimes = new double[processCount];
                for (i = 0; i < processCount; i++)
                {
                    responseTimes[i] = (firstStart[i] >= 0) ? (firstStart[i] - arrivalTimes[i]) : -1;
                }

                // call metrics calculator
                CalculateMetrics(processCount, avgWT, avgTT, totalTime, totalBurst, responseTimes);

                MessageBox.Show($"Average Waiting Time = {avgWT}\nAverage Turnaround Time = {avgTT}", "SRTF Results");
            }
        }

        /// <summary>
        /// Executes the Highest Response Ratio Next (HRRN) scheduling algorithm.
        /// </summary>
        /// <param name="processCountInput">The number of processes to schedule.</param>
        public static void RunHRRN(string processCountInput)
        {
            if (!int.TryParse(processCountInput, out int processCount) || processCount <= 0)
            {
                MessageBox.Show("Invalid number of processes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double[] arrivalTimes = new double[processCount];
            double[] burstTimes = new double[processCount];
            double[] waitingTimes = new double[processCount];
            double[] turnaroundTimes = new double[processCount];
            bool[] completed = new bool[processCount];

            double totalWaitingTime = 0, totalTurnaroundTime = 0;
            double currentTime = 0;
            int completedCount = 0, i;

            DialogResult result = MessageBox.Show(
                "Highest Response Ratio Next (HRRN) Scheduling",
                string.Empty,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                // Step 1: Input data
                for (i = 0; i < processCount; i++)
                {
                    string atInput = Microsoft.VisualBasic.Interaction.InputBox("Enter arrival time:", "Arrival time for P" + (i + 1), "", -1, -1);
                    if (!double.TryParse(atInput, out arrivalTimes[i]) || arrivalTimes[i] < 0)
                    {
                        MessageBox.Show("Invalid arrival time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string btInput = Microsoft.VisualBasic.Interaction.InputBox("Enter burst time:", "Burst time for P" + (i + 1), "", -1, -1);
                    if (!double.TryParse(btInput, out burstTimes[i]) || burstTimes[i] <= 0)
                    {
                        MessageBox.Show("Invalid burst time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // prepare first-start tracking and total burst
                int[] firstStart = new int[processCount];
                for (int k = 0; k < processCount; k++) firstStart[k] = -1;

                double totalBurst = 0;
                for (i = 0; i < processCount; i++) totalBurst += burstTimes[i];

                // Step 2: HRRN scheduling logic
                while (completedCount < processCount)
                {
                    double maxRatio = -1;
                    int nextProcess = -1;

                    for (i = 0; i < processCount; i++)
                    {
                        if (arrivalTimes[i] <= currentTime && !completed[i])
                        {
                            double waiting = currentTime - arrivalTimes[i];
                            double ratio = (waiting + burstTimes[i]) / burstTimes[i];
                            if (ratio > maxRatio)
                            {
                                maxRatio = ratio;
                                nextProcess = i;
                            }
                        }
                    }

                    // No available process at this time
                    if (nextProcess == -1)
                    {
                        currentTime++;
                        continue;
                    }

                    // record first start if needed
                    if (firstStart[nextProcess] == -1)
                        firstStart[nextProcess] = (int)currentTime;

                    // Execute the selected process (non-preemptive)
                    currentTime += burstTimes[nextProcess];
                    turnaroundTimes[nextProcess] = currentTime - arrivalTimes[nextProcess];
                    waitingTimes[nextProcess] = turnaroundTimes[nextProcess] - burstTimes[nextProcess];
                    completed[nextProcess] = true;
                    completedCount++;

                    MessageBox.Show($"P{nextProcess + 1}: Waiting = {waitingTimes[nextProcess]}, Turnaround = {turnaroundTimes[nextProcess]}");
                }

                // Step 3: Calculate averages
                for (i = 0; i < processCount; i++)
                {
                    totalWaitingTime += waitingTimes[i];
                    totalTurnaroundTime += turnaroundTimes[i];
                }

                double avgWT = totalWaitingTime / processCount;
                double avgTT = totalTurnaroundTime / processCount;
                double totalTime = currentTime; // simulation end time

                // build response times array
                double[] responseTimes = new double[processCount];
                for (i = 0; i < processCount; i++)
                {
                    responseTimes[i] = (firstStart[i] >= 0) ? (firstStart[i] - arrivalTimes[i]) : -1;
                }

                // Step 4: Compute and display performance metrics
                CalculateMetrics(processCount, avgWT, avgTT, totalTime, totalBurst, responseTimes);

                MessageBox.Show(
                    $"Average Waiting Time = {avgWT:F2}\nAverage Turnaround Time = {avgTT:F2}",
                    "HRRN Results",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Calculates and displays key CPU scheduling performance metrics.
        /// </summary>
        private static void CalculateMetrics(int processCount, double avgWT, double avgTT, double totalTime, double totalBurstTime, double[] responseTimes)
        {
            // CPU utilization: total work (burst) divided by total time (includes idle)
            double cpuUtilization = (totalTime > 0) ? (totalBurstTime / totalTime) * 100.0 : 0.0;
            double throughput = (totalTime > 0) ? (double)processCount / totalTime : 0.0;

            // Average response time (ignore -1 entries)
            double respSum = 0.0;
            int respCount = 0;
            if (responseTimes != null)
            {
                foreach (var r in responseTimes)
                {
                    if (r >= 0)
                    {
                        respSum += r;
                        respCount++;
                    }
                }
            }
            double avgResponse = (respCount > 0) ? respSum / respCount : 0.0;

            string message =
    "Performance Metrics:\n\n" +
    "-------------------------------------------\n" +
    "Metric                      | Value\n" +
    "-------------------------------------------\n" +
    $"Avg Waiting Time (AWT)      : {avgWT:F2}   |  " +
    $"Avg Turnaround Time (ATT)   : {avgTT:F2}\n" +
    $"Avg Response Time (RT)      : {avgResponse:F2}   |  " +
    $"CPU Utilization             : {cpuUtilization:F2}%\n" +
    $"Throughput                  : {throughput:F3} processes/unit\n" +
    "-------------------------------------------";

            // simple, compact one-window summary
            MessageBox.Show(message, "Performance Metrics (Summary)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
