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
            this.btnGamemodeCreate = new System.Windows.Forms.Button();
            this.contentMountListBox = new System.Windows.Forms.CheckedListBox();
            this.lblMainSteam = new System.Windows.Forms.Label();
            this.lblSteamDirs = new System.Windows.Forms.Label();
            this.richTextBoxAdditionalSteamDirectory = new System.Windows.Forms.RichTextBox();
            this.btnStartHammer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkLbFgd = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ddGameToModFor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ddTools = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtconsolebox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGamemodeCreate
            // 
            this.btnGamemodeCreate.Location = new System.Drawing.Point(22, 12);
            this.btnGamemodeCreate.Name = "btnGamemodeCreate";
            this.btnGamemodeCreate.Size = new System.Drawing.Size(130, 23);
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
            this.contentMountListBox.Size = new System.Drawing.Size(889, 139);
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
            // richTextBoxAdditionalSteamDirectory
            // 
            this.richTextBoxAdditionalSteamDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxAdditionalSteamDirectory.Enabled = false;
            this.richTextBoxAdditionalSteamDirectory.Location = new System.Drawing.Point(814, 19);
            this.richTextBoxAdditionalSteamDirectory.Name = "richTextBoxAdditionalSteamDirectory";
            this.richTextBoxAdditionalSteamDirectory.Size = new System.Drawing.Size(0, 23);
            this.richTextBoxAdditionalSteamDirectory.TabIndex = 4;
            this.richTextBoxAdditionalSteamDirectory.Text = "";
            this.richTextBoxAdditionalSteamDirectory.TextChanged += new System.EventHandler(this.richTextBoxAdditionalSteamDirectory_TextChanged);
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
            this.groupBox1.Controls.Add(this.richTextBoxAdditionalSteamDirectory);
            this.groupBox1.Controls.Add(this.lblSteamDirs);
            this.groupBox1.Controls.Add(this.lblMainSteam);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(890, 73);
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
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.ddTools);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ddGameToModFor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.chkLbFgd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.contentMountListBox);
            this.groupBox2.Location = new System.Drawing.Point(3, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(907, 584);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // chkLbFgd
            // 
            this.chkLbFgd.FormattingEnabled = true;
            this.chkLbFgd.Location = new System.Drawing.Point(12, 194);
            this.chkLbFgd.Name = "chkLbFgd";
            this.chkLbFgd.Size = new System.Drawing.Size(890, 184);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Game to mod for:";
            // 
            // ddGameToModFor
            // 
            this.ddGameToModFor.FormattingEnabled = true;
            this.ddGameToModFor.Location = new System.Drawing.Point(12, 398);
            this.ddGameToModFor.Name = "ddGameToModFor";
            this.ddGameToModFor.Size = new System.Drawing.Size(890, 21);
            this.ddGameToModFor.TabIndex = 10;
            this.ddGameToModFor.SelectedIndexChanged += new System.EventHandler(this.selectedgametomodforchanged);
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
            // ddTools
            // 
            this.ddTools.FormattingEnabled = true;
            this.ddTools.Location = new System.Drawing.Point(12, 438);
            this.ddTools.Name = "ddTools";
            this.ddTools.Size = new System.Drawing.Size(890, 21);
            this.ddTools.TabIndex = 12;
            this.ddTools.SelectedIndexChanged += new System.EventHandler(this.selectedtoolstousechanged);
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
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(22, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(913, 669);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtconsolebox);
            this.groupBox3.Location = new System.Drawing.Point(6, 465);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(791, 100);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // txtconsolebox
            // 
            this.txtconsolebox.Location = new System.Drawing.Point(6, 20);
            this.txtconsolebox.MaxLength = 99999999;
            this.txtconsolebox.Multiline = true;
            this.txtconsolebox.Name = "txtconsolebox";
            this.txtconsolebox.Size = new System.Drawing.Size(779, 74);
            this.txtconsolebox.TabIndex = 0;
            // 
            // TuxieLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(947, 828);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.btnStartHammer);
            this.Controls.Add(this.btnGamemodeCreate);
            this.Name = "TuxieLauncher";
            this.Text = "TuxieLauncher";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.RichTextBox richTextBoxAdditionalSteamDirectory;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtconsolebox;
    }
}

