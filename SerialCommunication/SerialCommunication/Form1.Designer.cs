namespace SerialCommunication
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnLightOn = new Button();
            btnLightOff = new Button();
            txtPortName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            txtBaudRate = new TextBox();
            btnConfirm = new Button();
            btnTimerStart = new Button();
            btnStopTimer = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            btnLidar = new Button();
            btnReceive = new Button();
            btnPlot = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnLightOn
            // 
            btnLightOn.BackColor = Color.Lime;
            btnLightOn.Font = new Font("Segoe UI", 12F);
            btnLightOn.Location = new Point(57, 54);
            btnLightOn.Name = "btnLightOn";
            btnLightOn.Size = new Size(118, 60);
            btnLightOn.TabIndex = 4;
            btnLightOn.Text = "Light ON";
            btnLightOn.UseVisualStyleBackColor = false;
            btnLightOn.Click += btnLightOn_Click;
            // 
            // btnLightOff
            // 
            btnLightOff.BackColor = Color.Red;
            btnLightOff.Font = new Font("Segoe UI", 12F);
            btnLightOff.ForeColor = Color.White;
            btnLightOff.Location = new Point(233, 54);
            btnLightOff.Name = "btnLightOff";
            btnLightOff.Size = new Size(118, 60);
            btnLightOff.TabIndex = 5;
            btnLightOff.Text = "Light OFF";
            btnLightOff.UseVisualStyleBackColor = false;
            btnLightOff.Click += btnLightOff_Click;
            // 
            // txtPortName
            // 
            txtPortName.Location = new Point(112, 38);
            txtPortName.Name = "txtPortName";
            txtPortName.Size = new Size(125, 27);
            txtPortName.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 41);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 7;
            label1.Text = "Port name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 95);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 8;
            label2.Text = "Baud rate";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtBaudRate);
            groupBox1.Controls.Add(btnConfirm);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtPortName);
            groupBox1.Location = new Point(253, 184);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(273, 188);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configuration";
            // 
            // txtBaudRate
            // 
            txtBaudRate.Location = new Point(112, 95);
            txtBaudRate.Name = "txtBaudRate";
            txtBaudRate.Size = new Size(125, 27);
            txtBaudRate.TabIndex = 11;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(143, 143);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(94, 29);
            btnConfirm.TabIndex = 10;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnTimerStart
            // 
            btnTimerStart.Location = new Point(464, 67);
            btnTimerStart.Name = "btnTimerStart";
            btnTimerStart.Size = new Size(113, 41);
            btnTimerStart.TabIndex = 10;
            btnTimerStart.Text = "Start timer";
            btnTimerStart.UseVisualStyleBackColor = true;
            btnTimerStart.Click += btnTimerStart_Click;
            // 
            // btnStopTimer
            // 
            btnStopTimer.Location = new Point(611, 67);
            btnStopTimer.Name = "btnStopTimer";
            btnStopTimer.Size = new Size(113, 41);
            btnStopTimer.TabIndex = 11;
            btnStopTimer.Text = "Stop timer";
            btnStopTimer.UseVisualStyleBackColor = true;
            btnStopTimer.Click += btnStopTimer_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // btnLidar
            // 
            btnLidar.Location = new Point(607, 197);
            btnLidar.Name = "btnLidar";
            btnLidar.Size = new Size(94, 29);
            btnLidar.TabIndex = 12;
            btnLidar.Text = "Lidar";
            btnLidar.UseVisualStyleBackColor = true;
            btnLidar.Click += btnLidar_Click;
            // 
            // btnReceive
            // 
            btnReceive.Location = new Point(595, 257);
            btnReceive.Name = "btnReceive";
            btnReceive.Size = new Size(117, 29);
            btnReceive.TabIndex = 13;
            btnReceive.Text = "Receive data";
            btnReceive.UseVisualStyleBackColor = true;
            btnReceive.Click += btnReceive_Click;
            // 
            // btnPlot
            // 
            btnPlot.Location = new Point(611, 327);
            btnPlot.Name = "btnPlot";
            btnPlot.Size = new Size(94, 29);
            btnPlot.TabIndex = 14;
            btnPlot.Text = "Plot";
            btnPlot.UseVisualStyleBackColor = true;
            btnPlot.Click += btnPlot_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPlot);
            Controls.Add(btnReceive);
            Controls.Add(btnLidar);
            Controls.Add(btnStopTimer);
            Controls.Add(btnTimerStart);
            Controls.Add(groupBox1);
            Controls.Add(btnLightOff);
            Controls.Add(btnLightOn);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox StringSize;
        private Button btnLightOn;
        private Button btnLightOff;
        private TextBox txtPortName;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private Button btnConfirm;
        private TextBox txtBaudRate;
        private Button btnTimerStart;
        private Button btnStopTimer;
        private System.Windows.Forms.Timer timer1;
        private Button btnLidar;
        private Button btnReceive;
        private Button btnPlot;
    }
}
