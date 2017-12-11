using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlyPig.Util;
using System.IO;
using System.Diagnostics;

namespace FPStudy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IniHelper iniHelper = new IniHelper(Path.Combine(Environment.CurrentDirectory, "test.ini"));
            iniHelper.WriteValue("sec", "key1", "value1");
            MessageBox.Show("ok");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Environment.CurrentDirectory);
        }
    }
}
