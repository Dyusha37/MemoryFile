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
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Threading;

namespace MemoryFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Semaphore sem = new Semaphore(0, 2, "sem");
        Process newPrc = new Process();
        Thread th;
        private void Form1_Load(object sender, EventArgs e)
        {
            th = new Thread(run);
            newPrc.StartInfo.FileName = @"MemoryFile2\MemoryFile2\bin\Debug\MemoryFile2.exe";
            th.Start();


        }
        public void run()
        {
            using (MemoryMappedFile mmf = MemoryMappedFile.CreateNew("procfile", 10000))
            {
                newPrc.Start();
                Thread.Sleep(500);
                int i;

                while (true)
                {

                    using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                    {
                        sem.WaitOne();
                        BinaryReader reader = new BinaryReader(stream);
                        i = reader.ReadInt32();
                        i = (int)i / 254;
                        richTextBox1.Invoke(new Action(() => richTextBox1.Text += ("Pressed " + i.ToString()) + " button\n"));
                    }

                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                th.Abort();
                newPrc.Kill();
            }
            catch { }
        }

        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {
            try
            {
                th.Abort();
                newPrc.Kill();
            }
            catch { }
        }
    }
}
