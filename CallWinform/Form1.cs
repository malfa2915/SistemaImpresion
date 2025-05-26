using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallWinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var location = new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath;
            var path = Path.GetDirectoryName(location);
            var serverPath = Path.Combine(path, "DeskTest.exe");
            Process cmd = new Process();
            cmd.StartInfo.FileName = @"D:\PrintServiceHelios\HeliosPrintService\DeskTest\bin\Debug\DeskTest.exe";// serverPath;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            //using (var f = File.Create(Path.Combine(path, "TestFile.txt")))
            //{
            //    filePath = f.Name;
            //}

           cmd.StartInfo.Arguments = @"D:\PrintServiceHelios\HeliosPrintService\DeskTest\bin\Debug\DeskTest.exe"; ;
            cmd.Start();
         //   processId = cmd.Id;
        }
    }
}
