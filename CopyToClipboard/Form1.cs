using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        string[] format = new string[] { "MM/dd/yyyy HH:mm:ss" };
        public Form1()
        {
            InitializeComponent();
            ReadFile();
        }
        private void ReadFile()
        {
            string path = "C:\\Users\\Bikash1\\Desktop\\CTC\\SavedList.txt";
            if (Directory.Exists("C:\\Users\\Bikash1\\Desktop\\CTC"))
            {
                if (File.Exists(path))
                {
                    int concedeDateTime = 0;
                    using (StreamReader SRead = new StreamReader(path))
                    {
                        // Use while not null pattern in while loop.
                        string line;
                        while ((line = SRead.ReadLine()) != null)
                        {
                            DateTime datetime;

                            if (DateTime.TryParseExact(line, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                                concedeDateTime++;
                            else if (concedeDateTime > 1)
                                break;
                            else if (line != null && line.Trim() != string.Empty)
                                arrayStrings.Add(line.Trim());
                        }
                    }
                    setValues(arrayStrings);
                }
            }

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
            MessageBox.Show(msg, "Information", MessageBoxButtons.OK);
        }
        public void setValues(List<string> list)
        {
            int listCount = 0;
            int valuesSetCount = 0;
            listCount = list.Count();
            List<Label> listCtrl = new List<Label>();
            listCtrl = Controls.OfType<Label>().ToList();
            for (int label = 0; label < listCtrl.Count; label++)
            {
                for (int i = 0; i < listCount; i++)
                {
                    if (i + 1 == listCtrl[label].TabIndex && listCtrl[label].Name != "title")
                    {
                        listCtrl[label].Text = list[i];
                        valuesSetCount++;

                        if (valuesSetCount == listCount)
                            break;
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

                if (arrayStrings.Count() > 0 && !arrayStrings.Contains(Text1.Text))
                {
                    //arrayStrings = Rearrange(arrayStrings);
                    arrayStrings.Insert(0, Text1.Text);
                    setValues(arrayStrings);
                }
                //if the string/item is in the list of string
                else if (arrayStrings.Contains(Text1.Text))
                {
                    int index = arrayStrings.FindIndex(x => x.StartsWith(Text1.Text));
                    arrayStrings.RemoveAt(index);
                    //arrayStrings = Rearrange(arrayStrings);
                    arrayStrings.Insert(0, Text1.Text);
                    setValues(arrayStrings);
                }
                else
                {
                    arrayStrings.Insert(0, Text1.Text);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 a = new Form1();
        }

        public void writetoFile(List<string> list)
        {
            using (TextWriter tw = new StreamWriter("C:\\Users\\Bikash1\\Desktop\\CTC\\SavedList.txt"))
            {
                tw.WriteLine(DateTime.Now.ToString(format[0]));
                tw.WriteLine("--------------------------------------");
                foreach (String s in list)
                {
                    tw.WriteLine(s);
                }
                tw.WriteLine("--------------------------------------");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Display a MsgBox asking the user to save changes or abort.
            if (MessageBox.Show("Do you want to save changes?", "CTC", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Cancel the Closing event from closing the form.

                writetoFile(arrayStrings);
                Application.Exit();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Display a MsgBox asking the user to save changes or abort.
            if (MessageBox.Show("Do you want to save changes?", "CTC", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Save the changes.                
                writetoFile(arrayStrings);
                
            }
        }
        private List<string> Rearrange(List<string> arrayStrings)
        {
            List<string> temp = new List<string>();
            int count = arrayStrings.Count;
            temp = arrayStrings;

            for (int i = 0; i < count; i++)
            {
                string tempString = string.Empty;
                if (arrayStrings[i] != string.Empty)
                    temp.Insert(i + 1, arrayStrings[i]);

                //do nothing

            }
            return temp;
        }
    }
}
