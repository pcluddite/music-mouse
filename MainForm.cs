//
// Copyright (c) 2012 Timothy Baxendale
//
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Musical_Mouse_Customizer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowseAudio_Click(object sender, EventArgs e)
        {
            if (browseAudioDlg.ShowDialog() == DialogResult.OK)
            {
                txtMusicPath.Text = browseAudioDlg.FileName;
            }
        }

        private void btnBrowseIcon_Click(object sender, EventArgs e)
        {
            if (browseIconDlg.ShowDialog() == DialogResult.OK)
            {
                txtIconPath.Text = browseIconDlg.FileName;
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            if (saveOutputDlg.ShowDialog() == DialogResult.OK)
            {
                txtOutput.Text = saveOutputDlg.FileName;
            }
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            int promptTimeout;
            if (!int.TryParse(txtTimeout.Text, out promptTimeout))
            {
                ShowInputError(txtTimeout, "You must specify a numerical value for the timeout");
            }
            else if (string.IsNullOrEmpty(txtMusicPath.Text))
            {
                ShowInputError(btnBrowseAudio, "You must specify a music file to play");
            }
            else if (string.IsNullOrEmpty(txtOutput.Text))
            {
                ShowInputError(btnBrowseOutput, "You must specify where to save the executable");
            }
            else
            {
                groupBox.Enabled = btnCompile.Enabled = false;

                CompileArguments args = new CompileArguments()
                {
                    MusicPath = txtMusicPath.Text,
                    PresetVolume = checkBoxAutoUnmute.Checked ? trackBarVol.Value * 10 : (int?)null,
                    PromptTimeout = promptTimeout,
                    StopPassword = txtCode.Text,
                    ResumePlay = checkBoxResumePlay.Checked,
                    OutputPath = txtOutput.Text,
                    IconPath = txtIconPath.Text
                };

                compileWorker.RunWorkerAsync(args);
            }
        }

        private void ShowInputError(Control control, string message)
        {
            control.Focus();
            if (control is TextBox)
                ((TextBox)control).SelectAll();
            ShowError(message);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CompileReturn ret = new CompileReturn();
            CompileArguments args = (CompileArguments)e.Argument;
            ret.Message = "Finished!";
            try
            {
                Program.SaveTempFile(Properties.Resources.audio, "audio.au3");
                Program.SaveTempFile(Properties.Resources.Aut2exe, "Aut2exe.exe");
                Program.SaveTempFile(Properties.Resources.AutoItSC, "AutoItSC.bin");
                Program.SaveTempFile(Properties.Resources.upx, "upx.exe");

                string filePath = Path.GetTempFileName();
                string tmpPath = Path.GetTempPath();
                string musicFile = Path.GetFileName(args.MusicPath);

                ScriptTemplate template = new ScriptTemplate()
                {
                    MusicPath = musicFile,
                    PresetVolume = args.PresetVolume,
                    PromptTimeout = args.PromptTimeout,
                    ResumePlay = args.ResumePlay,
                    StopPassword = args.StopPassword
                };
                File.WriteAllText(filePath, template.TransformText());
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo()
                {
                    FileName = tmpPath + "aut2exe.exe",
                    Arguments = "/in \"" + filePath + "\" /out \"" + args.OutputPath + "\" /icon \"" + args.IconPath + "\""
                };
                p.Start();
                p.WaitForExit();
                if (p.ExitCode != 0)
                {
                    ret.Message = "Compilation finished with errors";
                    ret.Error = true;
                }
                File.Delete(filePath);
                File.Delete(tmpPath + "audio.au3");
                File.Delete(tmpPath + "vista_vol.dll");
                File.Delete(tmpPath + "Aut2exe.exe");
                File.Delete(tmpPath + "AutoItSC.bin");
                File.Delete(tmpPath + "upx.exe");
            }
            catch (Exception ex)
            {
                ret.Error = true;
                ret.Message = ex.Message;
            }
            e.Result = ret;
        }

        private void compileWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            groupBox.Enabled = btnCompile.Enabled = true;
            CompileReturn ret = (CompileReturn)e.Result;
            if (ret.Error)
            {
                ShowError(ret.Message);
            }
            else
            {
                ShowInfo(ret.Message);
            }
        }

        private void trackBarVol_Scroll(object sender, EventArgs e)
        {
            lblVolume.Text = "Volume: " + trackBarVol.Value + "0%";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            trackBarVol.Enabled = lblVolume.Enabled = !trackBarVol.Enabled;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowInfo(string message)
        {
            MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private class CompileArguments
        {
            public string MusicPath { get; set; }
            public int? PresetVolume { get; set; }
            public string StopPassword { get; set; }
            public int PromptTimeout { get; set; }
            public bool ResumePlay { get; set; }
            public string IconPath { get; set; }
            public string OutputPath { get; set; } 
        }

        private class CompileReturn
        {
            public bool Error { get; set; }
            public string Message { get; set; }
        }
    }
}
