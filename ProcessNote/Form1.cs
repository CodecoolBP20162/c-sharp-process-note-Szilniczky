using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace ProcessNote
{
    public partial class Form1 : Form
    {
  
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;
  
      public Form1()
        {
            InitializeComponent();
            InitialiseCPUCounter();
            InitializeRAMCounter();
        }

        private void InitialiseCPUCounter()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
        }

        private void InitializeRAMCounter()
        {
            ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);

        }

        public void UpdateTasks()
        {
            listBox1.Items.Clear();
            foreach (Process task in Process.GetProcesses())
            {
                listBox1.Items.Add(task.ProcessName);
            }
        }

        public void Properties()
        {
            Process[] task = Process.GetProcesses();
            foreach(Process proc in task)
            {
                if (listBox1.SelectedItem.ToString() == proc.ProcessName)
                {


                    String temp = String.Empty;
                    String time = String.Empty;
                    temp += "Process ID :" + proc.Id.ToString();
                    time += "Process Start Time :" + proc.StartTime.ToString();
                    MessageBox.Show(temp);
                    MessageBox.Show(time);
                    break;
                }
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.UpdateTasks();
        }

        private void updateNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.UpdateTasks();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Properties();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process[] task = Process.GetProcesses();
            foreach (Process proc in task)
            {
                if (listBox1.SelectedItem.ToString() == proc.ProcessName)
                {
                    string cpu = string.Empty;
                    cpu += "CPU Usage: " + Convert.ToInt32(cpuCounter.NextValue()).ToString() + "%";
                    MessageBox.Show(cpu);
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process[] task = Process.GetProcesses();
            foreach (Process proc in task)
            {
                if (listBox1.SelectedItem.ToString() == proc.ProcessName)
                {
                    string ram = string.Empty;
                    ram += "RAM Usage: " + Convert.ToInt32(ramCounter.NextValue()).ToString() + "Mb";
                    MessageBox.Show(ram);
                    break;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamWriter file = File.AppendText("TestFile.txt");
            file.WriteLine(textBox1.Text);
            file.Close();
        }
    }
}
