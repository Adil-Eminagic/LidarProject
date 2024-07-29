namespace SerialCommunication.Other_forms
{
    partial class frmDrawingSpace
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
            btnRead = new Button();
            btnPath = new Button();
            SuspendLayout();
            // 
            // btnRead
            // 
            btnRead.Location = new Point(12, 12);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(178, 39);
            btnRead.TabIndex = 2;
            btnRead.Text = "Read data";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // btnPath
            // 
            btnPath.Location = new Point(208, 12);
            btnPath.Name = "btnPath";
            btnPath.Size = new Size(131, 39);
            btnPath.TabIndex = 3;
            btnPath.Text = "Get path";
            btnPath.UseVisualStyleBackColor = true;
            btnPath.Click += btnPath_Click;
            // 
            // frmDrawingSpace
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 562);
            Controls.Add(btnPath);
            Controls.Add(btnRead);
            Name = "frmDrawingSpace";
            Text = "frmDrawingSpace";
            Paint += frmDrawingSpace_Paint_1;
            ResumeLayout(false);
        }

        #endregion

        private Button btnRead;
        private Button btnPath;
    }
}