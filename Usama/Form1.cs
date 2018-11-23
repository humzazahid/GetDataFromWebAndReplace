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
using System.Net;
using System.Xml;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace Usama
{
    public partial class Form1 : Form
    {
        private static string text = "";
        
        
        public Form1()
        {
            InitializeComponent();
            
        }
        public static int CountWords(string temp)
        {

            var pattern = new Regex(@"\b\w+\b");
            var match = pattern.Matches(temp);

            return match.Count;
        }

        public static int CountLines(string temp)
        {
            var pattern = new Regex(@"\n");
            var match = pattern.Matches(temp);

            return match.Count + 1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string URL = textBox1.Text;
            Uri newUri;
            var isValid = Uri.TryCreate(URL, UriKind.Absolute, out newUri);

            if (isValid)
            {
                var htmlWeb = new HtmlWeb();
                var htmlDoc = htmlWeb.Load(URL);
                foreach (var el in htmlDoc.DocumentNode.SelectNodes("//p").Elements())
                {
                    text += el.InnerText;
                }

                label1.Text = text;
            }
           label4.Text=Convert.ToString(CountLines(text));
           label5.Text = Convert.ToString(CountWords(text));
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Stream browse = null;
            OpenFileDialog myFile = new OpenFileDialog();
            myFile.InitialDirectory = "c:\\";
            myFile.InitialDirectory = "txt file (*.txt)|*.txt|All files (*.*)|*.*";
            myFile.FilterIndex = 2;
            myFile.RestoreDirectory = true;
            if(myFile.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    if ((browse = myFile.OpenFile()) != null)
                    {
                        using(browse)
                        {
                            label1.Text = File.ReadAllText(myFile.FileName);
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR: Could not read file");
                }
            }
            label4.Text = Convert.ToString(CountLines(text));
            label5.Text = Convert.ToString(CountWords(text));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var pattern = new Regex(@"\b" + textBox2.Text + @"\b");
            text=pattern.Replace(text, textBox3.Text);
            label1.Text = text;
            MessageBox.Show("operation successed");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
