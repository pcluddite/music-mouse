namespace Musical_Mouse_Customizer
{
    partial class ScriptTemplate
    {
        public string MusicPath { get { return musicPath; } set { _musicPathField = value; } }
        public int? PresetVolume { get { return presetVolume; } set { _presetVolumeField = value; } }
        public string StopPassword { get { return stopPassword; } set { _stopPasswordField = value; } }
        public int PromptTimeout { get { return promptTimeout; } set { _promptTimeoutField = value; } }
        public bool ResumePlay { get { return resumePlay; } set { _resumePlayField = value; } }

        public ScriptTemplate()
        {
            _vistaVolPathField = Program.SaveTempFile(Properties.Resources.vista_vol, "vista_vol.dll");
        }
    }
}