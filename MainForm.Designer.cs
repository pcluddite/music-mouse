//
// Copyright (c) 2012 Timothy Baxendale
//
namespace Musical_Mouse_Customizer
{
    partial class MainForm
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
            System.Windows.Forms.Label lblAudioPath;
            System.Windows.Forms.Label lblCode;
            System.Windows.Forms.Label lblIcon;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtMusicPath = new System.Windows.Forms.TextBox();
            this.btnBrowseAudio = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.btnCompile = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.checkBoxResumePlay = new System.Windows.Forms.CheckBox();
            this.txtIconPath = new System.Windows.Forms.TextBox();
            this.btnBrowseIcon = new System.Windows.Forms.Button();
            this.browseAudioDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveOutputDlg = new System.Windows.Forms.SaveFileDialog();
            this.browseIconDlg = new System.Windows.Forms.OpenFileDialog();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.compileWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.checkBoxAutoUnmute = new System.Windows.Forms.CheckBox();
            this.lblVolume = new System.Windows.Forms.Label();
            this.trackBarVol = new System.Windows.Forms.TrackBar();
            lblAudioPath = new System.Windows.Forms.Label();
            lblCode = new System.Windows.Forms.Label();
            lblIcon = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVol)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAudioPath
            // 
            lblAudioPath.AutoSize = true;
            lblAudioPath.Location = new System.Drawing.Point(39, 20);
            lblAudioPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAudioPath.Name = "lblAudioPath";
            lblAudioPath.Size = new System.Drawing.Size(74, 17);
            lblAudioPath.TabIndex = 0;
            lblAudioPath.Text = "Music File:";
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new System.Drawing.Point(7, 52);
            lblCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCode.Name = "lblCode";
            lblCode.Size = new System.Drawing.Size(107, 17);
            lblCode.TabIndex = 3;
            lblCode.Text = "Disabling Code:";
            // 
            // lblIcon
            // 
            lblIcon.AutoSize = true;
            lblIcon.Location = new System.Drawing.Point(73, 84);
            lblIcon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new System.Drawing.Size(38, 17);
            lblIcon.TabIndex = 8;
            lblIcon.Text = "Icon:";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(25, 119);
            this.lblOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(88, 17);
            this.lblOutput.TabIndex = 11;
            this.lblOutput.Text = "Output Path:";
            // 
            // txtMusicPath
            // 
            this.txtMusicPath.Location = new System.Drawing.Point(123, 16);
            this.txtMusicPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtMusicPath.Name = "txtMusicPath";
            this.txtMusicPath.ReadOnly = true;
            this.txtMusicPath.Size = new System.Drawing.Size(236, 22);
            this.txtMusicPath.TabIndex = 1;
            // 
            // btnBrowseAudio
            // 
            this.btnBrowseAudio.Location = new System.Drawing.Point(368, 14);
            this.btnBrowseAudio.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseAudio.Name = "btnBrowseAudio";
            this.btnBrowseAudio.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseAudio.TabIndex = 2;
            this.btnBrowseAudio.Text = "Browse...";
            this.btnBrowseAudio.UseVisualStyleBackColor = true;
            this.btnBrowseAudio.Click += new System.EventHandler(this.btnBrowseAudio_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(123, 48);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(152, 22);
            this.txtCode.TabIndex = 4;
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(368, 112);
            this.btnBrowseOutput.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseOutput.TabIndex = 13;
            this.btnBrowseOutput.Text = "Browse...";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // btnCompile
            // 
            this.btnCompile.Location = new System.Drawing.Point(245, 198);
            this.btnCompile.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(100, 28);
            this.btnCompile.TabIndex = 1;
            this.btnCompile.Text = "Compile";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(123, 116);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(236, 22);
            this.txtOutput.TabIndex = 12;
            // 
            // checkBoxResumePlay
            // 
            this.checkBoxResumePlay.AutoSize = true;
            this.checkBoxResumePlay.Checked = true;
            this.checkBoxResumePlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxResumePlay.Location = new System.Drawing.Point(11, 150);
            this.checkBoxResumePlay.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxResumePlay.Name = "checkBoxResumePlay";
            this.checkBoxResumePlay.Size = new System.Drawing.Size(254, 21);
            this.checkBoxResumePlay.TabIndex = 14;
            this.checkBoxResumePlay.Text = "Resume Song Play on Mouse Move";
            this.checkBoxResumePlay.UseVisualStyleBackColor = true;
            // 
            // txtIconPath
            // 
            this.txtIconPath.Location = new System.Drawing.Point(123, 80);
            this.txtIconPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtIconPath.Name = "txtIconPath";
            this.txtIconPath.ReadOnly = true;
            this.txtIconPath.Size = new System.Drawing.Size(236, 22);
            this.txtIconPath.TabIndex = 9;
            // 
            // btnBrowseIcon
            // 
            this.btnBrowseIcon.Location = new System.Drawing.Point(368, 78);
            this.btnBrowseIcon.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseIcon.Name = "btnBrowseIcon";
            this.btnBrowseIcon.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseIcon.TabIndex = 10;
            this.btnBrowseIcon.Text = "Browse...";
            this.btnBrowseIcon.UseVisualStyleBackColor = true;
            this.btnBrowseIcon.Click += new System.EventHandler(this.btnBrowseIcon_Click);
            // 
            // browseAudioDlg
            // 
            this.browseAudioDlg.Filter = "All Files (*.*)|*.*";
            this.browseAudioDlg.Title = "Open File";
            // 
            // saveOutputDlg
            // 
            this.saveOutputDlg.Filter = "Executable Files (*.exe)|*.exe";
            this.saveOutputDlg.Title = "Save Executable";
            // 
            // browseIconDlg
            // 
            this.browseIconDlg.Filter = "Icon Files (*.ico)|*.ico";
            this.browseIconDlg.Title = "Open File";
            // 
            // lblTimeout
            // 
            this.lblTimeout.AutoSize = true;
            this.lblTimeout.Location = new System.Drawing.Point(284, 52);
            this.lblTimeout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(63, 17);
            this.lblTimeout.TabIndex = 5;
            this.lblTimeout.Text = "Timeout:";
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(348, 48);
            this.txtTimeout.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(37, 22);
            this.txtTimeout.TabIndex = 6;
            this.txtTimeout.Text = "5";
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Location = new System.Drawing.Point(386, 52);
            this.lblSeconds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(61, 17);
            this.lblSeconds.TabIndex = 7;
            this.lblSeconds.Text = "seconds";
            // 
            // compileWorker
            // 
            this.compileWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.compileWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.compileWorker_RunWorkerCompleted);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.txtTimeout);
            this.groupBox.Controls.Add(this.checkBoxAutoUnmute);
            this.groupBox.Controls.Add(this.lblVolume);
            this.groupBox.Controls.Add(this.trackBarVol);
            this.groupBox.Controls.Add(lblAudioPath);
            this.groupBox.Controls.Add(this.lblSeconds);
            this.groupBox.Controls.Add(this.lblOutput);
            this.groupBox.Controls.Add(this.txtMusicPath);
            this.groupBox.Controls.Add(this.lblTimeout);
            this.groupBox.Controls.Add(this.btnBrowseAudio);
            this.groupBox.Controls.Add(lblIcon);
            this.groupBox.Controls.Add(lblCode);
            this.groupBox.Controls.Add(this.btnBrowseIcon);
            this.groupBox.Controls.Add(this.txtCode);
            this.groupBox.Controls.Add(this.txtIconPath);
            this.groupBox.Controls.Add(this.btnBrowseOutput);
            this.groupBox.Controls.Add(this.checkBoxResumePlay);
            this.groupBox.Controls.Add(this.txtOutput);
            this.groupBox.Location = new System.Drawing.Point(16, 7);
            this.groupBox.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox.Size = new System.Drawing.Size(544, 183);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Options";
            // 
            // checkBoxAutoUnmute
            // 
            this.checkBoxAutoUnmute.AutoSize = true;
            this.checkBoxAutoUnmute.Checked = true;
            this.checkBoxAutoUnmute.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoUnmute.Location = new System.Drawing.Point(273, 150);
            this.checkBoxAutoUnmute.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxAutoUnmute.Name = "checkBoxAutoUnmute";
            this.checkBoxAutoUnmute.Size = new System.Drawing.Size(166, 21);
            this.checkBoxAutoUnmute.TabIndex = 15;
            this.checkBoxAutoUnmute.Text = "Automatically Unmute";
            this.checkBoxAutoUnmute.UseVisualStyleBackColor = true;
            this.checkBoxAutoUnmute.CheckedChanged += new System.EventHandler(this.checkBoxAutoUnmute_CheckedChanged);
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(445, 151);
            this.lblVolume.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(91, 17);
            this.lblVolume.TabIndex = 17;
            this.lblVolume.Text = "Volume: 50%";
            // 
            // trackBarVol
            // 
            this.trackBarVol.Location = new System.Drawing.Point(476, 14);
            this.trackBarVol.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarVol.Name = "trackBarVol";
            this.trackBarVol.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarVol.Size = new System.Drawing.Size(56, 130);
            this.trackBarVol.TabIndex = 16;
            this.trackBarVol.Value = 5;
            this.trackBarVol.Scroll += new System.EventHandler(this.trackBarVol_Scroll);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnCompile;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 240);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.btnCompile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Musical Mouse";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtMusicPath;
        private System.Windows.Forms.Button btnBrowseAudio;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.CheckBox checkBoxResumePlay;
        private System.Windows.Forms.TextBox txtIconPath;
        private System.Windows.Forms.Button btnBrowseIcon;
        private System.Windows.Forms.OpenFileDialog browseAudioDlg;
        private System.Windows.Forms.SaveFileDialog saveOutputDlg;
        private System.Windows.Forms.OpenFileDialog browseIconDlg;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.Label lblSeconds;
        private System.ComponentModel.BackgroundWorker compileWorker;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.TrackBar trackBarVol;
        private System.Windows.Forms.CheckBox checkBoxAutoUnmute;
    }
}

