namespace SerialCommunication
{
    partial class frmPackageView
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
            gridPackage = new DataGridView();
            Header = new DataGridViewTextBoxColumn();
            VarLen = new DataGridViewTextBoxColumn();
            Speed = new DataGridViewTextBoxColumn();
            StartAngle = new DataGridViewTextBoxColumn();
            EndAngle = new DataGridViewTextBoxColumn();
            Timestamps = new DataGridViewTextBoxColumn();
            CrcCheck = new DataGridViewTextBoxColumn();
            gridPoints = new DataGridView();
            Distance = new DataGridViewTextBoxColumn();
            Intensity = new DataGridViewTextBoxColumn();
            btnNext = new Button();
            btnBack = new Button();
            label1 = new Label();
            txtPacNumber = new TextBox();
            label2 = new Label();
            txtOverall = new TextBox();
            btnCSV = new Button();
            ((System.ComponentModel.ISupportInitialize)gridPackage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridPoints).BeginInit();
            SuspendLayout();
            // 
            // gridPackage
            // 
            gridPackage.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPackage.Columns.AddRange(new DataGridViewColumn[] { Header, VarLen, Speed, StartAngle, EndAngle, Timestamps, CrcCheck });
            gridPackage.Location = new Point(26, 39);
            gridPackage.Name = "gridPackage";
            gridPackage.RowHeadersWidth = 51;
            gridPackage.Size = new Size(928, 99);
            gridPackage.TabIndex = 0;
            // 
            // Header
            // 
            Header.HeaderText = "Header";
            Header.MinimumWidth = 6;
            Header.Name = "Header";
            Header.Width = 125;
            // 
            // VarLen
            // 
            VarLen.HeaderText = "VarLen";
            VarLen.MinimumWidth = 6;
            VarLen.Name = "VarLen";
            VarLen.Width = 125;
            // 
            // Speed
            // 
            Speed.HeaderText = "Speed";
            Speed.MinimumWidth = 6;
            Speed.Name = "Speed";
            Speed.Width = 125;
            // 
            // StartAngle
            // 
            StartAngle.HeaderText = "Start angle";
            StartAngle.MinimumWidth = 6;
            StartAngle.Name = "StartAngle";
            StartAngle.Width = 125;
            // 
            // EndAngle
            // 
            EndAngle.HeaderText = "End angle";
            EndAngle.MinimumWidth = 6;
            EndAngle.Name = "EndAngle";
            EndAngle.Width = 125;
            // 
            // Timestamps
            // 
            Timestamps.HeaderText = "Timestamps";
            Timestamps.MinimumWidth = 6;
            Timestamps.Name = "Timestamps";
            Timestamps.Width = 125;
            // 
            // CrcCheck
            // 
            CrcCheck.HeaderText = "Crc check";
            CrcCheck.MinimumWidth = 6;
            CrcCheck.Name = "CrcCheck";
            CrcCheck.Width = 125;
            // 
            // gridPoints
            // 
            gridPoints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPoints.Columns.AddRange(new DataGridViewColumn[] { Distance, Intensity });
            gridPoints.Location = new Point(26, 154);
            gridPoints.Name = "gridPoints";
            gridPoints.RowHeadersWidth = 51;
            gridPoints.Size = new Size(348, 397);
            gridPoints.TabIndex = 1;
            // 
            // Distance
            // 
            Distance.HeaderText = "Distance";
            Distance.MinimumWidth = 6;
            Distance.Name = "Distance";
            Distance.Width = 125;
            // 
            // Intensity
            // 
            Intensity.HeaderText = "Intensity";
            Intensity.MinimumWidth = 6;
            Intensity.Name = "Intensity";
            Intensity.Width = 125;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Segoe UI", 20F);
            btnNext.Location = new Point(776, 339);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(99, 58);
            btnNext.TabIndex = 2;
            btnNext.Text = "->";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 20F);
            btnBack.Location = new Point(484, 339);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(98, 58);
            btnBack.TabIndex = 3;
            btnBack.Text = "<-";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(628, 414);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 4;
            label1.Text = "Package number";
            // 
            // txtPacNumber
            // 
            txtPacNumber.Location = new Point(621, 354);
            txtPacNumber.Name = "txtPacNumber";
            txtPacNumber.Size = new Size(125, 27);
            txtPacNumber.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(596, 193);
            label2.Name = "label2";
            label2.Size = new Size(177, 20);
            label2.TabIndex = 6;
            label2.Text = "Overall packages number";
            // 
            // txtOverall
            // 
            txtOverall.Location = new Point(621, 240);
            txtOverall.Name = "txtOverall";
            txtOverall.Size = new Size(125, 27);
            txtOverall.TabIndex = 7;
            // 
            // btnCSV
            // 
            btnCSV.Location = new Point(621, 484);
            btnCSV.Name = "btnCSV";
            btnCSV.Size = new Size(148, 41);
            btnCSV.TabIndex = 8;
            btnCSV.Text = "Export to CSV";
            btnCSV.UseVisualStyleBackColor = true;
            btnCSV.Click += btnCSV_Click;
            // 
            // frmPackageView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(979, 563);
            Controls.Add(btnCSV);
            Controls.Add(txtOverall);
            Controls.Add(label2);
            Controls.Add(txtPacNumber);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Controls.Add(btnNext);
            Controls.Add(gridPoints);
            Controls.Add(gridPackage);
            Name = "frmPackageView";
            Text = "frmPackageView";
            ((System.ComponentModel.ISupportInitialize)gridPackage).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridPoints).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridPackage;
        private DataGridViewTextBoxColumn Header;
        private DataGridViewTextBoxColumn VarLen;
        private DataGridViewTextBoxColumn Speed;
        private DataGridViewTextBoxColumn StartAngle;
        private DataGridViewTextBoxColumn EndAngle;
        private DataGridViewTextBoxColumn Timestamps;
        private DataGridViewTextBoxColumn CrcCheck;
        private DataGridView gridPoints;
        private DataGridViewTextBoxColumn Distance;
        private DataGridViewTextBoxColumn Intensity;
        private Button btnNext;
        private Button btnBack;
        private Label label1;
        private TextBox txtPacNumber;
        private Label label2;
        private TextBox txtOverall;
        private Button btnCSV;
    }
}