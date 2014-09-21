namespace ToTangoXport
{
    partial class Options
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbConfirmUrl = new System.Windows.Forms.TextBox();
            this.txbMappingFile = new System.Windows.Forms.TextBox();
            this.txbToken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txbOutputDirectory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbSQLConnection = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbSQLConnection);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txbOutputDirectory);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbConfirmUrl);
            this.groupBox1.Controls.Add(this.txbMappingFile);
            this.groupBox1.Controls.Add(this.txbToken);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 225);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Options ";
            // 
            // txbConfirmUrl
            // 
            this.txbConfirmUrl.Location = new System.Drawing.Point(141, 110);
            this.txbConfirmUrl.Name = "txbConfirmUrl";
            this.txbConfirmUrl.Size = new System.Drawing.Size(354, 20);
            this.txbConfirmUrl.TabIndex = 5;
            // 
            // txbMappingFile
            // 
            this.txbMappingFile.Location = new System.Drawing.Point(141, 73);
            this.txbMappingFile.Name = "txbMappingFile";
            this.txbMappingFile.Size = new System.Drawing.Size(354, 20);
            this.txbMappingFile.TabIndex = 4;
            // 
            // txbToken
            // 
            this.txbToken.Location = new System.Drawing.Point(141, 39);
            this.txbToken.Name = "txbToken";
            this.txbToken.Size = new System.Drawing.Size(354, 20);
            this.txbToken.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confimation URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mapping File:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Token:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(366, 254);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(466, 254);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txbOutputDirectory
            // 
            this.txbOutputDirectory.Location = new System.Drawing.Point(141, 144);
            this.txbOutputDirectory.Name = "txbOutputDirectory";
            this.txbOutputDirectory.Size = new System.Drawing.Size(354, 20);
            this.txbOutputDirectory.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Output Directory:";
            // 
            // txbSQLConnection
            // 
            this.txbSQLConnection.Location = new System.Drawing.Point(141, 181);
            this.txbSQLConnection.Name = "txbSQLConnection";
            this.txbSQLConnection.Size = new System.Drawing.Size(354, 20);
            this.txbSQLConnection.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "SQL Connection:";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 289);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.Text = "Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Options_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txbConfirmUrl;
        private System.Windows.Forms.TextBox txbMappingFile;
        private System.Windows.Forms.TextBox txbToken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbOutputDirectory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbSQLConnection;
        private System.Windows.Forms.Label label5;
    }
}