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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.txbConfirmUrl = new System.Windows.Forms.TextBox();
            this.txbMappingFile = new System.Windows.Forms.TextBox();
            this.txbToken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnTest = new System.Windows.Forms.Button();
            this.BackupN = new System.Windows.Forms.RadioButton();
            this.BackupY = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txbSQLConnection = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txbOutputDirectory = new System.Windows.Forms.ComboBox();
            this.btnTestDir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 225);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Configuration Options ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(529, 200);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnTestDir);
            this.tabPage1.Controls.Add(this.txbOutputDirectory);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txbConfirmUrl);
            this.tabPage1.Controls.Add(this.txbMappingFile);
            this.tabPage1.Controls.Add(this.txbToken);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(521, 174);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Output Directory:";
            // 
            // txbConfirmUrl
            // 
            this.txbConfirmUrl.Location = new System.Drawing.Point(129, 90);
            this.txbConfirmUrl.Name = "txbConfirmUrl";
            this.txbConfirmUrl.Size = new System.Drawing.Size(354, 20);
            this.txbConfirmUrl.TabIndex = 15;
            // 
            // txbMappingFile
            // 
            this.txbMappingFile.Location = new System.Drawing.Point(129, 56);
            this.txbMappingFile.Name = "txbMappingFile";
            this.txbMappingFile.Size = new System.Drawing.Size(354, 20);
            this.txbMappingFile.TabIndex = 14;
            // 
            // txbToken
            // 
            this.txbToken.Location = new System.Drawing.Point(129, 22);
            this.txbToken.Name = "txbToken";
            this.txbToken.Size = new System.Drawing.Size(354, 20);
            this.txbToken.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Confimation URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mapping File:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Token:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnTest);
            this.tabPage2.Controls.Add(this.BackupN);
            this.tabPage2.Controls.Add(this.BackupY);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txbSQLConnection);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(521, 174);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SQL";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Enabled = false;
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Location = new System.Drawing.Point(421, 50);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(56, 22);
            this.btnTest.TabIndex = 25;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // BackupN
            // 
            this.BackupN.AutoSize = true;
            this.BackupN.Checked = true;
            this.BackupN.Location = new System.Drawing.Point(239, 73);
            this.BackupN.Name = "BackupN";
            this.BackupN.Size = new System.Drawing.Size(39, 17);
            this.BackupN.TabIndex = 24;
            this.BackupN.TabStop = true;
            this.BackupN.Text = "No";
            this.BackupN.UseVisualStyleBackColor = true;
            // 
            // BackupY
            // 
            this.BackupY.AutoSize = true;
            this.BackupY.Location = new System.Drawing.Point(190, 73);
            this.BackupY.Name = "BackupY";
            this.BackupY.Size = new System.Drawing.Size(43, 17);
            this.BackupY.TabIndex = 23;
            this.BackupY.Text = "Yes";
            this.BackupY.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Backup the data to SQL";
            // 
            // txbSQLConnection
            // 
            this.txbSQLConnection.Location = new System.Drawing.Point(123, 27);
            this.txbSQLConnection.Name = "txbSQLConnection";
            this.txbSQLConnection.Size = new System.Drawing.Size(354, 20);
            this.txbSQLConnection.TabIndex = 21;
            this.txbSQLConnection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbSQLConnection_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "SQL Connection:";
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
            this.txbOutputDirectory.FormattingEnabled = true;
            this.txbOutputDirectory.Items.AddRange(new object[] {
            ".",
            "\\\\nas\\dir\\QA\\ExactTarget",
            "\\\\nas\\dir\\Prod\\ExactTarget"});
            this.txbOutputDirectory.Location = new System.Drawing.Point(129, 124);
            this.txbOutputDirectory.Name = "txbOutputDirectory";
            this.txbOutputDirectory.Size = new System.Drawing.Size(296, 21);
            this.txbOutputDirectory.TabIndex = 17;
            this.txbOutputDirectory.DropDown += new System.EventHandler(this.txbOutputDirectory_SelectedIndexChanged);
            this.txbOutputDirectory.SelectedIndexChanged += new System.EventHandler(this.txbOutputDirectory_SelectedIndexChanged);
            this.txbOutputDirectory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbOutputDirectory_KeyDown);
            // 
            // btnTestDir
            // 
            this.btnTestDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestDir.Location = new System.Drawing.Point(427, 124);
            this.btnTestDir.Name = "btnTestDir";
            this.btnTestDir.Size = new System.Drawing.Size(56, 22);
            this.btnTestDir.TabIndex = 26;
            this.btnTestDir.Text = "Test";
            this.btnTestDir.UseVisualStyleBackColor = true;
            this.btnTestDir.Click += new System.EventHandler(this.btnTestDir_Click);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbConfirmUrl;
        private System.Windows.Forms.TextBox txbMappingFile;
        private System.Windows.Forms.TextBox txbToken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbSQLConnection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton BackupN;
        private System.Windows.Forms.RadioButton BackupY;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ComboBox txbOutputDirectory;
        private System.Windows.Forms.Button btnTestDir;
    }
}