using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsA.Classes;
using KlonsA.DataSets;

namespace KlonsA.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            var wrs = KlonsData.St.CollectedRefs.Where(r => r.IsAlive);
            foreach(var wr in wrs)
            {
                listBox1.Items.Add(wr.Target.GetType().Name);
            }
        }
    }
}
