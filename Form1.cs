using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CPUMon
{
    public partial class Form1 : Form
    {

        private PerformanceCounter cpuCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        private PerformanceCounter memCounter = new PerformanceCounter("Memory", "Available MBytes");

        private PerformanceCounter sysCounter = new PerformanceCounter("System", "System Up Time");

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick_1(object sender, System.EventArgs e)
        {
            TimeSpan t = TimeSpan.FromSeconds((int)sysCounter.NextValue());

            string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                            t.Hours,
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);

            cpuLabel.Text = $"CPU: {(int)cpuCounter.NextValue()} %";
            memoryLabel.Text = $"Available Memory: {(int)memCounter.NextValue()} MB";
            sysLabel.Text = $"System up for: {t}";
        }

    }
}
