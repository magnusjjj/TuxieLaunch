﻿namespace TuxieLaunch
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
            this.contentMountListBox.FormattingEnabled = true;
            this.contentMountListBox.Location = new System.Drawing.Point(12, 196);
            this.contentMountListBox.Name = "contentMountListBox";
            this.contentMountListBox.Size = new System.Drawing.Size(563, 259);
            this.contentMountListBox.TabIndex = 1;
            // 
            // lblMainSteam
            // 
            this.lblMainSteam.AutoSize = true;
            this.lblMainSteam.Location = new System.Drawing.Point(19, 50);
            this.lblMainSteam.Name = "lblMainSteam";
            this.lblMainSteam.Size = new System.Drawing.Size(70, 13);
            this.lblMainSteam.TabIndex = 2;
            this.lblMainSteam.Text = "lblMainSteam";
            // 
            // lblSteamDirs
            // 
            this.lblSteamDirs.AutoSize = true;
            this.lblSteamDirs.Location = new System.Drawing.Point(19, 72);
            this.lblSteamDirs.Name = "lblSteamDirs";
            this.lblSteamDirs.Size = new System.Drawing.Size(65, 13);
            this.lblSteamDirs.TabIndex = 3;
            this.lblSteamDirs.Text = "lblSteamDirs";
            // 
            // richTextBoxAdditionalSteamDirectory
            // 
            this.richTextBoxAdditionalSteamDirectory.Location = new System.Drawing.Point(12, 88);
            this.richTextBoxAdditionalSteamDirectory.Name = "richTextBoxAdditionalSteamDirectory";
            this.richTextBoxAdditionalSteamDirectory.Size = new System.Drawing.Size(563, 96);
            this.richTextBoxAdditionalSteamDirectory.TabIndex = 4;
            this.richTextBoxAdditionalSteamDirectory.Text = "";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 481);
            this.Controls.Add(this.btnStartHammer);
            this.Controls.Add(this.richTextBoxAdditionalSteamDirectory);
            this.Controls.Add(this.lblSteamDirs);
            this.Controls.Add(this.lblMainSteam);
            this.Controls.Add(this.contentMountListBox);
            this.Controls.Add(this.btnGamemodeCreate);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

