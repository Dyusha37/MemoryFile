using System;
using System.Windows.Forms;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading;


namespace MemoryFile2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Semaphore sem = new Semaphore(2, 3);
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                sem = Semaphore.OpenExisting("sem");
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                this.Text = "Memory-mapped file does not exist. Run Process A first.";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("procfile"))
                {
                    this.Text = "Form1";
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream(1, 0))
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(1);
                        sem.Release();
                    }
                }
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                this.Text = "Memory-mapped file does not exist. Run Process A first.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("procfile"))
                {
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream(1, 0))
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(2);
                        sem.Release();
                    }
                    this.Text = "button2";
                }
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                this.Text = "Memory-mapped file does not exist. Run Process A first.";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("procfile"))
                {
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream(1, 0))
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(3);
                        sem.Release();
                    }
                    this.Text = "button3";
                }
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                this.Text = "Memory-mapped file does not exist. Run Process A first.";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("procfile"))
                {
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream(1, 0))
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(4);
                        sem.Release();
                    }
                    this.Text = "button4";
                }
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                this.Text = "Memory-mapped file does not exist. Run Process A first.";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("procfile"))
                {
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream(1, 0))
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(5);
                        sem.Release();
                    }
                    this.Text = "button5";
                }
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                this.Text = "Memory-mapped file does not exist. Run Process A first.";
            }
        }
    }
}
