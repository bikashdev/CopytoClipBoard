using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace CopyToClipboard
{
    public partial class Form1 : Form
    {
        //string[] arrayStrings = new string[10];
        public static List<string> arrayStrings = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Text1.Text);
            showMessage("Copied");
        }

        private void btnCopy2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Text2.Text);
            showMessage("Copied");
        }

        private void btnCopy3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Text3.Text);
            showMessage("Copied");
        }

        private void btnCopy4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Text4.Text);
            showMessage("Copied");
        }

        private void btnCopy5_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Text5.Text);
            showMessage("Copied");
        }

        private void btnCopy6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Text6.Text);
            showMessage("Copied");
        }

        public void showMessage(string msg)
        {
            MessageBox.Show(msg);
        }
        public void setValues(List<string> list)
        {
            int count = 0;
            count = list.Count();
            List<Label> listCtrl = new List<Label>();
            listCtrl = Controls.OfType<Label>().ToList();
            for (int i = 0; i < count; i++)
            {
                for (int label = 1; label < listCtrl.Count; label++)
                {
                    if (i + 2 == label + 1)
                    {
                        listCtrl[label].Text = list[i];
                    }
                }
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();

            if (iData.GetDataPresent(DataFormats.Text))
            {
                Text1.Text = (string)iData.GetData(DataFormats.Text);
                if (arrayStrings.Count() == 0)
                {
                    arrayStrings.Add(Text1.Text);
                }

                if (arrayStrings.Count() > 0 && !arrayStrings.Contains(Text1.Text))
                {
                    arrayStrings.Add(Text1.Text);
                    setValues(arrayStrings);
                }


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
