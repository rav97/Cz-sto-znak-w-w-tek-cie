using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Częstość
{
    public partial class Form1 : Form
    {
        public string filepath, inputText;
        public Form1()
        {
            InitializeComponent();
        }

        private void ReadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filepath = openFileDialog1.FileName;
            }
            path.Text=filepath;
            if (filepath != null)
            {
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                try
                {
                    StreamReader sr = new StreamReader(fs);
                    inputText = sr.ReadToEnd();
                    sr.Close();
                }
                catch (Exception ex){
                    MessageBox.Show(ex.ToString());
                }
                string input = inputText.ToUpper();
                output.Text = "";
                zliczaj(input);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void path_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void output_TextChanged(object sender, EventArgs e)
        {

        }

        private void zliczaj(string txt)
        {
            IDictionary<char, int> znakIle = new Dictionary<char, int>();
            float inputSize;
            inputSize = (float)txt.Length;

            for(int i=0;i<txt.Length;i++)
            {
                if (znakIle.ContainsKey(txt[i]))
                    znakIle[txt[i]] += 1;
                else
                    znakIle[txt[i]] = 1;
            }
            print(znakIle, inputSize);
        }
        private void print(IDictionary<char,int> dict, float size)
        {
            float percent;
            dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (KeyValuePair<char,int> kvp in dict)
            {
                if (kvp.Key < 'A' | kvp.Key > 'Z')
                    continue;
                percent = ((float)dict[kvp.Key] / size) * 100;
                output.Text = output.Text + kvp.Key + "\t\t" + dict[kvp.Key] + "\t\t" + (int)percent + "\n";
            }
        }
    }
}
