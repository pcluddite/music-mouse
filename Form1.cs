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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = openFileDialog2.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = saveFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int promptTimeout;
            if (!int.TryParse(textBox5.Text, out promptTimeout))
            {
                ShowInputError(textBox5, "You must specify a numerical value for the timeout");
            }
            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                ShowInputError(button1, "You must specify a music file to play");
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                ShowInputError(button2, "You must specify where to save the executable");
            }
            else
            {
                groupBox1.Enabled = button3.Enabled = false;

                CompileArguments args = new CompileArguments()
                {
                    MusicPath = textBox1.Text,
                    PresetVolume = checkBox2.Checked ? trackBar1.Value : (int?)null,
                    PromptTimeout = promptTimeout,
                    StopPassword = textBox2.Text,
                    ResumePlay = checkBox1.Checked,
                    OutputPath = textBox3.Text,
                    IconPath = textBox4.Text
                };

                backgroundWorker1.RunWorkerAsync(args);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            groupBox1.Enabled = button3.Enabled = true;
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

        int vol = 50;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            vol = 10 * trackBar1.Value;
            label7.Text = "Volume: " + trackBar1.Value + "0%";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Enabled = label7.Enabled = !trackBar1.Enabled;
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
