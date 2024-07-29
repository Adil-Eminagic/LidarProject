namespace SerialCommunication.Other_forms
{
    partial class frmTest
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
            btnScan = new Button();
            SuspendLayout();
            // 
            // btnScan
            // 
            btnScan.Location = new Point(210, 200);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(94, 29);
            btnScan.TabIndex = 0;
            btnScan.Text = "Start scan";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += StartScanButton_Click;
            // 
            // frmTest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnScan);
            Name = "frmTest";
            Text = "frmTest";
            ResumeLayout(false);
        }

        #endregion

        private Button btnScan;
    }
}