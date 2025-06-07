namespace CpuScheduler
{
    partial class CpuSchedulerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CpuSchedulerForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCpuScheduler = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDashBoard = new System.Windows.Forms.Button();
            this.tabSelection = new System.Windows.Forms.TabControl();
            this.dashBoardTab = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cpuSchedulerTab = new System.Windows.Forms.TabPage();
            this.btnRoundRobin = new System.Windows.Forms.Button();
            this.restartApp = new System.Windows.Forms.Label();
            this.btnPriority = new System.Windows.Forms.Button();
            this.btnSJF = new System.Windows.Forms.Button();
            this.btnFCFS = new System.Windows.Forms.Button();
            this.txtProcess = new System.Windows.Forms.TextBox();
            this.labelProcess = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabSelection.SuspendLayout();
            this.dashBoardTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.cpuSchedulerTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.sidePanel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCpuScheduler);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnDashBoard);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 439);
            this.panel1.TabIndex = 0;
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.SeaGreen;
            this.sidePanel.Location = new System.Drawing.Point(0, 161);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(10, 45);
            this.sidePanel.TabIndex = 4;
            // 
            // 
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 52);
            this.label1.TabIndex = 3;
            this.label1.Text = "© 2024.\r\nAll Rights Reserved.\r\n\r\nCredits to Francis Nweke.\r\n";
            // 
            // btnCpuScheduler
            // 
            this.btnCpuScheduler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCpuScheduler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCpuScheduler.FlatAppearance.BorderSize = 0;
            this.btnCpuScheduler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCpuScheduler.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCpuScheduler.Image = ((System.Drawing.Image)(resources.GetObject("btnCpuScheduler.Image")));
            this.btnCpuScheduler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCpuScheduler.Location = new System.Drawing.Point(11, 212);
            this.btnCpuScheduler.Name = "btnCpuScheduler";
            this.btnCpuScheduler.Size = new System.Drawing.Size(150, 40);
            this.btnCpuScheduler.TabIndex = 2;
            this.btnCpuScheduler.Text = "    CPU Scheduler";
            this.btnCpuScheduler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCpuScheduler.UseVisualStyleBackColor = true;
            this.btnCpuScheduler.Click += new System.EventHandler(this.CpuSchedulerButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 129);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnDashBoard
            // 
            this.btnDashBoard.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnDashBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDashBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashBoard.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnDashBoard.FlatAppearance.BorderSize = 0;
            this.btnDashBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashBoard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashBoard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashBoard.Image")));
            this.btnDashBoard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashBoard.Location = new System.Drawing.Point(11, 161);
            this.btnDashBoard.Name = "btnDashBoard";
            this.btnDashBoard.Size = new System.Drawing.Size(150, 45);
            this.btnDashBoard.TabIndex = 1;
            this.btnDashBoard.Text = "    Dashboard";
            this.btnDashBoard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashBoard.UseVisualStyleBackColor = false;
            this.btnDashBoard.Click += new System.EventHandler(this.DashBoardButton_Click);
            // 
            // tabSelection
            // 
            this.tabSelection.Controls.Add(this.dashBoardTab);
            this.tabSelection.Controls.Add(this.cpuSchedulerTab);
            this.tabSelection.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSelection.Location = new System.Drawing.Point(171, 1);
            this.tabSelection.Name = "tabSelection";
            this.tabSelection.SelectedIndex = 0;
            this.tabSelection.Size = new System.Drawing.Size(509, 439);
            this.tabSelection.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabSelection.TabIndex = 1;
            // 
            // dashBoardTab
            // 
            this.dashBoardTab.BackColor = System.Drawing.SystemColors.Highlight;
            this.dashBoardTab.Controls.Add(this.listView1);
            this.dashBoardTab.Controls.Add(this.progressBar2);
            this.dashBoardTab.Controls.Add(this.label3);
            this.dashBoardTab.Controls.Add(this.progressBar1);
            this.dashBoardTab.Controls.Add(this.label2);
            this.dashBoardTab.Controls.Add(this.btnExit);
            this.dashBoardTab.Controls.Add(this.pictureBox3);
            this.dashBoardTab.Controls.Add(this.pictureBox4);
            this.dashBoardTab.Controls.Add(this.pictureBox2);
            this.dashBoardTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashBoardTab.Location = new System.Drawing.Point(4, 22);
            this.dashBoardTab.Name = "dashBoardTab";
            this.dashBoardTab.Padding = new System.Windows.Forms.Padding(3);
            this.dashBoardTab.Size = new System.Drawing.Size(501, 413);
            this.dashBoardTab.TabIndex = 0;
            this.dashBoardTab.Text = "Dashboard";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Menu;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(75, 64);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(347, 143);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(127, 261);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(295, 15);
            this.progressBar2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Memory Usage:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(127, 223);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(295, 15);
            this.progressBar1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "CPU Utilization:";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(417, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(77, 29);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = " Close";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(245, 293);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(256, 120);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(501, 296);
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.PictureBox4_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(0, 293);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(248, 120);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // cpuSchedulerTab
            // 
            this.cpuSchedulerTab.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cpuSchedulerTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cpuSchedulerTab.BackgroundImage")));
            this.cpuSchedulerTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cpuSchedulerTab.Controls.Add(this.btnRoundRobin);
            this.cpuSchedulerTab.Controls.Add(this.restartApp);
            this.cpuSchedulerTab.Controls.Add(this.btnPriority);
            this.cpuSchedulerTab.Controls.Add(this.btnSJF);
            this.cpuSchedulerTab.Controls.Add(this.btnFCFS);
            this.cpuSchedulerTab.Controls.Add(this.txtProcess);
            this.cpuSchedulerTab.Controls.Add(this.labelProcess);
            this.cpuSchedulerTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpuSchedulerTab.Location = new System.Drawing.Point(4, 22);
            this.cpuSchedulerTab.Name = "cpuSchedulerTab";
            this.cpuSchedulerTab.Padding = new System.Windows.Forms.Padding(3);
            this.cpuSchedulerTab.Size = new System.Drawing.Size(501, 413);
            this.cpuSchedulerTab.TabIndex = 1;
            this.cpuSchedulerTab.Text = "CPU Scheduler";
            // 
            // btnRoundRobin
            // 
            this.btnRoundRobin.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnRoundRobin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoundRobin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnRoundRobin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoundRobin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoundRobin.Image = ((System.Drawing.Image)(resources.GetObject("btnRoundRobin.Image")));
            this.btnRoundRobin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoundRobin.Location = new System.Drawing.Point(247, 278);
            this.btnRoundRobin.Name = "btnRoundRobin";
            this.btnRoundRobin.Size = new System.Drawing.Size(85, 45);
            this.btnRoundRobin.TabIndex = 12;
            this.btnRoundRobin.Text = "Round\r\nRobin";
            this.btnRoundRobin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoundRobin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRoundRobin.UseVisualStyleBackColor = false;
            this.btnRoundRobin.Click += new System.EventHandler(this.RoundRobinButton_Click);
            // 
            // restartApp
            // 
            this.restartApp.AutoSize = true;
            this.restartApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.restartApp.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartApp.ForeColor = System.Drawing.Color.Lime;
            this.restartApp.Location = new System.Drawing.Point(362, 379);
            this.restartApp.Name = "restartApp";
            this.restartApp.Size = new System.Drawing.Size(113, 15);
            this.restartApp.TabIndex = 11;
            this.restartApp.Text = "Restart Application";
            this.restartApp.Click += new System.EventHandler(this.RestartApp_Click);
            // 
            // btnPriority
            // 
            this.btnPriority.BackColor = System.Drawing.Color.Bisque;
            this.btnPriority.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPriority.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriority.Image = ((System.Drawing.Image)(resources.GetObject("btnPriority.Image")));
            this.btnPriority.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPriority.Location = new System.Drawing.Point(347, 278);
            this.btnPriority.Name = "btnPriority";
            this.btnPriority.Size = new System.Drawing.Size(107, 45);
            this.btnPriority.TabIndex = 10;
            this.btnPriority.Text = "PRIORITY";
            this.btnPriority.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPriority.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPriority.UseVisualStyleBackColor = false;
            this.btnPriority.Click += new System.EventHandler(this.PriorityButton_Click);
            // 
            // btnSJF
            // 
            this.btnSJF.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnSJF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSJF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnSJF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSJF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSJF.Image = ((System.Drawing.Image)(resources.GetObject("btnSJF.Image")));
            this.btnSJF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSJF.Location = new System.Drawing.Point(115, 278);
            this.btnSJF.Name = "btnSJF";
            this.btnSJF.Size = new System.Drawing.Size(117, 45);
            this.btnSJF.TabIndex = 9;
            this.btnSJF.Text = "SHORTEST JOB FIRST";
            this.btnSJF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSJF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSJF.UseVisualStyleBackColor = false;
            this.btnSJF.Click += new System.EventHandler(this.ShortestJobFirstButton_Click);
            // 
            // btnFCFS
            // 
            this.btnFCFS.BackColor = System.Drawing.Color.Beige;
            this.btnFCFS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFCFS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnFCFS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFCFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFCFS.Image = ((System.Drawing.Image)(resources.GetObject("btnFCFS.Image")));
            this.btnFCFS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFCFS.Location = new System.Drawing.Point(16, 278);
            this.btnFCFS.Name = "btnFCFS";
            this.btnFCFS.Size = new System.Drawing.Size(84, 45);
            this.btnFCFS.TabIndex = 8;
            this.btnFCFS.Text = "FCFS";
            this.btnFCFS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFCFS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFCFS.UseVisualStyleBackColor = false;
            this.btnFCFS.Click += new System.EventHandler(this.FirstComeFirstServeButton_Click);
            // 
            // txtProcess
            // 
            this.txtProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcess.Location = new System.Drawing.Point(205, 73);
            this.txtProcess.Multiline = true;
            this.txtProcess.Name = "txtProcess";
            this.txtProcess.Size = new System.Drawing.Size(249, 33);
            this.txtProcess.TabIndex = 7;
            this.txtProcess.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProcess.TextChanged += new System.EventHandler(this.ProcessTextBox_TextChanged);
            // 
            // labelProcess
            // 
            this.labelProcess.AutoSize = true;
            this.labelProcess.Location = new System.Drawing.Point(29, 91);
            this.labelProcess.Name = "labelProcess";
            this.labelProcess.Size = new System.Drawing.Size(148, 15);
            this.labelProcess.TabIndex = 6;
            this.labelProcess.Text = "Number of Processes:";
            // 
            // timer1
            //
            this.timer1.Tick += new System.EventHandler(this.FadeOutTimer_Tick);
            // 
            // CpuSchedulerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 439);
            this.Controls.Add(this.tabSelection);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CpuSchedulerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CpuSchedulerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabSelection.ResumeLayout(false);
            this.dashBoardTab.ResumeLayout(false);
            this.dashBoardTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.cpuSchedulerTab.ResumeLayout(false);
            this.cpuSchedulerTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCpuScheduler;
        private System.Windows.Forms.Button btnDashBoard;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabSelection;
        private System.Windows.Forms.TabPage dashBoardTab;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabPage cpuSchedulerTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label restartApp;
        private System.Windows.Forms.Button btnPriority;
        private System.Windows.Forms.Button btnSJF;
        private System.Windows.Forms.Button btnFCFS;
        public System.Windows.Forms.TextBox txtProcess;
        private System.Windows.Forms.Label labelProcess;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRoundRobin;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Timer timer1;
    }
}