namespace SerialCommunication
{
    partial class frmReceiveData
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
            dataBox = new TextBox();
            btnRead = new Button();
            btnStopReading = new Button();
            txtBytePackage = new TextBox();
            btnConPac = new Button();
            txtPackageLenght = new TextBox();
            txt84 = new TextBox();
            btnPackages = new Button();
            SuspendLayout();
            // 
            // dataBox
            // 
            dataBox.Location = new Point(37, 23);
            dataBox.Multiline = true;
            dataBox.Name = "dataBox";
            dataBox.ScrollBars = ScrollBars.Vertical;
            dataBox.Size = new Size(607, 393);
            dataBox.TabIndex = 0;
            // 
            // btnRead
            // 
            btnRead.Location = new Point(80, 449);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(178, 39);
            btnRead.TabIndex = 1;
            btnRead.Text = "Read data";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // btnStopReading
            // 
            btnStopReading.Location = new Point(436, 449);
            btnStopReading.Name = "btnStopReading";
            btnStopReading.Size = new Size(178, 39);
            btnStopReading.TabIndex = 2;
            btnStopReading.Text = "Stop reading";
            btnStopReading.UseVisualStyleBackColor = true;
            btnStopReading.Click += btnStopReading_Click;
            // 
            // txtBytePackage
            // 
            txtBytePackage.Location = new Point(680, 23);
            txtBytePackage.Multiline = true;
            txtBytePackage.Name = "txtBytePackage";
            txtBytePackage.ScrollBars = ScrollBars.Vertical;
            txtBytePackage.Size = new Size(363, 393);
            txtBytePackage.TabIndex = 3;
            // 
            // btnConPac
            // 
            btnConPac.Location = new Point(680, 434);
            btnConPac.Name = "btnConPac";
            btnConPac.Size = new Size(178, 39);
            btnConPac.TabIndex = 4;
            btnConPac.Text = "Convert Package";
            btnConPac.UseVisualStyleBackColor = true;
            btnConPac.Click += btnConPac_Click;
            // 
            // txtPackageLenght
            // 
            txtPackageLenght.Location = new Point(900, 440);
            txtPackageLenght.Name = "txtPackageLenght";
            txtPackageLenght.Size = new Size(125, 27);
            txtPackageLenght.TabIndex = 5;
            // 
            // txt84
            // 
            txt84.Location = new Point(900, 500);
            txt84.Name = "txt84";
            txt84.Size = new Size(125, 27);
            txt84.TabIndex = 6;
            // 
            // btnPackages
            // 
            btnPackages.Location = new Point(680, 494);
            btnPackages.Name = "btnPackages";
            btnPackages.Size = new Size(178, 39);
            btnPackages.TabIndex = 7;
            btnPackages.Text = "See packages";
            btnPackages.UseVisualStyleBackColor = true;
            btnPackages.Click += btnPackages_Click;
            // 
            // frmReceiveData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 550);
            Controls.Add(btnPackages);
            Controls.Add(txt84);
            Controls.Add(txtPackageLenght);
            Controls.Add(btnConPac);
            Controls.Add(txtBytePackage);
            Controls.Add(btnStopReading);
            Controls.Add(btnRead);
            Controls.Add(dataBox);
            Name = "frmReceiveData";
            Text = "frmReceiveData";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox dataBox;
        private Button btnRead;
        private Button btnStopReading;
        private TextBox txtBytePackage;
        private Button btnConPac;
        private TextBox txtPackageLenght;
        private TextBox txt84;
        private Button btnPackages;
    }
}