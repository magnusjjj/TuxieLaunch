namespace TuxieLaunch
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.chkLbFgd = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.contentMountListBox.Size = new System.Drawing.Size(895, 139);
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
            this.richTextBoxAdditionalSteamDirectory.Location = new System.Drawing.Point(12, 60);
            this.richTextBoxAdditionalSteamDirectory.Name = "richTextBoxAdditionalSteamDirectory";
            this.richTextBoxAdditionalSteamDirectory.Size = new System.Drawing.Size(895, 103);
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
            this.groupBox1.Controls.Add(this.richTextBoxAdditionalSteamDirectory);
            this.groupBox1.Controls.Add(this.lblSteamDirs);
            this.groupBox1.Controls.Add(this.lblMainSteam);
            this.groupBox1.Location = new System.Drawing.Point(22, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(913, 169);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkLbFgd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.contentMountListBox);
            this.groupBox2.Location = new System.Drawing.Point(22, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(913, 390);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
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
            // chkLbFgd
            // 
            this.chkLbFgd.FormattingEnabled = true;
            this.chkLbFgd.Location = new System.Drawing.Point(17, 195);
            this.chkLbFgd.Name = "chkLbFgd";
            this.chkLbFgd.Size = new System.Drawing.Size(890, 184);
            this.chkLbFgd.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 619);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStartHammer);
            this.Controls.Add(this.btnGamemodeCreate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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
    }
}

