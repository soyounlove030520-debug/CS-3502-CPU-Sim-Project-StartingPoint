# CPU-Simulator using Windows Forms

This project provides a simple Windows Forms application that demonstrates common CPU scheduling algorithms through an interactive graphical interface. Each algorithm prompts for basic input and displays the resulting waiting or turnaround times using message boxes and on screen tables.

## Project status

The simulator is functional but still a work in progress. Currently the following scheduling strategies are available:

| Algorithm | Method | Notes |
|-----------|--------|-------|
| First Come First Serve | `Algorithms.RunFirstComeFirstServe` | Processes are executed in order of arrival. |
| Shortest Job First | `Algorithms.RunShortestJobFirst` | Jobs are sorted by burst time before execution. |
| Priority Scheduling | `Algorithms.RunPriorityScheduling` | User supplies a priority value for each job. |
| Round Robin | `Algorithms.RunRoundRobin` | Requires a quantum time parameter. |

Additional algorithms can easily be added by extending `Algorithms.cs`.

## Requirements

- Windows operating system
- .NET Framework 9.0.5 (as referenced in `App.config`) or a compatible runtime
- Visual Studio 2022 or newer (recommended) or the .NET CLI tools

## How to run

1. Clone the repository using SSH:

   ```bash
   git clone git@github.com:iAmGiG/CS-3502-CPU-Sim-Project-StartingPoint.git
   ```

2. Open `CpuSchedulingWinForms.sln` in Visual Studio and build the solution. Alternatively, use the .NET CLI:

   ```bash
   dotnet build CpuSchedulingWinForms.sln
   ```

3. Run the application:

   ```bash
   dotnet run --project CpuSchedulingWinForms/CpuSchedulingWinForms.csproj
   ```

4. Enter the desired number of processes and choose a scheduling algorithm from the interface. The app will prompt for additional values as needed (burst time, priority, quantum time, etc.) and display the results.

### License

This project is licensed under the terms of the [MIT license](LICENSE.txt).
