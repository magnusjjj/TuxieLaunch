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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGamemodeCreate
            // 
            this.btnGamemodeCreate.Location = new System.Drawing.Point(22, 496);
            this.btnGamemodeCreate.Name = "btnGamemodeCreate";
            this.btnGamemodeCreate.Size = new System.Drawing.Size(869, 41);
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
            this.contentMountListBox.Location = new System.Drawing.Point(12, 32);
            this.contentMountListBox.Name = "contentMountListBox";
            this.contentMountListBox.Size = new System.Drawing.Size(851, 139);
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
            this.btnStartHammer.Location = new System.Drawing.Point(159, 12);
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
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Content directories to mount:";
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
            this.groupBox2.Controls.Add(this.ddTools);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ddGameToModFor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.chkLbFgd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.contentMountListBox);
            this.groupBox2.Location = new System.Drawing.Point(22, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(869, 478);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // ddTools
            // 
            this.ddTools.FormattingEnabled = true;
            this.ddTools.Location = new System.Drawing.Point(12, 438);
            this.ddTools.Name = "ddTools";
            this.ddTools.Size = new System.Drawing.Size(851, 21);
            this.ddTools.TabIndex = 12;
            this.ddTools.SelectedIndexChanged += new System.EventHandler(this.selectedtoolstousechanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tools to use:";
            // 
            // ddGameToModFor
            // 
            this.ddGameToModFor.FormattingEnabled = true;
            this.ddGameToModFor.Location = new System.Drawing.Point(12, 398);
            this.ddGameToModFor.Name = "ddGameToModFor";
            this.ddGameToModFor.Size = new System.Drawing.Size(851, 21);
            this.ddGameToModFor.TabIndex = 10;
            this.ddGameToModFor.SelectedIndexChanged += new System.EventHandler(this.selectedgametomodforchanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Game to mod for:";
            // 
            // chkLbFgd
            // 
            this.chkLbFgd.FormattingEnabled = true;
            this.chkLbFgd.Location = new System.Drawing.Point(12, 194);
            this.chkLbFgd.Name = "chkLbFgd";
            this.chkLbFgd.Size = new System.Drawing.Size(851, 184);
            this.chkLbFgd.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Game definitions to add:";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(249, 12);
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
            this.tabControl1.Size = new System.Drawing.Size(913, 775);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(905, 749);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Introduction and Information";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.btnGamemodeCreate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(905, 749);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings and creation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtDebug);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(905, 749);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Debug output";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            // txtDebug
            // 
            this.txtDebug.Location = new System.Drawing.Point(3, 3);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ReadOnly = true;
            this.txtDebug.Size = new System.Drawing.Size(899, 743);
            this.txtDebug.TabIndex = 0;
            // 
            // TuxieLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(947, 828);
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
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
    }
}

