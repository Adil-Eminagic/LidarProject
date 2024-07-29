namespace SerialCommunication.Other_forms
{
    partial class frmAPI
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
            btnFetch = new Button();
            txtData = new TextBox();
            SuspendLayout();
            // 
            // btnFetch
            // 
            btnFetch.Location = new Point(343, 289);
            btnFetch.Name = "btnFetch";
            btnFetch.Size = new Size(94, 29);
            btnFetch.TabIndex = 0;
            btnFetch.Text = "Fetch data";
            btnFetch.UseVisualStyleBackColor = true;
            // 
            // txtData
            // 
            txtData.Location = new Point(274, 61);
            txtData.Multiline = true;
            txtData.Name = "txtData";
            txtData.Size = new Size(248, 181);
            txtData.TabIndex = 1;
            // 
            // frmAPI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtData);
            Controls.Add(btnFetch);
            Name = "frmAPI";
            Text = "frmAPI";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnFetch;
        private TextBox txtData;
    }
}