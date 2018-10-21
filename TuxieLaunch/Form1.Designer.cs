namespace TuxieLaunch
{
    partial class TuxieLauncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TuxieLauncher));
            this.btnGamemodeCreate = new System.Windows.Forms.Button();
            this.contentMountListBox = new System.Windows.Forms.CheckedListBox();
            this.lblMainSteam = new System.Windows.Forms.Label();
            this.lblSteamDirs = new System.Windows.Forms.Label();
            this.btnStartHammer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ddTools = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ddGameToModFor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkLbFgd = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAbout = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.lblNotConfigured = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGamemodeCreate
            // 
            this.btnGamemodeCreate.Enabled = false;
            this.btnGamemodeCreate.Location = new System.Drawing.Point(6, 697);
            this.btnGamemodeCreate.Name = "btnGamemodeCreate";
            this.btnGamemodeCreate.Size = new System.Drawing.Size(886, 41);
            this.btnGamemodeCreate.TabIndex = 0;
            this.btnGamemodeCreate.Text = "Create the gamemode";
            this.btnGamemodeCreate.UseVisualStyleBackColor = true;
            this.btnGamemodeCreate.Click += new System.EventHandler(this.button1_Click);
            // 
            // contentMountListBox
            // 
            this.contentMountListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentMountListBox.FormattingEnabled = true;
            this.contentMountListBox.Location = new System.Drawing.Point(12, 71);
            this.contentMountListBox.Name = "contentMountListBox";
            this.contentMountListBox.Size = new System.Drawing.Size(868, 139);
            this.contentMountListBox.TabIndex = 1;
            // 
            // lblMainSteam
            // 
            this.lblMainSteam.AutoSize = true;
            this.lblMainSteam.Location = new System.Drawing.Point(14, 16);
            this.lblMainSteam.Name = "lblMainSteam";
            this.lblMainSteam.Size = new System.Drawing.Size(107, 13);
            this.lblMainSteam.TabIndex = 2;
            this.lblMainSteam.Text = "Main steam directory:";
            // 
            // lblSteamDirs
            // 
            this.lblSteamDirs.AutoSize = true;
            this.lblSteamDirs.Location = new System.Drawing.Point(14, 44);
            this.lblSteamDirs.Name = "lblSteamDirs";
            this.lblSteamDirs.Size = new System.Drawing.Size(116, 13);
            this.lblSteamDirs.TabIndex = 3;
            this.lblSteamDirs.Text = "Steam stores detected:";
            // 
            // btnStartHammer
            // 
            this.btnStartHammer.Enabled = false;
            this.btnStartHammer.Location = new System.Drawing.Point(22, 12);
            this.btnStartHammer.Name = "btnStartHammer";
            this.btnStartHammer.Size = new System.Drawing.Size(83, 23);
            this.btnStartHammer.TabIndex = 5;
            this.btnStartHammer.Text = "Start Hammer";
            this.btnStartHammer.UseVisualStyleBackColor = true;
            this.btnStartHammer.Click += new System.EventHandler(this.btnStartHammer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 52);
            this.label1.TabIndex = 6;
            this.label1.Text = "Here is a list of the games we found that you can mount, so they are usable in ha" +
    "mmer.\r\nCheck the ones you think your players have.\r\n\r\nContent directories to mou" +
    "nt:";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.lblSteamDirs);
            this.groupBox1.Controls.Add(this.lblMainSteam);
            this.groupBox1.Location = new System.Drawing.Point(9, 268);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(893, 73);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.ddTools);
            this.groupBox2.Controls.Add(this.chkLbFgd);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ddGameToModFor);
            this.groupBox2.Controls.Add(this.contentMountListBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(6, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(886, 596);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // ddTools
            // 
            this.ddTools.BackColor = System.Drawing.Color.MistyRose;
            this.ddTools.FormattingEnabled = true;
            this.ddTools.Location = new System.Drawing.Point(12, 504);
            this.ddTools.Name = "ddTools";
            this.ddTools.Size = new System.Drawing.Size(868, 21);
            this.ddTools.TabIndex = 12;
            this.ddTools.SelectedIndexChanged += new System.EventHandler(this.selectedtoolstousechanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 487);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tools to use:";
            // 
            // ddGameToModFor
            // 
            this.ddGameToModFor.BackColor = System.Drawing.Color.MistyRose;
            this.ddGameToModFor.FormattingEnabled = true;
            this.ddGameToModFor.Location = new System.Drawing.Point(12, 463);
            this.ddGameToModFor.Name = "ddGameToModFor";
            this.ddGameToModFor.Size = new System.Drawing.Size(868, 21);
            this.ddGameToModFor.TabIndex = 10;
            this.ddGameToModFor.SelectedIndexChanged += new System.EventHandler(this.selectedgametomodforchanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(590, 78);
            this.label3.TabIndex = 9;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // chkLbFgd
            // 
            this.chkLbFgd.FormattingEnabled = true;
            this.chkLbFgd.Location = new System.Drawing.Point(10, 274);
            this.chkLbFgd.Name = "chkLbFgd";
            this.chkLbFgd.Size = new System.Drawing.Size(870, 94);
            this.chkLbFgd.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(467, 52);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hammer uses .fgd files to figure out what parameters and entities exists, for thi" +
    "ngs like player_start.\r\nCheck the ones you want to use, for the game you want to" +
    " map for.\r\n\r\nGame definitions to add:";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Enabled = false;
            this.btnOpenFolder.Location = new System.Drawing.Point(111, 12);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFolder.TabIndex = 9;
            this.btnOpenFolder.Text = "Open folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(22, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(913, 0);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(828, 12);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(107, 23);
            this.btnAbout.TabIndex = 10;
            this.btnAbout.Text = "About and Thanks";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(22, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(913, 773);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(905, 884);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Introduction and Information";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(893, 256);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Introduction";
            // 
            // label5
            // 
            this.label5.AutoEllipsis = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(881, 243);
            this.label5.TabIndex = 8;
            this.label5.Text = resources.GetString("label5.Text");
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.btnGamemodeCreate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(905, 747);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings and creation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtDebug);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(905, 884);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Debug output";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtDebug
            // 
            this.txtDebug.Location = new System.Drawing.Point(3, 3);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ReadOnly = true;
            this.txtDebug.Size = new System.Drawing.Size(899, 743);
            this.txtDebug.TabIndex = 0;
            // 
            // lblNotConfigured
            // 
            this.lblNotConfigured.AutoSize = true;
            this.lblNotConfigured.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotConfigured.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblNotConfigured.Location = new System.Drawing.Point(192, 15);
            this.lblNotConfigured.Name = "lblNotConfigured";
            this.lblNotConfigured.Size = new System.Drawing.Size(98, 16);
            this.lblNotConfigured.TabIndex = 12;
            this.lblNotConfigured.Text = "Not configured!";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(893, 83);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Creation time!";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(567, 52);
            this.label6.TabIndex = 0;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 541);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(608, 39);
            this.label7.TabIndex = 13;
            this.label7.Text = resources.GetString("label7.Text");
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // TuxieLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(947, 827);
            this.Controls.Add(this.lblNotConfigured);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.btnStartHammer);
            this.Name = "TuxieLauncher";
            this.Text = "TuxieLauncher";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGamemodeCreate;
        private System.Windows.Forms.CheckedListBox contentMountListBox;
        private System.Windows.Forms.Label lblMainSteam;
        private System.Windows.Forms.Label lblSteamDirs;
        private System.Windows.Forms.Button btnStartHammer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox chkLbFgd;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.ComboBox ddTools;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddGameToModFor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.Label lblNotConfigured;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

