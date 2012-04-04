using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
            groupBox1.Enabled =
            button3.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void SaveTempFile(byte[] data, string file)
        {
            if (File.Exists(Path.GetTempPath() + "\\" + file)) { File.Delete(Path.GetTempPath() + "\\" + file); }
            Stream stream = new MemoryStream(data);
            FileStream fileStream = new FileStream(Path.GetTempPath() + "\\" + file, FileMode.CreateNew);
            for (int i = 0; i < stream.Length; i++)
                fileStream.WriteByte((byte)stream.ReadByte());
            fileStream.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SaveTempFile(Properties.Resources.audio, "audio.au3");
                SaveTempFile(Properties.Resources.vista_vol, "vista_vol.dll");
                SaveTempFile(Properties.Resources.Aut2exe, "Aut2exe.exe");
                SaveTempFile(Properties.Resources.AutoItSC, "AutoItSC.bin");
                SaveTempFile(Properties.Resources.upx, "upx.exe");
                string filePath = Path.GetTempFileName();
                string tmpPath = Path.GetTempPath();
                string musicFile = textBox1.Text.Split('\\')[textBox1.Text.Split('\\').GetUpperBound(0)];

                string script =
                    "#NoTrayIcon\r\n" +
                    "#include <audio.au3>\r\n" +
                    "OnAutoItExitRegister( \"_Exit\" )\r\n" +
                    "HotKeySet(\"^+l\", \"_Input\")\r\n" +
                    "FileInstall( \"" + textBox1.Text + "\", @Tempdir & \"\\" + musicFile + "\" )\r\n" +
                    "FileInstall( \"vista_vol.dll\", @TempDir & \"\\vista_vol.dll\" )\r\n" +
                    "$sound = _SoundOpen(@TempDir & \"\\" + musicFile + "\")\r\n" +
                    "if @error then exit\r\n" +
                    "if Not StringInStr(@OSVersion, \"XP\") AND Not StringInStr(@OSVersion, \"2000\") Then\r\n" +
                    "   PluginOpen(@TempDir & \"\\vista_vol.dll\")\r\n" +
                    "   if @error then exit\r\n" +
                    "EndIf\r\n" +
                    "While 1\r\n" +
                    "   $pos = MouseGetPos()\r\n" +
                    "   Sleep(10)\r\n" +
                    "   $pos2 = MouseGetPos()\r\n" +
                    "   if $pos[0] & $pos[1] <> $pos2[0] & $pos2[1] then\r\n";
                if (checkBox2.Checked)
                {
                    script +=
                    "       if Not StringInStr(@OSVersion, \"XP\") AND Not StringInStr(@OSVersion, \"2000\") Then\r\n" +
                    "           if _IsMute_Vista() Then _SetMute_Vista(False)\r\n" +
                    "           if _GetMasterVolumeScalar_Vista() < " + vol + " Then _SetMasterVolumeScalar_Vista(" + vol + ")\r\n" +
                    "       EndIf\r\n";
                }
                script +=
                    "       _SoundPlay($sound)\r\n" +
                    "       Do\r\n" +
                    "           $pos = MouseGetPos()\r\n" +
                    "           Sleep(100)\r\n" +
                    "           $pos2 = MouseGetPos()\r\n" +
                    "       Until $pos[0] = $pos2[0] And $pos2[1] = $pos[1]\r\n";
          if (checkBox1.Checked) { 
          script += "       _SoundPause($sound)\r\n"; } else{
          script += "       _SoundStop($sound)\r\n"; }
          script += "   EndIf\r\n" +
                    "WEnd\r\n" +

                    "Func _Input()\r\n" +
                    "   $text = InputBox(\"SecurityCheck\", \"Password\", \"\", \"\", -1, -1, 0, 0, " + textBox5.Text + ")\r\n" +
                    "   if @error Then Return 0\r\n" +
                    "   if StringCompare($text, \"" + textBox2.Text + "\", 1) == 0 Then Exit\r\n" +
                    "EndFunc\r\n" +

                    "Func _Exit()\r\n" +
                    "   FileDelete( @TempDir & \"\\" + musicFile + "\" )\r\n" +
                    "   FileDelete( @TempDir & \"\\vista_vol.dll\" )\r\n" +
                    "EndFunc";
                File.WriteAllText(filePath, script);
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = tmpPath + "aut2exe.exe";
                p.StartInfo.Arguments = "/in \"" + filePath + "\" /out \"" + textBox3.Text + "\" /icon \"" + textBox4.Text + "\"";
                p.Start();
                p.WaitForExit();
                File.Delete(filePath);
                File.Delete(tmpPath + "audio.au3");
                File.Delete(tmpPath + "vista_vol.dll");
                File.Delete(tmpPath + "Aut2exe.exe");
                File.Delete(tmpPath + "AutoItSC.bin");
                File.Delete(tmpPath + "upx.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            groupBox1.Enabled =
                button3.Enabled = true;
            MessageBox.Show(this, "Finished!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        int vol = 50;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            vol = 10 * trackBar1.Value;
            label7.Text = "Volume: " + trackBar1.Value + "0%";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Enabled =
                label7.Enabled = !trackBar1.Enabled;
        }
    }
}
